using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(2)]
    public class CreateFooTable : Migration
    {
        override public void Up()
        {
            //this is a dummy test
            Database.AddTable("Foo",
                new Column("id", DbType.Int32, ColumnProperty.PrimaryKey),
                new Column("street", DbType.String, 50),
                new Column("city", DbType.String, 50),
                new Column("state", DbType.StringFixedLength, 2),
                new Column("postal_code", DbType.String, 10)
            );
        }
        override public void Down()
        {
        }
    }
}