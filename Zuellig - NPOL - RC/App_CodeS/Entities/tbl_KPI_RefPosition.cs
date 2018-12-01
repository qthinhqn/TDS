using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_KPI_RefPosition
    {
        private int id;
        private int kpi_ID;
        private string position_ID;

        public tbl_KPI_RefPosition()
        {
        }
        #region
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public int KPI_ID
        {
            get
            {
                return kpi_ID;
            }
            set
            {
                kpi_ID = value;
            }
        }
        public string Position_ID
        {
            get
            {
                return position_ID;
            }
            set
            {
                position_ID = value;
            }
        }
        #endregion
    }
}