USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoUpdateCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoUpdateCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoUpdateCarlos @PlanGrupoTipoId int OUT,
												@PlanGrupoTipoCod varchar(50),
												@PlanGrupoTipoDes varchar(255),
												@PlanGrupoTipoEsp varchar(255),
												@EstadoId int
AS
BEGIN
	IF EXISTS( SELECT PlanGrupoTipoId
			   FROM ctbPlanGrupoTipo
			   WHERE PlanGrupoTipoId = @PlanGrupoTipoId)
	BEGIN
		IF NOT EXISTS ( SELECT PlanGrupoTipoCod
						FROM ctbPlanGrupoTipo	 
						WHERE PlanGrupoTipoCod = @PlanGrupoTipoCod)
		BEGIN
			UPDATE  ctbPlanGrupoTipo
			SET		PlanGrupoTipoCod = @PlanGrupoTipoCod,
					PlanGrupoTipoDes = @PlanGrupoTipoDes,
					PlanGrupoTipoEsp = @PlanGrupoTipoEsp, 
					EstadoId = @EstadoId 
			WHERE   PlanGrupoTipoId = @PlanGrupoTipoId
		END
		ELSE
		BEGIN
			RAISERROR('Código del Tipo Plan Grupo Duplicado', 16, 1)
			RETURN
		END 
	END
	ELSE
	BEGIN
		RAISERROR('Id del Tipo Plan Grupo No Encontrado', 16, 1)
		RETURN
	END
END

--****************************************************************
exec Carlos.ctbPlanGrupoTipoUpdateCarlos 4,'cacs mod','Carlos Cespedes mod','Carlos Alberto Cespedes Soliz mod', 100
select * from ctbPlanGrupoTipo
