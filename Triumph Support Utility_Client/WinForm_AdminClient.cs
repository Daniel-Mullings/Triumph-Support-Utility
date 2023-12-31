using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Principal;
using TriumphSupportUtility.Interfaces;
using TriumphSupportUtility.Systems;
using TriumphSupportUtility.Tools;
using TriumphSupportUtility.UIControllers;

namespace TriumphSupportUtility_Client
{
    public partial class WinForm_AdminClient : WinForm_UserClient
    {
        protected SystemService_Base systemService_Crowdstrike;
        protected SystemService_Base systemService_Dameware;
        protected SystemService_Base systemService_Teamviewer;
        protected SystemService_Base systemService_Zscaler;
        protected SystemService_Base systemService_Mimecast;
        protected SystemService_Base systemService_SnowInventoryAgent;
        protected SystemService_Base systemService_MsOffice365;
        protected SystemService_Base systemService_MsTeams;
        protected SystemService_Base systemService_ArcticWolf;
        protected Tool_CMD tool_SnowAgentScan;

        protected override void OnLoad(object sender, EventArgs e)
        {
            base.OnLoad(sender, e);
        }
        public WinForm_AdminClient()
        {
            InitializeComponent();
        }

        protected override void Display_Systems_GeneralInformation()
        {
            base.Display_Systems_GeneralInformation();
            UIController_Textbox.SetTextboxText(TextBox_SubnetMaskOutput, systemInfo_ThisPC.subnetMask);

            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Crowdstrike.isInstalled, systemService_Crowdstrike.isRunning, TextBox_CrowdstrikeOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Dameware.isInstalled, TextBox_DamewareOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Teamviewer.isInstalled, systemService_Teamviewer.isRunning, TextBox_TeamviewerOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Zscaler.isInstalled, systemService_Zscaler.isRunning, TextBox_ZscalerOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_Mimecast.isInstalled, TextBox_MimecastOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_SnowInventoryAgent.isInstalled, systemService_SnowInventoryAgent.isRunning, TextBox_SnowInventoryAgentOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_MsOffice365.isInstalled, TextBox_MsOffice365Output);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_MsTeams.isInstalled, TextBox_MsTeamsOutput);
            UIController_Textbox.SetTextboxText_IsInstalled(systemService_ArcticWolf.isInstalled, systemService_ArcticWolf.isRunning, TextBox_ArcticWolfOutput);

            UIController_Textbox.SetTextboxText(TextBox_OsOutput, systemInfo_ThisPC.os);
            UIController_Textbox.SetTextboxText(TextBox_OsPlatformOutput, systemInfo_ThisPC.osPlatform);
            UIController_Textbox.SetTextboxText(TextBox_WinVerOutput, systemInfo_ThisPC.winVer);

            UIController_Textbox.SetTextboxText(TextBox_ManufactureOutput, systemInfo_ThisPC.manufacturer);
            UIController_Textbox.SetTextboxText(TextBox_ModelOutput, systemInfo_ThisPC.model);
            UIController_Textbox.SetTextboxText(TextBox_UptimeOutput, systemInfo_ThisPC.uptime);
            UIController_Textbox.SetTextboxText(TextBox_BuildDateOutput, systemInfo_ThisPC.buildDate);
        }
        protected override void Init()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading Information. . .", Color.DarkOrange);

            isElevated = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

            Init_Config();
            Init_ProgramInfo();
            Init_Interfaces();
            Init_Systems();
            Init_Tools();

            Display_AgentController_ConnectionStatus();
            Display_Systems_GeneralInformation();

            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Ready", Color.Green);
        }
        protected override void Init_Interfaces()
        {
            agentController_TcpClient = new Interface_TcpClient(IPAddress.None.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:TcpPort").Get<int>());
            WinForm_ClientConnect winForm_getClientAddress = new WinForm_ClientConnect(agentController_TcpClient);
            winForm_getClientAddress.ShowDialog();
        }
        protected override void Init_Systems()
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loading General Information. . .", Color.Orange);

            systemInfo_ThisPC = new SystemInfo_Base();
            systemService_Crowdstrike = new SystemService_Base();
            systemService_Dameware = new SystemService_Base();
            systemService_Teamviewer = new SystemService_Base();
            systemService_Zscaler = new SystemService_Base();
            systemService_Mimecast = new SystemService_Base();
            systemService_SnowInventoryAgent = new SystemService_Base();
            systemService_MsOffice365 = new SystemService_Base();
            systemService_MsTeams = new SystemService_Base();
            systemService_ArcticWolf = new SystemService_Base();

            if (agentController_TcpClient.isOnline)
            {
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysinfo -thispc"), systemInfo_ThisPC);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -crowdstrike"), systemService_Crowdstrike);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -dameware"), systemService_Dameware);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -teamviewer"), systemService_Teamviewer);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -zscaler"), systemService_Zscaler);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -mimecast"), systemService_Mimecast);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -snowinventoryagent"), systemService_SnowInventoryAgent);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -msoffice365"), systemService_MsOffice365);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -msteams"), systemService_MsTeams);
                JsonConvert.PopulateObject(agentController_TcpClient.Request("/sysserv -arcticwolf"), systemService_ArcticWolf);

                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Loaded General Information; Ready", Color.Green);
            }
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, "Not Loaded General Information; Ready", Color.Orange);
        }
        protected override void Init_Tools()
        {
            uiController_ToolButtons = new UIController_Button();
            uiController_ToolButtons.SetUIElementButtons(TabControl_Tools.TabPages.Cast<TabPage>().SelectMany(tabPage => tabPage.Controls.Cast<Control>().OfType<Button>()).ToList());

            bool initTools_isSuccess = false;
            do
            {
                try
                {
                    tool_TeamViewer = new Tool_Base(
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:Name").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:ToolPathCollection_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:TeamViewer:WaitToExit").Get<bool>());

                    tool_MapDrives = new Tool_VBS(
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:Name").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolPathCollection_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolWorkingPath").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:ToolArgument").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:UserTools:MapDrives:WaitToExit").Get<bool>());

                    tool_SnowAgentScan = new Tool_CMD(
                        config.GetSection("ProgramSettings:ToolParameters:AdminTools:SnowScan:Name").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:AdminTools:SnowScan:ToolPathCollection_ToVerify").Get<string[]>(),
                        config.GetSection("ProgramSettings:ToolParameters:AdminTools:SnowScan:ToolWorkingPath").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:AdminTools:SnowScan:ToolArgument").Get<string>(),
                        config.GetSection("ProgramSettings:ToolParameters:AdminTools:SnowScan:WaitToExit").Get<bool>());

                    initTools_isSuccess = true;
                }
                catch (Exception)
                {

                    TriumphSupportUtility.Core.Configuration.ClientConfiguration_Rebuild();
                }

            } while (!initTools_isSuccess);

            uiController_ToolButtons.ToggleUiElements(agentController_TcpClient.isOnline && agentController_TcpClient.isLoopback);
        }

        #region WinForm_Butttons
        protected virtual void Button_ReTarget_Click(object sender, EventArgs e)
        {
            Init();
        }
        protected override void Button_Refresh_Click(object sender, EventArgs e)
        {
            Button_Refresh.Enabled = false;
            Display_AgentController_ConnectionStatus();
            Init_Systems();
            Init_Tools();
            Display_Systems_GeneralInformation();
            Button_Refresh.Enabled = true;
        }

        //Admin Tools
        protected virtual async void Button_LaunchSnowScan_ClickAsync(object sender, EventArgs e)
        {
            UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"Launching {tool_SnowAgentScan.toolName}. . .", Color.Orange);

            this.Enabled = false;
            UIController_ProgressBar progressBarController = new UIController_ProgressBar(ProgressBar_ProgProgressBar, Label_ProgProgressPct, Label_ProgProgressStatusOut);

            if (await tool_SnowAgentScan.LaunchToolAsync(progressBarController, CheckBox_ShellExecVisibility.Checked))
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_SnowAgentScan.toolName} Successful; Ready", Color.Green);
            else
                UIController_Textbox.SetTextboxText(TextBox_ProgStateOut, $"{tool_SnowAgentScan.toolName} Unsuccessful, Verify Install & UAC; Ready", Color.DarkOrange);

            progressBarController.Reset();
            this.Enabled = true;
        }
        protected virtual void Button_LaunchMessageBroadcast_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            WinForm_BroadcastNotification broadcastNotification = new WinForm_BroadcastNotification(config);
            broadcastNotification.ShowDialog(this);

            this.Enabled = true;
        }
        #endregion
    }
}