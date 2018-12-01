using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tblRef_Guideline
    {
        private int id;
        private int periodid;
        private double minRange;
        private double maxRange;
        private string description;
        private string expectation;
        private double real_Percent;
        private string notes;

        public tblRef_Guideline()
        {
            description = "";
            expectation = "";
            notes = "";
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
        public double MinRange
        {
            get
            {
                return minRange;
            }
            set
            {
                minRange = value;
            }
        }
        public double MaxRange
        {
            get
            {
                return maxRange;
            }
            set
            {
                maxRange = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public string Expectation
        {
            get
            {
                return expectation;
            }
            set
            {
                expectation = value;
            }
        }
        public double Real_Percent
        {
            get
            {
                return real_Percent;
            }
            set
            {
                real_Percent = value;
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
        #endregion
    }
}