using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace NPOL
{
    public partial class ForgotPassword : Class1
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate page
            if (Session["txtUserName"] == null || Session["txtUserName"].ToString().Equals(""))
            {
                Response.Redirect("Login.aspx");
            }

            //Reset lbMessage
            lbMessage.Text = "";

            if (!IsPostBack)
            {
                //Show info
                if (Session["txtUserName"] != null)
                {
                    txtUserName.Text = Session["txtUserName"].ToString();
                    Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
                    if (kh.getEmpEmail(Session["txtUserName"].ToString()) != null)
                    {
                        txtEmail.Text = kh.getEmpEmail(Session["txtUserName"].ToString());
                    }
                }
            }

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtUserName.Focus();
        }

        protected void btnGetPass_Click(object sender, EventArgs e)
        {
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            string pass = kh.GetRandomPassword();
            string encryptpass = kh.getEncryptPassAdmin(pass);
            string username = txtUserName.Text.Trim();

            //Xét trường hợp là Admin (HR)
            if (kh.IsAdmin(username))
            {
                //Update password into tblUser
                if (kh.UpdatePasswordAdmin(encryptpass, username))
                {
                    //Send email to user
                    if (kh.SendMail(txtEmail.Text, "Auto Generation Password", pass))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                lbMessage.Text = "Mật khẩu đã gửi thành công đến email của bạn " + txtEmail.Text;
                            }
                            else
                            {
                                lbMessage.Text = "New password has ben sent to your email address " + txtEmail.Text;
                            }
                        }
                        else
                        {
                            lbMessage.Text = "Mật khẩu đã gửi thành công đến email của bạn " + txtEmail.Text;
                        }

                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                lbMessage.Text = "Gửi mail không thành công. Vui lòng thử lại!";
                            }
                            else
                            {
                                lbMessage.Text = "Sending fail. Please try again!";
                            }
                        }
                        else
                        {
                            lbMessage.Text = "Gửi mail không thành công. Vui lòng thử lại!";
                        }
                    }
                }
            }
            else
            {
                //Update password into database
                if (kh.UpdatePassword(pass, username))
                {
                    //Send email to user
                    if (kh.SendMail(txtEmail.Text, "Auto Generation Password", pass))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                lbMessage.Text = "Mật khẩu đã gửi thành công đến email của bạn " + txtEmail.Text;
                            }
                            else
                            {
                                lbMessage.Text = "New password has ben sent to your email address " + txtEmail.Text;
                            }
                        }
                        else
                        {
                            lbMessage.Text = "Mật khẩu đã gửi thành công đến email của bạn " + txtEmail.Text;
                        }

                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                lbMessage.Text = "Gửi mail không thành công. Vui lòng thử lại!";
                            }
                            else
                            {
                                lbMessage.Text = "Sending fail. Please try again!";
                            }
                        }
                        else
                        {
                            lbMessage.Text = "Gửi mail không thành công. Vui lòng thử lại!";
                        }
                    }
                }
            }

        }

        protected void vCustomUserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string UserName = txtUserName.Text;
            bool monitor = false;
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);

            System.Collections.ArrayList arrManagerColumnNames = new System.Collections.ArrayList();
            arrManagerColumnNames.Add("ManagerID_L1");
            arrManagerColumnNames.Add("ManagerID_L2");
            arrManagerColumnNames.Add("ManagerID_L3");
            string tableName = "tblEmpManagerLevel";

            //Xét trường hợp vừa là Manager vừa là Employee
            if (kh.IsEmployee(UserName) && !kh.IsNewEmployee(UserName) && kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName) != null)
            {
                monitor = true;
            }
            else
            {
                //Xet truong hop la nhan vien cu
                if (kh.IsEmployee(UserName) && !kh.IsNewEmployee(UserName))
                {
                    monitor = true;
                }

                //Xet truong hop chi la manager
                if (!kh.IsEmployee(UserName) && kh.IsEmployeeOrigin(UserName) && kh.IsApprovalManager(tableName, arrManagerColumnNames, UserName) != null)
                {
                    monitor = true;
                }

                //Xet truong hop la HR
                if (kh.IsAdmin(UserName))
                {
                    monitor = true;
                }
            }

            if (!monitor)
            {
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        vCustomUserName.ErrorMessage = "Mã nhân viên không hợp lệ";
                    }
                    else
                    {
                        vCustomUserName.ErrorMessage = "EmployeeID is invalid";
                    }
                }
                else
                {
                    vCustomUserName.ErrorMessage = "Mã nhân viên không hợp lệ";
                }
                args.IsValid = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

    }
}