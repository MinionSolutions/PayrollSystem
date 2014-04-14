using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Payroll.BusinessLogicLayer;
using Payroll.BaseClass;
using Payroll.BusinessObjects.Models;
using Payroll.BusinessLogicLayer;

namespace PayrollSystem
{
    public partial class frmAddEmployee : Form
    {
        public frmAddEmployee()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DepartmentModel dm = new DepartmentModel(0, "arniel pogi");
            dm = Department.Add(dm);
        }

        private void frmAddEmployee_Load(object sender, EventArgs e)
        {
            string employeeid = Employee.generateEmployeeId();
            lblEmployeeId.Text = employeeid;
        }
    }
}
