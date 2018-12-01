using System;

namespace NPOL.App_Code.Entities
{
    [Serializable]
    public class tblCand_Request_Online
    {
        private string requestID;
        private DateTime? dateID;
        private DateTime? receivedDate;
        private DateTime? deadLine;
        private DateTime? finalDate;
        private string recruitByID;
        private string sectionID;
        private string lineID;
        private string depID;
        private string levelID;
        private string posID;
        private string regionID;
        private int numof;
        private string typeID;
        private string reasonID;
        private string empID_Replace;
        private double empReplace_Sal;
        private double empReplace_Allowance;
        private bool isInternalPost;
        private string locationID;
        private string sexID;
        private bool jobDes;
        private string jobDes_File;
        private bool isBudgetHead;
        private DateTime? startDate;
        private string probationID;
        private double probation_Sal;
        private double probation_Travel;
        private double probation_Allowance;
        private double permanent_Sal;
        private double permanent_Travel;
        private double permanent_Allowance;
        private string requester;
        private string reportTo;
        private string approvedBy;
        private DateTime? approvedDate;
        private string hRDept_Note;
        private string contractID;
        private string empID_Other;
        private string empID_Apply;
        private string apply_Name;
        private string to_LineID;
        private string to_DepID;
        private string to_LocationID;
        private string to_PosID;
        private string other_old;
        private string other_new;
        // new add
        private string otherDescription;
        private string other_oldValue;
        private string other_newValue;

        private string proAdj_Type;
        private string other_old2Value;
        private string other_new2Value;

        private Boolean regtype;
        private string remarks;

        public tblCand_Request_Online()
        {
            //set null Date Fields
            this.dateID = null;
            this.receivedDate = null;
            this.deadLine = null;
            this.finalDate = null;
            this.startDate = null;
            this.approvedDate = null;
        }
        public tblCand_Request_Online(string requestID, DateTime dateID, DateTime receivedDate, DateTime deadLine, DateTime finalDate, string recruitByID, string sectionID, string lineID, string depID, string levelID, string posID, string regionID, int numof, string typeID, string reasonID, string empID_Replace, double empReplace_Sal, double empReplace_Allowance, bool isInternalPost, string locationID, string sexID, bool jobDes, string jobDes_File, bool isBudgetHead, DateTime startDate, string probationID, double probation_Sal, double probation_Travel, double probation_Allowance, double permanent_Sal, double permanent_Travel, double permanent_Allowance, string requester, string reportTo, string approvedBy, DateTime approvedDate, string hRDept_Note, string contractID, string empID_Other, string empID_Apply, string apply_Name, string to_LineID, string to_DepID, string to_LocationID, string to_PosID, string other_old, string other_new, Boolean RegType, string other_old2, string other_new2)
        {
            this.requestID = requestID;
            this.dateID = dateID;
            this.receivedDate = receivedDate;
            this.deadLine = deadLine;
            this.finalDate = finalDate;
            this.recruitByID = recruitByID;
            this.sectionID = sectionID;
            this.lineID = lineID;
            this.depID = depID;
            this.levelID = levelID;
            this.posID = posID;
            this.regionID = regionID;
            this.numof = numof;
            this.typeID = typeID;
            this.reasonID = reasonID;
            this.empID_Replace = empID_Replace;
            this.empReplace_Sal = empReplace_Sal;
            this.empReplace_Allowance = empReplace_Allowance;
            this.isInternalPost = isInternalPost;
            this.locationID = locationID;
            this.sexID = sexID;
            this.jobDes = jobDes;
            this.jobDes_File = jobDes_File;
            this.isBudgetHead = isBudgetHead;
            this.startDate = startDate;
            this.probationID = probationID;
            this.probation_Sal = probation_Sal;
            this.probation_Travel = probation_Travel;
            this.probation_Allowance = probation_Allowance;
            this.permanent_Sal = permanent_Sal;
            this.permanent_Travel = permanent_Travel;
            this.permanent_Allowance = permanent_Allowance;
            this.requester = requester;
            this.reportTo = reportTo;
            this.approvedBy = approvedBy;
            this.approvedDate = approvedDate;
            this.hRDept_Note = hRDept_Note;
            this.contractID = contractID;
            this.empID_Other = empID_Other;
            this.empID_Apply = empID_Apply;
            this.apply_Name = apply_Name;
            this.to_LineID = to_LineID;
            this.to_DepID = to_DepID;
            this.to_LocationID = to_LocationID;
            this.to_PosID = to_PosID;
            this.other_old = other_old;
            this.other_new = other_new;

            this.regtype = RegType;
            this.other_old2Value = other_old2;
            this.other_new2Value = other_new2;
        }
        public string RequestID
        {
            get { return this.requestID; }
            set
            {
                if (value == null)
                    throw new Exception("requestID not allow nullvalue.");
                this.requestID = value;
            }
        }
        public DateTime? DateID
        {
            get { return this.dateID; }
            set { this.dateID = value; }
        }
        public DateTime? ReceivedDate
        {
            get { return this.receivedDate; }
            set { this.receivedDate = value; }
        }
        public DateTime? DeadLine
        {
            get { return this.deadLine; }
            set { this.deadLine = value; }
        }
        public DateTime? FinalDate
        {
            get { return this.finalDate; }
            set { this.finalDate = value; }
        }
        public string RecruitByID
        {
            get { return this.recruitByID; }
            set { this.recruitByID = value; }
        }
        public string SectionID
        {
            get { return this.sectionID; }
            set { this.sectionID = value; }
        }
        public string LineID
        {
            get { return this.lineID; }
            set { this.lineID = value; }
        }
        public string DepID
        {
            get { return this.depID; }
            set { this.depID = value; }
        }
        public string LevelID
        {
            get { return this.levelID; }
            set { this.levelID = value; }
        }
        public string PosID
        {
            get { return this.posID; }
            set { this.posID = value; }
        }
        public string RegionID
        {
            get { return this.regionID; }
            set { this.regionID = value; }
        }
        public int Numof
        {
            get { return this.numof; }
            set { this.numof = value; }
        }
        public string TypeID
        {
            get { return this.typeID; }
            set { this.typeID = value; }
        }
        public string ReasonID
        {
            get { return this.reasonID; }
            set { this.reasonID = value; }
        }
        public string EmpID_Replace
        {
            get { return this.empID_Replace; }
            set { this.empID_Replace = value; }
        }
        public double EmpReplace_Sal
        {
            get { return this.empReplace_Sal; }
            set { this.empReplace_Sal = value; }
        }
        public double EmpReplace_Allowance
        {
            get { return this.empReplace_Allowance; }
            set { this.empReplace_Allowance = value; }
        }
        public bool IsInternalPost
        {
            get { return this.isInternalPost; }
            set { this.isInternalPost = value; }
        }
        public string LocationID
        {
            get { return this.locationID; }
            set { this.locationID = value; }
        }
        public string SexID
        {
            get { return this.sexID; }
            set { this.sexID = value; }
        }
        public bool JobDes
        {
            get { return this.jobDes; }
            set { this.jobDes = value; }
        }
        public string JobDes_File
        {
            get { return this.jobDes_File; }
            set { this.jobDes_File = value; }
        }
        public bool IsBudgetHead
        {
            get { return this.isBudgetHead; }
            set { this.isBudgetHead = value; }
        }
        public DateTime? StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }
        public string ProbationID
        {
            get { return this.probationID; }
            set { this.probationID = value; }
        }
        public double Probation_Sal
        {
            get { return this.probation_Sal; }
            set { this.probation_Sal = value; }
        }
        public double Probation_Travel
        {
            get { return this.probation_Travel; }
            set { this.probation_Travel = value; }
        }
        public double Probation_Allowance
        {
            get { return this.probation_Allowance; }
            set { this.probation_Allowance = value; }
        }
        public double Permanent_Sal
        {
            get { return this.permanent_Sal; }
            set { this.permanent_Sal = value; }
        }
        public double Permanent_Travel
        {
            get { return this.permanent_Travel; }
            set { this.permanent_Travel = value; }
        }
        public double Permanent_Allowance
        {
            get { return this.permanent_Allowance; }
            set { this.permanent_Allowance = value; }
        }
        public string Requester
        {
            get { return this.requester; }
            set { this.requester = value; }
        }
        public string ReportTo
        {
            get { return this.reportTo; }
            set { this.reportTo = value; }
        }
        public string ApprovedBy
        {
            get { return this.approvedBy; }
            set { this.approvedBy = value; }
        }
        public DateTime? ApprovedDate
        {
            get { return this.approvedDate; }
            set { this.approvedDate = value; }
        }
        public string HRDept_Note
        {
            get { return this.hRDept_Note; }
            set { this.hRDept_Note = value; }
        }
        public string ContractID
        {
            get { return this.contractID; }
            set { this.contractID = value; }
        }
        public string EmpID_Other
        {
            get { return this.empID_Other; }
            set { this.empID_Other = value; }
        }
        public string EmpID_Apply
        {
            get { return this.empID_Apply; }
            set { this.empID_Apply = value; }
        }
        public string Apply_Name
        {
            get { return this.apply_Name; }
            set { this.apply_Name = value; }
        }
        public string To_LineID
        {
            get { return this.to_LineID; }
            set { this.to_LineID = value; }
        }
        public string To_DepID
        {
            get { return this.to_DepID; }
            set { this.to_DepID = value; }
        }
        public string To_LocationID
        {
            get { return this.to_LocationID; }
            set { this.to_LocationID = value; }
        }
        public string To_PosID
        {
            get { return this.to_PosID; }
            set { this.to_PosID = value; }
        }
        public string Other_old
        {
            get { return this.other_old; }
            set { this.other_old = value; }
        }
        public string Other_new
        {
            get { return this.other_new; }
            set { this.other_new = value; }
        }
        public string OtherDescription
        {
            get { return this.otherDescription; }
            set { this.otherDescription = value; }
        }
        public string Other_oldValue
        {
            get { return this.other_oldValue; }
            set { this.other_oldValue = value; }
        }
        public string Other_newValue
        {
            get { return this.other_newValue; }
            set { this.other_newValue = value; }
        }
        public string ProAdj_Type
        {
            get { return this.proAdj_Type; }
            set { this.proAdj_Type = value; }
        }
        public string Other_old2Value
        {
            get { return this.other_old2Value; }
            set { this.other_old2Value = value; }
        }
        public string Other_new2Value
        {
            get { return this.other_new2Value; }
            set { this.other_new2Value = value; }
        }

        public Boolean RegType
        {
            get { return this.regtype; }
            set { this.regtype = value; }
        }
        public override string ToString()
        {
            return this.requestID + "; " + this.dateID + "; " + this.receivedDate + "; " + this.deadLine + "; " + this.finalDate + "; " + this.recruitByID + "; " + this.sectionID + "; " + this.lineID + "; " + this.depID + "; " + this.levelID + "; " + this.posID + "; " + this.regionID + "; " + this.numof + "; " + this.typeID + "; " + this.reasonID + "; " + this.empID_Replace + "; " + this.empReplace_Sal + "; " + this.empReplace_Allowance + "; " + this.isInternalPost + "; " + this.locationID + "; " + this.sexID + "; " + this.jobDes + "; " + this.jobDes_File + "; " + this.to_LineID + "; " + this.to_DepID + "; " + this.to_LocationID + "; " + this.isBudgetHead + "; " + this.startDate + "; " + this.probationID + "; " + this.probation_Sal + "; " + this.probation_Travel + "; " + this.probation_Allowance + "; " + this.permanent_Sal + "; " + this.permanent_Travel + "; " + this.permanent_Allowance + "; " + this.requester + "; " + this.reportTo + "; " + this.approvedBy + "; " + this.approvedDate + "; " + this.hRDept_Note + "; " + this.contractID + "; " + this.empID_Other + "; " + this.empID_Apply + "; " + this.apply_Name + "; ";
        }
        public override bool Equals(Object obj)
        {
            tblCand_Request_Online me = (tblCand_Request_Online)obj;
            bool ret = this.RequestID.Equals(me.RequestID);
            return ret;
        }
        public override int GetHashCode()
        {
            return this.RequestID.GetHashCode();
        }


        public string Remarks
        {
            get { return this.remarks; }
            set { this.remarks = value; }
        }
    }
}