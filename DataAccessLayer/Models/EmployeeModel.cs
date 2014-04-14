using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll.DataAccessLayer.Model
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

        #endregion
    }
}
