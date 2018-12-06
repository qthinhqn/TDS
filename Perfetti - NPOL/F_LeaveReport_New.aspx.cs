using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using NPOL.Report;
using System.Data.SqlClient;
using System.Data;
using System.Collections;


namespace NPOL
{
    public partial class F_LeaveReport_New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["EmployeeID"] = "ADMIN";
            //Session["Role"] = "HR";

            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //Truong hop là nhân viên moi hoac nhân viên cu
                if (Session["Role"].ToString().Substring(0, 1).Equals("E"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Truong hop là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = Session["EmployeeID"].ToString();

                // Load current data
                LoadData();
            }

            // load data for gridview
            //LoadData();

            gvReport.DataSource = LeaveReport.getAllLeaveByManager(Session["EmployeeID"].ToString());
            gvReport.DataBind();

        }
        
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public void LoadData()
        {
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
                sqlCommand.CommandText = "PER_sp_Rpt_LeaveReport4Manager";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                //Khai báo thời gian timeout vô thời hạn
                sqlCommand.CommandTimeout = 0;

                //Add tham số
                sqlCommand.Parameters.AddWithValue("@FromDate", new  DateTime(DateTime.Now.Year, 1,1));
                sqlCommand.Parameters.AddWithValue("@ToDate", new DateTime(DateTime.Now.Year, 12, 31));
                sqlCommand.Parameters.AddWithValue("@EmpID", "");
                sqlCommand.Parameters.AddWithValue("@UserID", Session["EmployeeID"].ToString());

                //Thực thi store
                sqlCommand.ExecuteNonQuery();
                /*
                LeaveReport obj = new LeaveReport();
                ArrayList EmpList = obj.getEmpIDListByManager(Session["EmployeeID"].ToString());
                if (EmpList != null)
                {
                    for(int i=0; i<EmpList.Count; i++)
                    {
                        sqlCommand.Parameters["@EmpID"].Value = EmpList[i].ToString();
                        //Thực thi store
                        sqlCommand.ExecuteNonQuery();

                    }
                }
                */
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