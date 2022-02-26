using Dapper;
using DapperIntro.DbHelpers;
using DapperIntro.Entities;
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

namespace DapperIntro
{
    public partial class CategoryUpdateForm : Form
    {
        private int _categoryId;

        /// <summary>
        /// Lütfen categoryId değerini Gridden seçin de gönderin
        /// </summary>
        /// <param name="categoryId"></param>
        public CategoryUpdateForm(int categoryId)
        {
            InitializeComponent();

            _categoryId = categoryId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                CategoryID = _categoryId,
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = @"
update Categories
set
    CategoryName = @name,
    Description = @description
where CategoryID = @id";

                var parameters = new
                {
                    id = category.CategoryID,
                    name = category.CategoryName,
                    description = category.Description
                };

                try
                {
                    connection.Execute(sqlText, parameters);
                    MessageBox.Show("Güncelleme başarılı");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata meydana geldi, tekrar deneyin\n" + ex.Message);
                }
            }
        }

        private void btnSave_Click_Alternative(object sender, EventArgs e)
        {
            var category = new Category()
            {
                CategoryID = _categoryId,
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = @"
update Categories
set
    CategoryName = @CategoryName,
    Description = @Description
where CategoryID = @CategoryID";

                try
                {
                    connection.Execute(sqlText, category);
                    MessageBox.Show("Güncelleme başarılı");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata meydana geldi, tekrar deneyin\n" + ex.Message);
                }
            }
        }

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {
            var category = default(Category);
            //Category category = null;

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = "select * from Categories where CategoryID = @id";

                // QueryFirst => Yazdığın sorgu bir veya birden fazla sonuç döndürme ihtimali varsa
                // ve sen result set içinden ilk kaydı okumak istiyorsan First (birinci, top 1)

                // QueryFirstOrDefault => Yazdığın sorgu sıfır veya daha fazla sonuç döndürme ihtimali
                // varsa ve result set içinden ilk kaydı ya da kayıt yoksa null değeri okumak istiyorsan

                // QuerySingle
                // QuerySingleOrDefault

                category = connection.QuerySingleOrDefault<Category>(
                    sqlText,
                    new { id = _categoryId });
            }

            if (category != null)
            {
                lblCategoryId.Text = category.CategoryID.ToString();
                txtCategoryName.Text = category.CategoryName;
                txtDescription.Text = category.Description;
            }
            else
            {
                MessageBox.Show("Güncellenmek istenen kayıt mevcut değil!");
                Close();
            }
        }
    }
}
