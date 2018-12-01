using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System.Data;

namespace PAOL.App_Code.Business
{
    public class KPI_RequireTrainingService
    {
        public static DataTable GetAllRequirement(int PeriodID)
        {
            KPI_RequireTrainingDAO newsDAO = new KPI_RequireTrainingDAO();
            return newsDAO.GetAllRequirement("spKPI_GetAllRequireTraining", "AllRequireTraining", PeriodID);
        }

        public static DataTable GetAllRequirementByEmployee(int PeriodID, string EmployeeID)
        {
            KPI_RequireTrainingDAO newsDAO = new KPI_RequireTrainingDAO();
            return newsDAO.GetAllRequirementByEmployee("spKPI_GetRequirementByEmployee", "AllRequire_Employee", PeriodID, EmployeeID);
        }
        public bool CreateNew(tbl_KPIRequireTraining obj)
        {
            KPI_RequireTrainingDAO newDAO = new KPI_RequireTrainingDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            KPI_RequireTrainingDAO newDAO = new KPI_RequireTrainingDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_KPIRequireTraining obj)
        {
            KPI_RequireTrainingDAO newDAO = new KPI_RequireTrainingDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_KPIRequireTraining GetObjectById(int ID)
        {
            KPI_RequireTrainingDAO newDAO = new KPI_RequireTrainingDAO();
            return newDAO.GetObjectById("spGetKPI_RequireTraining_ById", ID);
        }

        public tbl_KPIRequireTraining GetObjectByEmp(string EmployeeID, int PeriodID)
        {
            KPI_RequireTrainingDAO newDAO = new KPI_RequireTrainingDAO();
            return newDAO.GetObjectByEmp("spKPI_RequireTraining_ByEmp", EmployeeID, PeriodID);
        }
    }
}