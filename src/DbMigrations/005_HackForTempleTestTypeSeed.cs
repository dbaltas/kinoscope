using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(5)]
    public class SeedHackForTemple: Migration
    {
        override public void Up()
        {
        }
        override public void Down()
        {
        }

        public override void AfterUp()
        {
            base.AfterUp();

            ObLib.SeedData.HackForTempleBehavioralTestTypeAndBehaviors();
        }

    }
}