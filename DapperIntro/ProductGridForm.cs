using Dapper;
using DapperIntro.DbHelpers;
using DapperIntro.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperIntro
{
    public partial class ProductGridForm : Form
    {
        public ProductGridForm()
        {
            InitializeComponent();

            grdProducts.AutoGenerateColumns = false;
        }

        private void ProductGridForm_Load(object sender, EventArgs e)
        {
            // Ön bilgi; inteface'lerin instance'ı alınamaz
            // Ancak o interface'i implement etmiş bir sınıftan instance alınabilir

            // Peki neden ısrarla products değişkeni için bir ilk değer (ilk instance) oluşturmaya
            // çalışıyorum da doğrudan null olarak ilk değerini atamıyorum?
            // Programlama örf/adetleri gereği; koleksiyon cinsinden bir değişken, field, property asla
            // null değer tutmamalı, koleksiyon cinsinden dönüş tipine sahip bir metot null değer döndürmemeli.

            // Bir koleksiyonun elemanlarının olmaması durumu null ile değil boş bir koleksiyon olarak
            // ifade edilmeli
            IEnumerable<Product> products = new List<Product>();

            using (var connection = DbConnectionFactory.Create())
            {
                const string sqlText = "select * from Products";

                try
                {
                    products = connection.Query<Product>(sqlText);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kayıtlar getirilemedi");
                    Close();
                }
            }

            grdProducts.DataSource = products;
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>();
            

            //
            //
            //
            //

            return products;
        }
    }
}
