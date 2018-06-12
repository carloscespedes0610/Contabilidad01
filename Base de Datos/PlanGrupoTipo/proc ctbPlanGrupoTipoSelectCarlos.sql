USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoSelectCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoSelectCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoSelectCarlos @SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
