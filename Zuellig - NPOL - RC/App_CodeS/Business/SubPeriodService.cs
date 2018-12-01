using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class SubPeriodService
    {
        public static void CreateNews(tblSubPeriod obj)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            newsDAO.CreateNew(obj);
        }

        public static void DeleteByID(int ID)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            newsDAO.DeleteByID(ID);
        }

        public static void UpdateNews(tblSubPeriod obj)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            newsDAO.UpdateNews(obj);
        }
        public DataTable GetListByID(int period, string EmployeeID)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            return newsDAO.GetListByID(period, EmployeeID);
        }

        /*
        public static DataTable GetTableByNewsid(int ID)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            return newsDAO.GetNewsById("spGetAttachByNewsId", "AttachByNewsId", ID);
        }

        public static tblSubPeriod GetAttachmentById(int ID)
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            return newsDAO.GetAttachmentById("spGetAttachmentById", ID);
        }
        public static DataTable GetTable()
        {
            SubPeriodDAO newsDAO = new SubPeriodDAO();
            return newsDAO.GetAttachment("spGetAttachment", "AttachmentList");
        }
         * */
    }
}