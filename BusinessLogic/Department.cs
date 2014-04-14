using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Payroll.DataAccessLayer;
using Payroll.BusinessObjects.Models;

namespace Payroll.BusinessLogicLayer
{
    [Serializable]
    public class Department
    {
        /// <summary>
        /// Adds the specified department model.
        /// </summary>
        /// <param name="departmentModel">The department model.</param>
        /// <returns></returns>
        public static DepartmentModel Add(DepartmentModel departmentModel)
        {
            return DepartmentDAL.Add(departmentModel);
        }

        /// <summary>
        /// Updates the specified department model.
        /// </summary>
        /// <param name="departmentModel">The department model.</param>
        public static void Update(DepartmentModel departmentModel)
        {

        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public static void Delete(int id)
        {

        }

        /// <summary>
        /// Gets the department models.
        /// </summary>
        /// <returns></returns>
        public static List<DepartmentModel> GetDepartmentModels()
        {
            return DepartmentDAL.GetDepartmentModels();
        }

        /// <summary>
        /// Gets the department model by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        //public static DepartmentModel GetDepartmentModelById(int id)
        //{
        //    return DepartmentDAL.GetDepartmentModelById(id);
        //}

    }
}
