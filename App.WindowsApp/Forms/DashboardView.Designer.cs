namespace App.WindowsApp.Forms
{
    partial class DashboardView
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
            pnlTotalAssets = new Panel();
            pnlAvailable = new Panel();
            pnlAssigned = new Panel();
            pnlUnderRepair = new Panel();
            pnlEmployees = new Panel();
            pnlAssignments = new Panel();
            lblVal1 = new Label();
            lblTitle1 = new Label();
            lblVal2 = new Label();
            lblTitle2 = new Label();
            lblVal3 = new Label();
            lblTitle3 = new Label();
            lblVal4 = new Label();
            lblTitle4 = new Label();
            lblVal5 = new Label();
            lblTitle5 = new Label();
            lblVal6 = new Label();
            lblTitle6 = new Label();
            pnlTotalAssets.SuspendLayout();
            pnlAvailable.SuspendLayout();
            pnlAssigned.SuspendLayout();
            pnlUnderRepair.SuspendLayout();
            pnlEmployees.SuspendLayout();
            pnlAssignments.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTotalAssets
            // 
            pnlTotalAssets.Controls.Add(lblTitle1);
            pnlTotalAssets.Controls.Add(lblVal1);
            pnlTotalAssets.Location = new Point(23, 12);
            pnlTotalAssets.Name = "pnlTotalAssets";
            pnlTotalAssets.Size = new Size(194, 141);
            pnlTotalAssets.TabIndex = 0;
            // 
            // pnlAvailable
            // 
            pnlAvailable.Controls.Add(lblTitle2);
            pnlAvailable.Controls.Add(lblVal2);
            pnlAvailable.Location = new Point(259, 12);
            pnlAvailable.Name = "pnlAvailable";
            pnlAvailable.Size = new Size(214, 141);
            pnlAvailable.TabIndex = 1;
            // 
            // pnlAssigned
            // 
            pnlAssigned.Controls.Add(lblTitle3);
            pnlAssigned.Controls.Add(lblVal3);
            pnlAssigned.Location = new Point(525, 12);
            pnlAssigned.Name = "pnlAssigned";
            pnlAssigned.Size = new Size(222, 141);
            pnlAssigned.TabIndex = 2;
            // 
            // pnlUnderRepair
            // 
            pnlUnderRepair.Controls.Add(lblTitle4);
            pnlUnderRepair.Controls.Add(lblVal4);
            pnlUnderRepair.Location = new Point(23, 215);
            pnlUnderRepair.Name = "pnlUnderRepair";
            pnlUnderRepair.Size = new Size(194, 131);
            pnlUnderRepair.TabIndex = 3;
            // 
            // pnlEmployees
            // 
            pnlEmployees.Controls.Add(lblTitle5);
            pnlEmployees.Controls.Add(lblVal5);
            pnlEmployees.Location = new Point(259, 215);
            pnlEmployees.Name = "pnlEmployees";
            pnlEmployees.Size = new Size(214, 131);
            pnlEmployees.TabIndex = 4;
            // 
            // pnlAssignments
            // 
            pnlAssignments.Controls.Add(lblTitle6);
            pnlAssignments.Controls.Add(lblVal6);
            pnlAssignments.Location = new Point(525, 215);
            pnlAssignments.Name = "pnlAssignments";
            pnlAssignments.Size = new Size(208, 131);
            pnlAssignments.TabIndex = 5;
            // 
            // lblVal1
            // 
            lblVal1.AutoSize = true;
            lblVal1.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal1.Location = new Point(61, 42);
            lblVal1.Name = "lblVal1";
            lblVal1.Size = new Size(64, 74);
            lblVal1.TabIndex = 0;
            lblVal1.Text = "0";
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Location = new Point(39, 13);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(105, 25);
            lblTitle1.TabIndex = 1;
            lblTitle1.Text = "Total Assets";
           
            // 
            // lblVal2
            // 
            lblVal2.AutoSize = true;
            lblVal2.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal2.Location = new Point(72, 50);
            lblVal2.Name = "lblVal2";
            lblVal2.Size = new Size(64, 74);
            lblVal2.TabIndex = 0;
            lblVal2.Text = "0";
            
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Location = new Point(72, 13);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(83, 25);
            lblTitle2.TabIndex = 1;
            lblTitle2.Text = "Available";
            // 
            // lblVal3
            // 
            lblVal3.AutoSize = true;
            lblVal3.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal3.Location = new Point(71, 50);
            lblVal3.Name = "lblVal3";
            lblVal3.Size = new Size(64, 74);
            lblVal3.TabIndex = 0;
            lblVal3.Text = "0";
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Location = new Point(71, 13);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(85, 25);
            lblTitle3.TabIndex = 1;
            lblTitle3.Text = "Assigned";
            // 
            // lblVal4
            // 
            lblVal4.AutoSize = true;
            lblVal4.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal4.Location = new Point(61, 47);
            lblVal4.Name = "lblVal4";
            lblVal4.Size = new Size(64, 74);
            lblVal4.TabIndex = 0;
            lblVal4.Text = "0";
            // 
            // lblTitle4
            // 
            lblTitle4.AutoSize = true;
            lblTitle4.Location = new Point(39, 13);
            lblTitle4.Name = "lblTitle4";
            lblTitle4.Size = new Size(114, 25);
            lblTitle4.TabIndex = 1;
            lblTitle4.Text = "Under Repair";
            // 
            // lblVal5
            // 
            lblVal5.AutoSize = true;
            lblVal5.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal5.Location = new Point(72, 47);
            lblVal5.Name = "lblVal5";
            lblVal5.Size = new Size(64, 74);
            lblVal5.TabIndex = 0;
            lblVal5.Text = "0";
            // 
            // lblTitle5
            // 
            lblTitle5.AutoSize = true;
            lblTitle5.Location = new Point(34, 13);
            lblTitle5.Name = "lblTitle5";
            lblTitle5.Size = new Size(140, 25);
            lblTitle5.TabIndex = 1;
            lblTitle5.Text = "Total Employees";
            // 
            // lblVal6
            // 
            lblVal6.AutoSize = true;
            lblVal6.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVal6.Location = new Point(71, 47);
            lblVal6.Name = "lblVal6";
            lblVal6.Size = new Size(64, 74);
            lblVal6.TabIndex = 0;
            lblVal6.Text = "0";
            // 
            // lblTitle6
            // 
            lblTitle6.AutoSize = true;
            lblTitle6.Location = new Point(19, 13);
            lblTitle6.Name = "lblTitle6";
            lblTitle6.Size = new Size(167, 25);
            lblTitle6.TabIndex = 1;
            lblTitle6.Text = "Active Assignments";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlAssignments);
            Controls.Add(pnlEmployees);
            Controls.Add(pnlUnderRepair);
            Controls.Add(pnlAssigned);
            Controls.Add(pnlAvailable);
            Controls.Add(pnlTotalAssets);
            Name = "DashboardView";
            Text = "Dashboard";
            pnlTotalAssets.ResumeLayout(false);
            pnlTotalAssets.PerformLayout();
            pnlAvailable.ResumeLayout(false);
            pnlAvailable.PerformLayout();
            pnlAssigned.ResumeLayout(false);
            pnlAssigned.PerformLayout();
            pnlUnderRepair.ResumeLayout(false);
            pnlUnderRepair.PerformLayout();
            pnlEmployees.ResumeLayout(false);
            pnlEmployees.PerformLayout();
            pnlAssignments.ResumeLayout(false);
            pnlAssignments.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTotalAssets;
        private Panel pnlAvailable;
        private Panel pnlAssigned;
        private Panel pnlUnderRepair;
        private Panel pnlEmployees;
        private Panel pnlAssignments;
        private Label lblTitle1;
        private Label lblVal1;
        private Label lblVal2;
        private Label lblTitle2;
        private Label lblTitle3;
        private Label lblVal3;
        private Label lblTitle4;
        private Label lblVal4;
        private Label lblTitle5;
        private Label lblVal5;
        private Label lblTitle6;
        private Label lblVal6;
    }
}