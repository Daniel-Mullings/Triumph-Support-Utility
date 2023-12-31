namespace TriumphSupportUtility_Client
{
    partial class WinForm_UserClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        protected System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_UserClient));
            PictureBox_ProgLogo = new PictureBox();
            Label_ProgTitle = new Label();
            GroupBox_GeneralInfo = new GroupBox();
            Button_Refresh = new Button();
            Label_NetworkDetailsHeader = new Label();
            TextBox_LogonServerOutput = new TextBox();
            Label_LogonServer = new Label();
            TextBox_WlanMacAddressOutput = new TextBox();
            Label_WlanMacAddress = new Label();
            TextBox_UsernameOutput = new TextBox();
            Label_Username = new Label();
            Label_LanMacAddress = new Label();
            TextBox_Ipv4AddressOutput = new TextBox();
            Label_Ipv4Address = new Label();
            TextBox_DomainNameOutput = new TextBox();
            Label_DomainName = new Label();
            TextBox_HostnameOutput = new TextBox();
            Label_Hostname = new Label();
            TextBox_LanMacAddressOutput = new TextBox();
            GroupBox_About = new GroupBox();
            LinkLabel_SysAid = new LinkLabel();
            Label_DevelopedBy = new Label();
            Label_Author = new Label();
            LinkLabel_ReportABug = new LinkLabel();
            TextBox_ProgStateOut = new TextBox();
            CheckBox_ShellExecVisibility = new CheckBox();
            ProgressBar_ProgProgressBar = new ProgressBar();
            Label_ProgProgressPct = new Label();
            Label_ProgPogress = new Label();
            Label_ProgProgressStatus = new Label();
            Label_ProgProgressStatusOut = new Label();
            Button_Cancel = new Button();
            Label_ProgSubTitle = new Label();
            Label_ConnectionState = new Label();
            Label_State = new Label();
            TabPage_Resources = new TabPage();
            Button_WakeOnLAN = new Button();
            Button_LaunchTriumphOnline = new Button();
            Button_LaunchWindchill = new Button();
            TabPage_UserTools = new TabPage();
            Button_LaunchPrinterInstall = new Button();
            Button_LaunchTeamviewer = new Button();
            Button_LaunchMapDrives = new Button();
            TabControl_Tools = new TabControl();
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).BeginInit();
            GroupBox_GeneralInfo.SuspendLayout();
            GroupBox_About.SuspendLayout();
            TabPage_Resources.SuspendLayout();
            TabPage_UserTools.SuspendLayout();
            TabControl_Tools.SuspendLayout();
            SuspendLayout();
            // 
            // PictureBox_ProgLogo
            // 
            PictureBox_ProgLogo.BackColor = SystemColors.Control;
            PictureBox_ProgLogo.BackgroundImageLayout = ImageLayout.Stretch;
            PictureBox_ProgLogo.Image = Properties.Resources.triumphLogo;
            PictureBox_ProgLogo.Location = new Point(12, 12);
            PictureBox_ProgLogo.Name = "PictureBox_ProgLogo";
            PictureBox_ProgLogo.Size = new Size(75, 75);
            PictureBox_ProgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox_ProgLogo.TabIndex = 0;
            PictureBox_ProgLogo.TabStop = false;
            // 
            // Label_ProgTitle
            // 
            Label_ProgTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Label_ProgTitle.Location = new Point(93, 12);
            Label_ProgTitle.Name = "Label_ProgTitle";
            Label_ProgTitle.Size = new Size(365, 37);
            Label_ProgTitle.TabIndex = 100;
            Label_ProgTitle.Text = "TRIUMPH SUPPORT UTILITY";
            // 
            // GroupBox_GeneralInfo
            // 
            GroupBox_GeneralInfo.BackColor = SystemColors.Control;
            GroupBox_GeneralInfo.BackgroundImage = Properties.Resources.backgroundImage;
            GroupBox_GeneralInfo.BackgroundImageLayout = ImageLayout.Center;
            GroupBox_GeneralInfo.Controls.Add(Button_Refresh);
            GroupBox_GeneralInfo.Controls.Add(Label_NetworkDetailsHeader);
            GroupBox_GeneralInfo.Controls.Add(TextBox_LogonServerOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_LogonServer);
            GroupBox_GeneralInfo.Controls.Add(TextBox_WlanMacAddressOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_WlanMacAddress);
            GroupBox_GeneralInfo.Controls.Add(TextBox_UsernameOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_Username);
            GroupBox_GeneralInfo.Controls.Add(Label_LanMacAddress);
            GroupBox_GeneralInfo.Controls.Add(TextBox_Ipv4AddressOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_Ipv4Address);
            GroupBox_GeneralInfo.Controls.Add(TextBox_DomainNameOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_DomainName);
            GroupBox_GeneralInfo.Controls.Add(TextBox_HostnameOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_Hostname);
            GroupBox_GeneralInfo.Controls.Add(TextBox_LanMacAddressOutput);
            GroupBox_GeneralInfo.Location = new Point(12, 122);
            GroupBox_GeneralInfo.Name = "GroupBox_GeneralInfo";
            GroupBox_GeneralInfo.Size = new Size(321, 257);
            GroupBox_GeneralInfo.TabIndex = 200;
            GroupBox_GeneralInfo.TabStop = false;
            GroupBox_GeneralInfo.Text = "General Information";
            // 
            // Button_Refresh
            // 
            Button_Refresh.Location = new Point(240, 0);
            Button_Refresh.Name = "Button_Refresh";
            Button_Refresh.Size = new Size(75, 23);
            Button_Refresh.TabIndex = 201;
            Button_Refresh.Text = "Refresh";
            Button_Refresh.UseVisualStyleBackColor = true;
            Button_Refresh.Click += Button_Refresh_Click;
            // 
            // Label_NetworkDetailsHeader
            // 
            Label_NetworkDetailsHeader.AutoSize = true;
            Label_NetworkDetailsHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Label_NetworkDetailsHeader.ImageAlign = ContentAlignment.TopLeft;
            Label_NetworkDetailsHeader.Location = new Point(3, 29);
            Label_NetworkDetailsHeader.Margin = new Padding(0, 10, 0, 0);
            Label_NetworkDetailsHeader.Name = "Label_NetworkDetailsHeader";
            Label_NetworkDetailsHeader.Size = new Size(115, 15);
            Label_NetworkDetailsHeader.TabIndex = 202;
            Label_NetworkDetailsHeader.Text = "NETWORK DETAILS";
            Label_NetworkDetailsHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_LogonServerOutput
            // 
            TextBox_LogonServerOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_LogonServerOutput.Location = new Point(140, 228);
            TextBox_LogonServerOutput.Name = "TextBox_LogonServerOutput";
            TextBox_LogonServerOutput.ReadOnly = true;
            TextBox_LogonServerOutput.Size = new Size(175, 23);
            TextBox_LogonServerOutput.TabIndex = 216;
            TextBox_LogonServerOutput.TabStop = false;
            // 
            // Label_LogonServer
            // 
            Label_LogonServer.AutoSize = true;
            Label_LogonServer.BackColor = Color.Transparent;
            Label_LogonServer.ImageAlign = ContentAlignment.TopLeft;
            Label_LogonServer.Location = new Point(3, 231);
            Label_LogonServer.Margin = new Padding(0, 10, 0, 0);
            Label_LogonServer.Name = "Label_LogonServer";
            Label_LogonServer.Size = new Size(79, 15);
            Label_LogonServer.TabIndex = 215;
            Label_LogonServer.Text = "Logon Server:";
            Label_LogonServer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_WlanMacAddressOutput
            // 
            TextBox_WlanMacAddressOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_WlanMacAddressOutput.Location = new Point(140, 199);
            TextBox_WlanMacAddressOutput.Name = "TextBox_WlanMacAddressOutput";
            TextBox_WlanMacAddressOutput.ReadOnly = true;
            TextBox_WlanMacAddressOutput.Size = new Size(175, 23);
            TextBox_WlanMacAddressOutput.TabIndex = 214;
            TextBox_WlanMacAddressOutput.TabStop = false;
            // 
            // Label_WlanMacAddress
            // 
            Label_WlanMacAddress.AutoSize = true;
            Label_WlanMacAddress.BackColor = Color.Transparent;
            Label_WlanMacAddress.ImageAlign = ContentAlignment.TopLeft;
            Label_WlanMacAddress.Location = new Point(3, 202);
            Label_WlanMacAddress.Margin = new Padding(0, 10, 0, 0);
            Label_WlanMacAddress.Name = "Label_WlanMacAddress";
            Label_WlanMacAddress.Size = new Size(119, 15);
            Label_WlanMacAddress.TabIndex = 213;
            Label_WlanMacAddress.Text = "WLAN MAC Address:";
            Label_WlanMacAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_UsernameOutput
            // 
            TextBox_UsernameOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_UsernameOutput.Location = new Point(140, 54);
            TextBox_UsernameOutput.Name = "TextBox_UsernameOutput";
            TextBox_UsernameOutput.ReadOnly = true;
            TextBox_UsernameOutput.Size = new Size(175, 23);
            TextBox_UsernameOutput.TabIndex = 204;
            TextBox_UsernameOutput.TabStop = false;
            // 
            // Label_Username
            // 
            Label_Username.AutoSize = true;
            Label_Username.BackColor = Color.Transparent;
            Label_Username.ImageAlign = ContentAlignment.TopLeft;
            Label_Username.Location = new Point(3, 57);
            Label_Username.Margin = new Padding(0, 10, 0, 0);
            Label_Username.Name = "Label_Username";
            Label_Username.Size = new Size(63, 15);
            Label_Username.TabIndex = 203;
            Label_Username.Text = "Username:";
            Label_Username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_LanMacAddress
            // 
            Label_LanMacAddress.AutoSize = true;
            Label_LanMacAddress.BackColor = Color.Transparent;
            Label_LanMacAddress.ImageAlign = ContentAlignment.TopLeft;
            Label_LanMacAddress.Location = new Point(3, 173);
            Label_LanMacAddress.Margin = new Padding(0, 10, 0, 0);
            Label_LanMacAddress.Name = "Label_LanMacAddress";
            Label_LanMacAddress.Size = new Size(108, 15);
            Label_LanMacAddress.TabIndex = 211;
            Label_LanMacAddress.Text = "LAN MAC Address:";
            Label_LanMacAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_Ipv4AddressOutput
            // 
            TextBox_Ipv4AddressOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_Ipv4AddressOutput.Location = new Point(140, 141);
            TextBox_Ipv4AddressOutput.Name = "TextBox_Ipv4AddressOutput";
            TextBox_Ipv4AddressOutput.ReadOnly = true;
            TextBox_Ipv4AddressOutput.Size = new Size(175, 23);
            TextBox_Ipv4AddressOutput.TabIndex = 210;
            TextBox_Ipv4AddressOutput.TabStop = false;
            // 
            // Label_Ipv4Address
            // 
            Label_Ipv4Address.AutoSize = true;
            Label_Ipv4Address.BackColor = Color.Transparent;
            Label_Ipv4Address.ImageAlign = ContentAlignment.TopLeft;
            Label_Ipv4Address.Location = new Point(3, 144);
            Label_Ipv4Address.Margin = new Padding(0, 10, 0, 0);
            Label_Ipv4Address.Name = "Label_Ipv4Address";
            Label_Ipv4Address.Size = new Size(65, 15);
            Label_Ipv4Address.TabIndex = 209;
            Label_Ipv4Address.Text = "IP Address:";
            Label_Ipv4Address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_DomainNameOutput
            // 
            TextBox_DomainNameOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_DomainNameOutput.Location = new Point(140, 112);
            TextBox_DomainNameOutput.Name = "TextBox_DomainNameOutput";
            TextBox_DomainNameOutput.ReadOnly = true;
            TextBox_DomainNameOutput.Size = new Size(175, 23);
            TextBox_DomainNameOutput.TabIndex = 208;
            TextBox_DomainNameOutput.TabStop = false;
            // 
            // Label_DomainName
            // 
            Label_DomainName.AutoSize = true;
            Label_DomainName.BackColor = Color.Transparent;
            Label_DomainName.ImageAlign = ContentAlignment.TopLeft;
            Label_DomainName.Location = new Point(3, 115);
            Label_DomainName.Margin = new Padding(0, 10, 0, 0);
            Label_DomainName.Name = "Label_DomainName";
            Label_DomainName.Size = new Size(87, 15);
            Label_DomainName.TabIndex = 207;
            Label_DomainName.Text = "Domain Name:";
            Label_DomainName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_HostnameOutput
            // 
            TextBox_HostnameOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_HostnameOutput.Location = new Point(140, 83);
            TextBox_HostnameOutput.Name = "TextBox_HostnameOutput";
            TextBox_HostnameOutput.ReadOnly = true;
            TextBox_HostnameOutput.Size = new Size(175, 23);
            TextBox_HostnameOutput.TabIndex = 206;
            TextBox_HostnameOutput.TabStop = false;
            // 
            // Label_Hostname
            // 
            Label_Hostname.AutoSize = true;
            Label_Hostname.BackColor = Color.Transparent;
            Label_Hostname.ImageAlign = ContentAlignment.TopLeft;
            Label_Hostname.Location = new Point(3, 86);
            Label_Hostname.Margin = new Padding(0, 10, 0, 0);
            Label_Hostname.Name = "Label_Hostname";
            Label_Hostname.Size = new Size(65, 15);
            Label_Hostname.TabIndex = 205;
            Label_Hostname.Text = "Hostname:";
            Label_Hostname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TextBox_LanMacAddressOutput
            // 
            TextBox_LanMacAddressOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_LanMacAddressOutput.Location = new Point(140, 170);
            TextBox_LanMacAddressOutput.Name = "TextBox_LanMacAddressOutput";
            TextBox_LanMacAddressOutput.ReadOnly = true;
            TextBox_LanMacAddressOutput.Size = new Size(175, 23);
            TextBox_LanMacAddressOutput.TabIndex = 212;
            TextBox_LanMacAddressOutput.TabStop = false;
            // 
            // GroupBox_About
            // 
            GroupBox_About.Controls.Add(LinkLabel_SysAid);
            GroupBox_About.Controls.Add(Label_DevelopedBy);
            GroupBox_About.Controls.Add(Label_Author);
            GroupBox_About.Location = new Point(339, 284);
            GroupBox_About.Name = "GroupBox_About";
            GroupBox_About.Size = new Size(240, 95);
            GroupBox_About.TabIndex = 400;
            GroupBox_About.TabStop = false;
            GroupBox_About.Text = "About";
            // 
            // LinkLabel_SysAid
            // 
            LinkLabel_SysAid.AutoSize = true;
            LinkLabel_SysAid.Location = new Point(6, 54);
            LinkLabel_SysAid.Name = "LinkLabel_SysAid";
            LinkLabel_SysAid.Size = new Size(42, 15);
            LinkLabel_SysAid.TabIndex = 506;
            LinkLabel_SysAid.TabStop = true;
            LinkLabel_SysAid.Text = "SysAid";
            LinkLabel_SysAid.LinkClicked += LinkLabel_SysAid_LinkClicked;
            // 
            // Label_DevelopedBy
            // 
            Label_DevelopedBy.AutoSize = true;
            Label_DevelopedBy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Label_DevelopedBy.Location = new Point(6, 19);
            Label_DevelopedBy.Name = "Label_DevelopedBy";
            Label_DevelopedBy.Size = new Size(205, 15);
            Label_DevelopedBy.TabIndex = 401;
            Label_DevelopedBy.Text = "Developed by: IT Service Desk - UK";
            // 
            // Label_Author
            // 
            Label_Author.AutoSize = true;
            Label_Author.Font = new Font("Segoe UI", 9F);
            Label_Author.Location = new Point(6, 34);
            Label_Author.Name = "Label_Author";
            Label_Author.Size = new Size(132, 15);
            Label_Author.TabIndex = 402;
            Label_Author.Text = "Author: Daniel Mullings";
            // 
            // LinkLabel_ReportABug
            // 
            LinkLabel_ReportABug.AutoSize = true;
            LinkLabel_ReportABug.Location = new Point(502, 9);
            LinkLabel_ReportABug.Name = "LinkLabel_ReportABug";
            LinkLabel_ReportABug.Size = new Size(77, 15);
            LinkLabel_ReportABug.TabIndex = 103;
            LinkLabel_ReportABug.TabStop = true;
            LinkLabel_ReportABug.Text = "Report A Bug";
            LinkLabel_ReportABug.LinkClicked += LinkLabel_ReportABug_LinkClicked;
            // 
            // TextBox_ProgStateOut
            // 
            TextBox_ProgStateOut.BorderStyle = BorderStyle.FixedSingle;
            TextBox_ProgStateOut.Location = new Point(51, 93);
            TextBox_ProgStateOut.Name = "TextBox_ProgStateOut";
            TextBox_ProgStateOut.ReadOnly = true;
            TextBox_ProgStateOut.Size = new Size(407, 23);
            TextBox_ProgStateOut.TabIndex = 105;
            TextBox_ProgStateOut.TabStop = false;
            // 
            // CheckBox_ShellExecVisibility
            // 
            CheckBox_ShellExecVisibility.AutoSize = true;
            CheckBox_ShellExecVisibility.Location = new Point(464, 95);
            CheckBox_ShellExecVisibility.Name = "CheckBox_ShellExecVisibility";
            CheckBox_ShellExecVisibility.Size = new Size(115, 19);
            CheckBox_ShellExecVisibility.TabIndex = 106;
            CheckBox_ShellExecVisibility.Text = "Shell Exec Visible";
            CheckBox_ShellExecVisibility.UseVisualStyleBackColor = true;
            // 
            // ProgressBar_ProgProgressBar
            // 
            ProgressBar_ProgProgressBar.Enabled = false;
            ProgressBar_ProgProgressBar.Location = new Point(73, 385);
            ProgressBar_ProgProgressBar.MarqueeAnimationSpeed = 10;
            ProgressBar_ProgProgressBar.Name = "ProgressBar_ProgProgressBar";
            ProgressBar_ProgProgressBar.Size = new Size(381, 23);
            ProgressBar_ProgProgressBar.Style = ProgressBarStyle.Continuous;
            ProgressBar_ProgProgressBar.TabIndex = 501;
            // 
            // Label_ProgProgressPct
            // 
            Label_ProgProgressPct.AutoSize = true;
            Label_ProgProgressPct.Location = new Point(541, 388);
            Label_ProgProgressPct.Name = "Label_ProgProgressPct";
            Label_ProgProgressPct.Size = new Size(25, 15);
            Label_ProgProgressPct.TabIndex = 503;
            Label_ProgProgressPct.Text = "- %";
            Label_ProgProgressPct.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label_ProgPogress
            // 
            Label_ProgPogress.AutoSize = true;
            Label_ProgPogress.Location = new Point(12, 388);
            Label_ProgPogress.Name = "Label_ProgPogress";
            Label_ProgPogress.Size = new Size(55, 15);
            Label_ProgPogress.TabIndex = 500;
            Label_ProgPogress.Text = "Progress:";
            // 
            // Label_ProgProgressStatus
            // 
            Label_ProgProgressStatus.AutoSize = true;
            Label_ProgProgressStatus.Location = new Point(73, 411);
            Label_ProgProgressStatus.Name = "Label_ProgProgressStatus";
            Label_ProgProgressStatus.Size = new Size(42, 15);
            Label_ProgProgressStatus.TabIndex = 504;
            Label_ProgProgressStatus.Text = "Status:";
            // 
            // Label_ProgProgressStatusOut
            // 
            Label_ProgProgressStatusOut.AutoSize = true;
            Label_ProgProgressStatusOut.Location = new Point(121, 411);
            Label_ProgProgressStatusOut.Name = "Label_ProgProgressStatusOut";
            Label_ProgProgressStatusOut.Size = new Size(39, 15);
            Label_ProgProgressStatusOut.TabIndex = 505;
            Label_ProgProgressStatusOut.Text = "Ready";
            // 
            // Button_Cancel
            // 
            Button_Cancel.Enabled = false;
            Button_Cancel.Location = new Point(460, 385);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(75, 23);
            Button_Cancel.TabIndex = 502;
            Button_Cancel.Text = "Cancel";
            Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // Label_ProgSubTitle
            // 
            Label_ProgSubTitle.ImageAlign = ContentAlignment.TopLeft;
            Label_ProgSubTitle.Location = new Point(97, 50);
            Label_ProgSubTitle.Margin = new Padding(0, 10, 0, 0);
            Label_ProgSubTitle.Name = "Label_ProgSubTitle";
            Label_ProgSubTitle.Size = new Size(361, 17);
            Label_ProgSubTitle.TabIndex = 101;
            Label_ProgSubTitle.Text = "IT Service Desk - UK        Verison x.1";
            Label_ProgSubTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_ConnectionState
            // 
            Label_ConnectionState.ForeColor = Color.Red;
            Label_ConnectionState.ImageAlign = ContentAlignment.TopLeft;
            Label_ConnectionState.Location = new Point(97, 70);
            Label_ConnectionState.Margin = new Padding(0, 10, 0, 0);
            Label_ConnectionState.Name = "Label_ConnectionState";
            Label_ConnectionState.Size = new Size(361, 17);
            Label_ConnectionState.TabIndex = 102;
            Label_ConnectionState.Text = "Connection: Not Established";
            Label_ConnectionState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_State
            // 
            Label_State.AutoSize = true;
            Label_State.BackColor = Color.Transparent;
            Label_State.ImageAlign = ContentAlignment.TopLeft;
            Label_State.Location = new Point(12, 97);
            Label_State.Margin = new Padding(0, 10, 0, 0);
            Label_State.Name = "Label_State";
            Label_State.Size = new Size(36, 15);
            Label_State.TabIndex = 104;
            Label_State.Text = "State:";
            Label_State.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // TabPage_Resources
            // 
            TabPage_Resources.BackColor = SystemColors.Control;
            TabPage_Resources.Controls.Add(Button_WakeOnLAN);
            TabPage_Resources.Controls.Add(Button_LaunchTriumphOnline);
            TabPage_Resources.Controls.Add(Button_LaunchWindchill);
            TabPage_Resources.Location = new Point(4, 24);
            TabPage_Resources.Name = "TabPage_Resources";
            TabPage_Resources.Padding = new Padding(3);
            TabPage_Resources.Size = new Size(234, 120);
            TabPage_Resources.TabIndex = 2;
            TabPage_Resources.Text = "Resources";
            // 
            // Button_WakeOnLAN
            // 
            Button_WakeOnLAN.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_WakeOnLAN.Location = new Point(6, 62);
            Button_WakeOnLAN.Name = "Button_WakeOnLAN";
            Button_WakeOnLAN.Size = new Size(222, 23);
            Button_WakeOnLAN.TabIndex = 306;
            Button_WakeOnLAN.Text = "Wake On LAN";
            Button_WakeOnLAN.UseVisualStyleBackColor = true;
            Button_WakeOnLAN.Click += Button_LaunchWakeOnLAN_Click;
            // 
            // Button_LaunchTriumphOnline
            // 
            Button_LaunchTriumphOnline.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchTriumphOnline.Location = new Point(6, 34);
            Button_LaunchTriumphOnline.Name = "Button_LaunchTriumphOnline";
            Button_LaunchTriumphOnline.Size = new Size(222, 23);
            Button_LaunchTriumphOnline.TabIndex = 305;
            Button_LaunchTriumphOnline.Text = "Triumph Online";
            Button_LaunchTriumphOnline.UseVisualStyleBackColor = true;
            Button_LaunchTriumphOnline.Click += Button_LaunchTriumphOnline_Click;
            // 
            // Button_LaunchWindchill
            // 
            Button_LaunchWindchill.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchWindchill.Location = new Point(6, 6);
            Button_LaunchWindchill.Name = "Button_LaunchWindchill";
            Button_LaunchWindchill.Size = new Size(222, 23);
            Button_LaunchWindchill.TabIndex = 29;
            Button_LaunchWindchill.Text = "Windchill";
            Button_LaunchWindchill.UseVisualStyleBackColor = true;
            Button_LaunchWindchill.Click += Button_LaunchWindchill_Click;
            // 
            // TabPage_UserTools
            // 
            TabPage_UserTools.BackColor = SystemColors.Control;
            TabPage_UserTools.Controls.Add(Button_LaunchPrinterInstall);
            TabPage_UserTools.Controls.Add(Button_LaunchTeamviewer);
            TabPage_UserTools.Controls.Add(Button_LaunchMapDrives);
            TabPage_UserTools.Location = new Point(4, 24);
            TabPage_UserTools.Name = "TabPage_UserTools";
            TabPage_UserTools.Padding = new Padding(3);
            TabPage_UserTools.Size = new Size(234, 120);
            TabPage_UserTools.TabIndex = 0;
            TabPage_UserTools.Text = "User Tools";
            // 
            // Button_LaunchPrinterInstall
            // 
            Button_LaunchPrinterInstall.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchPrinterInstall.Location = new Point(6, 62);
            Button_LaunchPrinterInstall.Margin = new Padding(2);
            Button_LaunchPrinterInstall.Name = "Button_LaunchPrinterInstall";
            Button_LaunchPrinterInstall.Size = new Size(222, 23);
            Button_LaunchPrinterInstall.TabIndex = 303;
            Button_LaunchPrinterInstall.Text = "Install Printer";
            Button_LaunchPrinterInstall.UseVisualStyleBackColor = true;
            Button_LaunchPrinterInstall.Click += Button_LaunchPrinterInstall_Click;
            // 
            // Button_LaunchTeamviewer
            // 
            Button_LaunchTeamviewer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchTeamviewer.Location = new Point(6, 6);
            Button_LaunchTeamviewer.Name = "Button_LaunchTeamviewer";
            Button_LaunchTeamviewer.Size = new Size(222, 23);
            Button_LaunchTeamviewer.TabIndex = 301;
            Button_LaunchTeamviewer.Text = "TeamViewer (Remote Support)";
            Button_LaunchTeamviewer.UseVisualStyleBackColor = true;
            Button_LaunchTeamviewer.Click += Button_LaunchTeamviewer_ClickAsync;
            // 
            // Button_LaunchMapDrives
            // 
            Button_LaunchMapDrives.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Button_LaunchMapDrives.Location = new Point(6, 34);
            Button_LaunchMapDrives.Name = "Button_LaunchMapDrives";
            Button_LaunchMapDrives.Size = new Size(222, 23);
            Button_LaunchMapDrives.TabIndex = 302;
            Button_LaunchMapDrives.Text = "Map Drives";
            Button_LaunchMapDrives.UseVisualStyleBackColor = true;
            Button_LaunchMapDrives.Click += Button_LaunchMapDrives_ClickAsync;
            // 
            // TabControl_Tools
            // 
            TabControl_Tools.Controls.Add(TabPage_UserTools);
            TabControl_Tools.Controls.Add(TabPage_Resources);
            TabControl_Tools.Location = new Point(339, 130);
            TabControl_Tools.Name = "TabControl_Tools";
            TabControl_Tools.SelectedIndex = 0;
            TabControl_Tools.Size = new Size(242, 148);
            TabControl_Tools.TabIndex = 304;
            // 
            // WinForm_UserClient
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMargin = new Size(3, 3);
            ClientSize = new Size(591, 435);
            Controls.Add(Label_State);
            Controls.Add(Button_Cancel);
            Controls.Add(Label_ProgProgressStatusOut);
            Controls.Add(Label_ProgProgressStatus);
            Controls.Add(Label_ProgPogress);
            Controls.Add(LinkLabel_ReportABug);
            Controls.Add(Label_ProgProgressPct);
            Controls.Add(ProgressBar_ProgProgressBar);
            Controls.Add(CheckBox_ShellExecVisibility);
            Controls.Add(TabControl_Tools);
            Controls.Add(PictureBox_ProgLogo);
            Controls.Add(TextBox_ProgStateOut);
            Controls.Add(GroupBox_About);
            Controls.Add(Label_ProgSubTitle);
            Controls.Add(Label_ProgTitle);
            Controls.Add(GroupBox_GeneralInfo);
            Controls.Add(Label_ConnectionState);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(607, 474);
            MinimumSize = new Size(607, 474);
            Name = "WinForm_UserClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Triumph Support Utility - Client (User)";
            Load += OnLoad;
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).EndInit();
            GroupBox_GeneralInfo.ResumeLayout(false);
            GroupBox_GeneralInfo.PerformLayout();
            GroupBox_About.ResumeLayout(false);
            GroupBox_About.PerformLayout();
            TabPage_Resources.ResumeLayout(false);
            TabPage_UserTools.ResumeLayout(false);
            TabControl_Tools.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected PictureBox PictureBox_ProgLogo;
        protected Label Label_ProgTitle;
        protected GroupBox GroupBox_GeneralInfo;
        protected Label Label_Hostname;
        protected Label Label_Username;
        protected TextBox TextBox_LanMacAddressOutput;
        protected Label Label_LanMacAddress;
        protected TextBox TextBox_Ipv4AddressOutput;
        protected Label Label_Ipv4Address;
        protected TextBox TextBox_DomainNameOutput;
        protected Label Label_DomainName;
        protected TextBox TextBox_HostnameOutput;
        protected Label Label_NetworkDetailsHeader;
        protected TextBox TextBox_LogonServerOutput;
        protected Label Label_LogonServer;
        protected TextBox TextBox_WlanMacAddressOutput;
        protected Label Label_WlanMacAddress;
        protected TextBox TextBox_UsernameOutput;
        protected GroupBox GroupBox_About;
        protected TextBox TextBox_ProgStateOut;
        protected Label Label_DevelopedBy;
        protected Button Button_Refresh;
        protected CheckBox CheckBox_ShellExecVisibility;
        protected ProgressBar ProgressBar_ProgProgressBar;
        protected Label Label_ProgProgressPct;
        protected Label Label_ProgPogress;
        protected Label Label_ProgProgressStatus;
        protected Label Label_ProgProgressStatusOut;
        protected Button Button_Cancel;
        protected LinkLabel LinkLabel_ReportABug;
        protected Label Label_Author;
        protected Label Label_ProgSubTitle;
        protected Label Label_ConnectionState;
        protected Label Label_State;
        protected TabPage TabPage_Resources;
        protected Button Button_WakeOnLAN;
        protected Button Button_LaunchTriumphOnline;
        protected Button Button_LaunchWindchill;
        protected TabPage TabPage_UserTools;
        protected TabControl TabControl_Tools;
        protected Button Button_LaunchPrinterInstall;
        protected Button Button_LaunchTeamviewer;
        protected Button Button_LaunchMapDrives;
        protected LinkLabel LinkLabel_SysAid;
    }
}