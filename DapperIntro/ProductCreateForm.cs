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
    public partial class ProductCreateForm : Form
    {
        public ProductCreateForm()
        {
            InitializeComponent();
        }

        private void ProductCreateForm_Load(object sender, EventArgs e)
        {
            FillCategoriesComboBox();
            FillSuppliersComboBox();
        }

        private void FillSuppliersComboBox()
        {
            var suppliers = Enumerable.Empty<Supplier>();

            using (var connection = DbConnectionFactory.Create())
            {
                try
                {
                    suppliers = connection.Query<Supplier>("select * from Suppliers");
                }
                catch (Exception)
                {
                    MessageBox.Show("Tedarikçi kayıtları getirilemedi");
                }
            }

            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "CompanyName";
            cmbSupplier.ValueMember = "SupplierId";
        }

        private void FillCategoriesComboBox()
        {
            var categories = Enumerable.Empty<Category>();

            using (var connection = DbConnectionFactory.Create())
            {
                try
                {
                    categories = connection.Query<Category>("select * from Categories");
                }
                catch (Exception)
                {
                    MessageBox.Show("Kategori kayıtları getirilemedi");
                }
            }

            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = CreateProductFromInputs();

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = @"INSERT INTO [dbo].[Products]
([ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock]
,[UnitsOnOrder],[ReorderLevel],[Discontinued])
VALUES
(@ProductName,@SupplierId,@CategoryId,@QuantityPerUnit,@UnitPrice,@UnitsInStock
,@UnitsOnOrder,@ReorderLevel,@Discontinued)";

                try
                {
                    connection.Execute(sqlText, product);
                }
                catch (Exception)
                {

                }
            }
        }

        private Product CreateProductFromInputs()
        {
            var product = new Product();
            product.ProductName = txtProductName.Text.Trim();
            product.SupplierId = cmbSupplier.SelectedItem != null
                ? (int)cmbSupplier.SelectedValue
                : default;
            product.CategoryId = cmbCategory.SelectedItem != null
                ? (int)cmbCategory.SelectedValue
                : default;
            product.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            product.UnitPrice = numUnitPrice.Value != 0 ? numUnitPrice.Value : default(decimal?);
            product.UnitsInStock = !string.IsNullOrWhiteSpace(txtUnitsInStock.Text)
                ? short.Parse(txtUnitsInStock.Text)
                : default(short?);
            product.UnitsOnOrder = !string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text)
                ? short.Parse(txtUnitsOnOrder.Text)
                : default(short?);
            product.ReorderLevel = !string.IsNullOrWhiteSpace(txtReorderLevel.Text)
                ? short.Parse(txtReorderLevel.Text)
                : default(short?);
            product.Discontinued = chkDiscontinued.Checked;

            return product;
        }
    }
}
