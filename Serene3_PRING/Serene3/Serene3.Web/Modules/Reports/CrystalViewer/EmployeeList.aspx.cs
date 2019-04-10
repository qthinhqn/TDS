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

namespace HRM_TDS.Reports.CrystalViewer
{
    public partial class EmployeeList : System.Web.UI.Page
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
            //if (objSqlConnection.State == ConnectionState.Closed)
            //{
            //    objSqlConnection.Open();
            //}
            //if (!IsPostBack)
            //{
            //    ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            //    //ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            //    BindCountries();
            //}
        }

        protected void BindCountries()
        {
            try
            {

                //using (SqlConnection sqlConnection = new SqlConnection(thisConnectionString))
                //{
                //    string queryString = "select * from tblCountry";

                //    SqlDataAdapter sqlDataAapter = new SqlDataAdapter(queryString, sqlConnection);
                //    DataSet objDataSet = new DataSet();
                //    sqlDataAapter.Fill(objDataSet);
                //    ddlCountry.DataSource = objDataSet;
                //    ddlCountry.DataTextField = "CountryName";
                //    ddlCountry.DataValueField = "CountryId";
                //    ddlCountry.DataBind();
                //    ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
                //}

                SqlDataAdapter objSQLAdapter = new SqlDataAdapter("select * from tblCountry", objSqlConnection);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(objDataSet);
                ddlCountry.DataSource = objDataSet;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Exception in Binding Country Dropdownlist : " + ex.Message.ToString());
            }
            finally
            {
                // objSqlConnection.Close();
            }
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter("select * from tblState where CountryId=" + CountryId, objSqlConnection);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(objDataSet);
                ddlState.DataSource = objDataSet;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
                if (ddlState.SelectedValue == "0")
                {
                    ddlCity.Items.Clear();
                    ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
                }
            }
            catch (Exception ex)
            {
                Response.Write("Exception in Binding State Dropdownlist: " + ex.Message.ToString());
            }
            finally
            {
                objSqlConnection.Close();
            }
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    int StateId = Convert.ToInt32(ddlState.SelectedValue);
            //    SqlDataAdapter objSQLAdapter = new SqlDataAdapter("select * from tblCity where StateId=" + StateId, objSqlConnection);
            //    DataSet objDataSet = new DataSet();
            //    objSQLAdapter.Fill(objDataSet);
            //    ddlCity.DataSource = objDataSet;
            //    ddlCity.DataTextField = "CityName";
            //    ddlCity.DataValueField = "CityId";
            //    ddlCity.DataBind();
            //    ddlCity.Items.Insert(0, new ListItem("--Select City--", "0"));
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("Exception in Binding City Dropdownlist: " + ex.Message.ToString());
            //}
            //finally
            //{
            //    objSqlConnection.Close();
            //}
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        { 
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
            //SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("PIS_GetAllEmployeeInfo", thisConnection);
            //mySelectCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("Select * From  Orders", thisConnection);
            mySelectCommand.CommandType = CommandType.Text;
            reportDocument = new ReportDocument();
            //Report path
            //string reportPath = Server.MapPath("~/Reports/Crystal/EmployeeListCrystalReport.rpt");
            string reportPath = Server.MapPath("~/Modules/Hrm_tds/Report/Report1.rpt");
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