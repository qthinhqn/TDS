using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblPA_FilterByManager
    {
        private int id;
        private string filterID;
        private string managerID;
        private string managerName;
        private string parentID;
        private bool status;

        public tblPA_FilterByManager()
        {
            filterID = "";
            managerID = "";
            managerName = "";
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
        public string ManagerID
        {
            get
            {
                return managerID;
            }
            set
            {
                managerID = value;
            }
        }
        public string ManagerName
        {
            get
            {
                return managerName;
            }
            set
            {
                managerName = value;
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