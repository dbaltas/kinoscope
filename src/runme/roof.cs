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
        static void Main(string[] args)
        {
            DisplayMenu();

            while (true)
            {

                string input = System.Console.ReadLine();
                string[] inputArgs = input.Split(' ');
                string command = inputArgs[0];

                switch (command)
                {
                    case "exit":
                    case "quit":
                    case "q":
                    case "bye":
                        return;
                    case "createdb":
                        CreateDb();
                        System.Console.WriteLine("a new SQLite database has been created");
                        break;
                    case "insert":
                        InsertProject();
                        break;
                    case "find":
                        if (inputArgs.Length < 2)
                        {
                            System.Console.WriteLine("please provide researcher id after the find command");
                            break;
                        }
                        FindResearcherById(int.Parse(inputArgs[1]));
                        break;
                    default:
                        DisplayMenu();
                        break;
                }
            }
        }

        static private void DisplayMenu()
        {
            System.Console.WriteLine("*********************************");
            System.Console.WriteLine("Welcome to Observador 0.0");
            System.Console.WriteLine("");
            System.Console.WriteLine("  type one of the available commands to get started:");
            System.Console.WriteLine("  exit: exit the program (aliases: 'quit', 'q', 'bye')");
            System.Console.WriteLine("  createdb: to create the database file (ob.db)");
            System.Console.WriteLine("  insert: insert a new researcher and project(with default values, not customizable)");
            System.Console.WriteLine("  find [id]: find a researcher from the database. ex: 'find 1' brings the researcher with id=1");
            System.Console.WriteLine("*********************************");
        }

        static private void CreateDb()
        {
            NHibernateHelper.BuildSchema();
        }

        static private void NotUsedGenerateFromScript()
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
            Random rnd = new Random();
            var researcher = new Researcher { Username = "John" + rnd.Next(1, 10000).ToString(), Password = "123" };

            var project = new Project { Name = "my project" + rnd.Next(1, 10000).ToString() };
            researcher.AddProject(project);
            NHibernateHelper.OpenSession().Save(researcher);

			System.Console.WriteLine("inserted new project!");
            FindResearcherById((int)researcher.Id);
		}		
		
		static private void FindResearcherById(int id)
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
	}

