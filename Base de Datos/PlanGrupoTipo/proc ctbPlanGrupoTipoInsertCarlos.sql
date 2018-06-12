USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoInsertCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoInsertCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoInsertCarlos @Id int OUT,
												@PlanGrupoTipoCod varchar(50),
												@PlanGrupoTipoDes varchar(255),
												@PlanGrupoTipoEsp varchar(255),
												@EstadoId int
AS
BEGIN
	IF NOT EXISTS ( SELECT PlanGrupoTipoCod
					FROM ctbPlanGrupoTipo	 
					WHERE PlanGrupoTipoCod = @PlanGrupoTipoCod)
	BEGIN
		INSERT INTO		ctbPlanGrupoTipo(
						PlanGrupoTipoCod, 
						PlanGrupoTipoDes,
						PlanGrupoTipoEsp,
						EstadoId)
					VALUES (@PlanGrupoTipoCod,
						@PlanGrupoTipoDes,
						@PlanGrupoTipoEsp,
						@EstadoId)
	
		SET @Id = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		RAISERROR('Código del Tipo Plan Grupo Duplicado', 16, 1)
		RETURN
    END 
END

--****************************************************************
declare @id int;
exec Carlos.ctbPlanGrupoTipoInsertCarlos @id out,'CACS','Carlos Cespedes','Carlos Alberto Cespedes Soliz', 101
select @id

