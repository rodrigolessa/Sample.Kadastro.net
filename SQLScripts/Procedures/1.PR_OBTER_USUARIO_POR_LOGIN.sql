USE [kadastro]
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[PR_OBTER_USUARIO_POR_LOGIN]') AND type in (N'P', N'PC'))
BEGIN
    EXEC('CREATE PROCEDURE [PR_OBTER_USUARIO_POR_LOGIN] AS')
END
GO

ALTER PROCEDURE [PR_OBTER_USUARIO_POR_LOGIN]
      @Login AS VARCHAR(50)
AS

-- ==================================================
-- Autor:		Rodrigo Lessa
-- Criado em:	30/07/2014
-- Descrição:   
-- 		Listar usuário pelo login
-- Retorno:
-- 		Resultset com o registro encontrado
-- --------------------------------------------------
-- Modificado em: --
-- ==================================================
-- Códigos de Retorno:
-- ==================================================
-- Testes:
-- exec PR_OBTER_USUARIO_POR_LOGIN 'rodrigolessa'
-- ==================================================

BEGIN

    SELECT
     u.[Id]
    ,u.[Login]
    ,u.[Senha]
    ,u.[Email]
    ,u.[Status]
    FROM [kadastro].[dbo].[Usuario] u
    WHERE u.Login = @Login;

END