using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class RefCompetencyService
    {
        public static DataTable GetAllKPI_Period()
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.GetAllRefCompetency("spKPI_GetAllRefCompetency", "AllRefCompetency");
        }

        public bool CreateNew(tbl_Ref_Competency obj)
        {
            RefCompetencyDAO newDAO = new RefCompetencyDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            RefCompetencyDAO newDAO = new RefCompetencyDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_Ref_Competency obj)
        {
            RefCompetencyDAO newDAO = new RefCompetencyDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_Ref_Competency GetObjectById(int ID)
        {
            RefCompetencyDAO newDAO = new RefCompetencyDAO();
            return newDAO.GetObjectById("spKPI_RefCompetency_ById", ID);
        }

        public static DataTable GetCompetency_Level1(int PeriodID, int ShowType)
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.GetCompetency_Level1("spKPI_GetCompetency_Level1", "Competency_Level1", PeriodID, ShowType);
        }
        public static DataTable GetCompetency_Level1_ByEmpID(string EmpID, int PeriodID, int ShowType)
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.GetCompetency_Level1_ByEmpID("spKPI_GetCompetency_Level1_ByEmpID", "Competency_Level1", EmpID, PeriodID, ShowType);
        }

        public static DataTable GetChildCompetency(int PeriodID, int parentID, int ShowType)
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.GetChildCompetency("spKPI_GetChildCompetency", "ChildCompetency", PeriodID, parentID, ShowType);
        }

        public static DataTable GetSubChildCompetency(int PeriodID, int subParentID, int ShowType)
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.GetChildCompetency("spKPI_GetChildCompetency", "SubChildCompetency", PeriodID, subParentID, ShowType);
        }

        public bool InsertRef(int competency_ID, int period_ID)
        {
            RefCompetencyDAO newsDAO = new RefCompetencyDAO();
            return newsDAO.InsertRef("spKPI_InsertRefCompetency", competency_ID, period_ID);
        }
    }
}