using DevExpress.Web;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_EmployeeKPI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //Trường hợp là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Trường hợp là nhân viên mới
                if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Điền dữ liệu chu kỳ đánh giá
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                // Nam hien tai OR KPI cuoi
                int lyear = Emp_KPIInfoService.GetYear(Session["EmployeeID"]);
                Session["YearID"] = lyear;
                ASPxPageControl1.TabPages[0].Text = "KPI " + lyear.ToString();
            }
            catch(Exception ex)
            { }
        }
    }
}