
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2015 11:17:30
-- Generated from EDMX file: \\psf\Home\Desktop\EmployeeEducationInfo-master\EmployeeEducationInfo.Model\EmployeeEducationInfo.edmx
-- --------------------------------------------------
IF exists(select * from sysdatabases where name='EmployeeEducationInfo')
DROP DATABASE [EmployeeEducationInfo]
GO

CREATE DATABASE [EmployeeEducationInfo] ON  PRIMARY 
( NAME = N'EmployeeEducationInfo', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EmployeeEducationInfo.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EmployeeEducationInfo_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\EmployeeEducationInfo_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EmployeeEducationInfo] SET COMPATIBILITY_LEVEL = 100
GO
ALTER DATABASE [EmployeeEducationInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeEducationInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeEducationInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeEducationInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeEducationInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeEducationInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeEducationInfo] SET  READ_WRITE 
GO
ALTER DATABASE [EmployeeEducationInfo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeEducationInfo] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeEducationInfo] SET PAGE_VERIFY CHECKSUM  
GO
USE [EmployeeEducationInfo]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [EmployeeEducationInfo] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO


SET QUOTED_IDENTIFIER OFF;
GO
USE [EmployeeEducationInfo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmployeeEducationInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EducationInfoSet] DROP CONSTRAINT [FK_EmployeeEducationInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EmployeeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeSet];
GO
IF OBJECT_ID(N'[dbo].[EducationInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EducationInfoSet];
GO
IF OBJECT_ID(N'[dbo].[AdminSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdminSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmployeeSet'
CREATE TABLE [dbo].[EmployeeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NULL,
    [Seniority] int  NULL,
    [IsDel] bit  NOT NULL
);
GO

-- Creating table 'EducationInfoSet'
CREATE TABLE [dbo].[EducationInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [Education] nvarchar(max)  NOT NULL,
    [IsDel] bit  NOT NULL,
    [EmployeeId] int  NOT NULL
);
GO

-- Creating table 'AdminSet'
CREATE TABLE [dbo].[AdminSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ErrorTime] int  NOT NULL,
    [IsDel] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EmployeeSet'
ALTER TABLE [dbo].[EmployeeSet]
ADD CONSTRAINT [PK_EmployeeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EducationInfoSet'
ALTER TABLE [dbo].[EducationInfoSet]
ADD CONSTRAINT [PK_EducationInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdminSet'
ALTER TABLE [dbo].[AdminSet]
ADD CONSTRAINT [PK_AdminSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'EducationInfoSet'
ALTER TABLE [dbo].[EducationInfoSet]
ADD CONSTRAINT [FK_EmployeeEducationInfo]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[EmployeeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeEducationInfo'
CREATE INDEX [IX_FK_EmployeeEducationInfo]
ON [dbo].[EducationInfoSet]
    ([EmployeeId]);
GO

set identity_insert [AdminSet] ON
INSERT INTO [dbo].[AdminSet] (Id,Name,Password,ErrorTime,IsDel) VALUES (1,'admin','admin',0,0);
set identity_insert [AdminSet] OFF
-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------