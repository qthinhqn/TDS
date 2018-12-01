using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_EmpKPI_Detail
    {
        private int id;
        private int empKPI_id;
        private int kpi_id;
        private string real_Description;
        private string real_Target;
        private string real_Doneby;
        private double score;
        private double adj_Score;
        private double important;
        private double adj_Important;
        private double point;
        private double adj_Point;
        public tbl_EmpKPI_Detail()
        {
            real_Target = "";
            real_Doneby = "";
            score = 0;
            important = 0;
            point = 0;
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
        public int EmpKPI_id
        {
            get
            {
                return empKPI_id;
            }
            set
            {
                empKPI_id = value;
            }
        }
        public int KPI_id
        {
            get
            {
                return kpi_id;
            }
            set
            {
                kpi_id = value;
            }
        }
        public string Real_Description
        {
            get
            {
                return real_Description;
            }
            set
            {
                real_Description = value;
            }
        }
        public string Real_Target
        {
            get
            {
                return real_Target;
            }
            set
            {
                real_Target = value;
            }
        }
        public string Real_Doneby
        {
            get
            {
                return real_Doneby;
            }
            set
            {
                real_Doneby = value;
            }
        }
        public double Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public double Adj_Score
        {
            get
            {
                return adj_Score;
            }
            set
            {
                adj_Score = value;
            }
        }
        public double Important
        {
            get
            {
                return important;
            }
            set
            {
                important = value;
            }
        }
        public double Adj_Important
        {
            get
            {
                return adj_Important;
            }
            set
            {
                adj_Important = value;
            }
        }
        public double Point
        {
            get
            {
                return point;
            }
            set
            {
                point = value;
            }
        }
        public double Adj_Point
        {
            get
            {
                return adj_Point;
            }
            set
            {
                adj_Point = value;
            }
        }
        #endregion
    }
}