namespace App.WindowsApp.Forms
{
    partial class AssignmentDetailForm
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
            label1 = new Label();
            cmbAsset = new ComboBox();
            label2 = new Label();
            cmbEmployee = new ComboBox();
            label3 = new Label();
            dtpDate = new DateTimePicker();
            label4 = new Label();
            txtAssignedBy = new TextBox();
            label5 = new Label();
            txtRemarks = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 23);
            label1.Name = "label1";
            label1.Size = new Size(71, 25);
            label1.TabIndex = 0;
            label1.Text = "Asset *";
            // 
            // cmbAsset
            // 
            cmbAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAsset.FormattingEnabled = true;
            cmbAsset.Location = new Point(129, 23);
            cmbAsset.Name = "cmbAsset";
            cmbAsset.Size = new Size(182, 33);
            cmbAsset.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 82);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 2;
            label2.Text = "Employee *";
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(149, 82);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(182, 33);
            cmbEmployee.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 154);
            label3.Name = "label3";
            label3.Size = new Size(147, 25);
            label3.TabIndex = 4;
            label3.Text = "Assigned Date *";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(189, 154);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(178, 31);
            dtpDate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 218);
            label4.Name = "label4";
            label4.Size = new Size(116, 25);
            label4.TabIndex = 6;
            label4.Text = "Assigned By";
            // 
            // txtAssignedBy
            // 
            txtAssignedBy.Location = new Point(149, 218);
            txtAssignedBy.Name = "txtAssignedBy";
            txtAssignedBy.Size = new Size(150, 31);
            txtAssignedBy.TabIndex = 7;
            txtAssignedBy.Text = "IT Admin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 279);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 8;
            label5.Text = "Remarks";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(149, 279);
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(150, 31);
            txtRemarks.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Image = Properties.Resources.save;
            btnSave.Location = new Point(255, 377);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Image = Properties.Resources.cancel;
            btnCancel.Location = new Point(408, 377);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AssignmentDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 469);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRemarks);
            Controls.Add(label5);
            Controls.Add(txtAssignedBy);
            Controls.Add(label4);
            Controls.Add(dtpDate);
            Controls.Add(label3);
            Controls.Add(cmbEmployee);
            Controls.Add(label2);
            Controls.Add(cmbAsset);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AssignmentDetailForm";
            Text = "Assign Asset";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbAsset;
        private Label label2;
        private ComboBox cmbEmployee;
        private Label label3;
        private DateTimePicker dtpDate;
        private Label label4;
        private TextBox txtAssignedBy;
        private Label label5;
        private TextBox txtRemarks;
        private Button btnSave;
        private Button btnCancel;
    }
}