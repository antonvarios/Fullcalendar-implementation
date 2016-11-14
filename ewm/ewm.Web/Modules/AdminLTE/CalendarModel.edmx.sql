
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/09/2016 02:38:03
-- Generated from EDMX file: C:\Users\abell\ownCloud\Personal\Anton\ewm 11.7.2016_2\ewm\ewm\ewm.Web\Modules\AdminLTE\CalendarModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ewm_Calednar_v1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClassesMembers_Classes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassesMembers] DROP CONSTRAINT [FK_ClassesMembers_Classes];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassesMembers_Members]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassesMembers] DROP CONSTRAINT [FK_ClassesMembers_Members];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[ClassesMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassesMembers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [StatusColor] nvarchar(max)  NOT NULL,
    [ClassName] nvarchar(max)  NOT NULL,
    [RepeatId] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClassesMembers'
CREATE TABLE [dbo].[ClassesMembers] (
    [Classes_Id] int  NOT NULL,
    [Members_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Classes_Id], [Members_Id] in table 'ClassesMembers'
ALTER TABLE [dbo].[ClassesMembers]
ADD CONSTRAINT [PK_ClassesMembers]
    PRIMARY KEY CLUSTERED ([Classes_Id], [Members_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Classes_Id] in table 'ClassesMembers'
ALTER TABLE [dbo].[ClassesMembers]
ADD CONSTRAINT [FK_ClassesMembers_Classes]
    FOREIGN KEY ([Classes_Id])
    REFERENCES [dbo].[Classes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Members_Id] in table 'ClassesMembers'
ALTER TABLE [dbo].[ClassesMembers]
ADD CONSTRAINT [FK_ClassesMembers_Members]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassesMembers_Members'
CREATE INDEX [IX_FK_ClassesMembers_Members]
ON [dbo].[ClassesMembers]
    ([Members_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------