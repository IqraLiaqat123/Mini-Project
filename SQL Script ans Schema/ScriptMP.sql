-- Script Date: 5/3/2019 2:43 PM  - ErikEJ.SqlCeScripting version 3.5.2.80
-- Database information:
-- Database: E:\6th semester\Mini-Project\FinalProjectA\bin\Debug\ProjectA.sqlite
-- ServerVersion: 3.24.0
-- DatabaseSize: 64 KB
-- Created: 5/3/2019 9:04 AM

-- User Table information:
-- Number of tables: 11
-- advisor: -1 row(s)
-- evaluation: -1 row(s)
-- group: -1 row(s)
-- groupevaluation: -1 row(s)
-- groupproject: -1 row(s)
-- groupstudent: -1 row(s)
-- lookup: -1 row(s)
-- person: -1 row(s)
-- project: -1 row(s)
-- projectadvisor: -1 row(s)
-- student: -1 row(s)

SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [project] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [description] text NULL
, [title] text NOT NULL
);
CREATE TABLE [lookup] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [value] text NOT NULL
, [category] text NOT NULL
);
CREATE TABLE [person] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [firstname] text NOT NULL
, [lastname] text NULL
, [contact] text NULL
, [email] text NOT NULL
, [dateofbirth] text NULL
, [gender] bigint NULL
, CONSTRAINT [FK_person_0_0] FOREIGN KEY ([gender]) REFERENCES [lookup] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [student] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [registrationno] text NOT NULL
, CONSTRAINT [FK_student_0_0] FOREIGN KEY ([id]) REFERENCES [person] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [group] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [created_on] text NOT NULL
, [Name] nvarchar(20) NULL COLLATE NOCASE
);
CREATE TABLE [groupstudent] (
  [groupid] INTEGER NOT NULL
, [studentid] INTEGER NOT NULL
, [status] bigint NOT NULL
, [assignmentdate] text NOT NULL
, CONSTRAINT [sqlite_autoindex_groupstudent_1] PRIMARY KEY ([groupid],[studentid])
, CONSTRAINT [FK_groupstudent_0_0] FOREIGN KEY ([studentid]) REFERENCES [student] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_groupstudent_1_0] FOREIGN KEY ([groupid]) REFERENCES [group] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_groupstudent_2_0] FOREIGN KEY ([status]) REFERENCES [lookup] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [groupproject] (
  [projectid] INTEGER NOT NULL
, [groupid] INTEGER NOT NULL
, [assignmentdate] text NOT NULL
, CONSTRAINT [sqlite_autoindex_groupproject_1] PRIMARY KEY ([projectid],[groupid])
, CONSTRAINT [FK_groupproject_0_0] FOREIGN KEY ([projectid]) REFERENCES [project] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_groupproject_1_0] FOREIGN KEY ([groupid]) REFERENCES [group] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [evaluation] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [name] text NOT NULL
, [totalmarks] bigint NOT NULL
, [totalweightage] bigint NOT NULL
);
CREATE TABLE [groupevaluation] (
  [groupid] INTEGER NOT NULL
, [evaluationid] INTEGER NOT NULL
, [obtainedmarks] bigint NOT NULL
, [evaluationdate] text NOT NULL
, CONSTRAINT [sqlite_autoindex_groupevaluation_1] PRIMARY KEY ([groupid],[evaluationid])
, CONSTRAINT [FK_groupevaluation_0_0] FOREIGN KEY ([groupid]) REFERENCES [group] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_groupevaluation_1_0] FOREIGN KEY ([evaluationid]) REFERENCES [evaluation] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [advisor] (
  [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [designation] bigint NOT NULL
, [salary] double NULL
, CONSTRAINT [FK_advisor_0_0] FOREIGN KEY ([designation]) REFERENCES [lookup] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [projectadvisor] (
  [advisorid] INTEGER NOT NULL
, [projectid] INTEGER NOT NULL
, [advisorrole] bigint NOT NULL
, [assignmentdate] text NOT NULL
, CONSTRAINT [sqlite_autoindex_projectadvisor_1] PRIMARY KEY ([advisorid],[projectid])
, CONSTRAINT [FK_projectadvisor_0_0] FOREIGN KEY ([advisorid]) REFERENCES [advisor] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_projectadvisor_1_0] FOREIGN KEY ([projectid]) REFERENCES [project] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
, CONSTRAINT [FK_projectadvisor_2_0] FOREIGN KEY ([advisorrole]) REFERENCES [lookup] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO [project] ([id],[description],[title]) VALUES (
1,'ab','ba');
INSERT INTO [project] ([id],[description],[title]) VALUES (
2,'AR','arglassess');
INSERT INTO [project] ([id],[description],[title]) VALUES (
3,'electron','robo');
INSERT INTO [project] ([id],[description],[title]) VALUES (
4,'lime','wireshark');
INSERT INTO [project] ([id],[description],[title]) VALUES (
5,'soldering','blink');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
1,'Male','GENDER');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
2,'Female','GENDER');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
3,'Active','STATUS');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
4,'InActive','STATUS');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
6,'Professor','DESIGNATION');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
7,'Associate Professor','DESIGNATION');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
8,'Assisstant Professor','DESIGNATION');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
9,'Lecturer','DESIGNATION');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
10,'Industry Professional','DESIGNATION');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
11,'Main Advisor','ADVISOR_ROLE');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
12,'Co-Advisror','ADVISOR_ROLE');
INSERT INTO [lookup] ([id],[value],[category]) VALUES (
14,'Industry Advisor','ADVISOR_ROLE');
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
1,'hello','bello','0321-4937082','a@gmail.com','Tuesday, March 26, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
2,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
3,'bisma','liaqat','0313-4937082','iqraliaqat6766@gmail.com','Wednesday, March 27, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
4,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
5,'almas','javaid','0313-4911414','almas@gmail.com','Wednesday, March 27, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
6,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
7,'Bisma','liaqat','0313-4937082','bisma@gmail.com','Monday, January 12, 1998',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
8,'almas','javaid','0312-4937082','almas@gmail.com','Tuesday, January 6, 1998',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
9,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
10,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
11,'almas','liaqat','0337-4937082','almas@gmail.com','Sunday, March 3, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
12,'gazala','tariq','0321-0000789','gazala@gmail.com','Saturday, March 2, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
13,'Asim','Rehmat','0335-4937028','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
14,'hell','hell','0355-4937082','hell@gmail.com','Wednesday, March 27, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
15,'anika','hassan','0313-4937082','anika@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
16,'anika','hassan','0313-4937082','anika@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
17,'anika','hassan','0313-4937082','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
18,'faria','iqbal','0335-7894568','faria@gmail.com','Tuesday, March 12, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
19,'almas','liaqat','0313-4911414','almas@gmail.com','Saturday, March 2, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
20,'bisma','javaid','0300-8096705','bisma@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
21,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
22,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
23,'asgahr','aslam','0314-4937028','a@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
24,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
25,'ali','zafar','0300-8036907','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
26,'laiba','zubair','0300-4937850','laiba@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
27,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
28,'shafaqat','ali','0313-4937028','ali@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
29,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
30,'iqra','liaqat','0335-4937082','iqra@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
31,'almas','liaqat','0306-4937082','almas@gmail.com','Friday, April 5, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
32,'anika','zafar','0300-0000002','a@gmail.com','Tuesday, April 2, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
33,'Asim','Rehmat','0335-4937028','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
34,'iqra','habib','0330-0101010','iqra@gmail.com','Saturday, April 6, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
35,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
36,'Asim','Rehmat','0335-4937028','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
37,'almas','javaid','0310-4937082','a@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
38,'iqra','liaqat','0335-4937082','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
39,'iqra','aslam','0335-4937082','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
40,'asim','rahmat','0335-4937083','ab@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
41,'ammi','but','0335-4300516','a@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
42,'asim','rahmat','0321-4937028','asim@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
44,'madiha','shahzadi','0335-4937081','a@gmail.com','Friday, April 26, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
45,'ali','zafar','0335-4937080','ali@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
47,'hira','iqbal','0321-4937083','hira@gmail.com','Sunday, March 31, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
48,'asim','rahmat','0321-4937084','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
49,'almas','javaid','0321-4937000','almas1@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
50,'almas','javaid','0321-4937086','almas@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
52,'asim','rahmat','0321-4330112','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
54,'asim','rahmat','0321-4330112','asim@gmail.com','Sunday, March 31, 2019',1);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
55,'','maham','0321-4937028','a@gmail.com','Friday, April 26, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
56,'iqra','liaqat','0321-4937028','a@gmail.com','Friday, April 26, 2019',2);
INSERT INTO [person] ([id],[firstname],[lastname],[contact],[email],[dateofbirth],[gender]) VALUES (
57,'ndm','sdnah','0321-4937082','a@gmail.com','Friday, April 26, 2019',2);
INSERT INTO [student] ([id],[registrationno]) VALUES (
30,'2016-CE-69');
INSERT INTO [student] ([id],[registrationno]) VALUES (
31,'2016-CE-51');
INSERT INTO [group] ([id],[created_on],[Name]) VALUES (
1,'Saturday, March 30, 2019','light');
INSERT INTO [group] ([id],[created_on],[Name]) VALUES (
2,'Sunday, March 31, 2019','minimum');
INSERT INTO [group] ([id],[created_on],[Name]) VALUES (
3,'Sunday, March 31, 2019','darkness');
INSERT INTO [group] ([id],[created_on],[Name]) VALUES (
4,'Friday, April 26, 2019','fdhdh');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
1,30,4,'Sunday, March 31, 2019');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,2,3,'2019-03-27');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,9,4,'2019-03-28');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,10,3,'2019-03-30');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,11,3,'Saturday, March 30, 2019');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,12,3,'Saturday, March 30, 2019');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
2,30,3,'Sunday, March 31, 2019');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
4,2,3,'2019-03-27');
INSERT INTO [groupstudent] ([groupid],[studentid],[status],[assignmentdate]) VALUES (
6,10,3,'2019-03-28');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
1,3,'Sunday, March 31, 2019');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
4,1,'Sunday, March 31, 2019');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
4,4,'Sunday, March 31, 2019');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
5,1,'Sunday, March 31, 2019');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
5,2,'Sunday, March 31, 2019');
INSERT INTO [groupproject] ([projectid],[groupid],[assignmentdate]) VALUES (
6,13,'Saturday, March 30, 2019');
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
1,'alpha',99,99);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
2,'beta',97,97);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
4,'ae',100,100);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
5,'good',1234,1234);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
6,'gamma',123,123);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
7,'charli',99,99);
INSERT INTO [evaluation] ([id],[name],[totalmarks],[totalweightage]) VALUES (
8,'iqra',59,59);
INSERT INTO [groupevaluation] ([groupid],[evaluationid],[obtainedmarks],[evaluationdate]) VALUES (
1,2,56,'Sunday, March 31, 2019');
INSERT INTO [advisor] ([id],[designation],[salary]) VALUES (
46,9,12340);
INSERT INTO [advisor] ([id],[designation],[salary]) VALUES (
52,6,150000);
INSERT INTO [advisor] ([id],[designation],[salary]) VALUES (
56,8,14526);
INSERT INTO [advisor] ([id],[designation],[salary]) VALUES (
57,10,2458);
INSERT INTO [projectadvisor] ([advisorid],[projectid],[advisorrole],[assignmentdate]) VALUES (
13,3,12,'Sunday, March 31, 2019');
INSERT INTO [projectadvisor] ([advisorid],[projectid],[advisorrole],[assignmentdate]) VALUES (
14,3,14,'Wednesday, April 3, 2019');
CREATE TRIGGER [fki_person_gender_lookup_id] BEFORE Insert ON [person] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table person violates foreign key constraint FK_person_0_0') WHERE NEW.gender IS NOT NULL AND(SELECT id FROM lookup WHERE  id = NEW.gender) IS NULL; END;
CREATE TRIGGER [fku_person_gender_lookup_id] BEFORE Update ON [person] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table person violates foreign key constraint FK_person_0_0') WHERE NEW.gender IS NOT NULL AND(SELECT id FROM lookup WHERE  id = NEW.gender) IS NULL; END;
CREATE TRIGGER [fki_student_id_person_id] BEFORE Insert ON [student] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table student violates foreign key constraint FK_student_0_0') WHERE (SELECT id FROM person WHERE  id = NEW.id) IS NULL; END;
CREATE TRIGGER [fku_student_id_person_id] BEFORE Update ON [student] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table student violates foreign key constraint FK_student_0_0') WHERE (SELECT id FROM person WHERE  id = NEW.id) IS NULL; END;
CREATE TRIGGER [fki_groupstudent_studentid_student_id] BEFORE Insert ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupstudent violates foreign key constraint FK_groupstudent_0_0') WHERE (SELECT id FROM student WHERE  id = NEW.studentid) IS NULL; END;
CREATE TRIGGER [fku_groupstudent_studentid_student_id] BEFORE Update ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupstudent violates foreign key constraint FK_groupstudent_0_0') WHERE (SELECT id FROM student WHERE  id = NEW.studentid) IS NULL; END;
CREATE TRIGGER [fki_groupstudent_groupid_group_id] BEFORE Insert ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupstudent violates foreign key constraint FK_groupstudent_1_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fku_groupstudent_groupid_group_id] BEFORE Update ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupstudent violates foreign key constraint FK_groupstudent_1_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fki_groupstudent_status_lookup_id] BEFORE Insert ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupstudent violates foreign key constraint FK_groupstudent_2_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.status) IS NULL; END;
CREATE TRIGGER [fku_groupstudent_status_lookup_id] BEFORE Update ON [groupstudent] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupstudent violates foreign key constraint FK_groupstudent_2_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.status) IS NULL; END;
CREATE TRIGGER [fki_groupproject_projectid_project_id] BEFORE Insert ON [groupproject] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupproject violates foreign key constraint FK_groupproject_0_0') WHERE (SELECT id FROM project WHERE  id = NEW.projectid) IS NULL; END;
CREATE TRIGGER [fku_groupproject_projectid_project_id] BEFORE Update ON [groupproject] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupproject violates foreign key constraint FK_groupproject_0_0') WHERE (SELECT id FROM project WHERE  id = NEW.projectid) IS NULL; END;
CREATE TRIGGER [fki_groupproject_groupid_group_id] BEFORE Insert ON [groupproject] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupproject violates foreign key constraint FK_groupproject_1_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fku_groupproject_groupid_group_id] BEFORE Update ON [groupproject] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupproject violates foreign key constraint FK_groupproject_1_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fki_groupevaluation_groupid_group_id] BEFORE Insert ON [groupevaluation] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupevaluation violates foreign key constraint FK_groupevaluation_0_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fku_groupevaluation_groupid_group_id] BEFORE Update ON [groupevaluation] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupevaluation violates foreign key constraint FK_groupevaluation_0_0') WHERE (SELECT id FROM group WHERE  id = NEW.groupid) IS NULL; END;
CREATE TRIGGER [fki_groupevaluation_evaluationid_evaluation_id] BEFORE Insert ON [groupevaluation] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table groupevaluation violates foreign key constraint FK_groupevaluation_1_0') WHERE (SELECT id FROM evaluation WHERE  id = NEW.evaluationid) IS NULL; END;
CREATE TRIGGER [fku_groupevaluation_evaluationid_evaluation_id] BEFORE Update ON [groupevaluation] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table groupevaluation violates foreign key constraint FK_groupevaluation_1_0') WHERE (SELECT id FROM evaluation WHERE  id = NEW.evaluationid) IS NULL; END;
CREATE TRIGGER [fki_advisor_designation_lookup_id] BEFORE Insert ON [advisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table advisor violates foreign key constraint FK_advisor_0_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.designation) IS NULL; END;
CREATE TRIGGER [fku_advisor_designation_lookup_id] BEFORE Update ON [advisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table advisor violates foreign key constraint FK_advisor_0_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.designation) IS NULL; END;
CREATE TRIGGER [fki_projectadvisor_advisorid_advisor_id] BEFORE Insert ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table projectadvisor violates foreign key constraint FK_projectadvisor_0_0') WHERE (SELECT id FROM advisor WHERE  id = NEW.advisorid) IS NULL; END;
CREATE TRIGGER [fku_projectadvisor_advisorid_advisor_id] BEFORE Update ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table projectadvisor violates foreign key constraint FK_projectadvisor_0_0') WHERE (SELECT id FROM advisor WHERE  id = NEW.advisorid) IS NULL; END;
CREATE TRIGGER [fki_projectadvisor_projectid_project_id] BEFORE Insert ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table projectadvisor violates foreign key constraint FK_projectadvisor_1_0') WHERE (SELECT id FROM project WHERE  id = NEW.projectid) IS NULL; END;
CREATE TRIGGER [fku_projectadvisor_projectid_project_id] BEFORE Update ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table projectadvisor violates foreign key constraint FK_projectadvisor_1_0') WHERE (SELECT id FROM project WHERE  id = NEW.projectid) IS NULL; END;
CREATE TRIGGER [fki_projectadvisor_advisorrole_lookup_id] BEFORE Insert ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Insert on table projectadvisor violates foreign key constraint FK_projectadvisor_2_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.advisorrole) IS NULL; END;
CREATE TRIGGER [fku_projectadvisor_advisorrole_lookup_id] BEFORE Update ON [projectadvisor] FOR EACH ROW BEGIN SELECT RAISE(ROLLBACK, 'Update on table projectadvisor violates foreign key constraint FK_projectadvisor_2_0') WHERE (SELECT id FROM lookup WHERE  id = NEW.advisorrole) IS NULL; END;
COMMIT;

