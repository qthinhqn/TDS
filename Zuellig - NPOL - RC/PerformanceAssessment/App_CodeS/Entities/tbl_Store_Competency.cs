using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_Store_Competency
    {
        private int id;
        private Nullable<bool> type;
        private string description;
        private string description_eng;
        private int parent;
        private int target;
        private bool active;
        private Nullable<DateTime> createTime;
        private Nullable<DateTime> lastUpdate;

        public tbl_Store_Competency()
        {
            type = null;
            description = "";
            description_eng = "";
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
        public Nullable<bool> Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string Description_eng
        {
            get
            {
                return description_eng;
            }
            set
            {
                description_eng = value;
            }
        }
        public int Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public int Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
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
        public Nullable<DateTime> CreateTime
        {
            get
            {
                return createTime;
            }
            set
            {
                createTime = value;
            }
        }
        public Nullable<DateTime> LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
            }
        }
        #endregion
    }
}