using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_News : System.Web.UI.UserControl
    {
        tbl_News news = new tbl_News();
        protected void Page_Load(object sender, EventArgs e)
        {
            int newsid = 0;
            if (Session["NewsID"] != null)
            {
                newsid = int.Parse(Session["NewsID"].ToString());
                news = NewsService.GetNewsByID(newsid);
            }
            #region Load noi dung
            //if (!IsPostBack && Request.QueryString["ID"] != null)
            if (!IsPostBack && newsid != 0)
            {
                if (news != null)
                {
                    //Response.Write(news.Title.ToString());

                    DataList2.DataSource = NewsService.GetTableNewsByid(newsid);
                    DataList2.DataBind();

                    if (news.AllowSubmit) PanelGuiPH.Visible = true;
                }
            }
            #endregion
            #region Load list Attachment
            if (!IsPostBack && newsid != 0)
            {
                news = NewsService.GetNewsByID(newsid);
                if (news != null)
                {
                    //Response.Write(news.Title.ToString());

                    DataList2.DataSource = NewsService.GetTableNewsByid(newsid);
                    DataList2.DataBind();

                    if (news.AllowSubmit) PanelGuiPH.Visible = true;
                }
            }
            #endregion
            #region lấy các tin mới hơn và cũ hơn
            if (newsid != 0)
            {
                DataTable dt = new DataTable();
                dt = NewsService.GetCacbaiVietKhac(newsid, 0);
                if (dt != null && dt.Rows.Count > 0)
                {
                    GridViewBaivietmoi.Visible = true;
                    GridViewBaivietmoi.DataSource = dt;
                    GridViewBaivietmoi.DataBind();
                    dt.Clear();
                }

                {
                    DataTable dtt = new DataTable();
                    dtt = NewsService.GetCacbaiVietKhac(newsid, 1);
                    if (dtt != null && dtt.Rows.Count > 0)
                    {
                        GridviewBaiVietcu.Visible = true;
                        GridviewBaiVietcu.DataSource = dtt;
                        GridviewBaiVietcu.DataBind();
                        dtt.Clear();
                    }
                }
            }

            #endregion
            #region Phần Feedback(phản hồi)
            LoadFeedBack();
            #endregion
            
        }
        protected void LoadFeedBack()
        {
            if (Session["NewsID"] != null)
            {
                int newsid = int.Parse(Session["NewsID"].ToString());
                string user = Session["EmployeeID"].ToString();
                tbl_SubmitNews obj = SubmitNewsService.GetSubmitFile(newsid, user);
                if(obj != null)
                {
                    LinkButton1.Text = obj.SubmitFile;
                }
                // check last submit date
                if (news.DeadlineSubmit != null)
                    if (DateTime.Compare(DateTime.Now, news.DeadlineSubmit.Value) > 0)
                    {
                        lbSubmit.Visible = true;
                        btnSubmit.Visible = false;
                    }
                    else
                    {
                        lbSubmit.Visible = false;
                        btnSubmit.Visible = true;
                    }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // check last submit date
                if (DateTime.Compare(DateTime.Now, news.DeadlineSubmit.Value) > 0)
                {
                    string message = "";
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            message = "alert('Đã hết hạn phản hồi cho bản tin này.')";
                        }
                        else
                        {
                            message = "alert('Expired feedback to this news!')";
                        }
                    }
                    else
                    {
                        message = "alert('Đã hết hạn phản hồi cho bản tin này.')";
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    return;
                }

                //Label lbid = (Label)DataList1.Items[0].FindControl("LabelID");
                if (FileUpload.PostedFile.FileName != "")
                {
                    if (txtCaptcha.Text.Equals(Session["captcha"].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        // Load file & Luu thong tin Submit
                        tbl_SubmitNews obj = new tbl_SubmitNews();
                        obj.NewsID = int.Parse(Session["NewsID"].ToString());
                        obj.SubmitFile = FileUpload.PostedFile.FileName;
                        obj.SubmitUser = Session["EmployeeID"].ToString();

                        SubmitNewsService sv = new SubmitNewsService();
                        sv.uploadFileSubmit(FileUpload, obj);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Phản hồi của bạn đã được đăng !')", true);

                        LoadFeedBack();

                    }

                    else ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bạn đã xác nhận không đúng, Xin vui lòng xác nhận lại !')", true);
                }
                else ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Vui lòng chọn file để gởi !')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Lỗi !" + ex.Message + "')", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int newsid = int.Parse(Session["NewsID"].ToString());
                string user = Session["EmployeeID"].ToString();
                tbl_SubmitNews obj = SubmitNewsService.GetSubmitFile(newsid, user);
                if (obj != null)
                {
                    Utility.Download_A_File(obj.Path, obj.SubmitFile);
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "linkClick")
            {
                Session["NewsID"] = e.CommandArgument.ToString();
                Response.Redirect("~/News.aspx");
                //ASPxWebControl.RedirectOnCallback("~/News.aspx?id=" + newsid);
            }
        }

        protected void GridViewAttach_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "linkClick")
            {
                try
                {
                    int id = int.Parse(e.CommandArgument.ToString());
                    tbl_Attachment obj = AttachmentService.GetAttachmentById(id);
                    if (obj != null)
                    {
                        Utility.Download_A_File(obj.AttachmentPath, obj.AttachmentName);
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}