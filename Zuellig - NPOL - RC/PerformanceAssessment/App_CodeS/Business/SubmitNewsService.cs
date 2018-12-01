using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PAOL.App_Code.Business
{
    public class SubmitNewsService
    {
        public void CreateNew(tbl_SubmitNews obj)
        {
            SubmitNewsDAO newsDAO = new SubmitNewsDAO();
            newsDAO.CreateNew(obj);
        }

        public void uploadFileSubmit(FileUpload fu, tbl_SubmitNews obj)
        {
            // Create folder newsid if not exist
            // NewsData/Attachment/NewsID
            String submitpath = ConfigurationManager.AppSettings["SubmitPath"];
            submitpath = HttpContext.Current.Server.MapPath(submitpath + obj.NewsID);
            if (!Directory.Exists(submitpath))
            {
                Directory.CreateDirectory(submitpath);
            }

            // Luu file
            try
            {
                string path = submitpath + "/" + obj.SubmitUser + "_" + obj.SubmitFile;
                obj.Path = path;
                fu.SaveAs(path);
                fu.Dispose();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            // Luu thong tin Submit
            this.CreateNew(obj);
        }

        public static tbl_SubmitNews GetSubmitFile(int ID, string user)
        {
            SubmitNewsDAO newsDAO = new SubmitNewsDAO();
            return newsDAO.GetSubmitFile("spGetSubmitFile", ID, user);
        }

        public static DataTable GetTableByNewsid(int ID)
        {
            SubmitNewsDAO newsDAO = new SubmitNewsDAO();
            return newsDAO.GetTableByNewsId("spGetSubmitByNewsId", "SubmitByNewsId", ID);
        }
    }
}