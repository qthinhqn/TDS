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
    public partial class AF_LeaveReportNew : System.Web.UI.Page
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
                if (!Session["Role"].ToString().Equals("HR") && !Session["Role"].ToString().Substring(0, 1).Equals("M"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
                dsReport2.SelectParameters.Add("UserID", Session["EmployeeID"].ToString());


                // Lay thong tin cu da luu trong tblEmpLeaveReport
                if (Session["CR_FromDate"] == null && Session["CR_ToDate"] == null)
                {
                    khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                    DataTable dt;
                    try
                    {
                        provider.CommandText = "Select 'Year'=Year(Getdate()), * from tblEmpLeaveReport Where EmployeeID = @UserID";
                        provider.ParameterCollection = new string[] { "@UserID" };
                        provider.ValueCollection = new object[] { Session["EmployeeID"].ToString().ToUpper() };
                        dt = provider.GetDataTable();
                        if (dt.Rows.Count > 0)
                        {
                            if (Session["EmployeeID"].ToString().ToUpper() == "HR_ONLINE")
                            {
                                Session["CR_FromDate"] = (DateTime)dt.Rows[0]["BeginDate"];
                                Session["CR_ToDate"] = (DateTime)dt.Rows[0]["EndDate"];
                            }
                            else
                            {
                                FromDate.Value = new DateTime((int)dt.Rows[0]["Year"], 1, 1);
                                ToDate.Value = new DateTime((int)dt.Rows[0]["Year"], 12, 31);
                                Session["CR_FromDate"] = FromDate.Value;
                                Session["CR_ToDate"] = ToDate.Value;

                                btnView1_Click(null, null);
                            }
                        }
                        else
                        {
                            FromDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
                            ToDate.Value = new DateTime(DateTime.Now.Year, 12, 31);
                            Session["CR_FromDate"] = FromDate.Value;
                            Session["CR_ToDate"] = ToDate.Value;

                            btnView1_Click(null, null);
                        }
                    }
                    catch
                    {

                    }
                    provider.CloseConnection();
                }

                // Load data grid
                LoadDataGrid();
                
            }
            if (Session["EmployeeID"].ToString().ToUpper() == "HR_ONLINE")
            {
                gvReport.DataSourceID = "dsReport";
                ShowReport();
                //divExport.Visible = false;
            }
            else
            {
                // hide report
                btnExport.Visible = false;
                ASPxDocumentViewer1.Visible = false;
                gvReport.DataSourceID = "dsReport2";
                divTonghop.Visible = false;
                //divExport.Visible = true;
            }
        }

        private void LoadDataGrid()
        {
            gvReport.DataBind();
        }
        protected void ShowReport()
        {
            #region Show Report

            //if (StaticCls.flag == 1)
            {
                if (Session["CR_FromDate"] != null && Session["CR_ToDate"] != null)
                {
                    LeaveReport report = new LeaveReport();
                    if (Session["CR_FromDate"] == null)
                    {
                        report.Parameters["_Year"].Value = "";
                        report.Parameters["_LastYear"].Value = "";
                        report.Parameters["_FromDate"].Value = "";
                    }
                    else
                    {
                        report.Parameters["_Year"].Value = ((DateTime)Session["CR_FromDate"]).Year;
                        report.Parameters["_LastYear"].Value = ((DateTime)Session["CR_FromDate"]).Year - 1;
                        report.Parameters["_FromDate"].Value = convertMonth((DateTime)Session["CR_FromDate"]) + "/" + convertDay((DateTime)Session["CR_FromDate"]);
                    }

                    if (Session["CR_ToDate"] == null)
                    {
                        report.Parameters["_ToDate"].Value = "";
                    }
                    else
                    {
                        report.Parameters["_ToDate"].Value = convertMonth((DateTime)Session["CR_ToDate"]) + "/" + convertDay((DateTime)Session["CR_ToDate"]);
                    }

                    //Gán datasource cho report
                    if (StaticCls.dt != null)
                    {
                        report.DataSource = StaticCls.dt;
                        report.DataMember = StaticCls.dt.TableName;
                    }

                    ASPxDocumentViewer1.Report = report;
                    ASPxDocumentViewer1.Report.ExportOptions.Xls.TextExportMode = TextExportMode.Text;
                    ASPxDocumentViewer1.Report.ExportOptions.Xlsx.TextExportMode = TextExportMode.Text;
                    // Old code
                    /* 
                    if (Session["lang"] != null && Session["lang"].ToString().Equals("en"))
                    {
                        AnnualLeave report = new AnnualLeave();
                        if (Session["CR_FromDate"] == null)
                        {
                            report.Parameters["_Year"].Value = "";
                            report.Parameters["_FromDate"].Value = "";
                        }
                        else
                        {
                            report.Parameters["_Year"].Value = ((DateTime)Session["CR_FromDate"]).Year;
                            report.Parameters["_FromDate"].Value = convertMonth((DateTime)Session["CR_FromDate"]) + "/" + convertDay((DateTime)Session["CR_FromDate"]);
                        }

                        if (Session["CR_ToDate"] == null)
                        {
                            report.Parameters["_ToDate"].Value = "";
                        }
                        else
                        {
                            report.Parameters["_ToDate"].Value = convertMonth((DateTime)Session["CR_ToDate"]) + "/" + convertDay((DateTime)Session["CR_ToDate"]);
                        }

                        //Gán datasource cho report
                        if (StaticCls.dt != null)
                        {
                            report.DataSource = StaticCls.dt;
                            report.DataMember = StaticCls.dt.TableName;
                        }

                        ASPxDocumentViewer1.Report = report;
                        ASPxDocumentViewer1.Report.ExportOptions.Xls.TextExportMode = TextExportMode.Text;
                        ASPxDocumentViewer1.Report.ExportOptions.Xlsx.TextExportMode = TextExportMode.Text;
                    }
                    else
                    {
                        AnnualLeave report = new AnnualLeave();
                        if (Session["CR_FromDate"] == null)
                        {
                            report.Parameters["_Year"].Value = "";
                            report.Parameters["_FromDate"].Value = "";
                        }
                        else
                        {
                            report.Parameters["_Year"].Value = ((DateTime)Session["CR_FromDate"]).Year;
                            report.Parameters["_FromDate"].Value = convertDay((DateTime)Session["CR_FromDate"]) + "/" + convertMonth((DateTime)Session["CR_FromDate"]);
                        }

                        if (Session["CR_ToDate"] == null)
                        {
                            report.Parameters["_ToDate"].Value = "";
                        }
                        else
                        {
                            report.Parameters["_ToDate"].Value = convertDay((DateTime)Session["CR_ToDate"]) + "/" + convertMonth((DateTime)Session["CR_ToDate"]);
                        }
                        //Gán datasource cho report
                        if (StaticCls.dt != null)
                        {
                            report.DataSource = StaticCls.dt;
                            report.DataMember = StaticCls.dt.TableName;
                        }
                        ASPxDocumentViewer1.Report = report;
                        ASPxDocumentViewer1.Report.ExportOptions.Xls.TextExportMode = TextExportMode.Text;
                        ASPxDocumentViewer1.Report.ExportOptions.Xlsx.TextExportMode = TextExportMode.Text;
                    }
                     */

                    // hide panel parameter before preview
                    PrintingSystemBase ps;
                    ps = report.PrintingSystem;
                    ps.SetCommandVisibility(PrintingSystemCommand.Parameters, CommandVisibility.None);
                    ps.SetCommandVisibility(PrintingSystemCommand.SubmitParameters, CommandVisibility.None);
                }
                //StaticCls.flag = 0;
            }
            #endregion

        }

        private string convertMonth(DateTime input)
        {
            string strMonth = null;
            int Month = input.Month;
            if (Month < 10)
            {
                strMonth = "0" + Month;
            }
            else
            {
                strMonth = Month.ToString();
            }
            return strMonth;
        }

        private string convertDay(DateTime input)
        {
            string strDay = null;
            int Day = input.Day;
            if (Day < 10)
            {
                strDay = "0" + Day;
            }
            else
            {
                strDay = Day.ToString();
            }
            return strDay;
        }

        //protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    DateTime frDate = (DateTime)FromDate.Value;
        //    DateTime toDate = (DateTime)ToDate.Value;
        //    DateTime temp;
        //    if (DateTime.Compare(frDate,toDate) > 0)
        //    {
        //        temp = frDate;
        //        FromDate.Value = toDate;
        //        ToDate.Value = temp;
        //    }

        //    if (frDate.Year != toDate.Year)
        //    {
        //        args.IsValid = false;
        //        this.CustomValidator1.ErrorMessage = "Bạn đang chọn thời gian theo dõi không cùng năm";
        //    }
        //}



        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;


        protected void btnView1_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            Session["CR_FromDate"] = FromDate.Value;
            Session["CR_ToDate"] = ToDate.Value;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                //lbMessage.ForeColor = System.Drawing.Color.Green;
                //lbMessage.Text = "Đang xử lý .......";


                //provider.CommandText = "PER_sp_Rpt_LeaveReport";
                //provider.CommandType = System.Data.CommandType.StoredProcedure;
                //provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@UserID" };
                //provider.ValueCollection = new object[] { FromDate.Value, ToDate.Value, "LeaveReport" };
                //provider.ExecuteNonQuery();

                //Mở kết nối
                if (sqlConnection == null || sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                    sqlConnection.Open();
                }

                //Khái báo cho đối tượng SqlCommand
                sqlCommand = new SqlCommand();
                if (Session["EmployeeID"].ToString().ToUpper() == "HR_ONLINE")
                {
                    sqlCommand.CommandText = "ZUE_sp_Rpt_LeaveReport";
                    sqlCommand.Parameters.AddWithValue("@UserID", "LeaveReport");
                }
                else
                {
                    sqlCommand.CommandText = "ZUE_sp_Rpt_LeaveReport4Manager";
                    sqlCommand.Parameters.AddWithValue("@UserID", Session["EmployeeID"].ToString().ToUpper());

                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                //Khai báo thời gian timeout vô thời hạn
                sqlCommand.CommandTimeout = 0;

                //Add tham số
                sqlCommand.Parameters.AddWithValue("@FromDate", FromDate.Value);
                sqlCommand.Parameters.AddWithValue("@ToDate", ToDate.Value);

                //Thực thi store
                sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();


                lbMessage.ForeColor = System.Drawing.Color.Blue;
                //lbMessage.Text = "Đã tổng hợp xong dữ liệu";
                if (Session["Role"].ToString().Equals("HR"))
                    lbMessage.Text = GetGlobalResourceObject("AF_LeaveReport", "lbMessage").ToString();

                LoadDataGrid();
                //gvReport.DataBind();
                //provider.CloseConnection();
            }
            catch (Exception ex)
            {
                lbMessage.ForeColor = System.Drawing.Color.Red;
                lbMessage.Text = ex.Message;
            }
        }

        static DataTable datasource = new DataTable();
        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (datasource.Columns.Count == 0)
            {
                datasource.Columns.Add("UserID");
                datasource.Columns.Add("EmployeeID");
                datasource.Columns.Add("EmployeeName");
                datasource.Columns.Add("EmployedDate");
                datasource.Columns.Add("Seniority");
                datasource.Columns.Add("DepName");
                datasource.Columns.Add("LineName");
                datasource.Columns.Add("PosName");
                datasource.Columns.Add("ALInital");
                datasource.Columns.Add("ALinYear");
                datasource.Columns.Add("AL");
                datasource.Columns.Add("B1_B2");
                datasource.Columns.Add("SL_A6");
                datasource.Columns.Add("UL");
                datasource.Columns.Add("SL_A5");
                datasource.Columns.Add("CS");
                datasource.Columns.Add("SL");
                datasource.Columns.Add("SL_L");
                datasource.Columns.Add("ME");
                datasource.Columns.Add("ML");
                datasource.Columns.Add("SB");
                datasource.Columns.Add("SB_7");
                datasource.Columns.Add("PL");
                datasource.Columns.Add("SL_AS");
                datasource.Columns.Add("SL_AM");
                datasource.Columns.Add("ALBalance");
            }
            else
            {
                datasource.Clear();
            }

            //Tổng hợp datasource
            ArrayList arr;
            for (int i = 0; i < gvReport.VisibleRowCount; i++)
            {
                arr = new ArrayList();
                //for (int k = 0; k < 62; k++)
                //{
                //    arr.Add(gvReport.GetDataRow(i)[k]);
                //}

                arr.Add(gvReport.GetDataRow(i)["UserID"]);
                arr.Add(gvReport.GetDataRow(i)["EmployeeID"]);
                arr.Add(gvReport.GetDataRow(i)["EmployeeName"]);                
                arr.Add(gvReport.GetDataRow(i)["EmployedDate"]); 
                arr.Add(gvReport.GetDataRow(i)["Seniority"]);
                arr.Add(gvReport.GetDataRow(i)["DepName"]);               
                arr.Add(gvReport.GetDataRow(i)["LineName"]);
                arr.Add(gvReport.GetDataRow(i)["PosName"]);

                arr.Add(gvReport.GetDataRow(i)["ALInital"]);
                arr.Add(gvReport.GetDataRow(i)["ALinYear"]);
                arr.Add(gvReport.GetDataRow(i)["AL"]);

                arr.Add(gvReport.GetDataRow(i)["B1_B2"]);
                arr.Add(gvReport.GetDataRow(i)["SL_A6"]);
                arr.Add(gvReport.GetDataRow(i)["UL"]);
                arr.Add(gvReport.GetDataRow(i)["SL_A5"]);

                arr.Add(gvReport.GetDataRow(i)["CS"]);
                arr.Add(gvReport.GetDataRow(i)["SL"]);
                arr.Add(gvReport.GetDataRow(i)["SL_L"]);
                arr.Add(gvReport.GetDataRow(i)["ME"]);

                arr.Add(gvReport.GetDataRow(i)["ML"]);
                arr.Add(gvReport.GetDataRow(i)["SB"]);
                arr.Add(gvReport.GetDataRow(i)["SB_7"]);
                arr.Add(gvReport.GetDataRow(i)["PL"]);

                arr.Add(gvReport.GetDataRow(i)["SL_AS"]);
                arr.Add(gvReport.GetDataRow(i)["SL_AM"]);

                arr.Add(gvReport.GetDataRow(i)["ALBalance"]);

                datasource.Rows.Add(arr.ToArray());
            }
            
            StaticCls.dt = datasource;
            StaticCls.flag = 1;
            //ShowReport();
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