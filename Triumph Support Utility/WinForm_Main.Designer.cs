namespace Triumph_Support_Utility
{
    partial class WinForm_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_Main));
            pictureBox_progLogo = new PictureBox();
            label_progTitle = new Label();
            groupBox_generalInfo = new GroupBox();
            textBox_buildDateOutput = new TextBox();
            textBox_uptimeOutput = new TextBox();
            label_buildDate = new Label();
            label_os = new Label();
            label_winVer = new Label();
            label_osPlatform = new Label();
            textBox_arcticWolfOutput = new TextBox();
            label_arcticWolf = new Label();
            Button_RefreshGeneralInformation = new Button();
            textBox_mimecastOutput = new TextBox();
            label_mimecast = new Label();
            label_subnetMask = new Label();
            textBox_osOutput = new TextBox();
            textBox_modelOutput = new TextBox();
            label_model = new Label();
            textBox_manufactureOutput = new TextBox();
            label_manufacture = new Label();
            label_systemDetailsHeader = new Label();
            label_uptime = new Label();
            textBox_osPlatformOutput = new TextBox();
            textBox_msTeamsOutput = new TextBox();
            label_msTeams = new Label();
            textBox_msOffice365Output = new TextBox();
            label_msOffice365 = new Label();
            label_serviceDetailsHeader = new Label();
            textBox_snowInventoryAgentOutput = new TextBox();
            label_snowInventoryAgent = new Label();
            textBox_zscalerOutput = new TextBox();
            label_zscaler = new Label();
            textBox_teamviewerOutput = new TextBox();
            label_teamviewer = new Label();
            textBox_damewareOutput = new TextBox();
            label_dameware = new Label();
            textBox_crowdstrikeOutput = new TextBox();
            label_crowdstrike = new Label();
            label_networkDetailsHeader = new Label();
            textBox_logonServerOutput = new TextBox();
            label_logonServer = new Label();
            textBox_wlanMacAddressOutput = new TextBox();
            label_wlanMacAddress = new Label();
            textBox_usernameOutput = new TextBox();
            label_username = new Label();
            textBox_lanMacAddressOutput = new TextBox();
            label_lanMacAddress = new Label();
            textBox_subnetMaskOutput = new TextBox();
            textBox_ipv4AddressOutput = new TextBox();
            label_ipAddress = new Label();
            textBox_domainNameOutput = new TextBox();
            label_domainName = new Label();
            textBox_hostnameOutput = new TextBox();
            label_hostname = new Label();
            label8 = new Label();
            textBox_winVerOutput = new TextBox();
            label_progSubTitle = new Label();
            groupBox_About = new GroupBox();
            LinkLabel_SysAid = new LinkLabel();
            LinkLabel_ITSEmail = new LinkLabel();
            label_telNo_val = new Label();
            label_email = new Label();
            label_telNo = new Label();
            label_dev = new Label();
            LinkLabel_ReportABug = new LinkLabel();
            label_progStatus = new Label();
            textBox_progStatusOutput = new TextBox();
            label_progVer = new Label();
            tabControl_Functions = new TabControl();
            tabPage_userTools = new TabPage();
            Button_LaunchTeamviewer = new Button();
            Button_LaunchMapDrives = new Button();
            tabPage_adminTools = new TabPage();
            Button_LaunchSnowScan = new Button();
            tabPage_resources = new TabPage();
            Button_WakeOnLAN = new Button();
            Button_LaunchTriumphOnline = new Button();
            Button_LaunchWindchill = new Button();
            checkBox_shellExecVisibility = new CheckBox();
            progressBar_progProgress = new ProgressBar();
            label_progProgressPct = new Label();
            label_progPogress = new Label();
            label_progProgressStatus = new Label();
            label_progProgressStatusOut = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_progLogo).BeginInit();
            groupBox_generalInfo.SuspendLayout();
            groupBox_About.SuspendLayout();
            tabControl_Functions.SuspendLayout();
            tabPage_userTools.SuspendLayout();
            tabPage_adminTools.SuspendLayout();
            tabPage_resources.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_progLogo
            // 
            pictureBox_progLogo.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_progLogo.Image = Properties.Resources.triumphLogo;
            pictureBox_progLogo.Location = new Point(12, 12);
            pictureBox_progLogo.Name = "pictureBox_progLogo";
            pictureBox_progLogo.Size = new Size(75, 75);
            pictureBox_progLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_progLogo.TabIndex = 0;
            pictureBox_progLogo.TabStop = false;
            // 
            // label_progTitle
            // 
            label_progTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_progTitle.Location = new Point(93, 12);
            label_progTitle.Name = "label_progTitle";
            label_progTitle.Size = new Size(381, 37);
            label_progTitle.TabIndex = 1;
            label_progTitle.Text = "TRIUMPH SUPPORT UTILITY";
            // 
            // groupBox_generalInfo
            // 
            groupBox_generalInfo.BackColor = SystemColors.Control;
            groupBox_generalInfo.BackgroundImage = Properties.Resources.backgroundImage;
            groupBox_generalInfo.BackgroundImageLayout = ImageLayout.Center;
            groupBox_generalInfo.Controls.Add(textBox_buildDateOutput);
            groupBox_generalInfo.Controls.Add(textBox_uptimeOutput);
            groupBox_generalInfo.Controls.Add(label_buildDate);
            groupBox_generalInfo.Controls.Add(label_os);
            groupBox_generalInfo.Controls.Add(label_winVer);
            groupBox_generalInfo.Controls.Add(label_osPlatform);
            groupBox_generalInfo.Controls.Add(textBox_arcticWolfOutput);
            groupBox_generalInfo.Controls.Add(label_arcticWolf);
            groupBox_generalInfo.Controls.Add(Button_RefreshGeneralInformation);
            groupBox_generalInfo.Controls.Add(textBox_mimecastOutput);
            groupBox_generalInfo.Controls.Add(label_mimecast);
            groupBox_generalInfo.Controls.Add(label_subnetMask);
            groupBox_generalInfo.Controls.Add(textBox_osOutput);
            groupBox_generalInfo.Controls.Add(textBox_modelOutput);
            groupBox_generalInfo.Controls.Add(label_model);
            groupBox_generalInfo.Controls.Add(textBox_manufactureOutput);
            groupBox_generalInfo.Controls.Add(label_manufacture);
            groupBox_generalInfo.Controls.Add(label_systemDetailsHeader);
            groupBox_generalInfo.Controls.Add(label_uptime);
            groupBox_generalInfo.Controls.Add(textBox_osPlatformOutput);
            groupBox_generalInfo.Controls.Add(textBox_msTeamsOutput);
            groupBox_generalInfo.Controls.Add(label_msTeams);
            groupBox_generalInfo.Controls.Add(textBox_msOffice365Output);
            groupBox_generalInfo.Controls.Add(label_msOffice365);
            groupBox_generalInfo.Controls.Add(label_serviceDetailsHeader);
            groupBox_generalInfo.Controls.Add(textBox_snowInventoryAgentOutput);
            groupBox_generalInfo.Controls.Add(label_snowInventoryAgent);
            groupBox_generalInfo.Controls.Add(textBox_zscalerOutput);
            groupBox_generalInfo.Controls.Add(label_zscaler);
            groupBox_generalInfo.Controls.Add(textBox_teamviewerOutput);
            groupBox_generalInfo.Controls.Add(label_teamviewer);
            groupBox_generalInfo.Controls.Add(textBox_damewareOutput);
            groupBox_generalInfo.Controls.Add(label_dameware);
            groupBox_generalInfo.Controls.Add(textBox_crowdstrikeOutput);
            groupBox_generalInfo.Controls.Add(label_crowdstrike);
            groupBox_generalInfo.Controls.Add(label_networkDetailsHeader);
            groupBox_generalInfo.Controls.Add(textBox_logonServerOutput);
            groupBox_generalInfo.Controls.Add(label_logonServer);
            groupBox_generalInfo.Controls.Add(textBox_wlanMacAddressOutput);
            groupBox_generalInfo.Controls.Add(label_wlanMacAddress);
            groupBox_generalInfo.Controls.Add(textBox_usernameOutput);
            groupBox_generalInfo.Controls.Add(label_username);
            groupBox_generalInfo.Controls.Add(textBox_lanMacAddressOutput);
            groupBox_generalInfo.Controls.Add(label_lanMacAddress);
            groupBox_generalInfo.Controls.Add(textBox_subnetMaskOutput);
            groupBox_generalInfo.Controls.Add(textBox_ipv4AddressOutput);
            groupBox_generalInfo.Controls.Add(label_ipAddress);
            groupBox_generalInfo.Controls.Add(textBox_domainNameOutput);
            groupBox_generalInfo.Controls.Add(label_domainName);
            groupBox_generalInfo.Controls.Add(textBox_hostnameOutput);
            groupBox_generalInfo.Controls.Add(label_hostname);
            groupBox_generalInfo.Controls.Add(label8);
            groupBox_generalInfo.Controls.Add(textBox_winVerOutput);
            groupBox_generalInfo.Location = new Point(12, 93);
            groupBox_generalInfo.MinimumSize = new Size(677, 551);
            groupBox_generalInfo.Name = "groupBox_generalInfo";
            groupBox_generalInfo.Size = new Size(677, 551);
            groupBox_generalInfo.TabIndex = 2;
            groupBox_generalInfo.TabStop = false;
            groupBox_generalInfo.Text = "General Information";
            // 
            // textBox_buildDateOutput
            // 
            textBox_buildDateOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_buildDateOutput.Location = new Point(140, 403);
            textBox_buildDateOutput.Name = "textBox_buildDateOutput";
            textBox_buildDateOutput.ReadOnly = true;
            textBox_buildDateOutput.Size = new Size(175, 23);
            textBox_buildDateOutput.TabIndex = 103;
            // 
            // textBox_uptimeOutput
            // 
            textBox_uptimeOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_uptimeOutput.Location = new Point(140, 374);
            textBox_uptimeOutput.Name = "textBox_uptimeOutput";
            textBox_uptimeOutput.ReadOnly = true;
            textBox_uptimeOutput.Size = new Size(175, 23);
            textBox_uptimeOutput.TabIndex = 102;
            // 
            // label_buildDate
            // 
            label_buildDate.AutoSize = true;
            label_buildDate.BackColor = Color.Transparent;
            label_buildDate.ImageAlign = ContentAlignment.TopLeft;
            label_buildDate.Location = new Point(3, 405);
            label_buildDate.Margin = new Padding(0, 10, 0, 0);
            label_buildDate.Name = "label_buildDate";
            label_buildDate.Size = new Size(64, 15);
            label_buildDate.TabIndex = 92;
            label_buildDate.Text = "Build Date:";
            label_buildDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_os
            // 
            label_os.AutoSize = true;
            label_os.BackColor = Color.Transparent;
            label_os.ImageAlign = ContentAlignment.TopLeft;
            label_os.Location = new Point(3, 463);
            label_os.Margin = new Padding(0, 10, 0, 0);
            label_os.Name = "label_os";
            label_os.Size = new Size(25, 15);
            label_os.TabIndex = 89;
            label_os.Text = "OS:";
            label_os.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_winVer
            // 
            label_winVer.AutoSize = true;
            label_winVer.BackColor = Color.Transparent;
            label_winVer.ImageAlign = ContentAlignment.TopLeft;
            label_winVer.Location = new Point(3, 521);
            label_winVer.Margin = new Padding(0, 10, 0, 0);
            label_winVer.Name = "label_winVer";
            label_winVer.Size = new Size(100, 15);
            label_winVer.TabIndex = 87;
            label_winVer.Text = "Windows Version:";
            label_winVer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_osPlatform
            // 
            label_osPlatform.AutoSize = true;
            label_osPlatform.BackColor = Color.Transparent;
            label_osPlatform.ImageAlign = ContentAlignment.TopLeft;
            label_osPlatform.Location = new Point(3, 492);
            label_osPlatform.Margin = new Padding(0, 10, 0, 0);
            label_osPlatform.Name = "label_osPlatform";
            label_osPlatform.Size = new Size(74, 15);
            label_osPlatform.TabIndex = 85;
            label_osPlatform.Text = "OS Platform:";
            label_osPlatform.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_arcticWolfOutput
            // 
            textBox_arcticWolfOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_arcticWolfOutput.Location = new Point(494, 290);
            textBox_arcticWolfOutput.Name = "textBox_arcticWolfOutput";
            textBox_arcticWolfOutput.ReadOnly = true;
            textBox_arcticWolfOutput.Size = new Size(175, 23);
            textBox_arcticWolfOutput.TabIndex = 84;
            // 
            // label_arcticWolf
            // 
            label_arcticWolf.AutoSize = true;
            label_arcticWolf.BackColor = Color.Transparent;
            label_arcticWolf.ImageAlign = ContentAlignment.TopLeft;
            label_arcticWolf.Location = new Point(357, 293);
            label_arcticWolf.Margin = new Padding(0, 10, 0, 0);
            label_arcticWolf.Name = "label_arcticWolf";
            label_arcticWolf.Size = new Size(69, 15);
            label_arcticWolf.TabIndex = 83;
            label_arcticWolf.Text = "Arctic Wolf:";
            label_arcticWolf.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Button_RefreshGeneralInformation
            // 
            Button_RefreshGeneralInformation.Location = new Point(596, 0);
            Button_RefreshGeneralInformation.Name = "Button_RefreshGeneralInformation";
            Button_RefreshGeneralInformation.Size = new Size(75, 23);
            Button_RefreshGeneralInformation.TabIndex = 82;
            Button_RefreshGeneralInformation.Text = "Refresh";
            Button_RefreshGeneralInformation.UseVisualStyleBackColor = true;
            Button_RefreshGeneralInformation.Click += Button_RefreshGeneralInformation_Click;
            // 
            // textBox_mimecastOutput
            // 
            textBox_mimecastOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_mimecastOutput.Location = new Point(494, 171);
            textBox_mimecastOutput.Name = "textBox_mimecastOutput";
            textBox_mimecastOutput.ReadOnly = true;
            textBox_mimecastOutput.Size = new Size(175, 23);
            textBox_mimecastOutput.TabIndex = 78;
            // 
            // label_mimecast
            // 
            label_mimecast.AutoSize = true;
            label_mimecast.BackColor = Color.Transparent;
            label_mimecast.ImageAlign = ContentAlignment.TopLeft;
            label_mimecast.Location = new Point(357, 174);
            label_mimecast.Margin = new Padding(0, 10, 0, 0);
            label_mimecast.Name = "label_mimecast";
            label_mimecast.Size = new Size(62, 15);
            label_mimecast.TabIndex = 77;
            label_mimecast.Text = "Mimecast:";
            label_mimecast.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_subnetMask
            // 
            label_subnetMask.AutoSize = true;
            label_subnetMask.BackColor = Color.Transparent;
            label_subnetMask.Location = new Point(3, 173);
            label_subnetMask.Name = "label_subnetMask";
            label_subnetMask.Size = new Size(78, 15);
            label_subnetMask.TabIndex = 76;
            label_subnetMask.Text = "Subnet Mask:";
            // 
            // textBox_osOutput
            // 
            textBox_osOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_osOutput.Location = new Point(140, 461);
            textBox_osOutput.Name = "textBox_osOutput";
            textBox_osOutput.ReadOnly = true;
            textBox_osOutput.Size = new Size(175, 23);
            textBox_osOutput.TabIndex = 70;
            // 
            // textBox_modelOutput
            // 
            textBox_modelOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_modelOutput.Location = new Point(140, 345);
            textBox_modelOutput.Name = "textBox_modelOutput";
            textBox_modelOutput.ReadOnly = true;
            textBox_modelOutput.Size = new Size(175, 23);
            textBox_modelOutput.TabIndex = 68;
            // 
            // label_model
            // 
            label_model.AutoSize = true;
            label_model.BackColor = Color.Transparent;
            label_model.ImageAlign = ContentAlignment.TopLeft;
            label_model.Location = new Point(3, 347);
            label_model.Margin = new Padding(0, 10, 0, 0);
            label_model.Name = "label_model";
            label_model.Size = new Size(44, 15);
            label_model.TabIndex = 67;
            label_model.Text = "Model:";
            label_model.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_manufactureOutput
            // 
            textBox_manufactureOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_manufactureOutput.Location = new Point(140, 316);
            textBox_manufactureOutput.Name = "textBox_manufactureOutput";
            textBox_manufactureOutput.ReadOnly = true;
            textBox_manufactureOutput.Size = new Size(175, 23);
            textBox_manufactureOutput.TabIndex = 66;
            // 
            // label_manufacture
            // 
            label_manufacture.AutoSize = true;
            label_manufacture.BackColor = Color.Transparent;
            label_manufacture.ImageAlign = ContentAlignment.TopLeft;
            label_manufacture.Location = new Point(3, 318);
            label_manufacture.Margin = new Padding(0, 10, 0, 0);
            label_manufacture.Name = "label_manufacture";
            label_manufacture.Size = new Size(78, 15);
            label_manufacture.TabIndex = 65;
            label_manufacture.Text = "Manufacture:";
            label_manufacture.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_systemDetailsHeader
            // 
            label_systemDetailsHeader.AutoSize = true;
            label_systemDetailsHeader.BackColor = Color.Transparent;
            label_systemDetailsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_systemDetailsHeader.ImageAlign = ContentAlignment.TopLeft;
            label_systemDetailsHeader.Location = new Point(3, 289);
            label_systemDetailsHeader.Margin = new Padding(0, 10, 0, 0);
            label_systemDetailsHeader.Name = "label_systemDetailsHeader";
            label_systemDetailsHeader.Size = new Size(101, 15);
            label_systemDetailsHeader.TabIndex = 63;
            label_systemDetailsHeader.Text = "SYSTEM DETAILS";
            label_systemDetailsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_uptime
            // 
            label_uptime.AutoSize = true;
            label_uptime.BackColor = Color.Transparent;
            label_uptime.ImageAlign = ContentAlignment.TopLeft;
            label_uptime.Location = new Point(3, 376);
            label_uptime.Margin = new Padding(0, 10, 0, 0);
            label_uptime.Name = "label_uptime";
            label_uptime.Size = new Size(49, 15);
            label_uptime.TabIndex = 61;
            label_uptime.Text = "Uptime:";
            label_uptime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_osPlatformOutput
            // 
            textBox_osPlatformOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_osPlatformOutput.Location = new Point(140, 490);
            textBox_osPlatformOutput.Name = "textBox_osPlatformOutput";
            textBox_osPlatformOutput.ReadOnly = true;
            textBox_osPlatformOutput.Size = new Size(175, 23);
            textBox_osPlatformOutput.TabIndex = 60;
            // 
            // textBox_msTeamsOutput
            // 
            textBox_msTeamsOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_msTeamsOutput.Location = new Point(494, 258);
            textBox_msTeamsOutput.Name = "textBox_msTeamsOutput";
            textBox_msTeamsOutput.ReadOnly = true;
            textBox_msTeamsOutput.Size = new Size(175, 23);
            textBox_msTeamsOutput.TabIndex = 58;
            // 
            // label_msTeams
            // 
            label_msTeams.AutoSize = true;
            label_msTeams.BackColor = Color.Transparent;
            label_msTeams.ImageAlign = ContentAlignment.TopLeft;
            label_msTeams.Location = new Point(357, 261);
            label_msTeams.Margin = new Padding(0, 10, 0, 0);
            label_msTeams.Name = "label_msTeams";
            label_msTeams.Size = new Size(97, 15);
            label_msTeams.TabIndex = 57;
            label_msTeams.Text = "Microsoft Teams:";
            label_msTeams.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_msOffice365Output
            // 
            textBox_msOffice365Output.BorderStyle = BorderStyle.FixedSingle;
            textBox_msOffice365Output.Location = new Point(494, 229);
            textBox_msOffice365Output.Name = "textBox_msOffice365Output";
            textBox_msOffice365Output.ReadOnly = true;
            textBox_msOffice365Output.Size = new Size(175, 23);
            textBox_msOffice365Output.TabIndex = 56;
            // 
            // label_msOffice365
            // 
            label_msOffice365.AutoSize = true;
            label_msOffice365.BackColor = Color.Transparent;
            label_msOffice365.ImageAlign = ContentAlignment.TopLeft;
            label_msOffice365.Location = new Point(357, 232);
            label_msOffice365.Margin = new Padding(0, 10, 0, 0);
            label_msOffice365.Name = "label_msOffice365";
            label_msOffice365.Size = new Size(117, 15);
            label_msOffice365.TabIndex = 55;
            label_msOffice365.Text = "Microsoft Office 365:";
            label_msOffice365.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_serviceDetailsHeader
            // 
            label_serviceDetailsHeader.AutoSize = true;
            label_serviceDetailsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_serviceDetailsHeader.ImageAlign = ContentAlignment.TopLeft;
            label_serviceDetailsHeader.Location = new Point(357, 29);
            label_serviceDetailsHeader.Margin = new Padding(0, 10, 0, 0);
            label_serviceDetailsHeader.Name = "label_serviceDetailsHeader";
            label_serviceDetailsHeader.Size = new Size(102, 15);
            label_serviceDetailsHeader.TabIndex = 53;
            label_serviceDetailsHeader.Text = "SERVICE DETAILS";
            label_serviceDetailsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_snowInventoryAgentOutput
            // 
            textBox_snowInventoryAgentOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_snowInventoryAgentOutput.Location = new Point(494, 200);
            textBox_snowInventoryAgentOutput.Name = "textBox_snowInventoryAgentOutput";
            textBox_snowInventoryAgentOutput.ReadOnly = true;
            textBox_snowInventoryAgentOutput.Size = new Size(175, 23);
            textBox_snowInventoryAgentOutput.TabIndex = 52;
            // 
            // label_snowInventoryAgent
            // 
            label_snowInventoryAgent.AutoSize = true;
            label_snowInventoryAgent.BackColor = Color.Transparent;
            label_snowInventoryAgent.ImageAlign = ContentAlignment.TopLeft;
            label_snowInventoryAgent.Location = new Point(357, 203);
            label_snowInventoryAgent.Margin = new Padding(0, 10, 0, 0);
            label_snowInventoryAgent.Name = "label_snowInventoryAgent";
            label_snowInventoryAgent.Size = new Size(127, 15);
            label_snowInventoryAgent.TabIndex = 51;
            label_snowInventoryAgent.Text = "Snow Inventory Agent:";
            label_snowInventoryAgent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_zscalerOutput
            // 
            textBox_zscalerOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_zscalerOutput.Location = new Point(494, 142);
            textBox_zscalerOutput.Name = "textBox_zscalerOutput";
            textBox_zscalerOutput.ReadOnly = true;
            textBox_zscalerOutput.Size = new Size(175, 23);
            textBox_zscalerOutput.TabIndex = 50;
            // 
            // label_zscaler
            // 
            label_zscaler.AutoSize = true;
            label_zscaler.BackColor = Color.Transparent;
            label_zscaler.ImageAlign = ContentAlignment.TopLeft;
            label_zscaler.Location = new Point(357, 145);
            label_zscaler.Margin = new Padding(0, 10, 0, 0);
            label_zscaler.Name = "label_zscaler";
            label_zscaler.Size = new Size(48, 15);
            label_zscaler.TabIndex = 49;
            label_zscaler.Text = "ZScaler:";
            label_zscaler.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox_teamviewerOutput
            // 
            textBox_teamviewerOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_teamviewerOutput.Location = new Point(494, 113);
            textBox_teamviewerOutput.Name = "textBox_teamviewerOutput";
            textBox_teamviewerOutput.ReadOnly = true;
            textBox_teamviewerOutput.Size = new Size(175, 23);
            textBox_teamviewerOutput.TabIndex = 48;
            // 
            // label_teamviewer
            // 
            label_teamviewer.AutoSize = true;
            label_teamviewer.BackColor = Color.Transparent;
            label_teamviewer.ImageAlign = ContentAlignment.TopLeft;
            label_teamviewer.Location = new Point(357, 116);
            label_teamviewer.Margin = new Padding(0, 10, 0, 0);
            label_teamviewer.Name = "label_teamviewer";
            label_teamviewer.Size = new Size(72, 15);
            label_teamviewer.TabIndex = 47;
            label_teamviewer.Text = "Teamviewer:";
            label_teamviewer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_damewareOutput
            // 
            textBox_damewareOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_damewareOutput.Location = new Point(494, 84);
            textBox_damewareOutput.Name = "textBox_damewareOutput";
            textBox_damewareOutput.ReadOnly = true;
            textBox_damewareOutput.Size = new Size(175, 23);
            textBox_damewareOutput.TabIndex = 46;
            // 
            // label_dameware
            // 
            label_dameware.AutoSize = true;
            label_dameware.BackColor = Color.Transparent;
            label_dameware.ImageAlign = ContentAlignment.TopLeft;
            label_dameware.Location = new Point(357, 87);
            label_dameware.Margin = new Padding(0, 10, 0, 0);
            label_dameware.Name = "label_dameware";
            label_dameware.Size = new Size(66, 15);
            label_dameware.TabIndex = 45;
            label_dameware.Text = "Dameware:";
            label_dameware.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_crowdstrikeOutput
            // 
            textBox_crowdstrikeOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_crowdstrikeOutput.Location = new Point(494, 55);
            textBox_crowdstrikeOutput.Name = "textBox_crowdstrikeOutput";
            textBox_crowdstrikeOutput.ReadOnly = true;
            textBox_crowdstrikeOutput.Size = new Size(175, 23);
            textBox_crowdstrikeOutput.TabIndex = 44;
            // 
            // label_crowdstrike
            // 
            label_crowdstrike.AutoSize = true;
            label_crowdstrike.BackColor = Color.Transparent;
            label_crowdstrike.ImageAlign = ContentAlignment.TopLeft;
            label_crowdstrike.Location = new Point(357, 58);
            label_crowdstrike.Margin = new Padding(0, 10, 0, 0);
            label_crowdstrike.Name = "label_crowdstrike";
            label_crowdstrike.Size = new Size(73, 15);
            label_crowdstrike.TabIndex = 43;
            label_crowdstrike.Text = "Crowdstrike:";
            label_crowdstrike.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_networkDetailsHeader
            // 
            label_networkDetailsHeader.AutoSize = true;
            label_networkDetailsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_networkDetailsHeader.ImageAlign = ContentAlignment.TopLeft;
            label_networkDetailsHeader.Location = new Point(3, 29);
            label_networkDetailsHeader.Margin = new Padding(0, 10, 0, 0);
            label_networkDetailsHeader.Name = "label_networkDetailsHeader";
            label_networkDetailsHeader.Size = new Size(115, 15);
            label_networkDetailsHeader.TabIndex = 42;
            label_networkDetailsHeader.Text = "NETWORK DETAILS";
            label_networkDetailsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_logonServerOutput
            // 
            textBox_logonServerOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_logonServerOutput.Location = new Point(140, 257);
            textBox_logonServerOutput.Name = "textBox_logonServerOutput";
            textBox_logonServerOutput.ReadOnly = true;
            textBox_logonServerOutput.Size = new Size(175, 23);
            textBox_logonServerOutput.TabIndex = 40;
            // 
            // label_logonServer
            // 
            label_logonServer.AutoSize = true;
            label_logonServer.BackColor = Color.Transparent;
            label_logonServer.ImageAlign = ContentAlignment.TopLeft;
            label_logonServer.Location = new Point(3, 260);
            label_logonServer.Margin = new Padding(0, 10, 0, 0);
            label_logonServer.Name = "label_logonServer";
            label_logonServer.Size = new Size(79, 15);
            label_logonServer.TabIndex = 39;
            label_logonServer.Text = "Logon Server:";
            label_logonServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_wlanMacAddressOutput
            // 
            textBox_wlanMacAddressOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_wlanMacAddressOutput.Location = new Point(140, 228);
            textBox_wlanMacAddressOutput.Name = "textBox_wlanMacAddressOutput";
            textBox_wlanMacAddressOutput.ReadOnly = true;
            textBox_wlanMacAddressOutput.Size = new Size(175, 23);
            textBox_wlanMacAddressOutput.TabIndex = 38;
            // 
            // label_wlanMacAddress
            // 
            label_wlanMacAddress.AutoSize = true;
            label_wlanMacAddress.BackColor = Color.Transparent;
            label_wlanMacAddress.ImageAlign = ContentAlignment.TopLeft;
            label_wlanMacAddress.Location = new Point(3, 231);
            label_wlanMacAddress.Margin = new Padding(0, 10, 0, 0);
            label_wlanMacAddress.Name = "label_wlanMacAddress";
            label_wlanMacAddress.Size = new Size(119, 15);
            label_wlanMacAddress.TabIndex = 37;
            label_wlanMacAddress.Text = "WLAN MAC Address:";
            label_wlanMacAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_usernameOutput
            // 
            textBox_usernameOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_usernameOutput.Location = new Point(140, 54);
            textBox_usernameOutput.Name = "textBox_usernameOutput";
            textBox_usernameOutput.ReadOnly = true;
            textBox_usernameOutput.Size = new Size(175, 23);
            textBox_usernameOutput.TabIndex = 24;
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.BackColor = Color.Transparent;
            label_username.ImageAlign = ContentAlignment.TopLeft;
            label_username.Location = new Point(3, 57);
            label_username.Margin = new Padding(0, 10, 0, 0);
            label_username.Name = "label_username";
            label_username.Size = new Size(63, 15);
            label_username.TabIndex = 23;
            label_username.Text = "Username:";
            label_username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_lanMacAddressOutput
            // 
            textBox_lanMacAddressOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_lanMacAddressOutput.Location = new Point(140, 199);
            textBox_lanMacAddressOutput.Name = "textBox_lanMacAddressOutput";
            textBox_lanMacAddressOutput.ReadOnly = true;
            textBox_lanMacAddressOutput.Size = new Size(175, 23);
            textBox_lanMacAddressOutput.TabIndex = 10;
            // 
            // label_lanMacAddress
            // 
            label_lanMacAddress.AutoSize = true;
            label_lanMacAddress.BackColor = Color.Transparent;
            label_lanMacAddress.ImageAlign = ContentAlignment.TopLeft;
            label_lanMacAddress.Location = new Point(3, 202);
            label_lanMacAddress.Margin = new Padding(0, 10, 0, 0);
            label_lanMacAddress.Name = "label_lanMacAddress";
            label_lanMacAddress.Size = new Size(108, 15);
            label_lanMacAddress.TabIndex = 9;
            label_lanMacAddress.Text = "LAN MAC Address:";
            label_lanMacAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_subnetMaskOutput
            // 
            textBox_subnetMaskOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_subnetMaskOutput.Location = new Point(140, 170);
            textBox_subnetMaskOutput.Name = "textBox_subnetMaskOutput";
            textBox_subnetMaskOutput.ReadOnly = true;
            textBox_subnetMaskOutput.Size = new Size(175, 23);
            textBox_subnetMaskOutput.TabIndex = 8;
            // 
            // textBox_ipv4AddressOutput
            // 
            textBox_ipv4AddressOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_ipv4AddressOutput.Location = new Point(140, 141);
            textBox_ipv4AddressOutput.Name = "textBox_ipv4AddressOutput";
            textBox_ipv4AddressOutput.ReadOnly = true;
            textBox_ipv4AddressOutput.Size = new Size(175, 23);
            textBox_ipv4AddressOutput.TabIndex = 6;
            // 
            // label_ipAddress
            // 
            label_ipAddress.AutoSize = true;
            label_ipAddress.BackColor = Color.Transparent;
            label_ipAddress.ImageAlign = ContentAlignment.TopLeft;
            label_ipAddress.Location = new Point(3, 144);
            label_ipAddress.Margin = new Padding(0, 10, 0, 0);
            label_ipAddress.Name = "label_ipAddress";
            label_ipAddress.Size = new Size(65, 15);
            label_ipAddress.TabIndex = 5;
            label_ipAddress.Text = "IP Address:";
            label_ipAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_domainNameOutput
            // 
            textBox_domainNameOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_domainNameOutput.Location = new Point(140, 112);
            textBox_domainNameOutput.Name = "textBox_domainNameOutput";
            textBox_domainNameOutput.ReadOnly = true;
            textBox_domainNameOutput.Size = new Size(175, 23);
            textBox_domainNameOutput.TabIndex = 4;
            // 
            // label_domainName
            // 
            label_domainName.AutoSize = true;
            label_domainName.BackColor = Color.Transparent;
            label_domainName.ImageAlign = ContentAlignment.TopLeft;
            label_domainName.Location = new Point(3, 115);
            label_domainName.Margin = new Padding(0, 10, 0, 0);
            label_domainName.Name = "label_domainName";
            label_domainName.Size = new Size(87, 15);
            label_domainName.TabIndex = 3;
            label_domainName.Text = "Domain Name:";
            label_domainName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_hostnameOutput
            // 
            textBox_hostnameOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_hostnameOutput.Location = new Point(140, 83);
            textBox_hostnameOutput.Name = "textBox_hostnameOutput";
            textBox_hostnameOutput.ReadOnly = true;
            textBox_hostnameOutput.Size = new Size(175, 23);
            textBox_hostnameOutput.TabIndex = 2;
            // 
            // label_hostname
            // 
            label_hostname.AutoSize = true;
            label_hostname.BackColor = Color.Transparent;
            label_hostname.ImageAlign = ContentAlignment.TopLeft;
            label_hostname.Location = new Point(3, 86);
            label_hostname.Margin = new Padding(0, 10, 0, 0);
            label_hostname.Name = "label_hostname";
            label_hostname.Size = new Size(65, 15);
            label_hostname.TabIndex = 0;
            label_hostname.Text = "Hostname:";
            label_hostname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ImageAlign = ContentAlignment.TopLeft;
            label8.Location = new Point(3, 434);
            label8.Margin = new Padding(0, 10, 0, 0);
            label8.Name = "label8";
            label8.Size = new Size(170, 15);
            label8.TabIndex = 99;
            label8.Text = "OPERATING SYSTEM DETAILS";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox_winVerOutput
            // 
            textBox_winVerOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_winVerOutput.Location = new Point(140, 519);
            textBox_winVerOutput.Name = "textBox_winVerOutput";
            textBox_winVerOutput.ReadOnly = true;
            textBox_winVerOutput.Size = new Size(175, 23);
            textBox_winVerOutput.TabIndex = 101;
            // 
            // label_progSubTitle
            // 
            label_progSubTitle.ImageAlign = ContentAlignment.TopLeft;
            label_progSubTitle.Location = new Point(97, 50);
            label_progSubTitle.Margin = new Padding(0, 10, 0, 0);
            label_progSubTitle.Name = "label_progSubTitle";
            label_progSubTitle.Size = new Size(110, 15);
            label_progSubTitle.TabIndex = 76;
            label_progSubTitle.Text = "IT Service Desk - UK";
            label_progSubTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox_About
            // 
            groupBox_About.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox_About.Controls.Add(LinkLabel_SysAid);
            groupBox_About.Controls.Add(LinkLabel_ITSEmail);
            groupBox_About.Controls.Add(label_telNo_val);
            groupBox_About.Controls.Add(label_email);
            groupBox_About.Controls.Add(label_telNo);
            groupBox_About.Controls.Add(label_dev);
            groupBox_About.Controls.Add(LinkLabel_ReportABug);
            groupBox_About.Location = new Point(700, 512);
            groupBox_About.MinimumSize = new Size(236, 132);
            groupBox_About.Name = "groupBox_About";
            groupBox_About.Size = new Size(236, 132);
            groupBox_About.TabIndex = 77;
            groupBox_About.TabStop = false;
            groupBox_About.Text = "About";
            // 
            // LinkLabel_SysAid
            // 
            LinkLabel_SysAid.AutoSize = true;
            LinkLabel_SysAid.Location = new Point(6, 109);
            LinkLabel_SysAid.Name = "LinkLabel_SysAid";
            LinkLabel_SysAid.Size = new Size(42, 15);
            LinkLabel_SysAid.TabIndex = 2;
            LinkLabel_SysAid.TabStop = true;
            LinkLabel_SysAid.Text = "SysAid";
            LinkLabel_SysAid.LinkClicked += LinkLabel_SysAid_LinkClicked;
            // 
            // LinkLabel_ITSEmail
            // 
            LinkLabel_ITSEmail.AutoSize = true;
            LinkLabel_ITSEmail.Location = new Point(58, 91);
            LinkLabel_ITSEmail.Name = "LinkLabel_ITSEmail";
            LinkLabel_ITSEmail.Size = new Size(164, 15);
            LinkLabel_ITSEmail.TabIndex = 7;
            LinkLabel_ITSEmail.TabStop = true;
            LinkLabel_ITSEmail.Text = "ITServiceDesk@triumph.co.uk";
            LinkLabel_ITSEmail.LinkClicked += LinkLabel_ITSEmail_LinkClicked;
            // 
            // label_telNo_val
            // 
            label_telNo_val.AutoSize = true;
            label_telNo_val.Location = new Point(58, 73);
            label_telNo_val.Name = "label_telNo_val";
            label_telNo_val.Size = new Size(53, 15);
            label_telNo_val.TabIndex = 6;
            label_telNo_val.Text = "Ext. 3333";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_email.Location = new Point(6, 91);
            label_email.Name = "label_email";
            label_email.Size = new Size(39, 15);
            label_email.TabIndex = 4;
            label_email.Text = "Email:";
            // 
            // label_telNo
            // 
            label_telNo.AutoSize = true;
            label_telNo.Location = new Point(6, 73);
            label_telNo.Name = "label_telNo";
            label_telNo.Size = new Size(46, 15);
            label_telNo.TabIndex = 3;
            label_telNo.Text = "Tel No.:";
            // 
            // label_dev
            // 
            label_dev.AutoSize = true;
            label_dev.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_dev.Location = new Point(6, 19);
            label_dev.Name = "label_dev";
            label_dev.Size = new Size(205, 15);
            label_dev.TabIndex = 0;
            label_dev.Text = "Developed by: IT Service Desk - UK";
            // 
            // LinkLabel_ReportABug
            // 
            LinkLabel_ReportABug.AutoSize = true;
            LinkLabel_ReportABug.Location = new Point(6, 37);
            LinkLabel_ReportABug.Name = "LinkLabel_ReportABug";
            LinkLabel_ReportABug.Size = new Size(75, 15);
            LinkLabel_ReportABug.TabIndex = 8;
            LinkLabel_ReportABug.TabStop = true;
            LinkLabel_ReportABug.Text = "Report a bug";
            LinkLabel_ReportABug.LinkClicked += LinkLabel_ReportABug_LinkClicked;
            // 
            // label_progStatus
            // 
            label_progStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_progStatus.AutoSize = true;
            label_progStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_progStatus.Location = new Point(647, 30);
            label_progStatus.Name = "label_progStatus";
            label_progStatus.Size = new Size(42, 15);
            label_progStatus.TabIndex = 78;
            label_progStatus.Text = "Status:";
            // 
            // textBox_progStatusOutput
            // 
            textBox_progStatusOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_progStatusOutput.BorderStyle = BorderStyle.FixedSingle;
            textBox_progStatusOutput.Location = new Point(701, 28);
            textBox_progStatusOutput.Multiline = true;
            textBox_progStatusOutput.Name = "textBox_progStatusOutput";
            textBox_progStatusOutput.ReadOnly = true;
            textBox_progStatusOutput.Size = new Size(235, 39);
            textBox_progStatusOutput.TabIndex = 79;
            // 
            // label_progVer
            // 
            label_progVer.AutoSize = true;
            label_progVer.ImageAlign = ContentAlignment.TopLeft;
            label_progVer.Location = new Point(477, 30);
            label_progVer.Margin = new Padding(0, 10, 0, 0);
            label_progVer.Name = "label_progVer";
            label_progVer.Size = new Size(66, 15);
            label_progVer.TabIndex = 80;
            label_progVer.Text = "Version  x.1";
            label_progVer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl_Functions
            // 
            tabControl_Functions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl_Functions.Controls.Add(tabPage_userTools);
            tabControl_Functions.Controls.Add(tabPage_adminTools);
            tabControl_Functions.Controls.Add(tabPage_resources);
            tabControl_Functions.Location = new Point(701, 100);
            tabControl_Functions.MinimumSize = new Size(237, 406);
            tabControl_Functions.Name = "tabControl_Functions";
            tabControl_Functions.SelectedIndex = 0;
            tabControl_Functions.Size = new Size(237, 406);
            tabControl_Functions.TabIndex = 81;
            // 
            // tabPage_userTools
            // 
            tabPage_userTools.BackColor = SystemColors.Control;
            tabPage_userTools.Controls.Add(Button_LaunchTeamviewer);
            tabPage_userTools.Controls.Add(Button_LaunchMapDrives);
            tabPage_userTools.Location = new Point(4, 24);
            tabPage_userTools.Name = "tabPage_userTools";
            tabPage_userTools.Padding = new Padding(3);
            tabPage_userTools.Size = new Size(229, 378);
            tabPage_userTools.TabIndex = 0;
            tabPage_userTools.Text = "User Tools";
            // 
            // Button_LaunchTeamviewer
            // 
            Button_LaunchTeamviewer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchTeamviewer.Location = new Point(6, 6);
            Button_LaunchTeamviewer.Name = "Button_LaunchTeamviewer";
            Button_LaunchTeamviewer.Size = new Size(217, 23);
            Button_LaunchTeamviewer.TabIndex = 1;
            Button_LaunchTeamviewer.Text = "TeamViewer (Remote Support)";
            Button_LaunchTeamviewer.UseVisualStyleBackColor = true;
            Button_LaunchTeamviewer.Click += Button_LaunchTeamviewer_Click;
            // 
            // Button_LaunchMapDrives
            // 
            Button_LaunchMapDrives.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchMapDrives.Location = new Point(6, 35);
            Button_LaunchMapDrives.Name = "Button_LaunchMapDrives";
            Button_LaunchMapDrives.Size = new Size(217, 23);
            Button_LaunchMapDrives.TabIndex = 0;
            Button_LaunchMapDrives.Text = "Map Drives";
            Button_LaunchMapDrives.UseVisualStyleBackColor = true;
            Button_LaunchMapDrives.Click += Button_LaunchMapDrives_Click;
            // 
            // tabPage_adminTools
            // 
            tabPage_adminTools.BackColor = SystemColors.Control;
            tabPage_adminTools.Controls.Add(Button_LaunchSnowScan);
            tabPage_adminTools.Location = new Point(4, 24);
            tabPage_adminTools.Name = "tabPage_adminTools";
            tabPage_adminTools.Padding = new Padding(3);
            tabPage_adminTools.Size = new Size(229, 378);
            tabPage_adminTools.TabIndex = 1;
            tabPage_adminTools.Text = "Admin Tools";
            // 
            // Button_LaunchSnowScan
            // 
            Button_LaunchSnowScan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchSnowScan.Location = new Point(6, 6);
            Button_LaunchSnowScan.Name = "Button_LaunchSnowScan";
            Button_LaunchSnowScan.Size = new Size(219, 23);
            Button_LaunchSnowScan.TabIndex = 3;
            Button_LaunchSnowScan.Text = "Snow Scan";
            Button_LaunchSnowScan.UseVisualStyleBackColor = true;
            Button_LaunchSnowScan.Click += Button_LaunchSnowScan_Click;
            // 
            // tabPage_resources
            // 
            tabPage_resources.BackColor = SystemColors.Control;
            tabPage_resources.Controls.Add(Button_WakeOnLAN);
            tabPage_resources.Controls.Add(Button_LaunchTriumphOnline);
            tabPage_resources.Controls.Add(Button_LaunchWindchill);
            tabPage_resources.Location = new Point(4, 24);
            tabPage_resources.Name = "tabPage_resources";
            tabPage_resources.Padding = new Padding(3);
            tabPage_resources.Size = new Size(229, 378);
            tabPage_resources.TabIndex = 2;
            tabPage_resources.Text = "Resources";
            // 
            // Button_WakeOnLAN
            // 
            Button_WakeOnLAN.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_WakeOnLAN.Location = new Point(6, 64);
            Button_WakeOnLAN.Name = "Button_WakeOnLAN";
            Button_WakeOnLAN.Size = new Size(219, 23);
            Button_WakeOnLAN.TabIndex = 3;
            Button_WakeOnLAN.Text = "Wake On LAN";
            Button_WakeOnLAN.UseVisualStyleBackColor = true;
            Button_WakeOnLAN.Click += Button_LaunchWakeOnLAN_Click;
            // 
            // Button_LaunchTriumphOnline
            // 
            Button_LaunchTriumphOnline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchTriumphOnline.Location = new Point(6, 35);
            Button_LaunchTriumphOnline.Name = "Button_LaunchTriumphOnline";
            Button_LaunchTriumphOnline.Size = new Size(219, 23);
            Button_LaunchTriumphOnline.TabIndex = 2;
            Button_LaunchTriumphOnline.Text = "Triumph Online";
            Button_LaunchTriumphOnline.UseVisualStyleBackColor = true;
            Button_LaunchTriumphOnline.Click += Button_LaunchTriumphOnline_Click;
            // 
            // Button_LaunchWindchill
            // 
            Button_LaunchWindchill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchWindchill.Location = new Point(6, 6);
            Button_LaunchWindchill.Name = "Button_LaunchWindchill";
            Button_LaunchWindchill.Size = new Size(219, 23);
            Button_LaunchWindchill.TabIndex = 1;
            Button_LaunchWindchill.Text = "Windchill";
            Button_LaunchWindchill.UseVisualStyleBackColor = true;
            Button_LaunchWindchill.Click += Button_LaunchWindchill_Click;
            // 
            // checkBox_shellExecVisibility
            // 
            checkBox_shellExecVisibility.AutoSize = true;
            checkBox_shellExecVisibility.Location = new Point(822, 73);
            checkBox_shellExecVisibility.Name = "checkBox_shellExecVisibility";
            checkBox_shellExecVisibility.Size = new Size(115, 19);
            checkBox_shellExecVisibility.TabIndex = 3;
            checkBox_shellExecVisibility.Text = "Shell Exec Visible";
            checkBox_shellExecVisibility.UseVisualStyleBackColor = true;
            // 
            // progressBar_progProgress
            // 
            progressBar_progProgress.Enabled = false;
            progressBar_progProgress.Location = new Point(73, 654);
            progressBar_progProgress.MarqueeAnimationSpeed = 10;
            progressBar_progProgress.Name = "progressBar_progProgress";
            progressBar_progProgress.Size = new Size(820, 23);
            progressBar_progProgress.Style = ProgressBarStyle.Continuous;
            progressBar_progProgress.TabIndex = 82;
            // 
            // label_progProgressPct
            // 
            label_progProgressPct.AutoSize = true;
            label_progProgressPct.Location = new Point(899, 657);
            label_progProgressPct.Name = "label_progProgressPct";
            label_progProgressPct.Size = new Size(25, 15);
            label_progProgressPct.TabIndex = 84;
            label_progProgressPct.Text = "- %";
            // 
            // label_progPogress
            // 
            label_progPogress.AutoSize = true;
            label_progPogress.Location = new Point(12, 657);
            label_progPogress.Name = "label_progPogress";
            label_progPogress.Size = new Size(55, 15);
            label_progPogress.TabIndex = 85;
            label_progPogress.Text = "Progress:";
            // 
            // label_progProgressStatus
            // 
            label_progProgressStatus.AutoSize = true;
            label_progProgressStatus.Location = new Point(73, 680);
            label_progProgressStatus.Name = "label_progProgressStatus";
            label_progProgressStatus.Size = new Size(42, 15);
            label_progProgressStatus.TabIndex = 86;
            label_progProgressStatus.Text = "Status:";
            // 
            // label_progProgressStatusOut
            // 
            label_progProgressStatusOut.AutoSize = true;
            label_progProgressStatusOut.Location = new Point(121, 680);
            label_progProgressStatusOut.Name = "label_progProgressStatusOut";
            label_progProgressStatusOut.Size = new Size(39, 15);
            label_progProgressStatusOut.TabIndex = 87;
            label_progProgressStatusOut.Text = "Ready";
            // 
            // WinForm_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 704);
            Controls.Add(label_progProgressStatusOut);
            Controls.Add(label_progProgressStatus);
            Controls.Add(label_progPogress);
            Controls.Add(label_progProgressPct);
            Controls.Add(progressBar_progProgress);
            Controls.Add(checkBox_shellExecVisibility);
            Controls.Add(tabControl_Functions);
            Controls.Add(pictureBox_progLogo);
            Controls.Add(label_progVer);
            Controls.Add(textBox_progStatusOutput);
            Controls.Add(label_progStatus);
            Controls.Add(groupBox_About);
            Controls.Add(label_progSubTitle);
            Controls.Add(label_progTitle);
            Controls.Add(groupBox_generalInfo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(963, 743);
            MinimumSize = new Size(963, 742);
            Name = "WinForm_Main";
            Text = "Triumph Support Utility";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_progLogo).EndInit();
            groupBox_generalInfo.ResumeLayout(false);
            groupBox_generalInfo.PerformLayout();
            groupBox_About.ResumeLayout(false);
            groupBox_About.PerformLayout();
            tabControl_Functions.ResumeLayout(false);
            tabPage_userTools.ResumeLayout(false);
            tabPage_adminTools.ResumeLayout(false);
            tabPage_resources.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_progLogo;
        private Label label_progTitle;
        private GroupBox groupBox_generalInfo;
        private Label label_hostname;
        private Label label_username;
        private TextBox textBox_lanMacAddressOutput;
        private Label label_lanMacAddress;
        private TextBox textBox_subnetMaskOutput;
        private TextBox textBox_ipv4AddressOutput;
        private Label label_ipAddress;
        private TextBox textBox_domainNameOutput;
        private Label label_domainName;
        private TextBox textBox_hostnameOutput;
        private Label label_networkDetailsHeader;
        private TextBox textBox_logonServerOutput;
        private Label label_logonServer;
        private TextBox textBox_wlanMacAddressOutput;
        private Label label_wlanMacAddress;
        private TextBox textBox_usernameOutput;
        private TextBox textBox_msTeamsOutput;
        private Label label_msTeams;
        private TextBox textBox_msOffice365Output;
        private Label label_msOffice365;
        private Label label_serviceDetailsHeader;
        private TextBox textBox_snowInventoryAgentOutput;
        private Label label_snowInventoryAgent;
        private TextBox textBox_zscalerOutput;
        private Label label_zscaler;
        private TextBox textBox_teamviewerOutput;
        private Label label_teamviewer;
        private TextBox textBox_damewareOutput;
        private Label label_dameware;
        private TextBox textBox_crowdstrikeOutput;
        private Label label_crowdstrike;
        private TextBox textBox_osOutput;
        private TextBox textBox_modelOutput;
        private Label label_model;
        private TextBox textBox_manufactureOutput;
        private Label label_manufacture;
        private Label label_systemDetailsHeader;
        private TextBox textBox_osPlatformOutput;
        private Label label_progSubTitle;
        private GroupBox groupBox_About;
        private Label label_progStatus;
        private TextBox textBox_progStatusOutput;
        private Label label_progVer;
        private Label label_dev;
        private Label label_subnetMask;
        private TextBox textBox_mimecastOutput;
        private Label label_mimecast;
        private Label label_telNo;
        private LinkLabel LinkLabel_ITSEmail;
        private Label label_email;
        private Label label_telNo_val;
        private LinkLabel LinkLabel_SysAid;
        private TabControl tabControl_Functions;
        private TabPage tabPage_userTools;
        private TabPage tabPage_adminTools;
        private TabPage tabPage_resources;
        private Button Button_RefreshGeneralInformation;
        private Button Button_LaunchTeamviewer;
        private Button Button_LaunchMapDrives;
        private LinkLabel LinkLabel_ReportABug;
        private Button Button_LaunchWindchill;
        private Button Button_LaunchTriumphOnline;
        private Button Button_WakeOnLAN;
        private TextBox textBox_arcticWolfOutput;
        private Label label_arcticWolf;
        private CheckBox checkBox_shellExecVisibility;
        private ProgressBar progressBar_progProgress;
        private Label label_progProgressPct;
        private Label label_progPogress;
        private Label label_progProgressStatus;
        private Label label_progProgressStatusOut;
        private Button Button_LaunchSnowScan;
        private Label label_os;
        private Label label_winVer;
        private Label label_osPlatform;
        private Label label_buildDate;
        private Label label_uptime;
        private Label label8;
        private TextBox textBox_winVerOutput;
        private TextBox textBox_buildDateOutput;
        private TextBox textBox_uptimeOutput;
    }
}