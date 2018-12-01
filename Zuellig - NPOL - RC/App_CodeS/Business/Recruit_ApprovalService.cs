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
    public class Recruit_ApprovalService : System.Web.UI.Page
    {
        public Recruit_ApprovalService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tblOT_Approval news)
        {
            OT_ApprovalDAO newsDAO = new OT_ApprovalDAO();
            newsDAO.CreateNews(news);
        }

        public static void UpdateNews(tblOT_Approval news)
        {
            OT_ApprovalDAO newsDAO = new OT_ApprovalDAO();
            newsDAO.UpdateNews(news);
        }

        public static void DeleteNews(tblOT_Approval news)
        {
            OT_ApprovalDAO newsDAO = new OT_ApprovalDAO();
            newsDAO.DeleteNews(news);
        }

        public static tblOT_Approval GetInfoByID(int ID)
        {
            OT_ApprovalDAO newsDAO = new OT_ApprovalDAO();
            return newsDAO.GetInfoByID("spGetApprovalById", "@ID", ID);
        }
        public static DataTable GetTableByid(string regID)
        {
            Recruit_ApprovalDAO newsDAO = new Recruit_ApprovalDAO();
            return newsDAO.GetTableByid("spRecruit_GetApprovalList_New", "ApprovalList", regID);
        }
        public static List<tblOT_Approval> GetListByID(int RegID)
        {
            OT_ApprovalDAO newsDAO = new OT_ApprovalDAO();
            return newsDAO.GetListByID("spOT_GetApprovalList", "@RerID", RegID);

        }

        public DataTable GetTable_rptEmpRequisition(string Procedure_Name, string requestID)
        {
            Recruit_ApprovalDAO newsDAO = new Recruit_ApprovalDAO();
            return newsDAO.GetTable_rptEmpRequisition(Procedure_Name, "rptEmpRequisition", requestID);
        }

        internal string getReportType(string requestID)
        {
            Recruit_ApprovalDAO newsDAO = new Recruit_ApprovalDAO();
            return newsDAO.getReportType(requestID);
        }
    }
}