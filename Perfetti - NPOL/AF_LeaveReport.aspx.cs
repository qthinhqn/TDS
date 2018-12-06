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
    public partial class AF_LeaveReport : System.Web.UI.Page
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
                if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = Session["EmployeeID"].ToString();
            }

            
            #region Show Report

            if (StaticCls.flag == 1)
            {
                if (Session["CR_FromDate"] != null && Session["CR_ToDate"] != null)
                {
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
            System.Threading.Thread.Sleep(2000);
            Session["CR_FromDate"] = FromDate.Value;
            Session["CR_ToDate"] = ToDate.Value;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
                    sqlConnection.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
                    sqlConnection.Open();
                }

                //Khái báo cho đối tượng SqlCommand
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "PER_sp_Rpt_LeaveReport";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                //Khai báo thời gian timeout vô thời hạn
                sqlCommand.CommandTimeout = 0;

                //Add tham số
                sqlCommand.Parameters.AddWithValue("@FromDate", FromDate.Value);
                sqlCommand.Parameters.AddWithValue("@ToDate", ToDate.Value);
                sqlCommand.Parameters.AddWithValue("@UserID", "LeaveReport");

                //Thực thi store
                sqlCommand.ExecuteNonQuery();

                //Đóng kết nối
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Dispose();


                lbMessage.ForeColor = System.Drawing.Color.Blue;
                lbMessage.Text = "Đã tổng hợp xong dữ liệu";

                gvReport.DataBind();
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
                datasource.Columns.Add("SectionName");
                datasource.Columns.Add("LineName");
                datasource.Columns.Add("PosName");
                datasource.Columns.Add("TotalALInit");
                datasource.Columns.Add("Jan_AL");
                datasource.Columns.Add("Jan_SL");
                datasource.Columns.Add("Jan_UP");
                datasource.Columns.Add("Jan_UN");
                datasource.Columns.Add("Feb_AL");
                datasource.Columns.Add("Feb_SL");
                datasource.Columns.Add("Feb_UP");
                datasource.Columns.Add("Feb_UN");
                datasource.Columns.Add("Mar_AL");
                datasource.Columns.Add("Mar_SL");
                datasource.Columns.Add("Mar_UP");
                datasource.Columns.Add("Mar_UN");
                datasource.Columns.Add("Apr_AL");
                datasource.Columns.Add("Apr_SL");
                datasource.Columns.Add("Apr_UP");
                datasource.Columns.Add("Apr_UN");
                datasource.Columns.Add("May_AL");
                datasource.Columns.Add("May_SL");
                datasource.Columns.Add("May_UP");
                datasource.Columns.Add("May_UN");
                datasource.Columns.Add("Jun_AL");
                datasource.Columns.Add("Jun_SL");
                datasource.Columns.Add("Jun_UP");
                datasource.Columns.Add("Jun_UN");
                datasource.Columns.Add("Jul_AL");
                datasource.Columns.Add("Jul_SL");
                datasource.Columns.Add("Jul_UP");
                datasource.Columns.Add("Jul_UN");
                datasource.Columns.Add("Aug_AL");
                datasource.Columns.Add("Aug_SL");
                datasource.Columns.Add("Aug_UP");
                datasource.Columns.Add("Aug_UN");
                datasource.Columns.Add("Sep_AL");
                datasource.Columns.Add("Sep_SL");
                datasource.Columns.Add("Sep_UP");
                datasource.Columns.Add("Sep_UN");
                datasource.Columns.Add("Oct_AL");
                datasource.Columns.Add("Oct_SL");
                datasource.Columns.Add("Oct_UP");
                datasource.Columns.Add("Oct_UN");
                datasource.Columns.Add("Nov_AL");
                datasource.Columns.Add("Nov_SL");
                datasource.Columns.Add("Nov_UP");
                datasource.Columns.Add("Nov_UN");
                datasource.Columns.Add("Dec_AL");
                datasource.Columns.Add("Dec_SL");
                datasource.Columns.Add("Dec_UP");
                datasource.Columns.Add("Dec_UN");
                datasource.Columns.Add("TotalAL");
                datasource.Columns.Add("TotalSL");
                datasource.Columns.Add("TotalUP");
                datasource.Columns.Add("TotalUN");
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
                arr.Add(gvReport.GetDataRow(i)["SectionName"]);               
                arr.Add(gvReport.GetDataRow(i)["LineName"]);
                arr.Add(gvReport.GetDataRow(i)["PosName"]);

                arr.Add(gvReport.GetDataRow(i)["TotalALInit"]);

                arr.Add(gvReport.GetDataRow(i)["Jan_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Jan_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Jan_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Jan_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Feb_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Feb_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Feb_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Feb_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Mar_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Mar_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Mar_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Mar_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Apr_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Apr_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Apr_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Apr_UN"]);

                arr.Add(gvReport.GetDataRow(i)["May_AL"]);
                arr.Add(gvReport.GetDataRow(i)["May_SL"]);
                arr.Add(gvReport.GetDataRow(i)["May_UP"]);
                arr.Add(gvReport.GetDataRow(i)["May_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Jun_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Jun_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Jun_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Jun_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Jul_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Jul_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Jul_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Jul_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Aug_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Aug_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Aug_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Aug_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Sep_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Sep_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Sep_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Sep_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Oct_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Oct_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Oct_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Oct_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Nov_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Nov_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Nov_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Nov_UN"]);

                arr.Add(gvReport.GetDataRow(i)["Dec_AL"]);
                arr.Add(gvReport.GetDataRow(i)["Dec_SL"]);
                arr.Add(gvReport.GetDataRow(i)["Dec_UP"]);
                arr.Add(gvReport.GetDataRow(i)["Dec_UN"]);

                arr.Add(gvReport.GetDataRow(i)["TotalAL"]);
                arr.Add(gvReport.GetDataRow(i)["TotalSL"]);
                arr.Add(gvReport.GetDataRow(i)["TotalUP"]);
                arr.Add(gvReport.GetDataRow(i)["TotalUN"]);

                arr.Add(gvReport.GetDataRow(i)["ALBalance"]);

                datasource.Rows.Add(arr.ToArray());
            }
            
            StaticCls.dt = datasource;
            StaticCls.flag = 1;
        }


    }
}