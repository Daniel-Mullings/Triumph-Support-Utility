using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TriumphSupportUtility.Components;
using TriumphSupportUtility.Interfaces;
using TriumphSupportUtility.Systems;
using TriumphSupportUtility.Tools;
using TriumphSupportUtility.UIControllers;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_AdminClient : Form
    {
        IConfiguration config;
        private UIController_Button uiController_ToolButtons;
        private Interface_TcpClient agentController_TcpClient;
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
        private Tool_CMD tool_SnowAgentScan;
        private bool isElevated;

        public WinForm_AdminClient()
        {
            InitializeComponent();
            Init();
        }

        private void Display_AgentController_ConnectionStatus()
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
        private void Display_Systems_GeneralInformation()
        {
            UIController_Textbox.SetTextboxText(TextBox_UsernameOutput, systemInfo_ThisPC.userName);
            UIController_Textbox.SetTextboxText(TextBox_HostnameOutput, systemInfo_ThisPC.hostName);
            UIController_Textbox.SetTextboxText(TextBox_DomainNameOutput, systemInfo_ThisPC.domainName);
            UIController_Textbox.SetTextboxText(TextBox_Ipv4AddressOutput, systemInfo_ThisPC.ipv4Address);
            UIController_Textbox.SetTextboxText(TextBox_SubnetMaskOutput, systemInfo_ThisPC.subnetMask);
            UIController_Textbox.SetTextboxText(TextBox_LanMacAddressOutput, systemInfo_ThisPC.lanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_WlanMacAddressOutput, systemInfo_ThisPC.wlanMacAddress);
            UIController_Textbox.SetTextboxText(TextBox_LogonServerOutput, systemInfo_ThisPC.logonServer);

            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Crowdstrike.isInstalled, systemService_Crowdstrike.isRunning, TextBox_CrowdstrikeOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Dameware.isInstalled, TextBox_DamewareOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Teamviewer.isInstalled, systemService_Teamviewer.isRunning, TextBox_TeamviewerOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Zscaler.isInstalled, systemService_Zscaler.isRunning, TextBox_ZscalerOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Mimecast.isInstalled, TextBox_MimecastOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_SnowInventoryAgent.isInstalled, systemService_SnowInventoryAgent.isRunning, TextBox_SnowInventoryAgentOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_MsOffice365.isInstalled, TextBox_MsOffice365Output);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_MsTeams.isInstalled, TextBox_MsTeamsOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_ArcticWolf.isInstalled, systemService_ArcticWolf.isRunning, TextBox_ArcticWolfOutput);

            UIController_Textbox.SetTextboxText(TextBox_OsOutput, systemInfo_ThisPC.os);
            UIController_Textbox.SetTextboxText(TextBox_OsPlatformOutput, systemInfo_ThisPC.osPlatform);
            UIController_Textbox.SetTextboxText(TextBox_WinVerOutput, systemInfo_ThisPC.winVer);

            UIController_Textbox.SetTextboxText(TextBox_ManufactureOutput, systemInfo_ThisPC.manufacturer);
            UIController_Textbox.SetTextboxText(TextBox_ModelOutput, systemInfo_ThisPC.model);
            UIController_Textbox.SetTextboxText(TextBox_UptimeOutput, systemInfo_ThisPC.uptime);
            UIController_Textbox.SetTextboxText(TextBox_BuildDateOutput, systemInfo_ThisPC.buildDate);
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
            agentController_TcpClient = new Interface_TcpClient(IPAddress.None.ToString(), 3027);
            WinForm_ClientConnect winForm_getClientAddress = new WinForm_ClientConnect(agentController_TcpClient);
            winForm_getClientAddress.ShowDialog();
        }
        private void Init_Systems()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading General Information. . .", Color.Orange);

            systemInfo_ThisPC = new SystemInfo_Base();
            systemService_Crowdstrike = new SystemService_Base();
            systemService_Dameware = new SystemService_Base();
            systemService_Teamviewer = new SystemService_Base();
            systemService_Zscaler = new SystemService_Base();
            systemService_Mimecast = new SystemService_Base();
            systemService_SnowInventoryAgent = new SystemService_Base();
            systemService_MsOffice365 = new SystemService_Base();
            systemService_MsTeams = new SystemService_Base();
            systemService_ArcticWolf = new SystemService_Base();

            if (agentController_TcpClient.isOnline)
            {
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysinfo -thispc"), systemInfo_ThisPC);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -crowdstrike"), systemService_Crowdstrike);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -dameware"), systemService_Dameware);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -teamviewer"), systemService_Teamviewer);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -zscaler"), systemService_Zscaler);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -mimecast"), systemService_Mimecast);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -snowinventoryagent"), systemService_SnowInventoryAgent);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -msoffice365"), systemService_MsOffice365);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -msteams"), systemService_MsTeams);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -arcticwolf"), systemService_ArcticWolf);

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

                    tool_SnowAgentScan = new Tool_CMD(
                        config.GetSection("ProgramParameters:Tools:AdminTools:SnowScan:Name").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:AdminTools:SnowScan:ToolPath_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramParameters:Tools:AdminTools:SnowScan:ToolWorkingPath").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:AdminTools:SnowScan:ToolArguments").Get<string>(),
                        config.GetSection("ProgramParameters:Tools:AdminTools:SnowScan:WaitToExit").Get<bool>());

                    initTools_isSuccess = true;
                }
                catch (Exception)
                {

                    TriumphSupportUtility.Components.Configuration.ClientConfiguration_Rebuild();
                }

            } while (!initTools_isSuccess);

            uiController_ToolButtons.ToggleUiElements(agentController_TcpClient.isOnline && agentController_TcpClient.isLoopback);
        }

        #region WinForm_Butttons
        private void Button_ReTarget_Click(object sender, EventArgs e)
        {
            Init();
        }
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

        //Admin Tools
        private void Button_LaunchMessageBroadcast_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            WinForm_BroadcastNotification broadcastNotification = new WinForm_BroadcastNotification(config);
            broadcastNotification.ShowDialog(this);

            this.Enabled = true;
        }
        private async void Button_LaunchSnowScan_Click(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_SnowAgentScan.toolName}. . .", Color.Orange);

            this.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_SnowAgentScan.LaunchToolAsync(progressBarController, CheckBox_ShellExecVisibility.Checked))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_SnowAgentScan.toolName} Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_SnowAgentScan.toolName} Unsuccessful, Verify Install & UAC; Ready", Color.DarkOrange);

            progressBarController.Reset();
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