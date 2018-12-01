using DevExpress.Export;
using DevExpress.XtraPrinting;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_ReviewFeedback : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            try
            {
                if (Session["Role"] == "PA_Admin")
                {
                    Session["ManagerID"] = "";
                    //GridView1.DataSource = NPOL.App_Code.Business.EmpFeedbackService.GetInfoByEmpID("%");
                    //GridView1.DataBind();
                }
                else
                {
                    Session["ManagerID"] = Session["EmployeeID"];
                    //string empID = Session["EmployeeID"].ToString();
                    //GridView1.DataSource = NPOL.App_Code.Business.EmpFeedbackService.GetInfoByManagerID(empID);
                    //GridView1.DataBind();
                }
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        #region Export tool
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        #endregion
    }
}