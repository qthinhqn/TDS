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
    public class Recruit_EmpGroupService : System.Web.UI.Page
    {
        public Recruit_EmpGroupService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tblRecruit_EmpGroup news)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            newsDAO.CreateNews(news);
        }

        public static void UpdateNews(tblRecruit_EmpGroup news)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            newsDAO.UpdateNews(news);
        }

        public static void DeleteNews(tblRecruit_EmpGroup news)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            newsDAO.DeleteNews(news);
        }

        public static tblRecruit_EmpGroup GetInfoByEmpID(string EmpID)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            return newsDAO.GetInfoByID("spGetEmpGroupById", "@EmpID", EmpID);
        }
        public static DataTable GetTableByid(string RepresentativeID)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            return newsDAO.GetTableByid("spRecruit_GetEmpGroupList", "EmployeeGroup", RepresentativeID);
        }
        public static List<tblRecruit_EmpGroup> GetListByID(string RepresentativeID)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            return newsDAO.GetListByID("spRecruit_GetEmpGroupList", "@RepresentativeID", RepresentativeID);

        }

        public static List<string> GetEmployeeNameByID(string RepresentativeID, string search)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            return newsDAO.GetEmployeeNameByID("spRecruit_SearchEmpGroup", "@RepresentativeID", RepresentativeID, search);

        }
        public bool IsRepresentative(string EmpID)
        {
            Recruit_EmpGroupDAO newsDAO = new Recruit_EmpGroupDAO();
            return newsDAO.IsRepresentative(EmpID);
        }
    }
}