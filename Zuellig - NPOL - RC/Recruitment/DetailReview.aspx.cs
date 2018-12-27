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
using NPOL.App_Code.Entities;
using System.Web.Services;
using System.Data.SqlClient;
using DevExpress.XtraRichEdit;
using System.IO;
using System.Net;
using DevExpress.Office.Services;
using DevExpress.Web.Office;
using NPOL.Recruitment;

namespace NPOL
{
    public partial class PR_DetailReview : System.Web.UI.Page
    {
        bool IsForeWarning = true;
        bool IsRepresentative = true;
        bool IsForeWarning_RegisterDate = true;
        tblCand_Request_Online item = null;
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

            // get data info
            if (Session["RecruitTmp"].ToString() == "True")
            {
                item = Cand_Request_OnlineService.GetInfoByRequestID(Session["RequestID"].ToString());
            }
            else
            {
                item = Cand_Request_OnlineService.GetInfoByRequestID_Tmp(Session["RequestID"].ToString());
            }

            if (!IsPostBack)
            {
                // Load data
                string requestID = Session["RequestID"].ToString();
                LoadData(requestID);
                ComboBox_Line.DropDownWidth = 350;
                ComboBox_Pos.DropDownWidth = 350;
                ComboBox_Dep.DropDownWidth = 350;
                ComboBox_Location.DropDownWidth = 350;
                GridLookup_Contract.GridView.Width = 250;
                //GridLookup_Other.GridView.Width = 350;

                // goi ham lay thong tin section user dang nhap
                getSection(Session["EmployeeID"].ToString());
                ComboBox_Line.DataBind();

                //xet dieu kien display phan 5: Benifit
                /*
                string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                int level = new tblRecruitData(ketnoi).GetLevel(requestID, Session["EmployeeID"]);
                switch(level)
                {
                    case 0:
                    case 1:
                        Part5.Visible = false;
                        textSalary.Visible = false;
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        Part5.Visible = true;
                        textSalary.Visible = true;
                        break;
                    default:
                        Part5.Visible = false;
                        textSalary.Visible = false;
                        break;
                }
                */
                if (Check_Benifit(Session["EmployeeID"].ToString()))
                {
                    Part5.Visible = true;
                    textSalary.Visible = true;
                }
                else
                {
                    Part5.Visible = false;
                    textSalary.Visible = false;
                }

                // kiem tra dieu kien edit
                if (Session["RecruitTmp"].ToString() == "True")
                {
                    if (Check_Edit(Session["EmployeeID"].ToString(), Session["RequestID"].ToString()))
                    {
                        btnDangKy.Visible = true;
                    }
                    else
                    {
                        btnDangKy.Visible = false;
                    }
                }
                //
                if (Check_HRRecruit(Session["EmployeeID"].ToString()))
                {
                    uc_Upload1.Visible = true;
                    uc_Upload2.Visible = true;
                    uc_Upload3.Visible = true;
                }
                else
                {
                    uc_Upload1.Visible = false;
                }
                loadAttach();
            }

            //update title
            if (!btnDangKy.Visible)
                lbTieuDe.Text = lbTieuDe.Text.Replace("EDIT", "REVIEW").Replace("SỬA", "XEM");
        }

        bool Check_Edit(string employeeID, string regID)
        {
            bool validate = false;
            uc_Upload2.Visible = false;
            uc_Upload3.Visible = false;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "SELECT * FROM [dbo].[vRecruit_Status] WHERE RequestID = @RegID";
            sqlProvider.CommandType = CommandType.Text;
            sqlProvider.ParameterCollection = new string[] { "@RegID" };
            sqlProvider.ValueCollection = new object[] { regID };
            DataTable dt = sqlProvider.GetDataTable();

            if (dt == null || dt.Rows.Count == 0)
            {
                validate = false;
            }
            else
            {
                object _Requester = dt.Rows[0]["Requester"];
                object _ManagerID_L1 = dt.Rows[0]["ManagerID_L1"];
                object _HR_Recruit = dt.Rows[0]["HR_Recruit"];
                object _HR_Manager = dt.Rows[0]["HR_Manager"];
                object _DirectorID = dt.Rows[0]["DirectorID"];
                object _ApprovingStatus_L1 = dt.Rows[0]["ApprovingStatus_L1"];
                object _HR_Recruit_Status = dt.Rows[0]["HR_Recruit_Status"];
                object _HR_Manager_Status = dt.Rows[0]["HR_Manager_Status"];
                object _DirectorID_Status = dt.Rows[0]["DirectorID_Status"];
                object _FinalStatus = dt.Rows[0]["FinalStatus"];

                // neu la user tao yeu cau
                if (_Requester != null && _Requester.ToString() == employeeID)
                {
                    txtRemarks.Attributes.Remove("readonly");
                    if (Check_HRRecruit(employeeID))
                    {
                        validate = true;
                        uc_Upload2.Visible = true;
                        uc_Upload3.Visible = true;
                    }
                    else
                    {
                        if ((_ApprovingStatus_L1 != DBNull.Value && (bool)_ApprovingStatus_L1) ||
                            (_HR_Recruit_Status != DBNull.Value && (bool)_HR_Recruit_Status) ||
                            (_HR_Manager_Status != DBNull.Value && (bool)_HR_Manager_Status) ||
                            (_DirectorID_Status != DBNull.Value && (bool)_DirectorID_Status))
                        {
                            validate = false;
                            txtRemarks.Attributes.Add("readonly", "true");
                        }
                        else
                        {
                            validate = true;
                            uc_Upload2.Visible = true;
                            uc_Upload3.Visible = true;
                        }
                    }
                }
                else
                {
                    txtRemarks.Attributes.Add("readonly", "true");
                    // xet da dong bo chua
                    if (_FinalStatus != DBNull.Value && (_FinalStatus.ToString() == "s" || _FinalStatus.ToString() == "u" || _FinalStatus.ToString() == "c"))
                        validate = false;
                    else
                        validate = true;
                }
                /*
                // neu la hr tuyen dung
                else if (_HR_Recruit != null && _HR_Recruit.ToString() == employeeID)
                {
                    if (_ApprovingStatus_L1 != null || _HR_Recruit_Status != null || _HR_Manager_Status != null || _DirectorID_Status != null)
                    {
                        validate = false;
                    }
                    else
                    {
                        validate = true;
                    }
                }
                // neu la L2
                else if (_ManagerID_L1 != null && _ManagerID_L1.ToString() == employeeID)
                {
                    if (_ApprovingStatus_L1 != null || _HR_Manager_Status != null || _DirectorID_Status != null)
                    {
                        validate = false;
                    }
                    else
                    {
                        validate = true;
                    }
                }
                // neu la hr director
                else if (_HR_Manager != null && _HR_Manager.ToString() == employeeID)
                {
                    if (_HR_Manager_Status != null || _DirectorID_Status != null)
                    {
                        validate = false;
                    }
                    else
                    {
                        validate = true;
                    }
                }
                // neu la genaral director
                else if (_DirectorID != null && _DirectorID.ToString() == employeeID)
                {
                    if (_DirectorID_Status != null)
                    {
                        validate = false;
                    }
                    else
                    {
                        validate = true;
                    }
                }
                 * */
            }
            sqlProvider.CloseConnection();
            return validate;
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
        public void getSection(string EmployeeID)
        {
            try
            {
                string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                tblRecruitData obj = new tblRecruitData(ketnoi);
                if (obj.isHRRecruitment(EmployeeID))
                {
                    Session["SectionID"] = "%";
                }
                else
                {
                    khSqlServerProvider provider = new khSqlServerProvider(ketnoi);
                    provider.CommandText = "Declare @curr datetime = Getdate(); select * from dbo.udfTbl_EmpDep (@curr, @curr) where empid =@EmployeeID";
                    provider.ParameterCollection = new string[] { "@EmployeeID" };
                    provider.ValueCollection = new object[] { EmployeeID };
                    DataTable dt = provider.GetDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        Session["SectionID"] = dt.Rows[0]["SectionID"];
                    }
                    else
                    {
                        Session["SectionID"] = null;
                    }
                    provider.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("ErrorPage.aspx");
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        bool Check_Benifit(string employeeID)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "spRC_CheckBenifit";
            sqlProvider.CommandType = CommandType.StoredProcedure;
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

        private void LoadData(string requestID)
        {
            try
            {
                if (item != null)
                {
                    // part 1
                    txtEmpID.Text = item.Apply_Name;
                    ComboBox_Line.Value = item.LineID;
                    Session["LineID"] = ComboBox_Line.Value;
                    //UpdatePanel1.DataBind();
                    ComboBox_Dep.DataBind();
                    ComboBox_Pos.Value = item.PosID;
                    ComboBox_Dep.Value = item.DepID;
                    ComboBox_Location.Value = item.LocationID;
                    txtEmpOtherID.Text = item.ReportTo;
                    txtEmpOtherID_TextChanged(txtEmpOtherID, null);

                    if (item.SexID == "F")
                        opt_Female.Checked = true;
                    else
                        opt_Male.Checked = true;
                    //item.RecruitByID
                    if (item.SectionID == "ZPV")
                        opt_G1.Checked = true;
                    else if (item.SectionID == "ZPS")
                        opt_G2.Checked = true;
                    else if (item.SectionID == "Sang")
                        opt_G3.Checked = true;
                    else if (item.SectionID == "Phyto")
                        opt_G4.Checked = true;
                    else if (item.SectionID == "Metro")
                        opt_G6.Checked = true;
                    else if (item.SectionID == "Casual")
                        opt_G7.Checked = true;
                    else if (item.SectionID != "")
                    {
                        opt_G5.Checked = true;
                        txtPayrollGroupOther.Text = item.SectionID;
                        //GridLookup_Other.Value = item.SectionID;
                    }

                    // part 2
                    if (item.ReasonID == "New")
                    {
                        if (item.TypeID == "Full")
                            opt_P1.Checked = true;
                        else if (item.TypeID == "Upgrade")
                            opt_P2.Checked = true;
                        else if (item.TypeID == "Casual")
                            opt_P3.Checked = true;
                        else if (item.TypeID == "Part")
                            opt_P4.Checked = true;

                        if (item.IsBudgetHead != null)
                        {
                            if (item.IsBudgetHead == true)
                                opt_inButget.Checked = true;
                            else
                                opt_outButget.Checked = true;
                        }
                    }
                    else if (item.ReasonID == "Replace")
                    {
                        if (item.TypeID == "Full")
                            opt_P5.Checked = true;
                        else if (item.TypeID == "Upgrade")
                            opt_P6.Checked = true;
                        else if (item.TypeID == "Casual")
                            opt_P7.Checked = true;
                        else if (item.TypeID == "Part")
                            opt_P8.Checked = true;
                        else if (item.TypeID == "Maternity")
                            opt_P9.Checked = true;
                    }

                    // part 3
                    txtEmpID_Replace.Text = item.EmpID_Replace;
                    txtEmpID_Replace_TextChanged(txtEmpID_Replace, null);

                    // part 4
                    if (item.ProbationID != null)
                        if (item.ProbationID == "")
                            chk4_1.Checked = true;
                        else if (item.ProbationID == "01")
                            chk4_2.Checked = true;
                        else if (item.ProbationID == "08")
                            chk4_3.Checked = true;

                    if (item.ContractID != null)
                        GridLookup_Contract.Value = item.ContractID;

                    if (item.StartDate != null)
                        cld_StartDate.Date = item.StartDate.Value;

                    // part 5
                    TextBox10.Text = item.Probation_Sal.ToString("#,###");
                    TextBox11.Text = item.Permanent_Sal.ToString("#,###");
                    TextBox12.Text = item.Probation_Travel.ToString("#,###");
                    TextBox13.Text = item.Permanent_Travel.ToString("#,###");
                    TextBox14.Text = item.Probation_Allowance.ToString("#,###");
                    TextBox15.Text = item.Permanent_Allowance.ToString("#,###");

                    TextBox1.Text = item.Other_old.ToString();
                    TextBox2.Text = item.Other_new.ToString();
                    TextBox3.Text = item.Other_oldValue.ToString();
                    TextBox4.Text = item.Other_newValue.ToString();

                    // remark
                    txtRemarks.Value = item.Remarks;
                }
            }
            catch (Exception ex)
            {

            }
        }


        #region Kiểm tra xem nhân viên có cấp duyệt chưa
        private bool havingManager(string EmployeeID, DateTime View)
        {
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Select * from tblOTManagerLevel Where EmployeeID=@EmpID AND Isnull(ManagerID_L1,'') not like N'';";
                provider.ParameterCollection = new string[] { "@thamso", "@EmpID" };
                provider.ValueCollection = new object[] { View, EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    validate = true;
                }
            }
            catch { }
            provider.CloseConnection();
            return validate;
        }
        #endregion

        #region Validate
        private void SetErrorMessage(string vError)
        {
            this.vThongBao.ErrorMessage = GetGlobalResourceObject("RC_Registration", vError).ToString();
        }
        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            IsForeWarning = true;
            args.IsValid = true;
            try
            {
                // kiem tra chon Nhan vien dieu chinh
                if (txtEmpID.Text.Trim() == "")
                {
                    args.IsValid = false;
                    //SetErrorMessage("vEmployee");
                    return;
                }
                // kiem tra chon gioi tinh
                if (!opt_Male.Checked && !opt_Female.Checked)
                {
                    args.IsValid = false;
                    SetErrorMessage("vGender");
                    return;
                }
                // kiem tra chon nhom luong
                if (!Validate_Payroll_Checked())
                {
                    args.IsValid = false;
                    SetErrorMessage("vPayroll");
                    return;
                }
                if (opt_G5.Checked && txtPayrollGroupOther.Text.Trim() == "")
                //if (opt_G5.Checked && GridLookup_Other.Value == null)
                {
                    args.IsValid = false;
                    SetErrorMessage("vPayroll_Other");
                    return;
                }
                // kiem tra chon vi tri
                if (!Validate_Position())
                {
                    args.IsValid = false;
                    SetErrorMessage("vPosition");
                    return;
                }
                // kiem tra ngan sach
                if (!Validate_Butget())
                {
                    args.IsValid = false;
                    SetErrorMessage("vButget");
                    return;
                }
                // kiem tra chon Nhan vien thay the
                if (!Validate_Employee_Replace())
                {
                    args.IsValid = false;
                    SetErrorMessage("vEmployee_Replace");
                    return;
                }
                // kiem tra chon loai hop dong
                if (!Validate_Promotion())
                {
                    args.IsValid = false;
                    SetErrorMessage("vPromotionType");
                    return;
                }
                // kiem tra chon loai hop dong
                if (!Validate_CasualContract())
                {
                    args.IsValid = false;
                    SetErrorMessage("vPromotionType_2");
                    return;
                }
                // kiem tra ngay hieu luc
                if (cld_StartDate.Date == null)
                {
                    args.IsValid = false;
                    SetErrorMessage("vStartDate");
                    return;
                }
                //if (cld_StartDate.Date < DateTime.Now.Date)
                //{
                //    args.IsValid = false;
                //    SetErrorMessage("vStartDate_2");
                //    return;
                //}
                if (cld_StartDate.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    args.IsValid = false;
                    SetErrorMessage("vStartDate_3");
                    return;
                }

                //// kiem tra trung
                //DateTime start = cld_StartDate.Date;
                //if (!Validate_DuplicateDate(txtEmpID.Text, start))
                //{
                //    args.IsValid = false;
                //    SetErrorMessage("vDuplicate");
                //    return;
                //}

            }
            catch (Exception ex)
            {
                //Phải set true để lưới không bị bắt validate
                args.IsValid = true;
            }

        }
        /*
        bool Validate_Employee()
        {
            bool validate = true;
            if (GridLookup_EmpID.Value == null || GridLookup_EmpID.Value.ToString() == "")
            {
                validate = false;
            }

            return validate;
        }
        */
        bool Validate_Payroll_Checked()
        {
            bool validate = true;
            if (opt_G1.Checked || opt_G2.Checked || opt_G3.Checked || opt_G4.Checked || opt_G5.Checked || opt_G6.Checked || opt_G7.Checked)
            {
                validate = true;
            }
            else
            {
                validate = false;
            }
            return validate;
        }
        bool Validate_Position()
        {
            bool validate = true;
            if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked ||
                opt_P5.Checked || opt_P6.Checked || opt_P7.Checked || opt_P8.Checked || opt_P9.Checked)
            { }
            else
            {
                validate = false;
            }
            return validate;
        }
        bool Validate_Butget()
        {
            bool validate = true;
            if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked)
            {
                if (opt_inButget.Checked == false & opt_outButget.Checked == false)
                    validate = false;
            }
            return validate;
        }
        bool Validate_Employee_Replace()
        {
            bool validate = true;
            if (opt_P5.Checked || opt_P6.Checked || opt_P7.Checked || opt_P8.Checked || opt_P9.Checked)
                if (txtEmpID_Replace.Text.Trim() == "")
                {
                    validate = false;
                }
            return validate;
        }

        bool Validate_Promotion()
        {
            bool validate = true;
            if (chk4_1.Checked || chk4_2.Checked || chk4_3.Checked)
            { }
            else
            {
                validate = false;
            }
            return validate;
        }

        bool Validate_CasualContract()
        {
            bool validate = true;
            if (opt_P1.Checked || opt_P2.Checked || opt_P5.Checked || opt_P6.Checked)
            { }
            else
            {
                if (GridLookup_Contract.Value == null)
                    validate = false;
            }
            return validate;
        }

        bool Validate_DuplicateDate(string employeeID, DateTime startDate)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblCand_Request_Online Where Apply_Name = @EmployeeID and convert(nvarchar(10), StartDate, 103)=convert(nvarchar(10), @StartDate, 103);";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@StartDate" };
            sqlProvider.ValueCollection = new object[] { employeeID, startDate };
            DataTable dt = sqlProvider.GetDataTable();

            if (dt == null || dt.Rows.Count == 0)
            {
                validate = true;
            }
            sqlProvider.CloseConnection();
            return validate;
        }

        #endregion

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
            //provider.ExecuteNonQuery();
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


        private void GetEmployeeInfo(string input)
        {
            DataTable dt = null;
            // get info
            dt = Cand_Request_OnlineService.GetEmpInfoByid(input);
            //Binding TextBox From dataTable 
            if (dt != null && dt.Rows.Count == 1)
            {
                txtEmpID.Text = input.ToUpper();
                //txtPos.Text = dt.Rows[0]["PosName"].ToString();
                //txtLine.Text = dt.Rows[0]["LineName"].ToString();
                //txtDep.Text = dt.Rows[0]["DepName"].ToString();
                //txtLocation.Text = dt.Rows[0]["LocationName"].ToString();

            }
            else
            {
                txtEmpID.Text = "";
                ComboBox_Pos.Text = "";
                ComboBox_Dep.Text = "";
                ComboBox_Line.Text = "";
                ComboBox_Location.Text = "";

            }
        }

        #region Submit & Reset
        private void resetNull()
        {
            // Part 1
            txtEmpID.Text = "";
            opt_Male.Checked = opt_Female.Checked = false;
            txtEmpOtherID.Text = "";
            opt_G1.Checked = opt_G2.Checked = opt_G3.Checked = opt_G4.Checked = opt_G5.Checked = opt_G6.Checked = opt_G7.Checked = false;
            ComboBox_Pos.Text = "";
            ComboBox_Line.Text = "";
            ComboBox_Dep.Text = "";
            ComboBox_Location.Text = "";

            // Part 2
            opt_P1.Checked = opt_P2.Checked = opt_P3.Checked = opt_P4.Checked =
            opt_P5.Checked = opt_P6.Checked = opt_P7.Checked = opt_P8.Checked = opt_P9.Checked = false;
            opt_inButget.Checked = opt_outButget.Checked = false;

            // Part 3
            txtEmpID_Replace.Text = "";
            txtEmpName_Replace.Text = "";

            // Part 4
            chk4_1.Checked = chk4_2.Checked = chk4_3.Checked = false;
            cld_StartDate.Date = DateTime.Now;
            GridLookup_Contract.Value = null;
            GridLookup_Contract.Text = "";

            // Part 5
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
        }
        protected void btnThoat_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (IsValid && item != null)
            {
                //Code insert data into database
                tblCand_Request_Online new_Obj = new tblCand_Request_Online();
                //new_Obj.EmpID_Apply = null;
                new_Obj.Apply_Name = txtEmpID.Text;
                new_Obj.RequestID = item.RequestID;
                new_Obj.DateID = DateTime.Now;
                //new_Obj.ReceivedDate = ;
                //new_Obj.DeadLine = ;
                //new_Obj.FinalDate = ;
                //new_Obj.RecruitByID = ;
                if (opt_G1.Checked)
                    new_Obj.SectionID = "ZPV";
                else if (opt_G2.Checked)
                    new_Obj.SectionID = "ZPS";
                else if (opt_G3.Checked)
                    new_Obj.SectionID = "Sang";
                else if (opt_G4.Checked)
                    new_Obj.SectionID = "Phyto";
                else if (opt_G6.Checked)
                    new_Obj.SectionID = "Metro";
                else if (opt_G7.Checked)
                    new_Obj.SectionID = "Casual";
                else if (opt_G5.Checked)
                {
                    new_Obj.SectionID = txtPayrollGroupOther.Text.Trim();
                    //if (GridLookup_Other.Value != null)
                    //    new_Obj.SectionID = GridLookup_Other.Value.ToString();
                }
                //if (ComboBox_Line.Value != null)
                //    new_Obj.LineID = ComboBox_Line.Value.ToString();
                //if (ComboBox_Dep.Value != null)
                //new_Obj.DepID = ComboBox_Dep.Value.ToString();
                //new_Obj.LevelID = ;
                //if (ComboBox_Pos.Value != null)
                //new_Obj.PosID = ComboBox_Pos.Value.ToString();
                //new_Obj.RegionID = ;
                //new_Obj.Numof = ;
                if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked)
                {
                    new_Obj.ReasonID = "New";
                    if (opt_P1.Checked == true)
                        new_Obj.TypeID = "Full";
                    else if (opt_P2.Checked == true)
                        new_Obj.TypeID = "Upgrade";
                    else if (opt_P3.Checked == true)
                        new_Obj.TypeID = "Casual";
                    else if (opt_P4.Checked == true)
                        new_Obj.TypeID = "Part";
                }
                else
                {
                    new_Obj.ReasonID = "Replace";
                    if (opt_P5.Checked == true)
                        new_Obj.TypeID = "Full";
                    else if (opt_P6.Checked == true)
                        new_Obj.TypeID = "Upgrade";
                    else if (opt_P7.Checked == true)
                        new_Obj.TypeID = "Casual";
                    else if (opt_P8.Checked == true)
                        new_Obj.TypeID = "Part";
                    else if (opt_P9.Checked == true)
                        new_Obj.TypeID = "Maternity";
                    if (txtEmpID_Replace.Text.Trim() != "")
                        new_Obj.EmpID_Replace = txtEmpID_Replace.Text.Trim();
                }
                // check butget
                if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked)
                {
                    if (opt_inButget.Checked == true)
                        new_Obj.IsBudgetHead = true;
                    else if (opt_outButget.Checked == true)
                        new_Obj.IsBudgetHead = false;
                }
                //new_Obj.EmpReplace_Sal = ;
                //new_Obj.EmpReplace_Allowance = ;
                //new_Obj.IsInternalPost = ;
                //if (ComboBox_Location.Value != null)
                //new_Obj.LocationID = ComboBox_Location.Value.ToString();
                if (opt_Male.Checked)
                    new_Obj.SexID = "M";
                else
                    new_Obj.SexID = "F";
                //new_Obj.JobDes = ;
                //new_Obj.JobDes_File = ;
                //new_Obj.IsBudgetHead = ;
                new_Obj.StartDate = cld_StartDate.Date;
                // ProbationID
                {
                    if (chk4_1.Checked)
                        new_Obj.ProbationID = "";
                    else if (chk4_2.Checked)
                        new_Obj.ProbationID = "01";
                    else if (chk4_3.Checked)
                        new_Obj.ProbationID = "08";
                    new_Obj.ContractID = null;
                }
                if (opt_P3.Checked || opt_P4.Checked || opt_P7.Checked || opt_P8.Checked || opt_P9.Checked)
                {
                    if (GridLookup_Contract.Value != null)
                        new_Obj.ContractID = GridLookup_Contract.Value.ToString();
                }

                if (TextBox10.Text != "")
                    new_Obj.Probation_Sal = double.Parse(TextBox10.Text.Replace(",", "").Replace(".", ""));
                if (TextBox12.Text != "")
                    new_Obj.Probation_Travel = double.Parse(TextBox12.Text.Replace(",", "").Replace(".", ""));
                if (TextBox14.Text != "")
                    new_Obj.Probation_Allowance = double.Parse(TextBox14.Text.Replace(",", "").Replace(".", ""));
                if (TextBox11.Text != "")
                    new_Obj.Permanent_Sal = double.Parse(TextBox11.Text.Replace(",", "").Replace(".", ""));
                if (TextBox13.Text != "")
                    new_Obj.Permanent_Travel = double.Parse(TextBox13.Text.Replace(",", "").Replace(".", ""));
                if (TextBox15.Text != "")
                    new_Obj.Permanent_Allowance = double.Parse(TextBox15.Text.Replace(",", "").Replace(".", ""));
                new_Obj.Requester = item.Requester;
                new_Obj.ReportTo = txtEmpOtherID.Text;
                //new_Obj.ApprovedBy = ;
                //new_Obj.ApprovedDate = ;
                //new_Obj.HRDept_Note = ;
                //new_Obj.ContractID = ;
                //new_Obj.EmpID_Other = ;
                if (ComboBox_Line.Value != null)
                    new_Obj.LineID = ComboBox_Line.Value.ToString();
                if (ComboBox_Dep.Value != null)
                    new_Obj.DepID = ComboBox_Dep.Value.ToString();
                if (ComboBox_Pos.Value != null && ComboBox_Pos.Value.ToString() != "")
                    new_Obj.PosID = ComboBox_Pos.Value.ToString();
                if (ComboBox_Location.Value != null)
                    new_Obj.LocationID = ComboBox_Location.Value.ToString();

                // moi them 12.01
                if (TextBox1.Text.Trim() != "")
                    new_Obj.Other_old = TextBox1.Text;
                if (TextBox2.Text.Trim() != "")
                    new_Obj.Other_new = TextBox2.Text;
                if (TextBox3.Text.Trim() != "")
                    new_Obj.Other_oldValue = TextBox3.Text;
                if (TextBox4.Text.Trim() != "")
                    new_Obj.Other_newValue = TextBox4.Text;
                // Remark
                new_Obj.Remarks = txtRemarks.Value;

                // Update data
                if (Session["RecruitTmp"].ToString() == "True")
                {
                    Cand_Request_OnlineService.UpdateNews(new_Obj);

                    if (uc_Upload2.Validate())
                    {
                        uc_Upload2.Submit_Attach(new_Obj.RequestID, "CE");
                    }
                    if (uc_Upload3.Validate())
                    {
                        uc_Upload3.Submit_Attach(new_Obj.RequestID, "JD");
                    }
                    if (uc_Upload1.Validate())
                    {
                        uc_Upload1.Submit_Attach(new_Obj.RequestID, "AF");
                    }
                }
                else
                {
                    new_Obj.RequestID = Guid.NewGuid().ToString();
                    // Insert data
                    Cand_Request_OnlineService.CreateNews(new_Obj);

                    if (new_Obj.RequestID != null)
                    {
                        // cap nhat file attach
                        UpdateAttachment(Session["RequestID"].ToString(), new_Obj.RequestID);
                        if (uc_Upload2.Validate())
                        {
                            uc_Upload2.Submit_Attach(new_Obj.RequestID, "CE");
                        }
                        if (uc_Upload3.Validate())
                        {
                            uc_Upload3.Submit_Attach(new_Obj.RequestID, "JD");
                        }
                        if (uc_Upload1.Validate())
                        {
                            uc_Upload1.Submit_Attach(new_Obj.RequestID, "AF");
                        }
                        // delete dl tam
                        DeletedItem(Session["RequestID"].ToString());
                    }
                }

                string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccess").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);

                // return
                //Response.Redirect(Request.UrlReferrer.AbsoluteUri);
                if (item.Requester == Session["EmployeeID"].ToString())
                    Response.Redirect("~/Recruitment/RegistrationView.aspx");
                else
                    Response.Redirect("~/Recruitment/Approval.aspx");
                //Response.Redirect("~/Recruitment/RegistrationView.aspx");
            }
            else
            {
                // show validation
                lblAlert.Text = vThongBao.ErrorMessage;
                ASPxPopupControl1.ShowOnPageLoad = true;
            }
        }

        public void DeletedItem(string id)
        {
            try
            {
                khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
                sqlProvider.CommandText = "Delete from tblCand_Request_Online_Tmp where RequestID = @RequestID";
                sqlProvider.ParameterCollection = new string[] { "@RequestID" };
                sqlProvider.ValueCollection = new object[] { id };
                sqlProvider.ExecuteNonQuery();
                sqlProvider.CloseConnection();
            }
            catch (Exception ex)
            {

            }
        }

        public void UpdateAttachment(string old_id, string new_id)
        {
            try
            {
                khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
                sqlProvider.CommandText = "UPDATE tbl_Attachment_RC SET RequestID=@New_RequestID where RequestID = @Old_RequestID";
                sqlProvider.ParameterCollection = new string[] { "@Old_RequestID", "@New_RequestID" };
                sqlProvider.ValueCollection = new object[] { old_id, new_id };
                sqlProvider.ExecuteNonQuery();
                sqlProvider.CloseConnection();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        protected void txtEmpID_Replace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                //txtEmpName_Replace.Text = kh.getEmployeeName(txtEmpID_Replace.Text.Trim()); ;
                Employee_Info item = EmployeeService.GetAttachmentById(txtEmpID_Replace.Text.Trim());
                if (opt_P9.Checked)
                {
                    textMaternity.Visible = true;
                }
                else
                {
                    textMaternity.Visible = false;
                }
                if (item != null)
                {
                    txtEmpName_Replace.Text = item.EmployeeName;
                    if (item.LeftDate != null)
                    {
                        opt3_1.Checked = false;
                        opt3_2.Checked = true;
                        textLeftDate.Text = item.LeftDate.Value.ToString("dd/MM/yyyy");
                        textLeftDate.Visible = true;
                    }
                    else
                    {
                        opt3_1.Checked = true;
                        opt3_2.Checked = false;
                        textLeftDate.Text = "";
                        textLeftDate.Visible = false;
                    }
                    // Load tt luong theo tung quan ly
                    if (EmployeeService.CheckViewSalary_EmpReplace(txtEmpID_Replace.Text.Trim(), Session["EmployeeID"].ToString()))
                        textSalary.Text = item.Salary.ToString("#,###");
                    else
                        textSalary.Text = "";
                    if (item.MaternityDate == null)
                    {
                        textMaternity.Text = "";
                    }
                    else
                    {
                        textMaternity.Text = item.MaternityDate.Value.ToString("dd/MM/yyyy");
                    }
                }
                else
                {
                    opt3_1.Checked = false;
                    opt3_2.Checked = false;
                    textLeftDate.Text = "";
                    textMaternity.Text = "";
                    textSalary.Text = "";

                    if (txtEmpID_Replace.Text.Trim() != "")
                    {
                        txtEmpOtherName.Text = "";
                        string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertNull").ToString() + "')";
                        message = message.Replace("[]", "[" + txtEmpID_Replace.Text + "]");
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                        txtEmpID_Replace.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                txtEmpName_Replace.Text = "";
            }
        }

        protected void txtEmpOtherID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                txtEmpOtherName.Text = kh.getWorkingEmployeeName(txtEmpOtherID.Text.Trim());
                if (txtEmpOtherID.Text.Trim() != "" && txtEmpOtherID.Text.Trim() == txtEmpOtherName.Text)
                {
                    txtEmpOtherName.Text = "";
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertNull").ToString() + "')";
                    message = message.Replace("[]", "[" + txtEmpOtherID.Text + "]");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpOtherID.Focus();
                }
                else if (txtEmpOtherID.Text.Trim() != "" && txtEmpOtherID.Text.Trim() == "")
                {
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertResign").ToString() + "')";
                    message = message.Replace("[]", "[" + txtEmpOtherID.Text + "]");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpOtherID.Focus();
                }
            }
            catch (Exception ex)
            {
                txtEmpOtherName.Text = "";
            }
        }

        [WebMethod]
        public static string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT PosName, PosID from tblRef_Position where PosName like @SearchText + '%'";
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["PosName"], sdr["PosID"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }

        protected void GridLookup_Line_ValueChanged(object sender, EventArgs e)
        {
            Session["LineID"] = ComboBox_Line.Value;
            UpdatePanel1.DataBind();
            ComboBox_Dep.DataBind();
            ComboBox_Dep.Text = "";
        }

        public void loadAttach()
        {
            if (item.RequestID != null)
            {
                DataTable dt = Attachment_RCService.GetTableByNewsid(item.RequestID);
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["AttachType"].ToString() == "CE")
                        {
                            HiddenField.Value = r["ID"].ToString();
                            LinkButton1.Text = r["AttachmentName"].ToString();
                        }
                        else if (r["AttachType"].ToString() == "JD")
                        {
                            HiddenField1.Value = r["ID"].ToString();
                            LinkButton2.Text = r["AttachmentName"].ToString();
                        }
                        else if (r["AttachType"].ToString() == "AF")
                        {
                            HiddenField2.Value = r["ID"].ToString();
                            LinkButton3.Text = r["AttachmentName"].ToString();
                        }
                    }
                }
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                object id = HiddenField.Value;
                if (id != null)
                {
                    tbl_Attachment_RC obj = Attachment_RCService.GetAttachmentById(int.Parse(id.ToString()));
                    if (obj != null)
                    {
                        //Utility.Download_A_File(obj.AttachmentPath.Replace("Recruitment/", "") + @"/" + obj.AttachmentName, obj.AttachmentName);
                        Response.Redirect("FileDownloadHandler.ashx?id=" + id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                object id = HiddenField1.Value;
                if (id != null)
                {
                    tbl_Attachment_RC obj = Attachment_RCService.GetAttachmentById(int.Parse(id.ToString()));
                    if (obj != null)
                    {
                        //Utility.Download_A_File(obj.AttachmentPath.Replace("Recruitment/", "") + @"/" + obj.AttachmentName, obj.AttachmentName);
                        Response.Redirect("FileDownloadHandler.ashx?id=" + id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                object id = HiddenField2.Value;
                if (id != null)
                {
                    tbl_Attachment_RC obj = Attachment_RCService.GetAttachmentById(int.Parse(id.ToString()));
                    if (obj != null)
                    {
                        //Utility.Download_A_File(obj.AttachmentPath.Replace("Recruitment/", "") + @"/" + obj.AttachmentName, obj.AttachmentName);
                        Response.Redirect("FileDownloadHandler.ashx?id=" + id.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}