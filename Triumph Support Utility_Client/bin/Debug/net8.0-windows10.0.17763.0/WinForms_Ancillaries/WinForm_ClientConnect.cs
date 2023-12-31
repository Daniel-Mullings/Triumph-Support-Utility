using System.Net;
using System.Net.Sockets;
using TriumphSupportUtility.Interfaces;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_ClientConnect : Form
    {
        public Interface_TcpClient agentObj { get; private set; }

        private async Task ClientConnectAsync()
        {
            IsLoading(true);
            await Task.Run(() => agentObj.SetHostname(TextBox_HostnameOrIP.Text));

            if (agentObj.isOnline)
            {
                GetSuccessfulResolveMessage();
                IsLoading(false);
                Close();
            }
            else
            {
                GetUnsuccessfulResolveMessage();
                DisplayUnsuccessfulResolveDialogue();
                IsLoading(false);
            }
        }
        private void IsLoading(bool isLoading)
        {
            Button_Connect.Enabled = !isLoading;

            Label_ProgBarInfo.Text = string.IsNullOrEmpty(TextBox_HostnameOrIP.Text)
                ? $"Resolving: {IPAddress.Loopback}"
                : $"Resolving: {TextBox_HostnameOrIP.Text}";

            ProgressBar_GetClientAddress.Style = isLoading ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;
            ProgressBar_GetClientAddress.MarqueeAnimationSpeed = 25;
            ProgressBar_GetClientAddress.Visible = isLoading;
            Label_ProgBarInfo.Visible = isLoading;

            Size = new Size(430, isLoading ? 182 : 137);
            MinimumSize = new Size(430, isLoading ? 182 : 137);
            MaximumSize = new Size(430, isLoading ? 182 : 137);
        }
        private string GetSuccessfulResolveMessage()
        {
            return string.IsNullOrEmpty(TextBox_HostnameOrIP.Text)
                ? $"Successfully resolved: {IPAddress.Loopback}"
                : $"Resolving: {TextBox_HostnameOrIP.Text}";
        }
        private string GetUnsuccessfulResolveMessage()
        {
            return string.IsNullOrEmpty(TextBox_HostnameOrIP.Text)
                ? $"Unsuccessfully resolved: {IPAddress.Loopback}"
                : $"Resolving: {TextBox_HostnameOrIP.Text}";
        }
        private void DisplayUnsuccessfulResolveDialogue()
        {
                if (Visible)
                {
                    MessageBox.Show("Connection Unsuccessful:\nFailed to establish connection to target machine", "Error: Connection Unsuccessful",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        public WinForm_ClientConnect(Interface_TcpClient p_agentObj)
        {
            InitializeComponent();
            agentObj = p_agentObj;
        }

        private async void Button_Connect_Click(object sender, EventArgs e)
        {
            await ClientConnectAsync();
        }
    }
}