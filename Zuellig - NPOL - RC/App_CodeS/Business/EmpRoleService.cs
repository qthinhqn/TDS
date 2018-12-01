using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NPOL.App_Code.Business
{
    public class EmpRoleService : System.Web.UI.Page
    {
        public EmpRoleService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tbl_EmpRole news)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            newsDAO.CreateNews(news);
        }

        public static void UpdateNews(tbl_EmpRole news)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            newsDAO.UpdateNews(news);
        }

        public static void DeleteNews(tbl_EmpRole news)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            newsDAO.DeleteNews(news);
        }

        public static tbl_EmpRole GetInfoByID(string EmpID)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            return newsDAO.GetInfoByID("spGetEmpRoleById", "@EmpID", EmpID);
        }
        public static DataTable GetTableByid(string EmpID)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            return newsDAO.GetTableByid("spGetEmpRoleById", "EmployeeRole", EmpID);
        }
        public static List<tbl_EmpRole> GetListByID(string EmpID)
        {
            EmpRoleDAO newsDAO = new EmpRoleDAO();
            return newsDAO.GetListByID("spGetListEmpRoleById", "@EmpID", EmpID);

        }
        
    }
}