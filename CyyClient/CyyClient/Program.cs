using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Skybound.Gecko;

namespace CyyClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Xpcom.Initialize(System.Environment.CurrentDirectory + @"\config\xulrunner1.9");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CyyMain());
        }
    }
}
