using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace NPOL
{
    public partial class Login : Class1
    {
        string ConString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nạp chuỗi kết nối ConString
            ConString = new Khuong().getDecryptConString();

            //Reset Session
            //Session.Remove("EmployeeID");
            //Session.Remove("Role");
            //Session.Remove("MID1");
            //Session.Remove("MID2");
            //Session.Remove("MID3");
            //Session.Remove("txtUserName");
            //Session.Remove("CR_SalTypeID");
            //Session.Remove("CR_YearID");
            //Session.Remove("CR_MonthID");
            //Session.Remove("CR_FromDate");
            //Session.Remove("CR_ToDate");
            //Session.Remove("YearID");
            Session.Clear();

            //Get account cookie
            if (!IsPostBack)
            {
                if (Request.Cookies["ckUserName"] != null && Request.Cookies["ckPassword"] != null)
                {
                    txtUserName.Text = Request.Cookies["ckUserName"].Value;
                    txtPass.Attributes["value"] = Request.Cookies["ckPassword"].Value;
                    chkRemember.Checked = true;
                }
            }
        }

        protected void lbtForgot_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPass.Text.Trim();
            //bool monitor = false;
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            string Email = kh.getEmpPayslipEmail(UserName);

            #region Kiem tra user đăng nhập bằng EmployeeID hay Email
            if (kh.getEmpPayslipEmail(UserName) == null && kh.getEmpID(UserName) == null)
            {
                //monitor = false;
            }
            else
            {
                //Đăng nhập bằng EmployeeID
                if (kh.getEmpPayslipEmail(UserName) != null)
                {

                }
                //Đăng nhập bằng Email
                if (kh.getEmpID(UserName) != null)
                {
                    UserName = kh.getEmpID(UserName);
                }
            }
            #endregion

            #region Xet truong hop la nhan vien moi
            //if (kh.IsEmployee(UserName) && kh.IsNewEmployee(UserName))
            //{
            //    Session["EmployeeID"] = UserName.ToUpper();
            //    Session["Role"] = "E1";
            //    //monitor = true;
            //    Response.Redirect("ChangePass_1st.aspx");
            //}
            #endregion

            #region Ngược lại không phải là nhân viên mới
            //else
            {
                #region Trường hơp để trống Tên đăng nhập
                if (txtUserName.Text.Equals(""))
                {
                    string message = null;

                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            message = "alert('Vui lòng nhập mã nhân viên');";
                        }
                        else
                        {
                            message = "alert('Please enter your EmployeeID');";
                        }
                    }
                    else
                    {
                        message = "alert('Vui lòng nhập mã nhân viên');";
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                #endregion
                #region Xét trường hợp tên đăng nhập không hợp lệ
                else if (!kh.IsEmployee(UserName))
                {
                    string message = null;

                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            message = "alert('Mã nhân viên không hợp lệ');";
                        }
                        else
                        {
                            message = "alert('EmployeeID is incorrect');";
                        }
                    }
                    else
                    {
                        message = "alert('Mã nhân viên không hợp lệ');";
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                #endregion
                #region Trường hợp nhân viên chưa có email để nhận mật khẩu --mới
                else if (Email == null || Email.Equals(""))
                {
                    //Session["txtUserName"] = txtUserName.Text;
                    //Response.Redirect("ForgotPassword.aspx");
                    string message = null;
                    // kiem tra nv con lam viec khong?
                    if (kh.IsEmployeeResign(UserName))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                message = "alert('Nhân viên không có quyền truy cập vì đã nghỉ việc!');";
                            }
                            else
                            {
                                message = "alert('You do not have access because your have been resigned!');";
                            }
                        }
                        else
                        {
                            message = "alert('Nhân viên không có quyền truy cập vì đã nghỉ việc!');";
                        }
                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                message = "alert('Bạn chưa đăng ký email để nhận mật khẩu');";
                            }
                            else
                            {
                                message = "alert('You have not yet registerd email to receive new password');";
                            }
                        }
                        else
                        {
                            message = "alert('Bạn chưa đăng ký email để nhận mật khẩu');";
                        }
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                }
                #endregion
                #region Trường hợp hợp lệ để nhận mật khẩu
                else
                {
                    SendAutoCode(UserName);
                }
                #endregion
            }
            #endregion
        }
        private void SendAutoCode(string UserName)
        {
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            string passcontent = "";
            string randompass = kh.GetRandomPassword();
            //string currentpass = kh.GetCurrentPassword(UserName);
            string username = txtUserName.Text.Trim();
            string email = kh.getEmpPayslipEmail(UserName);
            string message = "";
            //Insert Auto password into database
            randompass = kh.InsertAutoCode(randompass, username);
            if (randompass != "")
            {
                //Tạo nội dung cần gửi
                passcontent += "<table border=1 width=100% style=\"width:100.0%;border:solid windowtext 1.0pt\">";

                passcontent += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                passcontent += "<td>Mã NV</td>";
                passcontent += "<td>Họ Tên</td>";
                //passcontent += "<td>Mật khẩu mới</td>";
                passcontent += "<td>Mật khẩu</td>";
                passcontent += "</tr>";

                passcontent += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                passcontent += "<td>EmployeeID</td>";
                passcontent += "<td>Full Name</td>";
                //passcontent += "<td>New password</td>";
                passcontent += "<td>Password</td>";
                passcontent += "</tr>";

                passcontent += "<tr>";
                passcontent += "<td>" + username.ToUpper() + "</td>";
                passcontent += "<td>" + kh.getEmployeeName(username) + "</td>";
                passcontent += "<td>" + randompass + "</td>";
                //passcontent += "<td>" + currentpass + "</td>";
                passcontent += "<tr>";

                passcontent += "</table>";

                passcontent += "<p class=MsoNormal><i>"
                            + "Mật khẩu này sẽ hết hạn trong ngày, vì vậy hãy đảm bảo sử dụng ngay."
                            + "<br/>"
                            + "Nếu bạn không thực hiện yêu cầu thay đổi mật khẩu xin vui lòng bỏ qua email này."
                            + "</i></p>";
                passcontent += "<p class=MsoNormal><i>"
                            + "This random password expire in day, so be sure to use it right away."
                            + "<br/>"
                            + "If you do not make a password change request, please disregard this email."
                            + "</i></p>";


                //Send email to user
                MyLogs.LogInfo("Start send email to " + email + "...");
                try
                {
                    if (kh.SendMail(email, "Auto Send Password", passcontent))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                message = "alert('Mật khẩu đã gửi thành công đến email của bạn: " + email + "')";
                            }
                            else
                            {
                                message = "alert('New password has ben sent to your email address: " + email + "')";
                            }
                        }
                        else
                        {
                            message = "alert('Mật khẩu đã gửi thành công đến email của bạn: " + email + "')";
                        }
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                message = "alert('Gửi mail không thành công. Vui lòng thử lại!')";
                            }
                            else
                            {
                                message = "alert('Sending fail. Please try again!')";
                            }
                        }
                        else
                        {
                            message = "alert('Gửi mail không thành công. Vui lòng thử lại!')";
                        }
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                    }
                }
                catch (Exception ex)
                {
                    MyLogs.LogError(ex);
                }
                MyLogs.LogInfo("... END ...");
            }
        }
        private void setAutoPass(object EmployeeID, object value)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Update tblEmployee set AutoPass = @value where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@value" };
            provider.ValueCollection = new object[] { EmployeeID, value };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        private bool IsAutoPass(object EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select AutoPass from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                object autopass = dt.Rows[0]["AutoPass"];
                if (!autopass.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(autopass) == true)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
            }
            else
            {
                value = true;
            }

            return value;
        }

        protected void vn_Click(object sender, ImageClickEventArgs e)
        {
            Session["lang"] = "vi";
            //Set cookie CultureInfo for Master Page
            SetCultureInfo();
            Response.Redirect("Login.aspx");
        }

        protected void en_Click(object sender, ImageClickEventArgs e)
        {
            Session["lang"] = "en";
            //Set cookie CultureInfo for Master Page
            SetCultureInfo();
            Response.Redirect("Login.aspx");
        }
        private void SetCultureInfo()
        {
            HttpCookie cookie = Request.Cookies["CultureInfo"];

            if (Session["lang"] == null)
            {
                if (cookie == null)
                {
                    //Tao moi cookie CultureInfo
                    cookie = new HttpCookie("CultureInfo");
                    cookie.Value = "vi-VN";
                    Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Value = "vi-VN";
                    Response.Cookies.Add(cookie);
                }
            }
            else
            {
                string lang = "";
                lang = Convert.ToString(Session["lang"]);
                if (lang.ToLower() == "vi")
                {
                    if (cookie == null)
                    {
                        //Tao moi cookie CultureInfo
                        cookie = new HttpCookie("CultureInfo");
                        cookie.Value = "vi-VN";
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        cookie.Value = "vi-VN";
                        Response.Cookies.Add(cookie);
                    }
                }
                if (lang.ToLower() == "en")
                {
                    if (cookie == null)
                    {
                        //Tao moi cookie CultureInfo
                        cookie = new HttpCookie("CultureInfo");
                        cookie.Value = "en-US";
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        cookie.Value = "en-US";
                        Response.Cookies.Add(cookie);
                    }
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPass.Text = "";
            txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Save cookie login information
            if (chkRemember.Checked)
            {
                Response.Cookies["ckUserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["ckPassword"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["ckUserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ckPassword"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies["ckUserName"].Value = txtUserName.Text.Trim();
            Response.Cookies["ckPassword"].Value = txtPass.Text.Trim();

            //if (txtUserName.Text.Trim().ToLower() == "paadmin")
            //{
            //    Response.Redirect("PerformanceAssessment/login.aspx");
            //}

            //Validate
            if (IsValid == false)
            {
                return;
            }
            else
            {
                // set default CultureInfo for Foreigner
                if (IsForeigner(Session["EmployeeID"]))
                {
                    Session["lang"] = "en";
                    //Set cookie CultureInfo for Master Page
                    SetCultureInfo();
                }
                else
                {
                    Session["lang"] = "vi";
                    //Set cookie CultureInfo for Master Page
                    SetCultureInfo();
                }

                if (Session["Role"].ToString().Equals("E1"))
                {
                    //Session.Timeout = 10;
                    Response.Redirect("ChangePass_1st.aspx");
                }
                if (Session["Role"].ToString().Equals("E2"))
                {
                    //Session.Timeout = 10;

                    //Nếu đăng nhập bằng mật khẩu ngẫu nhiên do C&B cung cấp thì phải thay đổi mật khẩu khi đăng nhập thành công
                    if (IsAutoPass(Session["EmployeeID"]))
                    {
                        Response.Redirect("ChangePass_1st.aspx");
                    }
                    else
                    {
                        Session["ActiveTab"] = 0;
                        //Response.Redirect("F_Registration1.aspx");
                        Response.Redirect("hrnews.aspx");
                    }
                }
                if (Session["Role"].ToString().Substring(0, 1).Equals("M"))
                {
                    //Session.Timeout = 30;
                    //Nếu đăng nhập bằng mật khẩu ngẫu nhiên do C&B cung cấp thì phải thay đổi mật khẩu khi đăng nhập thành công
                    if (IsAutoPass(Session["EmployeeID"]))
                    {
                        Response.Redirect("ChangePass_1st.aspx");
                    }
                    else
                    {
                        Session["ActiveTab"] = 1;
                        //Response.Redirect("AF_ApprovalNew.aspx");
                        Response.Redirect("hrnews.aspx");
                    }
                }
                if (Session["Role"].ToString().Equals("HR"))
                {
                    //Session.Timeout = 30;
                    Session["ActiveTab"] = 1;
                    Response.Redirect("AF_HRNew.aspx");
                    //Response.Redirect("hrnews.aspx");
                }
                if (Session["Role"].ToString().Equals("PA_Admin"))
                {
                    //Session.Timeout = 30;
                    Session["ActiveTab"] = 0;
                    Response.Redirect("Ad_ManagerPALevel.aspx");
                }
                if (Session["Role"].ToString().Equals("RC_Admin"))
                {
                    Session["lang"] = "vi";
                    SetCultureInfo();
                    //Session.Timeout = 30;
                    Session["ActiveTab"] = 0;
                    Response.Redirect("Recruitment/Ad_ManagerLevelNew.aspx");
                }
            }
        }

        DateTime limit = new DateTime(2016, 12, 31);
        protected void vLogin_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPass.Text.Trim();
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

            //Limit license period
            //int compare = DateTime.Compare(DateTime.Today, limit);
            //if (compare > 0)
            //{
            //    args.IsValid = false;
            //    vLogin.ErrorMessage = "Please contact with programer. Thanks.";
            //    return;
            //}

            //Kiem tra user đăng nhập bằng EmployeeID hay Email
            if (kh.getEmpPayslipEmail(UserName) == null && kh.getEmpID(UserName) == null)
            {
                if (!kh.IsAdmin(UserName))
                {
                    args.IsValid = false;
                }

            }
            else
            {
                //Đăng nhập bằng EmployeeID
                if (kh.getEmpPayslipEmail(UserName) != null)
                {

                }
                //Đăng nhập bằng Email
                if (kh.getEmpID(UserName) != null)
                {
                    UserName = kh.getEmpID(UserName);
                }
            }

            string NewEmployeeID = GetNewEmployeeID(UserName);
            if (NewEmployeeID == "")
            {
                // loai  truong  hop nhan vien da nghi viec
                if (isResign(UserName))
                {
                    args.IsValid = false;
                }
            }

            //Xet truong hop la nhan vien dang nhap bang autocode
            if (kh.IsEmployee(UserName) && kh.IsUseAutoCode(Password, UserName))
            {
                Session["EmployeeID"] = UserName.ToUpper();
                Session["Role"] = "E1";
                return;
            }


            ArrayList arrManagerColumnNames = new ArrayList();
            arrManagerColumnNames.Add("ManagerID_L1");
            arrManagerColumnNames.Add("ManagerID_L2");
            arrManagerColumnNames.Add("ManagerID_L3");
            string tableName = "tblEmpManagerLevel";

            # region Xét trường hợp vừa là Employee vừa là Approval Manager
            if (kh.IsEmployee(UserName) //&& !kh.IsNewEmployee(UserName) 
                && kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName) != null)
            {
                if (kh.IsLogin(UserName, Password))
                {
                    Session["EmployeeID"] = UserName.ToUpper();
                    string columnName = kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName);
                    if (String.Compare(columnName, "ManagerID_L1", true) == 0)
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        Session["Role"] = "M1";
                    }
                    if (String.Compare(columnName, "ManagerID_L2", true) == 0)
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        Session["Role"] = "M2";
                    }
                    if (String.Compare(columnName, "ManagerID_L3", true) == 0)
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        Session["Role"] = "M3";
                    }

                    ArrayList result = kh.getManagerIDList("tblEmpManagerLevel", arrManagerColumnNames, UserName);
                    Session["MID1"] = result[0].ToString();
                    Session["MID2"] = result[1].ToString();
                    Session["MID3"] = result[2].ToString();
                }
                else
                {
                    args.IsValid = false;
                }
            }
            #endregion
            else
            {
                #region Xet truong hop la nhan vien cu
                if (kh.IsEmployee(UserName)) //&& !kh.IsNewEmployee(UserName))
                {
                    if (kh.IsLogin(UserName, Password))
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        Session["Role"] = "E2";
                        ArrayList result = kh.getManagerIDList("tblEmpManagerLevel", arrManagerColumnNames, UserName);
                        Session["MID1"] = result[0].ToString();
                        Session["MID2"] = result[1].ToString();
                        Session["MID3"] = result[2].ToString();
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                #endregion
                #region Xet truong hop chi la Manager
                if (!kh.IsEmployee(UserName) && kh.IsEmployeeOrigin(UserName) && kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName) != null)
                {
                    if (kh.IsLogin(UserName, Password))
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        string columnName = kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName);
                        if (String.Compare(columnName, "ManagerID_L1", true) == 0)
                        {
                            Session["Role"] = "M1";
                        }
                        if (String.Compare(columnName, "ManagerID_L2", true) == 0)
                        {
                            Session["Role"] = "M2";
                        }
                        if (String.Compare(columnName, "ManagerID_L3", true) == 0)
                        {
                            Session["Role"] = "M3";
                        }
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                #endregion
                #region Xét trường hợp là HR
                if (Session["EmployeeID"] == null && Session["Role"] == null)
                {
                    if (kh.IsAdminLogin_v2(UserName, Password))
                    {
                        Session["EmployeeID"] = UserName.ToUpper();
                        if (UserName.ToUpper() == "PAADMIN")
                            Session["Role"] = "PA_Admin";
                        else if (UserName.ToUpper() == "OTADMIN")
                            Session["Role"] = "OT_Admin";
                        else if (UserName.ToUpper() == "RCADMIN")
                            Session["Role"] = "RC_Admin";
                        else
                            Session["Role"] = "HR";
                    }
                    // xet role PA
                    else if (kh.isPARole(UserName))
                    {
                        if (kh.IsLogin(UserName, Password))
                        {
                            Session["EmployeeID"] = UserName.ToUpper();
                            Session["Role"] = "E2";
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                    // xet role RC
                    else if (kh.isRCRole(UserName))
                    {
                        if (kh.IsLogin(UserName, Password))
                        {
                            Session["EmployeeID"] = UserName.ToUpper();
                            Session["Role"] = "E2";
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                #endregion
            }

        }

        private bool IsForeigner(object EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select isForeigner from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                object isForeigner = dt.Rows[0]["isForeigner"];
                if (!isForeigner.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(isForeigner) == true)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                    }
                }
            }
            else
            {
                value = false;
            }

            return value;
        }

        private string GetNewEmployeeID(object EmployeeID)
        {
            string value = "";
            try
            {
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
            }
            catch (Exception ex) { }

            return value;
        }
        private bool isResign(object EmployeeID)
        {
            bool value = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "sp_isResign";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = true;
                }
            }
            catch (Exception ex) { }
            return value;
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            // [10.08.17] Kiem tra user DN bang OldEmployeeID
            string NewEmployeeID = GetNewEmployeeID(txtUserName.Text);
            if (txtUserName.Text.Trim() != "" && NewEmployeeID != "")
            {
                // Show warning
                string message = "";
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        message = "Bạn đang đăng nhập bằng mã cũ. Hãy đăng nhập bằng mã: " + NewEmployeeID.ToUpper() + " để đăng ký nghỉ phép.";
                    }
                    else
                    {
                        message = "You are login by old code. Please user new EmployeeID: " + NewEmployeeID.ToUpper() + " to registration annual leave.";
                    }
                }
                else
                {
                    message = "Bạn đang đăng nhập bằng mã cũ. Hãy đăng nhập bằng mã: " + NewEmployeeID.ToUpper() + " để đăng ký nghỉ phép.";
                }

                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                lblOldEmployee.Text = message;
                return;
            }
            else
                lblOldEmployee.Text = "";
        }
    }
}