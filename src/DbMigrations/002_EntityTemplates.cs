using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(2)]
    public class CreateEntityTemplateTable : Migration
    {
        override public void Up()
        {
            Database.ExecuteNonQuery(@"
CREATE TABLE 'EntityTemplate' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, Entity TEXT, Template TEXT, unique (Name, Entity));
");
        }
        override public void Down()
        {
            Database.ExecuteNonQuery(@"
DROP TABLE 'EntityTemplate'
");
        }
    }
}