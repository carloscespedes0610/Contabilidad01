USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbTipoPlanSelectCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbTipoPlanSelectCarlos
END
GO


CREATE PROC Carlos.ctbTipoPlanSelectCarlos @SQL varchar(MAX) 
AS
BEGIN
	EXEC(@SQL)
END
