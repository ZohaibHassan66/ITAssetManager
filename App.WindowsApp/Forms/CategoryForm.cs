using App.Core.Services;

namespace App.WindowsApp.Forms
{
    public partial class CategoryForm : Form
    {
        private readonly CategoryService _categoryService;

        public CategoryForm(string connString)
        {
            _categoryService = new CategoryService(connString);
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories();
            dgvCategories.DataSource = null;
            dgvCategories.Rows.Clear();
            dgvCategories.Columns.Clear();

            dgvCategories.Columns.Add("CategoryID", "ID");
            dgvCategories.Columns.Add("CategoryName", "Category Name");
            dgvCategories.Columns["CategoryID"].Width = 80;

            foreach (var cat in categories)
            {
                dgvCategories.Rows.Add(cat.CategoryID, cat.CategoryName);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name should not be empty!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _categoryService.AddCategory(txtCategoryName.Text.Trim());
            txtCategoryName.Clear();
            LoadCategories();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select Category First!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells["CategoryID"].Value);
            var confirm = MessageBox.Show("Are you sure you want to delete?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _categoryService.DeleteCategory(id);
                    LoadCategories();
                    MessageBox.Show("Category Deleted!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Its can`t be delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
    }
