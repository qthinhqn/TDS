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
    public partial class AF_ChangePassword : System.Web.UI.Page
    {
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
            }
            
            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }


            txtMKMoi.Focus();
            
        }
        protected void lbtThayDoi_Click(object sender, EventArgs e)
        {
            string UserName = Session["EmployeeID"].ToString();
            string Pass = txtMKMoi.Text.Trim();
            lbThongBao.Text = "";
            Khuong kh = new Khuong(conn.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //Xét trường hợp là HR
            if (Session["Role"].ToString().Equals("HR"))
            {
                if (ASPxCheckBox1.Checked)
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
                    if (kh.UpdatePasswordEmail(Pass, drLoainghi.SelectedItem.Value.ToString()))
                    {
                        //Update AutoPass = 0
                        setAutoPass(UserName, "0");

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

        protected void ASPxCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            drLoainghi.Enabled = !ASPxCheckBox1.Checked;
        }

        
    }
}