using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class K_PerformanceAssessment_Review_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //if (!Session["Role"].ToString().Equals("HR"))
                //{
                //    string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                //    tblEmpManagerNews obj = new tblEmpManagerNews(conn);
                //    if (!obj.IsMakerNews(Session["EmployeeID"].ToString()))
                //        Response.Redirect("Login.aspx");
                //}
            }
            if (!IsPostBack)
            {
                //Hien thi thong tin nhan vien
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                string empid = Session["EmployeeIDReview"].ToString();
                string EmployeeName = kh.getEmployeeName(empid);

                Label1.Text = GetGlobalResourceObject("KPI_TitlePage", "titlePAReview").ToString()
                            + ": " + empid.ToUpper() + " - " + EmployeeName;

                // kiem tra nhom level 3
                int kpiid = int.Parse(Session["PeriodID"].ToString());
                tblEmp_KPIInfo item = Emp_KPIInfoService.GetObjectById(Session["EmployeeID"].ToString(), kpiid);
                liStep_2.Visible = false;
                switch (Emp_KPIInfoService.GetTypeById(kpiid))
                {
                    case 1:
                        break;
                    case 2:
                        if (item != null && item.LevelID == "3")
                        {
                            liStep_2.Visible = false;
                        }
                        break;
                    case 3:
                        Response.Redirect("PAreview_2.aspx");
                        break;
                }
            }
        }
    }
}