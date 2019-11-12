-- Create new database called 'Candy'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'Candy'
)
CREATE DATABASE Candy
GO

USE Candy

-- Create a new table called '[Candy]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Candy]', 'U') IS NOT NULL
DROP TABLE [dbo].[Candy]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Candy]
(
    [Id] INT IDENTITY NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(255) NOT NULL,
    [IsHard] BIT NOT NULL,
    [IsChocolate] BIT NOT NULL,
    [IsFruity] BIT NOT NULL,
    [Cost] INT NOT NULL,
    [WillTrade] BIT NOT NULL,
);
GO

-- Create a new table called '[User]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[DBO].[User]', 'U') IS NOT NULL
DROP TABLE [dbo].[User]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[User]
(
    [Id] INT IDENTITY NOT NULL PRIMARY KEY, -- Primary Key Columnn
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [SignUpDate] DATE NOT NULL,
    [IsActive] BIT NOT NULL
)
GO

-- Create a new table called '[UsersCandy]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[DBO].[UsersCandy]', 'U') IS NOT NULL
DROP TABLE [dbo].[UsersCandy]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[UsersCandy]
(
    [Id] INT IDENTITY NOT NULL PRIMARY KEY, -- Primary Key Columnn,
    [CandyId] INT NOT NULL
        FOREIGN KEY (CandyId)
        REFERENCES Candy (Id),
    [UserId] INT NOT NULL
        FOREIGN KEY (UserId)
        REFERENCES [User] (Id),
    [IsTraded] BIT NOT NULL
)
GO