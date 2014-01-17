USE [kadastro]
GO

/*	Trecho de Rollback do script:

DROP TABLE [kadastro].[dbo].[intervalo];
GO
DROP TABLE [kadastro].[dbo].[ponto];
GO
DROP TABLE [kadastro].[dbo].[usuario];
GO

SELECT * FROM [dbo].[usuario];
SELECT * FROM [dbo].[ponto];
SELECT * FROM [dbo].[intervalo];

*/

CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[login] [varchar](50) NOT NULL,
	[senha] [varchar](50) NOT NULL,
	[email] [varchar](100) NULL,
	[status] [char](1) NULL
)
GO

CREATE TABLE [dbo].[ponto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[dia] [smalldatetime] NOT NULL,
	[horas] [time](7) NULL
)
GO

CREATE TABLE [dbo].[intervalo](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[idPonto] [int] NOT NULL,
	[entrada] [time](7) NULL,
	[saida] [time](7) NULL
)
GO

ALTER TABLE [dbo].[usuario] ADD CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [dbo].[ponto] ADD CONSTRAINT [PK_ponto] PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [dbo].[ponto] ADD CONSTRAINT [FK_ponto_usuario] FOREIGN KEY([idUsuario]) REFERENCES [dbo].[usuario] ([id])
GO

ALTER TABLE [dbo].[intervalo] ADD CONSTRAINT [PK_intervalo] PRIMARY KEY CLUSTERED ([id] ASC)
GO

ALTER TABLE [dbo].[intervalo]  WITH NOCHECK ADD  CONSTRAINT [FK_intervalo_ponto] FOREIGN KEY([idPonto]) REFERENCES [dbo].[ponto] ([id])
GO

ALTER TABLE [dbo].[intervalo] CHECK CONSTRAINT [FK_intervalo_ponto]
GO