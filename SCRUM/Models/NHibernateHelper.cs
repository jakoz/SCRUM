using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCRUM.Models
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
            set
            {
            }
        }
        public static void InitializeSessionFactory()
        {       
            _sessionFactory = Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("Scrum.db").ConnectionString("Data Source=C:\\Databases\\Scrum.db;Version=3;New=True;FailIfMissing=True;")).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Task>()).ExposeConfiguration(BuildSchema).BuildSessionFactory();
        }
        private static void BuildSchema(Configuration cfg)
        {
            new SchemaUpdate(cfg).Execute(false, true);
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
}