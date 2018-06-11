using System;
using System.Data.SqlClient;
using System.Data;
using Contabilidad.Models.VM;

namespace Contabilidad.Models.DAC
{
    public class clsPlan : clsBase, IDisposable
    {
        public clsPlanVM VM;

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
            PlanDes = 2,
            Grid = 3,
            GridCheck = 4,
            PlanCod = 5,
            Grid_PlanPadreId = 6,
            PlanPadreId = 7,
            PlanHijo_MaxOrden = 8,
            EstadoId = 9,
            TipoPlanId = 10
        }

        public enum OrderByFilters : byte
        {
            None = 0,
            PlanId = 1,
            PlanDes = 2,
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
        public clsPlan()
        {
            mstrTableName = "ctbPlan";
            mstrClassName = "clsPlan";

            PropertyInit();
            FilterInit();
        }

        public clsPlan(string ConnectString) : this()
        {
            moConnection = new SqlConnection();

            mstrConnectionString = ConnectString;
        }

        public clsPlan(SqlConnection oConnection) : this()
        {
            moConnection = oConnection;
        }

        public clsPlan(SqlConnection oConnection, SelectFilters bytSelectFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
        }

        public clsPlan(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
        }

        public clsPlan(SqlConnection oConnection, SelectFilters bytSelectFilter, WhereFilters bytWhereFilter, OrderByFilters bytOrderByFilter) : this()
        {
            moConnection = oConnection;
            mintSelectFilter = bytSelectFilter;
            mintWhereFilter = bytWhereFilter;
            mintOrderByFilter = bytOrderByFilter;
        }

        public void PropertyInit()
        {
            VM = new clsPlanVM();
            VM.PlanId = 0;
            VM.PlanCod = "";
            VM.PlanDes = "";
            VM.PlanEsp = "";
            VM.TipoPlanId = 0;
            VM.Orden = 0;
            VM.Nivel = 0;
            VM.MonedaId = 0;
            VM.TipoAmbitoId = 0;
            VM.PlanAjusteId = 0;
            VM.CapituloId = 0;
            VM.PlanPadreId = 0;
            VM.EstadoId = 0;
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
                    mstrStoreProcName = "ctbPlanSelect";
                    break;

                case SelectFilters.RowCount:
                    mstrStoreProcName = "ctbPlanSelect";
                    break;

                case SelectFilters.ListBox:
                    mstrStoreProcName = "ctbPlanSelect";
                    break;

                case SelectFilters.Grid:
                    mstrStoreProcName = "ctbPlanSelect";
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
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", VM.PlanId);
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.PlanDes:
                    break;
                //strSQL = " WHERE  ctbPlan.PlanDes = " & StringToField(mstrPlanDes)

                case WhereFilters.Grid:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", VM.PlanPadreId);
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", VM.EstadoId);
                    break;

                case WhereFilters.PlanCod:
                    break;

                case WhereFilters.GridCheck:
                    break;

                case WhereFilters.Grid_PlanPadreId:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", VM.PlanPadreId);
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.PlanPadreId:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", VM.PlanPadreId);
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", Convert.ToInt32(0));
                    break;

                case WhereFilters.PlanHijo_MaxOrden:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", VM.PlanPadreId);
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", VM.EstadoId);
                    break;

                case WhereFilters.EstadoId:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@TipoPlanId", Convert.ToInt32(0));
                    moParameters[7] = new SqlParameter("@EstadoId", VM.EstadoId);
                    break;

                case WhereFilters.TipoPlanId:
                    Array.Resize(ref moParameters, moParameters.Length + 5);
                    moParameters[3] = new SqlParameter("@PlanId", Convert.ToInt32(0));
                    moParameters[4] = new SqlParameter("@PlanCod", Convert.ToString(""));
                    moParameters[5] = new SqlParameter("@PlanPadreId", Convert.ToInt32(0));
                    moParameters[6] = new SqlParameter("@TipoPlanId", VM.TipoPlanId);
                    moParameters[7] = new SqlParameter("@EstadoId", VM.EstadoId);
                    break;
            }
        }

        protected override void InsertParameter()
        {
            switch (mintInsertFilter)
            {
                case InsertFilters.All:
                    mstrStoreProcName = "ctbPlanInsert";
                    moParameters = new SqlParameter[14] {
                        new SqlParameter("@InsertFilter", mintInsertFilter),
                        new SqlParameter("@Id", SqlDbType.Int),
                        new SqlParameter("@PlanCod", VM.PlanCod),
                        new SqlParameter("@PlanDes", VM.PlanDes),
                        new SqlParameter("@PlanEsp", VM.PlanEsp),
                        new SqlParameter("@TipoPlanId", VM.TipoPlanId),
                        new SqlParameter("@Orden", VM.Orden),
                        new SqlParameter("@Nivel", VM.Nivel),
                        new SqlParameter("@MonedaId", VM.MonedaId),
                        new SqlParameter("@TipoAmbitoId", VM.TipoAmbitoId),
                        new SqlParameter("@PlanAjusteId", VM.PlanAjusteId),
                        new SqlParameter("@CapituloId", VM.CapituloId),
                        new SqlParameter("@PlanPadreId", VM.PlanPadreId),
                        new SqlParameter("@EstadoId", VM.EstadoId)};
                    moParameters[1].Direction = ParameterDirection.Output;
                    break;
            }
        }

        protected override void UpdateParameter()
        {
            switch (mintUpdateFilter)
            {
                case UpdateFilters.All:
                    mstrStoreProcName = "ctbPlanUpdate";
                    moParameters = new SqlParameter[14] {
                        new SqlParameter("@UpdateFilter", mintUpdateFilter),
                        new SqlParameter("@PlanId", VM.PlanId),
                        new SqlParameter("@PlanCod", VM.PlanCod),
                        new SqlParameter("@PlanDes", VM.PlanDes),
                        new SqlParameter("@PlanEsp", VM.PlanEsp),
                        new SqlParameter("@TipoPlanId", VM.TipoPlanId),
                        new SqlParameter("@Orden", VM.Orden),
                        new SqlParameter("@Nivel", VM.Nivel),
                        new SqlParameter("@MonedaId", VM.MonedaId),
                        new SqlParameter("@TipoAmbitoId", VM.TipoAmbitoId),
                        new SqlParameter("@PlanAjusteId", VM.PlanAjusteId),
                        new SqlParameter("@CapituloId", VM.CapituloId),
                        new SqlParameter("@PlanPadreId", VM.PlanPadreId),
                        new SqlParameter("@EstadoId", VM.EstadoId)};
                    break;
            }
        }

        protected override void DeleteParameter()
        {
            switch (mintDeleteFilter)
            {
                case DeleteFilters.All:
                    mstrStoreProcName = "ctbPlanDelete";
                    moParameters = new SqlParameter[2] {
                        new SqlParameter("@DeleteFilter", mintDeleteFilter),
                        new SqlParameter("@PlanId", VM.PlanId)};
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
                        VM.PlanId = SysData.ToLong(oDataRow[clsPlanVM._PlanId]);
                        VM.PlanCod = SysData.ToStr(oDataRow[clsPlanVM._PlanCod]);
                        VM.PlanDes = SysData.ToStr(oDataRow[clsPlanVM._PlanDes]);
                        VM.PlanEsp = SysData.ToStr(oDataRow[clsPlanVM._PlanEsp]);
                        VM.TipoPlanId = SysData.ToLong(oDataRow[clsPlanVM._TipoPlanId]);
                        VM.Orden = SysData.ToLong(oDataRow[clsPlanVM._Orden]);
                        VM.Nivel = SysData.ToLong(oDataRow[clsPlanVM._Nivel]);
                        VM.MonedaId = SysData.ToLong(oDataRow[clsPlanVM._MonedaId]);
                        VM.TipoAmbitoId = SysData.ToLong(oDataRow[clsPlanVM._TipoAmbitoId]);
                        VM.PlanAjusteId = SysData.ToLong(oDataRow[clsPlanVM._PlanAjusteId]);
                        VM.CapituloId = SysData.ToLong(oDataRow[clsPlanVM._CapituloId]);
                        VM.PlanPadreId = SysData.ToLong(oDataRow[clsPlanVM._PlanPadreId]);
                        VM.EstadoId = SysData.ToLong(oDataRow[clsPlanVM._EstadoId]);
                        break;

                    case SelectFilters.ListBox:
                        VM.PlanId = SysData.ToLong(oDataRow[clsPlanVM._PlanId]);
                        VM.PlanCod = SysData.ToStr(oDataRow[clsPlanVM._PlanCod]);
                        VM.PlanDes = SysData.ToStr(oDataRow[clsPlanVM._PlanDes]);
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

            if (VM.PlanCod.Length == 0)
            {
                strMsg += "Código es Requerido" + Environment.NewLine;
            }

            if (VM.PlanDes.Length == 0)
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
            //GC.SuppressFinalize(this);      //carlos
        }

        protected override void SetPrimaryKey()
        {
            throw new NotImplementedException();
        }
    }
}