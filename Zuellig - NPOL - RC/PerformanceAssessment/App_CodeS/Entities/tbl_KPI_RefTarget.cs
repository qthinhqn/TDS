using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_KPI_RefTarget
    {
        private int id;
        private string description;
        private string description_eng;
        private bool active;

        public tbl_KPI_RefTarget()
        {
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