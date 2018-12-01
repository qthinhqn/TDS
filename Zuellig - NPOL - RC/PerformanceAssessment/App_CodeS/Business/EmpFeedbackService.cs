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
    public class EmpFeedbackService : System.Web.UI.Page
    {
        public EmpFeedbackService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tbl_EmpFeedback news)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            newsDAO.CreateNew(news);
        }

        public static void UpdateNews(tbl_EmpFeedback news)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            newsDAO.UpdateByID(news);
        }

        public static void DeleteNews(tbl_EmpFeedback news)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            newsDAO.DeleteByID(news);
        }

        public static List<tbl_EmpFeedback> GetInfoByEmpID(string EmpID)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            return newsDAO.GetInfoByEmpID("spKPI_GetFeedbackByEmp", "@EmployeeID", EmpID);
        }
        public static List<tbl_EmpFeedback> GetInfoByManagerID(string ManagerID)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            return newsDAO.GetInfoByEmpID("spKPI_GetFeedbackByManager", "@ManagerID", ManagerID);
        }
        public static DataTable GetTableByid(string EmpID)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            return newsDAO.GetTableByid("spKPI_GetFeedbackByEmp", "EmployeeFeedback", EmpID);
        }
        public static List<tbl_EmpFeedback> GetListByID(string EmpID)
        {
            EmpFeedbackDAO newsDAO = new EmpFeedbackDAO();
            return newsDAO.GetListByID("spKPI_GetFeedbackByEmp", "@EmpID", EmpID);

        }
        
    }
}