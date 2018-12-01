using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class Competency_KPIService
    {
        public static DataTable GetAllKPI_Period()
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetAllRefCompetency("spKPI_GetAllCompetency_KPI", "AllCompetency_KPI");
        }

        public bool CreateNew(tbl_Competency_KPI obj)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_Competency_KPI obj)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateByID(obj);
        }

        public bool UpdateNotes(tbl_Competency_KPI obj)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateNotes(obj);
        }

        public tbl_Competency_KPI GetObjectById(int ID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.GetObjectById("spKPI_Competency_ById", ID);
        }

        public tbl_Competency_KPI GetObjectByEmpId(string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.GetObjectByEmpId("spKPI_Competency_ByEmpId", EmployeeID, PeriodID);
        }

        public int GetCurrentStep(string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.GetCurrentStep("spKPI_Competency_GetCurrentStep", EmployeeID, PeriodID);
        }

        public bool UpdateScore(string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateScore("spKPI_Competency_UpdateScore", EmployeeID, PeriodID);
        }

        public bool UpdateKPIPoint(string EmployeeID, int PeriodID, double KPIPoint)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateKPIPoint("spKPI_Competency_UpdateKPIPoint", EmployeeID, PeriodID, KPIPoint);
        }

        public bool UpdateFactor(string EmployeeID, int PeriodID, double jobFactor, double kpiFactor)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateFactor("spKPI_Competency_UpdateFactor", EmployeeID, PeriodID, jobFactor, kpiFactor);
        }
        public bool UpdateFactorByID(int ID, double jobFactor, double kpiFactor)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateFactorByID("spKPI_Competency_UpdateFactorByID", ID, jobFactor, kpiFactor);
        }

        public bool IsCompletedAssess(string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.IsCompletedAssess("spKPI_Competency_IsCompletedAssess", EmployeeID, PeriodID);
        }
        public DataTable GetTable_rptEmpKPI(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptEmpKPI(Procedure_Name, "rptEmpKPI", EmployeeID, PeriodID);
        }

        public static DataTable GetTable_rptEmpHistory(string Procedure_Name, string EmployeeID, int Period_ID)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptEmpHistory(Procedure_Name, "rptEmpKPI", EmployeeID, Period_ID);
        }

        public DataTable GetTable_rptGeneralKPI(int PeriodID)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptGeneralKPI("spKPI_GetTable_rptGeneralKPI", "rptEmpKPI", PeriodID);
        }

        public static DataTable GetTable_EmployeeRating(string EmployeeID, int Period_ID)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptEmpKPI("spKPI_GetTable_rptEmpKPI", "rptEmpKPI", EmployeeID, Period_ID);
        }
        public static DataTable GetTableRpt_RatingPercent(string EmployeeID, int Period_ID)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptEmpKPI("spKPI_GetRpt_RatingPercent", "rptEmpKPI", EmployeeID, Period_ID);
        }
        public static DataTable GetTableRpt_RatingPercent_2(string EmployeeID, int Period_ID, string Location, bool level3)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.GetTable_rptRatingPercent("spKPI_GetRpt_RatingPercent", "rptEmpKPI", EmployeeID, Period_ID, Location, level3);
        }

        public object getCurrentLevel(object id, object managerid)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.getCurrentLevel(id, managerid);
        }


        public bool isLastLevel(object id, object currentLevel)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.isLastLevel(id, currentLevel);
        }

        public bool isFirstLastLevel(object id, object currentLevel)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.isFirstLastLevel(id, currentLevel);
        }

        public bool ApproveFirst(object id, object level, object reason)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.ApproveFirst(id, level, reason);
        }

        public bool ApproveLast(object id, object level, object reason)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.ApproveLast(id, level, reason);
        }

        public bool CancelApproval(object id, object level, object reason)
        {
            Competency_KPIDAO newsDAO = new Competency_KPIDAO();
            return newsDAO.CancelApproval(id, level, reason);
        }

    }
}