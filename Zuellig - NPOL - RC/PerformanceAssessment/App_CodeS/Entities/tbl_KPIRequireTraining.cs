using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_KPIRequireTraining
    {
        private int id;
        private string empid;
        private int periodid;
        private string detail;

        public tbl_KPIRequireTraining()
        {
            detail = "";
        }

        #region properties
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
        public string EmployeeID
        {
            get
            {
                return empid;
            }
            set
            {
                empid = value;
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
        public int Period_ID
        {
            get
            {
                return periodid;
            }
            set
            {
                periodid = value;
            }
        }
        #endregion
    }
}