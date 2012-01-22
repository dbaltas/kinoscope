using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObLib.Domain;
using ObLib.Repositories;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Data.SQLite;
	
	class FirstProgram
	{
        static private void CreateDatabase()
        {
            var cfg = new Configuration();
            cfg.Configure();

            cfg.AddAssembly(typeof(Researcher).Assembly);

            new SchemaExport(cfg).Execute(true, true, false);

            System.Console.WriteLine("database created!");
        }

        static private void ExportDb()
        {
            NHibernateHelper.BuildSchema();
        }

        static private void GenerateFromScript()
		{
			StreamReader streamReader = new StreamReader("ob.sql");
			string sql = streamReader.ReadToEnd();
			streamReader.Close();

			SQLiteConnection.CreateFile("ob.db");
			SQLiteConnection connection = new SQLiteConnection("Data Source=ob.db");
			connection.Open();
			SQLiteCommand cmd = new SQLiteCommand(connection);
			cmd.CommandText = sql;
			cmd.ExecuteNonQuery();
			connection.Close();
			System.Console.WriteLine("created database file from sql file");		
		}
		
		static private void InsertResearcher()
		{
			Random rnd = new Random();
			var researcher = new Researcher { Username = "John"+rnd.Next(1,10000).ToString(), Password = "123" };
            //var repository = new DomainRepository<Researcher>();
            //repository.Add(researcher);
            NHibernateHelper.OpenSession().Save(researcher);
			System.Console.WriteLine("inserted new researcher!");
		}			
		
		static private void InsertProject()
		{
		// null reference thrown on addProject
            //using (var session = NHibernateHelper.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
		
					Random rnd = new Random();
					var researcher = new Researcher { Username = "John"+rnd.Next(1,10000).ToString(), Password = "123" };
					
					var project = new Project { Name = "my project"+rnd.Next(1,10000).ToString() };
					researcher.AddProject(project);
					NHibernateHelper.OpenSession().Save(researcher);
            //    }
            //}
			System.Console.WriteLine("inserted new project!");
            GetByUsername((int)researcher.Id);
		}		
		
		static private void GetByUsername(int id)
		{
            Researcher researcher = NHibernateHelper.OpenSession().Get<Researcher>(id);
			System.Console.WriteLine(researcher.Id);
			System.Console.WriteLine("projects:");
			/* lazy loading issue*/
			foreach (var project in researcher.Projects)
			{
				System.Console.WriteLine("     " + project.Id + project.Name);
			}
			System.Console.WriteLine("get by username!");
		}

		static void Main(string[] args)
		{
           //args = new string[] { "export" };
			System.Console.WriteLine("start");
			
			if (args.Length == 0) {
                //NHibernateHelper.OpenSession().
                //var repository = new DomainRepository<Researcher>();
                //System.Console.WriteLine(repository.Count().ToString());
				return;
			}
			if (args[0] == "export") {
				ExportDb();
			}
			if (args[0] == "find") {
				GetByUsername(int.Parse(args[1]));
			}
			if (args[0] == "insert") {
				InsertProject();
            }
			if (args[0] == "generate") {
				GenerateFromScript();
			}
			System.Console.WriteLine("end");
		}
	}

