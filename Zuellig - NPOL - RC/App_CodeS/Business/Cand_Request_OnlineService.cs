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
    public class Cand_Request_OnlineService : System.Web.UI.Page
    {
        public Cand_Request_OnlineService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tblCand_Request_Online news)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            newsDAO.CreateNews(news);
        }
        public static void CreateNews_Tmp(tblCand_Request_Online news)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            newsDAO.CreateNews_Tmp(news);
        }

        public static void UpdateNews(tblCand_Request_Online news)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            newsDAO.UpdateNews(news);
        }
        public static void UpdateNews_2(tblCand_Request_Online news, object empID, object levelNo, int UpdateType)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            newsDAO.UpdateNews_2(news, empID, levelNo, UpdateType);
        }

        public static void DeleteNews(tblCand_Request_Online news)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            newsDAO.DeleteNews(news);
        }

        public static tblCand_Request_Online GetInfoByEmpID(string EmpID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetInfoByID("spGetEmpGroupById", "@EmpID", EmpID);
        }
        public static tblCand_Request_Online GetInfoByRequestID(string requestID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            string strSQL = "Select * From tblCand_Request_Online where RequestID = @RequestID";
            return newsDAO.GetInfoByRequestID(strSQL, requestID);
        }
        public static tblCand_Request_Online GetInfoByRequestID_Tmp(string requestID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            string strSQL = "Select * From tblCand_Request_Online_Tmp where RequestID = @RequestID";
            return newsDAO.GetInfoByRequestID(strSQL, requestID);
        }
        public static DataTable GetTableByid(string RepresentativeID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetTableByid("spRecruit_GetEmpGroupList", "EmployeeGroup", RepresentativeID);
        }
        public static DataTable GetEmpInfoByid(string EmpID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetEmpInfoByid("spGetEmpInfoByid", "EmployeeInfo", EmpID);
        }
        public static List<tblCand_Request_Online> GetListByID(string RepresentativeID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetListByID("spRecruit_GetEmpGroupList", "@RepresentativeID", RepresentativeID);

        }

        public static List<string> GetEmployeeNameByID(string RepresentativeID, string search)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetEmployeeNameByID("spRecruit_SearchEmpGroup", "@RepresentativeID", RepresentativeID, search);

        }
        public bool IsRepresentative(string EmpID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.IsRepresentative(EmpID);
        }
        public static DataTable GetRecruit_StatusByRequestID(string requestID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.GetEmpInfoByid("spGetRecruit_StatusByRequestID", "vRecruit_StatusInfo", requestID);
        }

        public bool IsLineManager(string EmpID, string managerID)
        {
            Cand_Request_OnlineDAO newsDAO = new Cand_Request_OnlineDAO();
            return newsDAO.IsLineManager(EmpID, managerID);
        }
    }
}