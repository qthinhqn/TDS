using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class FilterByDepService
    {
        public static void CreateNews(tblPA_FilterByDep obj)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            newsDAO.CreateNew(obj);
        }

        public static void CleanCheck(int period, string manager)
        {
            FilterByDepDAO newDAO = new FilterByDepDAO();
            newDAO.CleanCheck(period, manager);
        }

        public bool UpdateByID(tblPA_FilterByDep obj)
        {
            FilterByDepDAO newDAO = new FilterByDepDAO();
            return newDAO.UpdateByID(obj);
        }

        public static void DeleteFilter(tblPA_FilterByDep obj)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            newsDAO.DeleteFilterDep(obj);
        }
        public static void DeleteFilterByID(int ID)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            newsDAO.DeleteFilterDepByID(ID);
        }

        public static DataTable GetTableByid(int ID)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            return newsDAO.GetNewsById("spGetFilterDepById", "FilterDepById", ID);
        }

        public static tblPA_FilterByDep GetFilterDepById(int ID)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            return newsDAO.GetFilterDepById("spGetFilterDepById", ID);
        }
        public static DataTable GetTable(string manager)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            return newsDAO.GetFilterDep("spGetFilterDep", "AttachmentList", manager);
        }
        public static void InitGroup(int period, string manager)
        {
            FilterByDepDAO newsDAO = new FilterByDepDAO();
            newsDAO.InitGroup("spKPI_CreateGroupDep", period, manager);
        }
    }
}