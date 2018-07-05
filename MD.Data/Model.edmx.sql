
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/05/2018 11:36:05
-- Generated from EDMX file: C:\Users\Malyuk\documents\visual studio 2015\Projects\MasterData\MD.Data\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MasterData];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NodeSet'
CREATE TABLE [dbo].[NodeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(65)  NULL,
    [Connection] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'DictionaryTypeSet'
CREATE TABLE [dbo].[DictionaryTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(35)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'NodeSet'
ALTER TABLE [dbo].[NodeSet]
ADD CONSTRAINT [PK_NodeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DictionaryTypeSet'
ALTER TABLE [dbo].[DictionaryTypeSet]
ADD CONSTRAINT [PK_DictionaryTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------