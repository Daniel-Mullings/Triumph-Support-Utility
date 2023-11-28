using static Triumph_Support_Utility.Systems;
using static Triumph_Support_Utility.Tools;

namespace Triumph_Support_Utility
{
    public partial class WinForm_Main : Form
    {
        private SystemInfo_Base systemInfo_ThisPC = new SystemInfo_Base();
        private SystemService_Base systemService_Crowdstrike = new SystemService_Base
            ("Crowdstrike",
            ["C:\\Program Files(x86)\\Crowdstrike", "C:\\Program Files\\Crowdstrike"],
            ["CSFalconService"]);
        private SystemService_Base systemService_Dameware = new SystemService_Base
            ("Dameware",
            ["C:\\Program Files (x86)\\SolarWinds\\Dameware Mini Remote Control", "C:\\Program Files\\SolarWinds\\Dameware Mini Remote Control x64"]);
        private SystemService_Base systemService_Teamviewer = new SystemService_Base
            ("TeamViewer",
            ["C:\\Program Files (x86)\\TeamViewer", "C:\\Program Files\\TeamViewer"],
            ["TeamViewer"]);
        private SystemService_Base systemService_Zscaler = new SystemService_Base
            ("ZScaler",
            ["C:\\Program Files (x86)\\Zscaler", "C:\\Program Files\\Zscaler"],
            ["ZSAService", "ZSATrayManager", "ZSATunnel", "ZSAUpdater", "ZSAUmp"]);
        private SystemService_Base systemService_Mimecast = new SystemService_Base
            ("Mimecast",
            ["C:\\Program Files (x86)\\Mimecast", "C:\\Program Files\\Mimecast"]);
        private SystemService_Base systemService_SnowInventoryAgent = new SystemService_Base
            ("Snow Inventory Agent",
            ["C:\\Program Files (x86)\\Snow Software", "C:\\Program Files\\Snow Software"],
            ["SnowInventoryAgent5"]);
        private SystemService_Base systemService_MsOffice365 = new SystemService_Base
            ("MS Office 365",
            ["C:\\Program Files (x86)\\Microsoft Office", "C:\\Program Files\\Microsoft Office"]);
        private SystemService_Base systemService_MsTeams = new SystemService_Base
            ("MS Teams",
            ["C:\\Program Files (x86)\\Teams Installer", "C:\\Program Files\\Teams Installer"]);
        private SystemService_Base systemService_ArcticWolf = new SystemService_Base
            ("Arctic Wolf",
            ["C:\\Program Files (x86)\\Arctic Wolf Networks", "C:\\Program Files\\Arctic Wolf Networks"],
            ["ArcticWolfAgentMgr", "Sysmon64"]);
        private Tool_Base tool_TeamViewer = new Tool_Base
            ("TeamViewer",
            ["C:\\Program Files (x86)\\TeamViewer\\Teamviewer.exe", "C:\\Program Files\\TeamViewer\\Teamviewer.exe"],
            false);
        private Tool_VBS tool_MapDrives = new Tool_VBS
            ("Map Drives",
            ["C:\\Windows\\System32\\cscript.exe"],
            ".\\Scripts",
            ".\\Map_Drives.vbs",
            true);
        private Tool_CMD tool_SnowScan = new Tool_CMD
            ("Snow Scan",
            ["C:\\Windows\\System32\\cmd.exe"],
            ".\\Scripts",
            $"\".\\Snow_Scan.bat\"",
            true);

        public WinForm_Main()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainForm_Init();
        }
        private void MainForm_Init()
        {
            SetTextboxText(textBox_progStatusOutput, "Loading Information. . .", Color.DarkOrange);

            SetTextboxText(textBox_usernameOutput, systemInfo_ThisPC.username);
            SetTextboxText(textBox_hostnameOutput, systemInfo_ThisPC.hostname);
            SetTextboxText(textBox_domainNameOutput, systemInfo_ThisPC.domainName);
            SetTextboxText(textBox_ipv4AddressOutput, systemInfo_ThisPC.ipv4Address);
            SetTextboxText(textBox_subnetMaskOutput, systemInfo_ThisPC.subnetMask);
            SetTextboxText(textBox_lanMacAddressOutput, systemInfo_ThisPC.lanMacAddress);
            SetTextboxText(textBox_wlanMacAddressOutput, systemInfo_ThisPC.wlanMacAddress);
            SetTextboxText(textBox_logonServerOutput, systemInfo_ThisPC.logonServer);

            SetTextboxText_IsInstalled(systemService_Crowdstrike.IsInstalled(), systemService_Crowdstrike.IsRunning(), textBox_crowdstrikeOutput);
            SetTextboxText_IsInstalled(systemService_Dameware.IsInstalled(), textBox_damewareOutput);
            SetTextboxText_IsInstalled(systemService_Teamviewer.IsInstalled(), systemService_Teamviewer.IsRunning(), textBox_teamviewerOutput);
            SetTextboxText_IsInstalled(systemService_Zscaler.IsInstalled(), systemService_Zscaler.IsRunning(), textBox_zscalerOutput);
            SetTextboxText_IsInstalled(systemService_Mimecast.IsInstalled(), textBox_mimecastOutput);
            SetTextboxText_IsInstalled(systemService_SnowInventoryAgent.IsInstalled(), systemService_SnowInventoryAgent.IsRunning(), textBox_snowInventoryAgentOutput);
            SetTextboxText_IsInstalled(systemService_MsOffice365.IsInstalled(), textBox_msOffice365Output);
            SetTextboxText_IsInstalled(systemService_MsTeams.IsInstalled(), textBox_msTeamsOutput);
            SetTextboxText_IsInstalled(systemService_ArcticWolf.IsInstalled(), systemService_ArcticWolf.IsRunning(), textBox_arcticWolfOutput);

            SetTextboxText(textBox_osOutput, systemInfo_ThisPC.os);
            SetTextboxText(textBox_osPlatformOutput, systemInfo_ThisPC.osPlatform);
            SetTextboxText(textBox_winVerOutput, systemInfo_ThisPC.winVer);

            SetTextboxText(textBox_manufactureOutput, systemInfo_ThisPC.manufacturer);
            SetTextboxText(textBox_modelOutput, systemInfo_ThisPC.model);
            SetTextboxText(textBox_uptimeOutput, systemInfo_ThisPC.uptime);
            SetTextboxText(textBox_buildDateOutput, systemInfo_ThisPC.buildDate);

            systemInfo_ThisPC.Init();
            systemService_Crowdstrike.Init();
            systemService_Dameware.Init();
            systemService_Teamviewer.Init();
            systemService_Zscaler.Init();
            systemService_Mimecast.Init();
            systemService_SnowInventoryAgent.Init();
            systemService_MsOffice365.Init();
            systemService_MsTeams.Init();
            systemService_ArcticWolf.Init();

            SetTextboxText(textBox_progStatusOutput, "Ready", Color.Green);
        }
        private void SetTextboxText(TextBox p_textbox, string p_text)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = Color.Black;
            p_textbox.BackColor = p_textbox.BackColor;
        }
        private void SetTextboxText(TextBox p_textbox, string p_text, Color p_color)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = p_color;

            //ForeColor update only takes effect w/BackColor update
            p_textbox.BackColor = p_textbox.BackColor;
        }
        private void SetTextboxText_IsInstalled(bool p_isInstalled, TextBox p_textbox)
        {
            if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected; No Auxiliary Service!", Color.Green);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }
        private void SetTextboxText_IsInstalled(bool p_isInstalled, bool p_isProcessRunning, TextBox p_textbox)
        {
            if (p_isInstalled && p_isProcessRunning)
                SetTextboxText(p_textbox, "Detected; Service Running!", Color.Green);
            else if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected; Service Not Running!", Color.DarkOrange);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }

        #region WinForm_Butttons
        private void Button_RefreshGeneralInformation_Click(object sender, EventArgs e)
        {
            MainForm_Init();
        }
        private async void Button_LaunchTeamviewer_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            UIControllers.UIController_ProgressBar progressBarController = new UIControllers.UIController_ProgressBar(progressBar_progProgress, label_progProgressPct, label_progProgressStatusOut);

            if (await tool_TeamViewer.LaunchTool(progressBarController))
                SetTextboxText(textBox_progStatusOutput, "TeamViewer Launch Success;\r\nReady", Color.Green);
            else
                SetTextboxText(textBox_progStatusOutput, "TeamViewer Launch Fail, Verify Install;\r\nReady", Color.DarkOrange);

            await progressBarController.Reset();
            this.Enabled = true;
        }
        private async void Button_LaunchMapDrives_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            UIControllers.UIController_ProgressBar progressBarController = new UIControllers.UIController_ProgressBar(progressBar_progProgress, label_progProgressPct, label_progProgressStatusOut);

            if (await tool_MapDrives.LaunchTool(progressBarController, checkBox_shellExecVisibility.Checked))
                SetTextboxText(textBox_progStatusOutput, "Map Drives Success;\r\nReady", Color.Green);
            else
                SetTextboxText(textBox_progStatusOutput, "Map Drives Fail, Verify Network;\r\nReady", Color.DarkOrange);

            await progressBarController.Reset();
            this.Enabled = true;
        }
        private async void Button_LaunchSnowScan_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            UIControllers.UIController_ProgressBar progressBarController = new UIControllers.UIController_ProgressBar(progressBar_progProgress, label_progProgressPct, label_progProgressStatusOut);

            if (await tool_SnowScan.LaunchTool(progressBarController, checkBox_shellExecVisibility.Checked))
                SetTextboxText(textBox_progStatusOutput, "Snow Agent Scan Success;\r\nReady", Color.Green);
            else
                SetTextboxText(textBox_progStatusOutput, "Snow Agent Scan Fail, Verify Install & UAC;\r\nReady", Color.DarkOrange);

            await progressBarController.Reset();
            this.Enabled = true;
        }
        private void Button_LaunchWindchill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "http://windchill.triumphdesigns.com/Windchill/app/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Windchill Loaded;\r\nReady", Color.Green);
        }
        private void Button_LaunchTriumphOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://triumphonline.net/TriumphOnline/login.aspx", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Triumph Online Loaded;\r\nReady", Color.Green);
        }
        private void Button_LaunchWakeOnLAN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "http://wol/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Wake On LAN Loaded;\r\nReady", Color.Green);

        }
        #endregion

        #region WinForm_LinkLabels
        private void LinkLabel_ITSEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "mailto:itservicedesk@triumph.co.uk", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Email w/ ITS Address Loaded;\r\nReady", Color.Green);
        }
        private void LinkLabel_SysAid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://triumphmotorcycles.sysaidit.com/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "SysAid Loaded;\r\nReady", Color.Green);
        }
        private void LinkLabel_ReportABug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://forms.office.com/e/TRQkzVyVab", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Report a Bug Loaded;\r\nReady", Color.Green);
        }
        #endregion
    }
}