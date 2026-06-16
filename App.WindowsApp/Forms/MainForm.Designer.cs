namespace App.WindowsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            btnCategories = new Button();
            btnAssignments = new Button();
            btnEmployees = new Button();
            btnAsset = new Button();
            btnDashboard = new Button();
            lblAppTitle = new Label();
            pnlHeader = new Panel();
            lblPageTitle = new Label();
            pnlContent = new Panel();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.Controls.Add(btnCategories);
            pnlSidebar.Controls.Add(btnAssignments);
            pnlSidebar.Controls.Add(btnEmployees);
            pnlSidebar.Controls.Add(btnAsset);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(300, 644);
            pnlSidebar.TabIndex = 0;
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.FromArgb(224, 224, 224);
            btnCategories.Dock = DockStyle.Top;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCategories.ForeColor = Color.Black;
            btnCategories.Image = Properties.Resources.icons8_categories_24;
            btnCategories.Location = new Point(0, 356);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(300, 82);
            btnCategories.TabIndex = 5;
            btnCategories.Text = "Categories";
            btnCategories.TextAlign = ContentAlignment.MiddleRight;
            btnCategories.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnAssignments
            // 
            btnAssignments.BackColor = Color.FromArgb(224, 224, 224);
            btnAssignments.Dock = DockStyle.Top;
            btnAssignments.FlatStyle = FlatStyle.Flat;
            btnAssignments.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAssignments.ForeColor = Color.Black;
            btnAssignments.Image = Properties.Resources.assign__1_;
            btnAssignments.Location = new Point(0, 274);
            btnAssignments.Name = "btnAssignments";
            btnAssignments.Size = new Size(300, 82);
            btnAssignments.TabIndex = 3;
            btnAssignments.Text = "Assignments";
            btnAssignments.TextAlign = ContentAlignment.MiddleRight;
            btnAssignments.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAssignments.UseVisualStyleBackColor = false;
            btnAssignments.Click += btnAssignments_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.FromArgb(224, 224, 224);
            btnEmployees.Dock = DockStyle.Top;
            btnEmployees.FlatStyle = FlatStyle.Flat;
            btnEmployees.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEmployees.ForeColor = Color.Black;
            btnEmployees.Image = Properties.Resources.teamwork;
            btnEmployees.Location = new Point(0, 192);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(300, 82);
            btnEmployees.TabIndex = 2;
            btnEmployees.Text = "Employees";
            btnEmployees.TextAlign = ContentAlignment.MiddleRight;
            btnEmployees.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnAsset
            // 
            btnAsset.BackColor = Color.FromArgb(224, 224, 224);
            btnAsset.Dock = DockStyle.Top;
            btnAsset.FlatStyle = FlatStyle.Flat;
            btnAsset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAsset.ForeColor = Color.Black;
            btnAsset.Image = Properties.Resources.asset;
            btnAsset.Location = new Point(0, 115);
            btnAsset.Name = "btnAsset";
            btnAsset.Size = new Size(300, 77);
            btnAsset.TabIndex = 1;
            btnAsset.Text = "Asset";
            btnAsset.TextAlign = ContentAlignment.MiddleRight;
            btnAsset.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAsset.UseVisualStyleBackColor = false;
            btnAsset.Click += btnAssets_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.Black;
            btnDashboard.Image = Properties.Resources.dashboard__1_;
            btnDashboard.Location = new Point(0, 38);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(300, 77);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleRight;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.BackColor = Color.White;
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppTitle.ForeColor = Color.Black;
            lblAppTitle.Location = new Point(0, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(120, 38);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "IT Asset";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Black;
            pnlHeader.Controls.Add(lblPageTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = Color.FromArgb(224, 224, 224);
            pnlHeader.Location = new Point(300, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(778, 57);
            pnlHeader.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Dock = DockStyle.Fill;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.White;
            lblPageTitle.Location = new Point(0, 0);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(159, 38);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Dashboard";
            lblPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.WhiteSmoke;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(300, 57);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(778, 587);
            pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 644);
            Controls.Add(pnlContent);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            Name = "MainForm";
            Text = "IT Asset Manager";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Label lblAppTitle;
        private Button btnAssignments;
        private Button btnEmployees;
        private Button btnAsset;
        private Button btnDashboard;
        private Label lblPageTitle;
        
        private Button btnCategories;
    }
}