using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Sockets;
using TriumphSupportUtility.Interfaces;
using TriumphSupportUtility.Tools;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_BroadcastNotification : Form
    {
        IConfiguration config;
        private Tool_BroadcastNotification.NotificationMessage_Base notificationMessage_Base;

        private void FormComplete()
        {
            if (!string.IsNullOrEmpty(ComboBox_Title.Text) && !string.IsNullOrEmpty(ComboBox_Classification.Text) && !string.IsNullOrEmpty(TextBox_Message.Text))
                Button_SendMessage.Enabled = true;
            else
                Button_SendMessage.Enabled = false;
        }
        private void Init()
        {
            if (config != null)
            {
                ComboBox_Title.Items.Clear();
                ComboBox_Classification.Items.Clear();

                ComboBox_Title.Items.AddRange(config.GetSection("ProgramSettings:ToolParameters:AdminTools:BroadcastNotifications:TitleCollection").Get<string[]>());
                ComboBox_Classification.Items.AddRange(config.GetSection("ProgramSettings:ToolParameters:AdminTools:BroadcastNotifications:ClassificationCollection").Get<string[]>());
            }
        }

        public WinForm_BroadcastNotification(IConfiguration p_config = null)
        {
            InitializeComponent();

            config = p_config;
            Init();
        }

        private void Button_SendMessage_Click(object sender, EventArgs e)
        {
            notificationMessage_Base = new Tool_BroadcastNotification.NotificationMessage_Base(ComboBox_Title.Text, ComboBox_Classification.Text, TextBox_Message.Text);

            if (!string.IsNullOrEmpty(TextBox_HostnameOrIP.Text))
            {
                Interface_TcpClient agentController_TcpClient = new Interface_TcpClient(IPAddress.Loopback.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:TcpPort").Get<int>());
                agentController_TcpClient.SetHostname(TextBox_HostnameOrIP.Text);
                if (agentController_TcpClient.isOnline)
                    agentController_TcpClient.Request($"/broadcast {JsonConvert.SerializeObject(notificationMessage_Base)}", false);
                agentController_TcpClient.Dispose();
            }
            else
            {
                Interface_UdpClient agentController_UdpClient = new Interface_UdpClient(IPAddress.Broadcast.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:UdpPort").Get<int>());
                agentController_UdpClient.Request($"/broadcast {JsonConvert.SerializeObject(notificationMessage_Base)}", false);
                agentController_UdpClient.Dispose();
            }
        }
        private void TextBox_HostnameOrIP_TextChanged(object sender, EventArgs e)
        {
            FormComplete();
        }
        private void TextBox_Message_TextChanged(object sender, EventArgs e)
        {
            FormComplete();
        }
        private void ComboBox_Title_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormComplete();
        }
        private void ComboBox_Classification_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormComplete();
        }
        private void ComboBox_Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void ComboBox_Classification_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}