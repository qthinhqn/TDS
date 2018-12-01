using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class Store_KPIService
    {
        public static DataTable GetAllStore_KPI()
        {
            Store_KPIDAO newsDAO = new Store_KPIDAO();
            return newsDAO.GetAllStore_KPI("GetAllStore_KPI", "AllStore_KPI");
        }

        public bool CreateNew(tbl_Store_KPI obj)
        {
            Store_KPIDAO newDAO = new Store_KPIDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            Store_KPIDAO newDAO = new Store_KPIDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_Store_KPI obj)
        {
            Store_KPIDAO newDAO = new Store_KPIDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_Store_KPI GetObjectById(int ID)
        {
            Store_KPIDAO newDAO = new Store_KPIDAO();
            return newDAO.GetObjectById("spGetKPI_StoreKPI_ById", ID);
        }
    }
}