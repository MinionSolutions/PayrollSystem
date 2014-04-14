using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Payroll.BusinessObjects.Enums;
using Payroll.Utilities;
using Payroll.BusinessObjects.Models;

namespace Payroll.DataAccessLayer
{
    public class EmployeeDAL
    {
        #region Public Methods
        public static int generateEmployeeId() {
            int employeenumber = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollSystem.Properties.Settings.HRISConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[generateEmployeeId]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    employeenumber = (int)cmd.ExecuteScalar();
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (SqlException se) {
                PayrollLogger.Log(se.ToString(), (int)LogType.Error);

            }
            return employeenumber;
        }
        public static List<string> getEmployeeName()
        {
            List<string> employeenames = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollSystem.Properties.Settings.HRISConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[dbo].[getEmployeeNames]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    employeenames = ParseGetNames(cmd.ExecuteReader());
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (SqlException se)
            {
                PayrollLogger.Log(se.ToString(), (int)LogType.Error);

            }

            return employeenames;
        }
        public static List<EmployeeModel> getEmployeeNameByDepartment(string department)
        {
            List<EmployeeModel> employeenames = new List<EmployeeModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollSystem.Properties.Settings.HRISConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[Payroll].[getEmployeeNamesByDepartment]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@department", department);
                    employeenames = ParseGetNameByDepartment(cmd.ExecuteReader());
                    cmd.Dispose();
                    conn.Close();
                }
            }
            catch (SqlException se)
            {
                PayrollLogger.Log(se.ToString(), (int)LogType.Error);

            }

            return employeenames;
        }
        #endregion

        #region Private Methods
        private static string ParseRow(object p)
        {
            return Convert.ToString(p);
        }
        /// <summary>
        /// Parses the row.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private static List<string> ParseGetNames(SqlDataReader sqlDataReader)
        {
            List<string> employeenames = new List<string>();

            while (sqlDataReader.Read()) { 
                employeenames.Add(sqlDataReader.GetString(0));
            }

            return employeenames;
        }
        private static List<EmployeeModel> ParseGetNameByDepartment(SqlDataReader reader)
        {
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();

            while (reader.Read())
            {
                try
                {
                    EmployeeModel em = new EmployeeModel();
                    em.empId = Convert.ToString(reader["id"]);
                    em.empLName = Convert.ToString(reader["lastName"]);
                    em.empFName = Convert.ToString(reader["firstName"]);
                    em.empMName = Convert.ToString(reader["middleName"]);
                    em.empEmail = Convert.ToString(reader["email"]);
                    em.empDepartment = Convert.ToString(reader["departmentName"]);
                    em.empPosition = Convert.ToString(reader["position"]);
                    em.empTaxStatus = Convert.ToString(reader["taxStatus"]);
                    em.empSalary = Convert.ToDouble(reader["salary"]);
                    employeeModels.Add(em); 
                }
                catch
                { continue; }
            }

            return employeeModels;
        }


        #endregion




        
    }
}
