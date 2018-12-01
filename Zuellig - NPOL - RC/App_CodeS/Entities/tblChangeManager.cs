using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblChangeManager
    {
        private int id;
        private string managerID_A;
        private string managerID_B;
        private Nullable<DateTime> fromDate;
        private Nullable<DateTime> toDate;
        private Nullable<bool> status;
        private string notes;

        public tblChangeManager()
        {
            managerID_A = "";
            managerID_B = "";
            fromDate = null;
            toDate = null;
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
        public string Manager_A
        {
            get
            {
                return managerID_A;
            }
            set
            {
                managerID_A = value;
            }
        }
        public string Manager_B
        {
            get
            {
                return managerID_B;
            }
            set
            {
                managerID_B = value;
            }
        }
        public Nullable<DateTime> ToDate
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
        public Nullable<DateTime> FromDate
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
        public Nullable<bool> Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        #endregion
    }
}