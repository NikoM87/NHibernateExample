using System;
using System.Windows.Forms;
using NHibirnateExample.Domain;

namespace NHibirnateExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var sess = NHibernateApp.OpenSession();
            sess.BeginTransaction();
            try
            {
                var category = new Category
                {
                    DisplayName = "Game"
                };

                var product = new Product
                {
                    Name = "Minesweeper",
                    Price = 300
                };
                category.AddProduct(product);
                sess.SaveOrUpdate(product);

                sess.Transaction.Commit();
            }
            catch
            {
                sess.Transaction.Rollback();
            }

            sess.BeginTransaction();
            try
            {
                var product = NHibernateApp.CurrentSession().Get<Product>(1);
                var order = new Order(product)
                {
                    NumberOfItems = 5,
                    Customer = "Shop"
                };
                NHibernateApp.CurrentSession().SaveOrUpdate(product);
                sess.Transaction.Commit();
            }
            catch
            {
                sess.Transaction.Rollback();
            }

            sess.BeginTransaction();
            try
            {
                var product = NHibernateApp.CurrentSession().Get<Product>(1);
                product.Orders.Clear();

                NHibernateApp.CurrentSession().SaveOrUpdate(product);
                sess.Transaction.Commit();
            }
            catch
            {
                sess.Transaction.Rollback();
            }
        }
    }
}