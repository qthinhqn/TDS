using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblRecruit_EmpGroup
    {
        private string empid;
        private string representativeID;
        private DateTime dateChange;
        private string sectionID;
        private string lineID;
        private string posID;

        public tblRecruit_EmpGroup()
        {
            empid = "";
            representativeID = "";
            dateChange = DateTime.Now;
            sectionID = "";
            lineID = "";
            posID = "";
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
        public string RepresentativeID
        {
            get
            {
                return representativeID;
            }
            set
            {
                representativeID = value;
            }
        }
        public DateTime DateChange
        {
            get
            {
                return dateChange;
            }
            set
            {
                dateChange = value;
            }
        }
        public string SectionID
        {
            get
            {
                return sectionID;
            }
            set
            {
                sectionID = value;
            }
        }

        public string LineID
        {
            get
            {
                return lineID;
            }
            set
            {
                lineID = value;
            }
        }

        public string PosID
        {
            get
            {
                return posID;
            }
            set
            {
                posID = value;
            }
        }
        #endregion
    }
}