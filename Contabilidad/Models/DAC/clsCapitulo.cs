using System;
using System.Data.SqlClient;
using System.Data;

namespace Contabilidad.Models.DAC
{
    public class clsCapitulo : clsBase, IDisposable
    {
        private long mlngCapituloId;
        private long mlngTipoCapituloId;
        private long mlngOrden;
        private string mstrCapituloCod;
        private string mstrCapituloDes;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long CapituloId
        {
            get
            {
                return mlngCapituloId;
            }

            set
            {
                mlngCapituloId = value;
            }
        }

        public long TipoCapituloId
        {
            get
            {
                return mlngTipoCapituloId;
            }

            set
            {
                mlngTipoCapituloId = value;
            }
        }

        public long Orden
        {
            get
            {
                return mlngOrden;
            }

            set
            {
                mlngOrden = value;
            }
        }

        public string CapituloCod
        {
            get
            {
                return mstrCapituloCod;
            }

            set
            {
                mstrCapituloCod = value;
            }
        }

        public string CapituloDes
        {
            get
            {
                return mstrCapituloDes;
            }

            set
            {
                mstrCapituloDes = value;
            }
        }

        public long EstadoId
        {
            get
            {
                return mlngEstadoId;
            }

            set
            {
                mlngEstadoId = value;
            }
        }

        public long Id
        {
            get
            {
                return mlngId;
            }

            set
            {
                mlngId = value;
            }
        }

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
            CapituloDes = 2,
            Grid = 3,
            GridCheck = 4,
            CapituloCod = 5,
            Grid_EstadoId = 6
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            CapituloId = 1,
            CapituloDes = 2,
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
        public clsCapitulo()
        {
            mstrTableName = "ctbCapitulo";
            mstrClassName = "clsCapitulo";

            PropertyInit();
            FilterInit();
        }

        public clsCapitulo(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsCapitulo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsCapitulo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsCapitulo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsCapitulo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngCapituloId = 0;
            mlngTipoCapituloId = 0;
            mlngOrden = 0;
            mstrCapituloCod = "";
            mstrCapituloDes = "";
            mlngEstadoId = 0;
        }

        protected override void SelectParameter()
        {
            Array.Resize(ref moParameters, 3);
            moParameters[0] = new SqlParameter("@SelectFilter", mintSelectFilter);
            moParameters[1] = new SqlParameter("@WhereFilter", mintWhereFilter);
            moParameters[2] = new SqlParameter("@OrderByFilter", mintOrderByFilter);

            switch (mintSelectFilter)
            {
                case SelectFilters.All:
                    mstrStoreProcName = "ctbCapituloSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "ctbCapituloSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "ctbCapituloSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "ctbCapituloSelect";
                    break;

                case SelectFilters.GridCheck:
                    break;
            }

            WhereParameter();

            //Call OrderByParameter()
        }

        private void WhereParameter()
        {
            switch (mintWhereFilter)
            {
                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@CapituloId", mlngCapituloId);
                    moParameters[4] = new SqlParameter("@CapituloCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.CapituloDes:
                    break;
                //strSQL = " WHERE  ctbCapitulo.CapituloDes = " & StringToField(mstrCapituloDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@CapituloId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@CapituloCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.Grid_EstadoId:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@CapituloId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@CapituloCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", mlngEstadoId);
                    break;

                case WhereFilters.CapituloCod:
                    break;

                case WhereFilters.GridCheck:
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "ctbCapituloInsert";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@TipoCapituloId", mlngTipoCapituloId),
                        new SqlParameter("@Orden", mlngOrden),
                        new SqlParameter("@CapituloCod", mstrCapituloCod),
                        new SqlParameter("@CapituloDes", mstrCapituloDes),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "ctbCapituloUpdate";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@CapituloId", mlngCapituloId),
                        new SqlParameter("@TipoCapituloId", mlngTipoCapituloId),
                        new SqlParameter("@Orden", mlngOrden),
                        new SqlParameter("@CapituloCod", mstrCapituloCod),
                        new SqlParameter("@CapituloDes", mstrCapituloDes),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "ctbCapituloDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@CapituloId", mlngCapituloId)};
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
                        mlngCapituloId = SysData.ToLong(oDataRow["CapituloId"]);
                        mlngTipoCapituloId = SysData.ToLong(oDataRow["TipoCapituloId"]);
                        mlngOrden = SysData.ToLong(oDataRow["Orden"]);
                        mstrCapituloCod = SysData.ToStr(oDataRow["CapituloCod"]);
                        mstrCapituloDes = SysData.ToStr(oDataRow["CapituloDes"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngCapituloId = SysData.ToLong(oDataRow["CapituloId"]);
                        mstrCapituloCod = SysData.ToStr(oDataRow["CapituloCod"]);
                        mstrCapituloDes = SysData.ToStr(oDataRow["CapituloDes"]);
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
            bool returnValue = false;
            string strMsg = string.Empty;

            if (mstrCapituloCod.Length == 0)
            {
                strMsg += "Código es Requerido" + Environment.NewLine;
            }

            if (mstrCapituloDes.Length == 0)
            {
                strMsg += "Descipción del Tipo Usuario es Requerido" + Environment.NewLine;
            }

            if (strMsg.Trim() != string.Empty)
            {
                returnValue = false;
                throw (new Exception(strMsg));
            }
            else
            {
                returnValue = true;
            }

            return returnValue;
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

        protected override void SetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}