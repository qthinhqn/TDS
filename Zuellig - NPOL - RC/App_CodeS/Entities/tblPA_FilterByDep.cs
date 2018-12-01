using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblPA_FilterByDep
    {
        private int id;
        private string filterID;
        private string depID;
        private string depName;
        private string parentID;
        private bool status;

        public tblPA_FilterByDep()
        {
            filterID = "";
            depID = "";
            depName = "";
            parentID = "";
            status = false;
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
        public string FilterID
        {
            get
            {
                return filterID;
            }
            set
            {
                filterID = value;
            }
        }
        public string DepID
        {
            get
            {
                return depID;
            }
            set
            {
                depID = value;
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
        public string ParentID
        {
            get
            {
                return parentID;
            }
            set
            {
                parentID = value;
            }
        }
        public bool Status
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
        #endregion
    }
}