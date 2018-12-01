using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    [Serializable]
    public class tblRef_Department
    {
        private string group;
        private string depID;
        private string depKey;
        private string depName;
        private string depName_VN;
        private string depParent;
        private string depTypeID;
        private string direct;
        private string notes;
        private int basicWD;
        private int orderNo;
        private string centerCode;
        private string mealSection;
        private string rpt_Dep;
        private string rpt_Line;
        private string rpt_Group;
        private string isUnlimitContract;
        private string isBreakAllowance;
        private string isJobAllowance;
        private float jobAllowance;
        private string depName_Japan;
        private float a_Harmful;
        public tblRef_Department()
        { }

        #region

        public string Group
        {
            get { return this.group; }
            set { this.group = value; }
        }
        public string DepID
        {
            get { return this.depID; }
            set
            {
                if (value == null)
                    throw new Exception("depID not allow nullvalue.");
                this.depID = value;
            }
        }
        public string DepKey
        {
            get { return this.depKey; }
            set { this.depKey = value; }
        }
        public string DepName
        {
            get { return this.depName; }
            set { this.depName = value; }
        }
        public string DepName_VN
        {
            get { return this.depName_VN; }
            set { this.depName_VN = value; }
        }
        public string DepParent
        {
            get { return this.depParent; }
            set { this.depParent = value; }
        }
        public string DepTypeID
        {
            get { return this.depTypeID; }
            set { this.depTypeID = value; }
        }
        public string Direct
        {
            get { return this.direct; }
            set { this.direct = value; }
        }
        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }
        public int BasicWD
        {
            get { return this.basicWD; }
            set { this.basicWD = value; }
        }
        public int OrderNo
        {
            get { return this.orderNo; }
            set { this.orderNo = value; }
        }
        public string CenterCode
        {
            get { return this.centerCode; }
            set { this.centerCode = value; }
        }
        public string MealSection
        {
            get { return this.mealSection; }
            set { this.mealSection = value; }
        }
        public string Rpt_Dep
        {
            get { return this.rpt_Dep; }
            set { this.rpt_Dep = value; }
        }
        public string Rpt_Line
        {
            get { return this.rpt_Line; }
            set { this.rpt_Line = value; }
        }
        public string Rpt_Group
        {
            get { return this.rpt_Group; }
            set { this.rpt_Group = value; }
        }
        public string IsUnlimitContract
        {
            get { return this.isUnlimitContract; }
            set { this.isUnlimitContract = value; }
        }
        public string IsBreakAllowance
        {
            get { return this.isBreakAllowance; }
            set { this.isBreakAllowance = value; }
        }
        public string IsJobAllowance
        {
            get { return this.isJobAllowance; }
            set { this.isJobAllowance = value; }
        }
        public float JobAllowance
        {
            get { return this.jobAllowance; }
            set { this.jobAllowance = value; }
        }
        public string DepName_Japan
        {
            get { return this.depName_Japan; }
            set { this.depName_Japan = value; }
        }
        public float A_Harmful
        {
            get { return this.a_Harmful; }
            set { this.a_Harmful = value; }
        }
        public override bool Equals(Object obj)
        {
            tblRef_Department me = (tblRef_Department)obj;
            bool ret = this.DepID.Equals(me.DepID);
            return ret;
        }
        public override int GetHashCode()
        {
            return this.DepID.GetHashCode();
        }


        #endregion
    }
}