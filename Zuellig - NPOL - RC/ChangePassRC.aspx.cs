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
    public partial class ChangePassword_RC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null ||
                !Session["Role"].ToString().Equals("RC_Admin"))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            txtMKCu.Focus();
        }
        protected void lbtThayDoi_Click(object sender, EventArgs e)
        {
            //Validate
            if (IsValid == false)
            {
                return;
            }

            string UserName = Session["EmployeeID"].ToString();
            string Pass = txtMKMoi.Text.Trim();
            lbThongBao.Text = "";
            Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //Xét trường hợp là HR
            if (Session["Role"].ToString().Equals("RC_Admin"))
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
        }

        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ValidateOldPass() == false)
            {
                args.IsValid = false;
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        this.vThongBao.ErrorMessage = "Nhập mật khẩu không đúng.";
                        return;
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Input password is invalid.";
                        return;
                    }
                }
                else
                {
                    this.vThongBao.ErrorMessage = "Nhập mật khẩu không đúng.";
                    return;
                }
            }

            else if (txtMKMoi.Text != txtMKNhapLai.Text)
            {
                args.IsValid = false;
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        this.vThongBao.ErrorMessage = "Nhập mật khẩu không khớp.";
                        return;
                    }
                    else
                    {
                        this.vThongBao.ErrorMessage = "Input password is invalid.";
                        return;
                    }
                }
                else
                {
                    this.vThongBao.ErrorMessage = "Nhập mật khẩu không khớp.";
                    return;
                }
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

        protected void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMKMoi.Text = "";
            txtMKNhapLai.Text = "";
            txtMKMoi.Focus();
        }

        private bool ValidateOldPass()
        {
            bool result = true;
            try
            {
                // Validate old password
                string UserName = Session["EmployeeID"].ToString();
                string Pass = txtMKCu.Text.Trim();
                Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                //Xét trường hợp là HR
                if (Session["Role"].ToString().Equals("RC_Admin"))
                {
                    // Check old password
                    if (!kh.IsAdminLogin_v2(UserName, Pass))
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}