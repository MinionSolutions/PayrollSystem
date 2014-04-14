using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using OfficeOpenXml;
using Payroll.BusinessLogicLayer;
using Payroll.BusinessObjects.Models;

namespace PayrollSystem
{

    public partial class frmPayslip : Form
    {
        #region Global Variables
        public double TotalBasicSalary       = 0.00;
        public static double TotalAdditionalAmount  = 0.00;
        public static double TotalLessAmount        = 0.00;
        public static double TotalGrossSalary       = 0.00;
        public static double TotalNetPay            = 0.00;
        public static double WorkingDays            = 0.00;
        public static double WorkingHours           = 0.00;
        #endregion

        #region Private Members

        private EmployeeModel employee = null;

        #endregion

        public frmPayslip()
        {
            InitializeComponent();
            readtextEmail();
            initializeDefaultValue();
            TotalLessDeduction();
            TotalAdditional();

            TotalBasicSalary      = Convert.ToDouble(txtTotalBasicSalary.Text);
            TotalAdditionalAmount = Convert.ToDouble(txtTotalAdditionalAmount.Text);
            TotalLessAmount       = Convert.ToDouble(txtTotalLessAmount.Text);
            TotalGrossSalary      = Convert.ToDouble(txtGrossSalary.Text);
            TotalNetPay           = Convert.ToDouble(txtTotalBasicSalary.Text);
            WorkingDays           = Convert.ToDouble(txtWorkingDays.Text);
            WorkingHours          = Convert.ToDouble(txtWorkingHours.Text);
        }
        #region Private Void LessAndAdditionalTaxComputation
       
            #region LessTaxComputation
            private void computeSSS()
        {
            TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);

            if (TotalBasicSalary >= 1000.00 && TotalBasicSalary <= 1249.99) { txtSSS.Text = "36.30"; }
            else if (TotalBasicSalary >= 1250.00 && TotalBasicSalary <= 1749.99) { txtSSS.Text = "54.50"; }
            else if (TotalBasicSalary >= 1750.00 && TotalBasicSalary <= 2249.99) { txtSSS.Text = "72.70"; }
            else if (TotalBasicSalary >= 2250.00 && TotalBasicSalary <= 2749.99) { txtSSS.Text = "90.80"; }
            else if (TotalBasicSalary >= 2750.00 && TotalBasicSalary <= 3249.99) { txtSSS.Text = "109.00"; }
            else if (TotalBasicSalary >= 3250.00 && TotalBasicSalary <= 3749.99) { txtSSS.Text = "127.20"; }
            else if (TotalBasicSalary >= 3750.00 && TotalBasicSalary <= 4249.99) { txtSSS.Text = "145.30"; }
            else if (TotalBasicSalary >= 4250.00 && TotalBasicSalary <= 4749.99) { txtSSS.Text = "163.50"; }
            else if (TotalBasicSalary >= 4750.00 && TotalBasicSalary <= 5249.99) { txtSSS.Text = "181.70"; }
            else if (TotalBasicSalary >= 5250.00 && TotalBasicSalary <= 5749.99) { txtSSS.Text = "199.80"; }
            else if (TotalBasicSalary >= 5750.00 && TotalBasicSalary <= 6249.99) { txtSSS.Text = "218.00"; }
            else if (TotalBasicSalary >= 6250.00 && TotalBasicSalary <= 6749.99) { txtSSS.Text = "236.20"; }
            else if (TotalBasicSalary >= 6750.00 && TotalBasicSalary <= 7249.99) { txtSSS.Text = "254.30"; }
            else if (TotalBasicSalary >= 7250.00 && TotalBasicSalary <= 7749.99) { txtSSS.Text = "272.50"; }
            else if (TotalBasicSalary >= 7750.00 && TotalBasicSalary <= 8249.99) { txtSSS.Text = "290.70"; }
            else if (TotalBasicSalary >= 8250.00 && TotalBasicSalary <= 8749.99) { txtSSS.Text = "308.80"; }
            else if (TotalBasicSalary >= 8750.00 && TotalBasicSalary <= 9249.99) { txtSSS.Text = "327.00"; }
            else if (TotalBasicSalary >= 9250.00 && TotalBasicSalary <= 9749.99) { txtSSS.Text = "345.20"; }
            else if (TotalBasicSalary >= 9750.00 && TotalBasicSalary <= 10249.99) { txtSSS.Text = "363.30"; }
            else if (TotalBasicSalary >= 10250.00 && TotalBasicSalary <= 10749.99) { txtSSS.Text = "381.50"; }
            else if (TotalBasicSalary >= 10750.00 && TotalBasicSalary <= 11294.99) { txtSSS.Text = "399.70"; }
            else if (TotalBasicSalary >= 11250.00 && TotalBasicSalary <= 11749.99) { txtSSS.Text = "417.80"; }
            else if (TotalBasicSalary >= 11750.00 && TotalBasicSalary <= 12249.99) { txtSSS.Text = "436.00"; }
            else if (TotalBasicSalary >= 12250.00 && TotalBasicSalary <= 12749.99) { txtSSS.Text = "454.20"; }
            else if (TotalBasicSalary >= 12750.00 && TotalBasicSalary <= 13249.99) { txtSSS.Text = "472.30"; }
            else if (TotalBasicSalary >= 13250.00 && TotalBasicSalary <= 13749.99) { txtSSS.Text = "490.50"; }
            else if (TotalBasicSalary >= 13750.00 && TotalBasicSalary <= 14249.99) { txtSSS.Text = "508.70"; }
            else if (TotalBasicSalary >= 14250.00 && TotalBasicSalary <= 14749.99) { txtSSS.Text = "526.80"; }
            else if (TotalBasicSalary >= 14750.00 && TotalBasicSalary <= 15249.99) { txtSSS.Text = "545.00"; }
            else if (TotalBasicSalary >= 15250.00 && TotalBasicSalary <= 15749.99) { txtSSS.Text = "563.20"; }
            else { txtSSS.Text = "581.30"; }
        }
            private void computePhilhealth()
            {
                TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);

                if (TotalBasicSalary < 9000.00) { txtPH.Text = "100.00"; }
                else if (TotalBasicSalary >= 9000.00 && TotalBasicSalary <= 9999.99) { txtPH.Text = "112.50"; }
                else if (TotalBasicSalary >= 10000.00 && TotalBasicSalary <= 10999.99) { txtPH.Text = "125.00"; }
                else if (TotalBasicSalary >= 11000.00 && TotalBasicSalary <= 11999.99) { txtPH.Text = "137.50"; }
                else if (TotalBasicSalary >= 12000.00 && TotalBasicSalary <= 12999.99) { txtPH.Text = "150.00"; }
                else if (TotalBasicSalary >= 13000.00 && TotalBasicSalary <= 13999.99) { txtPH.Text = "162.50"; }
                else if (TotalBasicSalary >= 14000.00 && TotalBasicSalary <= 14999.99) { txtPH.Text = "175.00"; }
                else if (TotalBasicSalary >= 15000.00 && TotalBasicSalary <= 15999.99) { txtPH.Text = "187.50"; }
                else if (TotalBasicSalary >= 16000.00 && TotalBasicSalary <= 16999.99) { txtPH.Text = "200.00"; }
                else if (TotalBasicSalary >= 17000.00 && TotalBasicSalary <= 17999.99) { txtPH.Text = "212.50"; }
                else if (TotalBasicSalary >= 18000.00 && TotalBasicSalary <= 18999.99) { txtPH.Text = "225.00"; }
                else if (TotalBasicSalary >= 19000.00 && TotalBasicSalary <= 19999.99) { txtPH.Text = "237.50"; }
                else if (TotalBasicSalary >= 20000.00 && TotalBasicSalary <= 20999.99) { txtPH.Text = "250.00"; }
                else if (TotalBasicSalary >= 21000.00 && TotalBasicSalary <= 21999.99) { txtPH.Text = "262.50"; }
                else if (TotalBasicSalary >= 22000.00 && TotalBasicSalary <= 22999.99) { txtPH.Text = "275.00"; }
                else if (TotalBasicSalary >= 23000.00 && TotalBasicSalary <= 23999.99) { txtPH.Text = "287.50"; }
                else if (TotalBasicSalary >= 24000.00 && TotalBasicSalary <= 24999.99) { txtPH.Text = "300.00"; }
                else if (TotalBasicSalary >= 25000.00 && TotalBasicSalary <= 25999.99) { txtPH.Text = "312.50"; }
                else if (TotalBasicSalary >= 26000.00 && TotalBasicSalary <= 26999.99) { txtPH.Text = "325.00"; }
                else if (TotalBasicSalary >= 27000.00 && TotalBasicSalary <= 27999.99) { txtPH.Text = "337.50"; }
                else if (TotalBasicSalary >= 28000.00 && TotalBasicSalary <= 28999.99) { txtPH.Text = "350.00"; }
                else if (TotalBasicSalary >= 29000.00 && TotalBasicSalary <= 29999.99) { txtPH.Text = "362.50"; }
                else if (TotalBasicSalary >= 30000.00 && TotalBasicSalary <= 30999.99) { txtPH.Text = "375.00"; }
                else if (TotalBasicSalary >= 31000.00 && TotalBasicSalary <= 31999.99) { txtPH.Text = "387.50"; }
                else if (TotalBasicSalary >= 32000.00 && TotalBasicSalary <= 32999.99) { txtPH.Text = "400.00"; }
                else if (TotalBasicSalary >= 33000.00 && TotalBasicSalary <= 33999.99) { txtPH.Text = "412.50"; }
                else if (TotalBasicSalary >= 34000.00 && TotalBasicSalary <= 34999.99) { txtPH.Text = "425.00"; }
                //else if (TotalBasicSalary > 35000.00) { txtPH.Text = "437.50"; }
                else { txtPH.Text = "437.50"; }
            }
            private void computeUndertime()
            {
                TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double Undertime = Convert.ToDouble(txtUndertimeAmount.Text);
                double dblUndertime = Convert.ToDouble(txtUndertime.Text);
                double dblTotal = 0.00;

                dblTotal = (TotalBasicSalary / 22 / 8 / 60) * dblUndertime;
                Undertime = dblTotal;

            }
            private void computeLate()
            {
                TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double dblTotal = 0.00;
                double dblLate = Convert.ToDouble(txtLate.Text);

                dblTotal = (TotalBasicSalary / 22 / 60) * dblLate;
                txtLateAmount.Text = dblTotal.ToString("0.00");
            }
            private void computeAbsences()
            {
                double dblTotal = 0.00;
                TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double dblAbsences = Convert.ToDouble(txtAbsences.Text);

                dblTotal = (TotalBasicSalary / 22) * dblAbsences;
                txtAbsencesAmount.Text = dblTotal.ToString("0.00");
            }
            private void TotalLessDeduction()
            {
                double dblTotalLessDeduction = 0.00;
                double dblSSS = Convert.ToDouble(txtSSS.Text);
                double dblPH = Convert.ToDouble(txtPH.Text);
                double dblPagibig = Convert.ToDouble(txtPagibig.Text);
                double dblWithTax = Convert.ToDouble(txtWithTax.Text);
                double dblLate = Convert.ToDouble(txtLateAmount.Text);
                double dblAbsences = Convert.ToDouble(txtAbsencesAmount.Text);
                double dblUndertime = Convert.ToDouble(txtUndertimeAmount.Text);
                double dblAdjustment = Convert.ToDouble(txtLessAdjustment.Text);

                dblTotalLessDeduction = dblSSS + dblPH + dblPagibig + dblWithTax + dblLate + dblAbsences + dblUndertime + dblAdjustment;
                txtTotalLessAmount.Text = dblTotalLessDeduction.ToString("0.00");
            }
            #endregion

            #region AdditionTaxComputation
            private void computeRegularHoliday()
            {
                double dblGrossSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double inputWorkingTime = Convert.ToDouble(txtRegularHoliday.Text);

                txtRegularHolidayAmount.Text = ((dblGrossSalary / 22) * inputWorkingTime).ToString("0.00");

            }
            private void computeSpecialNonWorkingHoliday()
            {
                double dblGrossSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double inputWorkingTime = Convert.ToDouble(txtSpecialNonWorking.Text);

                txtSpecialNonWorkingAmount.Text = ((dblGrossSalary / 22) * inputWorkingTime).ToString("0.00");
            }
            private void computeRestDayWork()
            {
                double dblGrossSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double inputWorkingTime = Convert.ToDouble(txtRestDay.Text);

                txtRestDayAmount.Text = (((dblGrossSalary / 22 / 8) * 1.30) * inputWorkingTime).ToString("0.00");
            }
            private void computeNightDifferential()
            {
                double dblGrossSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
                double inputWorkingTime = Convert.ToDouble(txtNightDifferential.Text);

                txtNightDifferentialAmount.Text = (((dblGrossSalary / 22 / 8) * .10) * inputWorkingTime).ToString("0.00");
            }
            private void computeNonTaxable()
            {
                double dblTotal = 0.00;
                double dblAllowance = Convert.ToDouble(txtAllowance.Text);
                double dblIncentives = Convert.ToDouble(txtDeminimis.Text);
                double dblDeminimis = Convert.ToDouble(txtDeminimis.Text);
                double dblTranspoAllowance = Convert.ToDouble(txtDeminimis.Text);

                dblTotal = dblAllowance + dblIncentives + dblDeminimis + dblTranspoAllowance;
            }
            private void computeAllowance()
            {
                if (txtWorkingDays.Text == "0")
                {
                    MessageBox.Show("Input No. of Working Days");
                }
                else
                {
                    double dblTotal = 0.00;
                    double dblAllowance = Convert.ToDouble(txtAllowance.Text);
                    double intDaysWork = Convert.ToInt32(txtWorkingDays.Text);

                    dblTotal = (dblAllowance / 22) * intDaysWork;
                    txtAllowanceAmount.Text = dblTotal.ToString("0.00");
                }
            }
            private void TotalAdditional()
            {
                double dblTotalAdditional = 0.00;
                double dblAllowance = Convert.ToDouble(txtAllowanceAmount.Text);
                double dblIncentives = Convert.ToDouble(txtInventives.Text);
                double dblDeminimis = Convert.ToDouble(txtDeminimis.Text);
                double dblTranspoAllowance = Convert.ToDouble(txtTranspoAllowance.Text);
                double dblRegularHoliday = Convert.ToDouble(txtRegularHolidayAmount.Text);
                double dblSpecialNonWorking = Convert.ToDouble(txtSpecialNonWorkingAmount.Text);
                double dblNightDifferential = Convert.ToDouble(txtNightDifferentialAmount.Text);
                double dblRestDay = Convert.ToDouble(txtRestDayAmount.Text);
                double dblAdjustment = Convert.ToDouble(txtAddAdjustment.Text);

                dblTotalAdditional = dblAllowance + dblIncentives + dblDeminimis + dblTranspoAllowance + dblRegularHoliday + dblSpecialNonWorking + dblNightDifferential + dblRestDay + dblAdjustment;
                txtTotalAdditionalAmount.Text = dblTotalAdditional.ToString("0.00");
            }
            #endregion

        #endregion
     
        protected DataTable MakeDataTable()
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("AMOUNT", typeof(string));
            Dt.Columns.Add("SSS", typeof(string));
            Dt.Columns.Add("Philhealth", typeof(string));
            Dt.Columns.Add("Price", typeof(string));
            Dt.Columns.Add("Price", typeof(string));
            Dt.Columns.Add("Price", typeof(string));
            Dt.Columns.Add("Price", typeof(string));
            Dt.Columns.Add("Price", typeof(string));
            return Dt;
        }
        private void readtextEmail()
        {
            try
            {
                string path = Application.StartupPath;
                using (StreamReader sr = new StreamReader("email.txt"))
                {
                    bool hasEntries = true;
                    

                    while (hasEntries)
                    {
                        
                        String line = sr.ReadLine();
                        //cmbEmail.Items.Add(line);

                        hasEntries = line.Length > 0;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        public  void initializeDefaultValue()
        {
            #region TaxComputation
            txtTotalBasicSalary.Text = "0";
            txtGrossSalary.Text = "0";
            txtTotalBasicSalary.Text = "0";
            txtNetSalary.Text = "0";
            #endregion

            #region deduction
            txtSSS.Text = "0.00";
            txtPH.Text = "0.00";
            txtPagibig.Text = "100.00";
            txtLateAmount.Text = "0";
            txtLate.Text = "0";
            txtAbsencesAmount.Text = "0";
            txtAbsences.Text = "0";
            txtLessAdjustment.Text = "0";
            txtWithTax.Text = "0";
            txtUndertimeAmount.Text = "0";
            txtUndertime.Text = "0";
            txtTotalLessAmount.Text = "0";
            #endregion

            #region additional
            txtRegularHoliday.Text = "0";
            txtSpecialNonWorking.Text = "0";
            txtNightDifferential.Text = "0";
            txtRestDay.Text = "0";
            txtAllowance.Text = "0";
            txtDeminimis.Text = "0";
            txtInventives.Text = "0";
            txtTranspoAllowance.Text = "0";
            txtAllowanceAmount.Text = "0";
            txtRestDayAmount.Text = "0";
            txtRegularHolidayAmount.Text = "0";
            txtSpecialNonWorkingAmount.Text = "0";
            txtNightDifferentialAmount.Text = "0";
            txtRestDayAmount.Text = "0";
            txtAddAdjustment.Text = "0";
            txtTotalAdditionalAmount.Text = "0";
            #endregion

            #region others
            txtWorkingDays.Text = "0";
            txtWorkingHours.Text = "0";
            cmbPayPeriod.SelectedIndex = 0;
            #endregion
        }
        private void computeTotalBasicSalary()
        {
            double dblGrossSalary = Convert.ToDouble(txtGrossSalary.Text);
            double dblSSS = Convert.ToDouble(txtSSS.Text);
            double dblPH = Convert.ToDouble(txtPH.Text);
            double dblPagibig = Convert.ToDouble(txtPagibig.Text);
            double netPay = 0.00;

            netPay = dblGrossSalary - dblSSS - dblPH - dblPagibig;

            txtNetSalary.Text = Convert.ToDouble(netPay).ToString();
        }
        private void computeWorkBack()
        {
            double dblNetPay = Convert.ToDouble(txtTotalBasicSalary.Text);
            double dblSSS = Convert.ToDouble(txtSSS.Text);
            double dblPH = Convert.ToDouble(txtPH.Text);
            double dblPagibig = Convert.ToDouble(txtPagibig.Text);

            double grossSalary = 0.00;
            grossSalary = dblNetPay + dblSSS + dblPH + dblPagibig;

           txtTotalBasicSalary.Text = Convert.ToDouble(grossSalary).ToString();
        }
        private void computeGrossSalary()
        {
            double dbTotal = 0.00;
            double dblBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
            double dblLess = Convert.ToDouble(txtTotalLessAmount.Text);
            double dblAdditional = Convert.ToDouble(txtTotalAdditionalAmount.Text);
            //double dblcomputeGrossSalary   = Convert.ToDouble(txtGrossSalary.Text);

            dbTotal = (dblBasicSalary + dblAdditional) - dblLess;
            txtGrossSalary.Text = dbTotal.ToString();

        }
        public  void TaxComputation()
        {
            double  TotalBasicSalary = Convert.ToDouble(txtTotalBasicSalary.Text);
            double status = 0.00;

            if (txtTaxStatus.Text == "S/ME")
            {
                #region computeSME
                if (TotalBasicSalary < 4167.00)
                {
                    txtWithTax.Text = TotalBasicSalary.ToString();
                }
                else if (TotalBasicSalary >= 4167.00 && TotalBasicSalary < 5000.00)
                {
                    status = (TotalBasicSalary * .05) + 0.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 5000.00 && TotalBasicSalary < 6667.00)
                {
                    status = (TotalBasicSalary * .10) + 41.67;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 6667.00 && TotalBasicSalary < 10000.00)
                {
                    status = (TotalBasicSalary * .15) + 208.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 10000.00 && TotalBasicSalary < 15833.00)
                {
                    status = (TotalBasicSalary * .20) + 708.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 15833.00 && TotalBasicSalary < 25000.00)
                {
                    status = (TotalBasicSalary * .25) + 1875.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 25000.00 && TotalBasicSalary < 45833.00)
                {
                    status = (TotalBasicSalary * .30) + 4166.67;
                    txtWithTax.Text = status.ToString();
                }
                else
                {
                    status = (TotalBasicSalary * .32) + 10416.67;
                    txtWithTax.Text = status.ToString();
                }
                #endregion
            }
            else if (txtTaxStatus.Text == "S1/ME1")
            {
                #region computes1S1
                if (TotalBasicSalary < 6250.00)
                {
                    txtWithTax.Text = TotalBasicSalary.ToString();
                }
                else if (TotalBasicSalary >= 6250.00 && TotalBasicSalary < 7083.00)
                {
                    status = (TotalBasicSalary * .05) + 0.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 7083.00 && TotalBasicSalary < 8750.00)
                {
                    status = (TotalBasicSalary * .10) + 41.67;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 8750.00 && TotalBasicSalary < 12083.00)
                {
                    status = (TotalBasicSalary * .15) + 208.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 12083.00 && TotalBasicSalary < 17917.00)
                {
                    status = (TotalBasicSalary * .20) + 708.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 17917.00 && TotalBasicSalary < 27083.00)
                {
                    status = (TotalBasicSalary * .25) + 1875.00d;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 27083.00 && TotalBasicSalary < 47917.00)
                {
                    status = (TotalBasicSalary * .30) + 4166.67;
                    txtWithTax.Text = status.ToString();
                }
                else
                {
                    status = (TotalBasicSalary * .32) + 10416.67;
                    txtWithTax.Text = status.ToString();
                }
                #endregion
            }
            else if (txtTaxStatus.Text == "S2/ME2")
            {
                #region computem2S2
                if (TotalBasicSalary < 8333.00)
                {
                    txtWithTax.Text = TotalBasicSalary.ToString();
                }
                else if (TotalBasicSalary >= 8333.00 && TotalBasicSalary < 9167.00)
                {
                    status = (TotalBasicSalary * .05) + 0.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 9167.00 && TotalBasicSalary < 10833.00)
                {
                    status = (TotalBasicSalary * .10) + 41.67;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 10833.00 && TotalBasicSalary < 14167.00)
                {
                    status = (TotalBasicSalary * .15) + 208.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 14167.00 && TotalBasicSalary < 20000.00)
                {
                    status = (TotalBasicSalary * .20) + 708.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 20000.00 && TotalBasicSalary < 29167.00)
                {
                    status = (TotalBasicSalary * .25) + 1875.00d;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 29167.00 && TotalBasicSalary < 50000.00)
                {
                    status = (TotalBasicSalary * .30) + 4166.67;
                    txtWithTax.Text = status.ToString();
                }
                else
                {
                    status = (TotalBasicSalary * .32) + 10416.67;
                    txtWithTax.Text = status.ToString();
                }
                #endregion
            }
            else if (txtTaxStatus.Text == "S3/ME3")
            {
                #region computem3S3
                if (TotalBasicSalary < 10417.00)
                {
                    txtWithTax.Text = TotalBasicSalary.ToString();
                }
                else if (TotalBasicSalary >= 10417.00 && TotalBasicSalary < 11250.00)
                {
                    status = (TotalBasicSalary * .05) + 0.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 11250.00 && TotalBasicSalary < 12917.00)
                {
                    status = (TotalBasicSalary * .10) + 41.67;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 12917.00 && TotalBasicSalary < 16250.00)
                {
                    status = (TotalBasicSalary * .15) + 208.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 16250.00 && TotalBasicSalary < 22083.00)
                {
                    status = (TotalBasicSalary * .20) + 708.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 22083.00 && TotalBasicSalary < 31250.00)
                {
                    status = (TotalBasicSalary * .25) + 1875.00d;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 31250.00 && TotalBasicSalary < 52083.00)
                {
                    status = (TotalBasicSalary * .30) + 4166.67;
                    txtWithTax.Text = status.ToString();
                }
                else
                {
                    status = (TotalBasicSalary * .32) + 10416.67;
                    txtWithTax.Text = status.ToString();
                }
                #endregion
            }
            else
            {
                #region computem4S4
                if (TotalBasicSalary < 12500.00)
                {
                    txtWithTax.Text = TotalBasicSalary.ToString();
                }
                else if (TotalBasicSalary >= 12500.00 && TotalBasicSalary < 13333.00)
                {
                    status = (TotalBasicSalary * .05) + 0.00;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 13333.00 && TotalBasicSalary < 15000.00)
                {
                    status = (TotalBasicSalary * .10) + 41.67;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 15000.00 && TotalBasicSalary < 18333.00)
                {
                    status = (TotalBasicSalary * .15) + 208.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 18333.00 && TotalBasicSalary < 24167.00)
                {
                    status = (TotalBasicSalary * .20) + 708.33;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 24167.00 && TotalBasicSalary < 33333.00)
                {
                    status = (TotalBasicSalary * .25) + 1875.00d;
                    txtWithTax.Text = status.ToString();
                }
                else if (TotalBasicSalary >= 33333.00 && TotalBasicSalary < 54167.00)
                {
                    status = TotalBasicSalary * .30 + 4166.67;
                    txtWithTax.Text = status.ToString();
                }
                else
                {
                    status = (TotalBasicSalary * .32) + 10416.67;
                    txtWithTax.Text = status.ToString();
                }
                #endregion
            }
        }
        private void sendToEmail()
        {
            //if (cmbEmail.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Select Valid email");
            //}
            //else
            //{
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                SmtpServer.Credentials = new System.Net.NetworkCredential("minionsolutions2014@gmail.com", "M1nionsolutions");
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;

                mail.From = new MailAddress("minionsolutions@gmail.com", "Melchor Villar - minionsolutions inc.", System.Text.Encoding.UTF8);
                //mail.To.Add(cmbEmail.SelectedItem.ToString());
                //mail.Attachments.Add(this.generateExcelAttachment(cmbEmail.SelectedItem.ToString()));
                mail.Subject = "Payslip";
                mail.Body = "Please see attached";
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mail.IsBodyHtml = true;
                SmtpServer.Send(mail);
            //}
        }
        private Attachment generateExcelAttachment(string email)
        {
            string path = Application.UserAppDataPath;

            FileInfo excelFile = new FileInfo(string.Format(@"{0}\{1}{2}.xls",
                                                path,
                                                email,
                                                DateTime.UtcNow.Ticks));

            using (ExcelPackage package = new ExcelPackage(excelFile))
            {                
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Payslip");

                //data
                worksheet.Cell(1,1).Value = "MinionSolutions";
                worksheet.Cell(1, 2).Value = "Employee";
                //worksheet.Cell(1, 2).Value = cmbEmail.SelectedItem.ToString();
                worksheet.Cell(2, 2).Value = txtTotalBasicSalary.Text;

                //Column
                worksheet.Column(1).Width = 50;

                package.Save();
            }
            return new Attachment(excelFile.FullName);
        }
        private void getAllData()
        {
        }

        #region Control Events

        private void btnCompute_Click(object sender, EventArgs e)
        {
            #region addtitional
            //taxable
            this.computeRegularHoliday();
            this.computeSpecialNonWorkingHoliday();
            this.computeNightDifferential();
            this.computeRestDayWork();
            //non taxable
            this.computeAllowance();
            this.TotalAdditional();
            #endregion

            #region deduction
            this.TaxComputation();
            this.computeLate();
            this.computeAbsences();
            this.computeUndertime();
            this.computeSSS();
            this.computePhilhealth();
            this.TotalLessDeduction();
            #endregion

            this.computeGrossSalary();
            this.computeTotalBasicSalary();


        }
        private void btnSendToEmail_Click(object sender, EventArgs e)
        {
            sendToEmail();
            MessageBox.Show("Payslip sent!");
        }
        private void txtGrossSalary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.computeSSS();
                this.computePhilhealth();

                this.TotalAdditional();
                this.TotalLessDeduction();

                #region computeAddtional
                #endregion

            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            initializeDefaultValue();
        }
        private void txtRegularHoliday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
               computeRegularHoliday();
               this.TotalAdditional();
               this.computeGrossSalary();
            }
        }
        private void txtSpecialNonWorking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
              computeSpecialNonWorkingHoliday();
              this.TotalAdditional();
              this.computeGrossSalary();
            }
        }
        private void txtRestDay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
               computeRestDayWork();
               this.TotalAdditional();
               this.computeGrossSalary();
            }
        }
        private void txtNightDifferential_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13)
            {
                computeNightDifferential();
                this.TotalAdditional();
                this.computeGrossSalary();
            }
           
        }
        private void txtAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (txtWorkingDays.Text == "0")
                { 
                    MessageBox.Show("Input No. of Working Days");
                }
                else 
                { 
                    this.computeAllowance();
                    this.TotalAdditional();
                    this.computeGrossSalary();
                }
            }
        }
        private void txtDaysWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.computeAllowance();
                this.computeGrossSalary();
            }
        }
        private void txtLessAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                TotalLessDeduction();
                this.computeGrossSalary();
            }
        }
        private void txtInventives_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                    this.TotalAdditional();
                    this.computeGrossSalary();
            }
        }
        private void txtDeminimis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.TotalAdditional();
                this.computeGrossSalary();
            }
        }
        private void txtTranspoAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.TotalAdditional();
                this.computeGrossSalary();
            }
        }
        private void txtAddAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.TotalAdditional();
                this.computeGrossSalary();
            }
        }
        private void txtUndertime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.computeUndertime();
                this.TotalLessDeduction();
                this.computeGrossSalary();
            }
        }
        private void txtAbsences_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                computeAbsences();
                TotalLessDeduction();
                computeGrossSalary();
            }
        }
        private void txtLate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                computeLate();
                TotalLessDeduction();
                computeGrossSalary();
            }
        }
        private void btnComputeTotalLess_Click(object sender, EventArgs e)
        {
            this.computeSSS();
            this.computePhilhealth();
            this.TotalLessDeduction();
            this.computeGrossSalary();
        }
        private void cmbPayPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbPayPeriod.SelectedIndex == 1)
            {
                txtWorkingDays.Text = "11";
            }
            else if (this.cmbPayPeriod.SelectedIndex == 2)
            {
                txtWorkingDays.Text = "22";
            }
            else
            {
                txtWorkingDays.Text = "0";
            }

        }
        private void getListNameByDepartment(string department)
        {
            List<EmployeeModel> employees = Employee.getEmployeeNamesByDepartment(department);
            foreach (EmployeeModel employee in employees)
                employee.empLName = string.Format("{0}, {1} {2}", employee.empLName, employee.empFName, employee.empMName); 
        
            this.employeeModelBindingSource.DataSource = employees;
            this.dgEmployees.DataSource = this.employeeModelBindingSource;
            
        }
        private void getAllDepartments()
        {
            List<DepartmentModel> departments = new List<DepartmentModel>();
            departments = Department.GetDepartmentModels();

            cmbDepartment.Items.Add("All");
            foreach (DepartmentModel d in departments)
            {
 
                cmbDepartment.Items.Add(d.DepartmentName);
            }
           
            cmbDepartment.SelectedIndex = 0;

        }
        private void main_Load(object sender, EventArgs e)
        {
            getAllDepartments();
            string strDepartment = cmbDepartment.Text;
            getListNameByDepartment(strDepartment);
    
           
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.getListNameByDepartment(cmbDepartment.SelectedItem.ToString());
        }
        private void dgEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeeModel employee   = (EmployeeModel)employeeModelBindingSource.Current;
            this.employee            = employee;
            txtEmpId.Text            = employee.empId;
            txtEmpName.Text          = employee.empLName;
            txtEmail.Text            = employee.empEmail;
            txtPosition.Text         = employee.empPosition;
            txtDepartment.Text       = employee.empDepartment;
            txtTaxStatus.Text        = employee.empTaxStatus;
            txtTotalBasicSalary.Text = employee.empSalary.ToString();

            
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<EmployeeModel> employees = (List<EmployeeModel>)Employee.getEmployeeNamesByDepartment(cmbDepartment.SelectedItem.ToString());
            foreach (EmployeeModel employee in employees)
                employee.empLName = string.Format("{0}, {1} {2}", employee.empLName, employee.empFName, employee.empMName); 

            if (this.txtSearch.Text.Length > 0)
            {
                if (employees != null)
                    employeeModelBindingSource.DataSource = employees.Where(item => item.empLName.ToLower().Contains(this.txtSearch.Text.Trim())).ToList();
            }
            else
                employeeModelBindingSource.DataSource = employees;

        }
        #endregion

        private void btnPreview_Click(object sender, EventArgs e)
        {
            employee.AdditionalSalary = Convert.ToDouble(txtTotalAdditionalAmount.Text);
            employee.SalaryDeduction = Convert.ToDouble(txtTotalLessAmount.Text);
            employee.GrossSalary = Convert.ToDouble(txtGrossSalary.Text);
            employee.NetSalary = Convert.ToDouble(txtNetSalary.Text);
            employee.PayPeriod = Convert.ToString(cmbPayPeriod.SelectedItem);
            cmbPayPeriod.SelectedItem   = Convert.ToString(employee.PayPeriod);
            employee.WorkDays = Convert.ToInt32(txtWorkingDays.Text);
            employee.WorkHours = Convert.ToInt32(txtWorkingHours.Text);

            //additional
            employee.RegularHoliday = Convert.ToDouble(txtRegularHolidayAmount.Text);
            employee.SpecialNonWorkingHoliday = Convert.ToDouble(txtSpecialNonWorkingAmount.Text);
            employee.NightDifferential = Convert.ToDouble(txtNightDifferentialAmount.Text);
            employee.RestDay = Convert.ToDouble(txtRestDayAmount.Text);
            employee.Allowance = Convert.ToDouble(txtAllowanceAmount.Text);
            employee.Incentives = Convert.ToDouble(txtInventives.Text);
            employee.DeminimisBenifit = Convert.ToDouble(txtDeminimis.Text);
            employee.TransportationAllowance = Convert.ToDouble(txtTranspoAllowance.Text);
            employee.AdditionalAdjustment = Convert.ToDouble(txtAddAdjustment.Text);

            //deduction
            employee.Late = Convert.ToDouble(txtLateAmount.Text);
            employee.Absences = Convert.ToDouble(txtAbsencesAmount.Text);
            employee.Undertime = Convert.ToInt32(txtUndertimeAmount.Text);
            employee.SSS = Convert.ToDouble(txtSSS.Text);
            employee.Philhealth = Convert.ToDouble(txtPH.Text);
            employee.Pagibig = Convert.ToDouble(txtPagibig.Text);
            employee.taxAmount = Convert.ToDouble(txtWithTax.Text);
            employee.LessAdjustment = Convert.ToDouble(txtLessAdjustment.Text);

            frmPayslipPreview m = new frmPayslipPreview(this.employee);
            m.ShowDialog(this);
        }
    }
}
