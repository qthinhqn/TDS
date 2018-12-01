using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class Requirement_TrainingService
    {
        public static DataTable GetAllKPI_Period()
        {
            Requirement_TrainingDAO newsDAO = new Requirement_TrainingDAO();
            return newsDAO.GetAllRefCompetency("spKPI_GetAllRequirement_Training", "AllRequirement_Training");
        }

        public bool CreateNew(tbl_Requirement_Training obj)
        {
            Requirement_TrainingDAO newDAO = new Requirement_TrainingDAO();
            return newDAO.CreateNew(obj);
        }

        public bool DeleteByID(int ID)
        {
            Requirement_TrainingDAO newDAO = new Requirement_TrainingDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tbl_Requirement_Training obj)
        {
            Requirement_TrainingDAO newDAO = new Requirement_TrainingDAO();
            return newDAO.UpdateByID(obj);
        }

        public tbl_Requirement_Training GetObjectById(int ID)
        {
            Requirement_TrainingDAO newDAO = new Requirement_TrainingDAO();
            return newDAO.GetObjectById("spKPI_Requirement_Training_ById", ID);
        }

    }
}