using Contabilidad.Models.VM.Carlos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.DAC.Carlos
{
    public class clsTipoPlanCarlos: clsBase, IDisposable
    {
        public clsTipoPlanVMCarlos VM;

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
            TipoPlanDes = 2,
            Grid = 3,
            GridCheck = 4,
            EstadoId = 5,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            TipoPlanId = 1,
            TipoPlanDes = 2,
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
        public clsTipoPlanCarlos()
        {
            mstrTableName = "ctbTipoPlan";
            mstrClassName = "clsTipoPlanCarlos";

            PropertyInit();
            FilterInit();
        }

        public clsTipoPlanCarlos(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsTipoPlanCarlos(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsTipoPlanCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsTipoPlanCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsTipoPlanCarlos(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsTipoPlanVMCarlos();

            VM.TipoPlanId = 0;
            VM.TipoPlanDes = "";
            VM.EstadoId = 0;
            VM.EstadoDes = "";
        }

        protected override void SetPrimaryKey()
        {
            VM.TipoPlanId = mlngId;
        }

        protected override void SelectParameter()
        {
            string strSQL = null;

            mstrStoreProcName = "Carlos.ctbTipoPlanSelectCarlos";

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    strSQL = " SELECT  " +
                           "    ctbTipoPlan.TipoPlanId, " +             //usar espacio
                           "    ctbTipoPlan.TipoPlanDes, " +
                           "    ctbTipoPlan.EstadoId, " +
                           " FROM ctbTipoPlan ";
                    break;

                case SelectFilters.ListBox:
                    strSQL = " SELECT  " +
                           "    ctbTipoPlan.TipoPlanId, " +
                           "    ctbTipoPlan.TipoPlanDes, " +
                           " FROM ctbTipoPlan ";
                    break;

                case SelectFilters.Grid:
                    strSQL = " SELECT  " +
                           "    ctbTipoPlan.TipoPlanId, " +             //usar espacio
                           "    ctbTipoPlan.TipoPlanDes, " +
                           "    ctbTipoPlan.EstadoId, " +
                           "    parEstado.EstadoDes  " +
                           " FROM ctbTipoPlan ";
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
                    strSQL = " WHERE TipoPlanId = " + SysData.NumberToField(VM.TipoPlanId);
                    break;

                case WhereFilters.TipoPlanDes:
                    strSQL = " WHERE TipoPlanDes = " + SysData.StringToField(VM.TipoPlanDes);
                    break;

                case WhereFilters.Grid:
                    strSQL = " LEFT JOIN parEstado ON ctbTipoPlan.EstadoId = parEstado.EstadoId ";
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
                case OrderByFilters.TipoPlanId:
                    break;

                case OrderByFilters.TipoPlanDes:
                    strSQL = " ORDER BY ctbTipoPlan.TipoPlanDes ";
                    break;

                case OrderByFilters.Grid:
                    strSQL = " ORDER BY ctbTipoPlan.TipoPlanDes, parEstado.EstadoDes ";
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
                    mstrStoreProcName = "Carlos.ctbTipoPlanInsertCarlos";
                    moParameters = new SqlParameter[3] {
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter(clsTipoPlanVMCarlos._TipoPlanDes, VM.TipoPlanDes),
                        new SqlParameter(clsTipoPlanVMCarlos._EstadoId, VM.EstadoId)};
                    moParameters[0].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "Carlos.ctbTipoPlanUpdateCarlos";
                    moParameters = new SqlParameter[3] {
                        new SqlParameter(clsTipoPlanVMCarlos._TipoPlanId, VM.TipoPlanId),
                        new SqlParameter(clsTipoPlanVMCarlos._TipoPlanDes, VM.TipoPlanDes),
                        new SqlParameter(clsTipoPlanVMCarlos._EstadoId, VM.EstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "Carlos.ctbTipoPlanDeleteCarlos";
                    moParameters = new SqlParameter[1] {
                        new SqlParameter(clsTipoPlanVMCarlos._TipoPlanId, VM.TipoPlanId)};
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
                        VM.TipoPlanId = SysData.ToLong(oDataRow[clsTipoPlanVMCarlos._TipoPlanId]);
                        VM.TipoPlanDes = SysData.ToStr(oDataRow[clsTipoPlanVMCarlos._TipoPlanDes]);
                        VM.EstadoId= SysData.ToLong(oDataRow[clsTipoPlanVMCarlos._EstadoId]);
                        break;

                    case SelectFilters.ListBox:
                        VM.TipoPlanId = SysData.ToLong(oDataRow[clsTipoPlanVMCarlos._TipoPlanId]);
                        VM.TipoPlanDes = SysData.ToStr(oDataRow[clsTipoPlanVMCarlos._TipoPlanDes]);
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