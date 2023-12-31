using Newtonsoft.Json;
using System.Windows.Forms;

namespace TriumphSupportUtility.Core
{
    public static class Components
    {
        public static void Wait(int p_milliseconds)
        {
            var timer = new System.Windows.Forms.Timer();
            if (p_milliseconds == 0 || p_milliseconds < 0) return;

            timer.Interval = p_milliseconds;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
    public static class Configuration
    {
        public static void ClientConfiguration_Rebuild()
        {
            var clientConfig_UnserializedJson = new
            {
                ProgramSettings = new
                {
                    ProgramParameters = new
                    {
                        Name = "Triumph Support Utility",
                        Version = "2.x",
                        Type = "Client",
                        Author = "Daniel Mullings",
                        Links = new
                        {
                            SysAid = new { Link = "https://triumphmotorcycles.sysaidit.com/" },
                            ReportABug = new { Link = "https://forms.office.com/e/TRQkzVyVab" }
                        }
                    },
                    ConnectionParameters = new
                    {
                        TcpPort = 3027,
                        UdpPort = 3028
                    },
                    ToolParameters = new
                    {
                        UserTools = new
                        {
                            TeamViewer = new
                            {
                                Name = "TeamViewer",
                                ToolPathCollection_ToVerify = new[]
                            {
                                "C:\\Users\\Public\\Desktop\\Support.exe",
                                "C:\\Program Files (x86)\\TeamViewer\\Teamviewer.exe",
                                "C:\\Program Files\\TeamViewer\\Teamviewer.exe"
                            },
                                WaitToExit = false
                            },
                            MapDrives = new
                            {
                                Name = "Map Drives",
                                ToolPathCollection_ToVerify = new[] { "C:\\Windows\\System32\\cscript.exe" },
                                ToolWorkingPath = ".\\Scripts",
                                ToolArgument = ".\\Map_Drives.vbs",
                                WaitToExit = true
                            }
                        },
                        AdminTools = new
                        {
                            SnowScan = new
                            {
                                Name = "Snow Inventory Agent Scan",
                                ToolPathCollection_ToVerify = new[] { "C:\\Windows\\System32\\cmd.exe" },
                                ToolWorkingPath = ".\\Scripts",
                                ToolArgument = ".\\Snow_Scan.bat",
                                WaitToExit = true
                            },
                            BroadcastNotifications = new
                            {
                                TitleCollection = new[] { "IT Service Desk - UK" },
                                ClassificationCollection = new[] { "Information", "Outage", "Warning", "Security" }
                            }
                        },
                        Resources = new
                        {
                            Windchill = new { Link = "http://windchill.triumphdesigns.com/Windchill/app/" },
                            TOL = new { Link = "https://triumphonline.net/Account/Login" },
                            WOL = new { Link = "http://wol/" }
                        }
                    }
                }
            };

            string clientConfig_SerializedJson = JsonConvert.SerializeObject(clientConfig_UnserializedJson, Formatting.Indented);
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\config.json", clientConfig_SerializedJson);
        }
        public static void AgentConfiguration_Rebuild()
        {
            var agentConfig_UnserializedJson = new
            {
                ProgramSettings = new
                {
                    ProgramParameters = new
                    {
                        Name = "Triumph Support Utility",
                        Version = "2.x",
                        Type = "Agent",
                        Author = "Daniel Mullings"
                    },
                    ConnectionParameters = new
                    {
                        TcpPort = 3027,
                        UdpPort = 3028
                    },
                    SystemServiceParameters = new
                    {
                        Crowdstrike = new
                        {
                            Name = "Crowdstrike",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Crowdstrike", "C:\\Program Files\\Crowdstrike" },
                            serviceProcessCollection = new[] { "CSFalconService" }
                        },
                        Dameware = new
                        {
                            Name = "Dameware",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\SolarWinds\\Dameware Mini Remote Control", "C:\\Program Files\\SolarWinds\\Dameware Mini Remote Control x64" }
                        },
                        TeamViewer = new
                        {
                            Name = "TeamViewer",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\TeamViewer", "C:\\Program Files\\TeamViewer" },
                            serviceProcessCollection = new[] { "TeamViewer" }
                        },
                        Zscaler = new
                        {
                            Name = "ZScaler",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Zscaler", "C:\\Program Files\\Zscaler" },
                            serviceProcessCollection = new[] { "ZSAService", "ZSATrayManager", "ZSATunnel", "ZSAUpdater", "ZSAUmp" }
                        },
                        Mimecast = new
                        {
                            Name = "Mimecast",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Mimecast", "C:\\Program Files\\Mimecast" }
                        },
                        SnowInventoryAgent = new
                        {
                            Name = "Snow Inventory Agent",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Snow Software", "C:\\Program Files\\Snow Software" },
                            serviceProcessCollection = new[] { "SnowInventoryAgent5" }
                        },
                        MsOffice365 = new
                        {
                            Name = "MS Office 365",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Microsoft Office", "C:\\Program Files\\Microsoft Office" }
                        },
                        MsTeams = new
                        {
                            Name = "MS Teams",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Teams Installer", "C:\\Program Files\\Teams Installer" }
                        },
                        ArcticWolf = new
                        {
                            Name = "Arctic Wolf",
                            serviceDirectoryCollection = new[] { "C:\\Program Files (x86)\\Arctic Wolf Networks", "C:\\Program Files\\Arctic Wolf Networks" },
                            serviceProcessCollection = new[] { "ArcticWolfAgentMgr", "Sysmon64" }
                        }
                    }
                }
            };

            string agentConfig_SerializedJson = JsonConvert.SerializeObject(agentConfig_UnserializedJson, Formatting.Indented);
            File.WriteAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\config.json", agentConfig_SerializedJson);
        }
    }
}