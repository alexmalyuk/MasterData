
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/10/2018 12:25:41
-- Generated from EDMX file: C:\Users\Malyuk\Documents\Visual Studio 2015\Projects\MasterData\MD.Data\Model.edmx
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

IF OBJECT_ID(N'[dbo].[NodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NodeSet];
GO
IF OBJECT_ID(N'[dbo].[ContractorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractorSet];
GO
IF OBJECT_ID(N'[dbo].[ContractSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'NodeSet'
CREATE TABLE [dbo].[NodeSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'ContractorSet'
CREATE TABLE [dbo].[ContractorSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ContractSet'
CREATE TABLE [dbo].[ContractSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'ContractorSet'
ALTER TABLE [dbo].[ContractorSet]
ADD CONSTRAINT [PK_ContractorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContractSet'
ALTER TABLE [dbo].[ContractSet]
ADD CONSTRAINT [PK_ContractSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------