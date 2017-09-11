USE master;  
GO  
CREATE DATABASE TestDB;  
GO

USE TestDB
GO

CREATE TABLE TestData (TestDataID int, Content NVARCHAR(128))

INSERT INTO TestData (TestDataID, Content) VALUES (1, N'Hello World')
INSERT INTO TestData (TestDataID, Content) VALUES (1, N'Hello World')
INSERT INTO TestData (TestDataID, Content) VALUES (1, N'Hello World')