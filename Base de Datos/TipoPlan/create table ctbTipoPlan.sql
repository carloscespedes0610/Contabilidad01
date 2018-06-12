select ctbTipoPlan.EstadoId,
		ctbTipoPlan.TipoPlanDes,
		ctbTipoPlan.EstadoId,
		parEstado.EstadoDes
from ctbTipoPlan LEFT JOIN parEstado ON ctbTipoPlan.EstadoId = parEstado.EstadoId

create table ctbTipoPlan(
	TipoPlanId int IDENTITY(1,1) PRIMARY KEY,
	TipoPlanDes varchar(255),
	EstadoId int not null
)