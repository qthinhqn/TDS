using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class KPI_PeriodService
    {
        public static DataTable GetAllKPI_Period()
        {
            KPI_PeriodDAO newsDAO = new KPI_PeriodDAO();
            return newsDAO.GetAllKPI_Period("spKPI_GetAllPeriod", "AllKPI_Period");
        }

        public bool CreateNew(tbl_KPI_Period obj)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_KPI_Period obj)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_KPI_Period GetObjectById(int ID)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.GetObjectById("spGetKPI_Period_ById", ID);
        }

        public static int GetKPI_InProcess()
        {
            KPI_PeriodDAO newsDAO = new KPI_PeriodDAO();
            return newsDAO.GetKPI_InProcess("spKPI_InProcess");
        }

        public static int GetKPI_LastActive()
        {
            KPI_PeriodDAO newsDAO = new KPI_PeriodDAO();
            return newsDAO.GetKPI_InProcess("spKPI_GetLastActive");
        }

        // Check allow edit
        public bool AllowEdit(int ID)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.AllowEdit("spKPI_Period_AllowEdit", ID);
        }
        // Check allow delete
        public bool AllowDelete(int ID)
        {
            KPI_PeriodDAO newDAO = new KPI_PeriodDAO();
            return newDAO.AllowDelete("spKPI_Period_AllowDelete", ID);
        }
    }
}