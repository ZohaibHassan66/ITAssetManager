namespace App.WindowsApp.Forms
{
    partial class EmployeeDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            txtFullName = new TextBox();
            label2 = new Label();
            txtDepartment = new TextBox();
            label3 = new Label();
            txtContact = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(21, 20);
            label1.Name = "label1";
            label1.Size = new Size(113, 28);
            label1.TabIndex = 0;
            label1.Text = "Full Name *";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(163, 20);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(150, 31);
            txtFullName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(21, 81);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 2;
            label2.Text = "Department";
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(163, 81);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(150, 31);
            txtDepartment.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(21, 149);
            label3.Name = "label3";
            label3.Size = new Size(116, 28);
            label3.TabIndex = 4;
            label3.Text = "Contact No.";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(163, 149);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(150, 31);
            txtContact.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(22, 211);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 6;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(163, 208);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 31);
            txtEmail.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(238, 314);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(372, 314);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EmployeeDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 402);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtContact);
            Controls.Add(label3);
            Controls.Add(txtDepartment);
            Controls.Add(label2);
            Controls.Add(txtFullName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "EmployeeDetailForm";
            Text = "Employee Detail";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtFullName;
        private Label label2;
        private TextBox txtDepartment;
        private Label label3;
        private TextBox txtContact;
        private Label label4;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnCancel;
    }
}