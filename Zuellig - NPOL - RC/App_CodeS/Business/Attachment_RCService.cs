using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class Attachment_RCService
    {
        public static void CreateNews(tbl_Attachment_RC obj)
        {
            Attachment_RCDAO newsDAO = new Attachment_RCDAO();
            newsDAO.CreateNew(obj);
        }

        public static void DeleteAllAttach(tbl_Attachment_RC obj)
        {
            Attachment_RCDAO newsDAO = new Attachment_RCDAO();
            newsDAO.DeleteAllAttach(obj);
        }
        //public static void DeleteAttachByID(int ID)
        //{
        //    Attachment_RCDAO newsDAO = new Attachment_RCDAO();
        //    newsDAO.DeleteAttachByID(ID);
        //}

        public static DataTable GetTableByNewsid(string ID)
        {
            Attachment_RCDAO newsDAO = new Attachment_RCDAO();
            return newsDAO.GetNewsById("spGetAttach_RCByRequestId", "AttachByRequestId", ID);
        }

        public static tbl_Attachment_RC GetAttachmentById(int ID)
        {
            Attachment_RCDAO newsDAO = new Attachment_RCDAO();
            return newsDAO.GetAttachmentById("spGetAttachment_RCById", ID);
        }
    }
}