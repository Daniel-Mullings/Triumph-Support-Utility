using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.Forms;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Windows.UI.ApplicationSettings;
using TriumphSupportUtility.Tools;

namespace TriumphSupportUtility
{
    namespace Components
    {
        public static class Core
        {
            public static void Wait(int p_milliseconds)
            {
                var timer = new System.Windows.Forms.Timer();
                if (p_milliseconds == 0 || p_milliseconds < 0) return;

                // Console.WriteLine("start wait timer");
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
                File.WriteAllText("config.json", System.Text.Json.JsonSerializer.Serialize(File.ReadAllText("config.json"), new JsonSerializerOptions { WriteIndented = true }));
            }
            public static void AgentConfiguration_Rebuild()
            {
                File.WriteAllText("config.json", System.Text.Json.JsonSerializer.Serialize(File.ReadAllText("config.json"), new JsonSerializerOptions { WriteIndented = true }));
            }
        }
    }
    namespace Services
    {
        public class Service_Base
        {
            //Placeholder Class
        }
        public class Service_Agent : BackgroundService
        {
            private readonly ILogger<Service_Agent> logger;
            IConfiguration config { get; set; }
            private DateTime startDateTime { get; set; }
            public Interfaces.Interface_TcpListener agentController_TcpListener { get; set; }
            public Interfaces.Interface_UdpListener agentController_UdpListener { get; set; }
            public List<Interfaces.Interface_TcpListener> agentController_ListenerCollection { get; set; }
            public Systems.SystemInfo_Controller systemInfo_ThisPC { get; set; }
            public Systems.SystemService_Controller systemService_Crowdstrike { get; set; }
            public Systems.SystemService_Controller systemService_Dameware { get; set; }
            public Systems.SystemService_Controller systemService_Teamviewer { get; set; }
            public Systems.SystemService_Controller systemService_Zscaler { get; set; }
            public Systems.SystemService_Controller systemService_Mimecast { get; set; }
            public Systems.SystemService_Controller systemService_SnowInventoryAgent { get; set; }
            public Systems.SystemService_Controller systemService_MsOffice365 { get; set; }
            public Systems.SystemService_Controller systemService_MsTeams { get; set; }
            public Systems.SystemService_Controller systemService_ArcticWolf {  get; set; }


            private async void Display_ServiceStatusAsync(int p_startDisplayServiceStatusAfter_inSeconds = 0)
            {
                if (startDateTime.AddSeconds(p_startDisplayServiceStatusAfter_inSeconds) > DateTime.Now)
                    return;

                Console.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Service Status: ");
                Display_isServiceListening();
            }
            private void Display_isServiceListening()
            {
                foreach (Interfaces.Interface_TcpListener agentController_Listener in agentController_ListenerCollection)
                {
                    if (agentController_Listener.isListening)
                        Console.WriteLine($"LISTENING TO {agentController_Listener.ipv4Address}:{agentController_Listener.port}");
                    else
                        Console.WriteLine($"NOT LISTENING TO {agentController_Listener.ipv4Address}:{agentController_Listener.port}");
                }
            }
            private void Init()
            {
                Console.WriteLine("[NOTICE] Triumph Support Utility - Agent\n" +
                                  "         Developed by: Daniel Mullings (On behalf of Triumph Motorcycles .Ltd)\n");
                Console.WriteLine("[NOTICE] Service Status updates will begin printing in 5 seconds. . .\n");

                startDateTime = DateTime.Now;
                logger.LogInformation($"[{DateTime.Now.ToString("dd-MM-yyyy @ HH:mm:ss")}] Triumph Support Utility - Agent: Starting");

                Init_Configuration();
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Triumph Support Utility - Agent: Configuration: Initialised");

                Init_Systems();
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Triumph Support Utility - Agent: Systems: Initialised");

                Init_Interfaces();
                agentController_TcpListener.StartListeningAsync();
                agentController_UdpListener.StartListeningAsync();
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Triumph Support Utility - Agent: Interface(s): Initialised");

                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Triumph Support Utility - Agent: Started");
            }
            private void Init_Configuration()
            {
                if (!File.Exists("config.json"))
                    TriumphSupportUtility.Components.Configuration.AgentConfiguration_Rebuild();
                config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            }
            private void Init_Systems()
            {
                systemInfo_ThisPC = new Systems.SystemInfo_Controller();
                systemService_Crowdstrike = new Systems.SystemService_Controller(
                    config.GetSection("ProgramParameters:SystemServices:Crowdstrike:Name").Get<string>(),
                    config.GetSection("ProgramParameters:SystemServices:Crowdstrike:serviceDirectoryCollection").Get<string[]>(),
                    config.GetSection("ProgramParameters:SystemServices:Crowdstrike:serviceProcessCollection").Get<string[]>());
                systemService_Dameware = new Systems.SystemService_Controller(
                    "Dameware",
                    new string[] { @"C:\Program Files (x86)\SolarWinds\Dameware Mini Remote Control", @"C:\Program Files\SolarWinds\Dameware Mini Remote Control x64" });
                systemService_Teamviewer = new Systems.SystemService_Controller(
                    "TeamViewer",
                    new string[] { @"C:\Program Files (x86)\TeamViewer", @"C:\Program Files\TeamViewer" },
                    new string[] { "TeamViewer" });
                systemService_Zscaler = new Systems.SystemService_Controller(
                    "ZScaler",
                    new string[] { @"C:\Program Files (x86)\Zscaler", @"C:\Program Files\Zscaler" },
                    new string[] { "ZSAService", "ZSATrayManager", "ZSATunnel", "ZSAUpdater", "ZSAUmp" });
                systemService_Mimecast = new Systems.SystemService_Controller(
                    "Mimecast",
                    new string[] { @"C:\Program Files (x86)\Mimecast", @"C:\Program Files\Mimecast" });
                systemService_SnowInventoryAgent = new Systems.SystemService_Controller(
                    "Snow Inventory Agent",
                    new string[] { @"C:\Program Files (x86)\Snow Software", @"C:\Program Files\Snow Software" },
                    new string[] { "SnowInventoryAgent5" });
                systemService_MsOffice365 = new Systems.SystemService_Controller(
                    "MS Office 365",
                    new string[] { @"C:\Program Files (x86)\Microsoft Office", @"C:\Program Files\Microsoft Office" });
                systemService_MsTeams = new Systems.SystemService_Controller(
                    "MS Teams",
                    new string[] { @"C:\Program Files (x86)\Teams Installer", @"C:\Program Files\Teams Installer" });
                systemService_ArcticWolf = new Systems.SystemService_Controller(
                    "Arctic Wolf",
                    new string[] { @"C:\Program Files (x86)\Arctic Wolf Networks", @"C:\Program Files\Arctic Wolf Networks" },
                    new string[] { "ArcticWolfAgentMgr", "Sysmon64" });

                systemInfo_ThisPC.Init();
                systemService_Crowdstrike.Init();
                systemService_Dameware.Init();
                systemService_Teamviewer.Init();
                systemService_Zscaler.Init();
                systemService_Mimecast.Init();
                systemService_SnowInventoryAgent.Init();
                systemService_MsOffice365.Init();
                systemService_MsTeams.Init();
                systemService_ArcticWolf.Init();
            }
            private void Init_Interfaces()
            {
                agentController_TcpListener = new Interfaces.Interface_TcpListener(this, logger, IPAddress.Any.ToString(), 3027);
                agentController_UdpListener = new Interfaces.Interface_UdpListener(this, logger, IPAddress.Any.ToString(), 3028);
                agentController_ListenerCollection = new List<Interfaces.Interface_TcpListener> { agentController_TcpListener, agentController_UdpListener };
            }

            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    Display_ServiceStatusAsync(5);
                    await Task.Delay(2500, stoppingToken);

                    Init_Systems();
                }
            }

            public Service_Agent(ILogger<Service_Agent> p_logger)
            {
                logger = p_logger;
                Init();
            }
        }
    }
    namespace Interfaces
    {
        public class Interface_Base
        {
            //Plaeholder Class
        }
        public class Interface_Client
        {
            public bool isDisposed { get; protected set; }
            public IPAddress ipv4Address { get; protected set; }
            public int port { get; set; }
            public bool isLoopback { get; protected set; }
            public bool isOnline { get; protected set; }
        }
        public class Interface_TcpClient : Interface_Client
        {
            private TcpClient tcpClient { get; set; }
            public string hostName { get; private set; }

            internal bool Heartbeat()
            {
                try
                {
                    if (this.Request("/heartbeat") == "iloveyou")
                        return true;
                }
                catch
                {
                    return false;
                }
                return false;
            }
            internal async void HeartbeatAsync()
            {
                while (!isDisposed)
                {
                    try
                    {
                        if (this.Request("/heartbeat") == "iloveyou")
                            isOnline = true;
                    }
                    catch
                    {
                        isOnline = false;
                    }
                    await Task.Delay(10000);
                }
            }

            protected void ResolveIpOrHostname(string p_ipv4AddressOrHostName = "")
            {
                //System (Loopback) connection
                if (p_ipv4AddressOrHostName == "" || p_ipv4AddressOrHostName == IPAddress.Loopback.ToString() || p_ipv4AddressOrHostName == SystemInformation.ComputerName)
                {
                    ipv4Address = IPAddress.Loopback;
                    hostName = "localhost";
                    isLoopback = true;
                    if (Heartbeat())
                        isOnline = true;
                }
                //Local (Network) connection
                else
                {
                    isLoopback = false;
                    try
                    {
                        string ipv4AddressOrHostName_resolved = "";
                        IPHostEntry ipHE = Dns.GetHostEntry(hostName);

                        foreach (IPAddress ipHeal in ipHE.AddressList)
                        {
                            if (ipHeal.AddressFamily == AddressFamily.InterNetwork)
                                ipv4AddressOrHostName_resolved = ipHeal.ToString();
                        }
                        if (!string.IsNullOrEmpty(ipv4AddressOrHostName_resolved))
                        {
                            ipv4Address = IPAddress.Parse(ipv4AddressOrHostName_resolved);
                            port = 3027;
                            if (Heartbeat())
                                isOnline = true;
                        }
                    }
                    catch
                    {
                        ipv4Address = null;
                        isOnline = false;
                    }
                }
            }

            public void SetHostname(string p_ipv4AddressOrHostName)
            {
                hostName = p_ipv4AddressOrHostName;
                ResolveIpOrHostname(p_ipv4AddressOrHostName);
            }
            public virtual string Request(string p_request, bool responseExpected = true)
            {
                tcpClient = new TcpClient();

                tcpClient.Connect(ipv4Address, port);

                NetworkStream networkStream = tcpClient.GetStream();
                byte[] requestBytes = Encoding.UTF8.GetBytes(p_request);
                networkStream.Write(requestBytes, 0, requestBytes.Length);

                if (responseExpected)
                {
                    List<byte> responseBytesList = new List<byte>();
                    byte[] responseBuffer = new byte[1024];
                    int bytesRead;

                    do
                    {
                        bytesRead = networkStream.Read(responseBuffer, 0, responseBuffer.Length);
                        responseBytesList.AddRange(responseBuffer.Take(bytesRead));
                    } while (bytesRead == responseBuffer.Length);

                    string response = Encoding.UTF8.GetString(responseBytesList.ToArray());

                    tcpClient.Close();
                    return response;
                }
                tcpClient.Close();
                return "";
            }
            public virtual void Dispose()
            { 
                tcpClient.Close();
                isDisposed = true;
            }
            public Interface_TcpClient(string p_ipv4Address, int p_port)
            {
                if (p_ipv4Address == IPAddress.None.ToString())
                    hostName = "Hostname Unspecified";
                else
                    hostName = p_ipv4Address;

                HeartbeatAsync();
                isDisposed = false;
                port = p_port;
                isLoopback = false;
                ResolveIpOrHostname(p_ipv4Address);
            }
        }
        public class Interface_UdpClient : Interface_TcpClient
        {
            private UdpClient udpClient {  get; set; }

            public string Request(string p_request, bool p_responseExpected)
            {
                byte[] requestBytes = Encoding.UTF8.GetBytes(p_request);
                udpClient.Send(requestBytes, requestBytes.Length);

                if (p_responseExpected)
                {
                    IPEndPoint IpEndPoint = null;
                    byte[] responseBytes = udpClient.Receive(ref IpEndPoint);
                    string response = Encoding.UTF8.GetString(responseBytes);

                    return response;
                }
                return "";
            }
            public override void Dispose()
            {
                base.Dispose();
                udpClient.Close();
            }
            public Interface_UdpClient(string p_ipv4Address, int p_port)
                : base(p_ipv4Address, p_port)
            {
                udpClient = new UdpClient();
                udpClient.Connect(p_ipv4Address, p_port);
                if (p_ipv4Address == IPAddress.Broadcast.ToString())
                    udpClient.EnableBroadcast = true;
            }
        }
        public class Interface_Listener
        {
            protected readonly ILogger<Services.Service_Agent> logger;
            protected Services.Service_Agent agentWorker {  get; set; }
            public IPAddress ipv4Address { get; protected set; }
            public int port { get; protected set; }
            public bool isListening { get; protected set; }

            protected string ProcessData(string p_request)
            {
                return new Interface_RequestHandler(p_request, agentWorker).Response();
            }
            public Interface_Listener(Services.Service_Agent p_agentWorker, ILogger<Services.Service_Agent> p_logger, string p_ipv4Address, int p_port)
            {
                logger = p_logger;
                agentWorker = p_agentWorker;
                ipv4Address = IPAddress.Parse(p_ipv4Address);
                port = p_port;
                isListening = false;
            }
        }
        public class Interface_TcpListener : Interface_Listener
        {
            private TcpListener tcpListener {  get; set; }

            public void Response(TcpClient p_tcpClient)
            {
                NetworkStream networkStream = p_tcpClient.GetStream();

                List<byte> dataBytesList = new List<byte>();
                byte[] dataBuffer = new byte[1024];
                int bytesRead;

                do
                {
                    bytesRead = networkStream.Read(dataBuffer, 0, dataBuffer.Length);
                    dataBytesList.AddRange(dataBuffer.Take(bytesRead));
                } while (bytesRead == dataBuffer.Length);

                if (dataBytesList.Count > 0)
                {
                    string request = Encoding.UTF8.GetString(dataBytesList.ToArray());
                    logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] TCP Request Rx ({ipv4Address}:{port}): {request}");

                    var response = ProcessData(request);
                    if (!string.IsNullOrEmpty(response))
                    {
                        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                        networkStream.Write(responseBytes, 0, responseBytes.Length);
                        logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] TCP Response Tx ({ipv4Address}:{port}): {response}");
                    }
                }
            }
            public virtual async void StartListeningAsync()
            {
                tcpListener.Start();
                isListening = true;
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] TCP Listening: {ipv4Address}:{port}");

                while (isListening)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    Response(tcpClient);
                }
            }
            public virtual async void StopListeningAsync()
            {
                tcpListener.Stop();
                isListening = false;
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Stopped TCP Listening: {ipv4Address}:{port}");
            }
            public Interface_TcpListener(Services.Service_Agent p_agentWorker, ILogger<Services.Service_Agent> p_logger, string p_ipv4Address, int p_port)
                : base(p_agentWorker, p_logger, p_ipv4Address, p_port)
            {
                tcpListener = new TcpListener(ipv4Address, port);
            }
        }
        public class Interface_UdpListener : Interface_TcpListener
        {
            private UdpClient udpClient {  get; set; }

            public void Response(UdpReceiveResult p_udpReceiveResult)
            {
                string request = Encoding.UTF8.GetString(p_udpReceiveResult.Buffer);
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] UDP Request Rx ({p_udpReceiveResult.RemoteEndPoint}): {request}");

                string response = ProcessData(request);

                if (!string.IsNullOrEmpty(response))
                {
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    udpClient.Send(responseBytes, responseBytes.Length, p_udpReceiveResult.RemoteEndPoint);
                    logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] UDP Response Tx ({p_udpReceiveResult.RemoteEndPoint}): {response}");
                }
            }

            public override async void StartListeningAsync()
            {
                isListening = true;
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] UDP Listening: {ipv4Address}:{port}");

                while (isListening)
                {
                    UdpReceiveResult udpReceiveResult = await udpClient.ReceiveAsync();
                    Response(udpReceiveResult);
                }
            }
            public override async void StopListeningAsync()
            {
                udpClient.Close();
                isListening = false;
                logger.LogInformation($"[{DateTime.Now.ToString("yyyy-MM-dd @ HH:mm:ss")}] Stopped UDP Listening: {ipv4Address}:{port}");
            }
            public Interface_UdpListener(Services.Service_Agent p_agentWorker, ILogger<Services.Service_Agent> p_logger, string p_ipv4Address, int p_port)
                : base(p_agentWorker, p_logger, p_ipv4Address, p_port)
            {
                udpClient = new UdpClient(port);
            }
        }
        public class Interface_RequestHandler
        {
            private Services.Service_Agent agentWorker {  get; set; }
            private string request {  get; set; }
            private string command { get; set; }
            private string argument { get; set; }

            public void SetCommand()
            {
                int slashIndex = request.IndexOf('/');
                int spaceIndex = request.IndexOf(' ');

                if (slashIndex != -1 && spaceIndex != -1)
                    command = request.Substring(slashIndex, spaceIndex - slashIndex).TrimEnd(' ') ;
                else if (slashIndex != 1)
                    command = request;
            }
            private void SetArgument()
            {
                int spaceIndex = request.IndexOf(' ');

                if (spaceIndex != -1)
                    argument = request.Substring(spaceIndex + 1);
            }
            private string CommandHandler()
            {
                switch (command.ToLower())
                {
                    case "/heartbeat":
                        return "iloveyou";
                    case "/sysinfo":
                        return ArgumentHandler_SysInfo();
                    case "/sysserv":
                        return ArgumentHandler_SysServ();
                    case "/broadcast":
                        ArgumentHandler_Broadcast();
                        return "";
                    default:
                        return "Invalid Command";
                }
            }
            private string ArgumentHandler_SysInfo()
            {
                switch (argument.ToLower())
                {
                    case "-thispc":
                        return JsonConvert.SerializeObject(agentWorker.systemInfo_ThisPC);
                    default:
                        return "Invalid Request";
                }
            }
            private string ArgumentHandler_SysServ()
            {
                switch (argument.ToLower())
                {
                    case "-crowdstrike":
                        return JsonConvert.SerializeObject(agentWorker.systemService_Crowdstrike);
                    case "-dameware":
                        return JsonConvert.SerializeObject(agentWorker.systemService_Dameware);
                    case "-teamviewer":
                        return JsonConvert.SerializeObject(agentWorker.systemService_Teamviewer);
                    case "-zscaler":
                        return JsonConvert.SerializeObject(agentWorker.systemService_Zscaler);
                    case "-mimecast":
                        return JsonConvert.SerializeObject(agentWorker.systemService_Mimecast);
                    case "-snowinventoryagent":
                        return JsonConvert.SerializeObject(agentWorker.systemService_SnowInventoryAgent);
                    case "-msoffice365":
                        return JsonConvert.SerializeObject(agentWorker.systemService_MsOffice365);
                    case "-msteams":
                        return JsonConvert.SerializeObject(agentWorker.systemService_MsTeams);
                    case "-arcticwolf":
                        return JsonConvert.SerializeObject(agentWorker.systemService_ArcticWolf);
                    default:
                        return "Invalid Argument";
                }
            }
            private void ArgumentHandler_Broadcast()
            {
                new Tool_BroadcastNotification.NotificationMessage_Controller(argument).DisplayToastNotification();
            }
            public string Response()
            {
                return CommandHandler();
            }

            public Interface_RequestHandler(string p_request, Services.Service_Agent p_agentWorker)
            {
                agentWorker = p_agentWorker;
                request = p_request;

                SetCommand();
                SetArgument();
            }
        }
    }
    namespace Systems
    {
        public class SystemInfo_Base
        {
            public string userName { get; set; }
            public string hostName { get; set; }
            public string domainName { get; set; }
            public string ipv4Address { get; set; }
            public string subnetMask { get; set; }
            public string lanMacAddress { get; set; }
            public string wlanMacAddress { get; set; }
            public string logonServer { get; set; }
            public string os { get; set; }
            public string osPlatform { get; set; }
            public string winVer { get; set; }
            public string manufacturer { get; set; }
            public string model { get; set; }
            public string uptime { get; set; }
            public string buildDate { get; set; }

            public SystemInfo_Base()
            {
            }
        }
        public class SystemService_Base
        {
            public string serviceName { get; set; }
            public string[] serviceDirectoryCollection { get; set; }
            public string[] serviceProcessCollection { get; set; }
            public bool isInstalled { get; set; }
            public bool isRunning { get; set; }

            public SystemService_Base()
            {
            }
        }
        public class SystemInfo_Controller : SystemInfo_Base
        {
            private string GetUserName()
            {
                return Environment.UserName ?? "Not Detected!";
            }
            private string GetHostName()
            {
                return System.Net.Dns.GetHostName() ?? "Not Detected!";
            }
            private string GetDomainName()
            {
                return Environment.UserDomainName ?? "Not Detected!";
            }
            private string GetIPv4Address()
            {
                string ipv4Address = "";
                IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);

                foreach (IPAddress ipHeal in ipHostEntry.AddressList)
                {
                    if (ipHeal.AddressFamily == AddressFamily.InterNetwork)
                        ipv4Address = ipHeal.ToString();
                }

                return string.IsNullOrEmpty(ipv4Address) ? "Not Detected!" : ipv4Address;
            }
            private string GetSubnetMask()
            {
                NetworkInterface[] networkInterfaceCollection = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaceCollection)
                {
                    IPInterfaceProperties ipAddressProperties = networkInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in ipAddressProperties.UnicastAddresses)
                    {
                        if (unicastIPAddressInformation.Address.ToString() == ipv4Address)
                        {
                            return unicastIPAddressInformation.IPv4Mask.ToString();
                        }
                    }
                }

                return "Not Detected!";
            }
            private string GetMACAddress(NetworkInterfaceType p_interfaceType)
            {
                NetworkInterface[] networkInterfaceCollection = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaceCollection)
                {
                    if (networkInterface.NetworkInterfaceType == p_interfaceType &&
                        !networkInterface.Description.ToLowerInvariant().Contains("virtual") &&
                        !networkInterface.Description.ToLowerInvariant().Contains("pseudo"))
                    {
                        PhysicalAddress macAddress = networkInterface.GetPhysicalAddress();
                        byte[] bytes = macAddress.GetAddressBytes();

                        return string.Join(":", bytes.Select(b => b.ToString("X2")));
                    }
                }

                return "Not Detected!";
            }
            private string GetLogonServer()
            {
                return Environment.GetEnvironmentVariable("LOGONSERVER")?.Replace("\\", "") ?? "Not Detected!";
            }
            private string GetOS()
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");

                foreach (ManagementObject os in managementObjectSearcher.Get())
                {
                    return os["Caption"].ToString();
                }

                return "Not Detected!";
            }
            private string GetOSPlatform()
            {
                return Environment.Is64BitOperatingSystem ? "64-Bit" : "32-Bit";
            }
            private string GetWinVer()
            {
                return Environment.OSVersion.Version.Build.ToString();
            }
            private string GetDeviceManufactureAndModel(string p_propertyName)
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectCollection ManagementObjectSearcher_managementObjectCollection = managementObjectSearcher.Get();

                foreach (ManagementObject baseObject in ManagementObjectSearcher_managementObjectCollection)
                {
                    if (baseObject[p_propertyName] != null)
                    {
                        return baseObject[p_propertyName].ToString();
                    }
                }

                return "Not Detected!";
            }
            private string GetUptime()
            {
                TimeSpan systemUptime = TimeSpan.FromMilliseconds(Environment.TickCount);
                return ($"{systemUptime.Days}D, " + $"{systemUptime.Hours}H, " + $"{systemUptime.Minutes}M, " + $"{systemUptime.Seconds}S");
            }
            private string GetBuildDate()
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection ManagementObjectSearcher_managementObjectCollection = managementObjectSearcher.Get();

                foreach (ManagementObject baseObject in ManagementObjectSearcher_managementObjectCollection)
                {
                    string installDate = baseObject["InstallDate"].ToString();

                    int year = int.Parse(installDate.Substring(0, 4));
                    int month = int.Parse(installDate.Substring(4, 2));
                    int day = int.Parse(installDate.Substring(6, 2));

                    DateTime buildDate = new DateTime(year, month, day);

                    return buildDate.ToString("dd/MM/yyyy");
                }

                return "Not Detected";
            }
            private void Init_NetworkInfo()
            {
                userName = GetUserName();
                hostName = GetHostName();
                domainName = GetDomainName();
                ipv4Address = GetIPv4Address();
                subnetMask = GetSubnetMask();
                lanMacAddress = GetMACAddress(NetworkInterfaceType.Ethernet);
                wlanMacAddress = GetMACAddress(NetworkInterfaceType.Wireless80211);
                logonServer = GetLogonServer();
            }
            private void Init_OperatingSystemInfo()
            {
                os = GetOS();
                osPlatform = GetOSPlatform();
                winVer = GetWinVer();
            }
            private void Init_DeviceInfo()
            {
                manufacturer = GetDeviceManufactureAndModel("Manufacturer");
                model = GetDeviceManufactureAndModel("Model");
                uptime = GetUptime();
                buildDate = GetBuildDate();
            }

            public void Refresh()
            {
                Init();
            }
            public void Init()
            {
                Init_NetworkInfo();
                Init_OperatingSystemInfo();
                Init_DeviceInfo();
            }

            public SystemInfo_Controller()
            {
                Init();
            }
        }
        public class SystemService_Controller : SystemService_Base
        {
            private void VerifyInstall()
            {
                foreach (var serviceDirectory in serviceDirectoryCollection)
                {
                    if (Directory.Exists(serviceDirectory))
                    {
                        isInstalled = true;
                        return;
                    }
                }
                isInstalled = false;
            }
            private void VerifyRunning()
            {
                isRunning = false;

                if (serviceProcessCollection != null)
                {
                    foreach (var serviceProcess in serviceProcessCollection)
                    {
                        try
                        {
                            ServiceController serviceController = new ServiceController(serviceProcess);
                            if (serviceController.Status == ServiceControllerStatus.Running)
                            {
                                isRunning = true;
                                return;
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            // Service not installed or not accessible
                        }
                    }
                }
            }
            private void Init_SystemService()
            {
                VerifyInstall();
                VerifyRunning();
            }

            public void Init()
            {
                Init_SystemService();
            }
            public SystemService_Controller(string p_serviceName, string[] p_serviceDirectoriesCollection, string[] p_serviceProcessesCollection = null)
            {
                serviceName = p_serviceName;
                serviceDirectoryCollection = p_serviceDirectoriesCollection;
                serviceProcessCollection = p_serviceProcessesCollection;

                Init();
            }
        }
    }
    namespace Tools
    {
        public class Tool_Base
        {
            public string toolName { get; set; }
            protected string toolPath { get; set; }
            protected string[] toolPathCollection_toVerify { get; set; }
            protected bool toolPath_isPresent { get; set; }
            protected bool toolWaitForExit { get; set; }
            protected Process toolProc { get; set; } = new Process();

            private void Init()
            {
                Init_Tool();
            }

            protected bool LaunchTool_Failed()
            {
                if (!toolPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Unsuccessful:\nVerify Install File(s) Integrity", "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                return false;
            }
            protected void VerifyToolPath()
            {
                if (toolPathCollection_toVerify == null)
                    return;

                foreach (var path in toolPathCollection_toVerify)
                {
                    if (File.Exists(path))
                    {
                        toolPath = path;
                        toolPath_isPresent = true;
                        return;
                    }
                }
                toolPath_isPresent = false;
                return;
            }
            protected void Init_Tool()
            {
                VerifyToolPath();
            }
            protected void Init_ToolProcess()
            {
                toolProc.StartInfo.FileName = toolPath;
                toolProc.StartInfo.UseShellExecute = false;
                toolProc.StartInfo.CreateNoWindow = true;
                toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }

            public async Task<bool> LaunchToolAsync(UIControllers.UIController_ProgressBar p_progressBar)
            {
                if (toolPath_isPresent)
                {
                    p_progressBar.Update("Initialising process", 25);
                    Init_ToolProcess();

                    p_progressBar.Update("Starting process", 50);
                    await Task.Run(() => toolProc.Start());

                    p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    await Task.Run(() => toolProc.WaitForExit());

                    if (toolProc.ExitCode == 0)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Unsuccessful:\n(Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }

                p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }
            public Tool_Base(string p_toolName, string[] p_toolPath_toVerify, bool p_toolWaitForExit = true)
            {
                toolName = p_toolName;
                toolPathCollection_toVerify = p_toolPath_toVerify;
                toolWaitForExit = p_toolWaitForExit;

                Init();
            }
        }
        public class Tool_CMD : Tool_Base
        {
            protected string toolWorkingPath { get; set; }
            protected string toolArguments { get; set; }
            protected bool toolWorkingPath_isPresent { get; set; }

            private void Init()
            {
                Init_Tool();
            }

            protected void Init_Tool()
            {
                VerifyToolWorkingPath();
            }
            protected void Init_ToolProcess(bool p_shellExecuteVisible = false)
            {
                //Launch with shell, if toolArguments and toolWorkingPath are set
                if (p_shellExecuteVisible && ((toolArguments != null) || (toolWorkingPath != null)))
                {
                    toolProc.StartInfo.UseShellExecute = false;
                    toolProc.StartInfo.CreateNoWindow = false;
                    toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    toolProc.StartInfo.RedirectStandardInput = true;

                    toolProc.StartInfo.FileName = toolPath;
                    toolProc.StartInfo.WorkingDirectory = toolWorkingPath;
                }
                //Launch without shell, if toolArguments and toolWorkingPath are set
                else if (!p_shellExecuteVisible && ((toolArguments != null) || (toolWorkingPath != null)))
                {
                    toolProc.StartInfo.UseShellExecute = false;
                    toolProc.StartInfo.CreateNoWindow = true;
                    toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    toolProc.StartInfo.RedirectStandardInput = true;

                    toolProc.StartInfo.FileName = toolPath;
                    toolProc.StartInfo.WorkingDirectory = toolWorkingPath;
                }
            }
            protected bool LaunchTool_Failed()
            {
                if (!toolPath_isPresent && !toolWorkingPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Unsuccessful: Verify Install File(s) Integrity and Working Path", "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                else if (!toolPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Unsuccessful:\nVerify Install File(s) Integrity", "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                else if (!toolWorkingPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Unsuccessful:\nVerify Working Path", "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                return false;
            }
            protected void VerifyToolWorkingPath()
            {
                if (toolWorkingPath != null)
                {
                    if (File.Exists(toolWorkingPath))
                    {
                        toolWorkingPath_isPresent = true;
                        return;
                    }
                }
                toolWorkingPath_isPresent = true;
                return;
            }

            public bool LaunchTool(bool p_shellExecuteVisible)
            {
                if (toolPath_isPresent && toolWorkingPath_isPresent)
                {
                    Init_ToolProcess(p_shellExecuteVisible);
                    toolProc.Start();

                    toolProc.StandardInput.WriteLine(toolArguments);
                    toolProc.StandardInput.Close();

                    if (!toolWaitForExit)
                        return true;

                    toolProc.WaitForExit();

                    if (toolProc.ExitCode == 0)
                    {
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Unsuccessful:\n(Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    toolProc.Close();
                    return false;
                }
                return LaunchTool_Failed();
            }
            public async Task<bool> LaunchToolAsync(UIControllers.UIController_ProgressBar p_progressBar, bool p_shellExecuteVisible)
            {
                if (toolPath_isPresent && toolWorkingPath_isPresent)
                {
                    p_progressBar.Update("Initialising process", 25);
                    Init_ToolProcess(p_shellExecuteVisible);

                    p_progressBar.Update("Starting process", 50);
                    await Task.Run(() => toolProc.Start());

                    toolProc.StandardInput.WriteLine(toolArguments);
                    toolProc.StandardInput.Close();

                    p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    await Task.Run(() => toolProc.WaitForExit());

                    if (toolProc.ExitCode == 0)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Unsuccessful:\n(Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }
                p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }
            public Tool_CMD(string p_toolName, string[] p_toolPath_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)
                : base(p_toolName, p_toolPath_toVerify, p_toolWaitForExit)
            {
                toolWorkingPath = p_toolWorkingPath;
                toolArguments = p_toolArguments;

                Init();
            }
        }
        public class Tool_VBS : Tool_CMD
        {
            private void Init()
            {
                Init_Tool();
            }

            protected void Init_ToolProcess(bool p_shellExecuteVisible)
            {
                //Launch with shell, if toolArguments and toolWorkingPath are set
                if (p_shellExecuteVisible && ((toolArguments != null) || (toolWorkingPath != null)))
                {
                    toolProc.StartInfo.UseShellExecute = true;
                    toolProc.StartInfo.CreateNoWindow = false;
                    toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                    toolProc.StartInfo.FileName = toolPath;
                    toolProc.StartInfo.WorkingDirectory = toolWorkingPath;

                    //Argument value '1' = Visible cmd window launched via VB Script
                    toolProc.StartInfo.Arguments = toolArguments + ' ' + 1;
                }
                //Launch without shell, if toolArguments and toolWorkingPath are set
                else if (!p_shellExecuteVisible && ((toolArguments != null) || (toolWorkingPath != null)))
                {
                    toolProc.StartInfo.UseShellExecute = false;
                    toolProc.StartInfo.CreateNoWindow = true;
                    toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    toolProc.StartInfo.FileName = toolPath;
                    toolProc.StartInfo.WorkingDirectory = toolWorkingPath;

                    //Argument value '0' = Hidden cmd window launched via VB Script
                    toolProc.StartInfo.Arguments = toolArguments + ' ' + 0;
                }
            }

            public async Task<bool> LaunchToolAsync(UIControllers.UIController_ProgressBar p_progressBar, bool p_shellExecuteVisible)
            {
                if (toolPath_isPresent && toolWorkingPath_isPresent)
                {
                    p_progressBar.Update("Initialising process", 25);
                    Init_ToolProcess(p_shellExecuteVisible);

                    p_progressBar.Update("Starting process", 50);
                    await Task.Run(() => toolProc.Start());

                    p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    await Task.Run(() => toolProc.WaitForExit());

                    if (toolProc.ExitCode == 0)
                    {
                        p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Unsuccessful:\n(Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }

                p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }
            public Tool_VBS(string p_toolName, string[] p_toolPath_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)
                : base(p_toolName, p_toolPath_toVerify, p_toolWorkingPath, p_toolArguments, p_toolWaitForExit)
            {
                Init();
            }
        }
        public class Tool_PrinterInstall
        {
            public string printerShare { get; private set; }
            public List<string> printerCollection { get; private set; }

            public void Init()
            {
                SetPrinterCollection();
                PrinterCollection_ParseNames();
            }
            private void SetPrinterCollection()
            {
                string getPrinterCollection_cmd = $"net view {printerShare} | findstr /i \"print\"";

                Process toolProc = new Process();

                toolProc.StartInfo.FileName = "cmd.exe";
                toolProc.StartInfo.RedirectStandardInput = true;
                toolProc.StartInfo.RedirectStandardOutput = true;
                toolProc.StartInfo.UseShellExecute = false;
                toolProc.StartInfo.CreateNoWindow = true;

                toolProc.Start();
                toolProc.StandardInput.WriteLine(getPrinterCollection_cmd);
                toolProc.StandardInput.WriteLine("exit");

                List<string> OutputStream_ToIgnore = new List<string> { getPrinterCollection_cmd, "Microsoft Windows [Version", "(c) Microsoft Corporation. All rights reserved.", ">exit" };
                while (!toolProc.StandardOutput.EndOfStream)
                {
                    string line = toolProc.StandardOutput.ReadLine().Trim();
                    if (!string.IsNullOrWhiteSpace(line) && !OutputStream_ToIgnore.Any(line.Contains))
                    {
                        printerCollection.Add(line);
                    }
                }

                toolProc.WaitForExit();
                toolProc.Close();
            }
            private void PrinterCollection_ParseNames()
            {
                for (int counter = 0; counter < printerCollection.Count; counter++)
                {
                    int index = printerCollection[counter].IndexOf("  ");

                    if (index >= 0)
                        printerCollection[counter] = printerCollection[counter].Substring(0, index);
                }
            }

            public bool Install(string p_printerCollection, bool p_shellExecuteVisible = false)
            {
                Tool_CMD printerInstall = new Tool_CMD(
                    "Printer Installer",
                    new string[] { "C:\\Windows\\System32\\cmd.exe" },
                    ".\\Scripts", $"Printer_Install.bat {printerShare} {p_printerCollection}");
                return printerInstall.LaunchTool(p_shellExecuteVisible);
            }
            public Tool_PrinterInstall(string p_printerShare)
            {
                printerShare = p_printerShare;
                printerCollection = new List<string>();
            }
        }
        public static class Tool_BroadcastNotification
        {
            public class NotificationMessage_Base
            {
                public string title { get; set; }
                public string classification { get; set; }
                public string message { get; set; }

                public NotificationMessage_Base(string p_title, string p_classification, string p_message)
                {
                    title = p_title;
                    classification = p_classification;
                    message = p_message;
                }
            }
            public class NotificationMessage_Controller : NotificationMessage_Base
            {
                public void DisplayToastNotification()
                {
                    new ToastContentBuilder()
                        .AddText(title)
                        .AddText(classification)
                        .AddText(message)
                        .Show();
                }
                public NotificationMessage_Controller(string p_notificationMessage_Base_ObjAsJson, string p_title = "Title", string p_classification = "Classification", string p_message = "Message")
                    : base(p_title, p_classification, p_message)
                {
                    JsonConvert.PopulateObject(p_notificationMessage_Base_ObjAsJson, this);
                }
            }
        }
    }
    namespace UIControllers
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
                Components.Core.Wait(1000);
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
}