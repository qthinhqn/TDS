using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class Guideline : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                tbl_MenuRole menuRole = MenuRoleService.GetInfoByEmpID(Session["EmployeeID"].ToString());
                if (IsForeigner(Session["EmployeeID"].ToString()))
                {
                    ASPxRichEdit1.Open(Server.MapPath(@"~/App_Data/HDSD_PATool_ONLINE_E.docx"));
                }
                else if (menuRole.KPI4Manager == true)
                {
                    //ASPxRichEdit1.Open(Server.MapPath("~/App_Data/HDSD_KPI_ONLINE.docx"));
                    ASPxRichEdit1.Open(Server.MapPath(@"~/App_Data/HDSD_PATool_ONLINE.docx"));
                }
                else if (menuRole.KPI4Employee == true)
                {
                    ASPxRichEdit1.Open(Server.MapPath(@"~/App_Data/HDSD_PATool_ONLINE_E.docx"));
                }
            }
        }
        private bool IsForeigner(object EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select isForeigner from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                object isForeigner = dt.Rows[0]["isForeigner"];
                if (!isForeigner.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(isForeigner) == true)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
            }
            else
            {
                value = false;
            }

            return value;
        }
    }
}