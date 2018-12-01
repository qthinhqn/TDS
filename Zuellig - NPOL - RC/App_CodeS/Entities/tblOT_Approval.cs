using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblOT_Approval
    {
        private int id;
        private int? regid;
        private int? levelno;
        private string managerID;
        private DateTime? approvingDate;
        private string approvingReason;
        private bool? approvingStatus;
        private int? mailToManager;

        public tblOT_Approval()
        {
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
        public int? RegID
        {
            get
            {
                return regid;
            }
            set
            {
                regid = value;
            }
        }
        public int? LevelNo
        {
            get
            {
                return levelno;
            }
            set
            {
                levelno = value;
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
        public DateTime? ApprovingDate
        {
            get
            {
                return approvingDate;
            }
            set
            {
                approvingDate = value;
            }
        }
        public string ApprovingReason
        {
            get
            {
                return approvingReason;
            }
            set
            {
                approvingReason = value;
            }
        }

        public bool? ApprovingStatus
        {
            get
            {
                return approvingStatus;
            }
            set
            {
                approvingStatus = value;
            }
        }

        public int? MailToManager
        {
            get
            {
                return mailToManager;
            }
            set
            {
                mailToManager = value;
            }
        }
        #endregion
    }
}