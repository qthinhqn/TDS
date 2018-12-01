using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblSubPeriod
    {
        private int id;
        private string managerID;
        private int period_ID;
        private DateTime fromDate;
        private DateTime toDate;

        public tblSubPeriod()
        {
            managerID = "";
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
        public string ManagerID
        {
            get
            {
                return managerID;
            }
            set
            {
                managerID = value;
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
        public DateTime FromDate
        {
            get
            {
                return fromDate;
            }
            set
            {
                fromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return toDate;
            }
            set
            {
                toDate = value;
            }
        }

        #endregion
    }
}