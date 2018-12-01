using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using conn = System.Web.Configuration;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;

namespace NPOL
{
    public partial class PR_DetailReview_2 : System.Web.UI.Page
    {
        bool IsForeWarning = true;
        tblCand_Request_Online item = null;
        int ListItemType = 0;

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

            // Kiem tra user edit
            // hide phan thong tin dieu chinh
            ShowHide_Description();

            if (!IsPostBack)
            {
                // Load data
                string requestID = Session["RequestID"].ToString();
                LoadData(requestID);

                loadAttach_CE();
                loadAttach_JD();
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
            else
            {
                btnDangKy.Visible = true;
            }

            Session["LineID"] = ddl_Line.Text.Split(']')[0].Trim('[');
            Session["LineID2"] = ddl_Line2.Text.Split(']')[0].Trim('[');
            //ddl_Dep.DataBind();

            //update title
            if (!btnDangKy.Visible)
            {
                lbTieuDe.Text = lbTieuDe.Text.Replace("EDIT", "REVIEW").Replace("SỬA", "XEM");
                txtRemarks.Attributes.Add("readonly", "true");
            }
            else
            {
                txtRemarks.Attributes.Remove("readonly");
            }
        }

        private void ShowHide_Description()
        {
            if (Session["RecruitTmp"].ToString() == "True")
            {
                if (item.Requester == Session["EmployeeID"].ToString())
                {
                    Show_Description1();
                    ListItemType = 2;
                }
                else if (Is_CBManager(Session["EmployeeID"].ToString()) ||
                    Is_HRDirector(Session["EmployeeID"].ToString()) ||
                    Is_GeneralDirector(Session["EmployeeID"].ToString()))
                {
                    Show_Description2();
                    ListItemType = 3;
                }
                else
                {
                    Show_Description1();
                    ListItemType = 2;
                }
            }
            else
            {
                ListItemType = 1;
                // T/h load thong tin Temp
                // Show-hide thong tin Change1
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
                    txtA_HotlineNew.Visible = true;
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
                    txtA_HotlineNew.Visible = chk1_7.Checked;
                }
                // Hide thong tin Change2
                ddl_Line2.Visible = false;
                ddl_Dep2.Visible = false;
                ddl_Pos2.Visible = false;
                ddl_Location2.Visible = false;
                txtBasicSal_new2.Visible = false;
                txtTransAllow_new2.Visible = false;
                txtOtherAllow_new2.Visible = false;
                txtOther_new2.Visible = false;
                txtA_HotlineNew2.Visible = false;
            }
        }

        private void Show_Description2()
        {
            // Show-hide thong tin Change2
            if (chk1_1.Checked)
            {
                ddl_Line2.Enabled = true;
                ddl_Dep2.Enabled = true;
                ddl_Pos2.Enabled = true;
                ddl_Location2.Enabled = true;
                txtBasicSal_new2.Enabled = true;
                txtTransAllow_new2.Enabled = true;
                txtOtherAllow_new2.Enabled = true;
                txtOther_new2.Enabled = true;
                txtA_HotlineNew2.Enabled = true;
            }
            else
            {
                txtBasicSal_new2.Enabled = chk1_3.Checked;
                txtTransAllow_new2.Enabled = chk1_5.Checked;
                txtOtherAllow_new2.Enabled = chk1_5.Checked;
                ddl_Dep2.Enabled = chk1_2.Checked;
                ddl_Line2.Enabled = chk1_2.Checked;
                ddl_Location2.Enabled = chk1_4.Checked;
                ddl_Pos2.Enabled = chk1_6.Checked;
                txtOther_new2.Enabled = chk1_7.Checked;
                txtA_HotlineNew2.Enabled = chk1_7.Checked;
            }
            // Hide thong tin Change1
            ddl_Line.Enabled = false;
            ddl_Dep.Enabled = false;
            ddl_Pos.Enabled = false;
            ddl_Location.Enabled = false;
            txtBasicSal_new.Enabled = false;
            txtTransAllow_new.Enabled = false;
            txtOtherAllow_new.Enabled = false;
            txtOther_new.Enabled = false;
            txtA_HotlineNew.Enabled = false;
        }

        private void Show_Description1()
        {
            // Show-hide thong tin Change1
            if (chk1_1.Checked)
            {
                ddl_Line.Enabled = true;
                ddl_Dep.Enabled = true;
                ddl_Pos.Enabled = true;
                ddl_Location.Enabled = true;
                txtBasicSal_new.Enabled = true;
                txtTransAllow_new.Enabled = true;
                txtOtherAllow_new.Enabled = true;
                txtOther_new.Enabled = true;
                txtA_HotlineNew.Enabled = true;
            }
            else
            {
                txtBasicSal_new.Enabled = chk1_3.Checked;
                txtTransAllow_new.Enabled = chk1_5.Checked;
                txtOtherAllow_new.Enabled = chk1_5.Checked;
                ddl_Dep.Enabled = chk1_2.Checked;
                ddl_Line.Enabled = chk1_2.Checked;
                ddl_Location.Enabled = chk1_4.Checked;
                ddl_Pos.Enabled = chk1_6.Checked;
                txtOther_new.Enabled = chk1_7.Checked;
                txtA_HotlineNew.Enabled = chk1_7.Checked;
            }
            // Hide thong tin Change2
            ddl_Line2.Enabled = false;
            ddl_Dep2.Enabled = false;
            ddl_Pos2.Enabled = false;
            ddl_Location2.Enabled = false;
            txtBasicSal_new2.Enabled = false;
            txtTransAllow_new2.Enabled = false;
            txtOtherAllow_new2.Enabled = false;
            txtOther_new2.Enabled = false;
            txtA_HotlineNew2.Enabled = false;
        }

        public void loadAttach_JD()
        {
            if (item.RequestID != null)
            {
                DataTable dt = Attachment_RCService.GetTableByNewsid(item.RequestID);
                if (dt != null)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["AttachType"].ToString() == "JD")
                        {
                            HiddenField2.Value = r["ID"].ToString();
                            LinkButton2.Text = r["AttachmentName"].ToString();
                        }
                    }
                }
            }

        }
        public void loadAttach_CE()
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
                            HiddenField1.Value = r["ID"].ToString();
                            LinkButton1.Text = r["AttachmentName"].ToString();
                        }
                    }
                }
            }

        }

        #region Kiểm tra xem nhân viên có hien thi phan luong - phu cap
        bool Is_HRDirector(string employeeID)
        {
            bool result = false;

            //Code xu ly
            switch (RCManager_OpenType(employeeID))
            {
                case "B":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
        bool Is_GeneralDirector(string employeeID)
        {
            bool result = false;

            //Code xu ly
            switch (RCManager_OpenType(employeeID))
            {
                case "C":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
        bool Is_HRCreater(string employeeID)
        {
            bool result = false;

            //Code xu ly
            switch (RCManager_OpenType(employeeID))
            {
                case "D":
                case "E":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
        bool Is_CBManager(string employeeID)
        {
            bool result = false;

            //Code xu ly
            switch (RCManager_OpenType(employeeID))
            {
                case "F":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }
        String RCManager_OpenType(string employeeID)
        {
            String result = "";
            //Code xu ly
            khSqlServerProvider sqlProvider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
            try
            {
                sqlProvider.CommandText = "Select [Type] from tbl_RCManager_Open A WHERE A.ManagerID = @EmpID AND Status = 0 ";
                sqlProvider.ParameterCollection = new string[] { "@EmpID" };
                sqlProvider.ValueCollection = new object[] { employeeID };
                object obj = sqlProvider.ExecuteScalar();

                if (obj != null)
                {
                    result = obj.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            sqlProvider.CloseConnection();
            return result;
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

        bool Check_Edit(string employeeID, string regID)
        {
            bool validate = false;
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
                object _Director_Status = dt.Rows[0]["Director_Status"];
                object _ApprovingStatus_L1 = dt.Rows[0]["ApprovingStatus_L1"];
                object _HR_Recruit_Status = dt.Rows[0]["HR_Recruit_Status"];
                object _HR_Manager_Status = dt.Rows[0]["HR_Manager_Status"];
                object _DirectorID_Status = dt.Rows[0]["DirectorID_Status"];
                object _FinalStatus = dt.Rows[0]["FinalStatus"];
                object _EmpID_Apply = dt.Rows[0]["EmpID_Apply"];
                object _CheckerID = dt.Rows[0]["CheckerID"];

                // neu la user tao yeu cau
                if (_Requester != null && _Requester.ToString() == employeeID)
                {
                    txtRemarks.Attributes.Remove("readonly");

                    if ((_ApprovingStatus_L1 != DBNull.Value && (bool)_ApprovingStatus_L1) ||
                        (_HR_Recruit_Status != DBNull.Value && (bool)_HR_Recruit_Status) ||
                        (_HR_Manager_Status != DBNull.Value && (bool)_HR_Manager_Status) ||
                        (_DirectorID_Status != DBNull.Value && (bool)_DirectorID_Status))
                    {
                        txtRemarks.Attributes.Add("readonly", "true");
                        validate = false;
                    }
                    else
                    {
                        validate = true;
                    }
                    if (_Director_Status != DBNull.Value && _Director_Status.ToString() == "w")
                    {
                        validate = true;
                    }
                }
                else if (_EmpID_Apply != null && _EmpID_Apply.ToString() != "")
                {
                    if (!Is_HRDirector(employeeID))
                    {
                        txtRemarks.Attributes.Add("readonly", "true");

                        if (_Director_Status != DBNull.Value && _Director_Status.ToString() == "w")
                        {
                            validate = true;
                        }
                    }

                    // neu la Checker
                    if (_CheckerID != null && _CheckerID.ToString() == employeeID)
                    {
                        validate = false;
                    }
                    // neu la Manager
                    else if (_ManagerID_L1 != null && _ManagerID_L1.ToString() == employeeID)
                    {
                        if (_HR_Manager_Status != DBNull.Value && (bool)_HR_Manager_Status)
                        {
                            validate = false;
                        }
                        else
                        {
                            if (Is_L2_L1(_ManagerID_L1.ToString()) || Is_HRDirector(employeeID))
                            {
                                validate = true;
                            }
                            else
                            {
                                validate = false;
                            }
                        }
                    }
                    // neu la C&B Manager
                    if (Is_CBManager(employeeID))
                    {
                        if (_HR_Manager_Status != DBNull.Value && (bool)_HR_Manager_Status)
                        {
                            validate = false;
                        }
                        else
                        {
                            validate = true;
                        }
                    }
                    // neu la HR
                    //else if (_HR_Manager != null && _HR_Manager.ToString() == employeeID)
                    if (Is_HRDirector(employeeID))
                    {
                        if (_DirectorID_Status != DBNull.Value && (bool)_DirectorID_Status)
                        {
                            validate = false;
                        }
                        else
                        {
                            validate = true;
                        }
                        if (_Director_Status != DBNull.Value && _Director_Status.ToString() == "w")
                        {
                            validate = true;
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

        private void LoadData(string requestID)
        {
            try
            {
                if (item != null)
                {
                    // part 1
                    if (item.ProAdj_Type.ElementAt(0).ToString() == "1")
                        chk1_1.Checked = true;
                    if (item.ProAdj_Type.ElementAt(1).ToString() == "1")
                        chk1_2.Checked = true;
                    if (item.ProAdj_Type.ElementAt(2).ToString() == "1")
                        chk1_3.Checked = true;
                    if (item.ProAdj_Type.ElementAt(3).ToString() == "1")
                        chk1_4.Checked = true;
                    if (item.ProAdj_Type.ElementAt(4).ToString() == "1")
                        chk1_5.Checked = true;
                    if (item.ProAdj_Type.ElementAt(5).ToString() == "1")
                        chk1_6.Checked = true;
                    if (item.ProAdj_Type.ElementAt(6).ToString() == "1")
                        chk1_7.Checked = true;

                    // part 2
                    txtEmpID.Text = item.EmpID_Apply;
                    txtEmpID_TextChanged(txtEmpID, null);
                    txtEmpOtherID.Text = item.ReportTo;
                    txtEmpOtherID_TextChanged(txtEmpOtherID, null);

                    // RecruitByID
                    if (item.SectionID == "ZPV")
                        opt_G1.Checked = true;
                    else if (item.SectionID == "ZPS")
                        opt_G2.Checked = true;
                    //else if (item.SectionID == "PRN")
                    //    opt_G3.Checked = true;
                    else if (item.SectionID == "Casual")
                        opt_G4.Checked = true;

                    // part 3
                    if (item.ReasonID == "New")
                    {
                        chk3_1.Checked = true;
                        if (item.IsBudgetHead == true)
                            opt_inButget.Checked = true;
                        else if (item.IsBudgetHead == false)
                            opt_outButget.Checked = true;
                    }
                    else if (item.ReasonID == "Replace")
                    {
                        chk3_3.Checked = true;
                    }
                    else if (item.ReasonID == "Inter")
                    {
                        chk3_2.Checked = true;
                    }

                    txtEmpID_Replace.Text = item.EmpID_Replace;
                    txtEmpID_Replace_TextChanged(txtEmpID_Replace, null);

                    // part 4
                    if (ListItemType == 1)
                    {
                        var pr_service = new prServices(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
                        ddl_Line.Text = pr_service.getDep_Display(item.To_LineID);
                        ddl_Pos.Text = pr_service.getPos_Display(item.To_PosID);
                        Session["LineID"] = item.To_LineID;
                        ddl_Dep.DataBind();
                        ddl_Dep.Text = pr_service.getDep_Display(item.To_DepID);
                        ddl_Location.Text = pr_service.getLocation_Display(item.To_LocationID);

                        // Thong tin luong - phu cap
                        txtBasicSal_new.Text = item.Permanent_Sal.ToString("#,###");
                        txtTransAllow_new.Text = item.Permanent_Travel.ToString("#,###");
                        txtOtherAllow_new.Text = item.Permanent_Allowance.ToString("#,###");
                        txtOther_old.Text = item.Other_old.ToString();
                        txtOther_new.Text = item.Other_new.ToString();

                        txtA_HotlineOld.Text = item.Other_oldValue;
                        txtA_HotlineNew.Text = item.Other_newValue;
                    }
                    else
                    {
                        var pr_service2 = new prServices(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());
                        DataTable dt1 = pr_service2.getDescription_Requester(item.RequestID);
                        if (dt1 != null && dt1.Rows.Count > 0)
                        {
                            ddl_Line.Text = pr_service2.getDep_Display(dt1.Rows[0]["To_LineID"]);
                            ddl_Pos.Text = pr_service2.getPos_Display(dt1.Rows[0]["To_PosID"]);
                            Session["LineID"] = dt1.Rows[0]["To_LineID"];
                            ddl_Dep.DataBind();
                            ddl_Dep.Text = pr_service2.getDep_Display(dt1.Rows[0]["To_DepID"]);
                            ddl_Location.Text = pr_service2.getLocation_Display(dt1.Rows[0]["To_LocationID"]);

                            // Thong tin luong - phu cap
                            string strTemp = "";
                            strTemp = dt1.Rows[0]["Permanent_Sal"].ToString();
                            txtBasicSal_new.Text = Double.Parse(strTemp == "" ? "0" : strTemp).ToString("#,###");
                            strTemp = dt1.Rows[0]["Permanent_Travel"].ToString();
                            txtTransAllow_new.Text = Double.Parse(strTemp == "" ? "0" : strTemp).ToString("#,###");
                            strTemp = dt1.Rows[0]["Permanent_Allowance"].ToString();
                            txtOtherAllow_new.Text = Double.Parse(strTemp == "" ? "0" : strTemp).ToString("#,###");
                            //txtOther_old.Text = dt1.Rows[0]["Other_old"].ToString();
                            txtOther_new.Text = dt1.Rows[0]["Other_newValue"].ToString();

                            //txtA_HotlineOld.Text = dt1.Rows[0]["Other_oldValue"].ToString();
                            txtA_HotlineNew.Text = dt1.Rows[0]["Other_new2Value"].ToString();
                        }
                        DataTable dt2 = pr_service2.getDescription_HR(item.RequestID);
                        if (dt2 != null && dt2.Rows.Count > 0)
                        {
                            ddl_Line2.Text = pr_service2.getDep_Display(dt2.Rows[0]["To_LineID"]);
                            ddl_Pos2.Text = pr_service2.getPos_Display(dt2.Rows[0]["To_PosID"]);
                            Session["LineID2"] = dt2.Rows[0]["To_LineID"];
                            ddl_Dep2.DataBind();
                            ddl_Dep2.Text = pr_service2.getDep_Display(dt2.Rows[0]["To_DepID"]);
                            ddl_Location2.Text = pr_service2.getLocation_Display(dt2.Rows[0]["To_LocationID"]);

                            // Thong tin luong - phu cap
                            string strTemp2 = "";
                            strTemp2 = dt2.Rows[0]["Permanent_Sal"].ToString();
                            txtBasicSal_new2.Text = Double.Parse(strTemp2 == "" ? "0" : strTemp2).ToString("#,###");
                            strTemp2 = dt2.Rows[0]["Permanent_Travel"].ToString();
                            txtTransAllow_new2.Text = Double.Parse(strTemp2 == "" ? "0" : strTemp2).ToString("#,###"); 
                            strTemp2 = dt2.Rows[0]["Permanent_Allowance"].ToString();
                            txtOtherAllow_new2.Text = Double.Parse(strTemp2 == "" ? "0" : strTemp2).ToString("#,###"); 
                            txtOther_new2.Text = dt2.Rows[0]["Other_newValue"].ToString();
                            txtA_HotlineNew2.Text = dt2.Rows[0]["Other_new2Value"].ToString();
                        }
                    }
                    // part 5
                    if (item.StartDate != null)
                        cld_StartDate.Date = item.StartDate.Value;

                    // remark
                    loadRemark();
                    //txtRemarks.Value = item.Remarks;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void loadRemark()
        {
            //if (Session["EmployeeID"].ToString() == item.Requester)
            //{
            //    txtRemarks.Value = item.Remarks;

            //    txtRemark_Requester.Visible = false;
            //    lb_Requester.Visible = false;
            //    txtRemark_CB.Visible = false;
            //    lb_CB.Visible = false;
            //    txtRemark_HR.Visible = false;
            //    lb_HR.Visible = false;
            //}
            //else
            {
                var pr_service = new prServices(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ToString());

                String strRequester = pr_service.getRemark_Requester(item.RequestID);
                if (strRequester != "")
                {
                    txtRemark_Requester.Text = strRequester;
                }
                else
                {
                    txtRemark_Requester.Visible = false;
                    lb_Requester.Visible = false;
                }

                String strCB = pr_service.getRemark_CB(item.RequestID);
                if (strCB != "")
                {
                    txtRemark_CB.Text = strCB;
                }
                else
                {
                    txtRemark_CB.Visible = false;
                    lb_CB.Visible = false;
                }

                String strHR = pr_service.getRemark_HR(item.RequestID);
                if (strHR != "")
                {
                    txtRemark_HR.Text = strHR;
                }
                else
                {
                    txtRemark_HR.Visible = false;
                    lb_HR.Visible = false;
                }

                String strCEO = pr_service.getRemark_CEO(item.RequestID);
                if (strCEO != "")
                {
                    txtRemark_CEO.Text = strCEO;
                }
                else
                {
                    txtRemark_CEO.Visible = false;
                    lb_CEO.Visible = false;
                }
            }
        }

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
                    SetErrorMessage("vEmployee");
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
                DateTime start = cld_StartDate.Date;//DateTime.Parse(txtStartDate.Text);
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
                    if (ddl_Pos.Text == "" && ddl_Pos2.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangePromotion_Title");
                        return;
                    }
                    // bat buoc dinh kem JD
                    if (!uc_Upload2.Validate())
                    {
                        if (LinkButton2.Text == "")
                        {
                            args.IsValid = false;
                            SetErrorMessage("vChangePromotion_Title_2");
                            return;
                        }
                    }
                }
                // kiem tra chon change Salary
                if (chk1_3.Checked)
                {
                    //if (Is_L2_L1(Session["EmployeeID"].ToString()) ||
                    //    Is_HRCreater(Session["EmployeeID"].ToString()) ||
                    //    Is_CBManager(Session["EmployeeID"].ToString()))
                    {
                        // bat buoc change Salary
                        if (txtBasicSal_new.Text.Trim() == "" && txtBasicSal_new2.Text.Trim() == "")
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
                    //    Is_HRCreater(Session["EmployeeID"].ToString()) ||
                    //    Is_CBManager(Session["EmployeeID"].ToString()))
                    {
                        // bat buoc change allowance
                        if (txtTransAllow_new.Text.Trim() == "" && txtOtherAllow_new.Text.Trim() == "" &&
                            txtTransAllow_new2.Text.Trim() == "" && txtOtherAllow_new2.Text.Trim() == "")
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
                    if (ddl_Location.Text == "" && ddl_Location2.Text == "")
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
                    if (ddl_Line.Text == "" && ddl_Line2.Text == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeLine");
                        return;
                    }
                    if (ddl_Dep.Text == "" && ddl_Dep2.Text == "")
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
                    if (txtOther_new.Text.Trim() == "" && txtOther_new2.Text.Trim() == "")
                    {
                        args.IsValid = false;
                        SetErrorMessage("vChangeOther");
                        return;
                    }
                }

                // Nhap Remark neu thay doi gia tri creator tao
                if (txtRemarks.Value.Trim() == "")
                {
                    if (!Validate_Remark())
                    {
                        args.IsValid = false;
                        SetErrorMessage("vRemark");
                        return;
                    }
                }

                // buoc chon loai thay doi
                if (chk1_1.Checked || chk1_2.Checked || chk1_3.Checked || chk1_4.Checked ||
                    chk1_5.Checked || chk1_6.Checked || chk1_7.Checked)
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
            if (txtEmpID.Text.Trim() == "")
            {
                validate = false;
            }

            return validate;
        }

        bool Validate_Employee_Replace()
        {
            bool validate = true;
            if (chk3_3.Checked)
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
                if (!chk3_1.Checked)
                    if (!chk3_2.Checked)
                        if (!chk3_3.Checked)
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
                if (chk3_1.Checked)
                    if (!uc_Upload2.Validate())
                    {
                        if (LinkButton2.Text == "")
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
                if (chk3_1.Checked && opt_outButget.Checked)
                    if (!uc_Upload1.Validate())
                    {
                        if (LinkButton1.Text == "")
                            validate = false;
                    }
            }
            return validate;
        }

        bool Validate_Remark()
        {
            bool validate = true;
            if (ListItemType == 1 || ListItemType == 2)
            {
                String To_LineID = "";
                String To_DepID = "";
                String To_PosID = "";
                String To_LocationID = "";
                double Permanent_Sal = 0;
                double Permanent_Travel = 0;
                double Permanent_Allowance = 0;
                if (ddl_Line.Text != "")
                    To_LineID = ddl_Line.Text.Split(']')[0].Trim('[');
                if (ddl_Dep.Text != "")
                    To_DepID = ddl_Dep.Text.Split(']')[0].Trim('[');
                if (ddl_Pos.Text != "")
                    To_PosID = ddl_Pos.Text.Split(']')[0].Trim('[');
                if (ddl_Location.Text != "")
                    To_LocationID = ddl_Location.Text.Split(']')[0].Trim('[');
                if (txtBasicSal_new.Text != "")
                    Permanent_Sal = double.Parse(txtBasicSal_new.Text.Replace(",", "").Replace(".", ""));
                if (txtTransAllow_new.Text != "")
                    Permanent_Travel = double.Parse(txtTransAllow_new.Text.Replace(",", "").Replace(".", ""));
                if (txtOtherAllow_new.Text != "")
                    Permanent_Allowance = double.Parse(txtOtherAllow_new.Text.Replace(",", "").Replace(".", ""));

                // Kiem tra thay doi gia tri de xuat
                if (To_LineID != item.To_LineID)
                {
                    validate = false;
                }
                else if (To_DepID != item.To_DepID)
                {
                    validate = false;
                }
                else if (To_PosID != item.To_PosID)
                {
                    validate = false;
                }
                else if (To_LocationID != item.To_LocationID)
                {
                    validate = false;
                }
                else if (Permanent_Sal != item.Permanent_Sal)
                {
                    validate = false;
                }
                else if (Permanent_Travel != item.Permanent_Travel)
                {
                    validate = false;
                }
                else if (Permanent_Allowance != item.Permanent_Allowance)
                {
                    validate = false;
                }
                else if (item.Other_new != txtOther_new.Text)
                {
                    validate = false;
                }
                else if (item.Other_newValue != txtA_HotlineNew.Text)
                {
                    validate = false;
                }
            }
            else
            {
                if (ddl_Line2.Text != "")
                    validate = false;
                if (ddl_Dep2.Text != "")
                    validate = false;
                if (ddl_Pos2.Text != "")
                    validate = false;
                if (ddl_Location2.Text != "")
                    validate = false;
                if (txtBasicSal_new2.Text != "")
                    if (item.Permanent_Sal != double.Parse(txtBasicSal_new2.Text.Replace(",", "").Replace(".", "")))
                        validate = false;
                if (txtTransAllow_new2.Text != "")
                    if (item.Permanent_Travel != double.Parse(txtTransAllow_new2.Text.Replace(",", "").Replace(".", "")))
                        validate = false;
                if (txtOtherAllow_new2.Text != "")
                    if (item.Permanent_Allowance != double.Parse(txtOtherAllow_new2.Text.Replace(",", "").Replace(".", "")))
                        validate = false;
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
                txtEmpID.Text = input.ToUpper();
                txtEmpName.Text = (dt.Rows[0]["EmployeeName"] == DBNull.Value ? "" : dt.Rows[0]["EmployeeName"].ToString());
                txtPos.Text = (dt.Rows[0]["PosName"] == DBNull.Value ? "" : dt.Rows[0]["PosName"].ToString());
                txtLine.Text = (dt.Rows[0]["LineName"] == DBNull.Value ? "" : dt.Rows[0]["LineName"].ToString());
                txtDep.Text = (dt.Rows[0]["DepName"] == DBNull.Value ? "" : dt.Rows[0]["DepName"].ToString());
                txtLocation.Text = (dt.Rows[0]["LocationName"] == DBNull.Value ? "" : dt.Rows[0]["LocationName"].ToString());

                txtPos_old.Text = (dt.Rows[0]["PosName"] == DBNull.Value ? "" : dt.Rows[0]["PosName"].ToString());
                txtLine_old.Text = (dt.Rows[0]["LineName"] == DBNull.Value ? "" : dt.Rows[0]["LineName"].ToString());
                txtDep_old.Text = (dt.Rows[0]["DepName"] == DBNull.Value ? "" : dt.Rows[0]["DepName"].ToString());
                txtLocation_old.Text = (dt.Rows[0]["LocationName"] == DBNull.Value ? "" : dt.Rows[0]["LocationName"].ToString());

                //if (Is_HRCreater(Session["EmployeeID"].ToString()) ||
                //    Is_HRDirector(Session["EmployeeID"].ToString()) || 
                //    Is_GeneralDirector(Session["EmployeeID"].ToString()) ||
                //    Is_CBManager(Session["EmployeeID"].ToString()))
                // Check quyen xem 
                bool isLineManager = new Cand_Request_OnlineService().IsLineManager(input, Session["EmployeeID"].ToString());
                if (isLineManager == true ||
                    Is_CBManager(Session["EmployeeID"].ToString()) ||
                    Is_HRDirector(Session["EmployeeID"].ToString()) ||
                    Is_GeneralDirector(Session["EmployeeID"].ToString()))
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

            // Part 3
            chk3_1.Checked = chk3_2.Checked = chk3_3.Checked = false;

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
            txtA_HotlineNew.Text = "";

            ddl_Pos2.Text = "";
            ddl_Line2.Text = "";
            ddl_Dep2.Text = "";
            ddl_Location2.Text = "";
            txtBasicSal_new2.Text = "";
            txtTransAllow_new2.Text = "";
            txtOtherAllow_new2.Text = "";
            txtOther_old.Text = "";
            txtOther_new2.Text = "";
            txtA_HotlineNew2.Text = "";

            // Part 5
            //txtStartDate.Text = "";
            cld_StartDate.Date = DateTime.Now;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //Code insert data into database
                tblCand_Request_Online new_Obj = new tblCand_Request_Online();
                new_Obj.EmpID_Apply = txtEmpID.Text.Trim();
                new_Obj.Apply_Name = txtEmpName.Text;
                new_Obj.RequestID = item.RequestID;
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
                if (chk3_1.Checked)
                {
                    new_Obj.ReasonID = "New";
                    if (opt_inButget.Checked == true)
                        new_Obj.IsBudgetHead = true;
                    else if (opt_outButget.Checked == true)
                        new_Obj.IsBudgetHead = false;
                }
                if (chk3_2.Checked)
                    new_Obj.ReasonID = "Inter";
                if (chk3_3.Checked)
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
                //new_Obj.IsBudgetHead = ;
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
                if (ListItemType == 1 || ListItemType == 2)
                {
                    if (txtBasicSal_new.Text != "")
                        new_Obj.Permanent_Sal = double.Parse(txtBasicSal_new.Text.Replace(",", "").Replace(".", ""));
                    if (txtTransAllow_new.Text != "")
                        new_Obj.Permanent_Travel = double.Parse(txtTransAllow_new.Text.Replace(",", "").Replace(".", ""));
                    if (txtOtherAllow_new.Text != "")
                        new_Obj.Permanent_Allowance = double.Parse(txtOtherAllow_new.Text.Replace(",", "").Replace(".", ""));
                }
                else
                {
                    if (txtBasicSal_new2.Text != "")
                        new_Obj.Permanent_Sal = double.Parse(txtBasicSal_new2.Text.Replace(",", "").Replace(".", ""));
                    if (txtTransAllow_new2.Text != "")
                        new_Obj.Permanent_Travel = double.Parse(txtTransAllow_new2.Text.Replace(",", "").Replace(".", ""));
                    if (txtOtherAllow_new2.Text != "")
                        new_Obj.Permanent_Allowance = double.Parse(txtOtherAllow_new2.Text.Replace(",", "").Replace(".", ""));
                }
                new_Obj.Requester = item.Requester;
                new_Obj.ReportTo = txtEmpOtherID.Text;
                //new_Obj.ApprovedBy = ;
                //new_Obj.ApprovedDate = ;
                //new_Obj.HRDept_Note = ;
                //new_Obj.ContractID = ;
                //new_Obj.EmpID_Other = ;
                if (ListItemType == 1 || ListItemType == 2)
                {
                    if (ddl_Line.Text != "")
                        new_Obj.To_LineID = ddl_Line.Text.Split(']')[0].Trim('[');
                    if (ddl_Dep.Text != "")
                        new_Obj.To_DepID = ddl_Dep.Text.Split(']')[0].Trim('[');
                    if (ddl_Pos.Text != "")
                        new_Obj.To_PosID = ddl_Pos.Text.Split(']')[0].Trim('[');
                    if (ddl_Location.Text != "")
                        new_Obj.To_LocationID = ddl_Location.Text.Split(']')[0].Trim('[');
                    new_Obj.Other_new = txtOther_new.Text;
                    new_Obj.Other_newValue = txtA_HotlineNew.Text;
                }
                else
                {
                    if (ddl_Line2.Text != "")
                        new_Obj.To_LineID = ddl_Line2.Text.Split(']')[0].Trim('[');
                    if (ddl_Dep2.Text != "")
                        new_Obj.To_DepID = ddl_Dep2.Text.Split(']')[0].Trim('[');
                    if (ddl_Pos2.Text != "")
                        new_Obj.To_PosID = ddl_Pos2.Text.Split(']')[0].Trim('[');
                    if (ddl_Location2.Text != "")
                        new_Obj.To_LocationID = ddl_Location2.Text.Split(']')[0].Trim('[');
                    new_Obj.Other_new = txtOther_new2.Text;
                    new_Obj.Other_newValue = txtA_HotlineNew2.Text;
                }
                new_Obj.Other_old = txtOther_old.Text;
                new_Obj.Other_oldValue = txtA_HotlineOld.Text;

                //new_Obj.OtherDescription = TextBox1.Text;
                //new_Obj.Other_old2Value = TextBox2.Text;
                //new_Obj.Other_new2Value = TextBox3.Text;

                // Remark
                new_Obj.Remarks = txtRemarks.Value;

                // UPDATE data
                if (Session["RecruitTmp"].ToString() == "True")
                {
                    Cand_Request_OnlineService.UpdateNews_2(new_Obj, Session["EmployeeID"], Session["LevelNo"], ListItemType);
                    //Cap nhat attachment
                    if (uc_Upload1.Validate())
                    {
                        uc_Upload1.Submit_Attach(new_Obj.RequestID, "CE");
                    }
                    if (uc_Upload2.Validate())
                    {
                        uc_Upload2.Submit_Attach(new_Obj.RequestID, "JD");
                    }
                }
                else
                {
                    // cap nhat tu DL tam
                    Cand_Request_OnlineService.CreateNews(new_Obj);
                    if (new_Obj.RequestID != null)
                    {
                        // cap nhat file attach
                        UpdateAttachment(Session["RequestID"].ToString(), new_Obj.RequestID);
                        if (uc_Upload1.Validate())
                        {
                            uc_Upload1.Submit_Attach(new_Obj.RequestID, "CE");
                        }
                        if (uc_Upload2.Validate())
                        {
                            uc_Upload2.Submit_Attach(new_Obj.RequestID, "JD");
                        }
                        // delete dl tam
                        DeletedItem(Session["RequestID"].ToString());
                    }
                }

                string message = "alert('" + GetGlobalResourceObject("RC_Registration", "AlertSuccess").ToString() + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "Infor", message, true);

                // return
                if (item.Requester == Session["EmployeeID"].ToString())
                    Response.Redirect("~/Recruitment/RegistrationView.aspx");
                else
                    Response.Redirect("~/Recruitment/Approval.aspx");
                //Response.Redirect("~/Recruitment/RegistrationView.aspx");
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

        protected void LinkButton1_Click(object sender, EventArgs e)
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

        protected void LinkButton2_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                txtEmpOtherName.Text = "";
            }
        }

        protected void ddl_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Dep.Text = "";
        }

        protected void ddl_Line2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Dep2.Text = "";
        }

        protected void btnNhapLai_Click(object sender, EventArgs e)
        {

            if (item.Requester == Session["EmployeeID"].ToString())
                Response.Redirect("~/Recruitment/RegistrationView.aspx");
            else
                Response.Redirect("~/Recruitment/Approval.aspx");
        }
    }
}