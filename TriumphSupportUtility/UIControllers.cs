using System.Drawing;
using System.Windows.Forms;

namespace TriumphSupportUtility.UIControllers
{
    public class UIController_Base
    {
        //Placeholder Class
    }
    public class UIController_ProgressBar : UIController_Base
    {
        protected ProgressBar progressBar { get; set; }
        protected Label progressBarValue { get; set; }
        protected Label progressBarStatus { get; set; }
        public int customAwaitDelay { get; set; }

        protected void Init()
        {
            progressBar.Value = 0;
            progressBarValue.Text = "- %";
            progressBarStatus.Text = "Ready";
        }
        protected void UpdateStatus(string p_progressStatus)
        {
            progressBarStatus.Text = p_progressStatus + ". . .";
        }
        protected void UpdatePercent(int p_progressPercent)
        {
            if (p_progressPercent >= 100)
                p_progressPercent = 100;
            else if (p_progressPercent <= 0)
                p_progressPercent = 0;

            progressBar.Value = p_progressPercent;
            progressBarValue.Text = p_progressPercent.ToString() + " %";
        }

        public void Reset()
        {
            TriumphSupportUtility.Core.Components.Wait(1000);
            Init();
        }
        public void Update(string p_progressStatus, int p_progressPercent)
        {
            UpdateStatus(p_progressStatus);
            UpdatePercent(p_progressPercent);
        }
        public void Update(string p_progressStatus)
        {
            UpdateStatus(p_progressStatus);
        }
        public void Update(int p_progressPercent)
        {
            UpdatePercent(p_progressPercent);
        }
        public UIController_ProgressBar(ProgressBar p_progressBar, Label p_progressBarPct, Label p_progressBarStatus, int p_customAwaitDelay = 1000)
        {
            progressBar = p_progressBar;
            progressBarValue = p_progressBarPct;
            progressBarStatus = p_progressBarStatus;
            customAwaitDelay = p_customAwaitDelay;

            Init();
        }
    }
    public class UIController_Button
    {
        protected List<Button> buttonCollection = new List<Button>();

        public void SetUIElementButtons(List<Button> p_buttonCollection)
        {
            buttonCollection = p_buttonCollection;
        }
        public void EnableUiElements()
        {
            foreach (Button button in buttonCollection)
            {
                button.Enabled = true;
            }
        }
        public void DisableUiElements()
        {
            foreach (Button button in buttonCollection)
            {
                button.Enabled = false;
            }
        }
        public void ToggleUiElements(bool p_enabled)
        {
            if (p_enabled)
                EnableUiElements();
            else
                DisableUiElements();
        }
        public UIController_Button(List<Button> p_buttonCollection = null)
        {
            if (p_buttonCollection != null)
                SetUIElementButtons(p_buttonCollection);
            DisableUiElements();
        }
    }
    public class UIController_Textbox
    {
        public static void SetTextboxText(TextBox p_textbox, string p_text)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = Color.Black;
            p_textbox.BackColor = p_textbox.BackColor;
        }
        public static void SetTextboxText(TextBox p_textbox, string p_text, Color p_color)
        {
            p_textbox.Text = p_text;
            p_textbox.ForeColor = p_color;

            //ForeColor update only takes effect w/BackColor update
            p_textbox.BackColor = p_textbox.BackColor;
        }
        public static void SetTextboxText_IsInstalled(bool p_isInstalled, TextBox p_textbox)
        {
            if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected; No Auxiliary Service!", Color.Green);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }
        public static void SetTextboxText_IsInstalled(bool p_isInstalled, bool p_isProcessRunning, TextBox p_textbox)
        {
            if (p_isInstalled && p_isProcessRunning)
                SetTextboxText(p_textbox, "Detected; Service Running!", Color.Green);
            else if (p_isInstalled)
                SetTextboxText(p_textbox, "Detected; Service Not Running!", Color.DarkOrange);
            else
                SetTextboxText(p_textbox, "Not Detected!", Color.Red);
        }
    }
}