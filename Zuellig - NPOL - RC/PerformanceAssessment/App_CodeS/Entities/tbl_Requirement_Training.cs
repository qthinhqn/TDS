using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_Requirement_Training
    {
        private int id;
        private string emp_ID;
        private int period_ID;
        private string detail;

        public tbl_Requirement_Training()
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
        public string Employee_ID
        {
            get
            {
                return emp_ID;
            }
            set
            {
                emp_ID = value;
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
        public string Detail
        {
            get
            {
                return detail;
            }
            set
            {
                detail = value;
            }
        }
        #endregion
    }
}