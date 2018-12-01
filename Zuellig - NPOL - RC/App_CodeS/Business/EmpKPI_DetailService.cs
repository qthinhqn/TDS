using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class EmpKPI_DetailService
    {
        public static DataTable GetEmpKPI_ByPeriod(string EmployeeID, int Period_ID)
        {
            EmpKPI_DetailDAO newsDAO = new EmpKPI_DetailDAO();
            return newsDAO.GetEmpKPI_ByPeriod("spKPI_GetEmpKPI_ByPeriod", "EmpKPI_ByPeriod", EmployeeID, Period_ID);
        }

        public bool CreateNew(tbl_EmpKPI_Detail obj)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_EmpKPI_Detail obj)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.UpdateByID(obj);
        }

        public bool UpdateAdj_ByID(tbl_EmpKPI_Detail obj)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.UpdateAdj_ByID(obj);
        }

        public tbl_EmpKPI_Detail GetObjectById(int ID)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.GetObjectById("spKPI_EmpKPI_Detail_ById", ID);
        }

        public static DataTable GetCompetency_Level1(int PeriodID)
        {
            int ShowType = 1;
            EmpKPI_DetailDAO newsDAO = new EmpKPI_DetailDAO();
            return newsDAO.GetCompetency_Level1("spKPI_GetCompetency_Level1", "Competency_Level1", PeriodID, ShowType);
        }

        public static DataTable GetDetailCompetency(int PeriodID, int parentID, string EmployeeID)
        {
            EmpKPI_DetailDAO newsDAO = new EmpKPI_DetailDAO();
            return newsDAO.GetEmpCompetencyDetail("spKPI_GetDetailCompetency", "DetailCompetency", PeriodID, parentID, EmployeeID);
        }

        public static DataTable GetSubChildCompetency(int PeriodID, int subParentID)
        {
            int ShowType = 1;
            EmpKPI_DetailDAO newsDAO = new EmpKPI_DetailDAO();
            return newsDAO.GetDetailCompetency("spKPI_GetChildCompetency", "SubChildCompetency", PeriodID, subParentID, ShowType);
        }

        public bool UpdateRating(string EmployeeID, int PeriodID, int competency_id, double rating, double important)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.UpdateRating(EmployeeID, PeriodID, competency_id, rating, important);
        }

        public bool CreateNew(string EmployeeID, int PeriodID, int kpi_id, double rating, double important)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.CreateNew(EmployeeID, PeriodID, kpi_id, rating, important);
        }

        public bool UpdateAdj_Score(string EmployeeID, int PeriodID, int kpi_id, double score, double important)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.UpdateAdj_Score(EmployeeID, PeriodID, kpi_id, score, important);
        }

        public int CountSameImportant(string EmployeeID, int PeriodID, float important)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.CountSameImportant(EmployeeID, PeriodID, important);
        }


        public bool UpdateWeight(int KPI_ID, string EmployeeID, int YearID, double weight)
        {
            EmpKPI_DetailDAO newDAO = new EmpKPI_DetailDAO();
            return newDAO.UpdateWeight(KPI_ID, EmployeeID, YearID, weight);
        }
    }
}