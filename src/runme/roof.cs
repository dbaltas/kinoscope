using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObLib.Domain;

using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Data.SQLite;

using DbMigrations;
	
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
                    case "behaviors":
                    case "b":
                        ListBehaviors();
                        break;
                    case "insert":
                        InsertProject();
                        break;
                    case "auth":
                        if (inputArgs.Length < 3)
                        {
                            System.Console.WriteLine("please provide valid username and password");
                            break;
                        }
                        AuthenticateResearcher(inputArgs[1].ToString(), inputArgs[2].ToString());
                        break;
                    case "find":
                        if (inputArgs.Length < 2)
                        {
                            System.Console.WriteLine("please provide researcher id after the find command");
                            break;
                        }
                        FindResearcherById(int.Parse(inputArgs[1]));
                        break;
                    case "all":
                        ListResearchers();
                        break;
                    case "m":
                    case "migrations":
                        Migrations();
                        break;
                    default:
                        DisplayMenu();
                        break;
                }
            }
        }

        private static void Migrations()
        {
            MigratorConsole console = new MigratorConsole();
            console.Perform();
        }

        private static void AuthenticateResearcher(string username, string password)
        {
            Researcher researcher = Researcher.Authenticate(username, password);
            if (researcher == null)
            {
                System.Console.WriteLine("error: user could not be authenticated");
                return;
            }
            System.Console.WriteLine("OK: user authenticated");
        }

        static private void DisplayMenu()
        {
            System.Console.WriteLine("*********************************");
            if (Researcher.Current != null)
            {
                System.Console.WriteLine(String.Format("Welcome {0}", 
                    Researcher.Current.Username));
            }
            else
            {
                System.Console.WriteLine("Welcome to Observador 0.0");
            }
            System.Console.WriteLine("");
            System.Console.WriteLine("  TYPE ONE of the available COMMANDS to get started:");
            System.Console.WriteLine("  exit: exit the program (aliases: 'quit', 'q', 'bye')");
            System.Console.WriteLine("  createdb: to create the database file (ob.db)");
            System.Console.WriteLine("  behaviors: list behaviors");
            System.Console.WriteLine("  insert: insert a new researcher and project(with default values, not customizable)");
            System.Console.WriteLine("  find [id]: find a researcher from the database. ex: 'find 1' brings the researcher with id=1");
            System.Console.WriteLine("  auth: authenticate researcher, provide username, password");
            System.Console.WriteLine("  all: display all researchers");
            System.Console.WriteLine("  migrations: load db.migrator (alias m)");
            System.Console.WriteLine("*********************************");
        }

        static private void CreateDb()
        {
            NHibernateHelper.BuildSchema();
            ObLib.SeedData.AddInitialData();
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
		
		static private void InsertProject()
		{
            Random rnd = new Random();
            var researcher = new Researcher { Username = "john" + rnd.Next(1, 10000).ToString(), Password = "123" };

            var project = new Project { Name = "my project" + rnd.Next(1, 10000).ToString() };
            var behavioralTestType = NHibernateHelper.OpenSession().Get<BehavioralTestType>(1);
            var behavioralTest = new BehavioralTest { Name = "first test", Project = project, BehavioralTestType = behavioralTestType};

            project.AddBehavioralTest(behavioralTest);
            researcher.AddProject(project);

            researcher.Save();

			System.Console.WriteLine("inserted new researcher with project!");
            FindResearcherById((int)researcher.Id);
		}

        static private void ListResearchers()
        {
            var researchers = Researcher.All();

            foreach (Researcher researcher in researchers)
            {
                FindResearcherById(researcher.Id);
            }
        }

		static private void FindResearcherById(int id)
		{
            Researcher researcher = NHibernateHelper.OpenSession().Get<Researcher>(id);
            if (researcher == null)
            {
                System.Console.WriteLine("no researcher with this ID");
                return;
            }
            System.Console.WriteLine("Researcher:");
            System.Console.WriteLine(String.Format("  username: {1}, id:{0}", researcher.Id, researcher.Username));
            System.Console.WriteLine("");
			System.Console.WriteLine("  projects:");
			/* lazy loading issue*/
			foreach (var project in researcher.Projects)
			{
                System.Console.WriteLine(String.Format("     name:{1} id:{0}", project.Id, project.Name));
                System.Console.WriteLine("     tests:"); 
                foreach (var behavioralTest in project.BehavioralTests)
                {
                    System.Console.WriteLine(String.Format("       name:{0}, {1}", behavioralTest.Name, behavioralTest.BehavioralTestType.Name));
                }
			}
            System.Console.WriteLine("");
            System.Console.WriteLine("");
        }

        static private void ListBehaviors()
        {
            var behaviors = Behavior.All();

            System.Console.WriteLine("Behaviors:");
            foreach (Behavior behavior in behaviors)
            {
                System.Console.WriteLine(String.Format("{0}, {3}, {1}, {2}", behavior.Name, behavior.Type, 
                    behavior.BehavioralTestType.Name, behavior.DefaultKeyStroke));
            }
        }
	}

