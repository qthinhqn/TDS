using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblPA_FilterByLocation
    {
        private int id;
        private string filterID;
        private string locationID;
        private string locationName;
        private bool status;

        public tblPA_FilterByLocation()
        {
            filterID = "";
            locationID = "";
            locationName = "";
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
        public string LocationID
        {
            get
            {
                return locationID;
            }
            set
            {
                locationID = value;
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