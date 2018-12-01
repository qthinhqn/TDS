using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PAOL.App_Code.Business
{
    public class MenuRoleService : System.Web.UI.Page
    {
        public MenuRoleService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tbl_MenuRole news)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            newsDAO.CreateNews(news);
        }

        public static void UpdateNews(tbl_MenuRole news)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            newsDAO.UpdateNews(news);
        }

        public static void DeleteNews(tbl_MenuRole news)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            newsDAO.DeleteNews(news);
        }

        public static tbl_MenuRole GetInfoByID(string GroupCode)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            return newsDAO.GetInfoByID("spGetMenuRoleById", "@GroupCode", GroupCode);
        }
        public static tbl_MenuRole GetInfoByEmpID(string EmpID)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            return newsDAO.GetInfoByID("spGetMenuRoleByEmpID", "@EmpID", EmpID);
        }
        public static DataTable GetTableByid(string GroupCode)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            return newsDAO.GetTableByid("spGetMenuRoleById", "GroupCode", GroupCode);
        }
        public static List<tbl_MenuRole> GetListByID(string GroupCode)
        {
            MenuRoleDAO newsDAO = new MenuRoleDAO();
            return newsDAO.GetListByID("spGetMenuRoleById", "@GroupCode", GroupCode);

        }
    }
}