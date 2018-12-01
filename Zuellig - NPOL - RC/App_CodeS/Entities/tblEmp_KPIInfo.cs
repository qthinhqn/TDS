using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tblEmp_KPIInfo
    {
        private int iD;
        private int period_ID;
        private string employeeID;
        private string employeeName;
        private string levelID;
        private string sectionID;
        private string sectionName;
        private string lineID;
        private string lineName;
        private string depID;
        private string depName;
        private string teamID;
        private string teamName;
        private string partID;
        private string partName;
        private string posID;
        private string posName;
        private string locationID;
        private string locationName;
        private double basicSalary;
        private double averageSalary;
        private double incentive;
        private DateTime startDate;
        private double days;
        private double maternityDays;
        private double actualWD;
        private double pA;
        private string notes;
        public tblEmp_KPIInfo()
        { }

        #region
        public int ID
        {
            get { return this.iD; }
            set
            {
                if (value == null)
                    throw new Exception("iD not allow nullvalue.");
                this.iD = value;
            }
        }
        public int Period_ID
        {
            get { return this.period_ID; }
            set { this.period_ID = value; }
        }
        public string EmployeeID
        {
            get { return this.employeeID; }
            set
            {
                if (value == null)
                    throw new Exception("employeeID not allow nullvalue.");
                this.employeeID = value;
            }
        }
        public string EmployeeName
        {
            get { return this.employeeName; }
            set { this.employeeName = value; }
        }
        public string LevelID
        {
            get { return this.levelID; }
            set { this.levelID = value; }
        }
        public string SectionID
        {
            get { return this.sectionID; }
            set { this.sectionID = value; }
        }
        public string SectionName
        {
            get { return this.sectionName; }
            set { this.sectionName = value; }
        }
        public string LineID
        {
            get { return this.lineID; }
            set { this.lineID = value; }
        }
        public string LineName
        {
            get { return this.lineName; }
            set { this.lineName = value; }
        }
        public string DepID
        {
            get { return this.depID; }
            set { this.depID = value; }
        }
        public string DepName
        {
            get { return this.depName; }
            set { this.depName = value; }
        }
        public string TeamID
        {
            get { return this.teamID; }
            set { this.teamID = value; }
        }
        public string TeamName
        {
            get { return this.teamName; }
            set { this.teamName = value; }
        }
        public string PartID
        {
            get { return this.partID; }
            set { this.partID = value; }
        }
        public string PartName
        {
            get { return this.partName; }
            set { this.partName = value; }
        }
        public string PosID
        {
            get { return this.posID; }
            set { this.posID = value; }
        }
        public string PosName
        {
            get { return this.posName; }
            set { this.posName = value; }
        }
        public string LocationID
        {
            get { return this.locationID; }
            set { this.locationID = value; }
        }
        public string LocationName
        {
            get { return this.locationName; }
            set { this.locationName = value; }
        }
        public double BasicSalary
        {
            get { return this.basicSalary; }
            set { this.basicSalary = value; }
        }
        public double AverageSalary
        {
            get { return this.averageSalary; }
            set { this.averageSalary = value; }
        }
        public double Incentive
        {
            get { return this.incentive; }
            set { this.incentive = value; }
        }
        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }
        public double Days
        {
            get { return this.days; }
            set { this.days = value; }
        }
        public double MaternityDays
        {
            get { return this.maternityDays; }
            set { this.maternityDays = value; }
        }
        public double ActualWD
        {
            get { return this.actualWD; }
            set { this.actualWD = value; }
        }
        public double PA
        {
            get { return this.pA; }
            set { this.pA = value; }
        }
        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        #endregion
    }
}