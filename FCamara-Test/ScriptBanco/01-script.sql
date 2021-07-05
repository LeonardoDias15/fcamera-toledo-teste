
CREATE DATABASE LeonardoTest;
go

use LeonardoTest;

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Funcionario] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(255) NULL,
    [CPF] nvarchar(11) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] nvarchar(1) NOT NULL,
    [Cep] nvarchar(8) NULL,
    [Endereco] nvarchar(100) NULL,
    [Bairro] nvarchar(60) NULL,
    [Numero] nvarchar(20) NULL,
    [Complemento] nvarchar(40) NULL,
    [Estado] nvarchar(40) NULL,
    [Cidade] nvarchar(max) NULL,
    [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
    [DataCadastro] datetime2 NOT NULL DEFAULT (getdate()),
    [DataAtualizacao] datetime2 NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [HistoricoAuditoria] (
    [Id] uniqueidentifier NOT NULL,
    [Funcionalidade] nvarchar(30) NULL,
    [Evento] nvarchar(20) NULL,
    [Dados] nvarchar(max) NULL,
    [IdentificadorFuncionalidade] uniqueidentifier NOT NULL,
    [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
    [DataCadastro] datetime2 NOT NULL DEFAULT (getdate()),
    [DataAtualizacao] datetime2 NULL,
    CONSTRAINT [PK_HistoricoAuditoria] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DependenteFuncionario] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] nvarchar(255) NULL,
    [CPF] nvarchar(11) NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Sexo] nvarchar(max) NULL,
    [FuncionarioId] uniqueidentifier NOT NULL,
    [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
    [DataCadastro] datetime2 NOT NULL DEFAULT (getdate()),
    [DataAtualizacao] datetime2 NULL,
    CONSTRAINT [PK_DependenteFuncionario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DependenteFuncionario_Funcionario_FuncionarioId] FOREIGN KEY ([FuncionarioId]) REFERENCES [Funcionario] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_DependenteFuncionario_FuncionarioId] ON [DependenteFuncionario] ([FuncionarioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210703225012_Initial-Migration', N'3.1.1');

GO

