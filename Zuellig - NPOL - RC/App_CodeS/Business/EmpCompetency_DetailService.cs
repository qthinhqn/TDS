using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class EmpCompetency_DetailService
    {
        public static DataTable GetAllKPI_Period()
        {
            EmpCompetency_DetailDAO newsDAO = new EmpCompetency_DetailDAO();
            return newsDAO.GetAllRefCompetency("spKPI_GetAllRefCompetency", "AllRefCompetency");
        }

        public bool CreateNew(tbl_EmpCompetency_Detail obj)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_EmpCompetency_Detail obj)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_EmpCompetency_Detail GetObjectById(int ID)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.GetObjectById("spKPI_RefCompetency_ById", ID);
        }

        public static DataTable GetCompetency_Level1(int PeriodID)
        {
            int ShowType = 1;
            EmpCompetency_DetailDAO newsDAO = new EmpCompetency_DetailDAO();
            return newsDAO.GetCompetency_Level1("spKPI_GetCompetency_Level1", "Competency_Level1", PeriodID, ShowType);
        }

        public static DataTable GetDetailCompetency(int PeriodID, int parentID, string EmployeeID)
        {
            EmpCompetency_DetailDAO newsDAO = new EmpCompetency_DetailDAO();
            return newsDAO.GetEmpCompetencyDetail("spKPI_GetDetailCompetency", "DetailCompetency", PeriodID, parentID, EmployeeID);
        }

        public static DataTable GetSubChildCompetency(int PeriodID, int subParentID)
        {
            int ShowType = 1;
            EmpCompetency_DetailDAO newsDAO = new EmpCompetency_DetailDAO();
            return newsDAO.GetDetailCompetency("spKPI_GetChildCompetency", "SubChildCompetency", PeriodID, subParentID, ShowType);
        }

        public bool UpdateScore(string EmployeeID, int PeriodID, int competency_id, double score, double important)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.UpdateScore(EmployeeID, PeriodID, competency_id, score, important);
        }
        public bool UpdateAdj_Score(string EmployeeID, int PeriodID, int competency_id, object score, double important)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.UpdateAdj_Score(EmployeeID, PeriodID, competency_id, score, important);
        }

        public int CountSameImportant(string EmployeeID, int PeriodID, int competency_id, double important)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.CountSameImportant(EmployeeID, PeriodID, competency_id, important);
        }

        public int check4Time(string EmployeeID, int period, int competency_id, double point, double important)
        {
            EmpCompetency_DetailDAO newDAO = new EmpCompetency_DetailDAO();
            return newDAO.check4Time(EmployeeID, period, competency_id, point, important);
        }
    }
}