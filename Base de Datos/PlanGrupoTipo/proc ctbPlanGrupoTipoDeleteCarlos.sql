USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoDeleteCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoDeleteCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoDeleteCarlos @PlanGrupoTipoId int									   
AS
BEGIN
	IF EXISTS( SELECT PlanGrupoTipoId
			   FROM ctbPlanGrupoTipo
			   WHERE PlanGrupoTipoId = @PlanGrupoTipoId)
	BEGIN
		
		DELETE ctbPlanGrupoTipo
		WHERE PlanGrupoTipoId = @PlanGrupoTipoId
		
	END
	ELSE
	BEGIN
		RAISERROR('Id del Tipo Plan Grupo No Encontrado', 16, 1)
		RETURN
	END
END

--****************************************************************
exec Carlos.ctbPlanGrupoTipoDeleteCarlos 4
select * from ctbPlanGrupoTipo
