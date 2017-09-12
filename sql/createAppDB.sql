CREATE DATABASE AppDb
GO
USE AppDb
GO
CREATE TABLE Stock (StockId int, ItemText NVARCHAR(128))
GO
INSERT INTO Stock (StockId, ItemText) VALUES (1, N'Coins')
INSERT INTO Stock (StockId, ItemText) VALUES (1, N'Stamps')
INSERT INTO Stock (StockId, ItemText) VALUES (1, N'Babysitters')