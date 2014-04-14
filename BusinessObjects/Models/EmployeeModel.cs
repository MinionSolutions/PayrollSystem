using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll.BusinessObjects.Enums;

namespace Payroll.BusinessObjects.Models
{
    /// <summary>
    /// Employee Model
    /// </summary>
    [Serializable]
    public class EmployeeModel
    {
        #region Properties
        /// <summary>
        /// Employee Id
        /// </summary>
        public string empId { get; set; }
        /// <summary>
        /// Employee Last Name
        /// </summary>
        public string empLName { get; set; }
        /// <summary>
        /// Employee First Name
        /// </summary>
        public string empFName { get; set; }
        /// <summary>
        /// Employee Middle Name
        /// </summary>
        public string empMName { get; set; }
        /// <summary>
        /// Employee Email Address
        /// </summary>
        public string empEmail { get; set; }
        /// <summary>
        /// Employee Religion
        /// </summary>
        public string empReligion { get; set; }
        /// <summary>
        /// Employee Birth Day
        /// </summary>
        public DateTime empBirthdate { get; set; }
        /// <summary>
        /// Employee Gender
        /// </summary>
        public string empGender { get; set; }
        /// <summary>
        /// Employee Civil Status
        /// </summary>
        public string empCivilStatus { get; set; }
        /// <summary>
        /// Employee Birth Place
        /// </summary>
        public string empBirthPlace { get; set; }
        /// <summary>
        /// Employee Citizenship
        /// </summary>
        public string empCitizenship { get; set; }
        /// <summary>
        /// Employee Contact Number
        /// </summary>
        public string empContactNumber { get; set; }
        /// <summary>
        /// Employee Company 
        /// </summary>
        public string empCompany { get; set; }
        /// <summary>
        /// Employee Position
        /// </summary>
        public string empPosition { get; set; }
        /// <summary>
        /// Employee Department Code
        /// </summary>
        public int empDeptCode { get; set; }
        /// <summary>
        /// Employee PABIBIG Number
        /// </summary>
        public string empPagibigNumber { get; set; }
        /// <summary>
        /// Employee SSS Number
        /// </summary>
        public string empSSSNumber { get; set; }
        /// <summary>
        /// Employee PhilHealth Number
        /// </summary>
        public string empPHNumber { get; set; }
        /// <summary>
        /// Employee TIN Number
        /// </summary>
        public string empTINNumber { get; set; }
        /// <summary>
        /// Employee Created By
        /// </summary>
        public string empCreatedBy { get; set; }
        /// <summary>
        /// Employee Last Modified By
        /// </summary>
        public string empLastModifiedBy { get; set; }
        /// <summary>
        /// Employee Creation Date
        /// </summary>
        public DateTime empDateCreated { get; set; }
        /// <summary>
        /// Employee Modified Date
        /// </summary>
        public DateTime empDateLastModified { get; set; }
        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        /// <value>
        /// The department.
        /// </value>
        public string empDepartment { get; set; }
        /// <summary>
        /// Gets or sets the tax status.
        /// </summary>
        /// <value>
        /// The tax status.
        /// </value>
        public string empTaxStatus { get; set; }
        /// <summary>
        /// Gets or sets the emp salary.
        /// </summary>
        /// <value>
        /// The emp salary.
        /// </value>
        public double empSalary { get; set; }


        #endregion

        #region Payslip Report
        public string PayPeriod { get; set; }
        public int WorkDays { get; set; }
        public int WorkHours { get; set; }
        public double AdditionalSalary { get; set; }
        public double SalaryDeduction { get; set; }
        public double GrossSalary { get; set; }
        public double NetSalary { get; set; }
        public double RegularHoliday { get; set; }
        public double SpecialNonWorkingHoliday { get; set; }
        public double NightDifferential { get; set; }
        public double RestDay { get; set; }
        public double Allowance { get; set; }
        public double Incentives { get; set; }
        public double DeminimisBenifit { get; set; }
        public double TransportationAllowance { get; set; }
        public double AdditionalAdjustment { get; set; }
        public double Late { get; set; }
        public double Absences { get; set; }
        public int Undertime { get; set; }
        public double SSS { get; set; }
        public double Philhealth { get; set; }
        public double Pagibig { get; set; }
        public double taxAmount { get; set; }
        public double LessAdjustment { get; set; }
        #endregion
    }
}
