using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using NPOL.Report;

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
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
                //Điền dữ liệu chu kỳ lương vào dropdownlist
                LoadYearSal(Session["EmployeeID"].ToString());
                LoadChuKyLuong(Session["EmployeeID"].ToString(), ddlYearSal.Text);
            }


            if (Session["CR_MonthID"] != null && Session["CR_YearID"] != null && Session["CR_SalTypeID"] != null)
            {
                if (String.Compare(Session["CR_SalTypeID"].ToString(), "Sweep") == 0 || String.Compare(Session["CR_SalTypeID"].ToString(), "NoSweep") == 0)
                {
                    int monthid = (int)Session["CR_MonthID"];
                    int yearid = (int)Session["CR_YearID"];
                    DateTime EndCycle = new DateTime(yearid, monthid, 20);
                    DateTime TempBeginCycle = EndCycle.AddMonths(-1);
                    DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

                    NPOL.Report.Xtra_AtSite report = new NPOL.Report.Xtra_AtSite();
                    report.DataSource = getReportSource(Session["EmployeeID"].ToString(), Session["CR_MonthID"].ToString(), Session["CR_YearID"].ToString());

                    //report.Parameters["BeginCycleSal"].Value = BeginCycle.ToShortDateString();
                    //report.Parameters["EndCycleSal"].Value = EndCycle.ToShortDateString();
                    string beginDay = "", beginMonth = "", endDay = "", endMonth = "";

                    if (BeginCycle.Day < 10)
                        beginDay = "0" + BeginCycle.Day.ToString();
                    else
                        beginDay = BeginCycle.Day.ToString();

                    if (BeginCycle.Month < 10)
                        beginMonth = "0" + BeginCycle.Month.ToString();
                    else
                        beginMonth = BeginCycle.Month.ToString();

                    if (EndCycle.Day < 10)
                        endDay = "0" + EndCycle.Day.ToString();
                    else
                        endDay = EndCycle.Day.ToString();

                    if (EndCycle.Month < 10)
                        endMonth = "0" + EndCycle.Month.ToString();
                    else
                        endMonth = EndCycle.Month.ToString();


                    string BeginCycle_vn = beginDay + "/" + beginMonth + "/" + BeginCycle.Year;
                    string EndCycle_vn = endDay + "/" + endMonth + "/" + EndCycle.Year;

                    string BeginCycle_en = beginMonth + "/" + beginDay + "/" + BeginCycle.Year;
                    string EndCycle_en = endMonth + "/" + endDay + "/" + EndCycle.Year;

                    if (Session["lang"] == null || Session["lang"].ToString().Equals("vn"))
                    {
                        report.Parameters["BeginCycleSal"].Value = BeginCycle_vn;
                        report.Parameters["EndCycleSal"].Value = EndCycle_vn;
                    }
                    else
                    {
                        report.Parameters["BeginCycleSal"].Value = BeginCycle_vn;
                        report.Parameters["EndCycleSal"].Value = EndCycle_vn;
                    }

                    report.RequestParameters = false;
                    ASPxDocumentViewer1.Report = report;
                }
                else
                {
                    int monthid = (int)Session["CR_MonthID"];
                    int yearid = (int)Session["CR_YearID"];
                    DateTime EndCycle = new DateTime(yearid, monthid, 20);
                    DateTime TempBeginCycle = EndCycle.AddMonths(-1);
                    DateTime BeginCycle = new DateTime(TempBeginCycle.Year, TempBeginCycle.Month, 21);

                    NPOL.Report.Xtra_Sale report = new NPOL.Report.Xtra_Sale();
                    report.DataSource = getReportSource(Session["EmployeeID"].ToString(), Session["CR_MonthID"].ToString(), Session["CR_YearID"].ToString());
                    //report.FilterString = "[EmployeeID] = '" + Session["EmployeeID"].ToString() + "' and [MonthID] = " + monthid + " and [YearID] = " + yearid;


                    string beginDay = "", beginMonth = "", endDay = "", endMonth = "";

                    if (BeginCycle.Day < 10)
                        beginDay = "0" + BeginCycle.Day.ToString();
                    else
                        beginDay = BeginCycle.Day.ToString();

                    if (BeginCycle.Month < 10)
                        beginMonth = "0" + BeginCycle.Month.ToString();
                    else
                        beginMonth = BeginCycle.Month.ToString();

                    if (EndCycle.Day < 10)
                        endDay = "0" + EndCycle.Day.ToString();
                    else
                        endDay = EndCycle.Day.ToString();

                    if (EndCycle.Month < 10)
                        endMonth = "0" + EndCycle.Month.ToString();
                    else
                        endMonth = EndCycle.Month.ToString();


                    string BeginCycle_vn = beginDay + "/" + beginMonth + "/" + BeginCycle.Year;
                    string EndCycle_vn = endDay + "/" + endMonth + "/" + EndCycle.Year;

                    string BeginCycle_en = beginMonth + "/" + beginDay + "/" + BeginCycle.Year;
                    string EndCycle_en = endMonth + "/" + endDay + "/" + EndCycle.Year;

                    if (Session["lang"] == null || Session["lang"].ToString().Equals("vn"))
                    {
                        report.Parameters["BeginCycleSal"].Value = BeginCycle_vn;
                        report.Parameters["EndCycleSal"].Value = EndCycle_vn;
                    }
                    else
                    {
                        report.Parameters["BeginCycleSal"].Value = BeginCycle_vn;
                        report.Parameters["EndCycleSal"].Value = EndCycle_vn;
                    }

                    //report.Parameters["BeginCycleSal"].Value = BeginCycle.ToShortDateString();
                    //report.Parameters["EndCycleSal"].Value = EndCycle.ToShortDateString();

                    report.RequestParameters = false;
                    ASPxDocumentViewer1.Report = report;
                }
            }


        }

        private DataTable getReportSource(string EmployeeID, string Month, string Year)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select * from tblPayroll_Online where YearID = @YearID and MonthID = @MonthID and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@YearID", "@MonthID", "@EmployeeID" };
            provider.ValueCollection = new object[] { yearid, monthid, employeeid };
            System.Data.DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = dt.Rows[0]["SalaryTypeID"].ToString();
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool getIsAdvanceEIP(int monthid, int yearid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "select MonthID, YearID from tblPayroll_Online where EmployeeID = @EmployeeID and YearID = @YearID order by YearID desc, MonthID desc";
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
                    ddlChukyluong.Items.Add(new ListItem(strMonth + "-" + strYear));
                }
            }
            provider.CloseConnection();
        }

        private void LoadYearSal(string employeeid)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "select distinct YearID from tblPayroll_Online where EmployeeID = @EmployeeID and YearID > 2015 order by YearID desc";
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
            int MonthID = Convert.ToInt32(ddlChukyluong.Text.Substring(0, 2));
            int YearID = Convert.ToInt32(ddlChukyluong.Text.Substring(3, 4));
            string SalTypeID = getSalaryTypeID(MonthID, YearID, EmpID);

            if (AllowView(MonthID, YearID))
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

        }

        private bool AllowView(int MonthID, int YearID)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select distinct MonthID, YearID from tblPayroll_Lock where MonthID = @MonthID and YearID = @YearID";
            provider.ParameterCollection = new string[] { "@MonthID", "@YearID" };
            provider.ValueCollection = new object[] { MonthID, YearID };
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