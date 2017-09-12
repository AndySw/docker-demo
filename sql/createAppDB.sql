CREATE DATABASE AppDB
GO
USE AppDB
GO
CREATE TABLE Stock (StockID int, ItemText NVARCHAR(128))
GO
INSERT INTO Stock (StockID, ItemText) VALUES (1, N'Coins')
INSERT INTO Stock (StockID, ItemText) VALUES (1, N'Stamps')
INSERT INTO Stock (StockID, ItemText) VALUES (1, N'Babysitters')