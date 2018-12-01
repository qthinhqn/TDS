using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_SubmitNews
    {
        private int id;
        private int newsid;
        private string submitfile;
        private string submituser;
        private DateTime submitdate;
        private string path;

        public tbl_SubmitNews()
        {
            submitfile = "";
            submituser = "";
            submitdate = DateTime.Now;
            path = "";
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
        public string SubmitFile
        {
            get
            {
                return submitfile;
            }
            set
            {
                submitfile = value;
            }
        }
        public string SubmitUser
        {
            get
            {
                return submituser;
            }
            set
            {
                submituser = value;
            }
        }
        public DateTime SubmitDate
        {
            get
            {
                return submitdate;
            }
            set
            {
                submitdate = value;
            }
        }
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
        #endregion
    }
}