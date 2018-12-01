using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_EmpFeedback
    {
        private int id;
        private string empid;
        private string empName;
        private string content;
        private DateTime createdate;
        private DateTime? editdate;


        public tbl_EmpFeedback()
        {
            empid = "";
            empName = "";
            content = "";
            createdate = DateTime.Now;
            editdate = null;
        }

        #region properties
        public string EmpID
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
        public string EmployeeName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value;
            }
        }
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        public DateTime CreateDate
        {
            get
            {
                return createdate;
            }
            set
            {
                createdate = value;
            }
        }

        public DateTime? EditDate
        {
            get
            {
                return editdate;
            }
            set
            {
                editdate = value;
            }
        }

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
        #endregion
    }
}