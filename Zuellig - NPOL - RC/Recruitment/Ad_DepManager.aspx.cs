using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using NPOL.App_Code.Business;
using System.Data;
using conn = System.Web.Configuration;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace NPOL
{
    public partial class Ad_DepManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {

            }

            if (!IsPostBack)
            {
                Session["DepStatus"] = false;
            }
            gvApproval.DataBind();
        }
        
        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridViewExporter1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
            }
            catch (Exception ex)
            { }
        }

        protected void gvApproval_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            object SectionID = e.GetFieldValue("SectionID");
            object LineID = e.GetFieldValue("LineID");
            object DepID = e.GetFieldValue("DepID");

            if (e.GetFieldValue("SectionID") != null)
            {
                if (!SectionID.ToString().Equals(""))
                {
                    if (e.Column.FieldName.Equals("SectionID"))
                    {
                        e.DisplayText = getDepName(SectionID.ToString());
                    }
                }
            }

            if (e.GetFieldValue("LineID") != null)
            {
                if (!LineID.ToString().Equals(""))
                {
                    if (e.Column.FieldName.Equals("LineID"))
                    {
                        e.DisplayText = getDepName(LineID.ToString());
                    }
                }
            }

            if (e.GetFieldValue("DepID") != null)
            {
                if (!DepID.ToString().Equals(""))
                {
                    if (e.Column.FieldName.Equals("DepID"))
                    {
                        e.DisplayText = getDepName(DepID.ToString());
                    }
                }
            }
        }
        public string getDepName(object DepID)
        {
            string value = null;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select DepName from tblRef_Department where DepID = @DepID";
            provider.ParameterCollection = new string[] { "@DepID" };
            provider.ValueCollection = new object[] { DepID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = provider.GetDataTable().Rows[0]["DepName"].ToString();
            }
            provider.CloseConnection();
            return value;
        }

        protected void opt_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optInUse.Checked)
                    Session["DepStatus"] = false;
                else if (optNotUse.Checked)
                    Session["DepStatus"] = true;
                gvApproval.DataBind();
            }
            catch (Exception ex)
            { }
        }
    }
}