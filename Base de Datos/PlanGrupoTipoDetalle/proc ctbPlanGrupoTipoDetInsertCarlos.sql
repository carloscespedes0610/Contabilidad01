USE Jausi;
GO

IF(EXISTS(SELECT * FROM sys.objects WHERE name = 'ctbPlanGrupoTipoDetInsertCarlos'))
BEGIN
	DROP PROCEDURE Carlos.ctbPlanGrupoTipoDetInsertCarlos
END
GO


CREATE PROC Carlos.ctbPlanGrupoTipoDetInsertCarlos  @Id int OUT,
													@PlanGrupoTipoDetCod varchar(50),
													@PlanGrupoTipoDetDes varchar(255),
													@PlanGrupoTipoDetEsp varchar(255),
													@PlanGrupoTipoId int,
													@EstadoId int
AS
BEGIN
	IF NOT EXISTS ( SELECT PlanGrupoTipoDetId
					FROM ctbPlanGrupoTipoDet	 
					WHERE PlanGrupoTipoId = @PlanGrupoTipoId
						AND PlanGrupoTipoDetCod = @PlanGrupoTipoDetCod )
	BEGIN
		INSERT INTO	ctbPlanGrupoTipoDet	(
						PlanGrupoTipoId, 
						PlanGrupoTipoDetCod,
						PlanGrupoTipoDetDes,
						PlanGrupoTipoDetEsp,
						EstadoId)
					VALUES (@PlanGrupoTipoId,
						@PlanGrupoTipoDetCod,
						@PlanGrupoTipoDetDes,
						@PlanGrupoTipoDetEsp,
						@EstadoId)
	
		SET @Id = SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		RAISERROR('Detalle ya agregado al Tipo Plan Grupo', 16, 1)
		RETURN
    END 
END

--****************************************************************
declare @id int;
exec Carlos.ctbPlanGrupoTipoDetInsertCarlos @id out,
					'cacs cod', 'cacs des', 'cacs esp',1, 101
select @id

select * from dbo.ctbPlanGrupoTipoDet
