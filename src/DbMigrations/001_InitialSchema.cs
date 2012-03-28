using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(1)]
    public class CreateInitialSchema : Migration
    {
        override public void Up()
        {
            //initial schema generation should go here
            // migration should be marked as already run on existing databases with production data
        }
        override public void Down()
        {
        }
    }
}