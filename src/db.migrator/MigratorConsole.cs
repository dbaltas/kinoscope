using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Migrator.Framework;
using Migrator.Tools;

using ObLib.Domain;

namespace db.migrator
{
	/// <summary>
	/// Commande line utility to run the migrations
	/// </summary>
	/// </remarks>
	public class MigratorConsole
	{
		private string _provider;
		private string _connectionString;
		private string _migrationsAssembly;
		private bool _list = false;
		private bool _trace = false;
		private bool _dryrun = false;
		private string _dumpTo;
		private long _migrateTo = -1;
		private string[] args;
		
		/// <summary>
		/// Builds a new console
		/// </summary>
		/// <param name="argv">Command line arguments</param>
		public MigratorConsole(string[] argv)
		{
            args = new string[] { "sqlite", @"Data Source=C:\workspace\projects\schema-migration\ob.db;Version=3;", @"C:\workspace\projects\schema-migration\migratordotnet-sample-on-.NET-4\bin\Release\migro.dll" };
			ParseArguments(args);
            _migrateTo = -1;
            Run();
            Console.ReadLine();
		}
		
		/// <summary>
		/// Run the migrator's console
		/// </summary>
		/// <returns>-1 if error, else 0</returns>
		public int Run()
		{
			try
			{
				if (_list)
					List();
				else if (_dumpTo != null)
					Dump();
				else
					Migrate();
			}
			catch (ArgumentException aex)
			{
				Console.WriteLine("Invalid argument '{0}' : {1}", aex.ParamName, aex.Message);
				Console.WriteLine();
				PrintUsage();
				return -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return -1;
			}
			return 0;
		}
		
		/// <summary>
		/// Runs the migrations.
		/// </summary>
		public void Migrate()
		{
			CheckArguments();
			
			Migrator mig = GetMigrator();
            if (mig.DryRun)
                mig.Logger.Log("********** Dry run! Not actually applying changes. **********");

			if (_migrateTo == -1)
				mig.MigrateToLastVersion();
			else
				mig.MigrateTo(_migrateTo);
		}
		
		/// <summary>
		/// List migrations.
		/// </summary>
		public void List()
		{
			CheckArguments();
			
			Migrator mig = GetMigrator();
			List<long> appliedMigrations = mig.AppliedMigrations;
			
			Console.WriteLine("Available migrations:");
			foreach (Type t in mig.MigrationsTypes)
			{
                long v = MigrationLoader.GetMigrationVersion(t);
				Console.WriteLine("{0} {1} {2}",
                                  appliedMigrations.Contains(v) ? "=>" : "  ",
				                  v.ToString().PadLeft(3),
				                  StringUtils.ToHumanName(t.Name)
				                 );
			}
		}
		
		public void Dump()
		{
			CheckArguments();
			
			SchemaDumper dumper = new SchemaDumper(_provider, _connectionString);
			
			dumper.DumpTo(_dumpTo);
		}
		
		/// <summary>
		/// Show usage information and help.
		/// </summary>
		public void PrintUsage()
		{
			int tab = 17;
			Version ver = Assembly.GetExecutingAssembly().GetName().Version;
			
			Console.WriteLine("Database migrator - v{0}.{1}.{2}", ver.Major, ver.Minor, ver.Revision);
			Console.WriteLine();
			Console.WriteLine("usage:\nMigrator.Console.exe provider connectionString migrationsAssembly [options]");
			Console.WriteLine();
			Console.WriteLine("\t{0} {1}", "provider".PadRight(tab), "The database provider (SqlServer, MySql, Postgre)");
			Console.WriteLine("\t{0} {1}", "connectionString".PadRight(tab), "Connection string to the database");
			Console.WriteLine("\t{0} {1}", "migrationAssembly".PadRight(tab), "Path to the assembly containing the migrations");
			Console.WriteLine("Options:");
			Console.WriteLine("\t-{0}{1}", "version NO".PadRight(tab), "To specific version to migrate the database to");
			Console.WriteLine("\t-{0}{1}", "list".PadRight(tab), "List migrations");
			Console.WriteLine("\t-{0}{1}", "trace".PadRight(tab), "Show debug informations");
			Console.WriteLine("\t-{0}{1}", "dump FILE".PadRight(tab), "Dump the database schema as migration code");
			Console.WriteLine("\t-{0}{1}", "dryrun".PadRight(tab), "Simulation mode (don't actually apply/remove any migrations)");
			Console.WriteLine();
		}
		
		#region Private helper methods
		private void CheckArguments()
		{
			if (_connectionString == null)
				throw new ArgumentException("Connection string missing", "connectionString");
			if (_migrationsAssembly == null)
				throw new ArgumentException("Migrations assembly missing", "migrationsAssembly");
		}
				
		private Migrator GetMigrator()
		{
			Assembly asm = Assembly.LoadFrom(_migrationsAssembly);
			
			Migrator migrator = new Migrator(_provider, _connectionString, asm, _trace);
			migrator.args = args;
		    migrator.DryRun = _dryrun;
			return migrator;
		}
				
		private void ParseArguments(string[] argv)
		{
			for (int i = 0; i < argv.Length; i++)
			{
				if (argv[i].Equals("-list"))
				{
					_list = true;
				}
				else if (argv[i].Equals("-trace"))
				{
					_trace = true;
				}
				else if (argv[i].Equals("-dryrun"))
				{
					_dryrun = true;
				}
				else if (argv[i].Equals("-version"))
				{
					_migrateTo = long.Parse(argv[i+1]);
					i++;
				}
				else if (argv[i].Equals("-dump"))
				{
					_dumpTo = argv[i+1];
					i++;
				}
				else
				{
					if (i == 0) _provider = argv[i];
					if (i == 1) _connectionString = argv[i];
					if (i == 2) _migrationsAssembly = argv[i];
				}
			}
		}
		#endregion
	}
}
