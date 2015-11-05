using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace CSRAssistant
{
    static class Program
    {

        static bool IsRunAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                if (!IsRunAsAdmin())
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.UseShellExecute = true;
                    proc.WorkingDirectory = Environment.CurrentDirectory;
                    proc.FileName = Application.ExecutablePath;
                    proc.Verb = "runas";

                    try
                    {
                        Process.Start(proc);
                    }
                    catch
                    {
                        // The user refused the elevation.
                        // Do nothing and return directly ...
                        return;
                    }

                    Application.Exit();  // Quit itself
                }
                else
                {
                    Application.Run(new frmMain());
                }
            }
            else
            {
                Application.Run(new frmMain());
            }
        }
    }
}
