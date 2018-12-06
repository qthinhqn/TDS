using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOL.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace NPOL
{
    public partial class F_ViewIncomeTax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //Trường hợp là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Trường hợp là nhân viên mới
                if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
                //Điền dữ liệu chu kỳ lương vào dropdownlist
                LoadYearSal(Session["EmployeeID"].ToString());
            }


            if (Session["CR_YearID"] != null)
            {
                int yearid = (int)Session["CR_YearID"];
                DateTime EndCycle = new DateTime(yearid, 12, 20);
                DateTime TempBeginCycle = EndCycle.AddMonths(-1);
                DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

                DataTable dt = getReportSource(Session["EmployeeID"].ToString(), Session["CR_YearID"].ToString());

                if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
                {
                    NPOL.Report.PER_PIT_Online_en report = new NPOL.Report.PER_PIT_Online_en();
                    report.DataSource = dt;

                    report.Parameters["YearID"].Value = Session["CR_YearID"];
                    report.Parameters["EmpID"].Value = Session["EmployeeID"];
                    report.Parameters["UserID"].Value = Session["EmployeeID"];

                    report.RequestParameters = false;
                    ASPxDocumentViewer1.Report = report;
                }
                else
                {
                    NPOL.Report.PER_PIT_Online report = new NPOL.Report.PER_PIT_Online();
                    report.DataSource = dt;

                    report.Parameters["YearID"].Value = Session["CR_YearID"];
                    report.Parameters["EmpID"].Value = Session["EmployeeID"];
                    report.Parameters["UserID"].Value = Session["EmployeeID"];

                    report.RequestParameters = false;
                    ASPxDocumentViewer1.Report = report;
                }
            }


        }

        private DataTable getReportSource(string EmployeeID, string Year)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select * from PER_W_tblRptPIT_Online where EmployeeID = @EmployeeID and UserName = @UserID and YearID = @YearID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@UserID", "@YearID" };
            provider.ValueCollection = new object[] { EmployeeID, "PER_PIT_Online", Year };
            DataTable dt = provider.GetDataTable();
            provider.CloseConnection();
            return dt;
        }

        private void LoadYearSal(string employeeid)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "select distinct YearID from PER_W_tblEmpPIT order by YearID desc";
            //provider.CommandText = "select distinct YearID from PER_W_tblEmpPIT where EmployeeID = @EmployeeID order by YearID desc";
            //provider.ParameterCollection = new string[] { "@EmployeeID" };
            //provider.ValueCollection = new object[] { employeeid };
            DataTable dt = provider.GetDataTable();
            string strYear = "";
            if (dt.Rows.Count > 0)
            {
                ASPxButton1.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strYear = dt.Rows[i]["YearID"].ToString();
                    ddlYearSal.Items.Add(new ListItem(strYear));
                }
            }
            else
            {
                ASPxButton1.Enabled = false;
                ASPxLabel1.Visible = true;
            }
            provider.CloseConnection();
        }

        protected void ddlYearSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("CR_YearID");
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            string EmpID = Session["EmployeeID"].ToString();
            int YearID = Convert.ToInt32(ddlYearSal.Text);
            if (AllowView(YearID, EmpID))
            {
                Session["CR_YearID"] = YearID;
                ASPxLabel1.Visible = false;
                // Goi procudure 
                Call_PER_W_sp_RptPIT_online(YearID, EmpID, "PER_PIT_Online");
            }
            else
            {
                //string message = "alert('" + GetGlobalResourceObject("ViewIncomeTax", "alertNull").ToString() + "')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                ASPxLabel1.Visible = true;

                //Reset session
                Session.Remove("CR_YearID");
                return;
            }

        }

        private bool AllowView(int YearID, string EmpID)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "select distinct YearID from PER_W_tblEmpPIT where EmployeeID = @EmployeeID and YearID=@YearID";
            provider.ParameterCollection = new string[] { "@YearID", "@EmployeeID" };
            provider.ValueCollection = new object[] { YearID, EmpID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                validate = true;
            }
            provider.CloseConnection();
            return validate;
        }

        private void Call_PER_W_sp_RptPIT_online(int yearid, string empid, string userid)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            try
            {
                //Mở kết nối
                if (sqlConnection == null || sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
                    sqlConnection.Open();
                }

                //Khái báo cho đối tượng SqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "PER_W_sp_RptPIT_online";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                //Khai báo thời gian timeout vô thời hạn
                sqlCommand.CommandTimeout = 0;

                //Add tham số
                sqlCommand.Parameters.AddWithValue("@YearID", yearid);
                sqlCommand.Parameters.AddWithValue("@EmpID", empid);
                sqlCommand.Parameters.AddWithValue("@UserID", userid);

                //Thực thi store
                sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();
            }
            catch (Exception ex)
            {

            }
        }
    }
}