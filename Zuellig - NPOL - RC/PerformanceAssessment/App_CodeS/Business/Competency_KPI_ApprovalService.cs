using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class Competency_KPI_ApprovalService
    {
        public static DataTable GetAllStore_Competency()
        {
            Competency_KPI_ApprovalDAO newsDAO = new Competency_KPI_ApprovalDAO();
            return newsDAO.GetAllStore_Competency("GetAllCompetency_KPI_Approval", "AllCompetency_KPI_Approval");
        }

        public bool CreateNew(tblCompetency_KPI_Approval obj)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.CreateNew(obj);
        }
		
        public bool CreateNew(string EmployeeID, int PeriodID)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.CreateNew( EmployeeID, PeriodID);
        }

        public bool DeleteByID(int ID)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tblCompetency_KPI_Approval obj)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.UpdateByID(obj);
        }

        public tblCompetency_KPI_Approval GetObjectById(int ID)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.GetObjectById("spGetKPI_Competency_KPI_Approval_ById", ID);
        }

        public tblCompetency_KPI_Approval GetObjectByRefId(int EmpCompetency_KPI_ID)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.GetObjectById("spKPI_Competency_KPI_Approval_ByRefId", EmpCompetency_KPI_ID);
        }

        public bool UpdateNote_L1(tblCompetency_KPI_Approval obj)
        {
            Competency_KPI_ApprovalDAO newDAO = new Competency_KPI_ApprovalDAO();
            return newDAO.UpdateNote_L1(obj);
        }
    }
}