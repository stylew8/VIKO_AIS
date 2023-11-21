IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Person] (
    [Id] int NOT NULL IDENTITY,
    [Login] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Premissions] nvarchar(max) NULL,
    [Valstybe] nvarchar(max) NULL,
    [Miestas] nvarchar(max) NULL,
    [Gatve] nvarchar(max) NULL,
    [StudPastas] nvarchar(max) NULL,
    [Telefonas] nvarchar(max) NULL,
    [AsmPastas] nvarchar(max) NULL,
    [Fakultetas] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [Surname] nvarchar(max) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Grupe] nvarchar(max) NULL,
    [Kursas] nvarchar(max) NULL,
    [Semesrtas] int NULL,
    [Programa] nvarchar(max) NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Dalykas] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [lecturerId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Dalykas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dalykas_Person_lecturerId] FOREIGN KEY ([lecturerId]) REFERENCES [Person] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Marks] (
    [Id] int NOT NULL IDENTITY,
    [Mark] int NOT NULL,
    [DalykoId] int NOT NULL,
    [StudentId] int NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [DateOfMark] datetime2 NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Marks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Marks_Dalykas_DalykoId] FOREIGN KEY ([DalykoId]) REFERENCES [Dalykas] ([Id]) ON DELETE NO ACTION,
);
GO

CREATE TABLE [Programm] (
    [Id] int NOT NULL IDENTITY,
    [Semestras] int NOT NULL,
    [Kursas] int NOT NULL,
    [DalykoId] int NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_Programm] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Programm_Dalykas_DalykoId] FOREIGN KEY ([DalykoId]) REFERENCES [Dalykas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Marks_Person_StudentId] FOREIGN KEY ([StudentId]) REFERENCES [Person] ([Id]) ON DELETE NO ACTION;
);
GO

CREATE INDEX [IX_Dalykas_lecturerId] ON [Dalykas] ([lecturerId]);
GO

CREATE INDEX [IX_Marks_DalykoId] ON [Marks] ([DalykoId]);
GO

CREATE INDEX [IX_Marks_StudentId] ON [Marks] ([StudentId]);
GO

CREATE INDEX [IX_Programm_DalykoId] ON [Programm] ([DalykoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231116223929_xxx', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Person].[Semesrtas]', N'Semestras', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231116231614_UpdateDeleteBehavior', N'7.0.0');
GO

COMMIT;
GO

