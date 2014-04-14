using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Payroll.Utilities;

namespace PayrollSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PayrollLogger.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPayroll());
            
        }
    }
}
