namespace TriumphSupportUtility_Client
{
    partial class WinForm_BroadcastNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_BroadcastNotification));
            PictureBox_ProgLogo = new PictureBox();
            Label_InfoLine1 = new Label();
            Label_InfoLine2 = new Label();
            Button_SendMessage = new Button();
            Label_HostnameOrIP = new Label();
            TextBox_HostnameOrIP = new TextBox();
            GroupBox_GeneralInfo = new GroupBox();
            ComboBox_Title = new ComboBox();
            TextBox_Message = new TextBox();
            Label_Title = new Label();
            Label_Classification = new Label();
            TextBox_Ipv4AddressOutput = new TextBox();
            Label_Message = new Label();
            ComboBox_Classification = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).BeginInit();
            GroupBox_GeneralInfo.SuspendLayout();
            SuspendLayout();
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
            // Button_SendMessage
            // 
            Button_SendMessage.Enabled = false;
            Button_SendMessage.Location = new Point(12, 390);
            Button_SendMessage.Name = "Button_SendMessage";
            Button_SendMessage.Size = new Size(390, 23);
            Button_SendMessage.TabIndex = 5;
            Button_SendMessage.Text = "Send Message";
            Button_SendMessage.UseVisualStyleBackColor = true;
            Button_SendMessage.Click += Button_SendMessage_Click;
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
            // TextBox_HostnameOrIP
            // 
            TextBox_HostnameOrIP.Location = new Point(179, 63);
            TextBox_HostnameOrIP.Name = "TextBox_HostnameOrIP";
            TextBox_HostnameOrIP.PlaceholderText = "Leave blank for Global Broadcast";
            TextBox_HostnameOrIP.Size = new Size(223, 23);
            TextBox_HostnameOrIP.TabIndex = 1;
            TextBox_HostnameOrIP.TabStop = false;
            TextBox_HostnameOrIP.TextChanged += TextBox_HostnameOrIP_TextChanged;
            // 
            // GroupBox_GeneralInfo
            // 
            GroupBox_GeneralInfo.BackColor = SystemColors.Control;
            GroupBox_GeneralInfo.BackgroundImageLayout = ImageLayout.Center;
            GroupBox_GeneralInfo.Controls.Add(ComboBox_Title);
            GroupBox_GeneralInfo.Controls.Add(TextBox_Message);
            GroupBox_GeneralInfo.Controls.Add(Label_Title);
            GroupBox_GeneralInfo.Controls.Add(Label_Classification);
            GroupBox_GeneralInfo.Controls.Add(TextBox_Ipv4AddressOutput);
            GroupBox_GeneralInfo.Controls.Add(Label_Message);
            GroupBox_GeneralInfo.Controls.Add(ComboBox_Classification);
            GroupBox_GeneralInfo.Location = new Point(12, 93);
            GroupBox_GeneralInfo.Name = "GroupBox_GeneralInfo";
            GroupBox_GeneralInfo.Size = new Size(390, 291);
            GroupBox_GeneralInfo.TabIndex = 7;
            GroupBox_GeneralInfo.TabStop = false;
            GroupBox_GeneralInfo.Text = "Message Builder";
            // 
            // ComboBox_Title
            // 
            ComboBox_Title.FormattingEnabled = true;
            ComboBox_Title.Items.AddRange(new object[] { "IT Service Desk - UK" });
            ComboBox_Title.Location = new Point(89, 25);
            ComboBox_Title.Name = "ComboBox_Title";
            ComboBox_Title.Size = new Size(295, 23);
            ComboBox_Title.TabIndex = 2;
            ComboBox_Title.SelectedIndexChanged += ComboBox_Title_SelectedIndexChanged;
            ComboBox_Title.KeyPress += ComboBox_Title_KeyPress;
            // 
            // TextBox_Message
            // 
            TextBox_Message.Location = new Point(6, 141);
            TextBox_Message.Multiline = true;
            TextBox_Message.Name = "TextBox_Message";
            TextBox_Message.PlaceholderText = "Enter a Message";
            TextBox_Message.Size = new Size(378, 144);
            TextBox_Message.TabIndex = 4;
            TextBox_Message.TabStop = false;
            TextBox_Message.TextChanged += TextBox_Message_TextChanged;
            // 
            // Label_Title
            // 
            Label_Title.AutoSize = true;
            Label_Title.BackColor = Color.Transparent;
            Label_Title.ImageAlign = ContentAlignment.TopLeft;
            Label_Title.Location = new Point(3, 29);
            Label_Title.Margin = new Padding(0, 10, 0, 0);
            Label_Title.Name = "Label_Title";
            Label_Title.Size = new Size(32, 15);
            Label_Title.TabIndex = 77;
            Label_Title.Text = "Title:";
            Label_Title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_Classification
            // 
            Label_Classification.AutoSize = true;
            Label_Classification.BackColor = Color.Transparent;
            Label_Classification.ImageAlign = ContentAlignment.TopLeft;
            Label_Classification.Location = new Point(3, 57);
            Label_Classification.Margin = new Padding(0, 10, 0, 0);
            Label_Classification.Name = "Label_Classification";
            Label_Classification.Size = new Size(83, 15);
            Label_Classification.TabIndex = 23;
            Label_Classification.Text = "Classafication:";
            Label_Classification.TextAlign = ContentAlignment.MiddleLeft;

            // 
            // TextBox_Ipv4AddressOutput
            // 
            TextBox_Ipv4AddressOutput.BorderStyle = BorderStyle.FixedSingle;
            TextBox_Ipv4AddressOutput.Location = new Point(6, 141);
            TextBox_Ipv4AddressOutput.Multiline = true;
            TextBox_Ipv4AddressOutput.Name = "TextBox_Ipv4AddressOutput";
            TextBox_Ipv4AddressOutput.ReadOnly = true;
            TextBox_Ipv4AddressOutput.Size = new Size(378, 144);
            TextBox_Ipv4AddressOutput.TabIndex = 6;
            // 
            // Label_Message
            // 
            Label_Message.AutoSize = true;
            Label_Message.BackColor = Color.Transparent;
            Label_Message.ImageAlign = ContentAlignment.TopLeft;
            Label_Message.Location = new Point(3, 115);
            Label_Message.Margin = new Padding(0, 10, 0, 0);
            Label_Message.Name = "Label_Message";
            Label_Message.Size = new Size(56, 15);
            Label_Message.TabIndex = 3;
            Label_Message.Text = "Message:";
            Label_Message.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ComboBox_Classification
            // 
            ComboBox_Classification.FormattingEnabled = true;
            ComboBox_Classification.Items.AddRange(new object[] { "Information", "Outage", "Warning", "Security" });
            ComboBox_Classification.Location = new Point(89, 54);
            ComboBox_Classification.Name = "ComboBox_Classification";
            ComboBox_Classification.Size = new Size(295, 23);
            ComboBox_Classification.TabIndex = 3;
            ComboBox_Classification.SelectedIndexChanged += ComboBox_Classification_SelectedIndexChanged;
            ComboBox_Classification.KeyPress += ComboBox_Classification_KeyPress;
            // 
            // WinForm_BroadcastNotification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 425);
            Controls.Add(GroupBox_GeneralInfo);
            Controls.Add(TextBox_HostnameOrIP);
            Controls.Add(Button_SendMessage);
            Controls.Add(Label_InfoLine2);
            Controls.Add(Label_InfoLine1);
            Controls.Add(PictureBox_ProgLogo);
            Controls.Add(Label_HostnameOrIP);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(430, 137);
            Name = "WinForm_BroadcastNotification";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Triumph Support Utility - Broadcast Message";
            ((System.ComponentModel.ISupportInitialize)PictureBox_ProgLogo).EndInit();
            GroupBox_GeneralInfo.ResumeLayout(false);
            GroupBox_GeneralInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox PictureBox_ProgLogo;
        private Label Label_InfoLine1;
        private Label Label_InfoLine2;
        private Button Button_SendMessage;
        private Label Label_HostnameOrIP;
        private TextBox TextBox_HostnameOrIP;
        private GroupBox GroupBox_GeneralInfo;
        private Label Label_Classification;
        private Label Label_Message;
        private Label Label_Title;
        private TextBox TextBox_Message;
        private TextBox TextBox_Ipv4AddressOutput;
        private ComboBox ComboBox_Title;
        private ComboBox ComboBox_Classification;
    }
}