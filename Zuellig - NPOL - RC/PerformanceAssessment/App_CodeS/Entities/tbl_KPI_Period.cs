using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_KPI_Period
    {
        private int id;
        private string name;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime reviewTime;
        private DateTime approvalTime;
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
        #endregion
    }
}