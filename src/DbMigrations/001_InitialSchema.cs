using Migrator.Framework;
using System.Data;

namespace DbMigrations
{
    [Migration(1)]
    public class CreateInitialSchema : Migration
    {
        private bool _pretendMigrationHasRunForProductionDatabasesOfPreviousVersion = true;
        override public void Up()
        {
            if (_pretendMigrationHasRunForProductionDatabasesOfPreviousVersion)
            {
                return;
            }

            //initial schema as of v0.1.6
            Database.ExecuteNonQuery(@"
CREATE TABLE 'Behavior' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, Type TEXT, DefaultKeyStroke TEXT, BehavioralTestTypeId INT,unique (DefaultKeyStroke, BehavioralTestTypeId), constraint FK40A3ABF5A56ADD5 foreign key (BehavioralTestTypeId) references 'BehavioralTestType');
CREATE TABLE 'BehavioralTest' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, ProjectId INT, BehavioralTestTypeId INT, constraint FKAA0E17A0C9B5218A foreign key (ProjectId) references 'Project', constraint FKAA0E17A05A56ADD5 foreign key (BehavioralTestTypeId) references 'BehavioralTestType');
CREATE TABLE 'BehavioralTestType' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, Description TEXT);
CREATE TABLE Foo (id INTEGER  PRIMARY KEY, street TEXT, city TEXT, state TEXT, postal_code TEXT);
CREATE TABLE 'Project' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, ResearcherId INT, constraint FKCFC6D85AE5125BB9 foreign key (ResearcherId) references 'Researcher');
CREATE TABLE 'Researcher' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Username TEXT unique, Password TEXT);
CREATE TABLE 'ResearcherBehaviorKeyStroke' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, KeyStroke TEXT, ResearcherId INT, BehaviorId INT,unique (ResearcherId, BehaviorId), constraint FKD198FBB6E5125BB9 foreign key (ResearcherId) references 'Researcher', constraint FKD198FBB6ED7AAF55 foreign key (BehaviorId) references 'Behavior');
CREATE TABLE 'Run' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, TmRun DATETIME, TrialId INT, SubjectId INT,unique (TrialId, SubjectId), constraint FKF2C9914233E9ACB0 foreign key (TrialId) references 'Trial', constraint FKF2C99142D4AD0C5 foreign key (SubjectId) references 'Subject');
CREATE TABLE 'RunEvent' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, TimeTracked BIGINT, RunId INT, BehaviorId INT, constraint FKEDCB3BD2CE223BEF foreign key (RunId) references 'Run', constraint FKEDCB3BD2ED7AAF55 foreign key (BehaviorId) references 'Behavior');
CREATE TABLE 'Session' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, BehavioralTestId INT, constraint FKBF1D3E3780F36455 foreign key (BehavioralTestId) references 'BehavioralTest');
CREATE TABLE 'Subject' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Code TEXT, Strain TEXT, Sex TEXT, DateOfBirth DATETIME, Origin TEXT, Weight NUMERIC, ProjectId INT, SubjectGroupId INT,unique (Code, ProjectId), constraint FK4A85719AC9B5218A foreign key (ProjectId) references 'Project', constraint FK4A85719A279AFFF7 foreign key (SubjectGroupId) references 'SubjectGroup');
CREATE TABLE 'SubjectGroup' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, ProjectId INT, constraint FK2C3EA5FCC9B5218A foreign key (ProjectId) references 'Project');
CREATE TABLE 'Trial' (Id  integer primary key autoincrement, TmCreated DATETIME, TmModified DATETIME, Name TEXT, Duration INT, SessionId INT, constraint FK6179086BB51C926A foreign key (SessionId) references 'Session');
"                );
        }
        override public void Down()
        {
        }

        public override void AfterUp()
        {
            base.AfterUp();

            if (_pretendMigrationHasRunForProductionDatabasesOfPreviousVersion)
            {
                return;
            }

            ObLib.SeedData.AddInitialData();
        }
    }
}