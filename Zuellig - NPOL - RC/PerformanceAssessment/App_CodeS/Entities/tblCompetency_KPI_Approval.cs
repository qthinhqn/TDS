using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tblCompetency_KPI_Approval
    {
        private int id;
        private int refID;
        private string approval_L1;
        private Nullable<DateTime> dateApproval_L1;
        private Nullable<DateTime> dateUpdate_L1;
        private string note_L1;
        private string approval_L2;
        private Nullable<DateTime> dateApproval_L2;
        private Nullable<DateTime> dateUpdate_L2;
        private string note_L2;

        public tblCompetency_KPI_Approval()
        {
            approval_L1 = "";
            approval_L2 = "";
            note_L1 = "";
            note_L2 = "";
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
        public int EmpCompetency_KPI_ID
        {
            get
            {
                return refID;
            }
            set
            {
                refID = value;
            }
        }
        public string Approval_L1
        {
            get
            {
                return approval_L1;
            }
            set
            {
                approval_L1 = value;
            }
        }
        public Nullable<DateTime> DateApproval_L1
        {
            get
            {
                return dateApproval_L1;
            }
            set
            {
                dateApproval_L1 = value;
            }
        }
        public Nullable<DateTime> DateUpdate_L1
        {
            get
            {
                return dateUpdate_L1;
            }
            set
            {
                dateUpdate_L1 = value;
            }
        }
        public string Note_L1
        {
            get
            {
                return note_L1;
            }
            set
            {
                note_L1 = value;
            }
        }
        public string Approval_L2
        {
            get
            {
                return approval_L2;
            }
            set
            {
                approval_L2 = value;
            }
        }
        public Nullable<DateTime> DateApproval_L2
        {
            get
            {
                return dateApproval_L2;
            }
            set
            {
                dateApproval_L2 = value;
            }
        }
        public Nullable<DateTime> DateUpdate_L2
        {
            get
            {
                return dateUpdate_L2;
            }
            set
            {
                dateUpdate_L2 = value;
            }
        }
        public string Note_L2
        {
            get
            {
                return note_L2;
            }
            set
            {
                note_L2 = value;
            }
        }
        #endregion
    }
}