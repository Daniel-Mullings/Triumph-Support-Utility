using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TriumphSupportUtility.Tools;

namespace TriumphSupportUtility.Interfaces
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
        private UdpClient udpClient { get; set; }

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
        protected Services.Service_Agent agentWorker { get; set; }
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
        private TcpListener tcpListener { get; set; }

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
        private UdpClient udpClient { get; set; }

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
        private Services.Service_Agent agentWorker { get; set; }
        private string request { get; set; }
        private string command { get; set; }
        private string argument { get; set; }

        public void SetCommand()
        {
            int slashIndex = request.IndexOf('/');
            int spaceIndex = request.IndexOf(' ');

            if (slashIndex != -1 && spaceIndex != -1)
                command = request.Substring(slashIndex, spaceIndex - slashIndex).TrimEnd(' ');
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