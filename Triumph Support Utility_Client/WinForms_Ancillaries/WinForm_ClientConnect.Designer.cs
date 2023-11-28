namespace TriumphSupportUtility_Client
{
    partial class WinForm_ClientConnect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_ClientConnect));
            Label_HostnameOrIP = new Label();
            PictureBox_ProgLogo = new PictureBox();
            Label_InfoLine1 = new Label();
            Label_InfoLine2 = new Label();
            Button_Connect = new Button();
            TextBox_HostnameOrIP = new TextBox();
            ProgressBar_GetClientAddress = new ProgressBar();
            Label_ProgBarInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).BeginInit();
            SuspendLayout();
            // 
            // Label_HostnameOrIP
            // 
            Label_HostnameOrIP.AutoSize = true;
            Label_HostnameOrIP.Location = new Point(93, 67);
            Label_HostnameOrIP.Name = "Label_HostnameOrIP";
            Label_HostnameOrIP.Size = new Size(80, 15);
            Label_HostnameOrIP.TabIndex = 1;
            Label_HostnameOrIP.Text = "Hostname/IP:";
            // 
            // PictureBox_ProgLogo
            // 
            PictureBox_ProgLogo.BackgroundImageLayout = ImageLayout.Stretch;
            PictureBox_ProgLogo.Image = Properties.Resources.triumphLogo;
            PictureBox_ProgLogo.Location = new Point(12, 12);
            PictureBox_ProgLogo.Name = "PictureBox_ProgLogo";
            PictureBox_ProgLogo.Size = new Size(75, 75);
            PictureBox_ProgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox_ProgLogo.TabIndex = 2;
            PictureBox_ProgLogo.TabStop = false;
            // 
            // Label_InfoLine1
            // 
            Label_InfoLine1.AutoSize = true;
            Label_InfoLine1.Location = new Point(93, 12);
            Label_InfoLine1.Name = "Label_InfoLine1";
            Label_InfoLine1.Size = new Size(276, 15);
            Label_InfoLine1.TabIndex = 3;
            Label_InfoLine1.Text = "Please enter in the textbox below, the Hostname or";
            // 
            // Label_InfoLine2
            // 
            Label_InfoLine2.AutoSize = true;
            Label_InfoLine2.Location = new Point(93, 29);
            Label_InfoLine2.Name = "Label_InfoLine2";
            Label_InfoLine2.Size = new Size(162, 15);
            Label_InfoLine2.TabIndex = 4;
            Label_InfoLine2.Text = "IP Address of the target client";
            // 
            // Button_Connect
            // 
            Button_Connect.Location = new Point(327, 63);
            Button_Connect.Name = "Button_Connect";
            Button_Connect.Size = new Size(75, 23);
            Button_Connect.TabIndex = 5;
            Button_Connect.Text = "Connect";
            Button_Connect.UseVisualStyleBackColor = true;
            Button_Connect.Click += Button_Connect_Click;
            // 
            // TextBox_HostnameOrIP
            // 
            TextBox_HostnameOrIP.Location = new Point(179, 63);
            TextBox_HostnameOrIP.Name = "TextBox_HostnameOrIP";
            TextBox_HostnameOrIP.PlaceholderText = "Leave blank for This PC";
            TextBox_HostnameOrIP.Size = new Size(142, 23);
            TextBox_HostnameOrIP.TabIndex = 6;
            TextBox_HostnameOrIP.TabStop = false;
            // 
            // ProgressBar_GetClientAddress
            // 
            ProgressBar_GetClientAddress.Enabled = false;
            ProgressBar_GetClientAddress.Location = new Point(12, 92);
            ProgressBar_GetClientAddress.MarqueeAnimationSpeed = 25;
            ProgressBar_GetClientAddress.Name = "ProgressBar_GetClientAddress";
            ProgressBar_GetClientAddress.Size = new Size(390, 23);
            ProgressBar_GetClientAddress.Style = ProgressBarStyle.Marquee;
            ProgressBar_GetClientAddress.TabIndex = 7;
            ProgressBar_GetClientAddress.Visible = false;
            // 
            // Label_ProgBarInfo
            // 
            Label_ProgBarInfo.AutoSize = true;
            Label_ProgBarInfo.Location = new Point(12, 119);
            Label_ProgBarInfo.Name = "Label_ProgBarInfo";
            Label_ProgBarInfo.Size = new Size(162, 15);
            Label_ProgBarInfo.TabIndex = 8;
            Label_ProgBarInfo.Text = "IP Address of the target client";
            // 
            // WinForm_ClientConnect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 98);
            Controls.Add(Label_ProgBarInfo);
            Controls.Add(ProgressBar_GetClientAddress);
            Controls.Add(TextBox_HostnameOrIP);
            Controls.Add(Button_Connect);
            Controls.Add(Label_InfoLine2);
            Controls.Add(Label_InfoLine1);
            Controls.Add(PictureBox_ProgLogo);
            Controls.Add(Label_HostnameOrIP);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(430, 137);
            MinimizeBox = false;
            MinimumSize = new Size(430, 137);
            Name = "WinForm_ClientConnect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Triumph Support Utility - Client Connect";
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Label_HostnameOrIP;
        private PictureBox PictureBox_ProgLogo;
        private Label Label_InfoLine1;
        private Label Label_InfoLine2;
        private Button Button_Connect;
        private TextBox TextBox_HostnameOrIP;
        private ProgressBar ProgressBar_GetClientAddress;
        private Label Label_ProgBarInfo;
    }
}