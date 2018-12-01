using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using conn = System.Web.Configuration;
using DevExpress.Web;
using NPOL.App_Code.Business;

namespace NPOL
{
    public partial class F_Registration1 : System.Web.UI.Page
    {
        bool IsForeWarning = true;
        bool IsForeWarningUP = true;
        bool IsForeWarningMR1 = true;
        bool IsForeWarningMR2 = true;
        bool IsForeWarning_RegisterDate = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //Trường hợp là nhân viên mới
                if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Trường hợp chỉ là quản lý 
                if (Session["Role"].ToString().Substring(0, 1).Equals("M") && Session["MID1"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                //Trường hợp là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            //Tiêu đề trang & noi dung loai nghi phep
            if (Session["lang"] != null)
            {
                if (Session["lang"].ToString().Equals("vi"))
                {
                    ASPxGridView1.Columns["LeaveType"].Visible = true;
                    ASPxGridView1.Columns["LeaveType_eng"].Visible = false;
                    ASPxGridView1.Columns["PerTimeName"].Visible = true;
                    ASPxGridView1.Columns["PerTimeName_eng"].Visible = false;
                    lbTieuDe.Text = "Đăng ký nghỉ phép năm " + DateTime.Now.Year;
                }
                else
                {
                    ASPxGridView1.Columns["LeaveType"].Visible = false;
                    ASPxGridView1.Columns["LeaveType_eng"].Visible = true;
                    ASPxGridView1.Columns["PerTimeName"].Visible = false;
                    ASPxGridView1.Columns["PerTimeName_eng"].Visible = true;
                    lbTieuDe.Text = "Leave registration year " + DateTime.Now.Year;
                    drLoainghi.TextField = "LeaveType_eng";
                    drchedonghi.TextField = "PerTimeName_eng";
                }
            }
            else
            {
                lbTieuDe.Text = "Đăng ký nghỉ phép năm " + DateTime.Now.Year;
            }


            //Nạp dữ liệu chế độ nghỉ khi mở trang
            if (!IsPostBack)
            {
                // Nap DL loai nghi
                DataTable dt = new DataTable();
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "spGetLeaveType";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@EmpID" };
                provider.ValueCollection = new object[] { Session["EmployeeID"].ToString() };
                dt = provider.GetDataTable();
                int count = dt.Rows.Count;
                provider.CloseConnection();
                drLoainghi.DataSource = dt;
                drLoainghi.DataBind();

                drchedonghi.DataSource = getPerTimeDataSource2();
                drchedonghi.DataBind();
                drchedonghi.SelectedIndex = 0;

                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    //teditTuGio.Enabled = true;
                    //teditDenGio.Enabled = true;
                    //vTongGio.Enabled = true;
                    //btnTinhGio.Enabled = true;
                    vTongNgay.Enabled = false;
                    txtTongNgay.Text = "";
                }
                else
                {
                    //teditTuGio.Enabled = false;
                    //teditDenGio.Enabled = false;
                    //vTongGio.Enabled = false;
                    //btnTinhGio.Enabled = false;
                    vTongNgay.Enabled = true;
                }

                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            ASPxGridView1.JSProperties["cpDeleted"] = "";

            //Nếu nhân viên chưa ký HĐLĐ thì không hiện phép tồn
            if (!havingContract(Session["EmployeeID"].ToString(), DateTime.Today))
            {
                txtPhepTon.Text = "";
                txtAL.Text = "";
                txtTotalAL.Text = "";
                HiddenField1.Value = "";
                //LoaiPhepDS.SelectCommand = "SELECT LeaveID, LeaveType FROM tblRef_LeaveType where IsOnline = 'True' and LeaveID <> 'AL' and LeaveID <> 'CL_OT10'";
                //LoaiPhepDS.SelectCommandType = SqlDataSourceCommandType.Text; 
                //LoaiPhepDS.DataBind();


                //txtPhepTon.Value = CalculateALRemain(Session["EmployeeID"].ToString());  
            }
            else if (ProbationContract(Session["EmployeeID"].ToString()))
            {
                txtPhepTon.Text = "";
                txtAL.Text = "";
                txtTotalAL.Text = "";
                HiddenField1.Value = "";
                //LoaiPhepDS.SelectCommand = "SELECT LeaveID,LeaveType,LeaveType_eng FROM dbo.tblRef_LeaveType WHERE (IsOnline = 'True') AND LeaveID IN ('UL', 'B1', 'B1_1', 'B2')";
                //LoaiPhepDS.SelectCommandType = SqlDataSourceCommandType.Text;
                //LoaiPhepDS.DataBind();
            }
            else
            {
                txtPhepTon.Value = CalculateALRemain(Session["EmployeeID"].ToString());
            }

            //Hiển thịp phép nghỉ bù
            //StaticCls.phepbu = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
            //ViewState["phepbu"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
            //txtPhepbu.Text = ViewState["phepbu"].ToString();

            //Nếu là nhân viên đi ca 3 (26 ngày công và có thể đăng ký nghỉ ngày CN) thì hiện checkbox cho đăng ký phép CN
            if (getWorkDay(Session["EmployeeID"].ToString()).ToString() == "26")
            {
                chkSunday.Visible = true;
            }
            else
            {
                chkSunday.Visible = false;
            }

        }


        #region Kiểm tra xem nhân viên đã ký hđlđ chưa
        private bool havingContract(string EmployeeID, DateTime View)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Select * from dbo.udf_GetMax_Contract(@thamso) Where EmployeeID=@EmpID AND ContractTypeID In (Select ContractTypeID from tblRef_ContractType )";
                provider.ParameterCollection = new string[] { "@thamso", "@EmpID" };
                provider.ValueCollection = new object[] { View, EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string EmpID = dt.Rows[i]["EmployeeID"].ToString();
                        if (String.Compare(EmpID, EmployeeID, true) == 0)
                        {
                            validate = true;
                            break;
                        }
                    }
                }
            }
            catch { }
            provider.CloseConnection();
            return validate;
        }
        #endregion
        #region Kiểm tra xem nhân viên dang ky hđlđ thu viec
        private bool ProbationContract(string EmployeeID)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Select * from dbo.udf_GetMax_Contract(getdate()) Where EmployeeID=@EmpID AND ContractTypeID In (Select ContractTypeID from tblRef_ContractType ) AND GroupID = 3";
                provider.ParameterCollection = new string[] { "@EmpID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string EmpID = dt.Rows[i]["EmployeeID"].ToString();
                        if (String.Compare(EmpID, EmployeeID, true) == 0)
                        {
                            validate = true;
                            break;
                        }
                    }
                }
            }
            catch { }
            provider.CloseConnection();
            return validate;
        }
        #endregion
        double getWorkDay(string employeeid)
        {
            double returnValue = 26;
            System.Data.DataTable dt;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select Workday from tblEmpWorkday where EmployeeID = @EmployeeID";
                sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
                sqlProvider.ValueCollection = new object[] { employeeid };
                dt = sqlProvider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    object o = dt.Rows[0]["Workday"];
                    if (!o.ToString().Equals(""))
                    {
                        returnValue = (double)dt.Rows[0]["Workday"];
                    }
                }
            }
            catch { returnValue = 26; }
            sqlProvider.CloseConnection();
            return returnValue;
        }

        bool Validate_ForeWarn(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            double SoNgayNghi = 0;
            double SoNgayBao = 0;
            SoNgayNghi = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            SoNgayBao = (fromDate - DateTime.Today).TotalDays - 1;

            if (SoNgayNghi <= 1)
            {
                if (SoNgayBao < 1)
                {
                    validate = false;
                }
            }
            else
            {
                if (SoNgayNghi <= 3)
                {
                    if (SoNgayBao < 3)
                    {
                        validate = false;
                    }
                }
                else
                {
                    if (SoNgayBao < 6)
                    {
                        validate = false;
                    }
                }
            }

            return validate;
        }

        bool Validate_ForeWarn_MR(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            double SoNgayBao = 0;
            SoNgayBao = (fromDate - DateTime.Today).TotalDays - 1;
            if (SoNgayBao < 3)
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_ForeWarn_UP(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            double SoNgayNghi = 0;
            double SoNgayBao = 0;
            SoNgayNghi = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            SoNgayBao = (fromDate - DateTime.Today).TotalDays - 1;
            if (SoNgayNghi >= 1)
            {
                if (SoNgayBao < 3)
                {
                    validate = false;
                }
            }
            return validate;
        }

        bool Validate_ForeWarn_RegisterDate(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            double SoNgayBao = 0;
            SoNgayBao = (fromDate - DateTime.Today).TotalDays - 1;
            if (SoNgayBao < 5)
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_FL(DateTime fromDate, DateTime toDate, string perTimeID, String employeeID)
        {
            bool validate = false;
            if (string.Compare("B2", drLoainghi.Value.ToString(), true) == 0 && CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID) <= 3)
            {
                validate = true;
            }
            return validate;
        }

        bool Validate_MR1(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi cuoi ban than trong nam
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            if (count + count_current > 3)
                validate = false;

            return validate;
        }

        bool Validate_MR2(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            if (String.Compare(drLoainghi.Value.ToString(), "B1_1", true) == 0 && CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID) > 1)
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_SL(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi om ban than trong nam
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            if (count + count_current > 30)
                validate = false;

            return validate;
        }

        private bool Validate_SL_A5(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi phep di thi trong nam
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            if (count + count_current > 5)
                validate = false;

            return validate;
        }

        private bool Validate_SL_A(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi duong suc
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            switch (drLoainghi.Value.ToString().ToUpper())
            {
                case "SL_A":
                    if (count_current > 5)
                        validate = false;
                    break;

                case "SL_A1":
                    if (count_current > 7)
                        validate = false;
                    break;

                case "SL_A2":
                    if (count + count_current > 5)
                        validate = false;
                    break;

                case "SL_A3":
                    if (count + count_current > 7)
                        validate = false;
                    break;

                case "SL_A4":
                    if (count + count_current > 10)
                        validate = false;
                    break;

                default:
                    break;
            }
            return validate;
        }

        private bool Validate_SL_A_After_SL(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            double count = 0;
            {
                // Tim lan nghi om (SL) gan nhat
                Nullable<DateTime> lastToDate = null;
                lastToDate = getLastSickLeave(employeeID);
                if (lastToDate == null)
                    validate = false;
                else
                {
                    // Tinh khoan thoi gian : lastToDate - Todate
                    count = TotalDay(lastToDate.Value.AddDays(1), toDate);
                    if (count > 30)
                        validate = false;
                }
            }
            return validate;
        }

        private bool Validate_WL(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi cham vo sinh
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            switch (drLoainghi.Value.ToString().ToUpper())
            {
                case "WL_5":
                    if (count + count_current > 5)
                        validate = false;
                    break;

                case "WL_7":
                    if (count + count_current > 7)
                        validate = false;
                    break;

                case "WL_10":
                    if (count + count_current > 10)
                        validate = false;
                    break;

                case "WL_14":
                    if (count + count_current > 14)
                        validate = false;
                    break;

                default:
                    break;
            }
            return validate;
        }

        private DateTime? getLastSickLeave(string employeeID)
        {
            DateTime? value = null;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * From (";
            sqlProvider.CommandText += "Select Todate from tblWebData Where EmployeeID = @EmployeeID and [LeaveID]=@Type And (FinalStatus='a' and HRCheckingStatus is null) ";
            sqlProvider.CommandText += " Union ALL ";
            sqlProvider.CommandText += "Select ToDate from tblEmpDayOff Where EmployeeID = @EmployeeID and [LeaveID]=@Type";
            sqlProvider.CommandText += ") tmp ";
            sqlProvider.CommandText += "Order by Todate desc;";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@Type" };
            sqlProvider.ValueCollection = new object[] { employeeID, "SL" };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = Convert.ToDateTime(dt.Rows[0]["ToDate"]);
            }
            return value;
        }

        private bool Validate_ME(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi kham thai
            float count = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            if (count > 1)
                validate = false;

            return validate;
        }

        private bool Validate_SL_A6(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            // so ngay nghi om tối đa 2 ngày/ năm (không hỏi Giấy nghỉ hưởng BHXH)
            float count = (float)getTotalDayOf_ByType(employeeID, drLoainghi.Value.ToString(), fromDate.Year);
            float count_current = CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
            if (count + count_current > 2)
                validate = false;

            return validate;
        }

        bool Validate_RemainLeave(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly

            if (!havingContract(employeeID, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)))
            {
                validate = true;
            }
            else
            {
                double result = Convert.ToDouble(txtPhepTon.Text) - CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);

                // Tru phep nam da dang ky & cho duyet
                result = result - Convert.ToDouble(getTotalDayOf_WaitSyn(employeeID));
                if (result < 0)
                {
                    validate = false;
                }
            }
            return validate;
        }

        bool Validate_CL(string LeaveID)
        {
            bool validate = true;
            /* Khong xet th nghỉ bù
            double phepbu = 0;
            double tongngay = 0;

            try
            {
                phepbu = Convert.ToDouble(txtPhepbu.Value);
                tongngay = Convert.ToDouble(txtTongNgay.Value);
                double result = phepbu - tongngay;

                if (string.Compare(LeaveID, "CL") == 0)
                {
                    if (result < 0)
                    {
                        validate = false;
                    }
                }
            }
            catch { }
             */
            return validate;
        }

        bool Validate_RangeDate(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            //Code xu ly
            TimeSpan ts = toDate - fromDate;
            int i = (int)ts.TotalDays;
            if (i < 0)
            {
                validate = false;
            }
            return validate;
        }
        bool Validate_Back2Week(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            string leaveID = drLoainghi.Value.ToString();
            string compare = (leaveID.Substring(0, 2)).ToLower();

            if (compare.Equals("sl") || compare.Equals("fl"))
            {
                validate = true;
            }
            else
            {
                //Code xu ly
                TimeSpan ts = DateTime.Today - fromDate;
                TimeSpan ts1 = DateTime.Today - toDate;
                int i = (int)ts.TotalDays;
                int j = (int)ts1.TotalDays;
                if (i > 15 || j > 15)
                {
                    validate = false;
                }
            }
            return validate;
        }

        bool Validate_OldDate(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            string leaveID = drLoainghi.Value.ToString();
            string compare = (leaveID.Substring(0, 2)).ToLower();

            if (compare.Equals("sl") || compare.Equals("fl"))
            {
                validate = true;
            }
            else
            {
                //Code xu ly
                TimeSpan ts = DateTime.Today - fromDate;
                TimeSpan ts1 = DateTime.Today - toDate;
                int i = (int)ts.TotalDays;
                int j = (int)ts1.TotalDays;
                if (i > 0 || j > 0)
                {
                    validate = false;
                }
            }
            return validate;
        }

        bool Validate_DuplicateDate(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID, string leaveID)
        {
            bool validate = true;
            //Code xu ly
            validate = ValidateLeaveDateRange(employeeID, perTimeID, leaveID, fromDate, toDate);
            return validate;
        }

        //Xét trường hợp nghỉ bù không được trước ngày đăng ký làm thêm cũ nhất
        bool Is_CL_After_CLOT10(string EmployeeID, DateTime regCLEndtDate)
        {
            bool validate = true;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select StartDate from tblWebdata where EmployeeID = @EmployeeID and (FinalStatus = 'w' or FinalStatus ='A' or FinalStatus ='a') and LeaveID = 'CL_OT10' order by StartDate asc";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                DateTime StartDate = (DateTime)dt.Rows[0]["StartDate"];
                //Ngày nghỉ bù trước ngày làm thêm
                if (DateTime.Compare(StartDate, regCLEndtDate) > 0)
                {
                    validate = false;
                }
            }
            provider.CloseConnection();
            return validate;
        }

        bool Validate_DuplicateDate_CL(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID, string leaveID)
        {
            bool validate = true;
            //Code xu ly
            if (String.Compare(leaveID, "CL", true) == 0)
            {
                validate = ValidateLeaveDateRange(employeeID, perTimeID, "CL_OT10", fromDate, toDate);
            }

            if (String.Compare(leaveID, "CL_OT10", true) == 0)
            {
                validate = ValidateLeaveDateRange(employeeID, perTimeID, "CL", fromDate, toDate);
            }
            return validate;
        }

        public bool ValidateLeaveDateRange(string EmployeeID, string PerTimeID, string LeaveID, DateTime regStartDate, DateTime regToDate)
        {
            bool validate = true;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblWebData Where EmployeeID = @EmployeeID and (FinalStatus = 'w' or FinalStatus ='A' or FinalStatus ='a') and LeaveID = @LeaveID";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@LeaveID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID, LeaveID };
            DataTable dt = sqlProvider.GetDataTable();
            DateTime existingStartDate;
            DateTime existingToDate;
            string existingPerTimeID;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    existingStartDate = (DateTime)dt.Rows[i]["StartDate"];
                    existingToDate = (DateTime)dt.Rows[i]["ToDate"];
                    existingPerTimeID = dt.Rows[i]["PerTimeID"].ToString();

                    //Xét trường hợp ngày đăng ký đang có là 1 ngày
                    if (DateTime.Compare(existingStartDate, existingToDate) == 0)
                    {
                        //Nếu ngày đăng ký mới là 1 ngày
                        if (DateTime.Compare(regStartDate, regToDate) == 0)
                        {
                            //Nếu ngày đăng ký mới trùng với ngày đăng ký đang có
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0)
                            {
                                //Nếu chế độ nghỉ là cả ngày
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                //Ngược lại nếu chế độ nghỉ nửa ngày (đăng ký mới) trùng với chế độ nghỉ nửa ngày (đăng ký đang có)
                                else if (existingPerTimeID.Equals(PerTimeID) || PerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }
                        else//Ngày đăng ký mới nhiều hơn 1 ngày
                        {
                            //Trường hợp ngày bắt đầu hoặc kết thúc (đăng ký mới) trùng với ngày đăng ký đang có
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0 || DateTime.Compare(regToDate, existingStartDate) == 0)
                            {
                                //Nếu chế độ nghỉ đang có là cả ngày
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                //Nếu chế độ nghỉ là nửa ngày (đăng ký mới) trùng với chế độ nghỉ là nửa ngày (đăng ký đang có)
                                else if (existingPerTimeID.Equals(PerTimeID) || PerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                    }
                    else//Ngày đăng ký đang có nhiều hơn 1 ngày
                    {
                        //Nếu ngày đăng ký mới là 1 ngày
                        if (DateTime.Compare(regStartDate, regToDate) == 0)
                        {
                            //Nếu ngày đăng ký mới trùng với ngày bắt đầu hoặc ngày kết thúc của đăng ký hiện đang có
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0 || DateTime.Compare(regStartDate, existingToDate) == 0)
                            {
                                //Nếu chế độ nghỉ là cả ngày
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                //Nếu chế độ nghỉ nửa ngày trùng nhau
                                else if (existingPerTimeID.Equals(PerTimeID) || PerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                            else//Ngày đăng ký mới không trùng với ngày bắt đầu hoặc kết thúc của ngày đăng ký đang có
                            {
                                //Tạo đối tượng so sánh cho ngày đăng ký đang có
                                DateTimeRange dtRange = new DateTimeRange();
                                dtRange.Start = existingStartDate;
                                dtRange.End = existingToDate;

                                //Tạo đối tượng so sánh cho ngày đăng ký mới
                                DateTimeRange input = new DateTimeRange();
                                input.Start = regStartDate;
                                input.End = regToDate;

                                //Trường hợp ngày đăng ký mới rơi vào bên trong dãy ngày đăng ký đang có
                                if (dtRange.Intersects(input))
                                {
                                    //Nếu chế độ nghỉ là cả ngày
                                    if (existingPerTimeID.Equals("0"))
                                    {
                                        validate = false;
                                        break;
                                    }
                                    //Nếu trùng chế độ nghỉ nửa ngày
                                    else if (existingPerTimeID.Equals(PerTimeID) || PerTimeID.Equals("0"))
                                    {
                                        validate = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else //Nếu ngày đăng ký mới nhiều hơn 1 ngày
                        {
                            //Tạo đối tượng so sánh cho dãy ngày đăng ký đang có
                            DateTimeRange dtRange = new DateTimeRange();
                            dtRange.Start = existingStartDate;
                            dtRange.End = existingToDate;

                            //Tạo đối tượng so sánh cho dãng ngày đăng ký mới
                            DateTimeRange input = new DateTimeRange();
                            input.Start = regStartDate;
                            input.End = regToDate;

                            //Trường hợp giao thoa
                            if (dtRange.Intersects(input))
                            {
                                //Nếu chế độ đăng ký đang có là cả ngày
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                //Nếu trùng chế độ nghỉ nửa ngày
                                else if (existingPerTimeID.Equals(PerTimeID) || PerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }
                    }
                }//Kết thúc For loop
            }
            sqlProvider.CloseConnection();
            return validate;
        }

        // Không cho đăng ký nghỉ phép qua 2 năm
        bool Validate_Range(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            //Code xu ly
            DateTime d = new DateTime(fromDate.Year, 4, 1);
            // fromDate < d  && toDate >= d
            if ((fromDate - d).Days < 0 && (toDate - d).Days >= 0)
            {
                validate = false;
            }
            return validate;
        }

        // Không cho đăng ký nghỉ phép Không lương khi chưa hết phép năm
        bool Validate_UP(string employeeID, out double dayRemain)
        {
            try
            {
                bool validate = true;
                //Code xu ly
                //double phepTon = CalculateALRemain(employeeID);
                //double phepChoDongBo = getTotalDayOf_WaitSyn(employeeID);
                //dayRemain = (double.Parse(HiddenField1.Value.ToString())) - phepTon + phepChoDongBo;
                dayRemain = CalculateALRemain(employeeID);
                if (dayRemain > 0)
                {
                    validate = false;
                }
                return validate;
            }
            catch
            {
                dayRemain = 0;
                return false;
            }
        }

        float CalculateLeaveDays(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            float returnValue = 0;
            double result = 0;
            double workday = getWorkDay(employeeID);
            string leaveid = drLoainghi.Value.ToString();

            //if (workday == 22 || leaveid.ToUpper() == "AL") //Nghỉ làm thứ 7
            switch (leaveid.ToUpper())
            {
                //Trừ T7, CN, lễ
                case "AL": // Phép năm
                case "B1": // Nghỉ cưới hỏi - bản thân: 3 ngày
                case "B1_1": // Nghỉ cưới hỏi - con: 1 ngày
                case "B2": // Nghỉ tang lễ - vợ, chồng, con, anh chị em (ruột), cha mẹ (vợ/ chồng): 3 ngày
                case "SL_A6": // Nghỉ ốm dưới 3 ngày/ năm
                case "ME": // Khám thai
                case "SL_A5": // Nghỉ phép đi Thi (học do Cty duyệt): 5 ngày/ năm

                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate) - TotalHoliday(fromDate, fromDate) - TotalSaturday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate)) / 2;
                        }
                    }
                    break;

                //Trừ CN, lễ
                case "CS": // Nghỉ con ốm
                case "SL": // Nghỉ ốm
                case "WL_5": // Nghỉ vợ sinh - sinh thường: 5 ngày
                case "WL_7": // "Nghỉ vợ sinh - sinh con phải phẩu thuật/Sinh con dưới 32 tuần tuổi: 7 ngày"
                case "WL_10": // Nghỉ vợ sinh - Sinh đôi: 10 ngày
                case "WL_14": // Nghỉ vợ sinh - Sinh đôi phải phẩu thuật: 14 ngày

                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate) - TotalHoliday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate)) / 2;
                        }
                    }
                    break;

                //Tính suốt quá trình
                case "SL_L": //Bản thân ốm dài ngày (theo danh mục bệnh dài ngày)
                case "ML": //Thai sản
                case "SB": //Sẩy thai, nạo, hút, thai chêt lưu
                case "SB_7": // Thực hiện các biện pháp tránh thai: đặt vòng, triệt sản
                case "SL_A": // Dưỡng sức sau Bệnh: 5 ngày liên tục
                case "SL_A1": // Dưỡng sức sau Bệnh (phẩu thuật): 7 ngày liên tục 
                case "SL_A2": // Dưỡng sức sau Sinh: 5 ngày liên tục
                case "SL_A3": // Dưỡng sức sau Sinh (phẩu thuật): 7 ngày liên tục 
                case "SL_A4": // Dưỡng sức sau Sinh (sinh đôi): 10 ngày liên tục 

                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate)) / 2;
                        }

                    }
                    break;

                //Trừ CN
                case "UL": // Nghỉ không lương
                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate)) / 2;
                        }
                    }
                    break;

                default:
                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate) - TotalHoliday(fromDate, fromDate) - TotalSaturday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate)) / 2;
                        }
                    }
                    break;
            }

            ////Trường hợp đăng ký làm thêm nghỉ bù (1-1)
            //if (String.Compare(leaveid, "CL_OT10", true) == 0)
            //{
            //    result = TotalDay(fromDate, toDate);
            //}

            returnValue = (float)result;
            return returnValue;
        }

        #region Old
        /*
        float CalculateLeaveDays(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            float returnValue = 0;
            double result = 0;
            double workday = getWorkDay(employeeID);
            string leaveid = drLoainghi.Value.ToString();

            if (workday == 22 || leaveid.ToUpper() == "AL") //Nghỉ làm thứ 7
            {
                if (perTimeID.Equals("0"))
                {
                    result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate);
                }
                else
                {
                    if (perTimeID.Equals("3"))
                    {
                        result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate) - TotalHoliday(fromDate, fromDate) - TotalSaturday(fromDate, fromDate);
                    }
                    else
                    {
                        result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate)) / 2;
                    }

                }
            }
            else
            if (workday == 26)//Đi làm thứ 7, không tính chủ nhật
            {

                if (chkSunday.Checked)
                {
                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalHoliday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalHoliday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalHoliday(fromDate, toDate)) / 2;
                        }
                    }
                }
                else
                {
                    if (perTimeID.Equals("0"))
                    {
                        result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate);
                    }
                    else
                    {
                        if (perTimeID.Equals("3"))
                        {
                            result = TotalDay(fromDate, fromDate) - TotalSunday(fromDate, fromDate) - TotalHoliday(fromDate, fromDate);
                        }
                        else
                        {
                            result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate)) / 2;
                        }
                    }
                }

            }
            else if (leaveid.ToUpper() == "SL_L") // tính cả chủ nhật + lễ
            {

            }

            ////Trường hợp đăng ký làm thêm nghỉ bù (1-1)
            //if (String.Compare(leaveid, "CL_OT10", true) == 0)
            //{
            //    result = TotalDay(fromDate, toDate);
            //}

            returnValue = (float)result;
            return returnValue;
        }
         */
        #endregion
        double TotalDay(DateTime frDate, DateTime toDate)
        {
            double returnValue = 0;
            TimeSpan ts = toDate - frDate;
            returnValue = ts.TotalDays + 1;
            return returnValue;
        }

        double TotalSunday(DateTime frDate, DateTime toDate)
        {
            double returnValue = 0;
            returnValue = (1 + toDate.Subtract(frDate).Days + (6 + (int)frDate.DayOfWeek) % 7) / 7;
            return returnValue;
        }

        double TotalSaturday(DateTime frDate, DateTime toDate)
        {
            double returnValue = 0;
            TimeSpan ts = toDate - frDate;
            int days = ts.Days;
            for (int i = 0; i <= days; i++)
            {
                DateTime testDate = frDate.AddDays(i);
                if (testDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    returnValue++;
                }
            }
            return returnValue;
        }

        double TotalHoliday(DateTime frDate, DateTime toDate)
        {
            double returnValue = 0;
            int days = (int)toDate.Subtract(frDate).TotalDays + 1;
            for (int i = 0; i < days; i++)
            {
                if (IsHoliday(frDate.AddDays(i)))
                {
                    returnValue++;
                }
            }

            return returnValue;
        }

        public bool IsHoliday(DateTime date)
        {
            bool holiday = false;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblHoliday where Dating = @Dating";
            sqlProvider.ParameterCollection = new string[] { "@Dating" };
            sqlProvider.ValueCollection = new object[] { date };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                holiday = true;
            }
            sqlProvider.CloseConnection();
            return holiday;
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            string duyet = e.GetValue("FinalStatus").ToString();
            if (duyet.Equals("c") || duyet.Equals("C"))
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            if (duyet.Equals("a") || duyet.Equals("A"))
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;

            }

            string warning = e.GetValue("Warning").ToString();
            if (String.Compare(warning, "True", true) == 0)
            {
                e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }

        public bool IsDeleted(string id)
        {
            bool returnValue = true;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblWebData where id = @id";
            sqlProvider.ParameterCollection = new string[] { "@id" };
            sqlProvider.ValueCollection = new object[] { id };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                string approval = dt.Rows[0]["FinalStatus"].ToString();
                string statusL1 = dt.Rows[0]["ApprovingStatus_L1"].ToString();
                string statusL2 = dt.Rows[0]["ApprovingStatus_L2"].ToString();
                string statusL3 = dt.Rows[0]["ApprovingStatus_L3"].ToString();
                if (string.Compare(approval, "w", true) != 0)
                {
                    returnValue = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(statusL1) == false || string.IsNullOrWhiteSpace(statusL2) == false || string.IsNullOrWhiteSpace(statusL3) == false)
                    {
                        returnValue = false;
                    }
                }
            }
            sqlProvider.CloseConnection();
            return returnValue;
        }
        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            if (!IsDeleted(ID))
            {
                e.Cancel = true;
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        ASPxGridView1.SettingsText.Title = "Không thể xóa lượt đăng ký đã được xử lý.";
                    }
                    else
                    {
                        ASPxGridView1.SettingsText.Title = "This record can not be deleted. It's on processing.";
                    }
                }
                else
                {
                    ASPxGridView1.SettingsText.Title = "Không thể xóa lượt đăng ký đã được xử lý.";
                }
            }
        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "FinalStatus")
            {
                return;
            }
            else
            {
                if (e.Value.Equals("w") || e.Value.Equals("W"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            e.DisplayText = "Chờ duyệt";
                        }
                        else
                        {
                            e.DisplayText = "Waiting";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Chờ duyệt";
                    }
                }

                if (e.Value.Equals("a") || e.Value.Equals("A"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            e.DisplayText = "Duyệt";
                        }
                        else
                        {
                            e.DisplayText = "Approved";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Duyệt";
                    }
                }

                if (e.Value.Equals("c") || e.Value.Equals("C"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            e.DisplayText = "Không duyệt";
                        }
                        else
                        {
                            e.DisplayText = "Cacel";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Không duyệt";
                    }
                }
            }
        }
        protected void ASPxGridView1_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                if (!havingContract(Session["EmployeeID"].ToString(), DateTime.Today))
                {
                    ((ASPxGridView)sender).JSProperties["cpDeleted"] = "";
                    ((ASPxGridView)sender).JSProperties["cpDeletedCL"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                }
                else
                    if (ProbationContract(Session["EmployeeID"].ToString()))
                    {
                        ((ASPxGridView)sender).JSProperties["cpDeleted"] = "";
                        ((ASPxGridView)sender).JSProperties["cpDeletedCL"] = "";
                    }
                    else
                    {
                        ((ASPxGridView)sender).JSProperties["cpDeleted"] = CalculateALRemain(Session["EmployeeID"].ToString()).ToString();
                        ((ASPxGridView)sender).JSProperties["cpDeletedCL"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                    }
            }
            ASPxGridView1.SettingsText.Title = "";
        }



        public float CalculateALRemain(string EmployeeID)
        {
            float value = 0;
            ArrayList arr = new ArrayList();
            //DateTime todate = new DateTime(DateTime.Today.Year,12,31);
            DateTime todate = getToDate(EmployeeID);
            DateTime fromdate = new DateTime(DateTime.Today.Year, 1, 1);

            //float tempValue = (float)(getALRemainForEmployee(fromdate, todate, EmployeeID) - getTotalDayOfAL(EmployeeID));
            arr = getALRemainForEmployee(fromdate, todate, EmployeeID);
            object ALRemain = arr[3];

            object ALInitial = arr[0];
            object ALInyear = arr[1];
            object ALUsed = arr[2];
            object AlUsed_BeforeCut = arr[4];

            double dblALInitial = 0, dblALInyear = 0, dblALUsed = 0, dblAlUsed_BeforeCut = 0;
            double flALRemain = 0;

            if (!ALInitial.ToString().Equals(""))
                dblALInitial = Convert.ToDouble(ALInitial);
            if (!ALInyear.ToString().Equals(""))
                dblALInyear = Convert.ToDouble(ALInyear);
            if (!ALUsed.ToString().Equals(""))
                dblALUsed = Convert.ToDouble(ALUsed);
            if (!AlUsed_BeforeCut.ToString().Equals(""))
                dblAlUsed_BeforeCut = Convert.ToDouble(AlUsed_BeforeCut);
            if (!ALRemain.ToString().Equals(""))
                flALRemain = Convert.ToDouble(ALRemain);

            if (DateTime.Today.Subtract(new DateTime(DateTime.Today.Year, 4, 1)).Days >= 0)
            {
                txtTotalAL.Text = dblALInyear.ToString();
                HiddenField1.Value = dblALInyear.ToString();

                //flALRemain = (float)dblALInyear - (float)dblALUsed + (float)dblAlUsed_BeforeCut;
            }
            else
            {
                if (dblALInitial == 0)
                    txtTotalAL.Text = dblALInyear.ToString();
                else
                    txtTotalAL.Text = dblALInitial.ToString() + " + " + dblALInyear.ToString() + " = " + (dblALInitial + dblALInyear).ToString();
                HiddenField1.Value = (dblALInitial + dblALInyear).ToString();

                //flALRemain = (float)dblALInitial + (float)dblALInyear - (float)dblALUsed;
            }
            //txtAL.Text = dblALUsed.ToString();
            //float ALapproval = CalculateALWaitApprove(EmployeeID);

            if (!ALRemain.ToString().Equals(""))
            {
                float tmpvalue = (float)(flALRemain - getTotalDayOfAL(EmployeeID));

                if (tmpvalue > 0)
                    value = tmpvalue;
            }
            // phep da nghi sau khi cong phep da duyet
            txtAL.Text = (dblALUsed + getTotalDayOfAL(EmployeeID)).ToString();
            return value;
        }
        /*
                public float CalculateALWaitApprove(string EmployeeID)
                {
                    float value = 0;
                    ArrayList arr = new ArrayList();
                    //DateTime todate = new DateTime(DateTime.Today.Year,12,31);
                    DateTime todate = getToDate(EmployeeID);
                    DateTime fromdate = new DateTime(DateTime.Today.Year, 1, 1);

                    //float tempValue = (float)(getALRemainForEmployee(fromdate, todate, EmployeeID) - getTotalDayOfAL(EmployeeID));
                    arr = getALRemainForEmployee(fromdate, todate, EmployeeID);
                    object ALRemain = arr[3];
                    if (!ALRemain.ToString().Equals(""))
                    {
                        double dblALRemain = Convert.ToDouble(ALRemain);
                        float flALRemain = (float)dblALRemain;
                        float tmpvalue = (float)(flALRemain - getTotalDayOfAL(EmployeeID));

                        if (tmpvalue > 0)
                            value = tmpvalue;
                    }

                    object ALInitial = arr[0];
                    object ALInyear = arr[1];
                    object ALUsed = arr[2];

                    double dblALInitial = 0, dblALInyear = 0, dblALUsed = 0;

                    if (!ALInitial.ToString().Equals(""))
                        dblALInitial = Convert.ToDouble(ALInitial);
                    if (!ALInyear.ToString().Equals(""))
                        dblALInyear = Convert.ToDouble(ALInyear);
                    if (!ALUsed.ToString().Equals(""))
                        dblALUsed = Convert.ToDouble(ALUsed);

                    txtTotalAL.Text = (dblALInitial + dblALInyear).ToString();
                    txtAL.Text = dblALUsed.ToString();

                    //if (tempValue > 0)
                    //{
                    //    value = tempValue;
                    //}
                    return value;
                }
        */
        public ArrayList getALRemainForEmployee(DateTime FromDate, DateTime ToDate, string EmployeeID)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());

            //Gọi sp_View_EmpALRemain_Online của Tân Đức
            sqlProvider.CommandText = "sp_View_EmpALRemain_Online";
            //sqlProvider.CommandText = "PER_sp_Rpt_LeaveReport";
            sqlProvider.CommandType = CommandType.StoredProcedure;
            DateTime fromDate = new DateTime(ToDate.Year, 1, 1);
            sqlProvider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID", "@UserID" };
            sqlProvider.ValueCollection = new object[] { fromDate, ToDate, EmployeeID, "LeaveReg" + Session["EmployeeID"].ToString() };
            sqlProvider.ExecuteNonQuery();


            //Lay phep ton tu table tbl_View_EmpALRemain_Online            
            sqlProvider.CommandText = "Select ALInitial, ALInyear, ALUsed, ALRemain, AlUsed_BeforeCut from tbl_View_EmpALRemain_Online where EmployeeID = @EmployeeID and ComputerName = @ComputerName";
            sqlProvider.CommandType = CommandType.Text;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@ComputerName" };
            sqlProvider.ValueCollection = new object[] { EmployeeID, "LeaveReg" + EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                //if (dt.Rows[0]["ALRemain"].ToString() != "")
                //{

                //    value = (double)dt.Rows[0]["ALRemain"];
                //}
                //else { value = 0; }

                arr.Add(dt.Rows[0]["ALInitial"]);
                arr.Add(dt.Rows[0]["ALInyear"]);
                arr.Add(dt.Rows[0]["ALUsed"]);
                arr.Add(dt.Rows[0]["ALRemain"]);

                arr.Add(dt.Rows[0]["AlUsed_BeforeCut"]);
            }
            sqlProvider.CloseConnection();
            return arr;
        }


        //Tính tổng lượt phép năm chưa đồng bộ
        public double getTotalDayOfAL(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and FinalStatus='a' and LeaveID='AL' and HRCheckingStatus is null";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    value += Convert.ToDouble(dt.Rows[i]["TotalDays"]);
                }
            }
            return value;
        }

        //Tính tổng lượt phép chưa đồng bộ
        public double getTotalDayOf_WaitSyn(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and FinalStatus='w' and LeaveID='AL'";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    value += Convert.ToDouble(dt.Rows[i]["TotalDays"]);
                }
            }
            return value;
        }

        //Tính tổng lượt phép đã nghỉ & đăng ký theo loại nghỉ trong năm
        public double getTotalDayOf_ByType(string EmployeeID, string type, int year)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and [LeaveID]=@Type And Year(StartDate)=@Year And (FinalStatus='w' OR (FinalStatus='a' and HRCheckingStatus is null)) ";
            sqlProvider.CommandText += " Union ALL ";
            sqlProvider.CommandText += "Select 'TotalDays'=Days from tblEmpDayOff Where EmployeeID = @EmployeeID and [LeaveID]=@Type And Year(FromDate)=@Year;";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@Type", "@Year" };
            sqlProvider.ValueCollection = new object[] { EmployeeID, type, year };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    value += Convert.ToDouble(dt.Rows[i]["TotalDays"]);
                }
            }
            return value;
        }

        //Tính tổng lượt phép nghỉ bù chưa đồng bộ
        public float getTotalDayOfCL(string EmployeeID)
        {
            float value = 0;
            double double_value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and (FinalStatus='w' or FinalStatus='a') and LeaveID='CL' and HRCheckingStatus is null";
                sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
                sqlProvider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = sqlProvider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!dt.Rows[i]["TotalDays"].ToString().Equals(""))
                        {
                            double_value += (double)dt.Rows[i]["TotalDays"];
                        }
                    }
                    value = (float)double_value;
                }
            }
            catch
            {
                value = 0;
            }
            sqlProvider.CloseConnection();
            return value;
        }

        //Tổng lượt phép đã đồng bộ theo thời gian, loại nghỉ và mã nhân viên
        public float getTotalDaysOffByLeaveID(DateTime FromDate, DateTime ToDate, string LeaveID, string EmployeeID)
        {
            double temp_returnValue = 0;
            float returnValue = 0;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "select [Days] from tblEmpDayOff where [LeaveID] = @LeaveID and [EmployeeID] = @EmpID and [FromDate] >= @BeginDate and [ToDate] <= @EndDate";
                provider.ParameterCollection = new string[] { "@BeginDate", "@EndDate", "@EmpID", "@LeaveID" };
                provider.ValueCollection = new object[] { FromDate, ToDate, EmployeeID, LeaveID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (!dt.Rows[i]["Days"].ToString().Equals(""))
                        {
                            temp_returnValue += (double)dt.Rows[i]["Days"];
                        }

                    }
                }
                returnValue = (float)temp_returnValue;
            }
            catch { returnValue = 0; }
            provider.CloseConnection();
            return returnValue;
        }

        public float CalCurrentCompensationLeave(DateTime CurrentDate, string EmployeeID)
        {
            float value = 0;
            float CL_OT10_DaysOff = 0;
            float CL_DaysOff = 0;
            float CL = 0;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                DateTime FromDate = new DateTime(CurrentDate.Year, 1, 1);
                CL_OT10_DaysOff = getTotalDaysOffByLeaveID(FromDate, CurrentDate, "CL_OT10", EmployeeID);
                CL_DaysOff = getTotalDaysOffByLeaveID(FromDate, CurrentDate, "CL", EmployeeID);
                CL = getTotalDayOfCL(EmployeeID);
                value = CL_OT10_DaysOff - CL_DaysOff - CL;
                //if (CL_DaysOff == CL)
                //{
                //    value = CL_OT10_DaysOff - CL_DaysOff;
                //}
                //else
                //{
                //    value = CL_OT10_DaysOff - CL;
                //}

            }
            catch { value = 0; }
            provider.CloseConnection();
            return value;
        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ID"] = ((DevExpress.Web.ASPxGridView)sender).GetMasterRowKeyValue();
        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                string NewEmployeeID = GetNewEmployeeID(Session["EmployeeID"]);
                if (NewEmployeeID != "")
                {
                    // Show warning
                    string message = "";
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            message = "alert('Bạn đang đăng nhập bằng mã cũ. Hãy đăng nhập bằng mã: " + NewEmployeeID.ToUpper() + " để đăng ký nghỉ phép')";
                        }
                        else
                        {
                            message = "alert('You are login by old code. Please user new EmployeeID: " + NewEmployeeID.ToUpper() + " to registration annual leave')";
                        }
                    }
                    else
                    {
                        message = "alert('Bạn đang đăng nhập bằng mã cũ. Hãy đăng nhập bằng mã: " + NewEmployeeID.ToUpper() + " để đăng ký nghỉ phép')";
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    return;
                }
                //Code insert data into database
                string EmpID = Session["EmployeeID"].ToString();
                DateTime regDate = DateTime.Today;
                string leaveID = drLoainghi.Value.ToString();
                DateTime startDate = (DateTime)ddlTuNgay.Value;
                DateTime toDate = (DateTime)ddlDenNgay.Value;
                string perTimeID = drchedonghi.Value.ToString();
                string leaveReason = txtLydo.Text;
                string employeeID = Session["EmployeeID"].ToString();
                int checkNum = 0;
                int MaxCheckNum = 0;
                int level = 0;
                float totalDay = CalculateLeaveDays(startDate, toDate, perTimeID, employeeID);
                int mailToL1 = 1;

                tblEmpManagerLevel o = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                string managerID_L1 = o.getManagerID(EmpID, "1").ToString();
                string managerID_L2 = o.getManagerID(EmpID, "2").ToString();
                string managerID_L3 = o.getManagerID(EmpID, "3").ToString();


                //Tính số cấp duyệt thực tế
                //if (String.IsNullOrEmpty(managerID_L1) == false || String.IsNullOrWhiteSpace(managerID_L1) == false)
                //{
                //    MaxCheckNum++;
                //}

                //if (String.IsNullOrEmpty(managerID_L2) == false || String.IsNullOrWhiteSpace(managerID_L2) == false)
                //{
                //    MaxCheckNum++;
                //}

                //if (String.IsNullOrEmpty(managerID_L3) == false || String.IsNullOrWhiteSpace(managerID_L3) == false)
                //{
                //    MaxCheckNum++;
                //}

                MaxCheckNum = o.getManagerLevelList(employeeID).Count;


                ASPxGridView1.SettingsText.Title = "";

                #region Xét điều kiện số ngày nghỉ để xác định số cấp duyệt
                if (MaxCheckNum == 1)
                {
                    checkNum = 1;
                }
                else if (totalDay < 10 && leaveID.ToLower() == "al")
                {
                    checkNum = MaxCheckNum - 1;
                }
                else
                {
                    checkNum = MaxCheckNum;
                }
                #endregion
                #region Xét ngày báo trước
                //if (IsForeWarning_RegisterDate == false)
                //{
                //    if (Session["lang"] != null)
                //    {
                //        if (Session["lang"].ToString().Equals("vi"))
                //        {
                //            ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước 5 ngày";
                //        }
                //        else
                //        {
                //            ASPxGridView1.SettingsText.Title = "The forewaring period 5 days was be broken";
                //        }
                //    }
                //    else
                //    {
                //        ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước 5 ngày";
                //    }
                //}
                #endregion
                switch (leaveID.ToLower())
                {
                    #region Trường hợp UP
                    case "up": //Trường hợp nghỉ không lương
                        //Insert data
                        #region old code
                        /*
                        if (IsForeWarningUP == false)
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    ASPxGridView1.SettingsText.Title = "Nghỉ phép không hưởng lương phải báo trước 3 ngày";
                                }
                                else
                                {
                                    ASPxGridView1.SettingsText.Title = "The forewaring period was be broken";
                                }
                            }
                            else
                            {
                                ASPxGridView1.SettingsText.Title = "Nghỉ phép không hưởng lương phải báo trước 3 ngày";
                            }

                            if (string.Compare(leaveID, "up", true) == 0 && perTimeID.Equals("3"))
                            {
                                DateTime FromTime = DateTime.Now; //(DateTime)teditTuGio.Value;
                                DateTime ToTime = FromTime; //(DateTime)teditDenGio.Value;
                                TimeSpan ts = ToTime - FromTime;
                                float TotalHours = (float)(Math.Round(ts.TotalHours, 2));


                                DateTime FromTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, FromTime.Hour, FromTime.Minute, FromTime.Second);
                                DateTime ToTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, ToTime.Hour, ToTime.Minute, ToTime.Second);

                                //Insert data cho lượt đăng ký nghỉ theo giờ
                                InsertRecord2(EmpID, regDate, leaveID, startDate, startDate, perTimeID, leaveReason, checkNum, mailToL1, managerID_L1, managerID_L2, managerID_L3, FromTime1, ToTime1, TotalHours);
                            }
                            else
                            {
                                InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                            }
                        }
                        else
                        {
                            if (string.Compare(leaveID, "up", true) == 0 && perTimeID.Equals("3"))
                            {
                                DateTime FromTime = DateTime.Now; //(DateTime)teditTuGio.Value;
                                DateTime ToTime = FromTime; //(DateTime)teditDenGio.Value;
                                TimeSpan ts = ToTime - FromTime;
                                float TotalHours = (float)(Math.Round(ts.TotalHours, 2));

                                DateTime FromTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, FromTime.Hour, FromTime.Minute, FromTime.Second);
                                DateTime ToTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, ToTime.Hour, ToTime.Minute, ToTime.Second);

                                //Insert data cho lượt đăng ký nghỉ theo giờ
                                InsertRecord2(EmpID, regDate, leaveID, startDate, startDate, perTimeID, leaveReason, checkNum, mailToL1, managerID_L1, managerID_L2, managerID_L3, FromTime1, ToTime1, TotalHours);
                            }
                            else
                            {
                                InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                            }
                        }
                        */
                        #endregion
                        if (string.Compare(leaveID, "up", true) == 0 && perTimeID.Equals("3"))
                        {
                            DateTime FromTime = DateTime.Now; //(DateTime)teditTuGio.Value;
                            DateTime ToTime = FromTime; //(DateTime)teditDenGio.Value;
                            TimeSpan ts = ToTime - FromTime;
                            float TotalHours = (float)(Math.Round(ts.TotalHours, 2));

                            DateTime FromTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, FromTime.Hour, FromTime.Minute, FromTime.Second);
                            DateTime ToTime1 = new DateTime(startDate.Year, startDate.Month, startDate.Day, ToTime.Hour, ToTime.Minute, ToTime.Second);

                            //Insert data cho lượt đăng ký nghỉ theo giờ
                            InsertRecord2(EmpID, regDate, leaveID, startDate, startDate, perTimeID, leaveReason, checkNum, mailToL1, managerID_L1, managerID_L2, managerID_L3, FromTime1, ToTime1, TotalHours);
                        }
                        else if (IsForeWarningUP == false || IsForeWarning_RegisterDate)
                        {
                            InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        else
                        {
                            InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }

                        //Update Mail Action
                        level = getMailLevel(managerID_L1, managerID_L2, managerID_L3);
                        if (level > 0)
                        {
                            UpdateMailAction(EmpID, level);
                        }
                        break;
                    #endregion

                    #region Trường hợp AL
                    case "al"://Trường hợp phép năm
                        //Insert data
                        #region old code
                        /*
                        if (IsForeWarning == false)
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước";
                                }
                                else
                                {
                                    ASPxGridView1.SettingsText.Title = "The forewaring period was be broken";
                                }
                            }
                            else
                            {
                                ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước";
                            }

                            InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        else
                        {
                            InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        */
                        #endregion
                        if (IsForeWarning == false || IsForeWarning_RegisterDate == false)
                        {
                            InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        else
                        {
                            InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        //Update Mail Action
                        level = getMailLevel(managerID_L1, managerID_L2, managerID_L3);
                        if (level > 0)
                        {
                            UpdateMailAction(EmpID, level);
                        }
                        break;
                    #endregion

                    #region Trường hợp kết hôn MR
                    case "mr1"://Nhân viên kết hôn
                    case "mr2"://Con nhân viên kết hôn
                        //Insert data
                        #region old code
                        /*
                        if (IsForeWarningMR1 == false || IsForeWarningMR2 == false)
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước 3 ngày";
                                }
                                else
                                {
                                    ASPxGridView1.SettingsText.Title = "The forewaring period 3 days was be broken";
                                }
                            }
                            else
                            {
                                ASPxGridView1.SettingsText.Title = "Lượt đăng ký đã vi phạm thời gian báo trước 3 ngày";
                            }

                            InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        else
                        {
                            InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                         */
                        #endregion
                        if (IsForeWarningMR1 == false || IsForeWarningMR2 == false || IsForeWarning_RegisterDate == false)
                        {
                            InsertRecordWithWarning(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        else
                        {
                            InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);
                        }
                        //Update Mail Action
                        level = getMailLevel(managerID_L1, managerID_L2, managerID_L3);
                        if (level > 0)
                        {
                            UpdateMailAction(EmpID, level);
                        }
                        break;
                    #endregion

                    #region Các trường hợp khác
                    default: //Các trường hợp khác
                        //Insert data
                        InsertRecord(EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, totalDay, mailToL1, managerID_L1, managerID_L2, managerID_L3);

                        //Update Mail Action
                        level = getMailLevel(managerID_L1, managerID_L2, managerID_L3);
                        if (level > 0)
                        {
                            UpdateMailAction(EmpID, level);
                        }
                        break;
                    #endregion
                }

                this.ASPxGridView1.DataBind();
                if (!havingContract(Session["EmployeeID"].ToString(), DateTime.Today))
                {
                    txtPhepTon.Text = "";
                }
                else
                {
                    txtPhepTon.Text = CalculateALRemain(EmpID).ToString();
                }

                //Hiển thị phép bù
                //ViewState["phepbu"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                //txtPhepbu.Text = ViewState["phepbu"].ToString();

                btnNhapLai_Click(sender, e);
            }

            if (ProbationContract(Session["EmployeeID"].ToString()))
            {
                txtPhepTon.Text = "";
                txtAL.Text = "";
                txtTotalAL.Text = "";
                HiddenField1.Value = "";
                //LoaiPhepDS.SelectCommand = "SELECT LeaveID,LeaveType,LeaveType_eng FROM dbo.tblRef_LeaveType WHERE (IsOnline = 'True') AND LeaveID IN ('UL', 'B1', 'B1_1', 'B2')";
                //LoaiPhepDS.SelectCommandType = SqlDataSourceCommandType.Text;
                //LoaiPhepDS.DataBind();
            }
        }

        private void UpdateMailAction(string employeeid, int level)
        {
            string sql = "";
            switch (level)
            {
                case 1:
                    sql += "Update tblWebdata Set MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL Where EmployeeID = @EmployeeID and MailToL1 is null and FinalStatus='w'";
                    break;
                case 2:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL Where EmployeeID = @EmployeeID and MailToL2 is null and FinalStatus='w'";
                    break;
                case 3:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = NULL, MailToL3 = 1 Where EmployeeID = @EmployeeID and MailToL3 is null and FinalStatus='w'";
                    break;
            }
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { employeeid };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        private int getMailLevel(string ManagerID_L1, string ManagerID_L2, string ManagerID_L3)
        {
            int returnValue = 0;
            string[] arr = new string[] { ManagerID_L1, ManagerID_L2, ManagerID_L3 };
            foreach (string str in arr)
            {
                returnValue++;
                if (String.IsNullOrEmpty(str) == false || String.IsNullOrWhiteSpace(str) == false)
                {
                    break;
                }
            }
            return returnValue;
        }

        public int InsertRecord(string EmpID, DateTime regDate, string leaveID, DateTime startDate, DateTime toDate, string perTimeID, string leaveReason, int checkNum, float toTalDay, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
        {
            int returnValue = 0;
            object M1 = DBNull.Value, M2 = DBNull.Value, M3 = DBNull.Value;
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();

            if (checkNum == 0)
                checkNum = 3;
            for (int i = 0; i < checkNum; i++)
            {
                if (i == level.Length)
                    break;
                int j = Convert.ToInt32(level[i]);
                switch (j)
                {
                    case 1:
                        M1 = arr[i];
                        break;
                    case 2:
                        M2 = arr[i];
                        break;
                    case 3:
                        M3 = arr[i];
                        break;
                }
            }
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            string sql = "Insert into tblWebData (EmployeeID, RegDate, LeaveID, StartDate, ToDate, PerTimeID, LeaveReason, CheckNum, TotalDays, MailToL1, ManagerID_L1, ManagerID_L2, ManagerID_L3) ";
            sql += "Values(@EmployeeID, @RegDate, @LeaveID, @StartDate, @ToDate, @PerTimeID, @LeaveReason, @CheckNum, @TotalDays, @MailToL1, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@LeaveID", "@StartDate", "@ToDate", "@PerTimeID", "@LeaveReason", "@CheckNum", "@TotalDays", "@MailToL1", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, toTalDay, DBNull.Value, M1, M2, M3 };
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
        }

        //Insert data cho chế độ nghỉ theo giờ
        public int InsertRecord2(string EmpID, DateTime regDate, string leaveID, DateTime startDate, DateTime toDate, string perTimeID, string leaveReason, int checkNum, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3, DateTime fromTime, DateTime toTime, float TotalHours)
        {
            int returnValue = 0;
            object M1 = DBNull.Value, M2 = DBNull.Value, M3 = DBNull.Value;
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();
            for (int i = 0; i < checkNum; i++)
            {
                if (i == level.Length)
                    break;
                int j = Convert.ToInt32(level[i]);
                switch (j)
                {
                    case 1:
                        M1 = arr[i];
                        break;
                    case 2:
                        M2 = arr[i];
                        break;
                    case 3:
                        M3 = arr[i];
                        break;
                }
            }
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            string sql = "Insert into tblWebData (EmployeeID, RegDate, LeaveID, StartDate, ToDate, PerTimeID, LeaveReason, CheckNum, MailToL1, ManagerID_L1, ManagerID_L2, ManagerID_L3, FromTime, ToTime, TotalHours) ";
            sql += "Values(@EmployeeID, @RegDate, @LeaveID, @StartDate, @ToDate, @PerTimeID, @LeaveReason, @CheckNum, @MailToL1, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3, @FromTime, @ToTime, @TotalHours);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@LeaveID", "@StartDate", "@ToDate", "@PerTimeID", "@LeaveReason", "@CheckNum", "@MailToL1", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3", "@FromTime", "@ToTime", "@TotalHours" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, DBNull.Value, M1, M2, M3, fromTime, toTime, TotalHours };
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
        }

        //Insert data cho trường hợp lượt vi phạm thời gian báo trước
        public int InsertRecordWithWarning(string EmpID, DateTime regDate, string leaveID, DateTime startDate, DateTime toDate, string perTimeID, string leaveReason, int checkNum, float toTalDay, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
        {
            int returnValue = 0;
            object M1 = DBNull.Value, M2 = DBNull.Value, M3 = DBNull.Value;
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();
            for (int i = 0; i < checkNum; i++)
            {
                if (i == level.Length)
                    break;
                int j = Convert.ToInt32(level[i]);
                switch (j)
                {
                    case 1:
                        M1 = arr[i];
                        break;
                    case 2:
                        M2 = arr[i];
                        break;
                    case 3:
                        M3 = arr[i];
                        break;
                }
            }

            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            string sql = "Insert into tblWebData (EmployeeID, RegDate, LeaveID, StartDate, ToDate, PerTimeID, LeaveReason, CheckNum, TotalDays, MailToL1, ManagerID_L1, ManagerID_L2, ManagerID_L3, Warning) ";
            sql += "Values(@EmployeeID, @RegDate, @LeaveID, @StartDate, @ToDate, @PerTimeID, @LeaveReason, @CheckNum, @TotalDays, @MailToL1, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3, @Warning);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@LeaveID", "@StartDate", "@ToDate", "@PerTimeID", "@LeaveReason", "@CheckNum", "@TotalDays", "@MailToL1", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3", "@Warning" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, checkNum, toTalDay, DBNull.Value, M1, M2, M3, 1 };
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
        }

        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            IsForeWarning = true;
            IsForeWarningUP = true;
            IsForeWarningMR1 = true;
            IsForeWarningMR2 = true;
            IsForeWarning_RegisterDate = true;
            args.IsValid = true;
            try
            {
                DateTime FromDate = Convert.ToDateTime(ddlTuNgay.Text);
                DateTime ToDate = Convert.ToDateTime(ddlDenNgay.Text);
                string EmployeeID = Session["EmployeeID"].ToString();
                string PerTimeID = drchedonghi.Value.ToString();
                string LeaveID = drLoainghi.Value.ToString();
                string mid1 = Session["MID1"].ToString();
                string mid2 = Session["MID2"].ToString();
                string mid3 = Session["MID3"].ToString();

                #region old code
                //if (String.IsNullOrWhiteSpace(mid1) == false && String.IsNullOrWhiteSpace(mid2) == true && String.IsNullOrWhiteSpace(mid3) == false)
                //{
                //    args.IsValid = false;
                //    if (Session["lang"] != null)
                //    {
                //        if (Session["lang"].ToString().Equals("vi"))
                //        {
                //            this.vThongBao.ErrorMessage = "Vui lòng kiểm tra lại tính hợp lệ của danh sách cấp phê duyệt";
                //            return;
                //        }
                //        else
                //        {
                //            this.vThongBao.ErrorMessage = "Please check again approval manager list";
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        this.vThongBao.ErrorMessage = "Vui lòng kiểm tra lại tính hợp lệ của danh sách cấp phê duyệt";
                //        return;
                //    }
                //}

                //if (Validate_OldDate(FromDate, ToDate) == false)
                //{
                //    args.IsValid = false;
                //    if (Session["lang"] != null)
                //    {
                //        if (Session["lang"].ToString().Equals("vi"))
                //        {
                //            this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ phải lớn hơn hiện tại";
                //            return;
                //        }
                //        else
                //        {
                //            this.vThongBao.ErrorMessage = "The date to register must be greater than the current date";
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ phải lớn hơn hiện tại";
                //        return;
                //    }
                //}
                #endregion

                if (chkOptCondition.Enabled == true)
                {
                    if (!chkOptCondition.Checked)
                    {
                        vOptCondition.Visible = true;
                        args.IsValid = false;
                        this.vThongBao.ErrorMessage = GetGlobalResourceObject("F_Registration1", "vOptCondition").ToString();
                        return;
                    }
                }

                #region Validate_Back1Week
                if (Validate_Back2Week(FromDate, ToDate) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ không được trễ quá 15 ngày";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "The date to register cannot late 15 days";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ không được trễ quá 15 ngày";
                        return;
                    }
                }
                #endregion
                #region Validate_DuplicateDate
                if (Validate_DuplicateDate(FromDate, ToDate, PerTimeID, EmployeeID, LeaveID) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Khoảng thời gian đăng ký đã bị trùng";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "The period time to register was dupplicated";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Khoảng thời gian đăng ký đã bị trùng";
                        return;
                    }
                }
                #endregion
                #region Is_CL_After_CLOT10
                if (Is_CL_After_CLOT10(EmployeeID, ToDate) == false && String.Compare(LeaveID, "CL", true) == 0)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Không thể nghỉ bù trước thời điểm đăng ký làm thêm";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Không thể nghỉ bù trước thời điểm đăng ký làm thêm cũ nhất";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Không thể nghỉ bù trước thời điểm đăng ký làm thêm cũ nhất";
                        return;
                    }
                }
                #endregion
                #region Validate_DuplicateDate_CL
                if (Validate_DuplicateDate_CL(FromDate, ToDate, PerTimeID, EmployeeID, LeaveID) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Thời gian đăng ký làm thêm và nghỉ bù bị trùng";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Thời gian đăng ký làm thêm và nghỉ bù bị trùng";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Thời gian đăng ký làm thêm và nghỉ bù bị trùng";
                        return;
                    }
                }
                #endregion
                #region Validate_RemainLeave
                if (Validate_RemainLeave(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                {
                    if (string.Compare(drLoainghi.Value.ToString(), "AL") == 0)
                    {
                        string message = "";
                        args.IsValid = false;
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                //this.vThongBao.ErrorMessage = "Bạn không đủ phép tồn để đăng ký";
                                //return;
                                message = "alert('Bạn không đủ phép tồn để đăng ký')";
                            }
                            else
                            {
                                //this.vThongBao.ErrorMessage = "Not enough annually leave to register";
                                //return;
                                message = "alert('Not enough annually leave to register')";
                            }
                        }
                        else
                        {
                            //this.vThongBao.ErrorMessage = "Bạn không đủ phép tồn để đăng ký";
                            //return;
                            message = "alert('Bạn không đủ phép tồn để đăng ký')";
                        }
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                }
                #endregion
                #region Validate_CL
                if (Validate_CL(drLoainghi.Value.ToString()) == false)
                {
                    args.IsValid = false;
                    string message = "";
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            //this.vThongBao.ErrorMessage = "Bạn không đủ phép bù để đăng ký";
                            //return;
                            message = "alert('Bạn không đủ phép bù để đăng ký')";
                        }
                        else
                        {
                            //this.vThongBao.ErrorMessage = "Not enough compensation leave to register";
                            //return;
                            message = "alert('Not enough compensation leave to register')";
                        }
                    }
                    else
                    {
                        //this.vThongBao.ErrorMessage = "Bạn không đủ phép bù để đăng ký";
                        //return;
                        message = "alert('Bạn không đủ phép bù để đăng ký')";
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                #endregion
                #region Validate_Range
                if (!Validate_Range(FromDate, ToDate) && string.Compare(drLoainghi.Value.ToString(), "AL") == 0)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Phép năm " + (ToDate.Year - 1) + " chỉ tính đến hết tháng 3. Do đó phải tách ra 2 lần đăng ký cho 2 năm";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "After March, annual leave will be reset. You must register in range before April or after March";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Phép năm " + (ToDate.Year - 1) + " chỉ tính đến hết tháng 3. Do đó phải tách ra 2 lần đăng ký cho 2 năm";
                        return;
                    }
                }
                #endregion
                #region  Xét điều kiện loại phép để validate
                string leavetype = drLoainghi.Value.ToString();
                if (!Validate_ForeWarn_RegisterDate(FromDate, ToDate))
                {
                    IsForeWarning_RegisterDate = false;
                }
                switch (leavetype.ToLower())
                {
                    case "al": //Phép năm
                        if (Validate_ForeWarn(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            IsForeWarning = true;
                        }
                        break;
                    case "cl": //Phép bù
                        break;
                    case "b1": //Nhân viên kết hôn
                        if (Validate_MR1(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 3 ngày/năm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 3 days/year";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 3 ngày/năm";
                                return;
                            }
                        }

                        if (Validate_ForeWarn_MR(FromDate, ToDate) == false)
                        {
                            IsForeWarningMR1 = true;
                        }

                        break;

                    case "b1_1": //Con nhân viên kết hôn
                        if (Validate_MR2(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 1 ngày";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 1 day";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 1 ngày";
                                return;
                            }
                        }

                        if (Validate_ForeWarn_MR(FromDate, ToDate) == false)
                        {
                            IsForeWarningMR2 = true;
                        }
                        break;
                    case "b2": //Tang chế
                        if (Validate_FL(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 3 ngày";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 3 days";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 3 ngày";
                                return;
                            }
                        }
                        break;

                    case "sl": //Đau ốm
                        if (Validate_SL(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 30 ngày/năm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 30 days/year";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 30 ngày/năm";
                                return;
                            }
                        }
                        break;

                    case "sl_a6": // Nghỉ ốm dưới 3 ngày/ năm
                        if (Validate_SL_A6(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 2 ngày/năm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 2 days/year";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 2 ngày/năm";
                                return;
                            }
                        }
                        break;

                    case "me": // Khám thai
                        if (Validate_ME(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 1 ngày/lượt";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 1 day per time";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 1 ngày/lượt";
                                return;
                            }
                        }
                        break;

                    case "sl_a": //Dưỡng sức sau Bệnh: 5 ngày liên tục
                    case "sl_a1": //Dưỡng sức sau Bệnh(phẩu thuật): 7 ngày liên tục
                        if (getTotalDayOf_ByType(EmployeeID, "SL", FromDate.Year) < 30)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Bạn vẫn còn lượt nghỉ ốm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You still have limit \"Sick Leave\"";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Bạn vẫn còn lượt nghỉ ốm";
                                return;
                            }
                        }
                        else if (Validate_SL_A_After_SL(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký trong vòng 30 ngày sau nghỉ ốm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You must register between 30 days after \"Sick Leave\"";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký trong vòng 30 ngày sau nghỉ ốm";
                                return;
                            }
                        }
                        else if (Validate_SL_A(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over days specified";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                return;
                            }
                        }
                        break;

                    case "sl_a2": //Dưỡng sức sau Sinh: 5 ngày liên tục
                    case "sl_a3": //Dưỡng sức sau Sinh (phẩu thuật): 7 ngày liên tục 
                    case "sl_a4": //Dưỡng sức sau Sinh (sinh đôi): 10 ngày liên tục 
                        /*if (Validate_SL_A_After_SL(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký trong vòng 30 ngày sau nghỉ ốm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You must register between 30 days after \"Sick Leave\"";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký trong vòng 30 ngày sau nghỉ ốm";
                                return;
                            }
                        }
                        else */
                        if (Validate_SL_A(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over days specified";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                return;
                            }
                        }
                        break;

                    case "sl_a5": //Nghỉ phép đi Thi (học do Cty duyệt): 5 ngày/ năm
                        if (Validate_SL_A5(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 5 ngày/năm";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over 5 days/year";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Chỉ được đăng ký tối đa 5 ngày/năm";
                                return;
                            }
                        }
                        break;

                    case "ul": //Nghỉ không hưởng lương
                        double dayRemain = 0;
                        if (Validate_UP(EmployeeID, out dayRemain) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Khi hết số ngày phép năm thì mới được đăng ký nghỉ không lương";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You still have " + dayRemain.ToString("#0.#") + " days annual leave. You can not register this type.";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Khi hết số ngày phép năm thì mới được đăng ký nghỉ không lương";
                                return;
                            }
                        }
                        if (Validate_ForeWarn_UP(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            IsForeWarningUP = true;
                        }
                        break;

                    case "wl_5": // Nghi vo sinh
                    case "wl_7":
                    case "wl_10":
                    case "wl_14":
                        if (Validate_WL(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            args.IsValid = false;
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                    return;
                                }
                                else
                                {
                                    this.vThongBao.ErrorMessage = "You can not register over days specified";
                                    return;
                                }
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Bạn đã đăng ký quá số ngày quy định";
                                return;
                            }
                        }
                        break;

                    default: //Các trường hợp khác
                        break;
                }
                #endregion
            }
            catch
            {
                //Phải set true để lưới không bị bắt validate
                args.IsValid = true;
            }

        }

        protected void btnNhapLai_Click(object sender, EventArgs e)
        {
            ddlTuNgay.Text = "";
            ddlDenNgay.Text = "";
            txtTongNgay.Value = 0;
            txtLydo.Text = "";

            if (Convert.ToInt32(drchedonghi.Value) == 3)
            {
                //Hiện đăng ký giờ
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                //teditTuGio.Enabled = true;
                //teditDenGio.Enabled = true;
                //vTongGio.Enabled = true;
                //btnTinhGio.Enabled = true;
                ddlDenNgay.Enabled = false;
            }
            else
            {
                //teditTuGio.Enabled = false;
                //teditDenGio.Enabled = false;
                //vTongGio.Enabled = false;
                //btnTinhGio.Enabled = false;
                ddlDenNgay.Enabled = true;
            }
        }

        protected void ddlDenNgay_DateChanged(object sender, EventArgs e)
        {
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals(""))
            {

                if (!drchedonghi.Text.Equals(""))
                {
                    DateTime FromDate = (DateTime)ddlTuNgay.Value;
                    DateTime ToDate = (DateTime)ddlDenNgay.Value;
                    string EmpID = Session["EmployeeID"].ToString();
                    txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
                }
            }

            if (Convert.ToInt32(drchedonghi.Value) == 3)
            {
                //Hiện đăng ký giờ
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                //teditTuGio.Enabled = true;
                //teditDenGio.Enabled = true;
                //vTongGio.Enabled = true;
                //btnTinhGio.Enabled = true;
                txtTongNgay.Text = "";
            }
            else
            {
                //teditTuGio.Enabled = false;
                //teditDenGio.Enabled = false;
                //vTongGio.Enabled = false;
                //btnTinhGio.Enabled = false;
            }
        }

        protected void drchedonghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Thiết lập trạng thái control chế độ đăng ký theo giờ
            if (Convert.ToInt32(drchedonghi.Value) == 3)
            {
                //Hiện đăng ký giờ
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                //teditTuGio.Enabled = true;
                //teditDenGio.Enabled = true;
                //vTongGio.Enabled = true;
                //btnTinhGio.Enabled = true;
                ddlDenNgay.Enabled = false;
                txtTongNgay.Text = "";
            }
            else
            {
                //teditTuGio.Enabled = false;
                //teditDenGio.Enabled = false;
                //vTongGio.Enabled = false;
                //btnTinhGio.Enabled = false;
                ddlDenNgay.Enabled = true;
            }


            string EmpID = Session["EmployeeID"].ToString();
            //Xét điều kiện để tính tổng ngày
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;
                if (drchedonghi.Value.ToString().Equals("3"))
                {
                    ddlDenNgay.Value = ddlTuNgay.Value;
                    txtTongNgay.Value = CalculateLeaveDays(FromDate, FromDate, drchedonghi.Value.ToString(), EmpID).ToString();
                }
                else
                {
                    txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
                }

            }
            else
            {
                if (drchedonghi.Value.ToString().Equals("3") && !ddlTuNgay.Text.Equals(""))
                {
                    DateTime FromDate = (DateTime)ddlTuNgay.Value;
                    ddlDenNgay.Value = ddlTuNgay.Value;
                    //txtTongNgay.Value = CalculateLeaveDays(FromDate, FromDate, drchedonghi.Value.ToString(), EmpID).ToString();
                    txtTongNgay.Text = "";
                }
            }

        }

        protected void ddlTuNgay_DateChanged(object sender, EventArgs e)
        {
            // tu dong dien gia tri den ngay theo loai nghi phep
            switch (drLoainghi.Value.ToString().ToUpper())
            {
                case "ME": // kham thai
                    ddlDenNgay.Value = ddlTuNgay.Date;
                    break;

                case "ML": // Thai san
                    ddlDenNgay.Date = ddlTuNgay.Date.AddMonths(6).AddDays(-1);
                    break;

                case "SL_A": // Dưỡng sức sau Bệnh: 5 ngày liên tục
                case "SL_A2": // Dưỡng sức sau Sinh: 5 ngày liên tục
                    ddlDenNgay.Value = ddlTuNgay.Date.AddDays(4);
                    break;

                case "SL_A1": // Dưỡng sức sau Bệnh (phẩu thuật): 7 ngày liên tục 
                case "SL_A3": // Dưỡng sức sau Sinh (phẩu thuật): 7 ngày liên tục 
                    ddlDenNgay.Value = ddlTuNgay.Date.AddDays(6);
                    break;

                case "SL_A4": // Dưỡng sức sau Sinh (sinh đôi): 10 ngày liên tục 
                    ddlDenNgay.Value = ddlTuNgay.Date.AddDays(9);
                    break;
                /*
            case "WL_5": // Nghỉ vợ sinh - sinh thường: 5 ngày
            case "WL_7": // Nghỉ vợ sinh - sinh con phải phẩu thuật/Sinh con dưới 32 tuần tuổi: 7 ngày
            case "WL_10": // Nghỉ vợ sinh - Sinh đôi: 10 ngày
            case "WL_14": // Nghỉ vợ sinh - Sinh đôi phải phẩu thuật: 14 ngày
                ddlDenNgay.Value = ddlTuNgay.Date.AddDays(14);
                break;
                */
                default:
                    break;
            }
            string EmpID = Session["EmployeeID"].ToString();
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;

                if (drchedonghi.Value.ToString().Equals("3"))
                {
                    ddlDenNgay.Value = ddlTuNgay.Value;
                    //txtTongNgay.Value = CalculateLeaveDays(FromDate, FromDate, drchedonghi.Value.ToString(), EmpID).ToString();
                    txtTongNgay.Text = "";
                }
                else
                {
                    txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
                }
            }
            else
            {
                if (drchedonghi.Value.ToString().Equals("3") && !ddlTuNgay.Text.Equals(""))
                {
                    DateTime FromDate = (DateTime)ddlTuNgay.Value;
                    ddlDenNgay.Value = ddlTuNgay.Value;
                    //txtTongNgay.Value = CalculateLeaveDays(FromDate, FromDate, drchedonghi.Value.ToString(), EmpID).ToString();
                    txtTongNgay.Text = "";
                }
            }
        }

        protected void ASPxGridView2_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.Equals("ApprovingStatus_L1") || e.Column.FieldName.Equals("ApprovingStatus_L2") || e.Column.FieldName.Equals("ApprovingStatus_L3") || e.Column.FieldName.Equals("HRCheckingStatus"))
            {
                if (String.IsNullOrWhiteSpace(e.Value.ToString()) == true)
                {
                    e.DisplayText = GetGlobalResourceObject("F_Registration1", "w").ToString();
                }
                else
                {
                    if (String.Compare(e.Value.ToString(), "true", true) == 0)
                    {
                        e.DisplayText = GetGlobalResourceObject("F_Registration1", "a").ToString();
                    }
                    else
                    {
                        e.DisplayText = GetGlobalResourceObject("F_Registration1", "c").ToString();
                    }
                }
            }
        }

        protected void btnTinhGio_Click(object sender, EventArgs e)
        {
            //TimeSpan ts = new TimeSpan();
            //DateTime fromHour = Convert.ToDateTime(teditTuGio.Value);
            //DateTime toHour = Convert.ToDateTime(teditDenGio.Value);
            //ts = toHour - fromHour;
            //txtTongGio.Text = (Math.Round(ts.TotalHours, 2)).ToString();
        }

        protected void drLoainghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string leaveid = drLoainghi.Value.ToString();
            // Show check Condition
            ShowCheckCondition(leaveid);
            if (string.Compare(leaveid, "up", true) == 0)
            {
                drchedonghi.DataSource = getPerTimeDataSource1();
                drchedonghi.DataBind();
                //drchedonghi.SelectedIndex = 0;

                //Xét trường hợp đăng ký theo giờ
                if (drchedonghi.Value.ToString().Equals("3"))
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    //teditTuGio.Enabled = true;
                    //teditDenGio.Enabled = true;
                    //vTongGio.Enabled = true;
                    //btnTinhGio.Enabled = true;
                    ddlDenNgay.Enabled = false;
                    txtTongNgay.Text = "";
                }
                else
                {
                    //teditTuGio.Enabled = false;
                    //teditDenGio.Enabled = false;
                    //vTongGio.Enabled = false;
                    //btnTinhGio.Enabled = false;
                    ddlDenNgay.Enabled = true;
                }

            }
            else
            {
                drchedonghi.DataSource = getPerTimeDataSource2();
                drchedonghi.DataBind();
                drchedonghi.SelectedIndex = 0;

                //Xét trường hợp đăng ký theo giờ
                if (drchedonghi.Value.ToString().Equals("3"))
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    //teditTuGio.Enabled = true;
                    //teditDenGio.Enabled = true;
                    //vTongGio.Enabled = true;
                    //btnTinhGio.Enabled = true;
                    ddlDenNgay.Enabled = false;
                    txtTongNgay.Text = "";
                }
                else
                {
                    //teditTuGio.Enabled = false;
                    //teditDenGio.Enabled = false;
                    //vTongGio.Enabled = false;
                    //btnTinhGio.Enabled = false;
                    ddlDenNgay.Enabled = true;
                }
            }
        }

        private void ShowCheckCondition(string leaveid)
        {
            try
            {
                RefLeaveTypeService service = new RefLeaveTypeService();
                DataTable dt = service.GetLeaveType_ByID(leaveid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    object optCondition = dt.Rows[0]["OptCondition"];
                    if (optCondition == null || optCondition.ToString() == "")
                    {
                        chkOptCondition.Text = "";
                        vOptCondition.Visible = false;
                        chkOptCondition.Enabled = false;
                    }
                    else
                    {
                        chkOptCondition.Text = optCondition.ToString();
                        chkOptCondition.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private DataTable getPerTimeDataSource1()
        {
            DataTable dt = new DataTable();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select * from tblPerTime";
            dt = provider.GetDataTable();
            int count = dt.Rows.Count;
            provider.CloseConnection();
            return dt;
        }

        private DataTable getPerTimeDataSource2()
        {
            DataTable dt = new DataTable();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select * from tblPerTime where PerTimeID <> '3'";
            dt = provider.GetDataTable();
            int count = dt.Rows.Count;
            provider.CloseConnection();
            return dt;
        }

        private DateTime getToDate(string EmployeeID)
        {
            DateTime returnDate = new DateTime();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select LeftDate from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                object date = dt.Rows[0]["LeftDate"];
                if (String.IsNullOrWhiteSpace(date.ToString()))
                {
                    returnDate = new DateTime(DateTime.Today.Year, 12, 31);
                }
                else
                {
                    returnDate = Convert.ToDateTime(date);
                }
            }
            provider.CloseConnection();
            return returnDate;
        }

        protected void chkSunday_CheckedChanged(object sender, EventArgs e)
        {
            //Tính lại tổng ngày nghỉ
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;
                string EmpID = Session["EmployeeID"].ToString();
                txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
            }

            if (Convert.ToInt32(drchedonghi.Value) == 3)
            {
                //Hiện đăng ký giờ
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                //teditTuGio.Enabled = true;
                //teditDenGio.Enabled = true;
                //vTongGio.Enabled = true;
                //btnTinhGio.Enabled = true;
                txtTongNgay.Text = "";
            }
            else
            {
                //teditTuGio.Enabled = false;
                //teditDenGio.Enabled = false;
                //vTongGio.Enabled = false;
                //btnTinhGio.Enabled = false;
            }
        }

        protected void chkOptCondition_CheckedChanged(object sender, EventArgs e)
        {
            vOptCondition.Visible = false;
        }

        private string GetNewEmployeeID(object EmployeeID)
        {
            string value = "";
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "sp_GetNewEmployeeID";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["NewEmployeeID"].ToString();
            }

            return value;
        }
    }
}