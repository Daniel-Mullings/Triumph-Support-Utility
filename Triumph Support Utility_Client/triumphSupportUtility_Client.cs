using System.Security.Principal;

namespace TriumphSupportUtility_Client
{
    internal static class TriumphSupportUtility_Client
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

            if ((new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)))
                Application.Run(new WinForm_AdminClient());
            else
                Application.Run(new WinForm_UserClient());
        }
    }
}