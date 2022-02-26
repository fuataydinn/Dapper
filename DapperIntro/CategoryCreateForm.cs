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
    public partial class CategoryCreateForm : Form
    {
        public CategoryCreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var category = new Category()
            {
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = @"
insert into Categories (CategoryName, Description)
values (@categoryName, @description)";

                try
                {
                    // Anonymous Types
                    // Bir sınıfı olmayan nesne oluşturmak
                    // Dapper'a özgü bir özellik değil!! C# dilinin bir yeteneği
                    var parameters = new
                    {
                        categoryName = category.CategoryName,
                        description = category.Description
                    };

                    connection.Execute(sqlText, parameters); // ExecuteDapperIntro

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kaydetme sırasında bir hata meydana geldi\n\r" + ex.Message);
                }
            }
        }
    }
}
