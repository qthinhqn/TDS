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
    public partial class RptXuatFEList : BasePage//System.Web.UI.Page
    {
        SqlConnection objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);  
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString;
        CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LoadReport();
                //DropDownList1_SelectedIndexChanged(DropDownList1, null);
                //DropDownList1.SelectedIndex = -1;
            }
        }
        
        protected void Preview_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {
            try
            {
                if (this.reportDocument != null)
                {
                    this.reportDocument.Close();
                    this.reportDocument.Dispose();
                }
                SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString);
                SqlConnection thisConnection = new SqlConnection(thisConnectionString);
                // store procedure
                SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("spThongKe_XuatKho", thisConnection);
                mySelectCommand.CommandType = CommandType.StoredProcedure;
                mySelectCommand.Parameters.Add("@MaKH", SqlDbType.Int).Value = DropDownList1.SelectedValue;
                mySelectCommand.Parameters.Add("@TypeID", SqlDbType.NVarChar).Value = DropDownList2.SelectedValue;
                mySelectCommand.Parameters.Add("@dDate", SqlDbType.DateTime).Value = Calendar1.Value;
                //SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("Select * From  vXuatKho_SP", thisConnection);
                //mySelectCommand.CommandType = CommandType.Text;
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter(mySelectCommand);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(objDataSet);

                reportDocument = new ReportDocument();
                //Report path
                //string reportPath = Server.MapPath("~/Reports/Crystal/EmployeeListCrystalReport.rpt");
                string reportPath = Server.MapPath("~/Modules/Reports/Report/rptXuatFE_2.rpt");
                reportDocument.Load(reportPath);
                reportDocument.SetDataSource(objDataSet.Tables[0]);
                //// You can pass parameter in your store procedure if you need
                reportDocument.SetParameterValue("MaKH", DropDownList1.SelectedValue);
                reportDocument.SetParameterValue("TypeID", DropDownList2.SelectedValue);
                reportDocument.SetParameterValue("dDate", Calendar1.Value);

                EmployeeListCrystalReport.ReportSource = reportDocument;
                EmployeeListCrystalReport.DataBind();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}