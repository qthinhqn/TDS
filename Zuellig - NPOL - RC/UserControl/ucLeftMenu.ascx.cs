using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class ucLeftMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ASPxNavBar1_ItemClick(object source, NavBarItemEventArgs e)
        {
            switch (e.Item.Index)
            {
                case 0:
                    Response.Redirect("~/N_ListNews.aspx");
                    break;
                case 1:
                    Session["NewsID"] = null;
                    Response.Redirect("~/N_MakeNews.aspx");
                    break;
                case 2:
                    Response.Redirect("~/N_ListAttachment.aspx");
                    break;
                case 3:
                    Response.Redirect("~/N_ListSubmit.aspx");
                    break;
                default:
                    break;
            }
        }
    }
}