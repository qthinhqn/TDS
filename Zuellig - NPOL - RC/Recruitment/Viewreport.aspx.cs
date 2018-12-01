using System;
using System.Web.UI.WebControls;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace NPOL
{
    public partial class Viewreport_Recruit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                Session["ReportType"] = null;
                // Kiem tra user co quyen xem report

            }

            gridExport.DataBind();
            gridExport_TTDC.DataBind();
            gridExport_TTDC.GridView.Visible = false;
        }


        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
        }


        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            // bao cao tong hop theo yeu cau tuyen dung EmpID_Apply
            Session["ReportType"] = true;
            dsReport_Selecting(null, null);
            gridExport.DataBind();
            gridExport.GridView.Visible = true;
            gridExport_TTDC.GridView.Visible = false;
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            // bao cao tong hop theo loai thang tien - dieu chinh
            Session["ReportType"] = false;
            dsReport_Selecting(null, null);
            gridExport_TTDC.DataBind();
            gridExport.GridView.Visible = false;
            gridExport_TTDC.GridView.Visible = true;
        }

        #region Export tool
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            if (gridExport.GridView.Visible)
                gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
            else
                gridExport_TTDC.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            if (gridExport.GridView.Visible)
                gridExport.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
            else
                gridExport_TTDC.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        #endregion

        protected void dsReport_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            if (ddlTuNgay.Value != null)
            {
                dsReport.SelectParameters["FromDate"].DefaultValue = ddlTuNgay.Date.ToShortDateString();
            }
            else
            {
                dsReport.SelectParameters["FromDate"].DefaultValue = null;
            }

            if (ddlDenNgay.Value != null)
            {
                dsReport.SelectParameters["ToDate"].DefaultValue = ddlDenNgay.Date.ToShortDateString();
            }
            else
            {
                dsReport.SelectParameters["ToDate"].DefaultValue = null;
            }
        }

        protected void gvReport_TTDC_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                if (e.Column.Name != "ProAdj_Type")
                    return;

                String proAdj_Type = e.GetFieldValue("ProAdj_Type").ToString();
                if (proAdj_Type != "" && proAdj_Type.Length == 7)
                {
                    String txt = "";
                    if (proAdj_Type[0] == '1')
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_1").ToString();
                    if (proAdj_Type[1] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_2").ToString();
                    }
                    if (proAdj_Type[2] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_3").ToString();
                    }
                    if (proAdj_Type[3] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_4").ToString();
                    }
                    if (proAdj_Type[4] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_5").ToString();
                    }
                    if (proAdj_Type[5] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_6").ToString();
                    }
                    if (proAdj_Type[6] == '1')
                    {
                        if (txt != "")
                            txt = txt + System.Environment.NewLine;
                        txt = GetGlobalResourceObject("RC_Registration2", "chk1_7").ToString();
                    }

                    e.DisplayText = txt;
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
    }
}