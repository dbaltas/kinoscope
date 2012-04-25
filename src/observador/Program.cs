using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ObLib.Domain;

namespace observador
{
    static class Program
    {
        public static string GetTitle()
        {
            Version version = new Version(Application.ProductVersion);
            return string.Format(
                Properties.Settings.Default.TitleFormat,
                Application.ProductName,
                version.Major,
                version.Minor,
                version.Build);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Cursor.Current = Cursors.WaitCursor;

            DbMigrations.MigrationManager migrationManager = new DbMigrations.MigrationManager();

            if (!NHibernateHelper.DatabaseExists)
            {
                NHibernateHelper.CreateDatabaseDirectoryIfNotExist();
                if (MessageBox.Show("No Database Found. Click ok to Create new database. or cancel to exit.", GetTitle(), MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
                migrationManager.MigrateToLastRevision();
            }
            else
            {
                if (migrationManager.hasDetectedNewMigrations())
                {
                    if (MessageBox.Show(String.Format(@"The database schema has changed.
Click OK to backup the existing database and upgrade to the newer version, or Cancel to exit.
NOTE: After the upgrade the database will no longer be accessible through previous versions of {0}", Application.ProductName),
                    "Upgrade Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        NHibernateHelper.BackupDatabase();
                        migrationManager.MigrateToLastRevision();
                    }
                    else
                    {
                        return;
                    }
                }
                if (migrationManager.hasDetectedDatabaseWithNewerVersion())
                {
                    MessageBox.Show(String.Format(@"The database has been in use by a newer version of {0}.
Please upgrade {0}. The application will now exit", Application.ProductName),
                    "Database from a newer version detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Application.Run(new DashBoard());
        }
    }
}
