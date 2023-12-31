using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.Forms;

namespace TriumphSupportUtility.Tools
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
        public Tool_Base(string p_toolName, string[] p_toolPathCollection_toVerify, bool p_toolWaitForExit = true)
        {
            toolName = p_toolName;
            toolPathCollection_toVerify = p_toolPathCollection_toVerify;
            toolWaitForExit = p_toolWaitForExit;

            Init();
        }
    }
    public class Tool_CMD : Tool_Base
    {
        protected string toolWorkingPath { get; set; }
        protected string toolArgument { get; set; }
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
            if (p_shellExecuteVisible && ((toolArgument != null) || (toolWorkingPath != null)))
            {
                toolProc.StartInfo.UseShellExecute = false;
                toolProc.StartInfo.CreateNoWindow = false;
                toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                toolProc.StartInfo.RedirectStandardInput = true;

                toolProc.StartInfo.FileName = toolPath;
                toolProc.StartInfo.WorkingDirectory = toolWorkingPath;
            }
            //Launch without shell, if toolArguments and toolWorkingPath are set
            else if (!p_shellExecuteVisible && ((toolArgument != null) || (toolWorkingPath != null)))
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

                toolProc.StandardInput.WriteLine(toolArgument);
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

                toolProc.StandardInput.WriteLine(toolArgument);
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
        public Tool_CMD(string p_toolName, string[] p_toolPathCollection_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)   
            : base(p_toolName, p_toolPathCollection_toVerify, p_toolWaitForExit)
        {
            toolWorkingPath = p_toolWorkingPath;
            toolArgument = p_toolArguments;

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
            if (p_shellExecuteVisible && ((toolArgument != null) || (toolWorkingPath != null)))
            {
                toolProc.StartInfo.UseShellExecute = true;
                toolProc.StartInfo.CreateNoWindow = false;
                toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                toolProc.StartInfo.FileName = toolPath;
                toolProc.StartInfo.WorkingDirectory = toolWorkingPath;

                //Argument value '1' = Visible cmd window launched via VB Script
                toolProc.StartInfo.Arguments = toolArgument + ' ' + 1;
            }
            //Launch without shell, if toolArguments and toolWorkingPath are set
            else if (!p_shellExecuteVisible && ((toolArgument != null) || (toolWorkingPath != null)))
            {
                toolProc.StartInfo.UseShellExecute = false;
                toolProc.StartInfo.CreateNoWindow = true;
                toolProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                toolProc.StartInfo.FileName = toolPath;
                toolProc.StartInfo.WorkingDirectory = toolWorkingPath;

                //Argument value '0' = Hidden cmd window launched via VB Script
                toolProc.StartInfo.Arguments = toolArgument + ' ' + 0;
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
        public Tool_VBS(string p_toolName, string[] p_toolPathCollection_toVerify, string p_toolWorkingPath, string p_toolArguments, bool p_toolWaitForExit = true)
            : base(p_toolName, p_toolPathCollection_toVerify, p_toolWorkingPath, p_toolArguments, p_toolWaitForExit)
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