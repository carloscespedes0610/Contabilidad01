USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbTipoPlanDeleteCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbTipoPlanDeleteCarlos
END
GO


CREATE PROC Carlos.ctbTipoPlanDeleteCarlos @TipoPlanId int									   
AS
BEGIN
	IF EXISTS( SELECT TipoPlanId
			   FROM ctbTipoPlan
			   WHERE TipoPlanId = @TipoPlanId)
	BEGIN
		
		DELETE ctbTipoPlan
		WHERE TipoPlanId = @TipoPlanId
		
	END
	ELSE
	BEGIN
		RAISERROR('Id del Tipo Plan No Encontrado', 16, 1)
		RETURN
	END
END

--****************************************************************
exec Carlos.ctbTipoPlanDeleteCarlos 2
select * from ctbTipoPlan
