
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/26/2023 19:02:42
-- Generated from EDMX file: C:\Users\Alumnos MCSD Tarde\source\repos\IvanAlonsoVera\ProyectosASP\TiendaAnimalesEntity\TiendaAnimalesEntity\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PetStore];
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

-- Creating table 'Personas'
CREATE TABLE [dbo].[Personas] (
    [Id_Persona] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clase_Animales'
CREATE TABLE [dbo].[Clase_Animales] (
    [Id_Clase] int IDENTITY(1,1) NOT NULL,
    [Nombre_Clase] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Mascotas'
CREATE TABLE [dbo].[Mascotas] (
    [Id_Mascota] int IDENTITY(1,1) NOT NULL,
    [Dueño] int  NOT NULL,
    [Clase] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Persona_Id_Persona] int  NOT NULL,
    [Clase_Animal_Id_Clase] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_Persona] in table 'Personas'
ALTER TABLE [dbo].[Personas]
ADD CONSTRAINT [PK_Personas]
    PRIMARY KEY CLUSTERED ([Id_Persona] ASC);
GO

-- Creating primary key on [Id_Clase] in table 'Clase_Animales'
ALTER TABLE [dbo].[Clase_Animales]
ADD CONSTRAINT [PK_Clase_Animales]
    PRIMARY KEY CLUSTERED ([Id_Clase] ASC);
GO

-- Creating primary key on [Id_Mascota] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [PK_Mascotas]
    PRIMARY KEY CLUSTERED ([Id_Mascota] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Persona_Id_Persona] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [FK_PersonaMascota]
    FOREIGN KEY ([Persona_Id_Persona])
    REFERENCES [dbo].[Personas]
        ([Id_Persona])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaMascota'
CREATE INDEX [IX_FK_PersonaMascota]
ON [dbo].[Mascotas]
    ([Persona_Id_Persona]);
GO

-- Creating foreign key on [Clase_Animal_Id_Clase] in table 'Mascotas'
ALTER TABLE [dbo].[Mascotas]
ADD CONSTRAINT [FK_Clase_AnimalMascota]
    FOREIGN KEY ([Clase_Animal_Id_Clase])
    REFERENCES [dbo].[Clase_Animales]
        ([Id_Clase])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clase_AnimalMascota'
CREATE INDEX [IX_FK_Clase_AnimalMascota]
ON [dbo].[Mascotas]
    ([Clase_Animal_Id_Clase]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------