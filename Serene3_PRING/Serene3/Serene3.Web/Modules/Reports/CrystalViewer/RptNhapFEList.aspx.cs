using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Serene3.Reports.CrystalViewer
{
    public partial class RptNhapFEList : BasePage//System.Web.UI.Page
    {
        SqlConnection objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);  
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString;
        CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LoadReport();
            }
        }
        
        protected void Preview_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {
            if (this.reportDocument != null)
            {
                this.reportDocument.Close();
                this.reportDocument.Dispose();
            }
            SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString);
            SqlConnection thisConnection = new SqlConnection(thisConnectionString);
            // store procedure
            //SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("spThongKe_NhapXuatTon", thisConnection);
            //mySelectCommand.CommandType = CommandType.StoredProcedure;
            //mySelectCommand.Parameters.Add("@dDate", SqlDbType.DateTime).Value = DateTime.Now;
            SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("Select * From  vNhapKho_SP", thisConnection);
            mySelectCommand.CommandType = CommandType.Text;
            reportDocument = new ReportDocument();
            //Report path
            //string reportPath = Server.MapPath("~/Reports/Crystal/EmployeeListCrystalReport.rpt");
            string reportPath = Server.MapPath("~/Modules/Reports/Report/rptNhapFE.rpt");
            reportDocument.Load(reportPath);
            // Report connection
            ConnectionInfo connInfo = new ConnectionInfo();
            connInfo.ServerName = SConn.DataSource;
            connInfo.DatabaseName = SConn.InitialCatalog;
            connInfo.UserID = SConn.UserID;
            connInfo.Password = SConn.Password;
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = connInfo;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
                table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                try
                {
                    table.Location = "dbo." + table.Location;
                }
                catch { }
            }
           // You can pass parameter in your store procedure if you need
            //reportDocument.SetParameterValue("@FromDate", ProjectUtilities.ConvertToDate(txtFromDate.Text));
            //reportDocument.SetParameterValue("@ToDate", ProjectUtilities.ConvertToDate(txtToDate.Text));

            EmployeeListCrystalReport.ReportSource = reportDocument;
            EmployeeListCrystalReport.DataBind();
        }
    }
}