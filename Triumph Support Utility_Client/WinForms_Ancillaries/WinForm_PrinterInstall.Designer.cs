namespace TriumphSupportUtility_Client
{
    partial class WinForm_PrinterInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_PrinterInstall));
            ComboBox_PrinterList = new ComboBox();
            label_Printer = new Label();
            pictureBox_ProgLogo = new PictureBox();
            label_InfoLine1 = new Label();
            label_InfoLine2 = new Label();
            Button_Install = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_ProgLogo).BeginInit();
            SuspendLayout();
            // 
            // ComboBox_PrinterList
            // 
            ComboBox_PrinterList.DropDownHeight = 250;
            ComboBox_PrinterList.FormattingEnabled = true;
            ComboBox_PrinterList.IntegralHeight = false;
            ComboBox_PrinterList.Location = new Point(144, 64);
            ComboBox_PrinterList.Name = "ComboBox_PrinterList";
            ComboBox_PrinterList.Size = new Size(176, 23);
            ComboBox_PrinterList.Sorted = true;
            ComboBox_PrinterList.TabIndex = 0;
            ComboBox_PrinterList.SelectedIndexChanged += ComboBox_PrinterList_SelectedIndexChanged;
            ComboBox_PrinterList.KeyPress += ComboBox_PrinterList_KeyPress;
            // 
            // label_Printer
            // 
            label_Printer.AutoSize = true;
            label_Printer.Location = new Point(93, 67);
            label_Printer.Name = "label_Printer";
            label_Printer.Size = new Size(45, 15);
            label_Printer.TabIndex = 1;
            label_Printer.Text = "Printer:";
            // 
            // pictureBox_ProgLogo
            // 
            pictureBox_ProgLogo.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_ProgLogo.Image = Properties.Resources.triumphLogo;
            pictureBox_ProgLogo.Location = new Point(12, 12);
            pictureBox_ProgLogo.Name = "pictureBox_ProgLogo";
            pictureBox_ProgLogo.Size = new Size(75, 75);
            pictureBox_ProgLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_ProgLogo.TabIndex = 2;
            pictureBox_ProgLogo.TabStop = false;
            // 
            // label_InfoLine1
            // 
            label_InfoLine1.AutoSize = true;
            label_InfoLine1.Location = new Point(93, 12);
            label_InfoLine1.Name = "label_InfoLine1";
            label_InfoLine1.Size = new Size(303, 15);
            label_InfoLine1.TabIndex = 3;
            label_InfoLine1.Text = "Please select from the list below, the name of the printer";
            // 
            // label_InfoLine2
            // 
            label_InfoLine2.AutoSize = true;
            label_InfoLine2.Location = new Point(93, 29);
            label_InfoLine2.Name = "label_InfoLine2";
            label_InfoLine2.Size = new Size(310, 15);
            label_InfoLine2.TabIndex = 4;
            label_InfoLine2.Text = "to install, and Triumph Support Utility will install it for you";
            // 
            // Button_Install
            // 
            Button_Install.Enabled = false;
            Button_Install.Location = new Point(328, 64);
            Button_Install.Name = "Button_Install";
            Button_Install.Size = new Size(75, 23);
            Button_Install.TabIndex = 5;
            Button_Install.Text = "Install";
            Button_Install.UseVisualStyleBackColor = true;
            Button_Install.Click += Button_Install_Click;
            // 
            // WinForm_PrinterInstall
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 100);
            Controls.Add(Button_Install);
            Controls.Add(label_InfoLine2);
            Controls.Add(label_InfoLine1);
            Controls.Add(pictureBox_ProgLogo);
            Controls.Add(label_Printer);
            Controls.Add(ComboBox_PrinterList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(430, 139);
            MinimizeBox = false;
            MinimumSize = new Size(430, 139);
            Name = "WinForm_PrinterInstall";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Triumph Support Utility - Printer Install";
            ((System.ComponentModel.ISupportInitialize)pictureBox_ProgLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboBox_PrinterList;
        private Label label_Printer;
        private PictureBox pictureBox_ProgLogo;
        private Label label_InfoLine1;
        private Label label_InfoLine2;
        private Button Button_Install;
    }
}