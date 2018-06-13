using Contabilidad.Models.VM.Carlos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.DAC.Carlos
{
    public class clsPlanGrupoTipoDetCarlos: clsBase, IDisposable
    {
        public clsPlanGrupoTipoDetVMCarlos VM;

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
            PlanGrupoTipoDetCod = 2,
            PlanGrupoTipoDetDes = 3,
            Grid = 4,
            GridCheck = 5,
            EstadoId = 6,
            PlanGrupoTipoId = 7
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
        public clsPlanGrupoTipoDetCarlos()
        {
            mstrTableName = "ctbPlanGrupoTipo";
            mstrClassName = "clsPlanGrupoTipoCarlos";

            PropertyInit();
            FilterInit();
        }

        public clsPlanGrupoTipoDetCarlos(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPlanGrupoTipoDetCarlos(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPlanGrupoTipoDetCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPlanGrupoTipoDetCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPlanGrupoTipoDetCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsPlanGrupoTipoDetVMCarlos();

            VM.PlanGrupoTipoDetId = 0;
            VM.PlanGrupoTipoId = 0;
            VM.PlanGrupoTipoDetCod = "";
            VM.PlanGrupoTipoDetDes = "";
            VM.PlanGrupoTipoDetEsp = "";
            VM.EstadoId = 0;
            VM.EstadoDes = "";
        }

        protected override void SetPrimaryKey()
        {
            VM.PlanGrupoTipoDetId = mlngId;
        }

        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "Carlos.ctbPlanGrupoTipoDetSelectCarlos";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = " SELECT  " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetId, " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetCod, " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetDes," +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetEsp," +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoId," +
                           "    ctbPlanGrupoTipoDet.EstadoId" +
                           " FROM ctbPlanGrupoTipoDet ";
                    break;

                case SelectFilters.ListBox:
                    strSQL = " SELECT  " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetId, " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetCod, " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetDes," +
                           " FROM ctbPlanGrupoTipoDet ";
                    break;

                case SelectFilters.Grid:
                    strSQL = " SELECT  " +
                            "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetId, " +
                            "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetCod, " +
                           "    ctbPlanGrupoTipoDet.PlanGrupoTipoDetDes," +
                           "    ctbPlanGrupoTipo.PlanGrupoTipoDes," +
                           "    parEstado.EstadoDes  " +
                           " FROM ctbPlanGrupoTipoDet ";
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
                    strSQL = " WHERE PlanGrupoTipoDetId = " + SysData.NumberToField(VM.PlanGrupoTipoDetId);
                    break;

                case WhereFilters.PlanGrupoTipoDetCod:
                    strSQL = " WHERE PlanGrupoTipoDetCod = " + SysData.StringToField(VM.PlanGrupoTipoDetCod);
                    break;

                case WhereFilters.PlanGrupoTipoDetDes:
                    strSQL = " WHERE PlanGrupoTipoDetDes = " + SysData.StringToField(VM.PlanGrupoTipoDetDes);
                    break;

                case WhereFilters.Grid:
                    strSQL = " LEFT JOIN ctbPlanGrupoTipo ON ctbPlanGrupoTipoDet.PlanGrupoTipoId = ctbPlanGrupoTipo.PlanGrupoTipoId " +
                             " LEFT JOIN parEstado ON ctbPlanGrupoTipo.EstadoId = parEstado.EstadoId ";
                    break;

                case WhereFilters.EstadoId:
                    strSQL = " WHERE EstadoId = " + SysData.NumberToField(VM.EstadoId);
                    break;

                case WhereFilters.GridCheck:
                    break;

                case WhereFilters.PlanGrupoTipoId:
                    strSQL = " WHERE PlanGrupoTipoId = " + SysData.StringToField(VM.PlanGrupoTipoId);
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
                    strSQL = " ORDER BY ctbPlanGrupoTipoDet.PlanGrupoTipoDetCod ";
                    break;

                case OrderByFilters.Grid:
                    strSQL = " ORDER BY ctbPlanGrupoTipoDet.PlanGrupoTipoDetCod, parEstado.EstadoDes ";
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
                    mstrStoreProcName = "Carlos.ctbPlanGrupoTipoDetInsertCarlos";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter(clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetCod, SysData.ToStr(VM.PlanGrupoTipoDetCod)),
                        new SqlParameter(clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetDes, SysData.ToStr(VM.PlanGrupoTipoDetDes)),
                        new SqlParameter(clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetEsp, SysData.ToStr(VM.PlanGrupoTipoDetEsp)),
                        new SqlParameter(clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoId, SysData.ToLong(VM.PlanGrupoTipoId)),
                        new SqlParameter(clsPlanGrupoTipoDetVMCarlos._EstadoId, SysData.ToLong(VM.EstadoId))};
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
                    /*moParameters = new SqlParameter[5] {
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId, SysData.ToLong(VM.PlanGrupoTipoId)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod, SysData.ToStr(VM.PlanGrupoTipoCod)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes, SysData.ToStr(VM.PlanGrupoTipoDes)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp, SysData.ToStr(VM.PlanGrupoTipoEsp)),
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._EstadoId, SysData.ToLong(VM.EstadoId))};*/
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "Carlos.ctbPlanGrupoTipoDeleteCarlos";
                    /*moParameters = new SqlParameter[1] {
                        new SqlParameter(clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId, SysData.ToLong(VM.PlanGrupoTipoId))};*/
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
                        VM.PlanGrupoTipoDetId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetId]);
                        VM.PlanGrupoTipoDetCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetCod]);
                        VM.PlanGrupoTipoDetDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetDes]);
                        VM.PlanGrupoTipoDetEsp = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetEsp]);
                        VM.PlanGrupoTipoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoId]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._EstadoId]);
                        break;

                    case SelectFilters.ListBox:
                        VM.PlanGrupoTipoDetId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetId]);
                        VM.PlanGrupoTipoDetCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetCod]);
                        VM.PlanGrupoTipoDetDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetDes]);
                        break;

                    case SelectFilters.Grid:
                        VM.PlanGrupoTipoDetId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetId]);
                        VM.PlanGrupoTipoDetCod = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetCod]);
                        VM.PlanGrupoTipoDetDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetDes]);
                        VM.PlanGrupoTipoDetEsp = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDetEsp]);
                        VM.PlanGrupoTipoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoId]);
                        VM.PlanGrupoTipoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._PlanGrupoTipoDes]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPlanGrupoTipoDetVMCarlos._EstadoId]);
                        VM.EstadoDes = SysData.ToStr(oDataRow[clsPlanGrupoTipoDetVMCarlos._EstadoDes]);
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

        public bool FindByPK(long id)
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