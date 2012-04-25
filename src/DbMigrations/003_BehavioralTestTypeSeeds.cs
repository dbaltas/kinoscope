using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(3)]
    public class SeedBehavioralTestTypes : Migration
    {
        override public void Up()
        {
            Database.ExecuteNonQuery(@"
DELETE FROM ResearcherBehaviorKeystroke where behaviorID in (select id from Behavior where BehavioralTestTypeId in (2,3));
DELETE FROM Behavior where BehavioralTestTypeId in (2,3);
DELETE FROM BehavioralTestType where Id in (2,3);
");
        }
        override public void Down()
        {
        }

        public override void AfterUp()
        {
            base.AfterUp();

            ObLib.SeedData.PlusMazeBehavioralTestTypeAndBehaviors();
            ObLib.SeedData.ObjectRecognitionBehavioralTestTypeAndBehaviors();
        }

    }
}