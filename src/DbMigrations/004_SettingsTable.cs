using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(4)]
    public class CreateSettingsTable : Migration
    {
        override public void Up()
        {
            Database.ExecuteNonQuery(@"
CREATE TABLE 'Settings' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, Value TEXT, unique (Name));
");
        }
        override public void Down()
        {
            Database.ExecuteNonQuery(@"
DROP TABLE 'Settings'
");
        }
    }
}