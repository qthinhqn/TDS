using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class ChangeManagerService
    {
        public static DataTable GetDataChangeManager()
        {
            ChangeManagerDAO newsDAO = new ChangeManagerDAO();
            return newsDAO.GetAllManager("spKPI_GetData_ChangeManager", "ChangeManagerList");
        }
        public static DataTable GetDataChangePAManager()
        {
            ChangeManagerDAO newsDAO = new ChangeManagerDAO();
            return newsDAO.GetAllManager("spKPI_GetDataChange_PAManager", "ChangePAManagerList");
        }
        public static DataTable GetAllManager()
        {
            ChangeManagerDAO newsDAO = new ChangeManagerDAO();
            return newsDAO.GetAllManager("spKPI_GetManagerList", "ManagerList");
        }

        public static DataTable GetAllPAManager()
        {
            ChangeManagerDAO newsDAO = new ChangeManagerDAO();
            return newsDAO.GetAllManager("spKPI_GetPAManagerList", "PAManagerList");
        }

        public static DataTable GetAll_EmpManagerLevel()
        {
            ChangeManagerDAO newsDAO = new ChangeManagerDAO();
            return newsDAO.GetAllManager("spKPI_GetAll_EmpManagerLevel", "EmployeeList");
        }

        public bool CreateNew(tblChangeManager obj)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.CreateNew(obj);
        }
        public int CreateNew_PA(tblChangeManager obj)
        {
            try
            {
                ChangeManagerDAO newDAO = new ChangeManagerDAO();
                newDAO.CreateNew_PA(obj);
                return obj.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool DeleteByID(int ID)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.DeleteByID(ID);
        }

        public bool UpdateByID(tblChangeManager obj)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.UpdateByID(obj);
        }

        public tblChangeManager GetObjectById(int ID)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.GetObjectById("spKPI_GetChangeManager_ById", ID);
        }

        public bool ChangeManager(int ID)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.ChangeManager("spNPOL_ChangeManager_ByID", ID);
        }
        public bool ChangePAManager(int ID)
        {
            ChangeManagerDAO newDAO = new ChangeManagerDAO();
            return newDAO.ChangeManager("spNPOL_ChangePAManager_ByID", ID);
        }
    }
}