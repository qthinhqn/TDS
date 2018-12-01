using DevExpress.Web;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_makeNews : System.Web.UI.UserControl
    {
        tbl_News news = new tbl_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["NewsID"] != null)
            {
                news = NewsService.GetNewsByID(int.Parse(Session["NewsID"].ToString()));
                if (news != null)
                {
                    HiddenField1.Value = news.Picture;
                    txtTitle.Text = news.Title;
                    txtSummary.Text = news.Summary;
                    heContent.Html = news.Content;
                    chkSubmit.Checked = news.AllowSubmit;
                    if(news.AllowSubmit)
                    {
                        deDeadlineSubmit.Date = news.DeadlineSubmit.Value;
                    }
                    cbStatus.SelectedIndex = (news.IsShow ? 1 : 0);
                    Avatar.ImageUrl = "../" + ConfigurationManager.AppSettings["ImagePath"] + news.Picture;
                }
            }
        }
        protected void chkPrivate_CheckedChanged(object sender, EventArgs e)
        {
            //ASPxGridViewPrivate.Enabled = chkPrivate.Checked;
        }

        protected void lbtEditContent_Click(object sender, EventArgs e)
        {

        }

        const string UploadDirectory = "~/UserControl/Upload/";
        static string fullpath = "";
        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string resultFileName = Path.ChangeExtension(Path.GetRandomFileName(), resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            e.UploadedFile.SaveAs(resultFilePath);


            //UploadingUtils.RemoveFileWithDelay(resultFileName, resultFilePath, 5);

            string name = e.UploadedFile.FileName;
            string url = ResolveClientUrl(resultFileUrl);
            long sizeInKilobytes = e.UploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";
            e.CallbackData = name + "|" + url + "|" + sizeText;
        }

        protected void btnInitial_Click(object sender, EventArgs e)
        {

            if (this.Page.IsValid)
            {
                try
                {
                    news.TypeID = 1;
                    news.Title = txtTitle.Text;
                    news.Summary = txtSummary.Text;
                    news.Content = heContent.Html;
                    // load Picture
                    if (avatarUpload.PostedFile.FileName != "")
                    {
                        news.Picture = avatarUpload.PostedFile.FileName;
                        NewsService n = new NewsService();
                        n.uploadNewsImages(avatarUpload);
                    }
                    else
                    {
                        if (Session["NewsID"] == null)
                            news.Picture = "NoImages.jpg";
                        else
                            news.Picture = HiddenField1.Value;
                    }
                    news.UserID = Session["EmployeeID"].ToString();
                    news.CreationTime = DateTime.Now;

                    if (chkSubmit.Checked)
                    {
                        news.AllowSubmit = true;
                        news.DeadlineSubmit = deDeadlineSubmit.Date;
                    }
                    else
                    {
                        news.AllowSubmit = false;
                        news.DeadlineSubmit = null;
                    }
                    news.IsShow = (cbStatus.SelectedIndex == 1);
                    // load attachment
                    //if (fuAttachment.PostedFile.FileName != "")
                    //{
                    //    news.IsAttach = true;
                    //    NewsService n = new NewsService();
                    //    n.uploadNewsAttach(fuAttachment);
                    //}
                    //else
                    //{
                    //    news.IsAttach = false;
                    //}
                    news.StatusID = 'P';

                    if (Session["NewsID"] != null)
                    {
                        // Update data
                        news.NewsID = int.Parse(Session["NewsID"].ToString());
                        NewsService.UpdateNews(news);
                    }
                    else
                    {
                        // insert data
                        NewsService.CreateNews(news);
                    }
                    if (news.NewsID == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Lưu Bài viết bị lỗi !')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Bài viết của bạn đã được lưu lại !')", true);
                        Clearform();
                        Session["NewsID"] = null;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clearform();
        }

        private void Clearform()
        {
            txtTitle.Text = "";
            txtSummary.Text = "";
            heContent.Html = "";
            cbStatus.SelectedIndex = 0;
            chkSubmit.Checked = false;
            HiddenField1.Value = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if(fuPicture.HasFile)
            //{
            //    imgCurrentAvatar.ImageUrl = Path.GetFullPath(fuPicture.PostedFile.FileName);
            //}
        }

        //protected void btnUpload_Click(object sender, EventArgs e)
        //{
        //    // Upload file attach
        //    // load attachment
        //    if (fuAttachment.PostedFile.FileName != "")
        //    {
        //        NewsService n = new NewsService();
        //        n.uploadNewsAttach(fuAttachment);
        //        news.IsAttach = true;
                
        //    }
        //}

    }
}