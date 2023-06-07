
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/07/2023 03:49:51
-- Generated from EDMX file: C:\Users\amirg\OneDrive\Рабочий стол\MyTrain\MyTrain\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyTrain];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Tickets_Routes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets_Routes];
GO
IF OBJECT_ID(N'[dbo].[FK_Places_Users1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_Places_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_Places_Wagons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Places] DROP CONSTRAINT [FK_Places_Wagons];
GO
IF OBJECT_ID(N'[dbo].[FK_Routes_Cities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Routes] DROP CONSTRAINT [FK_Routes_Cities];
GO
IF OBJECT_ID(N'[dbo].[FK_Routes_DepartureCities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Routes] DROP CONSTRAINT [FK_Routes_DepartureCities];
GO
IF OBJECT_ID(N'[dbo].[FK_Routes_Trains1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Routes] DROP CONSTRAINT [FK_Routes_Trains1];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_Places]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_Places];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_Wagons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_Wagons];
GO
IF OBJECT_ID(N'[dbo].[FK_Users_Role1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Role1];
GO
IF OBJECT_ID(N'[dbo].[FK_Wagons_Trains]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wagons] DROP CONSTRAINT [FK_Wagons_Trains];
GO
IF OBJECT_ID(N'[dbo].[FK_Wagons_Types1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Wagons] DROP CONSTRAINT [FK_Wagons_Types1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Places]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Places];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Routes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Routes];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[Trains]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trains];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Wagons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Wagons];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [UserId] int  NULL,
    [WagonId] int  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Routes'
CREATE TABLE [dbo].[Routes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DepartureDate] datetime  NOT NULL,
    [DepartureCityId] int  NOT NULL,
    [ArrivalCityId] int  NOT NULL,
    [ArrivalDate] datetime  NOT NULL,
    [TrainsId] int  NOT NULL,
    [PriceCoupe] decimal(18,2)  NOT NULL,
    [PriceEconom] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RouteId] int  NOT NULL,
    [WagonId] int  NOT NULL,
    [PlaceId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'Trains'
CREATE TABLE [dbo].[Trains] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(10)  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [MiddleName] nvarchar(max)  NULL,
    [NumberPhone] nvarchar(11)  NULL,
    [PassportData] nvarchar(10)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Wagons'
CREATE TABLE [dbo].[Wagons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Count] nvarchar(50)  NOT NULL,
    [TrainsId] int  NOT NULL,
    [TypeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [PK_Routes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trains'
ALTER TABLE [dbo].[Trains]
ADD CONSTRAINT [PK_Trains]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Wagons'
ALTER TABLE [dbo].[Wagons]
ADD CONSTRAINT [PK_Wagons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ArrivalCityId] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Routes_Cities]
    FOREIGN KEY ([ArrivalCityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Routes_Cities'
CREATE INDEX [IX_FK_Routes_Cities]
ON [dbo].[Routes]
    ([ArrivalCityId]);
GO

-- Creating foreign key on [DepartureCityId] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Routes_DepartureCities]
    FOREIGN KEY ([DepartureCityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Routes_DepartureCities'
CREATE INDEX [IX_FK_Routes_DepartureCities]
ON [dbo].[Routes]
    ([DepartureCityId]);
GO

-- Creating foreign key on [UserId] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_Places_Users1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Places_Users1'
CREATE INDEX [IX_FK_Places_Users1]
ON [dbo].[Places]
    ([UserId]);
GO

-- Creating foreign key on [WagonId] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [FK_Places_Wagons]
    FOREIGN KEY ([WagonId])
    REFERENCES [dbo].[Wagons]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Places_Wagons'
CREATE INDEX [IX_FK_Places_Wagons]
ON [dbo].[Places]
    ([WagonId]);
GO

-- Creating foreign key on [PlaceId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_Places]
    FOREIGN KEY ([PlaceId])
    REFERENCES [dbo].[Places]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_Places'
CREATE INDEX [IX_FK_Tickets_Places]
ON [dbo].[Tickets]
    ([PlaceId]);
GO

-- Creating foreign key on [RoleID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Role1]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Users_Role1'
CREATE INDEX [IX_FK_Users_Role1]
ON [dbo].[Users]
    ([RoleID]);
GO

-- Creating foreign key on [RouteId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK__Tickets_Routes]
    FOREIGN KEY ([RouteId])
    REFERENCES [dbo].[Routes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tickets_Routes'
CREATE INDEX [IX_FK__Tickets_Routes]
ON [dbo].[Tickets]
    ([RouteId]);
GO

-- Creating foreign key on [TrainsId] in table 'Routes'
ALTER TABLE [dbo].[Routes]
ADD CONSTRAINT [FK_Routes_Trains1]
    FOREIGN KEY ([TrainsId])
    REFERENCES [dbo].[Trains]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Routes_Trains1'
CREATE INDEX [IX_FK_Routes_Trains1]
ON [dbo].[Routes]
    ([TrainsId]);
GO

-- Creating foreign key on [UserId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_Users'
CREATE INDEX [IX_FK_Tickets_Users]
ON [dbo].[Tickets]
    ([UserId]);
GO

-- Creating foreign key on [WagonId] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_Wagons]
    FOREIGN KEY ([WagonId])
    REFERENCES [dbo].[Wagons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_Wagons'
CREATE INDEX [IX_FK_Tickets_Wagons]
ON [dbo].[Tickets]
    ([WagonId]);
GO

-- Creating foreign key on [TrainsId] in table 'Wagons'
ALTER TABLE [dbo].[Wagons]
ADD CONSTRAINT [FK_Wagons_Trains]
    FOREIGN KEY ([TrainsId])
    REFERENCES [dbo].[Trains]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Wagons_Trains'
CREATE INDEX [IX_FK_Wagons_Trains]
ON [dbo].[Wagons]
    ([TrainsId]);
GO

-- Creating foreign key on [TypeId] in table 'Wagons'
ALTER TABLE [dbo].[Wagons]
ADD CONSTRAINT [FK_Wagons_Types1]
    FOREIGN KEY ([TypeId])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Wagons_Types1'
CREATE INDEX [IX_FK_Wagons_Types1]
ON [dbo].[Wagons]
    ([TypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------