USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoDetSelectCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoDetSelectCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoDetSelectCarlos @SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
