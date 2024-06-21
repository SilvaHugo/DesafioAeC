USE [DesafioAeC]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 6/20/2024 10:31:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[Id] [uniqueidentifier] NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[AlteradoEm] [datetime] NULL,
	[Cep] [char](8) NOT NULL,
	[Logradouro] [varchar](255) NOT NULL,
	[Complemento] [varchar](255) NULL,
	[Bairro] [varchar](255) NOT NULL,
	[Cidade] [varchar](255) NOT NULL,
	[Uf] [char](2) NOT NULL,
	[Numero] [varchar](255) NOT NULL,
	[UsuarioId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO

USE [DesafioAeC]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 6/20/2024 10:31:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [uniqueidentifier] NOT NULL,
	[CriadoEm] [datetime] NOT NULL,
	[AlteradoEm] [datetime] NULL,
	[Nome] [varchar](255) NOT NULL,
	[Login] [varchar](255) NOT NULL,
	[Senha] [varchar](255) NOT NULL
) ON [PRIMARY]
GO


