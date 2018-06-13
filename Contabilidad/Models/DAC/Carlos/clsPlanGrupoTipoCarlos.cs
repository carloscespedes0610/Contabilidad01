using Contabilidad.Models.VM.Carlos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.DAC.Carlos
{
    public class clsPlanGrupoTipoCarlos: clsBase, IDisposable
    {
        public clsPlanGrupoTipoVMCarlos VM;

        //******************************************************
        //* The following enumerations will change for each
        //* data access class
        //******************************************************
        public enum SelectFilters : byte
        {
            All = 0,
            RowCount = 1,
            ListBox = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum WhereFilters : byte
        {
            None = 0,
            PrimaryKey = 1,
            PlanGrupoTipoCod = 2,
            PlanGrupoTipoDes = 3,
            Grid = 4,
            GridCheck = 5,
            EstadoId = 6,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            PlanGrupoTipoId = 1,
            PlanGrupoTipoCod = 2,
            Grid = 3,
            GridCheck = 4
        }

        public enum InsertFilters : byte
        {
            All = 0
        }

        public enum UpdateFilters : byte
        {
            All = 0
        }

        public enum DeleteFilters : byte
        {
            All = 0
        }

        public enum RowCountFilters : byte
        {
            All = 0
        }

        //*********************************************************
        //* The following filters will change for each
        //* data access class
        //*********************************************************
        private SelectFilters mintSelectFilter;
        private WhereFilters mintWhereFilter;
        private OrderByFilters mintOrderByFilter;
        private InsertFilters mintInsertFilter;
        private UpdateFilters mintUpdateFilter;
        private DeleteFilters mintDeleteFilter;
        private RowCountFilters mintRowCountFilter;

        public SelectFilters SelectFilter
        {
            get
            {
                return mintSelectFilter;
            }

            set
            {
                mintSelectFilter = value;
            }
        }

        public WhereFilters WhereFilter
        {
            get
            {
                return mintWhereFilter;
            }

            set
            {
                mintWhereFilter = value;
            }
        }

        public OrderByFilters OrderByFilter
        {
            get
            {
                return mintOrderByFilter;
            }

            set
            {
                mintOrderByFilter = value;
            }
        }

        public InsertFilters InsertFilter
        {
            get
            {
                return mintInsertFilter;
            }

            set
            {
                mintInsertFilter = value;
            }
        }

        public UpdateFilters UpdateFilter
        {
            get
            {
                return mintUpdateFilter;
            }

            set
            {
                mintUpdateFilter = value;
            }
        }

        public DeleteFilters DeleteFilter
        {
            get
            {
                return mintDeleteFilter;
            }

            set
            {
                mintDeleteFilter = value;
            }
        }

        public RowCountFilters RowCountFilter
        {
            get
            {
                return mintRowCountFilter;
            }

            set
            {
                mintRowCountFilter = value;
            }
        }

        //************************************************************
        //* Method Name  : New()
        //* Syntax       : Constructor
        //* Parameters   : None
        //*
        //* Description  : This event is called when the object is created.
        //* It can be used to initialize private data variables.
        //*
        //************************************************************
        public clsPlanGrupoTipoCarlos()
        {
            mstrTableName = "ctbPlanGrupoTipo";
            mstrClassName = "clsPlanGrupoTipoCarlos";

            PropertyInit();
            FilterInit();
        }

        public clsPlanGrupoTipoCarlos(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPlanGrupoTipoCarlos(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPlanGrupoTipoCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPlanGrupoTipoCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPlanGrupoTipoCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsPlanGrupoTipoVMCarlos();

            VM.PlanGrupoTipoId = 0;
            VM.PlanGrupoTipoCod = "";
            VM.PlanGrupoTipoDes = "";
            VM.PlanGrupoTipoEsp = "";
            VM.EstadoId = 0;
            VM.EstadoDes = "";
        }

        protected override void SetPrimaryKey()
        {
            VM.PlanGrupoTipoId = mlngId;
        }

        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "Carlos.ctbPlanGrupoTipoSelectCarlos";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = " SELECT  " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoId, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoCod, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoDes," +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoEsp," +
                           "    ctbPlanGrupoTipo.EstadoId" +
                           " FROM ctbPlanGrupoTipo ";
                    break;

                case SelectFilters.ListBox:
                    strSQL = " SELECT  " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoId, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoCod, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoDes," +
                           " FROM ctbPlanGrupoTipo ";
                    break;

                case SelectFilters.Grid:
                    strSQL = " SELECT  " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoId, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoCod, " +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoDes," +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoEsp," +
                           "    ctbPlanGrupoTipo.EstadoId," +
                           "    parEstado.EstadoDes  " +
                           " FROM ctbPlanGrupoTipo ";
                    break;

                case SelectFilters.GridCheck:
                    break;
            }

            strSQL += WhereFilterGet() + OrderByFilterGet();

            Array.Resize(ref moParameters, 1);
            moParameters[0] = new SqlParameter("SQL", strSQL);
        }

        private string WhereFilterGet()
        {
            string strSQL = null;

            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    strSQL = " WHERE PlanGrupoTipoId = " + SysData.NumberToField(VM.PlanGrupoTipoId);
                    break;

                case WhereFilters.PlanGrupoTipoCod:
                    strSQL = " WHERE PlanGrupoTipoCod = " + SysData.StringToField(VM.PlanGrupoTipoCod);
                    break;

                case WhereFilters.PlanGrupoTipoDes:
                    strSQL = " WHERE TipoPlanDes = " + SysData.StringToField(VM.PlanGrupoTipoDes);
                    break;

                case WhereFilters.Grid:
                    strSQL = " LEFT JOIN parEstado ON ctbPlanGrupoTipo.EstadoId = parEstado.EstadoId ";
                    break;

                case WhereFilters.EstadoId:
                    strSQL = " WHERE EstadoId = " + SysData.NumberToField(VM.EstadoId);
                    break;

                case WhereFilters.GridCheck:
                    break;
            }

            return strSQL;
        }

        private string OrderByFilterGet()
        {
            string strSQL = null;

            switch (mintOrderByFilter)
            {
                case OrderByFilters.PlanGrupoTipoId:
                    break;

                case OrderByFilters.PlanGrupoTipoCod:
                    strSQL = " ORDER BY ctbPlanGrupoTipo.PlanGrupoTipoCod ";
                    break;

                case OrderByFilters.Grid:
                    strSQL = " ORDER BY ctbPlanGrupoTipo.PlanGrupoTipoCod, parEstado.EstadoDes ";
                    break;

                case OrderByFilters.GridCheck:
                    break;
            }

            return strSQL;
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "Carlos.ctbPlanGrupoTipoInsertCarlos";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod, SysData.ToStr(VM.PlanGrupoTipoCod)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes, SysData.ToStr(VM.PlanGrupoTipoDes)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp, SysData.ToStr(VM.PlanGrupoTipoEsp)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._EstadoId, SysData.ToLong(VM.EstadoId))};
                    moParameters[0].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "Carlos.ctbPlanGrupoTipoUpdateCarlos";
                    moParameters = new SqlParameter[5] {
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId, SysData.ToLong(VM.PlanGrupoTipoId)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod, SysData.ToStr(VM.PlanGrupoTipoCod)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes, SysData.ToStr(VM.PlanGrupoTipoDes)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp, SysData.ToStr(VM.PlanGrupoTipoEsp)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._EstadoId, SysData.ToLong(VM.EstadoId))};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "Carlos.ctbPlanGrupoTipoDeleteCarlos";
                    moParameters = new SqlParameter[1] {
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId, SysData.ToLong(VM.PlanGrupoTipoId))};
                    break;
            }
        }

        protected override void Retrieve(DataRow oDataRow)
        {
            try
            {
                PropertyInit();

                switch (mintSelectFilter)
                {
                    case SelectFilters.All:
                        VM.PlanGrupoTipoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId]);
                        VM.PlanGrupoTipoCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod]);
                        VM.PlanGrupoTipoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes]);
                        VM.PlanGrupoTipoEsp = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoVMCarlos._EstadoId]);
                        break;

                    case SelectFilters.ListBox:
                        VM.PlanGrupoTipoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId]);
                        VM.PlanGrupoTipoCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod]);
                        VM.PlanGrupoTipoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes]);
                        break;

                    case SelectFilters.Grid:
                        VM.PlanGrupoTipoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId]);
                        VM.PlanGrupoTipoCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod]);
                        VM.PlanGrupoTipoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes]);
                        VM.PlanGrupoTipoEsp = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoVMCarlos._EstadoId]);
                        VM.EstadoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoVMCarlos._EstadoDes]);
                        break;

                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
        }

        public override bool Validate()
        {
            // no existe ninguna verificacion extra
            // aparte de las condiciones de DataNotacion

            return true;

        }

        public bool FindByPK()
        {
            bool returnValue = false;
            returnValue = false;

            try
            {
                mintSelectFilter = SelectFilters.All;
                mintWhereFilter = WhereFilters.PrimaryKey;
                mintOrderByFilter = OrderByFilters.None;

                if (Open())
                {
                    if (Read())
                    {
                        returnValue = true;
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }

            return returnValue;
        }

        public void FilterInit()
        {
            mintWhereFilter = 0;
            mintOrderByFilter = 0;
            mintSelectFilter = 0;
            mintInsertFilter = 0;
            mintUpdateFilter = 0;
            mintDeleteFilter = 0;
            mintRowCountFilter = 0;
        }

        virtual public void Dispose()
        {
            //Call CloseConection()
        }


    }
}