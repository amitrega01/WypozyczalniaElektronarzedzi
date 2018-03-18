
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2018 16:34:23
-- Generated from EDMX file: C:\Users\amitr\Desktop\WypozyczalniaElektronarzedzi\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Wypozyczalnia];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Pracownicy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pracownicy];
GO
IF OBJECT_ID(N'[dbo].[PunktObslugi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PunktObslugi];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pracownicy'
CREATE TABLE [dbo].[Pracownicy] (
    [PESEL] decimal(11,0)  NOT NULL,
    [Imie] nchar(20)  NULL,
    [Nazwisko] nchar(20)  NULL,
    [Haslo] nchar(10)  NULL,
    [PunktObslugi_IDPunktu] int  NOT NULL
);
GO

-- Creating table 'PunktObslugi'
CREATE TABLE [dbo].[PunktObslugi] (
    [IDPunktu] int IDENTITY(1,1) NOT NULL,
    [Ulica] nvarchar(max)  NOT NULL,
    [NrDomu] nvarchar(max)  NOT NULL,
    [Miasto] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PESEL] in table 'Pracownicy'
ALTER TABLE [dbo].[Pracownicy]
ADD CONSTRAINT [PK_Pracownicy]
    PRIMARY KEY CLUSTERED ([PESEL] ASC);
GO

-- Creating primary key on [IDPunktu] in table 'PunktObslugi'
ALTER TABLE [dbo].[PunktObslugi]
ADD CONSTRAINT [PK_PunktObslugi]
    PRIMARY KEY CLUSTERED ([IDPunktu] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PunktObslugi_IDPunktu] in table 'Pracownicy'
ALTER TABLE [dbo].[Pracownicy]
ADD CONSTRAINT [FK_PracownicyPunktObslugi]
    FOREIGN KEY ([PunktObslugi_IDPunktu])
    REFERENCES [dbo].[PunktObslugi]
        ([IDPunktu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PracownicyPunktObslugi'
CREATE INDEX [IX_FK_PracownicyPunktObslugi]
ON [dbo].[Pracownicy]
    ([PunktObslugi_IDPunktu]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------