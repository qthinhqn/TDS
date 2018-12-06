using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using conn = System.Web.Configuration;
using System.Data;

namespace NPOL
{
    public partial class F_Registration2 : System.Web.UI.Page
    {
        string validate = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            //Validate Page
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("AF_HR.aspx");
                }
                else if (Session["Role"].ToString().Substring(0, 1).Equals("M"))
                {
                    Response.Redirect("AF_Approval.aspx");
                }
                else if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("ChangePass_1st.aspx");
                }
            }
            ASPxGridView1.JSProperties["cpDeleted"] = "";
            lbMessage.Text = "";
            txtPhepTon.Text = CalculateALRemain(Session["EmployeeID"].ToString()).ToString();
        }

        protected void lbtNhapLai_Click(object sender, EventArgs e)
        {
            txtLyDo.Text = "";
            ccbNgayNghi.Text = "";
            ccbNgayNghi.Focus();
        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ID"] = ((DevExpress.Web.ASPxGridView)sender).GetMasterRowKeyValue();
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
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            try
            {
                DateTime date = Convert.ToDateTime(ccbNgayNghi.Text);
                double phepton = Convert.ToDouble(txtPhepTon.Text);
                validate = "";
                if (IsSunday(date))
                {
                    args.IsValid = false;
                    validate = "sunday";
                }
                if (IsHoliday(date))
                {
                    args.IsValid = false;
                    validate = "holiday";
                }
                if (DateTime.Compare(DateTime.Today, Convert.ToDateTime(ccbNgayNghi.Text)) > 0)
                {
                    args.IsValid = false;
                    validate = "deny";
                }
                if (!ValidateLeaveDateRange(Session["EmployeeID"].ToString(), ccbCheDoNghi.Value.ToString(), Convert.ToDateTime(ccbNgayNghi.Text), Convert.ToDateTime(ccbNgayNghi.Text)))
                {
                    args.IsValid = false;
                    validate = "duplicate";
                }
                if (phepton == 0)
                {
                    args.IsValid = false;
                    validate = "aliszero";
                }

            }
            catch
            {
                args.IsValid = true;
            }




        }

        public bool IsSunday(DateTime date)
        {
            bool returnValue = false;
            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                returnValue = true;
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
                if (!approval.Equals("w"))
                {
                    returnValue = false;
                }
            }
            sqlProvider.CloseConnection();
            return returnValue;
        }

        public bool ValidateLeaveDateRange(string EmployeeID, string PerTimeID, DateTime regStartDate, DateTime regToDate)
        {
            bool validate = true;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            sqlProvider.CommandText = "Select * from tblWebData Where EmployeeID = @EmployeeID and (FinalStatus = 'w' or FinalStatus ='A' or FinalStatus ='a')";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            DateTime existingStartDate;
            DateTime existingToDate;
            string existingPerTimeID;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    existingStartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"].ToString());
                    existingToDate = Convert.ToDateTime(dt.Rows[i]["ToDate"].ToString());
                    existingPerTimeID = dt.Rows[i]["PerTimeID"].ToString();
                    if (DateTime.Compare(existingStartDate, existingToDate) == 0)
                    {
                        if (DateTime.Compare(regStartDate, regToDate) == 0)
                        {
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0)
                            {
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                else if (existingPerTimeID.Equals(PerTimeID))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0 || DateTime.Compare(regToDate, existingStartDate) == 0)
                            {
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                else if (existingPerTimeID.Equals(PerTimeID))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {
                        if (DateTime.Compare(regStartDate, regToDate) == 0)
                        {
                            if (DateTime.Compare(regStartDate, existingStartDate) == 0 || DateTime.Compare(regStartDate, existingToDate) == 0)
                            {
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                else if (existingPerTimeID.Equals(PerTimeID))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                            else
                            {
                                DateTimeRange dtRange = new DateTimeRange();
                                dtRange.Start = existingStartDate;
                                dtRange.End = existingToDate;

                                DateTimeRange input = new DateTimeRange();
                                input.Start = regStartDate;
                                input.End = regToDate;

                                if (dtRange.Intersects(input))
                                {
                                    if (existingPerTimeID.Equals("0"))
                                    {
                                        validate = false;
                                        break;
                                    }
                                    else if (existingPerTimeID.Equals(PerTimeID))
                                    {
                                        validate = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            DateTimeRange dtRange = new DateTimeRange();
                            dtRange.Start = existingStartDate;
                            dtRange.End = existingToDate;

                            DateTimeRange input = new DateTimeRange();
                            input.Start = regStartDate;
                            input.End = regToDate;

                            if (dtRange.Intersects(input))
                            {
                                if (existingPerTimeID.Equals("0"))
                                {
                                    validate = false;
                                    break;
                                }
                                else if (existingPerTimeID.Equals(PerTimeID))
                                {
                                    validate = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            sqlProvider.CloseConnection();
            return validate;
        }
        protected void lbtDangKy_Click(object sender, EventArgs e)
        {
            string empid = "";
            DateTime regdate;
            string leaveid = "";
            DateTime startdate;
            DateTime todate;
            string pertimeid = "";
            string leavereason = "";
            string managerid_l1 = "";

            if (!IsValid)
            {
                if (validate.Equals("sunday"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.CustomValidator1.Text = "Ngày bạn chọn là Chủ Nhật";
                        }
                        else
                        {
                            this.CustomValidator1.Text = "Your choice is Sunday";
                        }
                    }
                    else
                    {
                        this.CustomValidator1.Text = "Ngày bạn chọn là Chủ Nhật";
                    }

                }
                if (validate.Equals("holiday"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.CustomValidator1.Text = "Ngày bạn chọn là ngày Lễ";
                        }
                        else
                        {
                            this.CustomValidator1.Text = "Your choice is holiday";
                        }
                    }
                    else
                    {
                        this.CustomValidator1.Text = "Ngày bạn chọn là ngày Lễ";
                    }
                }
                if (validate.Equals("deny"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.CustomValidator1.Text = "Ngày bạn chọn nhỏ hơn hiện tại";
                        }
                        else
                        {
                            this.CustomValidator1.Text = "Your choice is old day";
                        }
                    }
                    else
                    {
                        this.CustomValidator1.Text = "Ngày bạn chọn nhỏ hơn hiện tại";
                    }
                }
                if (validate.Equals("duplicate"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.CustomValidator1.Text = "Thời gian đăng ký bị trùng";
                        }
                        else
                        {
                            this.CustomValidator1.Text = "Your date range was duplicated.";
                        }
                    }
                    else
                    {
                        this.CustomValidator1.Text = "Thời gian đăng ký bị trùng";
                    }
                }
                if (validate.Equals("aliszero"))
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            this.CustomValidator1.Text = "Bạn không đủ phép tồn để đăng ký";
                        }
                        else
                        {
                            this.CustomValidator1.Text = "Not enough annually leave to register";
                        }
                    }
                    else
                    {
                        this.CustomValidator1.Text = "Bạn không đủ phép tồn để đăng ký";
                    }
                }
            }
            else
            {
                empid = Session["EmployeeID"].ToString();
                managerid_l1 = Session["MID1"].ToString();
                regdate = Convert.ToDateTime(DateTime.Today);
                leaveid = cbbLoaiNghi.Value.ToString();
                startdate = Convert.ToDateTime(ccbNgayNghi.Text);
                todate = Convert.ToDateTime(ccbNgayNghi.Text);
                pertimeid = ccbCheDoNghi.Value.ToString();
                leavereason = txtLyDo.Text;
                InsertRecord(empid, regdate, leaveid, startdate, todate, pertimeid, leavereason,managerid_l1);
                lbtNhapLai_Click(sender, e);
                this.ASPxGridView1.DataBind();
                //Cập nhật giá trị textbox phép tồn
                txtPhepTon.Text = CalculateALRemain(empid).ToString();
            }
        }

        public int InsertRecord(string EmpID, DateTime regDate, string leaveID, DateTime startDate, DateTime toDate, string perTimeID, string leaveReason, string managerid_l1)
        {
            int returnValue = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            string sql = "Insert into tblWebData (EmployeeID, RegDate, LeaveID, StartDate, ToDate, PerTimeID, LeaveReason, CheckNum, TotalDays, ManagerID_L1) ";
            sql += "Values(@EmployeeID, @RegDate, @LeaveID, @StartDate, @ToDate, @PerTimeID, @LeaveReason, @CheckNum, @TotalDays, @ManagerID_L1);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@LeaveID", "@StartDate", "@ToDate", "@PerTimeID", "@LeaveReason", "@CheckNum", "@TotalDays","@ManagerID_L1" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, leaveID, startDate, toDate, perTimeID, leaveReason, 1, 0.5, managerid_l1};
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
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
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());

            //Call sp_View_EmpALRemain_Online
            //sqlProvider.CommandText = "sp_View_EmpALRemain_Online";
            //sqlProvider.CommandType = CommandType.StoredProcedure;
            //DateTime fromDate = new DateTime(ToDate.Year, 1, 1);
            //sqlProvider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID" };
            //sqlProvider.ValueCollection = new object[] {fromDate, ToDate, EmployeeID };
            //sqlProvider.ExecuteNonQuery();


            //Lay phep ton tu table tbl_View_EmpALRemain_Online            
            sqlProvider.CommandText = "Select ALRemain from tbl_View_EmpALRemain_Online where EmployeeID = @EmployeeID";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = Convert.ToDouble(dt.Rows[0]["ALRemain"]);
            }
            sqlProvider.CloseConnection();
            return value;
        }

        public double getTotalDayOfAL(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
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

        protected void ASPxGridView1_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                ((ASPxGridView)sender).JSProperties["cpDeleted"] = CalculateALRemain(Session["EmployeeID"].ToString()).ToString();
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
            }
        }

    }
}