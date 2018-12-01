using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_KPI_Period
    {
        private int id;
        private string name;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime reviewTime;
        private DateTime approvalTime;
        private DateTime reviewTime_First;
        private int _typeid;
        private bool active;

        public tbl_KPI_Period()
        {
            name = "";
            active = true;
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        public DateTime EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        public DateTime ReviewTime
        {
            get
            {
                return reviewTime;
            }
            set
            {
                reviewTime = value;
            }
        }
        public DateTime ApprovalTime
        {
            get
            {
                return approvalTime;
            }
            set
            {
                approvalTime = value;
            }
        }

        public DateTime ReviewTime_First
        {
            get
            {
                return reviewTime_First;
            }
            set
            {
                reviewTime_First = value;
            }
        }
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        public int TypeID
        {
            get
            {
                return _typeid;
            }
            set
            {
                _typeid = value;
            }
        }
        #endregion
    }
}