using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TriumphSupportUtility.Interfaces;
using TriumphSupportUtility.Systems;
using TriumphSupportUtility.Tools;
using TriumphSupportUtility.UIControllers;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_UserClient : Form
    {
        IConfiguration config;
        private UIController_Button uiController_ToolButtons;
        private Interface_TcpClient agentController_Client;
        private SystemInfo_Base systemInfo_ThisPC;
        private SystemService_Base systemService_Crowdstrike;
        private SystemService_Base systemService_Dameware;
        private SystemService_Base systemService_Teamviewer;
        private SystemService_Base systemService_Zscaler;
        private SystemService_Base systemService_Mimecast;
        private SystemService_Base systemService_SnowInventoryAgent;
        private SystemService_Base systemService_MsOffice365;
        private SystemService_Base systemService_MsTeams;
        private SystemService_Base systemService_ArcticWolf;
        private Tool_Base tool_TeamViewer;
        private Tool_VBS tool_MapDrives;
        private bool isElevated;

        public WinForm_UserClient()
        {
            InitializeComponent();
            Init();
        }

        private void Display_AgentController_ConnectionStatus()
        {
            if (agentController_Client.isOnline && agentController_Client.isLoopback)
            {
                Label_ConnectionState.Text = $"Connection Success @ {agentController_Client.ipv4Address} [{agentController_Client.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Green;
            }
            else if (agentController_Client.isOnline)
            {
                Label_ConnectionState.Text = $"Connection Success @ {agentController_Client.ipv4Address} [{agentController_Client.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Green;
            }
            else
            {
                Label_ConnectionState.Text = $"Connection Unsuccessful @ {agentController_Client.ipv4Address} [{agentController_Client.hostName.ToUpper()}]";
                Label_ConnectionState.ForeColor = Color.Red;
            }
        }
        private void Display_Systems_GeneralInformation()
        {
            UIController_Textbox.SetTextboxText(TextBox_UsernameOutput, systemInfo_ThisPC.userName);
            UIController_Textbox.SetTextboxText(TextBox_HostnameOutput, systemInfo_ThisPC.hostName);
            UIController_Textbox.SetTextboxText(TextBox_DomainNameOutput, systemInfo_ThisPC.domainName);
            UIController_Textbox.SetTextboxText(TextBox_Ipv4AddressOutput, systemInfo_ThisPC.ipv4Address);
            UIController_Textbox.SetTextboxText(TextBox_LanMacAddressOutput, systemInfo_ThisPC.lanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_WlanMacAddressOutput, systemInfo_ThisPC.wlanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_LogonServerOutput, systemInfo_ThisPC.logonServer);
        }
        private void Init()
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
        private void Init_Config()
        {
            if (!File.Exists("config.json"))
                TriumphSupportUtility.Components.Configuration.ClientConfiguration_Rebuild();
            config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
        }
        private void Init_ProgramInfo()
        {
            Label_ProgTitle.Text = config.GetSection("ProgramInformation:ProgramName").Get<string>().ToUpper();
            Label_ProgSubTitle.Text = $"IT Service Desk - UK (Version {config.GetSection("ProgramInformation:Version").Get<string>()})";
            Label_Author.Text = $"Author: {config.GetSection("ProgramInformation:Author").Get<string>()}";
        }
        private void Init_Interfaces()
        {
            agentController_Client = new Interface_TcpClient("127.0.0.1", 3027);
        }
        private void Init_Systems()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading General Information. . .", Color.Orange);

            systemInfo_ThisPC = new SystemInfo_Base();

            if (agentController_Client.isOnline)
            {
                JsonConvert.PopulateObject(agentController_Client.Request("/sysinfo -thispc"), systemInfo_ThisPC);

                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loaded General Information; Ready", Color.Green);
            }
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Not Loaded General Information; Ready", Color.Orange);
        }
        private void Init_Tools()
        {
            uiController_ToolButtons = new UIController_Button();
            uiController_ToolButtons.SetUIElementButtons(TabControl_Tools.TabPages.Cast<TabPage>().SelectMany(tabPage => tabPage.Controls.Cast<Control>().OfType<Button>()).ToList());

            bool initTools_isSuccess = false;
            do
            {
                try
                {
                    tool_TeamViewer = new Tool_Base(
                        config.GetSection("ProgramParameters:Tools:UserTools:TeamViewer:Name").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:TeamViewer:ToolPath_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:TeamViewer:WaitToExit").Get<bool>());

                    tool_MapDrives = new Tool_VBS(
                        config.GetSection("ProgramParameters:Tools:UserTools:MapDrives:Name").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:MapDrives:ToolPath_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:MapDrives:ToolWorkingPath").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:MapDrives:ToolArguments").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:UserTools:MapDrives:WaitToExit").Get<bool>());

                    initTools_isSuccess = true;
                }
                catch (Exception)
                {

                    TriumphSupportUtility.Components.Configuration.ClientConfiguration_Rebuild();
                }

            } while (!initTools_isSuccess);

            uiController_ToolButtons.ToggleUiElements(agentController_Client.isOnline && agentController_Client.isLoopback);
        }

        #region WinForm_Butttons
        public void Button_Refresh_Click(object sender, EventArgs e)
        {
            Button_Refresh.Enabled = false;
            Display_AgentController_ConnectionStatus();
            Init_Systems();
            Init_Tools();
            Display_Systems_GeneralInformation();
            Button_Refresh.Enabled = true;
        }

        //User Tools
        private async void Button_LaunchTeamviewer_Click(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_TeamViewer.toolName}. . .", Color.Orange);

            this.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_TeamViewer.LaunchToolAsync(progressBarController))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_TeamViewer.toolName} Launch Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_TeamViewer.toolName} Launch Unsuccessful, Verify Install; Ready", Color.DarkOrange);

            progressBarController.Reset();
            this.Enabled = true;
        }
        private async void Button_LaunchMapDrives_Click(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_MapDrives.toolName}. . .", Color.Orange);

            this.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_MapDrives.LaunchToolAsync(progressBarController, CheckBox_ShellExecVisibility.Checked))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_MapDrives.toolName} Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_MapDrives.toolName} Drives Unsuccessful, Verify Network; Ready", Color.DarkOrange);

            progressBarController.Reset();
            this.Enabled = true;
        }
        private void Button_LaunchPrinterInstall_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            WinForm_PrinterInstall printerInstall = new WinForm_PrinterInstall();
            printerInstall.ShowDialog(this);

            if (printerInstall.DialogResult == DialogResult.OK)
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Successful; Ready", Color.Green);
            else if (printerInstall.DialogResult == DialogResult.Cancel)
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Terminated; Ready", Color.DarkOrange);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Printer Install Unsuccessful, Verify Network & UAC; Ready", Color.Red);

            this.Enabled = true;
        }

        //Resources
        private void Button_LaunchWindchill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramParameters:Tools:Resources:Windchill:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Windchill Loaded; Ready", Color.Green);
        }
        private void Button_LaunchTriumphOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramParameters:Tools:Resources:TOL:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Triumph Online Loaded; Ready", Color.Green);
        }
        private void Button_LaunchWakeOnLAN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramParameters:Tools:Resources:WOL:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Wake On LAN Loaded; Ready", Color.Green);

        }
        #endregion

        #region WinForm_LinkLabels
        private void LinkLabel_SysAid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramParameters:Links:SysAid:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "SysAid Loaded;\r\nReady", Color.Green);
        }
        private void LinkLabel_ReportABug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = config.GetSection("ProgramParameters:Links:ReportABug:Link").Get<string>(), UseShellExecute = true });
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Report a Bug Loaded;\r\nReady", Color.Green);
        }
        #endregion
    }
}