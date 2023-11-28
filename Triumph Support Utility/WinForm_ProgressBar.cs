using System.Diagnostics;

namespace Triumph_Support_Utility
{
    public partial class WinForm_ProgressBar : Form
    {
        private Form parentForm;
        private Process process;

        public void SetParentForm(Form p_parentForm)
        {
            parentForm = p_parentForm;
            this.Update();
            return;
        }
        public void SetProcess(Process p_process)
        {
            process = p_process;
            this.Update();
            return;
        }
        public void SetProcessName(string p_processName)
        {
            label_processName.Text = p_processName;
            this.Update();
            return;
        }
        public void SetProcessAction(string p_processAction)
        {
            if (p_processAction != "")
                label_processAction.Text = p_processAction + ". . .";
            else
                label_processAction.Text = "";

            this.Update();
            return;
        }
        public void SetProcessProgress(int p_processProgress)
        {
            if (p_processProgress >= 100)
            {
                progressBar_processProgress.Value = 100;
                completeProcess();
            }
            else if (p_processProgress <= 0)
                progressBar_processProgress.Value = 0;
            else
                progressBar_processProgress.Value = p_processProgress;

            progressBar_processProgress.Value = p_processProgress;
            label_processProgress.Text = p_processProgress.ToString() + '%';
            this.Update();
            return;
        }
        public void SetProcessAction_ProcessProgress(string p_processAction, int p_processProgress)
        {
            SetProcessAction(p_processAction);
            SetProcessProgress(p_processProgress);
            return;
        }

        public Form GetParentForm() { return parentForm; }
        public Process GetProcess() { return process; }
        public string GetProcessName() { return label_processName.Text; }
        public string GetProcessAction() { return label_processAction.Text; }
        public int GetProcessProgress() { return progressBar_processProgress.Value; }

        public async void progressBarHold(int p_holdSeconds = 1000)
        {
            await Task.Delay(p_holdSeconds);
        }
        private async void cancelProcess(WinForm_ProgressBar winForm_progressBar)
        {
            SetProcessAction("Cancelling Operation");
            this.Update();
            if (GetProcess() != null)
                GetProcess().Close();
            await Task.Delay(1000);
            GetParentForm().Enabled = true;
            this.Close();
            return;
        }
        private async void completeProcess()
        {
            await Task.Delay(2500);
            GetParentForm().Enabled = true;
            this.Close();
            return;
        }

        public WinForm_ProgressBar(Form p_parentForm, Process p_process, string p_processName, string p_processAction, int p_processProgress)
        {
            
            InitializeComponent();

            SetParentForm(p_parentForm);
            SetProcess(p_process);
            SetProcessName(p_processName);
            SetProcessAction(p_processAction);
            SetProcessProgress(p_processProgress);

            this.Show();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parentForm.DesktopLocation.X + 50, parentForm.DesktopLocation.Y + 50);

            GetParentForm().Enabled = false;
        }

        private void button_cancelProcess_Click(object sender, EventArgs e)
        {
            cancelProcess(this);
        }
    }
}