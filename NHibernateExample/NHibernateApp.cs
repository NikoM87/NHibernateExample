using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibirnateExample
{
    public static class NHibernateApp
    {
        private const string DataBaseFile = "SQLite.db";
        private static readonly ISessionFactory SessionFactory = CreateAutoMappingSessionFactory();

        [ThreadStatic] private static ISession _currentSession;

        internal static ISessionFactory CreateAutoMappingSessionFactory()
        {
            return Fluently.Configure().Database(
                SQLiteConfiguration.Standard
                    .UsingFile(DataBaseFile)
                    .ShowSql()
                )
                .Mappings(m => m.AutoMappings.Add(new ModelGenerator().Generate()))
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