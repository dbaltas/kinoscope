using System;
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
        private const string _DbFile = @"..\db\ob.db";

        private static FluentConfiguration _configuration = Fluently.Configure()
                        .Database(SQLiteConfiguration.Standard
                            .UsingFile(DbFile))
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Researcher>()
                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.PrimaryKey.Name.Is(x => "Id"))
                        .Conventions.Add(FluentNHibernate.Conventions.Helpers.ForeignKey.EndsWith("Id")));

        private static ISession _openSession;

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = _configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static void DropDatabase()
        {
            File.Delete(DbFile);
        }

        public static void BackupDatabase()
        {
            string dbDirectory = Path.GetDirectoryName(DbFile);
            string dbBackupDirectory = Path.Combine(dbDirectory, "backup");

            if (!Directory.Exists(dbBackupDirectory))
            {
                Directory.CreateDirectory(dbBackupDirectory);
            }
            //Version version = new Version(Application.ProductVersion);

            Version version = System.Reflection.Assembly.GetCallingAssembly().GetName().Version;
            string backupFile = string.Format("ob.{0:yyyyMMdd-HHmmss}-prior-to-{1}.{2}.{3}.db", DateTime.Now,
                version.Major,
                version.Minor,
                version.Build);
            File.Copy(DbFile, Path.Combine(dbBackupDirectory, backupFile));
        }

        public static bool DatabaseExists
        {
            get
            {
                return File.Exists(DbFile);
            }
        }

        public static string DbFile
        {
            get
            {
                return _DbFile;
            }
        }

        public static void CreateDatabaseWithSeedData()
        {
            BuildSchema();
            SeedData.AddInitialData();
        }

        public static void BuildSchema()
        {
            string dbDirectory = Path.GetDirectoryName(DbFile);
            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }
            if (DatabaseExists)
            {
                DropDatabase();
            }

            new SchemaExport(_configuration.BuildConfiguration())
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

