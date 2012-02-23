using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace observador
{
    static class Program
    {
        public static string GetTitle()
        {
            Version version = new Version(Application.ProductVersion);
            return string.Format(
                Properties.Settings.Default.TitleFormat,
                Application.ProductName,
                version.Major,
                version.Minor);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashBoard());
        }
    }
}
