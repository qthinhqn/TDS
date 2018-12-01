using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL
{
    public partial class K_SelfAssessment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period obj = (new KPI_PeriodService()).GetObjectById(kpiid);

                if (DateTime.Now >= obj.StartTime && DateTime.Now < obj.ReviewTime)
                {
                    // hien thong bao
                    divInfo_1.Attributes["class"] = "msg info";
                    divInfo_2.Attributes["class"] = "msg hidden";
                }
                else
                {
                    // hien thong bao
                    divInfo_1.Attributes["class"] = "msg hidden";
                    divInfo_2.Attributes["class"] = "msg warning";
                }
            }
        }
    }
}