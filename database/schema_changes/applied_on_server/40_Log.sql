/*
   Friday, 25 September 200912:11:06 PM
   User: 
   Server: localhost\sql2008
   Database: ShortestPath_dev
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.[Log] ADD
	Timestamp datetime NOT NULL CONSTRAINT DF_Log_Timestamp DEFAULT getDate()
GO
ALTER TABLE dbo.[Log] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
