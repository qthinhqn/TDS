using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class FilterByLocationService
    {
        public static void CreateNews(tblPA_FilterByLocation obj)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            newsDAO.CreateNew(obj);
        }

        public static void CleanCheck(int period, string manager)
        {
            FilterByLocationDAO newDAO = new FilterByLocationDAO();
            newDAO.CleanCheck(period, manager);
        }

        public bool UpdateByID(tblPA_FilterByLocation obj)
        {
            FilterByLocationDAO newDAO = new FilterByLocationDAO();
            return newDAO.UpdateByID(obj);
        }

        public static void DeleteFilter(tblPA_FilterByLocation obj)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            newsDAO.DeleteFilterDep(obj);
        }
        public static void DeleteFilterByID(int ID)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            newsDAO.DeleteFilterDepByID(ID);
        }

        public static DataTable GetTableByid(int ID)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            return newsDAO.GetNewsById("spGetFilterLocationById", "FilterLocationById", ID);
        }

        public static tblPA_FilterByLocation GetFilterDepById(int ID)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            return newsDAO.GetFilterDepById("spGetFilterLocationpById", ID);
        }
        public static DataTable GetTable(string manager)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            return newsDAO.GetFilterDep("spGetFilterLocation", "LocationList", manager);
        }
        public static void InitGroup(int period, string manager)
        {
            FilterByLocationDAO newsDAO = new FilterByLocationDAO();
            newsDAO.InitGroup("spKPI_CreateGroupLocation", period, manager);
        }
    }
}