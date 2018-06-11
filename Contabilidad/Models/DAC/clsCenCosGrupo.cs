using System;
using System.Data.SqlClient;
using System.Data;

namespace Contabilidad.Models.DAC
{
    public class clsCenCosGrupo : clsBase, IDisposable
    {
        private long mlngCenCosGrupoId;
        private string mstrCenCosGrupoCod;
        private string mstrCenCosGrupoDes;
        private string mstrCenCosGrupoEsp;
        private long mlngEstadoId;

        //******************************************************
        // Private Data To Match the Table Definition
        //******************************************************
        public long CenCosGrupoId
        {
            get
            {
                return mlngCenCosGrupoId;
            }

            set
            {
                mlngCenCosGrupoId = value;
            }
        }

        public string CenCosGrupoCod
        {
            get
            {
                return mstrCenCosGrupoCod;
            }

            set
            {
                mstrCenCosGrupoCod = value;
            }
        }

        public string CenCosGrupoDes
        {
            get
            {
                return mstrCenCosGrupoDes;
            }

            set
            {
                mstrCenCosGrupoDes = value;
            }
        }

        public string CenCosGrupoEsp
        {
            get
            {
                return mstrCenCosGrupoEsp;
            }

            set
            {
                mstrCenCosGrupoEsp = value;
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
            CenCosGrupoDes = 2,
            Grid = 3,
            GridCheck = 4,
            CenCosGrupoCod = 5,
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            CenCosGrupoId = 1,
            CenCosGrupoDes = 2,
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
        public clsCenCosGrupo()
        {
            mstrTableName = "ctbCenCosGrupo";
            mstrClassName = "clsCenCosGrupo";

            PropertyInit();
            FilterInit();
        }

        public clsCenCosGrupo(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsCenCosGrupo(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsCenCosGrupo(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsCenCosGrupo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsCenCosGrupo(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            mlngCenCosGrupoId = 0;
            mstrCenCosGrupoCod = "";
            mstrCenCosGrupoDes = "";
            mstrCenCosGrupoEsp = "";
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
                    mstrStoreProcName = "ctbCenCosGrupoSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "ctbCenCosGrupoSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "ctbCenCosGrupoSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "ctbCenCosGrupoSelect";
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
                    moParameters[3] = new SqlParameter("@CenCosGrupoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@CenCosGrupoCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.PrimaryKey:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@CenCosGrupoId", mlngCenCosGrupoId);
                    moParameters[4] = new SqlParameter("@CenCosGrupoCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.CenCosGrupoDes:
                    break;
                //strSQL = " WHERE  ctbCenCosGrupo.CenCosGrupoDes = " & StringToField(mstrCenCosGrupoDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 3);
                    moParameters[3] = new SqlParameter("@CenCosGrupoId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@CenCosGrupoCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.CenCosGrupoCod:
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
                    mstrStoreProcName = "ctbCenCosGrupoInsert";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@CenCosGrupoCod", mstrCenCosGrupoCod),
                        new SqlParameter("@CenCosGrupoDes", mstrCenCosGrupoDes),
                        new SqlParameter("@CenCosGrupoEsp", mstrCenCosGrupoEsp),
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
                    mstrStoreProcName = "ctbCenCosGrupoUpdate";
                    moParameters = new SqlParameter[6] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@CenCosGrupoId", mlngCenCosGrupoId),
                        new SqlParameter("@CenCosGrupoCod", mstrCenCosGrupoCod),
                        new SqlParameter("@CenCosGrupoDes", mstrCenCosGrupoDes),
                        new SqlParameter("@CenCosGrupoEsp", mstrCenCosGrupoEsp),
                        new SqlParameter("@EstadoId", mlngEstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "ctbCenCosGrupoDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@CenCosGrupoId", mlngCenCosGrupoId)};
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
                        mlngCenCosGrupoId = SysData.ToLong(oDataRow["CenCosGrupoId"]);
                        mstrCenCosGrupoCod = SysData.ToStr(oDataRow["CenCosGrupoCod"]);
                        mstrCenCosGrupoDes = SysData.ToStr(oDataRow["CenCosGrupoDes"]);
                        mstrCenCosGrupoEsp = SysData.ToStr(oDataRow["CenCosGrupoEsp"]);
                        mlngEstadoId = SysData.ToLong(oDataRow["EstadoId"]);
                        break;

                    case SelectFilters.ListBox:
                        mlngCenCosGrupoId = SysData.ToLong(oDataRow["CenCosGrupoId"]);
                        mstrCenCosGrupoCod = SysData.ToStr(oDataRow["CenCosGrupoCod"]);
                        mstrCenCosGrupoDes = SysData.ToStr(oDataRow["CenCosGrupoDes"]);
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

            if (mstrCenCosGrupoCod.Length == 0)
            {
                strMsg += "Código es Requerido" + Environment.NewLine;
            }

            if (mstrCenCosGrupoDes.Length == 0)
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