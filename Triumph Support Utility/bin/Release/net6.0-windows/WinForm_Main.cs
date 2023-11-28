namespace Triumph_Support_Utility
{
    public partial class WinForm_Main : Form
    {
        //Set textbox value
        private void SetTextboxText(TextBox p_textbox, string p_text)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = Color.Black;
            p_textbox.BackColor = p_textbox.BackColor;
        }
        //Set textbox value w/ Colour
        private void SetTextboxText(TextBox p_textbox, string p_text, Color p_color)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = p_color;

            //ForeColor update only takes effect w/BackColor update
            p_textbox.BackColor = p_textbox.BackColor;
        }
        //Set textbox value w/ Colour _isInstalled
        private void SetTextboxText_isInstalled(bool p_isInstalled, TextBox p_textbox)
        {
            if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected!", Color.Green);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }
        private void SetTextboxText_isInstalled(bool p_isInstalled, bool p_isProcessRunning, TextBox p_textbox)
        {
            if (p_isInstalled && p_isProcessRunning)
                SetTextboxText(p_textbox, "Detected; Service Running!", Color.Green);
            else if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected; Service Not Running!", Color.DarkOrange);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }

        public WinForm_Main()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            init_mainForm();
        }
        private void init_mainForm()
        {
            //Set initial program status
            SetTextboxText(textBox_progStatusOutput, "Loading Information. . .", Color.DarkOrange);

            //Display Network Details
            //WinForm_ProgressBar init_mainForm_isLoading = new WinForm_ProgressBar(this, null, "Loading Triumph Support Utility", "Loading Network Details", 0);
            SetTextboxText(textBox_usernameOutput, GeneralInformation.GetUsername());
            SetTextboxText(textBox_hostnameOutput, GeneralInformation.GetHostname());
            SetTextboxText(textBox_domainNameOutput, GeneralInformation.GetDomainName());
            SetTextboxText(textBox_ipv4AddressOutput, GeneralInformation.GetIpv4Address());
            SetTextboxText(textBox_subnetMaskOutput, GeneralInformation.GetSubnetMask());
            SetTextboxText(textBox_lanMacAddressOutput, GeneralInformation.GetLanMacAddress());
            SetTextboxText(textBox_wlanMacAddressOutput, GeneralInformation.GetWlanMacAddress());
            SetTextboxText(textBox_logonServerOutput, GeneralInformation.GetLogonServer());

            //Display Service Details
            //init_mainForm_isLoading.SetProcessAction_ProcessProgress("Loading Service Details", 33);
            SetTextboxText_isInstalled(GeneralInformation.crowdstrikeService.isInstalled(), GeneralInformation.crowdstrikeService.isProcessRunning(), textBox_crowdstrikeOutput);
            SetTextboxText_isInstalled(GeneralInformation.damewareService.isInstalled(), textBox_damewareOutput);
            SetTextboxText_isInstalled(GeneralInformation.teamviewerService.isInstalled(), textBox_teamviewerOutput);
            SetTextboxText_isInstalled(GeneralInformation.zscalerService.isInstalled(), GeneralInformation.zscalerService.isProcessRunning(), textBox_zscalerOutput);
            SetTextboxText_isInstalled(GeneralInformation.mimecastService.isInstalled(), textBox_mimecastOutput);
            SetTextboxText_isInstalled(GeneralInformation.snowInventoryAgentService.isInstalled(), GeneralInformation.snowInventoryAgentService.isProcessRunning(), textBox_snowInventoryAgentOutput);
            SetTextboxText_isInstalled(GeneralInformation.msOffice365Service.isInstalled(), textBox_msOffice365Output);
            SetTextboxText_isInstalled(GeneralInformation.msTeamsService.isInstalled(), textBox_msTeamsOutput);
            SetTextboxText_isInstalled(GeneralInformation.arcticWolfService.isInstalled(),GeneralInformation.arcticWolfService.isProcessRunning(), textBox_arcticWolfOutput);

            //Display Operating System Details
            //init_mainForm_isLoading.SetProcessAction_ProcessProgress("Loading Operating System Details", 66);
            SetTextboxText(textBox_osOutput, GeneralInformation.GetOS());
            SetTextboxText(textBox_osPlatformOutput, GeneralInformation.GetOSPlatform());
            SetTextboxText(textBox_winVerOutput, GeneralInformation.GetWinVer());

            //Display System Details
            //init_mainForm_isLoading.SetProcessAction_ProcessProgress("Loading System Details", 100);
            SetTextboxText(textBox_manufactureOutput, GeneralInformation.GetManufacture());
            SetTextboxText(textBox_modelOutput, GeneralInformation.GetModel());

            //Set initial program status
            SetTextboxText(textBox_progStatusOutput, "Ready", Color.Green);
        }

        private void button_refreshGeneralInformation_Click(object sender, EventArgs e)
        {
            init_mainForm();
        }

        private void button_launchTeamviewer_Click(object sender, EventArgs e)
        {
            if (Tools.LaunchTeamViewer(this))
                SetTextboxText(textBox_progStatusOutput, "TeamViewer Launch Success;\r\nReady", Color.Green);
            else
                SetTextboxText(textBox_progStatusOutput, "TeamViewer Launch Fail, Verify Install;\r\nReady", Color.DarkOrange);
        }
        private void button_launchMapDrives_Click(object sender, EventArgs e)
        {
            if (Tools.LaunchMapDrives())
                SetTextboxText(textBox_progStatusOutput, "Map Drives Success;\r\nReady", Color.Green);
            else
                SetTextboxText(textBox_progStatusOutput, "Map Drives Fail, Verify Network;\r\nReady", Color.DarkOrange);
        }

        private void linkLabel_emailVal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "mailto:itservicedesk@triumph.co.uk", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Email w/ ITS Address Loaded;\r\nReady", Color.Green);
        }
        private void linkLabel_sysaid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://triumphmotorcycles.sysaidit.com/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "SysAid Loaded;\r\nReady", Color.Green);
        }
        private void linkLabel_reportABug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://forms.office.com/e/TRQkzVyVab", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Report a Bug Loaded;\r\nReady", Color.Green);
        }

        private void button_windchill_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "http://windchill.triumphdesigns.com/Windchill/app/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Windchill Loaded;\r\nReady", Color.Green);
        }
        private void button_triumphOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://triumphonline.net/TriumphOnline/login.aspx", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Triumph Online Loaded;\r\nReady", Color.Green);
        }
        private void button_wakeOnLAN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "http://wol/", UseShellExecute = true });
            SetTextboxText(textBox_progStatusOutput, "Wake On LAN Loaded;\r\nReady", Color.Green);

        }
    }
}