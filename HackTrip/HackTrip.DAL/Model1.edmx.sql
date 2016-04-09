
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2016 00:18:45
-- Generated from EDMX file: D:\work\trip\HackTrip\HackTrip.DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TripCollections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TripCollections];
GO
IF OBJECT_ID(N'[dbo].[TripSegments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TripSegments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TripCollections'
CREATE TABLE [dbo].[TripCollections] (
    [TripId] bigint  NOT NULL,
    [Origin] nvarchar(50)  NULL,
    [Destination] nvarchar(50)  NULL,
    [OriginPosi] nvarchar(100)  NULL,
    [DestinationPosi] nvarchar(100)  NULL,
    [OriginTime] datetime  NULL,
    [DestinationTime] datetime  NULL
);
GO

-- Creating table 'TripSegments'
CREATE TABLE [dbo].[TripSegments] (
    [SegmentID] bigint  NOT NULL,
    [SegmentType] tinyint  NULL,
    [Topic] nvarchar(50)  NULL,
    [StartTime] datetime  NULL,
    [CostSeconds] bigint  NULL,
    [Posi] nvarchar(100)  NULL,
    [Index] int  NULL,
    [TripID] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [TripId] in table 'TripCollections'
ALTER TABLE [dbo].[TripCollections]
ADD CONSTRAINT [PK_TripCollections]
    PRIMARY KEY CLUSTERED ([TripId] ASC);
GO

-- Creating primary key on [SegmentID] in table 'TripSegments'
ALTER TABLE [dbo].[TripSegments]
ADD CONSTRAINT [PK_TripSegments]
    PRIMARY KEY CLUSTERED ([SegmentID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------