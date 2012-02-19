using System.IO;
using NHibernate;
using ObLib.Domain;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace ObLib.Domain
{
	public class NHibernateHelper
	{
        private const string DbFile = "ob.db";

        private static ISession _openSession;

        private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get
			{
				if (_sessionFactory == null)
				{
                    var configuration = Fluently.Configure()
                        .Database(SQLiteConfiguration.Standard
                            .UsingFile(DbFile))
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Researcher>()
                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.PrimaryKey.Name.Is(x => "Id")));

					_sessionFactory = configuration.BuildSessionFactory();
				}
				return _sessionFactory;
			}
		}

        public static void BuildSchema()
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            var configuration = Fluently.Configure()
                        .Database(SQLiteConfiguration.Standard
                            .UsingFile(DbFile))
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Researcher>()
                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.PrimaryKey.Name.Is(x => "Id")));
            new SchemaExport(configuration.BuildConfiguration())
                .Create(false, true);
        }

		public static ISession OpenSession()
		{
            if (_openSession == null)
            {
                _openSession = SessionFactory.OpenSession();
            }
            return _openSession;
		}
	}

}

