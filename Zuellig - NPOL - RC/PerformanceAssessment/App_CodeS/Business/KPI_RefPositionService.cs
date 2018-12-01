using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class KPI_RefPositionService
    {
        public static DataTable GetAllPosition()
        {
            KPI_RefPositionDAO newsDAO = new KPI_RefPositionDAO();
            return newsDAO.GetAllPosition("spKPI_GetAllPosition_RefKPI", "AllPosition");
        }

        public static DataTable GetKPI_RefPosition(string PosID)
        {
            KPI_RefPositionDAO newsDAO = new KPI_RefPositionDAO();
            return newsDAO.GetKPI_RefPosition("spKPI_GetKPI_RefPosition", "KPI_RefPosition", PosID);
        }

        public bool CreateNew(tbl_KPI_RefPosition obj)
        {
            KPI_RefPositionDAO newDAO = new KPI_RefPositionDAO();
            return newDAO.CreateNew(obj);
        }

        public static bool DeleteByID(int ID)
        {
            KPI_RefPositionDAO newDAO = new KPI_RefPositionDAO();
            return newDAO.DeleteByID(ID);
        }
    }
}