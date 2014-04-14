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
        public void CreateEmployee(string empId, string empLName, string empFName, string empMName, DateTime empBDay, string empBPlace, string empGender, string empCNumber, string empReligion, string empCitizen, string empCivilStatus, string empEAdd, string empCompany, string empPosition, string empDepartment, double empBasicSalary, string empTaxCode, string empSSSNumber, string empPAGIBIGNo, string empPhilHealthNo, string empTINNo)
        {
            EmployeeModel empModel = new EmployeeModel();
            empModel.empId = empId;
            empModel.empLName = empLName;
            empModel.empFName = empFName;
            empModel.empMName = empMName;
            empModel.empBirthdate = empBDay;
            empModel.empBirthPlace = empBPlace;
            empModel.empGender = empGender;
            empModel.empContactNumber = empCNumber;
            empModel.empReligion = empReligion;
            empModel.empCitizenship = empCitizen;
            empModel.empCivilStatus = empCivilStatus;
            empModel.empEmail = empEAdd;
            empModel.empCompany = empCompany;
            empModel.empPosition = empPosition;
            empModel.empDepartment =empDepartment;
            empModel.empSalary = empBasicSalary;
            empModel.empTaxStatus = empTaxCode;
            empModel.empSSSNumber = empSSSNumber;
            empModel.empPagibigNumber = empPAGIBIGNo;
            empModel.empPHNumber = empPhilHealthNo;
            empModel.empTINNumber = empTINNo;

            EmployeeDAL.CreateEmployee(empModel);

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
