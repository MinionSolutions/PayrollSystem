using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class frmManageEmployee : Form
    {
        public frmManageEmployee()
        {
            InitializeComponent();
        }

        private void frmManageEmployee_Load(object sender, EventArgs e)
        {
            //get all list of employees

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsViewEmployees.Enabled = true;
            tsAddEmployee.Enabled = false;

            frmAddEmployee frmAddE = new frmAddEmployee();
            frmAddE.ShowDialog(this);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
