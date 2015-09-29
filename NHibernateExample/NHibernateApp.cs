using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibirnateExample.Domain;

namespace NHibirnateExample
{
    public static class NHibernateApp
    {
        private const string DataBaseFile = "SQLite.db";
        private static readonly ISessionFactory SessionFactory = CreateFluentSessionFactory();

        [ThreadStatic] private static ISession _currentSession;

        internal static ISessionFactory CreateFluentSessionFactory()
        {
            return Fluently.Configure().Database(
                SQLiteConfiguration.Standard
                    .UsingFile(DataBaseFile)
                    .ShowSql()
                )
                .Mappings(
                    m => m.FluentMappings
                        .AddFromAssemblyOf<Product>()
                        .AddFromAssemblyOf<Category>()
                        .AddFromAssemblyOf<Order>()
                )
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            //if (!File.Exists(DataBaseFile))
            {
                new SchemaExport(config)
                    .Create(true, true);
            }
        }

        internal static ISessionFactory CreateXmlSessionFactory()
        {
            var cfg = new Configuration().Configure().AddAssembly(typeof (Product).Assembly);
            new SchemaExport(cfg).Create(true, true);
            return cfg.BuildSessionFactory();
        }

        public static ISession CurrentSession()
        {
            return _currentSession;
        }

        public static ISession OpenSession()
        {
            _currentSession = SessionFactory.OpenSession();
            return _currentSession;
        }
    }
}