using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Payroll.BusinessLogicLayer;
using Payroll.BusinessObjects.Models;
using Payroll.Utilities;

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
            //get all departments
            initializeDepartments();
            lblEmployeeId.Text = Employee.generateEmployeeId();

        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.DimGray;
            panel1.Cursor = Cursors.Default;
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

      

        private void label1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Beige;
            panel1.Cursor = Cursors.Hand;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Beige;
            panel1.Cursor = Cursors.Hand;
            viewAllEmployees();
        }

        #region Private methods

        private void initializeDepartments()
        {
            List<DepartmentModel> depts = Department.GetDepartmentModels();
            foreach (DepartmentModel d in depts) {
                ComboItem item = new ComboItem();
                item.Text = d.DepartmentName;
                item.Value = d.Id;

                cbDepartment.Items.Add(item);
            }

            cbDepartment.SelectedIndex = 0;
        }

        private void viewAllEmployees()
        {
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            string empId = lblEmployeeId.Text;
            string empLName = txtEmpLName.Text;
            string empFName = txtEmpFName.Text;
            string empMName = txtEmpMName.Text;
            DateTime empBDay = dtpEmpBirthday.Value;
            string empBPlace = txtEmpBPlace.Text;
            string empGender = radMale.Checked ? "1" : "2";
            string empCNumber = txtEmpCNumber.Text;
            string empReligion = txtEmpReligion.Text;
            string empCitizen = txtEmpCitizenship.Text;
            string empCivilStatus = cbCivilStatus.SelectedItem.ToString();
            string empEAdd = txtEmpEmail.Text;

            string empCompany = txtEmpCompany.Text;
            string empPosition = txtEmpPosition.Text;
            string empDepartment = Convert.ToString(((Payroll.Utilities.ComboItem)(cbDepartment.SelectedItem)).Value);
            double empBasicSalary = Convert.ToDouble(txtBasicSalary.Text);
            string empTaxCode = cbTaxCode.SelectedItem.ToString();
            string empSSSNumber = txtEmpSSSNumber.Text;
            string empPAGIBIGNo = txtEmpPAGIBIGNo.Text;
            string empPhilHealthNo = txtEmpPHNo.Text;
            string empTINNo = txtEmpTINNo.Text;


            Employee emp = new Employee();

            emp.CreateEmployee(empId, empLName, empFName, empMName, empBDay, empBPlace, empGender, empCNumber, empReligion,
                               empCitizen, empCivilStatus, empEAdd, empCompany, empPosition, empDepartment, empBasicSalary, empTaxCode,
                               empSSSNumber, empPAGIBIGNo, empPhilHealthNo, empTINNo);
        }

       

        


    }
}
