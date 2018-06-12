USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbTipoPlanInsertCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbTipoPlanInsertCarlos
END
GO


CREATE PROC Carlos.ctbTipoPlanInsertCarlos @Id int OUT,
										   @TipoPlanDes varchar(255),
										   @EstadoId int
AS
BEGIN
	IF NOT EXISTS ( SELECT TipoPlanDes
					FROM ctbTipoPlan	 
					WHERE TipoPlanDes = @TipoPlanDes)
	BEGIN
		INSERT INTO ctbTipoPlan(TipoPlanDes, EstadoId)
					VALUES (@TipoPlanDes,@EstadoId)
	
		SET @Id = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		RAISERROR('Descripción del Tipo Plan Duplicado', 16, 1)
		RETURN
    END 
END

--****************************************************************
declare @id int;
exec Carlos.ctbTipoPlanInsertCarlos @id out,'carlos9', 23
select @id

