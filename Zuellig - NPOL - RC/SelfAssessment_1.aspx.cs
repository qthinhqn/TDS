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
    public partial class K_SelfAssessment_1 : System.Web.UI.Page
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

                if (obj == null)
                {
                    Response.Redirect("SelfAssessmentHistory.aspx");
                }
                else
                {
                    if (DateTime.Now >= obj.StartTime && DateTime.Now < obj.ReviewTime_First)
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

                    // kiem tra nhom level 3
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
                            Response.Redirect("SelfAssessment_2.aspx");
                            break;
                    }
                }
            }
        }
    }
}