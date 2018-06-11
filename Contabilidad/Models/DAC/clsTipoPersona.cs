using System;
using System.Data.SqlClient;
using System.Data;

namespace Contabilidad.Models.DAC
{
    public class clsTipoPersona : clsBase, IDisposable
    {
        private long mlngTipoPersonaId;
        private string mstrTipoPersonaCod;
        private string mstrTipoPersonaDes;
        private string mstrTipoPersonaEsp;
        private long mlngTipoPersonaGrupoId;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long TipoPersonaId
        {
            get
            {
                return mlngTipoPersonaId;
            }

            set
            {
                mlngTipoPersonaId = value;
            }
        }

        public string TipoPersonaCod
        {
            get
            {
                return mstrTipoPersonaCod;
            }

            set
            {
                mstrTipoPersonaCod = value;
            }
        }

        public string TipoPersonaDes
        {
            get
            {
                return mstrTipoPersonaDes;
            }

            set
            {
                mstrTipoPersonaDes = value;
            }
        }

        public string TipoPersonaEsp
        {
            get
            {
                return mstrTipoPersonaEsp;
            }

            set
            {
                mstrTipoPersonaEsp = value;
            }
        }

        public long TipoPersonaGrupoId
        {
            get
            {
                return mlngTipoPersonaGrupoId;
            }

            set
            {
                mlngTipoPersonaGrupoId = value;
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
            TipoPersonaDes = 2,
            Grid = 3,
            GridCheck = 4,
            TipoPersonaCod = 5,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            TipoPersonaId = 1,
            TipoPersonaDes = 2,
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
        public clsTipoPersona()
        {
            mstrTableName = "parTipoPersona";
            mstrClassName = "clsTipoPersona";

            PropertyInit();
            FilterInit();
        }

        public clsTipoPersona(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsTipoPersona(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsTipoPersona(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsTipoPersona(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsTipoPersona(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngTipoPersonaId = 0;
            mstrTipoPersonaCod = "";
            mstrTipoPersonaDes = "";
            mstrTipoPersonaEsp = "";
            mlngTipoPersonaGrupoId = 0;
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
                    mstrStoreProcName = "parTipoPersonaSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "parTipoPersonaSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "parTipoPersonaSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "parTipoPersonaSelect";
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
                case WhereFilters.None:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@TipoPersonaId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@TipoPersonaCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@TipoPersonaId", mlngTipoPersonaId);
                    moParameters[4] = new SqlParameter("@TipoPersonaCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TipoPersonaDes:
                    break;
                //strSQL = " WHERE  parTipoPersona.TipoPersonaDes = " & StringToField(mstrTipoPersonaDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@TipoPersonaId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@TipoPersonaCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.TipoPersonaCod:
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
                    mstrStoreProcName = "parTipoPersonaInsert";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@TipoPersonaCod", mstrTipoPersonaCod),
                        new SqlParameter("@TipoPersonaDes", mstrTipoPersonaDes),
                        new SqlParameter("@TipoPersonaEsp", mstrTipoPersonaEsp),
                        new SqlParameter("@TipoPersonaGrupoId", mlngTipoPersonaGrupoId),
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
                    mstrStoreProcName = "parTipoPersonaUpdate";
                    moParameters = new SqlParameter[7] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@TipoPersonaId", mlngTipoPersonaId),
                        new SqlParameter("@TipoPersonaCod", mstrTipoPersonaCod),
                        new SqlParameter("@TipoPersonaDes", mstrTipoPersonaDes),
                        new SqlParameter("@TipoPersonaEsp", mstrTipoPersonaEsp),
                        new SqlParameter("@TipoPersonaGrupoId", mlngTipoPersonaGrupoId),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "parTipoPersonaDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@TipoPersonaId", mlngTipoPersonaId)};
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
                        mlngTipoPersonaId = SysData.ToLong(oDataRow["TipoPersonaId"]);
                        mstrTipoPersonaCod = SysData.ToStr(oDataRow["TipoPersonaCod"]);
                        mstrTipoPersonaDes = SysData.ToStr(oDataRow["TipoPersonaDes"]);
                        mstrTipoPersonaEsp = SysData.ToStr(oDataRow["TipoPersonaEsp"]);
                        mlngTipoPersonaGrupoId = SysData.ToLong(oDataRow["TipoPersonaGrupoId"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngTipoPersonaId = SysData.ToLong(oDataRow["TipoPersonaId"]);
                        mstrTipoPersonaCod = SysData.ToStr(oDataRow["TipoPersonaCod"]);
                        mstrTipoPersonaDes = SysData.ToStr(oDataRow["TipoPersonaDes"]);
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

            if (mstrTipoPersonaCod.Length == 0)
            {
                strMsg += "Código es Requerido" + Environment.NewLine;
            }

            if (mstrTipoPersonaDes.Length == 0)
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