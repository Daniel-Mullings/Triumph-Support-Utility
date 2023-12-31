using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.ServiceProcess;

namespace TriumphSupportUtility.Systems
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