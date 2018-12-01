using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_EmpFeedback
    {
        private int id;
        private string empid;
        private string empName;
        private string content;
        private string training;
        private string lineName;
        private string depName;
        private string teamName;
        private string locationName;
        private DateTime createdate;
        private DateTime? editdate;


        public tbl_EmpFeedback()
        {
            empid = "";
            empName = "";
            content = "";
            training = "";
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
        public string TrainingDetail
        {
            get
            {
                return training;
            }
            set
            {
                training = value;
            }
        }
        public string LineName
        {
            get
            {
                return lineName;
            }
            set
            {
                lineName = value;
            }
        }

        public string DepName
        {
            get
            {
                return depName;
            }
            set
            {
                depName = value;
            }
        }
        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
            }
        }
        public string LocationName
        {
            get
            {
                return locationName;
            }
            set
            {
                locationName = value;
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