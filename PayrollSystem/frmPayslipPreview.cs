using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Payroll.BusinessObjects.Models;

namespace PayrollSystem
{
    public partial class frmPayslipPreview : Form
    {
        private EmployeeModel _employee = null;

        public frmPayslipPreview(EmployeeModel employee)
        {
            InitializeComponent();
            _employee = employee;
        }

        private void frmPayslipPreview_Load(object sender, EventArgs e)
        {
            this.employeeModelBindingSource.DataSource = _employee;
            this.reportViewer1.RefreshReport();
        }
    }
}
