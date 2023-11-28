namespace Triumph_Support_Utility
{
    partial class WinForm_ProgressBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_ProgressBar));
            pictureBox_progLogo = new PictureBox();
            label_progTitle = new Label();
            progressBar_processProgress = new ProgressBar();
            button_cancelProcess = new Button();
            label_processProgress = new Label();
            label_processAction = new Label();
            label_processName = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_progLogo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_progLogo
            // 
            pictureBox_progLogo.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_progLogo.Image = Properties.Resources.triumphLogo;
            pictureBox_progLogo.Location = new Point(12, 12);
            pictureBox_progLogo.Name = "pictureBox_progLogo";
            pictureBox_progLogo.Size = new Size(75, 75);
            pictureBox_progLogo.TabIndex = 77;
            pictureBox_progLogo.TabStop = false;
            // 
            // label_progTitle
            // 
            label_progTitle.AutoSize = true;
            label_progTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label_progTitle.Location = new Point(93, 12);
            label_progTitle.Name = "label_progTitle";
            label_progTitle.Size = new Size(381, 37);
            label_progTitle.TabIndex = 78;
            label_progTitle.Text = "TRIUMPH SUPPORT UTILITY";
            // 
            // progressBar_processProgress
            // 
            progressBar_processProgress.Location = new Point(12, 93);
            progressBar_processProgress.MarqueeAnimationSpeed = 10;
            progressBar_processProgress.Name = "progressBar_processProgress";
            progressBar_processProgress.Size = new Size(617, 23);
            progressBar_processProgress.Style = ProgressBarStyle.Marquee;
            progressBar_processProgress.TabIndex = 85;
            // 
            // button_cancelProcess
            // 
            button_cancelProcess.FlatStyle = FlatStyle.Popup;
            button_cancelProcess.Location = new Point(676, 93);
            button_cancelProcess.Name = "button_cancelProcess";
            button_cancelProcess.Size = new Size(75, 23);
            button_cancelProcess.TabIndex = 81;
            button_cancelProcess.Text = "Cancel";
            button_cancelProcess.UseVisualStyleBackColor = true;
            button_cancelProcess.Click += button_cancelProcess_Click;
            // 
            // label_processProgress
            // 
            label_processProgress.AutoSize = true;
            label_processProgress.Location = new Point(635, 97);
            label_processProgress.Name = "label_processProgress";
            label_processProgress.Size = new Size(35, 15);
            label_processProgress.TabIndex = 82;
            label_processProgress.Text = "100%";
            // 
            // label_processAction
            // 
            label_processAction.AutoSize = true;
            label_processAction.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label_processAction.Location = new Point(97, 68);
            label_processAction.Name = "label_processAction";
            label_processAction.Size = new Size(101, 15);
            label_processAction.TabIndex = 84;
            label_processAction.Text = "<Process Action>";
            // 
            // label_processName
            // 
            label_processName.AutoSize = true;
            label_processName.Location = new Point(97, 50);
            label_processName.Name = "label_processName";
            label_processName.Size = new Size(93, 15);
            label_processName.TabIndex = 83;
            label_processName.Text = "<Main Process>";
            // 
            // WinForm_ProgressBar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 129);
            ControlBox = false;
            Controls.Add(label_processAction);
            Controls.Add(label_processName);
            Controls.Add(label_processProgress);
            Controls.Add(button_cancelProcess);
            Controls.Add(progressBar_processProgress);
            Controls.Add(pictureBox_progLogo);
            Controls.Add(label_progTitle);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(779, 168);
            MinimizeBox = false;
            MinimumSize = new Size(779, 168);
            Name = "WinForm_ProgressBar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Triumph Support Utility - Progress";
            ((System.ComponentModel.ISupportInitialize)pictureBox_progLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_progLogo;
        private Label label_progTitle;
        private ProgressBar progressBar_processProgress;
        private Button button_cancelProcess;
        private Label label_processProgress;
        private Label label_processAction;
        private Label label_processName;
    }
}