using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class Store_CompetencyService
    {
        public static DataTable GetAllStore_Competency()
        {
            Store_CompetencyDAO newsDAO = new Store_CompetencyDAO();
            return newsDAO.GetAllStore_Competency("GetAllStore_Competency", "AllStore_Competency");
        }

        public bool CreateNew(tbl_Store_Competency obj)
        {
            Store_CompetencyDAO newDAO = new Store_CompetencyDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            Store_CompetencyDAO newDAO = new Store_CompetencyDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_Store_Competency obj)
        {
            Store_CompetencyDAO newDAO = new Store_CompetencyDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_Store_Competency GetObjectById(int ID)
        {
            Store_CompetencyDAO newDAO = new Store_CompetencyDAO();
            return newDAO.GetObjectById("spGetKPI_StoreCompetency_ById", ID);
        }
    }
}