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
using System.IO;
using NPOL.Recruitment;
using System.Configuration;

namespace NPOL
{
    public partial class Registration_Recruit : System.Web.UI.Page
    {
        bool IsForeWarning = true;
        bool IsRepresentative = true;
        bool IsForeWarning_RegisterDate = true;

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

            //
            if (!IsPostBack)
            {
                cld_StartDate.Date = DateTime.Today;
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
                //
                if (Check_HRRecruit(Session["EmployeeID"].ToString()))
                {
                    Part6.Visible = true;
                }
                else
                {
                    Part6.Visible = false;
                }

            }
            else
            {
                Session["LineID"] = ComboBox_Line.Value;
                //UpdatePanel1.DataBind();
                ComboBox_Dep.DataBind();

                // chon nhom luong khac
                if (!opt_G5.Checked)
                {
                    //GridLookup_Other.Value = null;
                    //GridLookup_Other.Text = "";
                    txtPayrollGroupOther.Text = "";
                }
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
                // kiem tra file phe duyet
                if (!Validate_Attach_CE())
                {
                    args.IsValid = false;
                    SetErrorMessage("vAttach_CE");
                    return;
                }
                // kiem tra file mo ta cong viec
                if (!Validate_Attach_JD())
                {
                    args.IsValid = false;
                    SetErrorMessage("vAttach_JD");
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
                if (cld_StartDate.Date <= DateTime.Now.Date)
                {
                    args.IsValid = false;
                    SetErrorMessage("vStartDate_2");
                    return;
                }
                if (cld_StartDate.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    args.IsValid = false;
                    SetErrorMessage("vStartDate_3");
                    return;
                }

                // kiem tra trung
                DateTime start = cld_StartDate.Date;
                if (!Validate_DuplicateDate(txtEmpID.Text, start))
                {
                    args.IsValid = false;
                    SetErrorMessage("vDuplicate");
                    return;
                }

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
        bool Validate_Attach_CE()
        {
            bool validate = true;
            if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked)
            {
                if (!uc_Upload2.Validate())
                    validate = false;
            }
            return validate;
        }
        bool Validate_Attach_JD()
        {
            bool validate = true;
            if (opt_P1.Checked || opt_P2.Checked || opt_P3.Checked || opt_P4.Checked)
            {
                if (!uc_Upload3.Validate())
                    validate = false;
            }
            return validate;
        }
        bool Validate_Employee_Replace()
        {
            bool validate = true;
            if (opt_P5.Checked || opt_P6.Checked || opt_P7.Checked || opt_P8.Checked || opt_P9.Checked)
                if (txtEmpID_Replace.Text.Trim() == "" || txtEmpName_Replace.Text == "")
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
            sqlProvider.CommandText = "Select * from tblCand_Request_Online Where Apply_Name like @EmployeeID and convert(nvarchar(10), StartDate, 103)=convert(nvarchar(10), @StartDate, 103);";
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
            opt_G1.Checked = opt_G2.Checked = opt_G3.Checked = opt_G4.Checked = opt_G5.Checked = opt_G6.Checked = opt_G7.Checked = false;
            opt_inButget.Checked = opt_outButget.Checked = false;
            ComboBox_Pos.Text = "";
            ComboBox_Dep.Text = "";
            ComboBox_Line.Text = "";
            ComboBox_Location.Text = "";
            txtPayrollGroupOther.Text = "";
            //GridLookup_Other.Value = null;
            //GridLookup_Other.Text = "";
            txtEmpOtherID.Text = "";
            txtEmpOtherName.Text = "";

            // Part 2
            opt_P1.Checked = opt_P2.Checked = opt_P3.Checked = opt_P4.Checked =
            opt_P5.Checked = opt_P6.Checked = opt_P7.Checked = opt_P8.Checked = opt_P9.Checked = false;

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

            txtRemarks.Value = "";

            if (uc_Upload1.Validate())
                uc_Upload1.ClearTokenBox();
            uc_Upload2.ClearTokenBox();
            uc_Upload3.ClearTokenBox();
        }
        protected void btnNhapLai_Click(object sender, EventArgs e)
        {
            resetNull();
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Code insert data into database
                tblCand_Request_Online new_Obj = new tblCand_Request_Online();
                //new_Obj.EmpID_Apply = null;
                new_Obj.Apply_Name = txtEmpID.Text;
                new_Obj.RequestID = Guid.NewGuid().ToString();
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
                //if (GridLookup_Line.Value != null)
                //    new_Obj.LineID = GridLookup_Line.Value.ToString();
                //if (GridLookup_Dep.Value != null)
                //new_Obj.DepID = GridLookup_Dep.Value.ToString();
                //new_Obj.LevelID = ;
                //if (GridLookup_Pos.Value != null)
                //new_Obj.PosID = GridLookup_Pos.Value.ToString();
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
                //if (GridLookup_Location.Value != null)
                //new_Obj.LocationID = GridLookup_Location.Value.ToString();
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
                new_Obj.Requester = Session["EmployeeID"].ToString();
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
                // remarks
                new_Obj.Remarks = txtRemarks.Value.Trim();

                // INsert data
                Cand_Request_OnlineService.CreateNews(new_Obj);
                if (new_Obj.RequestID != null)
                {
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
                //string script = string.Format("alert('{0}');", "Begin add");
                //if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
                //}
                //string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccess").ToString() + "')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);
                // clean content
                string str_script = "Func('"+ Session["Lang"] + "')";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", str_script, true);
                resetNull();
            }
            else
            {
                // show validation
                lblAlert.Text = vThongBao.ErrorMessage;
                ASPxPopupControl1.ShowOnPageLoad = true;
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
                    textSalary.Text = item.Salary.ToString("#,###");
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
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
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
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpOtherID.Focus();
                }
                else if (txtEmpOtherID.Text.Trim() != "" && txtEmpOtherID.Text.Trim() == "")
                {
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertResign").ToString() + "')";
                    message = message.Replace("[]", "[" + txtEmpOtherID.Text + "]");
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
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

        protected void CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Validate Employee
            if (txtEmpID.Text.Trim() == "")
            {
                args.IsValid = false;
                return;
            }

            // Validate Line
            if (ComboBox_Line.Value == null)
            {
                args.IsValid = false;
                return;
            }
        }

        protected void GridLookup_Line_ValueChanged(object sender, EventArgs e)
        {
            ComboBox_Dep.Text = "";
        }

        protected void opt_G5_CheckedChanged(object sender, EventArgs e)
        {
            //if (opt_G5.Checked)
            //{
            //    GridLookup_Other.Enabled = true;
            //}
            //else
            //{
            //    GridLookup_Other.Enabled = false;
            //    GridLookup_Other.Text = "";
            //}
        }

        protected void btnSaveTemp_Click(object sender, EventArgs e)
        {
            tblCand_Request_Online new_Obj = new tblCand_Request_Online();
            //new_Obj.EmpID_Apply = null;
            new_Obj.Apply_Name = txtEmpID.Text;
            new_Obj.RequestID = Guid.NewGuid().ToString();
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
            //if (GridLookup_Line.Value != null)
            //    new_Obj.LineID = GridLookup_Line.Value.ToString();
            //if (GridLookup_Dep.Value != null)
            //new_Obj.DepID = GridLookup_Dep.Value.ToString();
            //new_Obj.LevelID = ;
            //if (GridLookup_Pos.Value != null)
            //new_Obj.PosID = GridLookup_Pos.Value.ToString();
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
            //if (GridLookup_Location.Value != null)
            //new_Obj.LocationID = GridLookup_Location.Value.ToString();
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
            new_Obj.Requester = Session["EmployeeID"].ToString();
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

            // remarks
            new_Obj.Remarks = txtRemarks.Value.Trim();

            // INsert data
            new_Obj.RegType = false;
            Cand_Request_OnlineService.CreateNews_Tmp(new_Obj);
            if (new_Obj.RequestID != null)
            {
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
            ////string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccessTmp").ToString() + "')";
            ////ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);
            string str_script = "Func2('" + Session["Lang"] + "')";
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", str_script, true);
            
            // clean content
            resetNull();
        }

    }
}