using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class FilterByManagerService
    {
        public static void CreateNews(tblPA_FilterByManager obj)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            newsDAO.CreateNew(obj);
        }
        public static void CleanCheck(int period, string manager)
        {
            FilterByManagerDAO newDAO = new FilterByManagerDAO();
            newDAO.CleanCheck(period, manager);
        }

        public bool UpdateByID(tblPA_FilterByManager obj)
        {
            FilterByManagerDAO newDAO = new FilterByManagerDAO();
            return newDAO.UpdateByID(obj);
        }

        public static void DeleteFilter(tblPA_FilterByManager obj)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            newsDAO.DeleteFilter(obj);
        }
        public static void DeleteFilterByID(int ID)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            newsDAO.DeleteFilterByID(ID);
        }

        public static DataTable GetTableByid(int ID)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            return newsDAO.GetNewsById("spGetFilterManagerById", "FilterManagerById", ID);
        }

        public static tblPA_FilterByManager GetFilterManagerById(int ID)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            return newsDAO.GetFilterMangerById("spGetFilterManagerpById", ID);
        }
        public static DataTable GetTable(string manager)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            return newsDAO.GetFilterManger("spGetFilterManager", "AttachmentList", manager);
        }
        public static void InitGroup(int period, string manager)
        {
            FilterByManagerDAO newsDAO = new FilterByManagerDAO();
            newsDAO.InitGroup("spKPI_CreateGroupManager", period, manager);
        }
    }
}