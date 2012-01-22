--Table: Researcher

--DROP TABLE Researcher;

CREATE TABLE Researcher (
  Id        integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  Username  nvarchar(50) NOT NULL UNIQUE,
  Password  nvarchar(50) NOT NULL,
  Tm        datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);


--Table: BehavioralTestType

--DROP TABLE BehavioralTestType;

CREATE TABLE BehavioralTestType (
  Id           integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  Description  nvarchar(50) NOT NULL UNIQUE,
  Tm           datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
);


--Table: Behavior

--DROP TABLE Behavior;

CREATE TABLE Behavior (
  Id                    integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  BehavioralTestTypeId  integer NOT NULL,
  Name                  nvarchar(50) NOT NULL,
  Type                  integer NOT NULL,
  DefaultKeyStroke      integer,
  Tm                    datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (BehavioralTestTypeId)
    REFERENCES BehavioralTestType(Id)
);


--Table: Project

--DROP TABLE Project;

CREATE TABLE Project (
  Id            integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  ResearcherId  integer NOT NULL,
  Name          nvarchar(50) NOT NULL,
  Tm            datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (ResearcherId)
    REFERENCES Researcher(Id)
);


--Table: SubjectGroup

--DROP TABLE SubjectGroup;

CREATE TABLE SubjectGroup (
  Id         integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  ProjectId  integer NOT NULL,
  Name       nvarchar(50) NOT NULL,
  Tm         datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (ProjectId)
    REFERENCES Project(Id)
);


--Table: Subject

--DROP TABLE Subject;

CREATE TABLE Subject (
  Id              integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  SubjectGroupId  integer NOT NULL,
  ProjectId       integer NOT NULL,
  Code            nvarchar(50) NOT NULL,
  Strain          nvarchar(50),
  Sex             integer,
  DateOfBirth     datetime,
  Origin          nvarchar(50),
  Weight          float(24),
  Tm              datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (ProjectId)
    REFERENCES Project(Id), 
  FOREIGN KEY (SubjectGroupId)
    REFERENCES SubjectGroup(Id)
);


--Table: ResearcherBehaviorKeyStrokes

--DROP TABLE ResearcherBehaviorKeyStrokes;

CREATE TABLE ResearcherBehaviorKeyStrokes (
  Id            integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  ResearcherId  integer NOT NULL,
  BehaviorId    integer NOT NULL,
  KeyStroke     integer NOT NULL,
  /* Foreign keys */
  FOREIGN KEY (ResearcherId)
    REFERENCES Researcher(Id), 
  FOREIGN KEY (BehaviorId)
    REFERENCES Behavior(Id)
);


--Table: BehavioralTest

--DROP TABLE BehavioralTest;

CREATE TABLE BehavioralTest (
  Id                    integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  ProjectId             integer NOT NULL,
  BehavioralTestTypeId  integer NOT NULL,
  Name                  nvarchar(50) NOT NULL,
  Tm                    datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (BehavioralTestTypeId)
    REFERENCES BehavioralTestType(Id), 
  FOREIGN KEY (ProjectId)
    REFERENCES Project(Id)
);

CREATE UNIQUE INDEX IDX_BehavioralTest_ProjectId_BehavioralTestTypeId_Unique
  ON BehavioralTest
  (ProjectId, BehavioralTestTypeId);


--Table: Session

--DROP TABLE Session;

CREATE TABLE Session (
  Id                integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  BehavioralTestId  integer NOT NULL,
  Name              nvarchar(50) NOT NULL,
  Tm                datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (BehavioralTestId)
    REFERENCES BehavioralTest(Id)
);


--Table: Trial

--DROP TABLE Trial;

CREATE TABLE Trial (
  Id         integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  SessionId  integer NOT NULL,
  Name       nvarchar(50) NOT NULL,
  Duration   integer NOT NULL,
  Tm         datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (SessionId)
    REFERENCES Session(Id)
);


--Table: Run

--DROP TABLE Run;

CREATE TABLE Run (
  Id         integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  TrialId    integer NOT NULL,
  SubjectId  integer NOT NULL,
  Tm         datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (SubjectId)
    REFERENCES Subject(Id), 
  FOREIGN KEY (TrialId)
    REFERENCES Trial(Id)
);

CREATE UNIQUE INDEX IDX_Run_TrialId_SubjectId_Unique
  ON Run
  (TrialId, SubjectId);


--Table: RunEvent

--DROP TABLE RunEvent;

CREATE TABLE RunEvent (
  Id          integer PRIMARY KEY AUTOINCREMENT NOT NULL,
  RunId       integer NOT NULL,
  BehaviorId  integer NOT NULL,
  Tm          datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  /* Foreign keys */
  FOREIGN KEY (BehaviorId)
    REFERENCES Behavior(Id), 
  FOREIGN KEY (RunId)
    REFERENCES Run(Id)
);


INSERT INTO Researcher(Id, Username, Password) values (1, 'Nikos', '123');	