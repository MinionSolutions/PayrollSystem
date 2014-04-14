namespace PayrollSystem
{
    partial class frmManageEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsViewEmployees = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAddEmployee = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddEmployee,
            this.toolStripSeparator1,
            this.tsViewEmployees});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1049, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsViewEmployees
            // 
            this.tsViewEmployees.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsViewEmployees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsViewEmployees.Name = "tsViewEmployees";
            this.tsViewEmployees.Size = new System.Drawing.Size(23, 22);
            this.tsViewEmployees.Text = "View Employees";
            this.tsViewEmployees.ToolTipText = "View Employees";
            this.tsViewEmployees.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsAddEmployee
            // 
            this.tsAddEmployee.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAddEmployee.Enabled = false;
            this.tsAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAddEmployee.Name = "tsAddEmployee";
            this.tsAddEmployee.Size = new System.Drawing.Size(23, 22);
            this.tsAddEmployee.Text = "Add Employee";
            this.tsAddEmployee.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // frmManageEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 472);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmManageEmployee";
            this.Text = "Manage Employee";
            this.Load += new System.EventHandler(this.frmManageEmployee_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsViewEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsAddEmployee;


    }
}