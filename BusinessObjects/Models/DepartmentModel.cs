using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payroll.BusinessObjects.Models
{
    [Serializable]
    public class DepartmentModel
    {
        #region Contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentModel"/> class.
        /// </summary>
        public DepartmentModel()
        { 
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentModel"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="departmentName">Name of the department.</param>
        public DepartmentModel(int id, string departmentName)
        {
            _Id = id;
            _DepartmentName = departmentName;
        }

        #endregion

        #region Private Members
        private int _Id;
        private string _DepartmentName = string.Empty;
        #endregion
        #region Public Properties
        /// <summary>
         /// Gets or sets the identifier.
         /// </summary>
         /// <value>
         /// The identifier.
         /// </value>
        public int Id { get { return _Id; } set { _Id = value; } }
        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get { return _DepartmentName; } set { _DepartmentName = value; } }

        #endregion

    }
}
