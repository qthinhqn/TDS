using PAOL.App_Code.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PAOL.App_Code.Entities;

namespace PAOL.App_Code.Business
{
    public class RefTargetService
    {
        public static DataTable GetAllTargetRef()
        {
            RefTargetDAO newsDAO = new RefTargetDAO();
            return newsDAO.GetAllTargetRef("spKPI_GetAllTargetRef", "AllTargetRef");
        }

        public bool CreateNew(tbl_KPI_RefTarget obj)
        {
            RefTargetDAO newDAO = new RefTargetDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            RefTargetDAO newDAO = new RefTargetDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_KPI_RefTarget obj)
        {
            RefTargetDAO newDAO = new RefTargetDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_KPI_RefTarget GetObjectById(int ID)
        {
            RefTargetDAO newDAO = new RefTargetDAO();
            return newDAO.GetObjectById("spGetKPI_RefTarget_ById", ID);
        }
    }
}