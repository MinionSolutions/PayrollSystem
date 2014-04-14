using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll.BaseClass;
using Payroll.DataAccessLayer;
using Payroll.BusinessObjects.Models;

namespace Payroll.BusinessLogicLayer
{
    /// <summary>
    /// Employee Class
    /// </summary>
    [Serializable]
    public class Employee : Base
    {
        #region Properties
        private string empId { get; set; }
        #endregion

        #region Public Methods
        public static string generateEmployeeId() {
            string employeeid = string.Empty;
            int sequence;

            sequence = EmployeeDAL.generateEmployeeId();


          
            return generateEmployeeNumber(sequence);

        }
        public void CreateEmployee() { 
            
        }
        public static List<string> getEmployeeNames() 
        {
            return EmployeeDAL.getEmployeeName(); 
        }
        public static List<EmployeeModel> getEmployeeNamesByDepartment(string department)
        {
            return EmployeeDAL.getEmployeeNameByDepartment(department);
        }      
        #endregion

        #region Private Methods
        private static string generateEmployeeNumber(int sequence)
        {
            string employeeid = string.Empty;
            string idprefix = string.Empty;

            //idprefix = Configuratio
            return employeeid;

        }
        

        #endregion
       
    }
}
