using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_Competency_KPI
    {
        private int id;
        private string employeeid;
        private int periodid;
        private double total_CompPoint;
        private double total_CompImportant;
        private double total_KPIPoint;
        private double total_KPIImportant;
        private double jobFactor;
        private double kpiFactor;
        private double ratingTotal;
        private string notes;
        private string step;

        public tbl_Competency_KPI()
        {
            employeeid = "";
            notes = "";
            step = "1";
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
        public string EmployeeID
        {
            get
            {
                return employeeid;
            }
            set
            {
                employeeid = value;
            }
        }
        public int Period_ID
        {
            get
            {
                return periodid;
            }
            set
            {
                periodid = value;
            }
        }
        public double Total_CompPoint
        {
            get
            {
                return total_CompPoint;
            }
            set
            {
                total_CompPoint = value;
            }
        }
        public double Total_CompImportant
        {
            get
            {
                return total_CompImportant;
            }
            set
            {
                total_CompImportant = value;
            }
        }
        public double Total_KPIPoint
        {
            get
            {
                return total_KPIPoint;
            }
            set
            {
                total_KPIPoint = value;
            }
        }
        public double Total_KPIImportant
        {
            get
            {
                return total_KPIImportant;
            }
            set
            {
                total_KPIImportant = value;
            }
        }
        public double JobFactor
        {
            get
            {
                return jobFactor;
            }
            set
            {
                jobFactor = value;
            }
        }
        public double KPIFactor
        {
            get
            {
                return kpiFactor;
            }
            set
            {
                kpiFactor = value;
            }
        }
        public double Rating_Total
        {
            get
            {
                return ratingTotal;
            }
            set
            {
                ratingTotal = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
        public string Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }
        #endregion
    }
}