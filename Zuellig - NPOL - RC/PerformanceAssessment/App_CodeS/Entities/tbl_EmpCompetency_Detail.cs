using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_EmpCompetency_Detail
    {
        private int id;
        private int empCompetency_id;
        private int competency_id;
        private double score;
        private double adj_Score;
        private double important;
        private double adj_Important;
        private double point;
        private double adj_Point;
        public tbl_EmpCompetency_Detail()
        {
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
        public int EmpCompetency_id
        {
            get
            {
                return empCompetency_id;
            }
            set
            {
                empCompetency_id = value;
            }
        }
        public int Competency_id
        {
            get
            {
                return competency_id;
            }
            set
            {
                competency_id = value;
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