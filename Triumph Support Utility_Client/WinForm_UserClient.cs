using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Security.Principal;
using TriumphSupportUtility.Interfaces;
using TriumphSupportUtility.Systems;
using TriumphSupportUtility.Tools;
using TriumphSupportUtility.UIControllers;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_UserClient : Form
    {
        protected IConfiguration config;
        protected UIController_Button uiController_ToolButtons;
        protected Interface_TcpClient agentController_TcpClient;
        protected SystemInfo_Base systemInfo_ThisPC;
        protected Tool_Base tool_TeamViewer;
        protected Tool_VBS tool_MapDrives;
        protected bool isElevated;

        protected virtual void OnLoad(object sender, EventArgs e)
        {
            if (!this.DesignMode)
                Init();
        }
        public WinForm_UserClient()
        {
            InitializeComponent();
        }

        protected virtual void Display_AgentController_ConnectionStatus()
        {
            if (agentController_TcpClient.isOnline && agentController_TcpClient.isLoopback)
            {
                Label_ConnectionState.Text = $"Connection Success @ {agentController_TcpClient.ipv4Address} [{agentController_TcpClient.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Green;
            }
            else if (agentController_TcpClient.isOnline)
            {
                Label_ConnectionState.Text = $"Connection Success @ {agentController_TcpClient.ipv4Address} [{agentController_TcpClient.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Green;
            }
            else
            {
                Label_ConnectionState.Text = $"Connection Unsuccessful @ {agentController_TcpClient.ipv4Address} [{agentController_TcpClient.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Red;
            }
        }
        protected virtual void Display_Systems_GeneralInformation()
        {
            UIController_Textbox.SetTextboxText(TextBox_UsernameOutput, systemInfo_ThisPC.userName);
            UIController_Textbox.SetTextboxText(TextBox_HostnameOutput, systemInfo_ThisPC.hostName);
            UIController_Textbox.SetTextboxText(TextBox_DomainNameOutput, systemInfo_ThisPC.domainName);
            UIController_Textbox.SetTextboxText(TextBox_Ipv4AddressOutput, systemInfo_ThisPC.ipv4Address);
            UIController_Textbox.SetTextboxText(TextBox_LanMacAddressOutput, systemInfo_ThisPC.lanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_WlanMacAddressOutput, systemInfo_ThisPC.wlanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_LogonServerOutput, systemInfo_ThisPC.logonServer);
        }
        protected virtual void Init()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading Information. . .", Color.DarkOrange);

            isElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

            Init_Config();
            Init_ProgramInfo();
            Init_Interfaces();
            Init_Systems();
            Init_Tools();

            Display_AgentController_ConnectionStatus();
            Display_Systems_GeneralInformation();

            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Ready", Color.Green);
        }
        protected virtual void Init_Config()
        {
            if (!File.Exists("config.json"))
                TriumphSupportUtility.Core.Configuration.ClientConfiguration_Rebuild();
            config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
        }
        protected virtual void Init_ProgramInfo()
        {
            Label_ProgTitle.Text = config.GetSection("ProgramSettings:ProgramParameters:Name").Get<string>().ToUpper();
            Label_ProgSubTitle.Text = $"IT Service Desk - UK (Version {config.GetSection("ProgramSettings:ProgramParameters:Version").Get<string>()})";
            Label_Author.Text = $"Author: Daniel Mullings";
        }
        protected virtual void Init_Interfaces()
        {
            agentController_TcpClient = new Interface_TcpClient(IPAddress.Loopback.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:TcpPort").Get<int>());
        }
        protected virtual void Init_Systems()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading General Information. . .", Color.Orange);

            systemInfo_ThisPC = new SystemInfo_Base();

            if (agentController_TcpClient.isOnline)
            {
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysinfo -thispc"), systemInfo_ThisPC);

                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loaded General Information; Ready", Color.Green);
            }
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Not Loaded General Information; Ready", Color.Orange);
        }
        protected virtual void Init_Tools()
        {
            uiController_ToolButtons = new UIController_Button();
            uiController_ToolButtons.SetUIElementButtons(TabControl_Tools.TabPages.Cast<TabPage>().SelectMany(tabPage => tabPage.Controls.Cast<Control>().OfType<Button>()).ToList());

            bool initTools_isSuccess = false;
            do
            {
                try
                {
                    tool_TeamViewer = new Tool_Base(
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:Name").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:ToolPathCollection_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:WaitToExit").Get<bool>());

                    tool_MapDrives = new Tool_VBS(
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:Name").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolPathCollection_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolWorkingPath").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolArgument").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:WaitToExit").Get<bool>());

                    initTools_isSuccess = true;
                }
                catch (Exception)
                {

                    TriumphSupportUtility.Core.Configuration.ClientConfiguration_Rebuild();
                }

            } while (!initTools_isSuccess);

            uiController_ToolButtons.ToggleUiElements(agentController_TcpClient.isOnline && agentController_TcpClient.isLoopback);
        }

        #region WinForm_Butttons
        protected virtual void Button_Refresh_Click(object sender, EventArgs e)
        {
            Button_Refresh.Enabled = false;
            Display_AgentController_ConnectionStatus();
            Init_Systems();
            Init_Tools();
            Display_Systems_GeneralInformation();
            Button_Refresh.Enabled = true;
        }

        //User Tools
        protected virtual async void Button_LaunchTeamviewer_ClickAsync(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_TeamViewer.toolName}. . .", Color.Orange);

            this.TabControl_Tools.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_TeamViewer.LaunchToolAsync(progressBarController))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_TeamViewer.toolName} Launch Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_TeamViewer.toolName} Launch Unsuccessful, Verify Install; Ready", Color.DarkOrange);

            progressBarController.Reset();
            this.TabControl_Tools.Enabled = true;
        }
        protected virtual async void Button_LaunchMapDrives_ClickAsync(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_MapDrives.toolName}. . .", Color.Orange);

            this.TabControl_Tools.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_MapDrives.LaunchToolAsync(progressBarController, CheckBox_ShellExecVisibility.Checked))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_MapDrives.toolName} Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_MapDrives.toolName} Drives Unsuccessful, Verify Network; Ready", Color.DarkOrange);

            progressBarController.Reset();
            this.TabControl_Tools.Enabled = true;
        }
        protected virtual void Button_LaunchPrinterInstall_Click(object sender, EventArgs e)
        {
            this.TabControl_Tools.Enabled = false;
            WinForm_PrinterInstall printerInstall = new WinForm_PrinterInstall();
            printerInstall.ShowDialog(this);

            if (printerInstall.DialogResult == DialogResult.OK)
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Successful; Ready", Color.Green);
            else if (printerInstall.DialogResult == DialogResult.Cancel)
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Terminated; Ready", Color.DarkOrange);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Unsuccessful, Verify Network & UAC; Ready", Color.Red);

            this.TabControl_Tools.Enabled = true;
        }

        //Resources
        protected virtual void Button_LaunchWindchill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramSettings:ToolParameters:Resources:Windchill:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Windchill Loaded; Ready", Color.Green);
        }
        protected virtual void Button_LaunchTriumphOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramSettings:ToolParameters:Resources:TOL:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Triumph Online Loaded; Ready", Color.Green);
        }
        protected virtual void Button_LaunchWakeOnLAN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramSettings:ToolParameters:Resources:WOL:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Wake On LAN Loaded; Ready", Color.Green);

        }
        #endregion

        #region WinForm_LinkLabels
        protected virtual void LinkLabel_SysAid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramSettings:ProgramParameters:Links:SysAid:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "SysAid Loaded;\r\nReady", Color.Green);
        }
        protected virtual void LinkLabel_ReportABug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramSettings:ProgramParameters:Links:ReportABug:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Report a Bug Loaded;\r\nReady", Color.Green);
        }
        #endregion
    }
}