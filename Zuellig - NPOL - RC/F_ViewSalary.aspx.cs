using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOL.Report;
using CrystalDecisions.CrystalReports.Engine;

namespace NPOL
{
    public partial class F_ViewSalary : System.Web.UI.Page
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
                //Reset session
                Session.Remove("CR_MonthID");
                Session.Remove("CR_YearID");

                ////Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
                
                //Điền dữ liệu chu kỳ lương vào dropdownlist
                LoadYearSal(Session["EmployeeID"].ToString());
                LoadChuKyLuong(Session["EmployeeID"].ToString(), ddlYearSal.Text);
            }

            
            if (Session["CR_MonthID"] != null && Session["CR_YearID"] != null && Session["CR_SalTypeID"] != null)
            {
                int monthid = (int)Session["CR_MonthID"];
                int yearid = (int)Session["CR_YearID"];
                DateTime EndCycle = new DateTime(yearid, monthid, 20);
                DateTime TempBeginCycle = EndCycle.AddMonths(-1);
                DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

                ReportDocument report = new ReportDocument();
                DataTable ds = getReportSource(Session["EmployeeID"].ToString(), Session["CR_MonthID"].ToString(), Session["CR_YearID"].ToString(), "Payslip");

                if (ds != null && ds.Rows.Count > 0)
                {
                    if (ds.Rows[0]["SecID"].ToString() == "LA")
                    {
                        report.Load(Server.MapPath(@"~/Report/CR_Payslip_LA.rpt"));
                        report.FileName = Server.MapPath(@"~/Report/CR_Payslip_LA.rpt");
                    }
                    else
                    {
                        {
                            report.Load(Server.MapPath(@"~/Report/CR_Payslip.rpt"));
                            report.FileName = Server.MapPath(@"~/Report/CR_Payslip.rpt");
                        }
                    }
                }
                report.SetDataSource(ds);
                CrystalReportViewer1.ReportSource = report;
            }
             
        }

        private void LoadPhieuLuong()
        {
            if (Session["CR_MonthID"] != null && Session["CR_YearID"] != null && Session["CR_SalTypeID"] != null)
            {
                int monthid = (int)Session["CR_MonthID"];
                int yearid = (int)Session["CR_YearID"];
                DateTime EndCycle = new DateTime(yearid, monthid, 20);
                DateTime TempBeginCycle = EndCycle.AddMonths(-1);
                DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

                ReportDocument report = new ReportDocument();
                DataTable ds = getReportSource(Session["EmployeeID"].ToString(), Session["CR_MonthID"].ToString(), Session["CR_YearID"].ToString(), "Payslip");

                if (ds != null && ds.Rows.Count > 0)
                {
                    if (ds.Rows[0]["SecID"].ToString() == "LA")
                    {
                        report.Load(Server.MapPath(@"~/Report/CR_Payslip_LA.rpt"));
                        report.FileName = Server.MapPath(@"~/Report/CR_Payslip_LA.rpt");
                    }
                    else
                    {
                        {
                            report.Load(Server.MapPath(@"~/Report/CR_Payslip.rpt"));
                            report.FileName = Server.MapPath(@"~/Report/CR_Payslip.rpt");
                        }
                    }
                    report.SetDataSource(ds);

                    CrystalReportViewer1.ReportSource = report;
                }
            }
        }
        private DataTable getReportSource(string EmployeeID, string monthID, string yearID, string type)
        {
            DataTable dt = new DataTable();
            try
            {
                string con = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                khSqlServerProvider provider = new khSqlServerProvider(con);
                provider.CommandText = "sp_PayrollOnline_PaySlip";
                provider.CommandType = CommandType.StoredProcedure;
                //provider.CommandText = "Select * from vPayroll_Payslip_SendMail where EmployeeID = @EmployeeID and MonthID = @MonthID and YearID = @YearID and Type = @Type";
                provider.ParameterCollection = new string[] { "@MonthID", "@YearID",  "@EmployeeID", "@Type"};
                provider.ValueCollection = new object[] { monthID, yearID, EmployeeID, type };
                dt = provider.GetDataTable();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        private DataTable getReportSource(string EmployeeID, string Month, string Year)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select * from tblPAYROLL_ONLINE where EmployeeID = @EmployeeID and MonthID = @MonthID and YearID = @YearID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@MonthID", "@YearID" };
            provider.ValueCollection = new object[] { EmployeeID, Month, Year };
            DataTable dt = provider.GetDataTable();
            provider.CloseConnection();
            return dt;
        }

        //protected void btnReport_Click(object sender, EventArgs e)
        //{
        //    string EmpID = Session["EmployeeID"].ToString();
        //    int MonthID = Convert.ToInt32(ddlChukyluong.Text.Substring(0, 2));
        //    int YearID = Convert.ToInt32(ddlChukyluong.Text.Substring(3, 4));            
        //    string SalTypeID = getSalaryTypeID(MonthID, YearID, EmpID);
        //    Session["CR_MonthID"] = MonthID;
        //    Session["CR_YearID"] = YearID;
        //    Session["CR_SalTypeID"] = SalTypeID;

        //    //if (String.Compare(SalTypeID, "Sweep", true) == 0 || String.Compare(SalTypeID, "NoSweep", true) == 0)
        //    //{
        //    //    Response.Write("<script type='text/javascript'>window.open('Dev_AtSite.aspx','_blank');</script>");
        //    //}
        //    //else
        //    //{
        //    //    if (getIsAdvanceEIP(MonthID, YearID))
        //    //    {
        //    //        Response.Write("<script type='text/javascript'>window.open('Dev_Sale1.aspx','_blank');</script>");
        //    //    }
        //    //    else
        //    //    {
        //    //        Response.Write("<script type='text/javascript'>window.open('Dev_Sale2.aspx','_blank');</script>");
        //    //    }
        //    //}
        //}

        public string getSalaryTypeID(int monthid, int yearid, string employeeid)
        {
            string returnValue = null;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select * from tblPayroll_SendMail where YearID = @YearID and MonthID = @MonthID and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@YearID", "@MonthID", "@EmployeeID" };
            provider.ValueCollection = new object[] { yearid, monthid, employeeid };
            System.Data.DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                //returnValue = dt.Rows[0]["SalaryTypeID"].ToString();
                returnValue = dt.Rows[0]["Type"].ToString();
            }
            provider.CloseConnection();
            return returnValue;
        }

        // Kiem tra tien thuong EIP_Sales cua thang @MonthID/@YearID co duoc tam ung truoc ko
        public bool getIsAdvanceEIP(int monthid, int yearid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "spPayroll_IsAdvanceEIP";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@MonthID", "@YearID" };
            provider.ValueCollection = new object[] { monthid, yearid };
            provider.OutputParameterCollection = new string[] { "@KQ" };
            provider.OutputDbTypeCollection = new SqlDbType[] { SqlDbType.Bit };
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            arr = provider.OutputExecuteNonQuery();
            if (arr.Count > 0)
            {
                returnValue = (bool)arr[0];
            }
            provider.CloseConnection();
            return returnValue;
        }

        private void LoadChuKyLuong(string employeeid, string year)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //provider.CommandText = "select MonthID, YearID from tblPayroll_Online where EmployeeID = @EmployeeID and YearID = @YearID order by YearID desc, MonthID desc";
            provider.CommandText = "select distinct MonthID, YearID from tblPayroll_SendMail where EmployeeID = @EmployeeID and YearID = @YearID order by YearID desc, MonthID desc";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@YearID" };
            provider.ValueCollection = new object[] { employeeid, year };
            DataTable dt = provider.GetDataTable();
            string strMonth = "";
            string strYear = "";
            if (dt.Rows.Count > 0)
            {
                ASPxButton1.Enabled = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strMonth = convertMonth(dt.Rows[i]["MonthID"]);
                    strYear = dt.Rows[i]["YearID"].ToString();
                    //ddlChukyluong.Items.Add(new ListItem(strMonth + "-" + strYear));
                    ddlChukyluong.Items.Add(new ListItem(strMonth));
                }
            }
            provider.CloseConnection();
        }

        private void LoadYearSal(string employeeid)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //provider.CommandText = "select distinct YearID from tblPayroll_Online where EmployeeID = @EmployeeID and YearID > 2015 order by YearID desc";
            provider.CommandText = "select distinct YearID from tblPayroll_SendMail where EmployeeID = @EmployeeID and YearID > 2016 and Type='Payslip' order by YearID desc";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { employeeid };
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
            provider.CloseConnection();
        }

        private string convertMonth(object month)
        {
            int Month = (int)month;
            string returnValue = "";
            if (Month < 10)
            {
                returnValue = string.Concat("0", month.ToString());
            }
            else
            {
                returnValue = month.ToString();
            }
            return returnValue;
        }

        protected void ddlYearSal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlChukyluong.Items.Clear();
            Session.Remove("CR_MonthID");
            Session.Remove("CR_YearID");
            Session.Remove("CR_SalTypeID");
            LoadChuKyLuong(Session["EmployeeID"].ToString(), ddlYearSal.Text);
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            string EmpID = Session["EmployeeID"].ToString();
            //int MonthID = Convert.ToInt32(ddlChukyluong.Text.Substring(0, 2));
            //int YearID = Convert.ToInt32(ddlChukyluong.Text.Substring(3, 4));
            int MonthID = Convert.ToInt32(ddlChukyluong.Text);
            int YearID = Convert.ToInt32(ddlYearSal.Text);
            string SalTypeID = getSalaryTypeID(MonthID, YearID, EmpID);

            if (AllowView(MonthID, YearID, EmpID))
            {
                Session["CR_MonthID"] = MonthID;
                Session["CR_YearID"] = YearID;
                Session["CR_SalTypeID"] = SalTypeID;
            }
            else
            {
                string message = "alert('" + GetGlobalResourceObject("ViewSalary", "alert").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);

                //Reset session
                Session.Remove("CR_MonthID");
                Session.Remove("CR_YearID");
                return;
            }

            // Check password 
            string Password = txtPass.Text.Trim();
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            if (kh.IsLogin_PayslipPass(EmpID, Password))
            {
                LoadPhieuLuong();
            }
            else
            {
                string message = "alert('Mật khẩu xác nhận không đúng. Vui lòng kiểm tra lại!')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                //Reset session
                Session.Remove("CR_MonthID");
                Session.Remove("CR_YearID");
                CrystalReportViewer1.ReportSource = null;
            }
        }

        private bool AllowView(int MonthID, int YearID, string EmployeeID)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
//            provider.CommandText = "Select distinct MonthID, YearID from tblPayroll_Lock where MonthID = @MonthID and YearID = @YearID";
            provider.CommandText = " Select distinct S.MonthID, S.YearID From tblPayroll P INNER JOIN tblPayroll_SendMail S ON 	P.EmployeeID = S.EmployeeID And P.MonthID = S.MonthID And P.YearID = S.YearID "
                                 + " Where S.MonthID = @MonthID and S.YearID = @YearID And S.EmployeeID=@EmployeeID";
            provider.ParameterCollection = new string[] { "@MonthID", "@YearID", "@EmployeeID" };
            provider.ValueCollection = new object[] { MonthID, YearID, EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                validate = true;
            }
            provider.CloseConnection();
            return validate;
        }

        //protected void btnReport1_Click(object sender, EventArgs e)
        //{
        //    string EmpID = Session["EmployeeID"].ToString();
        //    int MonthID = Convert.ToInt32(ddlChukyluong.Text.Substring(0, 2));
        //    int YearID = Convert.ToInt32(ddlChukyluong.Text.Substring(3, 4));
        //    string SalTypeID = getSalaryTypeID(MonthID, YearID, EmpID);
        //    Session["CR_MonthID"] = MonthID;
        //    Session["CR_YearID"] = YearID;
        //    Session["CR_SalTypeID"] = SalTypeID;
        //}
    }
}