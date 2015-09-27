using System;
using System.Linq;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Environment = System.Environment;

namespace NHibirnateExample
{
    public partial class Form1 : Form
    {
        private ISession _sess;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof (Product).Assembly);

            var sessions = cfg.BuildSessionFactory();
            _sess = sessions.OpenSession();

            new SchemaExport(cfg).Create(true, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            var product = new Product
            {
                Name = "Minesweeper",
                Price = 300,
                Category = "Game"
            };
            _sess.Save(product);
            _sess.Flush();

            var q = _sess.CreateQuery("FROM Product");
            var list = q.List<Product>();

            foreach (var p in list.ToList())
                richTextBox1.Text += p + Environment.NewLine;
        }
    }
}