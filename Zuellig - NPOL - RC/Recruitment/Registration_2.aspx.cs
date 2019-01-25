using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using conn = System.Web.Configuration;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;

namespace NPOL
{
    public partial class Registration_Promotion : System.Web.UI.Page
    {
        bool IsForeWarning = true;
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

            }

            // hide phan thong tin dieu chinh
            if (chk1_1.Checked)
            {
                ddl_Line.Visible = true;
                ddl_Dep.Visible = true;
                ddl_Pos.Visible = true;
                ddl_Location.Visible = true;
                txtBasicSal_new.Visible = true;
                txtTransAllow_new.Visible = true;
                txtOtherAllow_new.Visible = true;
                txtOther_new.Visible = true;
                TextBox5.Visible = true;
            }
            else
            {
                txtBasicSal_new.Visible = chk1_3.Checked;
                txtTransAllow_new.Visible = chk1_5.Checked;
                txtOtherAllow_new.Visible = chk1_5.Checked;
                ddl_Dep.Visible = chk1_2.Checked;
                ddl_Line.Visible = chk1_2.Checked;
                ddl_Location.Visible = chk1_4.Checked;
                ddl_Pos.Visible = chk1_6.Checked;
                txtOther_new.Visible = chk1_7.Checked;
                TextBox5.Visible = chk1_7.Checked;
            }

            Session["LineID"] = ddl_Line.Text.Split(']')[0].Trim('[');
            //ddl_Dep.DataBind();
        }


        #region Kiểm tra xem nhân viên có hien thi phan luong - phu cap
        bool Is_HRCreater(string employeeID)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select * from tbl_RCManager_Open A WHERE A.ManagerID = @EmpID AND Status = 0 AND Type in ('D', 'E')";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { employeeID };
                DataTable dt = sqlProvider.GetDataTable();

                if (dt == null || dt.Rows.Count == 0)
                {
                    validate = false;
                }
            }
            catch(Exception ex)
            {

            }
            sqlProvider.CloseConnection();
            return validate;
        }
        bool Is_HRDirector(string employeeID)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select * from tbl_RCManager_Open A WHERE A.ManagerID = @EmpID AND Status = 0 AND Type in ('B')";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { employeeID };
                DataTable dt = sqlProvider.GetDataTable();

                if (dt == null || dt.Rows.Count == 0)
                {
                    validate = false;
                }
            }
            catch (Exception ex)
            {

            }
            sqlProvider.CloseConnection();
            return validate;
        }
        bool Is_GeneralDirector(string employeeID)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select * from tbl_RCManager_Open A WHERE A.ManagerID = @EmpID AND Status = 0 AND Type in ('C')";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { employeeID };
                DataTable dt = sqlProvider.GetDataTable();

                if (dt == null || dt.Rows.Count == 0)
                {
                    validate = false;
                }
            }
            catch (Exception ex)
            {

            }
            sqlProvider.CloseConnection();
            return validate;
        }
        private bool Is_L2_L1(string EmployeeID)
        {
            // update ngày 24/07/2018: theo mail Ms Trang yeu cau bo level 2 tru Hr Director
            bool validate = false;
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Declare @curr datetime = getdate(); SELECT * FROM DBO.udfTbl_EmpLevel(@curr) WHERE employeeid=@EmpID AND LevelID in (1,2);";
                provider.ParameterCollection = new string[] { "@EmpID" };
                provider.ValueCollection = new object[] { EmployeeID };
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
            this.vThongBao.ErrorMessage = GetGlobalResourceObject("RC_Registration2", vError).ToString();
        }
        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            IsForeWarning = true;
            args.IsValid = true;
            try
            {
                // kiem tra chon Nhan vien dieu chinh
                if (!Validate_Employee())
                {
                    args.IsValid = false;
                    SetErrorMessage("vEmployeeID");
                    return;
                }
                // kiem tra chon Nhan vien thay the
                if (!Validate_Employee_Replace())
                {
                    args.IsValid = false;
                    SetErrorMessage("vEmployee_Replace");
                    return;
                }
                // kiem tra chon loai dieu chinh
                if (!Validate_Promotion())
                {
                    args.IsValid = false;
                    SetErrorMessage("vPromotionType");
                    return;
                }
                // kiem tra dinh kem JD
                if (!Validate_NewHeadcount())
                {
                    args.IsValid = false;
                    SetErrorMessage("vNewHeadcount");
                    return;
                }
                // kiem tra dinh kem CE
                if (!Validate_NewHeadcount_NotInBudget())
                {
                    args.IsValid = false;
                    SetErrorMessage("vNewHeadcount_NotInBudget");
                    return;
                }
                // kiem tra ngay hieu luc
                if (cld_StartDate.Text.Trim() == "")
                {
                    args.IsValid = false;
                    SetErrorMessage("vStartDate_2");
                    return;
                }
                //if (cld_StartDate.Date.DayOfWeek == DayOfWeek.Sunday)
                //{
                //    args.IsValid = false;
                //    SetErrorMessage("vStartDate_3");
                //    return;
                //}
                // kiem tra trung
                DateTime start = cld_StartDate.Date;    // DateTime.Parse(txtStartDate.Text);
                if (!Validate_DuplicateDate(txtEmpID.Text.Trim(), start))
                {
                    args.IsValid = false;
                    SetErrorMessage("vDuplicate");
                    return;
                }
                // kiem tra chon Promotion/Title change
                if (chk1_1.Checked || chk1_6.Checked)
                {
                    // bat buoc change title
                    if (ddl_Pos.Text == null || ddl_Pos.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangePromotion_Title");
                        return;
                    }
                    // bat buoc dinh kem JD
                    if (!uc_Upload2.Validate())
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangePromotion_Title_2");
                        return;
                    }
                }
                // kiem tra chon change Salary
                if (chk1_3.Checked)
                {
                    //if (Is_L2_L1(Session["EmployeeID"].ToString()) ||
                    //    Is_HRCreater(Session["EmployeeID"].ToString()))
                    {
                        // bat buoc change Salary
                        if (txtBasicSal_new.Text.Trim() == "")
                        {
                            args.IsValid = false;
                            SetErrorMessage("vChangeSalary");
                            return;

                        }
                    }
                }
                // kiem tra chon change Allowance
                if (chk1_5.Checked)
                {
                    //if (Is_L2_L1(Session["EmployeeID"].ToString()) ||
                    //    Is_HRCreater(Session["EmployeeID"].ToString()))
                    {
                        // bat buoc change allowance
                        if (txtTransAllow_new.Text.Trim() == "" && txtOtherAllow_new.Text.Trim() == "")
                        {
                            args.IsValid = false;
                            SetErrorMessage("vChangeAllowance");
                            return;
                        }
                    }
                }
                // kiem tra chon change Location
                if (chk1_4.Checked)
                {
                    // bat buoc change location
                    if (ddl_Location.Text == null || ddl_Location.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeLocation");
                        return;
                    }
                }
                    
                // kiem tra chon change Department
                if (chk1_2.Checked)
                {
                    // bat buoc change phong ban/Bo phan
                    if (ddl_Line.Text == null || ddl_Line.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeLine");
                        return;
                    }
                    if (ddl_Dep.Text == null || ddl_Dep.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeDep");
                        return;
                    }
                }

                // kiem tra chon change Other
                if (chk1_7.Checked)
                {
                    // bat buoc change other
                    if (txtOther_new.Text.Trim() == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeOther");
                        return;
                    }
                }
                
                // buoc chon loai thay doi
                if (chk1_1.Checked || chk1_2.Checked || chk1_3.Checked || chk1_4.Checked ||
                    chk1_5.Checked || chk1_6.Checked || chk1_7.Checked )
                {

                }
                else
                {
                    args.IsValid = false;
                    SetErrorMessage("vOneChecked");
                    return;
                }
            }
            catch (Exception ex)
            {
                //Phải set true để lưới không bị bắt validate
                args.IsValid = true;
            }

        }

        bool Validate_Employee()
        {
            bool validate = true;
            if (txtEmpID.Text.Trim() == "" || txtEmpName.Text == "")
            {
                validate = false;
            }

            return validate;
        }

        bool Validate_Employee_Replace()
        {
            bool validate = true;
            if (chk4_3.Checked)
                if (txtEmpID_Replace.Text.Trim() == "")
                {
                    validate = false;
                }
            return validate;
        }

        bool Validate_Promotion()
        {
            bool validate = true;
            if (chk1_1.Checked || chk1_2.Checked || chk1_4.Checked)
            {
                if (!chk4_1.Checked)
                    if (!chk4_2.Checked)
                        if (!chk4_3.Checked)
                        {
                            validate = false;
                        }
            }
            return validate;
        }

        bool Validate_NewHeadcount()
        {
            bool validate = true;
            if (chk1_1.Checked || chk1_2.Checked || chk1_4.Checked)
            {
                if (chk4_1.Checked)
                    if (!uc_Upload2.Validate())
                    {
                        validate = false;
                    }
            }
            return validate;
        }

        bool Validate_NewHeadcount_NotInBudget()
        {
            bool validate = true;
            if (chk1_1.Checked || chk1_2.Checked || chk1_4.Checked)
            {
                if (chk4_1.Checked && opt_outButget.Checked)
                    if (!uc_Upload1.Validate())
                    {
                        validate = false;
                    }
            }
            return validate;
        }

        bool Validate_DuplicateDate(string employeeID, DateTime startDate)
        {
            bool validate = true;
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            sqlProvider.CommandText = "Select * from tblCand_Request_Online Where EmpID_Apply = @EmployeeID and convert(nvarchar(10), StartDate, 103)=convert(nvarchar(10), @StartDate, 103);";
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
                // Check nghi viec
                if (dt.Rows[0]["LeftDate"] != DBNull.Value)
                {
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertResign").ToString() + "')";
                    message = message.Replace("[]", "[" + (dt.Rows[0]["EmployeeName"] == DBNull.Value ? "" : dt.Rows[0]["EmployeeName"].ToString()) + "]");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpID.Focus();

                    return;
                }
                // Check quyen xem 
                bool isLineManager = new Cand_Request_OnlineService().IsLineManager(input, Session["EmployeeID"].ToString());
                if (dt.Rows[0]["LeftDate"] != DBNull.Value)
                {
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration2", "vPermissionViewSalary").ToString() + "')";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpID.Focus();
                    
                }

                txtEmpID.Text = input.ToUpper();
                txtEmpName.Text = (dt.Rows[0]["EmployeeName"] == DBNull.Value ? "" : dt.Rows[0]["EmployeeName"].ToString());
                txtPos.Text = (dt.Rows[0]["PosName"] == DBNull.Value ? "" : dt.Rows[0]["PosName"].ToString());
                txtLine.Text = (dt.Rows[0]["LineName"] == DBNull.Value ? "" : dt.Rows[0]["LineName"].ToString());
                txtDep.Text = (dt.Rows[0]["DepName"] == DBNull.Value ? "" : dt.Rows[0]["DepName"].ToString());
                txtLocation.Text = (dt.Rows[0]["LocationName"] == DBNull.Value ? "" : dt.Rows[0]["LocationName"].ToString());
                txtEmpOtherID.Text = (dt.Rows[0]["ReportTo"] == DBNull.Value ? "" : dt.Rows[0]["ReportTo"].ToString());

                txtPos_old.Text = (dt.Rows[0]["PosName"] == DBNull.Value ? "" : dt.Rows[0]["PosName"].ToString());
                txtLine_old.Text = (dt.Rows[0]["LineName"] == DBNull.Value ? "" : dt.Rows[0]["LineName"].ToString());
                txtDep_old.Text = (dt.Rows[0]["DepName"] == DBNull.Value ? "" : dt.Rows[0]["DepName"].ToString());
                txtLocation_old.Text = (dt.Rows[0]["LocationName"] == DBNull.Value ? "" : dt.Rows[0]["LocationName"].ToString());

                // Thong tin luong + PC
                //if (Is_HRCreater(Session["EmployeeID"].ToString()) ||
                //    Is_HRDirector(Session["EmployeeID"].ToString()) || Is_GeneralDirector(Session["EmployeeID"].ToString()))
                if (isLineManager)
                {
                    txtBasicSal_old.Text = Convert.ToInt32(dt.Rows[0]["BasicSal"] == DBNull.Value ? "0" : dt.Rows[0]["BasicSal"]).ToString("#,###");
                    txtTransAllow_old.Text = Convert.ToInt32(dt.Rows[0]["Allow_Travel"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Travel"]).ToString("#,###");
                    txtOtherAllow_old.Text = Convert.ToInt32(dt.Rows[0]["Allow_Other"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Other"]).ToString("#,###");
                }
                else
                {
                    txtBasicSal_old.Text = "";
                    txtTransAllow_old.Text = "";
                    txtOtherAllow_old.Text = "";
                }

                opt_G1.Checked = opt_G2.Checked = opt_G3.Checked = opt_G4.Checked = opt_G5.Checked = opt_G6.Checked = opt_G7.Checked = false;
                switch (dt.Rows[0]["SectionID"].ToString())
                {
                    case "ZPV":
                        opt_G1.Checked = true;
                        break;
                    case "ZPS":
                        opt_G2.Checked = true;
                        break;
                    case "SPC1": // Sang
                        opt_G3.Checked = true;
                        break;
                    case "PHT": // Phyto
                        opt_G4.Checked = true;
                        break;
                    case "MHV": // Metro health
                        opt_G6.Checked = true;
                        break;
                    case "LA": // Casual
                        opt_G7.Checked = true;
                        break;
                    default:
                        opt_G5.Checked = true;
                        //txtPayrollGroupOther.Text = dt.Rows[0]["SectionID"].ToString();
                        break;
                }
            }
            else
            {
                //txtEmpID.Text = "";
                txtEmpName.Text = "";
                txtPos.Text = "";
                txtDep.Text = "";
                txtLine.Text = "";
                txtLocation.Text = "";
                txtEmpOtherID.Text = "";

                txtPos_old.Text = "";
                txtLine_old.Text = "";
                txtDep_old.Text = "";
                txtLocation_old.Text = "";
                txtBasicSal_old.Text = "";
                txtTransAllow_old.Text = "";
                txtOtherAllow_old.Text = "";

                opt_G1.Checked = opt_G2.Checked = opt_G3.Checked = opt_G4.Checked = opt_G5.Checked = opt_G6.Checked = opt_G7.Checked = false;
                //txtPayrollGroupOther.Text = "";

                if (txtEmpID.Text.Trim() != "")
                {
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertNull").ToString() + "')";
                    message = message.Replace("[]", "[" + txtEmpID.Text + "]");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpID.Focus();
                }
            }

            txtEmpOtherID_TextChanged(txtEmpOtherID, null);
        }

        protected void GridLookup_EmpID_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Load info of employee
                //GetEmployeeInfo(GridLookup_EmpID.Value.ToString());
            }
            catch (Exception ex)
            {

            }
        }
        protected void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Load info of employee
                GetEmployeeInfo(txtEmpID.Text.Trim());
            }
            catch (Exception ex)
            {

            }
        }

        #region Submit & Reset
        private void resetNull()
        {
            // Part 1
            chk1_1.Checked = chk1_2.Checked = chk1_3.Checked = chk1_4.Checked = chk1_5.Checked = chk1_6.Checked = chk1_7.Checked = false;

            // Part 2
            txtEmpID.Text = "";
            txtEmpID_TextChanged(txtEmpID, null);

            // Part 3
            chk4_1.Checked = chk4_2.Checked = chk4_3.Checked = false;
            txtEmpID_Replace.Text = "";
            txtEmpName_Replace.Text = "";

            // Part 4
            ddl_Pos.Text = "";
            ddl_Line.Text = "";
            ddl_Dep.Text = "";
            ddl_Location.Text = "";
            txtBasicSal_new.Text = "";
            txtTransAllow_new.Text = "";
            txtOtherAllow_new.Text = "";
            txtOther_old.Text = "";
            txtOther_new.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";

            txtRemarks.Value = "";

            // Part 5
            cld_StartDate.Date = DateTime.Now;
            if (uc_Upload1.Validate())
                uc_Upload1.ClearTokenBox();
            if (uc_Upload2.Validate())
                uc_Upload2.ClearTokenBox();
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
                new_Obj.EmpID_Apply = txtEmpID.Text.Trim();
                new_Obj.Apply_Name = txtEmpName.Text;
                new_Obj.RequestID = Guid.NewGuid().ToString();
                new_Obj.DateID = DateTime.Now;
                //new_Obj.ReceivedDate = ;
                //new_Obj.DeadLine = ;
                //new_Obj.FinalDate = ;
                string _proAdj_Type = "";
                _proAdj_Type = _proAdj_Type + (chk1_1.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_2.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_3.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_4.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_5.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_6.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_7.Checked ? "1" : "0");
                new_Obj.ProAdj_Type = _proAdj_Type;

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
                    //new_Obj.SectionID = txtPayrollGroupOther.Text.Trim();
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
                //new_Obj.TypeID = "";
                if (chk4_1.Checked)
                {
                    new_Obj.ReasonID = "New";
                    if (opt_inButget.Checked == true)
                        new_Obj.IsBudgetHead = true;
                    else if (opt_outButget.Checked == true)
                        new_Obj.IsBudgetHead = false;
                }
                if (chk4_2.Checked)
                    new_Obj.ReasonID = "Inter";
                if (chk4_3.Checked)
                {
                    new_Obj.ReasonID = "Replace";
                    if (txtEmpID_Replace.Text.Trim() != "")
                        new_Obj.EmpID_Replace = txtEmpID_Replace.Text.Trim();
                }
                //new_Obj.EmpReplace_Sal = ;
                //new_Obj.EmpReplace_Allowance = ;
                //new_Obj.IsInternalPost = ;
                //if (GridLookup_Location.Value != null)
                //new_Obj.LocationID = GridLookup_Location.Value.ToString();
                //new_Obj.SexID = ;
                //new_Obj.JobDes = ;
                //new_Obj.JobDes_File = ;
                //if (txtStartDate.Text != "")
                //    new_Obj.StartDate = DateTime.Parse(txtStartDate.Text);
                if (cld_StartDate.Text != "")
                    new_Obj.StartDate = cld_StartDate.Date;
                //new_Obj.ProbationID = ;
                DataTable dt = Cand_Request_OnlineService.GetEmpInfoByid(txtEmpID.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    new_Obj.Probation_Sal = Convert.ToDouble(dt.Rows[0]["BasicSal"] == DBNull.Value ? "0" : dt.Rows[0]["BasicSal"]);
                    //new_Obj.Probation_Sal = double.Parse(txtBasicSal_old.Text.Replace(",", "").Replace(".", ""));
                    new_Obj.Probation_Travel = Convert.ToDouble(dt.Rows[0]["Allow_Travel"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Travel"]);
                    //new_Obj.Probation_Travel = double.Parse(txtTransAllow_old.Text.Replace(",", "").Replace(".", ""));
                    new_Obj.Probation_Allowance = Convert.ToDouble(dt.Rows[0]["Allow_Other"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Other"]);
                    //new_Obj.Probation_Allowance = double.Parse(txtOtherAllow_old.Text.Replace(",", "").Replace(".", ""));
                }
                if (txtBasicSal_new.Text != "")
                    new_Obj.Permanent_Sal = double.Parse(txtBasicSal_new.Text.Replace(",", "").Replace(".", ""));
                if (txtTransAllow_new.Text != "")
                    new_Obj.Permanent_Travel = double.Parse(txtTransAllow_new.Text.Replace(",", "").Replace(".", ""));
                if (txtOtherAllow_new.Text != "")
                    new_Obj.Permanent_Allowance = double.Parse(txtOtherAllow_new.Text.Replace(",", "").Replace(".", ""));
                new_Obj.Requester = Session["EmployeeID"].ToString();
                new_Obj.ReportTo = txtEmpOtherID.Text;
                //new_Obj.ApprovedBy = ;
                //new_Obj.ApprovedDate = ;
                //new_Obj.HRDept_Note = ;
                //new_Obj.ContractID = ;
                //new_Obj.EmpID_Other = ;
                if (ddl_Line.Text != "")
                    new_Obj.To_LineID = ddl_Line.Text.Split(']')[0].Trim('[');
                if (ddl_Dep.Text != "")
                    new_Obj.To_DepID = ddl_Dep.Text.Split(']')[0].Trim('[');
                if (ddl_Pos.Text != "")
                    new_Obj.To_PosID = ddl_Pos.Text.Split(']')[0].Trim('[');
                if (ddl_Location.Text != "")
                    new_Obj.To_LocationID = ddl_Location.Text.Split(']')[0].Trim('[');
                new_Obj.Other_old = txtOther_old.Text;
                new_Obj.Other_new = txtOther_new.Text;

                new_Obj.Other_oldValue = TextBox4.Text;
                new_Obj.Other_newValue = TextBox5.Text;

                //new_Obj.OtherDescription = TextBox1.Text;
                //new_Obj.Other_old2Value = TextBox2.Text;
                //new_Obj.Other_new2Value = TextBox3.Text;

                // remarks
                new_Obj.Remarks = txtRemarks.Value.Trim();

                // INsert data
                Cand_Request_OnlineService.CreateNews(new_Obj);
                if (new_Obj.RequestID != null)
                {
                    if (uc_Upload1.Validate())
                    {
                        uc_Upload1.Submit_Attach(new_Obj.RequestID, "CE");
                    }
                    if (uc_Upload2.Validate())
                    {
                        uc_Upload2.Submit_Attach(new_Obj.RequestID, "JD");
                    }
                }
                ////string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccess").ToString() + "')";
                ////ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);
                string str_script = "Func('" + Session["Lang"] + "')";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", str_script, true);

                // clean content
                txtEmpID.Text = "";
                btnNhapLai_Click(sender, e);
            }

        }
        public int InsertRecord(string EmpID, DateTime regDate, DateTime startDate, DateTime fromTime, DateTime toTime, string OTReason, int checkNum, float toTalHours, int mailToL1, string managerID_L1, string managerID_L2, string managerID_L3)
        {
            int returnValue = 0;
            try
            {
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
                sql += "SELECT SCOPE_IDENTITY();";
                sqlProvider.CommandText = sql;
                sqlProvider.ParameterCollection = new string[] { "@EmployeeID", "@RegDate", "@StartDate", "@FromTime", "@ToTime", "@OTReason", "@CheckNum", "@TotalHours" };
                sqlProvider.ValueCollection = new object[] { EmpID, regDate, startDate, fromTime, toTime, OTReason, checkNum, toTalHours };
                object obj = sqlProvider.ExecuteScalar();
                returnValue = int.Parse(obj.ToString());
                sqlProvider.CloseConnection();
            }
            catch (Exception ex)
            { }
            return returnValue;
        }
        #endregion

        protected void txtEmpID_Replace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                txtEmpName_Replace.Text = kh.getEmployeeName(txtEmpID_Replace.Text.Trim());
                if (txtEmpID.Text.Trim() != "" && txtEmpID.Text.Trim() == txtEmpName_Replace.Text)
                {
                    txtEmpName_Replace.Text = "";
                    string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertNull").ToString() + "')";
                    message = message.Replace("[]", "[" + txtEmpID.Text + "]");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Alert", message, true);
                    txtEmpID.Focus();
                }
            }
            catch (Exception ex)
            {
                txtEmpName_Replace.Text = "";
            }
        }

        protected void GridLookup_Line_ValueChanged(object sender, EventArgs e)
        {
            ddl_Dep.Text = "";
        }

        protected void btnSaveTemp_Click(object sender, EventArgs e)
        {
            try
            {
                //Code insert data into database
                tblCand_Request_Online new_Obj = new tblCand_Request_Online();
                new_Obj.EmpID_Apply = txtEmpID.Text.Trim();
                new_Obj.Apply_Name = txtEmpName.Text;
                new_Obj.RequestID = Guid.NewGuid().ToString();
                new_Obj.DateID = DateTime.Now;
                //new_Obj.ReceivedDate = ;
                //new_Obj.DeadLine = ;
                //new_Obj.FinalDate = ;
                string _proAdj_Type = "";
                _proAdj_Type = _proAdj_Type + (chk1_1.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_2.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_3.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_4.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_5.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_6.Checked ? "1" : "0");
                _proAdj_Type = _proAdj_Type + (chk1_7.Checked ? "1" : "0");
                new_Obj.ProAdj_Type = _proAdj_Type;

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
                    //new_Obj.SectionID = txtPayrollGroupOther.Text.Trim();
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
                //new_Obj.TypeID = "";
                if (chk4_1.Checked)
                {
                    new_Obj.ReasonID = "New";
                    if (opt_inButget.Checked == true)
                        new_Obj.IsBudgetHead = true;
                    else if (opt_outButget.Checked == true)
                        new_Obj.IsBudgetHead = false;
                }
                if (chk4_2.Checked)
                    new_Obj.ReasonID = "Inter";
                if (chk4_3.Checked)
                {
                    new_Obj.ReasonID = "Replace";
                    if (txtEmpID_Replace.Text.Trim() != "")
                        new_Obj.EmpID_Replace = txtEmpID_Replace.Text.Trim();
                }
                //new_Obj.EmpReplace_Sal = ;
                //new_Obj.EmpReplace_Allowance = ;
                //new_Obj.IsInternalPost = ;
                //if (GridLookup_Location.Value != null)
                //new_Obj.LocationID = GridLookup_Location.Value.ToString();
                //new_Obj.SexID = ;
                //new_Obj.JobDes = ;
                //new_Obj.JobDes_File = ;
                //if (txtStartDate.Text != "")
                //    new_Obj.StartDate = DateTime.Parse(txtStartDate.Text);
                if (cld_StartDate.Text != "")
                    new_Obj.StartDate = cld_StartDate.Date;
                //new_Obj.ProbationID = ;
                DataTable dt = Cand_Request_OnlineService.GetEmpInfoByid(txtEmpID.Text.Trim());
                if (dt != null && dt.Rows.Count > 0)
                {
                    new_Obj.Probation_Sal = Convert.ToDouble(dt.Rows[0]["BasicSal"] == DBNull.Value ? "0" : dt.Rows[0]["BasicSal"]);
                    //new_Obj.Probation_Sal = double.Parse(txtBasicSal_old.Text.Replace(",", "").Replace(".", ""));
                    new_Obj.Probation_Travel = Convert.ToDouble(dt.Rows[0]["Allow_Travel"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Travel"]);
                    //new_Obj.Probation_Travel = double.Parse(txtTransAllow_old.Text.Replace(",", "").Replace(".", ""));
                    new_Obj.Probation_Allowance = Convert.ToDouble(dt.Rows[0]["Allow_Other"] == DBNull.Value ? "0" : dt.Rows[0]["Allow_Other"]);
                    //new_Obj.Probation_Allowance = double.Parse(txtOtherAllow_old.Text.Replace(",", "").Replace(".", ""));
                }
                if (txtBasicSal_new.Text != "")
                    new_Obj.Permanent_Sal = double.Parse(txtBasicSal_new.Text.Replace(",", "").Replace(".", ""));
                if (txtTransAllow_new.Text != "")
                    new_Obj.Permanent_Travel = double.Parse(txtTransAllow_new.Text.Replace(",", "").Replace(".", ""));
                if (txtOtherAllow_new.Text != "")
                    new_Obj.Permanent_Allowance = double.Parse(txtOtherAllow_new.Text.Replace(",", "").Replace(".", ""));
                new_Obj.Requester = Session["EmployeeID"].ToString();
                new_Obj.ReportTo = txtEmpOtherID.Text;
                //new_Obj.ApprovedBy = ;
                //new_Obj.ApprovedDate = ;
                //new_Obj.HRDept_Note = ;
                //new_Obj.ContractID = ;
                //new_Obj.EmpID_Other = ;
                if (ddl_Line.Text != "")
                    new_Obj.To_LineID = ddl_Line.Text.Split(']')[0].Trim('[');
                if (ddl_Dep.Text != "")
                    new_Obj.To_DepID = ddl_Dep.Text.Split(']')[0].Trim('[');
                if (ddl_Pos.Text != "")
                    new_Obj.To_PosID = ddl_Pos.Text.Split(']')[0].Trim('[');
                if (ddl_Location.Text != "")
                    new_Obj.To_LocationID = ddl_Location.Text.Split(']')[0].Trim('[');
                new_Obj.Other_old = txtOther_old.Text;
                new_Obj.Other_new = txtOther_new.Text;

                new_Obj.Other_oldValue = TextBox4.Text;
                new_Obj.Other_newValue = TextBox5.Text;
                //new_Obj.OtherDescription = TextBox1.Text;
                //new_Obj.Other_old2Value = TextBox2.Text;
                //new_Obj.Other_new2Value = TextBox3.Text;

                // remarks
                new_Obj.Remarks = txtRemarks.Value.Trim();

                // INsert data
                new_Obj.RegType = true;
                Cand_Request_OnlineService.CreateNews_Tmp(new_Obj);
                if (new_Obj.RequestID != null)
                {
                    if (uc_Upload1.Validate())
                    {
                        uc_Upload1.Submit_Attach(new_Obj.RequestID, "CE");
                    }
                    if (uc_Upload2.Validate())
                    {
                        uc_Upload2.Submit_Attach(new_Obj.RequestID, "JD");
                    }
                }
                //string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccess").ToString() + "')";
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);
                string str_script = "Func2('" + Session["Lang"] + "')";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", str_script, true);
                // clean content
                txtEmpID.Text = "";
                resetNull();
            }
            catch(Exception ex)
            {

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
        #region // AutoPostBack events
        protected void ddl_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Dep.Text = "";
        }
        #endregion

    }
}