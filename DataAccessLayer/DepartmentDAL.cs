using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Payroll.BusinessObjects.Models;
using Payroll.Utilities;

namespace Payroll.DataAccessLayer
{
   public class DepartmentDAL
   {

       #region Persistence

       /// <summary>
        /// Adds the specified department model.
        /// </summary>
        /// <param name="departmentModel">The department model.</param>
        /// <returns></returns>
       public static DepartmentModel Add(DepartmentModel departmentModel)
       {
           try
           {
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollSystem.Properties.Settings.HRISConnectionString"].ConnectionString))
               {
                   SqlTransaction transaction = null;
                   try
                   {
                       connection.Open();
                       transaction = connection.BeginTransaction();

                       using (SqlCommand command = new SqlCommand("[][]", connection, transaction))
                       {
                           command.CommandType = CommandType.StoredProcedure;
                           command.Parameters.AddRange(CreateParameters(departmentModel));

                           departmentModel.Id = Convert.ToInt32(command.ExecuteScalar());
                       }

                       transaction.Commit();
                   }
                   catch (Exception ex)
                   {
                       if (transaction != null)
                           transaction.Rollback();

                       throw ex;
                   }
                   finally
                   {
                       transaction.Dispose();
                   }
               }
           }
           catch (Exception ex)
           {
               PayrollLogger.Log(ex.Message, 0);
           }

           return departmentModel;
       }

       #endregion

       #region Factory Methods
       /// <summary>
       /// Gets the department models.
       /// </summary>
       /// <returns></returns>
       public static List<DepartmentModel> GetDepartmentModels()
       {
           List<DepartmentModel> departmentModels = new List<DepartmentModel>();

           try
           {
               using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PayrollSystem.Properties.Settings.HRISConnectionString"].ConnectionString))
               {
                   connection.Open();

                   using (SqlCommand command = new SqlCommand("[Payroll].[getAllDepartments]", connection))
                   {
                       command.CommandType = CommandType.StoredProcedure;
                       departmentModels.AddRange(ParseRow(command.ExecuteReader()));
                   }
               }
           }
           catch (Exception ex)
           {
               PayrollLogger.Log(ex.Message, 0);
           }

           return departmentModels;
       }
       /// <summary>
       /// Gets the department model by identifier.
       /// </summary>
       /// <param name="id">The identifier.</param>
       /// <returns></returns>
       #endregion

       #region Private Methods

       /// <summary>
       /// Parses the row.
       /// </summary>
       /// <param name="reader">The reader.</param>
       /// <returns></returns>
       private static List<DepartmentModel> ParseRow(SqlDataReader reader)
       {
           List<DepartmentModel> departmentModels = new List<DepartmentModel>();

           while (reader.Read())
           {
               try
               {
                   departmentModels.Add(new DepartmentModel(Convert.ToInt32(reader["id"]), 
                                                            Convert.ToString(reader["departmentName"])));
               }
               catch
               { continue; }
           }

           return departmentModels;
       }
       /// <summary>
       /// Creates the parameters.
       /// </summary>
       /// <returns></returns>
       private static SqlParameter[] CreateParameters(DepartmentModel departmentModel)
       {
           List<SqlParameter> parameters = new List<SqlParameter>();
           parameters.Add(new SqlParameter("@departmentName", departmentModel.DepartmentName));

           return parameters.ToArray();
       }

       #endregion
   }
}
