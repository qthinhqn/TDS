using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using conn = System.Web.Configuration;
using System.Data;

namespace NPOL
{
    public partial class F_ChangePassword2 : System.Web.UI.Page
    {
        ServerValidateEventArgs _args = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["Role"].ToString().Equals("E1"))
                {
                    Response.Redirect("ChangPass_1st.aspx");
                }
                else if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("F_ChangePassword.aspx"); 
                    //lbtPayslip.Enabled = false;
                }
            }

            if (!IsPostBack)
            {
            }

            txtMKCu.Focus();

        }
        protected void lbtThayDoi_Click(object sender, EventArgs e)
        {
            //Validate
            if (ValidateOldPass(1) == false)
            {
                return;
            }

            string UserName = Session["EmployeeID"].ToString();
            string Pass = txtMKMoi.Text.Trim();
            lbThongBao.Text = "";
            Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //Xét trường hợp là HR
            if (Session["Role"].ToString().Equals("HR"))
            {
                string encryptpass = kh.getEncryptPassAdmin_v2(Pass);
                if (kh.UpdatePasswordAdmin(encryptpass, UserName))
                {
                    //Thông báo thành công
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                        }
                        else
                        {
                            lbThongBao.Text = "Your password has been changed successfully.";
                        }
                    }
                    else
                    {
                        lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                    }
                }
                else
                {
                    //Thông báo thất bại
                }
            }
            else
            {
                if (kh.UpdateEPassword(Pass, UserName))
                {
                    //Thông báo thành công
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                        }
                        else
                        {
                            lbThongBao.Text = "Your password has been changed successfully.";
                        }
                    }
                    else
                    {
                        lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                    }
                }
                else
                {
                    //Thông báo thất bại
                }
            }

        }

        protected void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMKMoi.Text = "";
            txtMKNhapLai.Text = "";
            txtMKMoi.Focus();
        }

        private bool ValidateOldPass(int type)
        {
            bool result = true;
            try
            {
                // Validate old password
                string UserName = Session["EmployeeID"].ToString();
                string Pass = txtMKMoi.Text.Trim();
                Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                //Xét trường hợp là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    // Check old password
                    if (!kh.IsAdminLogin_v2(UserName, Pass))
                    {
                        result = false;
                    }
                }
                else
                {
                    // Check old password
                    switch (type)
                    {
                        case 1: // password logon
                            if (!kh.IsLogin(UserName, txtMKCu.Text.Trim()))
                            {
                                result = false;
                            }
                            break;
                        case 2: // password payslip
                            if (!kh.IsLogin_PayslipPass(UserName, txtMKCu.Text.Trim()))
                            {
                                result = false;
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }

        protected void lbtQuenPass_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = Session["EmployeeID"].ToString();
                //bool monitor = false;
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                #region Trường hợp nhân viên chưa có email để nhận mật khẩu --mới
                if (kh.getEmpPayslipEmail(UserName).Equals(""))
                {

                    //Session["txtUserName"] = txtUserName.Text;
                    //Response.Redirect("ForgotPassword.aspx");
                    string message = null;
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
            catch(Exception ex)
            { }
        }

        private void SendAutoCode(string UserName)
        {
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            string passcontent = "";
            string currentpass = kh.GetCurrentPassword(UserName);
            string email = kh.getEmpPayslipEmail(UserName);
            string message = "";
            if (currentpass != "")
            {
                //Tạo nội dung cần gửi
                passcontent += "<table border=1 width=100% style=\"width:100.0%;border:solid windowtext 1.0pt\">";

                passcontent += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                passcontent += "<td>Mã NV</td>";
                passcontent += "<td>Họ Tên</td>";
                //passcontent += "<td>Mật khẩu mới</td>";
                passcontent += "<td>Mật khẩu phiếu lương</td>";
                passcontent += "</tr>";

                passcontent += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                passcontent += "<td>EmployeeID</td>";
                passcontent += "<td>Full Name</td>";
                passcontent += "<td>Payslip Password</td>";
                passcontent += "</tr>";

                passcontent += "<tr>";
                passcontent += "<td>" + UserName.ToUpper() + "</td>";
                passcontent += "<td>" + kh.getEmployeeName(currentpass) + "</td>";
                passcontent += "<td>" + currentpass + "</td>";
                passcontent += "<tr>";

                passcontent += "</table>";

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
                                message = "alert('Payslip password has ben sent to your email address: " + email + "')";
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

        protected void lbtPayslip_Click(object sender, EventArgs e)
        {
            //Validate
            if (ValidateOldPass(2) == false)
            {
                lbThongBao.Text = GetGlobalResourceObject("ChangePassFirst", "vMissOldPass").ToString();
                return;
            }

            string UserName = Session["EmployeeID"].ToString();
            string Pass = txtMKMoi.Text.Trim();
            lbThongBao.Text = "";
            Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //Xét trường hợp là HR
            if (Session["Role"].ToString().Equals("HR"))
            {
                return;
            }
            else
            {
                if (kh.UpdatePayslipPassword(Pass, UserName))
                {
                    //Thông báo thành công
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                        }
                        else
                        {
                            lbThongBao.Text = "Your password has been changed successfully.";
                        }
                    }
                    else
                    {
                        lbThongBao.Text = "Mật khẩu đã thay đổi thành công.";
                    }
                }
                else
                {
                    //Thông báo thất bại
                }
            }
        }
    }
}