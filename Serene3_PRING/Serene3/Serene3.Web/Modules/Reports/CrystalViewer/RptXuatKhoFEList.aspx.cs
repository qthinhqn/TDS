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
    public partial class RptXuatKhoFEList : System.Web.UI.Page
    {
        SqlConnection objSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString);
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString;
        CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //thisConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString;
            if (!Page.IsPostBack)
            {
                //string script = "$(document).ready(function () { $('[id*=Preview]').click(); });";
                //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

                BindCustomer();
                DropDownList1_SelectedIndexChanged(DropDownList1, null);
                DropDownList1.SelectedIndex = -1;
            }
            LoadReport();
        }
        protected void BindCustomer()
        {
            try
            {
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter("SELECT [KeyID],[MaKH],[TenKH] FROM [dbo].[tblKhachHang]", objSqlConnection);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(objDataSet);
                DropDownList1.DataSource = objDataSet;
                DropDownList1.DataTextField = "TenKH";
                DropDownList1.DataValueField = "KeyID";
                DropDownList1.DataBind();

                DropDownList1.Items.Insert(0, new ListItem("--Select Customer--", "0"));
            }
            catch (Exception ex)
            {
                Response.Write("Exception in Binding Customer Dropdownlist : " + ex.Message.ToString());
            }
            finally
            {
                // objSqlConnection.Close();
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
                SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("spThongKe_XuatKho_2", thisConnection);
                mySelectCommand.CommandType = CommandType.StoredProcedure;
                mySelectCommand.Parameters.Add("@MaHD", SqlDbType.Int).Value = DropDownList2.SelectedValue;
                mySelectCommand.Parameters.Add("@MaBTP", SqlDbType.Int).Value = DropDownList3.SelectedValue;
                //SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("Select * From  vNhapKho_SP", thisConnection);
                //mySelectCommand.CommandType = CommandType.Text;
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter(mySelectCommand);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(objDataSet);

                reportDocument = new ReportDocument();
                //Report path
                string reportPath = Server.MapPath("~/Modules/Reports/Report/rptCrossTable_XuatKho.rpt");
                reportDocument.Load(reportPath);
                reportDocument.SetDataSource(objDataSet.Tables[0]);

                EmployeeListCrystalReport.ReportSource = reportDocument;
                EmployeeListCrystalReport.DataBind();
            }
            catch (Exception ex)
            { }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection thisConnection = new SqlConnection(thisConnectionString);
                string sql = "SELECT distinct A.KeyID, A.SoHD, A.NoiDung FROM [dbo].[tblHopDong] A WHERE A.[MaKH] = @MaKH Order BY A.SoHD ;";
                SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand(sql, thisConnection);
                mySelectCommand.CommandType = CommandType.Text;
                if (DropDownList1.SelectedValue != null)
                    mySelectCommand.Parameters.Add("@MaKH", SqlDbType.Int).Value = DropDownList1.SelectedValue;
                else
                    mySelectCommand.Parameters.Add("@MaKH", SqlDbType.Int).Value = DBNull.Value;
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter(mySelectCommand);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(ds);
                DropDownList2.DataSource = ds;
                DropDownList2.DataValueField = "KeyID";
                DropDownList2.DataTextField = "SoHD";
                DropDownList2.DataBind();
                //This updates the panel Asynchronously
                //UpdatePanel1.Update();
                DropDownList2_SelectedIndexChanged(DropDownList2, null);
            }
            catch (Exception ex)
            {

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection thisConnection = new SqlConnection(thisConnectionString);
                string sql = "SELECT distinct A.KeyID, A.MotaBTP FROM [dbo].[tblBanThanhPham] A INNER JOIN [dbo].[tblHopDong_ChiTiet] B ON A.KeyID = B.MaBTP WHERE B.[MaHD] = @KeyID;";
                SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand(sql, thisConnection);
                mySelectCommand.CommandType = CommandType.Text;
                if (DropDownList2.SelectedValue != null)
                    mySelectCommand.Parameters.Add("@KeyID", SqlDbType.Int).Value = DropDownList2.SelectedValue;
                else
                    mySelectCommand.Parameters.Add("@KeyID", SqlDbType.Int).Value = DBNull.Value;
                SqlDataAdapter objSQLAdapter = new SqlDataAdapter(mySelectCommand);
                DataSet objDataSet = new DataSet();
                objSQLAdapter.Fill(ds);
                DropDownList3.DataSource = ds;
                DropDownList3.DataValueField = "KeyID";
                DropDownList3.DataTextField = "MotaBTP";
                DropDownList3.DataBind();
                //This updates the panel Asynchronously
                //UpdatePanel1.Update();
            }
            catch (Exception ex)
            {

            }
        }
    }
}