using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.ServiceProcess;

namespace Triumph_Support_Utility
{
    internal static class triumphSupportUtility
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new WinForm_Main());
        }
    }
    public class Systems
    {
        public class SystemInfo_Base
        {
            public string username { get; private set; }
            public string hostname { get; private set; }
            public string domainName { get; private set; }
            public string ipv4Address { get; private set; }
            public string subnetMask { get; private set; }
            public string lanMacAddress { get; private set; }
            public string wlanMacAddress { get; private set; }
            public string logonServer { get; private set; }
            public string os { get; private set; }
            public string osPlatform { get; private set; }
            public string winVer { get; private set; }
            public string manufacturer { get; private set; }
            public string model { get; private set; }
            public string uptime { get; private set; }
            public string buildDate { get; private set; }

            public SystemInfo_Base()
            {
                Init();
            }
            public void Init()
            {
                InitNetworkInfo();
                InitOperatingSystemInfo();
                InitDeviceInfo();
            }

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
                IPHostEntry ipHE = Dns.GetHostEntry(hostname);

                foreach (IPAddress ipHeal in ipHE.AddressList)
                {
                    if (ipHeal.AddressFamily == AddressFamily.InterNetwork)
                        ipv4Address = ipHeal.ToString();
                }

                return string.IsNullOrEmpty(ipv4Address) ? "Not Detected!" : ipv4Address;
            }
            private string GetSubnetMask()
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    IPInterfaceProperties ipAddressProperties = networkInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation unicastIPAddressInfo in ipAddressProperties.UnicastAddresses)
                    {
                        if (unicastIPAddressInfo.Address.ToString() == ipv4Address)
                        {
                            return unicastIPAddressInfo.IPv4Mask.ToString();
                        }
                    }
                }

                return "Not Detected!";
            }
            private string GetMACAddress(NetworkInterfaceType p_interfaceType)
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface nic in networkInterfaces)
                {
                    if (nic.NetworkInterfaceType == p_interfaceType &&
                        !nic.Description.ToLowerInvariant().Contains("virtual") &&
                        !nic.Description.ToLowerInvariant().Contains("pseudo"))
                    {
                        PhysicalAddress macAddress = nic.GetPhysicalAddress();
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
                ManagementObjectSearcher mgmtObjSrch = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");

                foreach (ManagementObject os in mgmtObjSrch.Get())
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
                ManagementObjectSearcher mgmtObjSrch = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
                ManagementObjectCollection baseObjects = mgmtObjSrch.Get();

                foreach (ManagementObject baseObject in baseObjects)
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
                ManagementObjectSearcher mgmtObjSrch = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection baseObjects = mgmtObjSrch.Get();

                foreach (ManagementObject baseObject in baseObjects)
                {
                    string buildDate = baseObject["InstallDate"].ToString();

                    int year = int.Parse(buildDate.Substring(0, 4));
                    int month = int.Parse(buildDate.Substring(4, 2));
                    int day = int.Parse(buildDate.Substring(6, 2));

                    DateTime installDate = new DateTime(year, month, day);

                    return installDate.ToString("dd/MM/yyyy");
                }

                return "Not Detected";
            }
            private void InitNetworkInfo()
            {
                username = GetUserName();
                hostname = GetHostName();
                domainName = GetDomainName();
                ipv4Address = GetIPv4Address();
                subnetMask = GetSubnetMask();
                lanMacAddress = GetMACAddress(NetworkInterfaceType.Ethernet);
                wlanMacAddress = GetMACAddress(NetworkInterfaceType.Wireless80211);
                logonServer = GetLogonServer();
            }
            private void InitOperatingSystemInfo()
            {
                os = GetOS();
                osPlatform = GetOSPlatform();
                winVer = GetWinVer();
            }
            private void InitDeviceInfo()
            {
                manufacturer = GetDeviceManufactureAndModel("Manufacturer");
                model = GetDeviceManufactureAndModel("Model");
                uptime = GetUptime();
                buildDate = GetBuildDate();
            }
        }
        public class SystemService_Base
        {
            public string serviceName { get; private set; }
            protected string[] serviceDirectories;
            protected string[] serviceProcesses;
            protected bool isInstalled;
            protected bool isProcessRunning;

            public SystemService_Base(string p_serviceName, string[] p_serviceDirectories, string[] p_serviceProcesses = null)
            {
                serviceName = p_serviceName;
                serviceDirectories = p_serviceDirectories;
                serviceProcesses = p_serviceProcesses;

                Init();
            }
            public void Init()
            {
                InitSystemService();
            }
            public bool IsInstalled()
            {
                VerifyInstall();
                return isInstalled;
            }
            public bool IsRunning()
            {
                VerifyRunning();
                return isProcessRunning;
            }

            private void VerifyInstall()
            {
                foreach (var directory in serviceDirectories)
                {
                    if (Directory.Exists(directory))
                    {
                        isInstalled = true;
                        return;
                    }
                }
                isInstalled = false;
            }
            private void VerifyRunning()
            {
                isProcessRunning = false;

                if (serviceProcesses != null)
                {
                    foreach (var process in serviceProcesses)
                    {
                        try
                        {
                            ServiceController serviceController = new ServiceController(process);
                            if (serviceController.Status == ServiceControllerStatus.Running)
                            {
                                isProcessRunning = true;
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
            private void InitSystemService()
            {
                VerifyInstall();
                VerifyRunning();
            }
        }
    }
    public class Tools
    {
        public class Tool_Base
        {
            protected string toolName;
            protected string toolPath;
            protected string[] toolPath_toVerify;
            protected bool toolPath_isPresent;
            protected bool toolWaitForExit;
            protected Process toolProc = new Process();

            public Tool_Base(string p_toolName, string[] p_toolPath_toVerify, bool p_toolWaitForExit = true)
            {
                toolName = p_toolName;
                toolPath_toVerify = p_toolPath_toVerify;
                toolWaitForExit = p_toolWaitForExit;

                InitTool();
            }
            public async Task<bool> LaunchTool(UIControllers.UIController_ProgressBar p_progressBar)
            {
                if (toolPath_isPresent)
                {
                    await p_progressBar.Update("Initialising process", 25);
                    InitToolProcess();

                    await p_progressBar.Update("Starting process", 50);
                    toolProc.Start();

                    await p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    toolProc.WaitForExit();

                    if (toolProc.ExitCode == 0)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Failed: (Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    await p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }

                await p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }

            protected bool LaunchTool_Failed()
            {
                if (!toolPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Failed: Verify Install File(s) Integrity", "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                return false;
            }
            protected void VerifyToolPath()
            {
                foreach (var path in toolPath_toVerify)
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
            protected void InitTool()
            {
                VerifyToolPath();
            }
            protected void InitToolProcess()
            {
                toolProc.StartInfo.FileName = toolPath;
                toolProc.StartInfo.UseShellExecute = false;
                toolProc.StartInfo.CreateNoWindow = true;
                toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            }
        }
        public class Tool_CMD : Tool_Base
        {
            protected string toolWorkingPath;
            protected string toolArguments;
            protected bool toolWorkingPath_isPresent;

            public Tool_CMD(string p_toolName, string[] p_toolPath_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)
                : base(p_toolName, p_toolPath_toVerify, p_toolWaitForExit)
            {
                toolWorkingPath = p_toolWorkingPath;
                toolArguments = p_toolArguments;

                InitTool();
            }
            public async Task<bool> LaunchTool(UIControllers.UIController_ProgressBar p_progressBar, bool p_shellExecuteVisible)
            {
                if (toolPath_isPresent && toolWorkingPath_isPresent)
                {
                    await p_progressBar.Update("Initialising process", 25);
                    InitToolProcess(p_shellExecuteVisible);

                    await p_progressBar.Update("Starting process", 50);
                    toolProc.Start();

                    toolProc.StandardInput.WriteLine(toolArguments);
                    toolProc.StandardInput.Close();

                    await p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    toolProc.WaitForExit();

                    if (toolProc.ExitCode == 0)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Failed: (Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    await p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }
                await p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }

            protected bool LaunchTool_Failed()
            {
                if (!toolPath_isPresent && !toolWorkingPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Failed: Verify Install File(s) Integrity and Working Path", "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                else if (!toolPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Failed: Verify Install File(s) Integrity", "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolProc.Close();
                    return false;
                }
                else if (!toolWorkingPath_isPresent)
                {
                    MessageBox.Show(toolName + " Launch Failed, Verify Working Path", "Error: Launch Failed",
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
            protected void InitTool()
            {
                VerifyToolWorkingPath();
            }
            protected void InitToolProcess(bool p_shellExecuteVisible)
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
        }
        public class Tool_VBS : Tool_CMD
        {
            public Tool_VBS(string p_toolName, string[] p_toolPath_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)
                : base(p_toolName, p_toolPath_toVerify, p_toolWorkingPath, p_toolArguments, p_toolWaitForExit)
            {
                InitTool();
            }
            public async Task<bool> LaunchTool(UIControllers.UIController_ProgressBar p_progressBar, bool p_shellExecuteVisible)
            {
                if (toolPath_isPresent && toolWorkingPath_isPresent)
                {
                    await p_progressBar.Update("Initialising process", 25);
                    InitToolProcess(p_shellExecuteVisible);

                    await p_progressBar.Update("Starting process", 50);
                    toolProc.Start();

                    await p_progressBar.Update("Running process", 75);
                    if (!toolWaitForExit)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        return true;
                    }

                    toolProc.WaitForExit();

                    if (toolProc.ExitCode == 0)
                    {
                        await p_progressBar.Update("Finalising process", 100);
                        toolProc.Close();
                        return true;
                    }

                    MessageBox.Show(toolName + " Launch Failed: (Exit Code: " + toolProc.ExitCode + ')', "Error: Launch Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    await p_progressBar.Update("Finalising process", 100);
                    toolProc.Close();
                    return false;
                }

                await p_progressBar.Update("Finalising process", 100);
                return LaunchTool_Failed();
            }

            protected void InitToolProcess(bool p_shellExecuteVisible)
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
        }
    }
    public class UIControllers
    {
        public class UIController_Base()
        { 
            //Placeholder
        }
        public class UIController_ProgressBar
        {
            protected ProgressBar progressBar;
            protected Label progressBarPct;
            protected Label progressBarStatus;
            
            public UIController_ProgressBar(ProgressBar p_progressBar, Label p_progressBarPct, Label p_progressBarStatus)
            {
                progressBar = p_progressBar;
                progressBarPct = p_progressBarPct;
                progressBarStatus = p_progressBarStatus;

                Init();
            }
            public async Task Reset()
            {
                await Task.Delay(2000);
                Init();
            }
            public async Task Update(string p_progressStatus, int p_progressPercent)
            {
                UpdateStatus(p_progressStatus);
                UpdatePercent(p_progressPercent);
                await Task.Delay(2500);
            }
            public async Task Update(string p_progressStatus)
            {
                UpdateStatus(p_progressStatus);
                await Task.Delay(2500);
            }
            public async Task Update(int p_progressPercent)
            {
                UpdatePercent(p_progressPercent);
                await Task.Delay(2500);
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
                progressBarPct.Text = p_progressPercent.ToString() + " %";
            }
            protected void Init()
            {
                progressBar.Value = 0;
                progressBarPct.Text = "- %";
                progressBarStatus.Text = "Ready";
            }
        }
        public class UIController_Button
        {
            protected List<Button> uiButtons = new List<Button>();

            public UIController_Button(List<Button> p_uiButtons)
            {
                SetUIElementButtons(p_uiButtons);
            }
            public void SetUIElementButtons(List<Button> p_uiButtons)
            {
                uiButtons = p_uiButtons;
            }
            public void EnableUIElements()
            {
                foreach (Button uiButton in uiButtons)
                {
                    uiButton.Enabled = true;
                }
            }
            public void DisableUIElements()
            {
                foreach (Button uiButton in uiButtons)
                {
                    uiButton.Enabled = false;
                }
            }
        }
    }
}