using DevExpress.Web;
using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_ListNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAction(Request.QueryString["action"]);
            }
        }

        protected void LoadAction(string action)
        {

            //if (action == "bvcd")
            //{
            //    DataTable dt = new DataTable();
            //    dt = NewsService.GetNewsApproving();
            //    if (dt.Rows.Count > 0)
            //        Labelnhan.Text = "CÁC BÀI VIẾT CHỜ ĐĂNG";
            //    if (dt.Rows.Count == 0)
            //        Labelnhan.Text = "HIỆN TẠI KHÔNG CÓ BÀI VIẾT CHỜ ĐĂNG";
            //    GridView5.Visible = true;
            //    GridView5.DataSource = dt;
            //    GridView5.DataBind();
            //    GridView1.Visible = false;
            //    GridView2.Visible = false;
            //    GridView3.Visible = false;
            //}
        }

        protected string GetImageName(object dataValue)
        {
            string val = string.Empty;
            try
            {
                return "~/NewsData/Images/" + (string)dataValue;
            }
            catch {
                return "";
            }
        }
        
        protected void ASPxGridView1_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            Session["NewsID"] = ASPxGridView1.GetRowValues(e.VisibleIndex, "NewsID").ToString();
            string title = ASPxGridView1.GetRowValues(e.VisibleIndex, "Title").ToString();
            int newsid = int.Parse(Session["NewsID"].ToString());
            switch (e.ButtonID)
            {
                // edit news
                case "Edit":
                    ASPxWebControl.RedirectOnCallback("~/N_MakeNews.aspx");
                    break;
                case "Attach":
                    
                    break;
                case "Delete":
                    DeleteNews(newsid, title);
                    ASPxGridView1.DataBind();
                    break;
                case "Preview":
                    ASPxWebControl.RedirectOnCallback("~/News.aspx");
                    break;
                default:
                    break;
            }

        }

        private void DeleteNews(int newsid, string title)
        {
            try
            {

                tbl_News n = new tbl_News();
                n.NewsID = newsid;
                NewsService.DeleteNews(n);
            }
            catch (Exception ex)
            {

            }
        }

        protected void cpPopup_Callback(object sender, CallbackEventArgsBase e)
        {
            try
            {
                int index = int.Parse(e.Parameter);
                Session["NewsID"] = ASPxGridView1.GetRowValues(index, "NewsID").ToString();
                string title = ASPxGridView1.GetRowValues(index, "Title").ToString();
                int newsid = int.Parse(Session["NewsID"].ToString());
                ASPxPopupControl1.HeaderText = newsid.ToString() + ": " + title;
                //ASPxGridView1.JSProperties["cpSuc"] = true;
                uc_UploadFileAttach.ReloadControl();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            if (e.Column.Name == "Title")
                if (e.CellType == GridViewTableCommandCellType.Data)
                {
                    ASPxGridView grid = sender as ASPxGridView;
                    //e.Text = grid.GetRowValues(e.VisibleIndex, "Title").ToString();
                }
        }


    }
}