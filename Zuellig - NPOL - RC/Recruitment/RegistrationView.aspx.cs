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
using System.Data.OleDb;
using System.IO;

namespace NPOL
{
    public partial class RegistrationView_Recruit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
            }
            
            //Nạp dữ liệu chế độ nghỉ khi mở trang
            if (!IsPostBack)
            {
                Session["RecruitTmp"] = true;
                ASPxGridView1.DataBind();
            }
            else
            {
                if (ASPxCheckBox1.Checked)
                {
                    Session["RecruitTmp"] = false;
                }
                else
                {
                    Session["RecruitTmp"] = true;
                }
                ASPxGridView1.DataBind();
            }

            ASPxGridView1.JSProperties["cpDeleted"] = "";
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

        bool Validate_ForeWarn(DateTime fromDate)
        {
            bool validate = true;
            //Code xu ly

            if (fromDate >= DateTime.Now)
            {
                validate = false;
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

        bool Validate_DuplicateDate(DateTime fromDate, string employeeID, DateTime fromTime, DateTime toTime)
        {
            bool validate = true;
            //Code xu ly
            validate = ValidateLeaveDateRange(employeeID, fromDate, fromTime, toTime);
            return validate;
        }

        public bool ValidateLeaveDateRange(string EmployeeID, DateTime regStartDate, DateTime regFromTime, DateTime regToTime)
        {
            bool validate = true;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblRecruitApproval_Detail Where EmployeeID = @EmployeeID and StartDate=@StartDate and FromTime = @FromTime And ToTime=@ToTime";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@StartDate", "@FromTime", "@ToTime" };
            sqlProvider.ValueCollection = new object[] { EmployeeID, regStartDate, regFromTime, regToTime };
            DataTable dt = sqlProvider.GetDataTable();

            if (dt == null || dt.Rows.Count == 0)
            {
                validate = false;
            }
            sqlProvider.CloseConnection();
            return validate;
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            try
            {
                if (e.RowType != GridViewRowType.Data) return;
                string empID_Apply = e.GetValue("EmpID_Apply").ToString();
                if (String.Compare(empID_Apply, "", true) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.FromArgb(153, 255, 102);
                }
                else
                {

                }

                string duyet = e.GetValue("FinalStatus").ToString();
                if (duyet.Equals("c") || duyet.Equals("C")
                    || duyet.Equals("u") || duyet.Equals("U"))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                //if (duyet.Equals("a") || duyet.Equals("A"))
                //{
                //    e.Row.BackColor = System.Drawing.Color.Yellow;

                //}
            }
            catch(Exception ex)
            { }
        }

        public bool IsDeleted(string id)
        {
            bool returnValue = true;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblRecruitApproval_Detail Where RegID = @id";
            sqlProvider.ParameterCollection = new string[] { "@id" };
            sqlProvider.ValueCollection = new object[] { id };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = false;
            }
            sqlProvider.CloseConnection();
            return returnValue;
        }

        public void DeletedItem(string id)
        {
            try
            {
                khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
                sqlProvider.CommandText = "Delete from tblCand_Request_Online where RequestID = @RequestID";
                if (ASPxCheckBox1.Checked)
                    sqlProvider.CommandText = "Delete from tblCand_Request_Online_Tmp where RequestID = @RequestID";
                sqlProvider.ParameterCollection = new string[] { "@RequestID" };
                sqlProvider.ValueCollection = new object[] { id };
                sqlProvider.ExecuteNonQuery();
                sqlProvider.CloseConnection();
            }
            catch(Exception ex)
            {

            }
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
            else
            {
                DeletedItem(ID);
                e.Cancel = true;
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
                    e.DisplayText = GetGlobalResourceObject("RC_RegistrationView", "colFinalStatus_W").ToString();
                }

                else if (e.Value.Equals("a") || e.Value.Equals("A"))
                {
                    e.DisplayText = GetGlobalResourceObject("RC_RegistrationView", "colFinalStatus_A").ToString();
                }

                else if (e.Value.Equals("c") || e.Value.Equals("C"))
                {
                    e.DisplayText = GetGlobalResourceObject("RC_RegistrationView", "colFinalStatus_C").ToString();
                }

                else if (e.Value.Equals("s") || e.Value.Equals("S"))
                {
                    e.DisplayText = GetGlobalResourceObject("RC_RegistrationView", "colFinalStatus_S").ToString();
                }

                else if (e.Value.Equals("u") || e.Value.Equals("U"))
                {
                    e.DisplayText = GetGlobalResourceObject("RC_RegistrationView", "colFinalStatus_U").ToString();
                }
            }
        }
        protected void ASPxGridView1_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                if (!havingContract(Session["EmployeeID"].ToString(), DateTime.Today))
                {
                    //((ASPxGridView)sender).JSProperties["cpDeleted"] = "";
                    //((ASPxGridView)sender).JSProperties["cpDeletedCL"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                }
                else
                {
                    //((ASPxGridView)sender).JSProperties["cpDeleted"] = CalculateALRemain(Session["EmployeeID"].ToString()).ToString();
                    //((ASPxGridView)sender).JSProperties["cpDeletedCL"] = CalCurrentCompensationLeave(new DateTime(DateTime.Today.Year, 12, 31), Session["EmployeeID"].ToString());
                }
            }
            ASPxGridView1.SettingsText.Title = "";
        }

        //Tính tổng lượt phép năm chưa đồng bộ
        public double getTotalDayOfAL(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalDays from tblOTData Where EmployeeID = @EmployeeID and FinalStatus='a' and HRCheckingStatus is null";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    value += Convert.ToDouble(dt.Rows[i]["TotalHours"]);
                }
            }
            return value;
        }

        //Tính tổng lượt phép chưa đồng bộ
        public double getTotalDayOf_WaitSyn(string EmployeeID)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalHours from tblOTData Where EmployeeID = @EmployeeID and FinalStatus='w'";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    value += Convert.ToDouble(dt.Rows[i]["TotalHours"]);
                }
            }
            return value;
        }

        //Tính tổng lượt phép đã nghỉ & đăng ký theo loại nghỉ trong năm
        public double getTotalDayOf_ByType(string EmployeeID, int year)
        {
            double value = 0;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select TotalHours from tblOTData Where EmployeeID = @EmployeeID And Year(StartDate)=@Year And (FinalStatus='w' OR (FinalStatus='a' and HRCheckingStatus is null)) ";
            sqlProvider.CommandText += " Union ALL ";
            sqlProvider.CommandText += "Select 'TotalHours'=TotalHours from tblEmpDayOff Where EmployeeID = @EmployeeID and Year(FromDate)=@Year;";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@Year" };
            sqlProvider.ValueCollection = new object[] { EmployeeID, year };
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
        
        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["ID"] = ((DevExpress.Web.ASPxGridView)sender).GetMasterRowKeyValue();
        }
        private void UpdateMailAction(string employeeid, int level)
        {
            string sql = "";
            switch (level)
            {
                case 1:
                    sql += "Update tblOTdata Set MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL Where EmployeeID = @EmployeeID and MailToL1 is null and FinalStatus='w'";
                    break;
                case 2:
                    sql += "Update tblOTdata Set MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL Where EmployeeID = @EmployeeID and MailToL2 is null and FinalStatus='w'";
                    break;
                case 3:
                    sql += "Update tblOTdata Set MailToL1 = NULL, MailToL2 = NULL, MailToL3 = 1 Where EmployeeID = @EmployeeID and MailToL3 is null and FinalStatus='w'";
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

        public int InsertRecord(string EmpID, DateTime regDate, DateTime startDate, DateTime fromTime,  DateTime toTime, string OTReason, int checkNum, float toTalHours, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
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
            string sql = "Insert into tblOTData (EmployeeID, RegDate, StartDate, FromTime, ToTime, OTReason, CheckNum, TotalHours) ";
            sql += "Values(@EmployeeID, @RegDate, @StartDate, @FromTime, @ToTime, @OTReason, @CheckNum, @TotalHours);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@StartDate", "@FromTime", "@ToTime", "@OTReason", "@CheckNum", "@TotalHours" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, startDate, fromTime, toTime, OTReason, checkNum, toTalHours };
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
        }

        //Insert data cho trường hợp lượt vi phạm thời gian báo trước
        public int InsertRecordWithWarning(string EmpID, DateTime regDate, DateTime startDate, DateTime fromTime, DateTime toTime, string OTReason, int checkNum, float toTalHours, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
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
            string sql = "Insert into tblOTData (EmployeeID, RegDate, StartDate, FromTime, ToTime, OTReason, CheckNum, TotalHours, Warning) ";
            sql += "Values(@EmployeeID, @RegDate, @StartDate, @FromTime, @ToTime, @OTReason, @CheckNum, @TotalHours, @Warning);";
            sqlProvider.CommandText = sql;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@StartDate", "@FromTime", "@ToTime", "@OTReason", "@CheckNum", "@TotalHours", "@Warning" };
            sqlProvider.ValueCollection = new object[] { EmpID, regDate, startDate, fromTime, toTime, OTReason, checkNum, toTalHours, 1 };
            returnValue = sqlProvider.ExecuteNonQuery();
            sqlProvider.CloseConnection();
            return returnValue;
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

        protected void btnView2_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object objID = grid.GetRowValues(container.VisibleIndex, new string[] { "RequestID" });

            //Xử lý giá trị biến
            objID = (objID == null ? DBNull.Value : objID);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            gvOTList.DataSource = Recruit_ApprovalService.GetTableByid(objID.ToString());
            gvOTList.DataBind();

        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            string requestID = grid.GetRowValues(e.VisibleIndex, "RequestID").ToString();
            string empID_Apply = grid.GetRowValues(e.VisibleIndex, "EmpID_Apply").ToString();
            switch (e.ButtonID)
            {
                // edit news
                case "Edit":
                    Session["RequestID"] = requestID;
                    Session["LevelNo"] = 1;
                    if (empID_Apply != null && empID_Apply.ToString() != "")
                        ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview_2.aspx");
                    else
                        ASPxWebControl.RedirectOnCallback("~/Recruitment/DetailReview.aspx");
                    break;

                case "Print":
                    ViewRequisition wf = new ViewRequisition();
                    Session["RequestID"] = requestID;
                    ASPxWebControl.RedirectOnCallback("~/Recruitment/ViewRequisition.aspx");
                break;

                default:
                    break;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object objID = grid.GetRowValues(container.VisibleIndex, new string[] { "RequestID" });
            object empID_Apply = grid.GetRowValues(container.VisibleIndex, new string[] { "EmpID_Apply" });
            //Xử lý giá trị biến
            if (objID != null)
            {
                Session["RequestID"] = objID;
                Session["LevelNo"] = 1;
                if (empID_Apply != null && empID_Apply.ToString() != "")
                    Response.Redirect("~/Recruitment/DetailReview_2.aspx");
                else
                    Response.Redirect("~/Recruitment/DetailReview.aspx");
            }
        }

        #region Import data
        const string UploadDirectory = "~/Upload/";
        static string fullpath = "";
        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string resultFileName = Path.ChangeExtension("EmpList", resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            fullpath = resultFilePath;
            e.UploadedFile.SaveAs(resultFilePath, true);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //Clear Title Text
            ASPxGridView1.SettingsText.Title = "";

            int current = 0;
            try
            {
                //Đọc dữ liệu excel vào DataTable
                DataTable exceldata = getExelData(fullpath);
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                if (exceldata.Columns.Count == 22)
                {
                    if (exceldata.Rows.Count > 0)
                    {
                        for (int i = 0; i < exceldata.Rows.Count-1; i++)
                        {
                            current = i + 1;
                            object Apply_Name = exceldata.Rows[current][0];
                            if (Apply_Name == null || Apply_Name.ToString() == "")
                                break;
                            object SexID = exceldata.Rows[current][1];
                            object LineID = exceldata.Rows[current][2];
                            object DepID = exceldata.Rows[current][3];
                            object PosID = exceldata.Rows[current][4];
                            object LocationID = exceldata.Rows[current][5];
                            object ReportTo = exceldata.Rows[current][6];
                            object RecruitByID = exceldata.Rows[current][7];
                            object ReasonID = exceldata.Rows[current][8];
                            object isBudget = exceldata.Rows[current][9];
                            object TypeID = exceldata.Rows[current][10];
                            object EmpID_Replace = exceldata.Rows[current][11];
                            object EmpName_Replace = exceldata.Rows[current][12];
                            object ContractID = exceldata.Rows[current][13];
                            object StartDate = exceldata.Rows[current][14];
                            object ProbationID = exceldata.Rows[current][15];
                            object Probation_Sal = exceldata.Rows[current][16];
                            object Probation_Travel = exceldata.Rows[current][17];
                            object Probation_Allowance = exceldata.Rows[current][18];
                            object Permanent_Sal = exceldata.Rows[current][19];
                            object Permanent_Travel = exceldata.Rows[current][20];
                            object Permanent_Allowance = exceldata.Rows[current][21];


                            //Thêm dữ liệu vào bảng tblCand_Request_Online
                            provider.CommandText = "spRecruit_InsertEmployeeRegist_1";
                            provider.CommandType = CommandType.StoredProcedure;
                            provider.ParameterCollection = new string[] { "@Requester", "@RequestID", "@Apply_Name", "@SexID", "@LineID", "@DepID", "@PosID", "@LocationID", "@ReportTo", "@RecruitByID", "@ReasonID", "@TypeID", "@EmpID_Replace", "@EmpName_Replace", "@ContractID", "@StartDate", "@ProbationID", "@Probation_Sal", "@Probation_Travel", "@Probation_Allowance", "@Permanent_Sal", "@Permanent_Travel", "@Permanent_Allowance", "isBudget" };
                            provider.ValueCollection = new object[] { Session["EmployeeID"], Guid.NewGuid(), Apply_Name, SexID, LineID, DepID, PosID, LocationID, ReportTo, RecruitByID, ReasonID, TypeID, EmpID_Replace, EmpName_Replace, ContractID, DateTime.Parse(StartDate.ToString()), ProbationID, Probation_Sal, Probation_Travel, Probation_Allowance, Permanent_Sal, Permanent_Travel, Permanent_Allowance, isBudget };
                            provider.ExecuteNonQuery();
                        }
                    }
                }
                else if (exceldata.Columns.Count == 19)
                {
                    if (exceldata.Rows.Count > 0)
                    {
                        for (int i = 0; i < exceldata.Rows.Count; i++)
                        {
                            current = i + 1;
                            object ProAdj_Type = exceldata.Rows[current][0];
                            object EmpID_Apply = exceldata.Rows[current][1];

                            if (EmpID_Apply == null || EmpID_Apply.ToString() == "")
                                break;

                            object Apply_Name = exceldata.Rows[current][2];
                            object ReasonID = exceldata.Rows[current][3];
                            object EmpID_Replace = exceldata.Rows[current][4];
                            object EmpName_Replace = exceldata.Rows[current][5];
                            object StartDate = exceldata.Rows[current][6];
                            object Other_old = exceldata.Rows[current][7];
                            object OtherDescription = exceldata.Rows[current][8];
                            object Other_oldValue = exceldata.Rows[current][9];
                            object To_LineID = exceldata.Rows[current][10];
                            object To_DepID = exceldata.Rows[current][11];
                            object To_PosID = exceldata.Rows[current][12];
                            object To_LocationID = exceldata.Rows[current][13];
                            object Permanent_Sal = exceldata.Rows[current][14];
                            object Permanent_Travel = exceldata.Rows[current][15];
                            object Permanent_Allowance = exceldata.Rows[current][16];
                            object Other_new = exceldata.Rows[current][17];
                            object Other_newValue = exceldata.Rows[current][18];

                            //Thêm dữ liệu vào bảng tblCand_Request_Online
                            provider.CommandText = "spRecruit_InsertEmployeeRegist_2";
                            provider.CommandType = CommandType.StoredProcedure;
                            provider.ParameterCollection = new string[] { "@Requester", "@RequestID", "@ProAdj_Type", "@EmpID_Apply", "@Apply_Name", "@ReasonID", "@EmpID_Replace", "@EmpName_Replace", "@StartDate", "@Other_old", "@OtherDescription", "@Other_oldValue", "@To_LineID", "@To_DepID", "@To_PosID", "@To_LocationID", "@Permanent_Sal", "@Permanent_Travel", "@Permanent_Allowance", "@Other_new", "@Other_newValue" };
                            provider.ValueCollection = new object[] { Session["EmployeeID"], Guid.NewGuid(), ProAdj_Type, EmpID_Apply, Apply_Name, ReasonID, EmpID_Replace, EmpName_Replace, StartDate, Other_old, OtherDescription, Other_oldValue, To_LineID, To_DepID, To_PosID, To_LocationID, Permanent_Sal, Permanent_Travel, Permanent_Allowance, Other_new, Other_newValue };
                            provider.ExecuteNonQuery();
                        }
                    }
                }

                provider.CloseConnection();
                ASPxGridView1.DataBind();

            }
            catch (Exception ex)
            {
                ASPxGridView1.SettingsText.Title = "Import bị lỗi tại dòng thứ " + current.ToString() + " vì nguyên nhân: [" + ex.Message + "]";
            }
        }

        private DataTable getExelData(string path)
        {
            DataTable dt = new DataTable();
            OleDbConnection con;
            OleDbCommand com;
            OleDbDataAdapter da;
            string constring = "";

            try
            {
                constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                constring = string.Format(constring, path);

                //Tạo đối tượng OleDbConnection và mở kết nối
                con = new OleDbConnection(constring);
                con.Open();

                //Tạo và truyền tham số cho đối tượng OleDbCommand
                string query = "Select * from [{0}]";
                query = string.Format(query, "Sheet1$");
                com = new OleDbCommand(query, con);
                com.CommandTimeout = 0;

                //Tạo đối tượng OleDbDataAdapter
                da = new OleDbDataAdapter(com);

                //Tạo đối tượng Dataset để chứa dữ liệu từ Adapter
                DataSet ds = new DataSet();

                //Đổ dữ liệu vào dataset
                da.Fill(ds);

                //Đổ dữ liệu vào DataTable
                dt = ds.Tables[0];

                //Đóng kết nối
                con.Close();
            }
            catch (Exception ex)
            {
                ASPxGridView1.SettingsText.Title = ex.Message;
            }
            return dt;
        }
        #endregion

        protected void gvOTList_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

            if (e.Column.Name == "ApprovingStatusText")
            {
                object value = e.GetFieldValue("ApprovingStatusText");
                switch (value.ToString())
                {
                    case "Chờ duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Waiting";
                        }
                        break;

                    case "Không duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Rejected";
                        }
                        break;

                    case "Đã Duyệt":
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("en"))
                                e.DisplayText = "Approved";
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        protected void ASPxGridView1_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            //if (e.ButtonID == "Print")
            //{
            //    if (Check_HRRecruit(Session["EmployeeID"].ToString()))
            //    {
            //        e.Visible = DevExpress.Utils.DefaultBoolean.True;
            //    }
            //    else
            //    {
            //        e.Visible = DevExpress.Utils.DefaultBoolean.False;
            //    }
            //}
        }

        bool Check_HRRecruit(string employeeID)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tbl_RCManager_Open Where ManagerID = @EmpID And Type = 'A' And ISNULL(Status,0)=0";
            sqlProvider.ParameterCollection = new string[] { "@EmpID" };
            sqlProvider.ValueCollection = new object[] { employeeID };
            DataTable dt = sqlProvider.GetDataTable();

            if (dt == null || dt.Rows.Count == 0)
            {
                validate = false;
            }
            sqlProvider.CloseConnection();
            return validate;
        }
    }
}