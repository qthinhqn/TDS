using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_Ref_Competency
    {
        private int id;
        private int period_ID;
        private int competency_ID;
        private int order;

        public tbl_Ref_Competency()
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
        public int Period_ID
        {
            get
            {
                return period_ID;
            }
            set
            {
                period_ID = value;
            }
        }
        public int Competency_ID
        {
            get
            {
                return competency_ID;
            }
            set
            {
                competency_ID = value;
            }
        }
        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }
        #endregion
    }
}