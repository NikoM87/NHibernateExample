using System;
using System.Linq;
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

            try
            {
                var q = NHibernateApp.CurrentSession().CreateCriteria<Product>();
                var list = q.List<Product>();

                foreach (var p in list.ToList())
                    richTextBox1.Text += p + Environment.NewLine;
            }
            catch
            {
                //
            }
        }
    }
}