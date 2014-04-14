using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using Payroll.BusinessObjects;


namespace Payroll.Utilities
{
    public class PayrollLogger
    {
        #region Properties
            public static string logpath = string.Empty;
        #endregion
       

        public static void Initialize(string loggerpath = "") {
            if (string.IsNullOrEmpty(loggerpath)) {
                logpath = (!string.IsNullOrEmpty(loggerpath)) ? loggerpath : Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/logger.txt";
            }
        }
        public static void Log(string message, int type) { 
        
            
        }
    }
}
