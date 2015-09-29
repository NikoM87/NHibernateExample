using System;
using System.Windows.Forms;
using NHibernate.Criterion;
using NHibirnateExample.Domain;
using Order = NHibirnateExample.Domain.Order;

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

                category.AddProduct(new Product
                {
                    Name = "Minesweeper",
                    Price = 300
                });

                category.AddProduct(new Product
                {
                    Name = "Pinball",
                    Price = 500
                });

                sess.SaveOrUpdate(category);

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

            var criteria = NHibernateApp.CurrentSession().CreateCriteria<Product>();
            criteria.Add(Restrictions.Between("Price", 200, 400));

            var result = criteria.List<Product>();
            foreach (var product in result)
            {
                richTextBox1.Text += product + Environment.NewLine;
            }
        }
    }
}