USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbTipoPlanUpdateCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbTipoPlanUpdateCarlos
END
GO


CREATE PROC Carlos.ctbTipoPlanUpdateCarlos @TipoPlanId int,
										   @TipoPlanDes varchar(255),
										   @EstadoId int
AS
BEGIN
	IF EXISTS( SELECT TipoPlanId
			   FROM ctbTipoPlan
			   WHERE TipoPlanId = @TipoPlanId)
	BEGIN
		IF NOT EXISTS ( SELECT TipoPlanDes
						FROM ctbTipoPlan	 
						WHERE TipoPlanDes = @TipoPlanDes)
		BEGIN
			UPDATE dbo.ctbTipoPlan
			SET		TipoPlanDes = @TipoPlanDes, 
					EstadoId = @EstadoId 
			WHERE   TipoPlanId = @TipoPlanId
		END
		ELSE
		BEGIN
			RAISERROR('Descripción del Tipo Plan Duplicado', 16, 1)
			RETURN
		END 
	END
	ELSE
	BEGIN
		RAISERROR('Id del Tipo Plan No Encontrado', 16, 1)
		RETURN
	END
END

--****************************************************************
exec Carlos.ctbTipoPlanUpdateCarlos 3,'carlosmod2', 23
select * from ctbTipoPlan
