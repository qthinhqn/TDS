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

namespace NPOL
{
    public partial class F_Registration1 : System.Web.UI.Page
    {
        bool IsForeWarning = true;
        bool IsForeWarningUP = true;
        bool IsForeWarningMR1 = true;
        bool IsForeWarningMR2 = true;

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

            //Tiêu đề trang
            if (Session["lang"] != null)
            {
                if (Session["lang"].ToString().Equals("vi"))
                {
                    lbTieuDe.Text = "Đăng ký nghỉ phép năm " + DateTime.Now.Year;
                }
                else
                {
                    lbTieuDe.Text = "Leave registration year " + DateTime.Now.Year;
                }
            }
            else
            {
                lbTieuDe.Text = "Đăng ký nghỉ phép năm " + DateTime.Now.Year;
            }


            //Nạp dữ liệu chế độ nghỉ khi mở trang
            if (!IsPostBack)
            {
                drchedonghi.DataSource = getPerTimeDataSource1();
                drchedonghi.DataBind();
                drchedonghi.SelectedIndex = 0;

                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    teditTuGio.Enabled = true;
                    teditDenGio.Enabled = true;
                    vTongGio.Enabled = true;
                    btnTinhGio.Enabled = true;
                    vTongNgay.Enabled = false;
                    txtTongNgay.Text = "";
                }
                else
                {
                    teditTuGio.Enabled = false;
                    teditDenGio.Enabled = false;
                    vTongGio.Enabled = false;
                    btnTinhGio.Enabled = false;
                    vTongNgay.Enabled = true;
                }

                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = new Khuong(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            ASPxGridView1.JSProperties["cpDeleted"] = "";

            //Nếu nhân viên chưa ký HĐLĐ thì không hiện phép tồn
            if (!havingContract(Session["EmployeeID"].ToString(), DateTime.Today))
            {
                txtPhepTon.Text = "";
                txtAL.Text = "";
                txtTotalAL.Text = "";
                LoaiPhepDS.SelectCommand = "SELECT LeaveID, LeaveType FROM tblRef_LeaveType where IsOnline = 'True' and LeaveID <> 'AL' and LeaveID <> 'CL_OT10'";
                LoaiPhepDS.DataBind();


                //txtPhepTon.Value = CalculateALRemain(Session["EmployeeID"].ToString());  
            }
            else
            {
                txtPhepTon.Value = CalculateALRemain(Session["EmployeeID"].ToString());
            }

            //Hiển thịp phép nghỉ bù
            //StaticCls.phepbu = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
            ViewState["phepbu"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
            txtPhepbu.Text = ViewState["phepbu"].ToString();

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

        private void LoadData_Edit(object keyID)
        {
            try
            {
                string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString;
                tblWebData thucthi = new tblWebData(ketnoi);
                DataTable dt = thucthi.getObjectByID(keyID);
                if (dt != null && dt.Rows.Count == 1)
                {
                    drLoainghi.Value = dt.Rows[0]["LeaveID"].ToString();
                    drchedonghi.Value = dt.Rows[0]["PerTimeID"].ToString();
                    ddlTuNgay.Value = (DateTime)dt.Rows[0]["StartDate"];
                    ddlDenNgay.Value = (DateTime)dt.Rows[0]["ToDate"];
                    txtLydo.Text = dt.Rows[0]["LeaveReason"].ToString();
                    
                    ddlDenNgay_DateChanged(null, null);
                }
            }
            catch(Exception ex)
            { }
        }


        #region Kiểm tra xem nhân viên đã ký hđlđ chưa
        private bool havingContract(string EmployeeID, DateTime View)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            try
            {
                provider.CommandText = "Select * from dbo.udf_GetMax_Contract(@thamso) Where ContractTypeID In (Select ContractTypeID from tblRef_ContractType Where GroupID in (2,4))";
                provider.ParameterCollection = new string[] { "@thamso" };
                provider.ValueCollection = new object[] { View };
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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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
        bool Validate_CurrentYear(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            try
            {
                khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
                sqlProvider.CommandText = "select Year(getdate())";
                object year = sqlProvider.ExecuteScalar();
                if (fromDate.Year != (int)year || toDate.Year != (int)year)
                {
                    validate = false;
                }
            }
            catch (Exception ex)
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_Foreigner()
        {
            bool validate = true;
            try
            {
                // khong chan dang ky cua nguoi nuoc ngoai
                // cap nhat theo mail y.c Ms Tram 30.11.2017
                khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
                sqlProvider.CommandText = "select ISNULL(IsForeigner,0) From tblEmployee Where EmployeeID = @EmpID";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { Session["EmployeeID"] };
                object _isForeigner = sqlProvider.ExecuteScalar();
                if (!(bool)_isForeigner)
                    validate = false;
            }
            catch (Exception ex)
            {
                validate = false;
            }
            return validate;
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

        bool Validate_FL(DateTime fromDate, DateTime toDate, string perTimeID, String employeeID)
        {
            bool validate = false;
            if (string.Compare("fl", drLoainghi.Value.ToString(), true) == 0 && CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID) <= 3)
            {
                validate = true;
            }
            return validate;
        }

        bool Validate_MR1(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            if (String.Compare(drLoainghi.Value.ToString(), "MR1", true) == 0 && CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID) > 3)
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_MR2(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            bool validate = true;
            //Code xu ly
            if (String.Compare(drLoainghi.Value.ToString(), "MR2", true) == 0 && CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID) > 1)
            {
                validate = false;
            }
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
                if (Validate_Foreigner())
                {
                    khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
                    sqlProvider.CommandText = "select Year(getdate())";
                    object year = sqlProvider.ExecuteScalar();
                    double _totalAL = Convert.ToDouble(txtTotalAL.Text);

                    if (fromDate.Year == (int)year)
                    {
                        if (toDate.Year == (int)year + 1)
                        {
                            toDate = new DateTime(fromDate.Year, 12, 31);
                            result = Convert.ToDouble(txtPhepTon.Text) - CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);
                            if (_totalAL < Convert.ToDouble(txtPhepTon.Text) - CalculateLeaveDays(new DateTime(toDate.Year, 1, 1), toDate, perTimeID, employeeID))
                                return false;
                        }
                    }
                    else if (fromDate.Year == (int)year + 1)
                    {
                        result = Convert.ToDouble(txtPhepTon.Text);
                        if (_totalAL < Convert.ToDouble(txtPhepTon.Text) - CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }

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

        // Không cho đăng ký nghỉ phép ngày quốc khánh
        bool Validate_IndependenceDay(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            //Code xu ly
            if (IsIndependenceDay(fromDate, Session["EmployeeID"].ToString()) || IsIndependenceDay(toDate, Session["EmployeeID"].ToString()))
            {
                validate = false;
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
        bool Validate_OldDate30(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            sqlProvider.CommandText = "select getdate()";
            object current = sqlProvider.ExecuteScalar();
            TimeSpan ts = (DateTime)current - fromDate;
            TimeSpan ts1 = (DateTime)current - toDate;
            int i = (int)ts.TotalDays;
            int j = (int)ts1.TotalDays;
            if (i > 30 || j > 30)
            {
                validate = false;
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
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            sqlProvider.CommandText = "Select * from tblWebData Where EmployeeID = @EmployeeID and (FinalStatus = 'w' or FinalStatus ='A' or FinalStatus ='a') and LeaveID = @LeaveID";
            if (Session["KeyID_Edit"] != null)
            {
                sqlProvider.CommandText += " And ID <> " + Session["KeyID_Edit"].ToString();
            }
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

        float CalculateLeaveDays(DateTime fromDate, DateTime toDate, string perTimeID, string employeeID)
        {
            float returnValue = 0;
            double result = 0;
            double workday = getWorkDay(employeeID);
            string leaveid = drLoainghi.Value.ToString();

            if (workday == 22) //Nghỉ làm thứ 7
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

            if (workday == 26)//Đi làm thứ 7
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

            //Trường hợp đăng ký làm thêm nghỉ bù (1-1)
            if (String.Compare(leaveid, "CL_OT10", true) == 0)
            {
                result = TotalDay(fromDate, toDate);
            }

            returnValue = (float)result;
            return returnValue;
        }

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
                if (IsIndependenceDay(frDate.AddDays(i), Session["EmployeeID"].ToString()))
                {
                    returnValue++;
                }
            }

            return returnValue;
        }

        public bool IsHoliday(DateTime date)
        {
            bool holiday = false;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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

        public bool IsIndependenceDay(DateTime date, string EmployeeID)
        {
            bool holiday = false;

            try
            {
                BaseDAO dao = new BaseDAO();
                DataTable dt = dao.StoreToTable("PER_sp_IndependenceDay", "tblIndependenceDay", EmployeeID, date);

                if (dt.Rows.Count > 0)
                {
                    holiday = true;
                }
            }
            catch (Exception ex) { }

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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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
                if (string.Compare(approval, "w", true) != 0 && string.Compare(approval, "r", true) != 0)
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
                            e.DisplayText = "Cancel";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Không duyệt";
                    }
                }

                if (e.Value.Equals("r") || e.Value.Equals("R"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            e.DisplayText = "Trả lại";
                        }
                        else
                        {
                            e.DisplayText = "Restore";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Trả lại";
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


        public ArrayList getALRemainForEmployee(DateTime FromDate, DateTime ToDate, string EmployeeID)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());

            //Gọi sp_View_EmpALRemain_Online của Tân Đức
            //sqlProvider.CommandText = "sp_View_EmpALRemain_Online";
            sqlProvider.CommandText = "PER_sp_Rpt_LeaveReport";
            sqlProvider.CommandType = CommandType.StoredProcedure;
            DateTime fromDate = new DateTime(ToDate.Year, 1, 1);
            sqlProvider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID", "@UserID" };
            sqlProvider.ValueCollection = new object[] { fromDate, ToDate, EmployeeID, "LeaveReg" + Session["EmployeeID"].ToString() };
            sqlProvider.ExecuteNonQuery();


            //Lay phep ton tu table tbl_View_EmpALRemain_Online            
            sqlProvider.CommandText = "Select ALInitial, ALInyear, ALUsed, ALRemain from tbl_View_EmpALRemain_Online where EmployeeID = @EmployeeID and ComputerName = @ComputerName";
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

            }
            sqlProvider.CloseConnection();
            return arr;
        }

        //Tính tổng lượt phép năm chưa đồng bộ
        public double getTotalDayOfAL(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and LeaveID='AL'"
                                    + " and ((FinalStatus='w' And HRview = 'b') OR (FinalStatus='a' And HRView = 'a'))"
                                    + " and Year(StartDate) = Year(getdate());";
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

        //Tính tổng lượt phép nghỉ bù chưa đồng bộ
        public float getTotalDayOfCL(string EmployeeID)
        {
            float value = 0;
            double double_value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
                if (Session["KeyID_Edit"] != null)
                {
                    DeleteObject(Session["KeyID_Edit"]);
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

                tblEmpManagerLevel o = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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

                //Xét điều kiện loại phép để xác định số cấp duyệt
                switch (leaveID.ToLower())
                {
                    #region Trường hợp UP
                    case "up": //Trường hợp nghỉ không lương
                        //Nếu số ngày nghỉ < 4
                        if (totalDay < 4)
                        {
                            if (MaxCheckNum >= 1)
                            {
                                checkNum = 1;
                            }
                            else
                            {
                                checkNum = MaxCheckNum;
                            }
                        }
                        else
                        {
                            //Nếu nghỉ từ 4 - 12 ngày
                            if (totalDay < 13)
                            {
                                if (MaxCheckNum >= 2)
                                {
                                    checkNum = 2;
                                }
                                else
                                {
                                    checkNum = MaxCheckNum;
                                }
                            }
                            else
                            {
                                if (MaxCheckNum >= 3)
                                {
                                    checkNum = 3;
                                }
                                else
                                {
                                    checkNum = MaxCheckNum;
                                }
                            }
                        }

                        //Insert data
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
                                DateTime FromTime = (DateTime)teditTuGio.Value;
                                DateTime ToTime = (DateTime)teditDenGio.Value;
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
                                DateTime FromTime = (DateTime)teditTuGio.Value;
                                DateTime ToTime = (DateTime)teditDenGio.Value;
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

                        //Update Mail Action
                        level = getMailLevel(managerID_L1, managerID_L2, managerID_L3);
                        if (level > 0)
                        {
                            UpdateMailAction(EmpID, level);
                        }
                        break;
                    #endregion

                    #region Trường hợp DOD
                    case "dod": //Trường hợp di cong tac
                        checkNum = 1;

                        //Insert data
                        if (perTimeID.Equals("3"))
                        {
                            DateTime FromTime = (DateTime)teditTuGio.Value;
                            DateTime ToTime = (DateTime)teditDenGio.Value;
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
                        //if (MaxCheckNum >= 2)
                        //{
                        //    checkNum = 1;
                        //}
                        //else
                        //{
                        //    checkNum = MaxCheckNum;
                        //}
                        checkNum = 1;
                        //Insert data
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
                        //if (MaxCheckNum >= 2)
                        //{
                        //    checkNum = 1;
                        //}
                        //else
                        //{
                        //    checkNum = MaxCheckNum;
                        //}

                        checkNum = 1;
                        //Insert data
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
                        //if (MaxCheckNum >= 2)
                        //{
                        //    checkNum = 1;
                        //}
                        //else
                        //{
                        //    checkNum = MaxCheckNum;
                        //}
                        checkNum = 1;

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
                ViewState["phepbu"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                txtPhepbu.Text = ViewState["phepbu"].ToString();

                btnNhapLai_Click(sender, e);
            }

        }

        private void UpdateMailAction(string employeeid, int level)
        {
            string sql = "";
            switch (level)
            {
                case 1:
                    sql += "Update tblWebdata Set MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL Where EmployeeID = @EmployeeID  and MailToL1 is null and FinalStatus='w'";
                    break;
                case 2:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL Where EmployeeID = @EmployeeID  and MailToL2 is null and FinalStatus='w'";
                    break;
                case 3:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = NULL, MailToL3 = 1 Where EmployeeID = @EmployeeID  and MailToL3 is null and FinalStatus='w'";
                    break;
            }
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();
            for (int i = 0; i < checkNum; i++)
            {
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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();
            for (int i = 0; i < checkNum; i++)
            {
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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            object[] arr = eml.getManagerList(EmpID).ToArray();
            object[] level = eml.getManagerLevelList(EmpID).ToArray();
            for (int i = 0; i < checkNum; i++)
            {
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

            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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

                #region Validate_Independence Day
                if (!Validate_IndependenceDay(FromDate, ToDate))
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Đây là ngày Quốc Khánh, bạn được mặc nhiên nghỉ không cần đăng ký.";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "You are not required to register your Independence Day in the Eleave system.";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Đây là ngày Quốc Khánh, bạn được mặc nhiên nghỉ không cần đăng ký.";
                        return;
                    }
                }
                #endregion

                if (!Validate_Foreigner() && Validate_CurrentYear(FromDate, ToDate) == false && drLoainghi.Value.ToString().ToLower() == "al")
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Chỉ được phép đăng ký nghỉ phép trong năm hiện tại";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "The year to register must be equal the current year";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Chỉ được phép đăng ký nghỉ phép trong năm hiện tại";
                        return;
                    }
                }

                if (drLoainghi.Value.ToString().ToLower() == "al")
                {
                    if (Validate_OldDate(FromDate, ToDate) == false)
                    {
                        args.IsValid = false;
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ phải lớn hơn hiện tại";
                                return;
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "The date to register must be greater than the current date";
                                return;
                            }
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ phải lớn hơn hiện tại";
                            return;
                        }
                    }
                }
                else if (Validate_OldDate30(FromDate, ToDate) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ không nhỏ hơn hiện tại 30 ngày";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Registration date does not less than the current stay of 30 days";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Ngày đăng ký nghỉ không nhỏ hơn hiện tại 30 ngày";
                        return;
                    }
                }

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


                //Xét điều kiện loại phép để validate
                string leavetype = drLoainghi.Value.ToString();
                int TongNgay = Convert.ToInt32(txtTongNgay.Value.ToString());
                switch (leavetype.ToLower())
                {
                    case "al": //Phép năm
                        if (Validate_ForeWarn(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            //args.IsValid = false;
                            if (TongNgay == 0.5)
                            {
                                IsForeWarning = true;
                            }
                            else
                            {
                                IsForeWarning = false;
                            }
                        }
                        break;
                    case "cl": //Phép bù
                        break;
                    case "mr1": //Nhân viên kết hôn
                        if (Validate_MR1(FromDate, ToDate, PerTimeID, EmployeeID) == false)
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

                        if (Validate_ForeWarn_MR(FromDate, ToDate) == false)
                        {
                            if (TongNgay == 0.5)
                            {
                                IsForeWarningMR1 = true;
                            }
                            else
                            {
                                IsForeWarningMR1 = false;
                            }
                        }

                        break;
                    case "mr2": //Con nhân viên kết hôn
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
                            if (TongNgay == 0.5)
                            {
                                IsForeWarningMR2 = true;
                            }
                            else
                            {
                                IsForeWarningMR2 = false;
                            }
                        }
                        break;
                    case "fl": //Tang chế
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
                                    this.vThongBao.ErrorMessage = "You can not register over 3 day";
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
                    case "ml": //Thai sản
                        break;
                    case "up": //Nghỉ không hưởng lương
                        if (Validate_ForeWarn_UP(FromDate, ToDate, PerTimeID, EmployeeID) == false)
                        {
                            if (TongNgay == 0.5)
                            {
                                IsForeWarningUP = true;
                            }
                            else
                            {
                                IsForeWarningUP = false;
                            }
                        }
                        break;
                    default: //Các trường hợp khác
                        break;
                }

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

            string leaveid = drLoainghi.Value.ToString();
            if (leaveid == "DOD")
            {
                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    teditTuGio.Enabled = true;
                    teditDenGio.Enabled = true;
                    vTongGio.Enabled = true;
                    btnTinhGio.Enabled = true;
                    ddlDenNgay.Enabled = false;
                }
            }
            else
            {
                teditTuGio.Enabled = false;
                teditDenGio.Enabled = false;
                vTongGio.Enabled = false;
                btnTinhGio.Enabled = false;
                ddlDenNgay.Enabled = true;
            }

            //
            Session["KeyID_Edit"] = null;
        }

        protected void ddlDenNgay_DateChanged(object sender, EventArgs e)
        {
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;
                string EmpID = Session["EmployeeID"].ToString();
                txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
            }

            string leaveid = drLoainghi.Value.ToString();
            if (leaveid == "DOD")
            {
                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    teditTuGio.Enabled = true;
                    teditDenGio.Enabled = true;
                    vTongGio.Enabled = true;
                    btnTinhGio.Enabled = true;
                    txtTongNgay.Text = "";
                }
            }
            else
            {
                teditTuGio.Enabled = false;
                teditDenGio.Enabled = false;
                vTongGio.Enabled = false;
                btnTinhGio.Enabled = false;
            }
        }

        protected void drchedonghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Thiết lập trạng thái control chế độ đăng ký theo giờ
            string leaveid = drLoainghi.Value.ToString();
            if (leaveid == "DOD")
            {
                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    teditTuGio.Enabled = true;
                    teditDenGio.Enabled = true;
                    vTongGio.Enabled = true;
                    btnTinhGio.Enabled = true;
                    ddlDenNgay.Enabled = false;
                    txtTongNgay.Text = "";
                }
            }
            else
            {
                teditTuGio.Enabled = false;
                teditDenGio.Enabled = false;
                vTongGio.Enabled = false;
                btnTinhGio.Enabled = false;
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
            TimeSpan ts = new TimeSpan();
            DateTime fromHour = Convert.ToDateTime(teditTuGio.Value);
            DateTime toHour = Convert.ToDateTime(teditDenGio.Value);
            ts = toHour - fromHour;
            txtTongGio.Text = (Math.Round(ts.TotalHours, 2)).ToString();
        }

        protected void drLoainghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string leaveid = drLoainghi.Value.ToString();
            if (string.Compare(leaveid, "up", true) == 0)
            {
                drchedonghi.DataSource = getPerTimeDataSource1();
                drchedonghi.DataBind();
                //drchedonghi.SelectedIndex = 0;

                //Xét trường hợp đăng ký theo giờ
                if (leaveid == "DOD")
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    if (drchedonghi.Value.ToString().Equals("3"))
                    {
                        teditTuGio.Enabled = true;
                        teditDenGio.Enabled = true;
                        vTongGio.Enabled = true;
                        btnTinhGio.Enabled = true;
                        ddlDenNgay.Enabled = false;
                        txtTongNgay.Text = "";
                    }
                }
                else
                {
                    teditTuGio.Enabled = false;
                    teditDenGio.Enabled = false;
                    vTongGio.Enabled = false;
                    btnTinhGio.Enabled = false;
                    ddlDenNgay.Enabled = true;
                }

            }
            else
            {
                drchedonghi.DataSource = getPerTimeDataSource1();
                drchedonghi.DataBind();
                drchedonghi.SelectedIndex = 0;

                //Xét trường hợp đăng ký theo giờ
                if (leaveid == "DOD")
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    if (drchedonghi.Value.ToString().Equals("3"))
                    {
                        teditTuGio.Enabled = true;
                        teditDenGio.Enabled = true;
                        vTongGio.Enabled = true;
                        btnTinhGio.Enabled = true;
                        ddlDenNgay.Enabled = false;
                        txtTongNgay.Text = "";
                    }
                }
                else
                {
                    teditTuGio.Enabled = false;
                    teditDenGio.Enabled = false;
                    vTongGio.Enabled = false;
                    btnTinhGio.Enabled = false;
                    ddlDenNgay.Enabled = true;
                }
            }
        }

        private DataTable getPerTimeDataSource1()
        {
            DataTable dt = new DataTable();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select * from tblPerTime";
            dt = provider.GetDataTable();
            int count = dt.Rows.Count;
            provider.CloseConnection();
            return dt;
        }

        private DataTable getPerTimeDataSource2()
        {
            DataTable dt = new DataTable();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Select * from tblPerTime where PerTimeID <> '3'";
            dt = provider.GetDataTable();
            int count = dt.Rows.Count;
            provider.CloseConnection();
            return dt;
        }

        private DateTime getToDate(string EmployeeID)
        {
            DateTime returnDate = new DateTime();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
                    if (returnDate.Year > DateTime.Today.Year)
                        returnDate = new DateTime(DateTime.Today.Year, 12, 31);
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

            string leaveid = drLoainghi.Value.ToString();
            if (leaveid == "DOD")
            {
                if (Convert.ToInt32(drchedonghi.Value) == 3)
                {
                    //Hiện đăng ký giờ
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "show", "ShowTimeReg();", true);
                    teditTuGio.Enabled = true;
                    teditDenGio.Enabled = true;
                    vTongGio.Enabled = true;
                    btnTinhGio.Enabled = true;
                    txtTongNgay.Text = "";
                }
            }
            else
            {
                teditTuGio.Enabled = false;
                teditDenGio.Enabled = false;
                vTongGio.Enabled = false;
                btnTinhGio.Enabled = false;
            }
        }

        protected void ASPxGridView1_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            try
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                if (index < 0)
                    return;
                object id = grid.GetRowValues(index, "ID");
                object finalStatus = grid.GetRowValues(index, "FinalStatus");
                if (e.ButtonType == ColumnCommandButtonType.Delete || e.ButtonType == ColumnCommandButtonType.Edit)
                {
                    if (!IsDeleted(id.ToString()))
                        e.Visible = false;
                    else
                        e.Visible = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                Session["KeyID_Edit"] = ASPxGridView1.GetRowValues(e.VisibleIndex, "ID").ToString();
                switch (e.ButtonID)
                {
                    // Edit item
                    case "Edit":
                        LoadData_Edit(Session["KeyID_Edit"]);
                        break;

                    // Delete item
                    case "Delete":
                        // Check allow delete
                        DeleteObject(Session["KeyID_Edit"]);
                        ASPxGridView1.DataBind();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void DeleteObject(object id)
        {
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            sqlProvider.CommandText = "Delete from tblWebData where id = @id";
            sqlProvider.ParameterCollection = new string[] { "@id" };
            sqlProvider.ValueCollection = new object[] { id };
            
            sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
        }

        protected void ASPxGridView1_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            try
            {
                ASPxGridView grid = sender as ASPxGridView;
                int index = e.VisibleIndex;
                if (index < 0)
                    return;
                object id = grid.GetRowValues(index, "ID");
                object finalStatus = grid.GetRowValues(index, "FinalStatus");
                if (e.ButtonID == "Edit" || e.ButtonID == "Delete")
                {
                    if (!IsDeleted(id.ToString()))
                        e.Visible = DevExpress.Utils.DefaultBoolean.False;
                    else
                        e.Visible = DevExpress.Utils.DefaultBoolean.True; 
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}