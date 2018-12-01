using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_Viewed
    {
        private int id;
        private int newsid;
        private string userid;
        private DateTime viewdate;

        public tbl_Viewed()
        {
            userid = "";
            viewdate = DateTime.Now;
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
        public int NewsID
        {
            get
            {
                return newsid;
            }
            set
            {
                newsid = value;
            }
        }
        public string UserID
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }
        public DateTime ViewDate
        {
            get
            {
                return viewdate;
            }
            set
            {
                viewdate = value;
            }
        }
        #endregion
    }
}