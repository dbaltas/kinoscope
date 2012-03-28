﻿using System.IO;
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
        private const string DbFile = @"..\db\ob.db";

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

        public static bool DatabaseExists()
        {
            return File.Exists(DbFile);
        }

        public static string GetDbFile()
        {
            return DbFile;
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
            if (DatabaseExists())
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

