using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TriumphSupportUtility.Services
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
        public Systems.SystemService_Controller systemService_ArcticWolf { get; set; }


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
                              "        Developed by: Daniel Mullings (On behalf of Triumph Motorcycles .Ltd)\n");
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
                TriumphSupportUtility.Core.Configuration.AgentConfiguration_Rebuild();
            config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
        }
        private void Init_Systems()
        {
            systemInfo_ThisPC = new Systems.SystemInfo_Controller();
            systemService_Crowdstrike = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:Crowdstrike:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Crowdstrike:serviceDirectoryCollection").Get<string[]>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Crowdstrike:serviceProcessCollection").Get<string[]>());
            systemService_Dameware = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:Dameware:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Dameware:serviceDirectoryCollection").Get<string[]>());
            systemService_Teamviewer = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:TeamViewer:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:TeamViewer:serviceDirectoryCollection").Get<string[]>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:TeamViewer:serviceProcessCollection").Get<string[]>());
            systemService_Zscaler = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:Zscaler:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Zscaler:serviceDirectoryCollection").Get<string[]>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Zscaler:serviceProcessCollection").Get<string[]>());
            systemService_Mimecast = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:Mimecast:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:Mimecast:serviceDirectoryCollection").Get<string[]>());
            systemService_SnowInventoryAgent = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:SnowInventoryAgent:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:SnowInventoryAgent:serviceDirectoryCollection").Get<string[]>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:SnowInventoryAgent:serviceProcessCollection").Get<string[]>());
            systemService_MsOffice365 = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:MsOffice365:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:MsOffice365:serviceDirectoryCollection").Get<string[]>());
            systemService_MsTeams = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:MsTeams:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:MsTeams:serviceDirectoryCollection").Get<string[]>());
            systemService_ArcticWolf = new Systems.SystemService_Controller(
                config.GetSection("ProgramSettings:SystemServiceParameters:ArcticWolf:Name").Get<string>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:ArcticWolf:serviceDirectoryCollection").Get<string[]>(),
                config.GetSection("ProgramSettings:SystemServiceParameters:ArcticWolf:serviceProcessCollection").Get<string[]>());

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
            agentController_TcpListener = new Interfaces.Interface_TcpListener(this, logger, IPAddress.Any.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:TcpPort").Get<int>());
            agentController_UdpListener = new Interfaces.Interface_UdpListener(this, logger, IPAddress.Any.ToString(), config.GetSection("ProgramSettings:ConnectionParameters:UdpPort").Get<int>());
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