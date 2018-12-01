using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class Ref_GuidelineService
    {
        public static DataTable GetAllKPI_Period()
        {
            Ref_GuidelineDAO newsDAO = new Ref_GuidelineDAO();
            return newsDAO.GetAllRefCompetency("spKPI_GetAllCompetency_KPI", "AllCompetency_KPI");
        }

        public bool CreateNew(tblRef_Guideline obj)
        {
            Ref_GuidelineDAO newDAO = new Ref_GuidelineDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            Ref_GuidelineDAO newDAO = new Ref_GuidelineDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tblRef_Guideline obj)
        {
            Ref_GuidelineDAO newDAO = new Ref_GuidelineDAO();
            return newDAO.UpdateByID(obj);
        }

        public bool UpdateNotes(tblRef_Guideline obj)
        {
            Ref_GuidelineDAO newDAO = new Ref_GuidelineDAO();
            return newDAO.UpdateNotes(obj);
        }

        public tblRef_Guideline GetObjectById(int ID)
        {
            Ref_GuidelineDAO newDAO = new Ref_GuidelineDAO();
            return newDAO.GetObjectById("spKPI_Competency_ById", ID);
        }

        
        public static DataTable GetTable_EmployeeRating(string EmployeeID, int Period_ID)
        {
            Ref_GuidelineDAO newsDAO = new Ref_GuidelineDAO();
            return newsDAO.GetTable_rptEmpKPI("spKPI_GetTable_rptEmpKPI", "rptEmpKPI", EmployeeID, Period_ID);
        }
    }
}