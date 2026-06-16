namespace App.WindowsApp.Forms
{
    partial class AssignmentForm
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
            pnlTop = new Panel();
            btnRefresh = new Button();
            btnReturn = new Button();
            btnAssign = new Button();
            dgvAssignments = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnReturn);
            pnlTop.Controls.Add(btnAssign);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(878, 81);
            pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.Location = new Point(352, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 56);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnReturn.Image = Properties.Resources._return;
            btnReturn.Location = new Point(188, 3);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(112, 56);
            btnReturn.TabIndex = 1;
            btnReturn.Text = "Return";
            btnReturn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnAssign
            // 
            btnAssign.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAssign.Image = Properties.Resources.assign;
            btnAssign.Location = new Point(27, 3);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(112, 56);
            btnAssign.TabIndex = 0;
            btnAssign.Text = "Assign";
            btnAssign.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // dgvAssignments
            // 
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.BackgroundColor = Color.FromArgb(224, 224, 224);
            dgvAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignments.Dock = DockStyle.Fill;
            dgvAssignments.GridColor = Color.FromArgb(224, 224, 224);
            dgvAssignments.Location = new Point(0, 81);
            dgvAssignments.MultiSelect = false;
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.ReadOnly = true;
            dgvAssignments.RowHeadersWidth = 62;
            dgvAssignments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssignments.Size = new Size(878, 463);
            dgvAssignments.TabIndex = 1;
            // 
            // AssignmentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 544);
            Controls.Add(dgvAssignments);
            Controls.Add(pnlTop);
            Name = "AssignmentForm";
            Text = "Assignments";
            pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlTop;
        private Button btnRefresh;
        private Button btnReturn;
        private Button btnAssign;
        private DataGridView dgvAssignments;
    }
}