using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using conn = System.Web.Configuration;
using DevExpress.Web;

namespace NPOL
{
    public partial class F_Registration3 : System.Web.UI.Page
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
            //lbTieuDe.Text = GetGlobalResourceObject("F_Registration3", "tieude").ToString() + " " + DateTime.Now.Year;

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            ASPxGridView1.JSProperties["cpDeleted"] = "";
            txtPhepTon.Value = CalculateALRemain(Session["EmployeeID"].ToString());
            txtPhepbu.Value = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());

        }

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
            double result = Convert.ToDouble(txtPhepTon.Text) - CalculateLeaveDays(fromDate, toDate, perTimeID, employeeID);

            if (result < 0)
            {
                validate = false;
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

        bool Validate_OldDate(DateTime fromDate, DateTime toDate)
        {
            bool validate = true;
            //Code xu ly
            TimeSpan ts = DateTime.Today - fromDate;
            TimeSpan ts1 = DateTime.Today - toDate;
            int i = (int)ts.TotalDays;
            int j = (int)ts1.TotalDays;
            if (i > 0 || j > 0)
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
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select StartDate from tblWebdata where EmployeeID = @EmployeeID and (FinalStatus = 'w' or FinalStatus ='A' or FinalStatus ='a') and LeaveID = 'CL_OT10' order by StartDate asc";
            provider.ParameterCollection = new string[] {"@EmployeeID"};
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
                    result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate) - TotalSaturday(fromDate, toDate)) / 2;
                }
            }

            if (workday == 26)//Đi làm thứ 7
            {
                if (perTimeID.Equals("0"))
                {
                    result = TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate);
                }
                else
                {
                    result = (TotalDay(fromDate, toDate) - TotalSunday(fromDate, toDate) - TotalHoliday(fromDate, toDate)) / 2;
                }
            }

            //Trường hợp đăng ký làm thêm nghỉ bù (1-1)
            if (String.Compare(leaveid, "CL_OT10", true) == 0)
            {                
                if (perTimeID.Equals("0"))
                {
                    result = TotalDay(fromDate, toDate);
                }
                else
                {
                    result = (TotalDay(fromDate, toDate)) / 2;
                }
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
                ((ASPxGridView)sender).JSProperties["cpDeleted"] = CalculateALRemain(Session["EmployeeID"].ToString()).ToString();
                ((ASPxGridView)sender).JSProperties["cpDeletedCL"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
            }
            ASPxGridView1.SettingsText.Title = "";
        }



        public float CalculateALRemain(string EmployeeID)
        {
            float value = 0;
            DateTime todate = DateTime.Today;
            DateTime fromdate = new DateTime(DateTime.Today.Year, 1, 1);
            float tempValue = (float)(getALRemainForEmployee(fromdate, todate, EmployeeID) - getTotalDayOfAL(EmployeeID));
            if (tempValue > 0)
            {
                value = tempValue;
            }
            return value;
        }

        public double getALRemainForEmployee(DateTime FromDate, DateTime ToDate, string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());

            //Gọi sp_View_EmpALRemain_Online của Tân Đức
            //sqlProvider.CommandText = "sp_View_EmpALRemain_Online";
            sqlProvider.CommandText = "PER_sp_Rpt_LeaveReport";
            sqlProvider.CommandType = CommandType.StoredProcedure;
            DateTime fromDate = new DateTime(ToDate.Year, 1, 1);
            sqlProvider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID", "@UserID" };
            sqlProvider.ValueCollection = new object[] { fromDate, ToDate, EmployeeID, "LeaveReg" };
            sqlProvider.ExecuteNonQuery();


            //Lay phep ton tu table tbl_View_EmpALRemain_Online            
            sqlProvider.CommandText = "Select ALRemain from tbl_View_EmpALRemain_Online where EmployeeID = @EmployeeID and ComputerName = 'LeaveReg'";
            sqlProvider.CommandType = CommandType.Text;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ALRemain"].ToString() != "")
                {

                    value = (double)dt.Rows[0]["ALRemain"];
                }
                else { value = 0; }

            }
            sqlProvider.CloseConnection();
            return value;
        }

        //Tính tổng lượt phép năm chưa đồng bộ
        public double getTotalDayOfAL(string EmployeeID)
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

        //Tính tổng lượt phép nghỉ bù chưa đồng bộ
        public float getTotalDayOfCL(string EmployeeID)
        {
            float value = 0;
            double double_value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select TotalDays from tblWebData Where EmployeeID = @EmployeeID and FinalStatus='w' and LeaveID='CL'";
                sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
                sqlProvider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = sqlProvider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        double_value += (double)dt.Rows[i]["TotalDays"];
                    }
                    value = (float)double_value;
                }
            }
            catch
            {
                value = -1;
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
                        temp_returnValue += (double)dt.Rows[i]["Days"]; 
                    }                        
                }
                returnValue = (float)temp_returnValue;
            }
            catch { returnValue = -1; }
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
            }
            catch { value = -1; }
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

                    #region Trường hợp kết hôn
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

                    #region Trường hợp khác
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
                txtPhepTon.Text = CalculateALRemain(EmpID).ToString();
                txtPhepbu.Value = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                btnNhapLai_Click(sender, e);
            }

        }

        private void UpdateMailAction(string employeeid, int level)
        {
            string sql = "";
            switch (level)
            {
                case 1:
                    sql += "Update tblWebdata Set MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL Where EmployeeID = @EmployeeID";
                    break;
                case 2:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL Where EmployeeID = @EmployeeID";
                    break;
                case 3:
                    sql += "Update tblWebdata Set MailToL1 = NULL, MailToL2 = NULL, MailToL3 = 1 Where EmployeeID = @EmployeeID";
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

        public int InsertRecordWithWarning(string EmpID, DateTime regDate, string leaveID, DateTime startDate, DateTime toDate, string perTimeID, string leaveReason, int checkNum, float toTalDay, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
        {
            int returnValue = 0;
            object M1 = DBNull.Value, M2 = DBNull.Value, M3 = DBNull.Value;
            tblEmpManagerLevel eml = new tblEmpManagerLevel(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
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

                if (String.IsNullOrWhiteSpace(mid1) == false && String.IsNullOrWhiteSpace(mid2) == true && String.IsNullOrWhiteSpace(mid3) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Vui lòng kiểm tra lại tính hợp lệ của danh sách cấp phê duyệt";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Please check again approval manager list";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Vui lòng kiểm tra lại tính hợp lệ của danh sách cấp phê duyệt";
                        return;
                    }
                }


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

                if (Is_CL_After_CLOT10(EmployeeID, ToDate) == false && String.Compare(LeaveID,"CL",true) == 0)
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
                        args.IsValid = false;
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                this.vThongBao.ErrorMessage = "Bạn không đủ phép tồn để đăng ký";
                                return;
                            }
                            else
                            {
                                this.vThongBao.ErrorMessage = "Not enough annually leave to register";
                                return;
                            }
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Bạn không đủ phép tồn để đăng ký";
                            return;
                        }
                    }
                }

                if (Validate_CL(drLoainghi.Value.ToString()) == false)
                {
                    args.IsValid = false;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.vThongBao.ErrorMessage = "Bạn không đủ phép bù để đăng ký";
                            return;
                        }
                        else
                        {
                            this.vThongBao.ErrorMessage = "Not enough compensation leave to register";
                            return;
                        }
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Bạn không đủ phép bù để đăng ký";
                        return;
                    }
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
        }

        protected void drchedonghi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;
                string EmpID = Session["EmployeeID"].ToString();
                txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();

            }
        }

        protected void ddlTuNgay_DateChanged(object sender, EventArgs e)
        {
            if (!ddlTuNgay.Text.Equals("") && !ddlDenNgay.Text.Equals("") && !drchedonghi.Text.Equals(""))
            {
                DateTime FromDate = (DateTime)ddlTuNgay.Value;
                DateTime ToDate = (DateTime)ddlDenNgay.Value;
                string EmpID = Session["EmployeeID"].ToString();
                txtTongNgay.Text = CalculateLeaveDays(FromDate, ToDate, drchedonghi.Value.ToString(), EmpID).ToString();
            }
        }

        protected void ASPxGridView2_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.Equals("ApprovingStatus_L1") || e.Column.FieldName.Equals("ApprovingStatus_L2") || e.Column.FieldName.Equals("ApprovingStatus_L3") || e.Column.FieldName.Equals("HRCheckingStatus"))
            {
                if (String.IsNullOrWhiteSpace(e.Value.ToString()) == true)
                {
                    e.DisplayText = GetGlobalResourceObject("F_Registration3", "w").ToString();
                }
                else
                {
                    if (String.Compare(e.Value.ToString(), "true", true) == 0)
                    {
                        e.DisplayText = GetGlobalResourceObject("F_Registration3", "a").ToString();
                    }
                    else
                    {
                        e.DisplayText = GetGlobalResourceObject("F_Registration3", "c").ToString();
                    }
                }
            }
        }



    }
}