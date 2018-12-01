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
    public class NewsService : System.Web.UI.Page
    {
        public NewsService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void CreateNews(tbl_News news)
        {
            NewsDAO newsDAO = new NewsDAO();
            newsDAO.CreateNews(news);
        }

        public static void UpdateNews(tbl_News news)
        {
            NewsDAO newsDAO = new NewsDAO();
            newsDAO.UpdateNews(news);
        }

        public static void DeleteNews(tbl_News news)
        {
            NewsDAO newsDAO = new NewsDAO();
            newsDAO.DeleteNews(news);
        }

        public static tbl_News GetNewsByID(int ID)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsByID("spGetNewsById", "@NewsID", ID);
        }
        public static DataTable GetTableNewsByid(int ID)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsById("spGetNewsById", "NewsById", ID);
        }
        public static List<tbl_News> GetNewsOfCategory()
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetListNewsByID("spGetNewsByType", "@TypeID", 1);

        }

        public static List<tbl_News> GetNewsByIDParent(int IDParent)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetListNewsByID("spGetNewsByIDParent", "@IDParent", IDParent);

        }

        public void uploadNewsAttach(FileUpload fu)
        {

            try
            {
                fu.SaveAs(Server.MapPath("~/NewsData/" + fu.PostedFile.FileName + "_1"));
                fu.Dispose();
                File.Delete(Server.MapPath("~/NewsData/" + fu.PostedFile.FileName + "_1"));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }

        internal void uploadNewsImages(System.Web.UI.HtmlControls.HtmlInputFile avatarUpload)
        {
            try
            {
                string imagepath = ConfigurationManager.AppSettings["ImagePath"];
                avatarUpload.PostedFile.SaveAs(Server.MapPath(imagepath + avatarUpload.PostedFile.FileName + "_1"));
                System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imagepath + avatarUpload.PostedFile.FileName + "_1"));
                System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(250, 190, dummyCallBack, IntPtr.Zero);

                thumbNailImg.Save(Server.MapPath(imagepath + avatarUpload.PostedFile.FileName), ImageFormat.Jpeg);

                thumbNailImg.Dispose();
                fullSizeImg.Dispose();
                avatarUpload.Dispose();
                File.Delete(Server.MapPath(imagepath + avatarUpload.PostedFile.FileName + "_1"));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private static bool ThumbnailCallback()
        {
            return false;
        }

        public static DataTable GetCacbaiVietKhac(int NewsID, int Action)
        {
            NewsDAO newsDAO = new NewsDAO();
            return newsDAO.GetNewsToTableByStore("spNewsOthers", "OtherNews", NewsID, Action);
        }
    }
}