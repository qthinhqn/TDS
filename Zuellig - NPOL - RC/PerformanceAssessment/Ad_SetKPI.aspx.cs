﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL
{
    public partial class Ad_SetKPI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null || !Session["Role"].ToString().Equals("PA_Admin"))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //if (!Session["Role"].ToString().Equals("HR"))
                //{
                //    string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString;
                //    tblEmpManagerNews obj = new tblEmpManagerNews(conn);
                //    if (!obj.IsMakerNews(Session["EmployeeID"].ToString()))
                //        Response.Redirect("Login.aspx");
                //}
            }
        }
    }
}