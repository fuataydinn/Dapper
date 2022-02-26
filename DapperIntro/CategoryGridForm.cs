using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using DapperIntro.DbHelpers;
using DapperIntro.Entities;

namespace DapperIntro
{
    public partial class CategoryGridForm : Form
    {
        public CategoryGridForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillCategoriesGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var clickedRow = dataGridView1.Rows[e.RowIndex];

            // 1
            var idCell = clickedRow.Cells["CategoryID"];
            var categoryId = (int)idCell.Value;

            // 2
            //var category = (Category)clickedRow.DataBoundItem;
            //category.CategoryID

            var updateForm = new CategoryUpdateForm(categoryId);
            updateForm.FormClosed += UpdateForm_FormClosed;
            updateForm.Show();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillCategoriesGrid();
        }

        private void FillCategoriesGrid()
        {
            const string connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=Northwind; Integrated Security=true;";

            using (var connection = new SqlConnection(connectionString))
            {
                var categories = connection.Query<Category>("select * from Categories");

                // connection.Open()
                // command.ExecuteReader()
                // satır satır mapleme
                // dbReader dispose etti
                // connection.Close()

                //dataGridView1.DataSource = null;
                dataGridView1.DataSource = categories;
            }
        }

        public void RefreshGrid()
        {
            FillCategoriesGrid();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void contextItemUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var idCell = selectedRow.Cells["CategoryID"];
                var categoryId = (int)idCell.Value;

                var updateForm = new CategoryUpdateForm(categoryId);
                updateForm.FormClosed += UpdateForm_FormClosed;
                updateForm.Show();
            }
        }

        private void contextItemDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var dialogResult = MessageBox.Show(
                    "Bu kaydı silmek istediğinize emin misiniz?",
                    "Dikkat!",
                    MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var categoryId = (int)dataGridView1
                        .SelectedRows[0]
                        .Cells["CategoryID"]
                        .Value;

                    using (var connection = DbConnectionFactory.Create())
                    {
                        const string sqlText = "delete from Categories where CategoryID = @id";

                        try
                        {
                            connection.Execute(sqlText, new { id = categoryId });
                            FillCategoriesGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Kayıt silinemedi!");
                        }
                    }
                }
            }
        }
    }
}
