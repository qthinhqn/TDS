using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System.Data;

namespace PAOL.App_Code.Business
{
    public class AttachmentService
    {
        public static void CreateNews(tbl_Attachment obj)
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            newsDAO.CreateNew(obj);
        }

        public static void DeleteAllAttach(tbl_Attachment obj)
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            newsDAO.DeleteAllAttach(obj);
        }
        public static void DeleteAttachByID(int ID)
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            newsDAO.DeleteAttachByID(ID);
        }

        public static DataTable GetTableByNewsid(int ID)
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            return newsDAO.GetNewsById("spGetAttachByNewsId", "AttachByNewsId", ID);
        }

        public static tbl_Attachment GetAttachmentById(int ID)
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            return newsDAO.GetAttachmentById("spGetAttachmentById", ID);
        }
        public static DataTable GetTable()
        {
            AttachmentDAO newsDAO = new AttachmentDAO();
            return newsDAO.GetAttachment("spGetAttachment", "AttachmentList");
        }
    }
}