using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_CoNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MultiView1.ActiveViewIndex = 0;
                GridView1.DataSource = NPOL.App_Code.Business.NewsService.GetNewsOfCategory();
                GridView1.DataBind();
            }
            catch { }
            //for (int i = 0; i < DataList1.Items.Count; i++)
            //{
            //    Image img = (Image)DataList1.Items[i].FindControl("Image2");
            //    if (img.ImageUrl == "~/NewsData/Images/NoImages.png")
            //        img.Visible = false;
            //}
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                Image im = (Image)GridView1.Rows[i].FindControl("Image2");
                HyperLink hy = (HyperLink)GridView1.Rows[i].FindControl("HyperLinkanh");
                if (im.ImageUrl == "~/NewsData/Images/NoImages.png")
                {
                    hy.Visible = false;
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ImageClick" || e.CommandName == "TitleClick")
            {
                Session["NewsID"] = e.CommandArgument.ToString();
                Response.Redirect("~/News.aspx");
                //ASPxWebControl.RedirectOnCallback("~/News.aspx?id=" + newsid);
            }
        }


    }
}