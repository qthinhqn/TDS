using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NPOL
{
    public partial class ChangePass_1st : Class1
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Validate Page
            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                //if (!Session["Role"].ToString().Equals("E1"))
                //{
                //    if (!(Session["Role"].ToString().Equals("E2") && IsAutoPass(Session["EmployeeID"])))
                //    {
                //        Response.Redirect("Login.aspx");
                //    }

                //    if (!(Session["Role"].ToString().Substring(0, 1).Equals("M") && IsAutoPass(Session["EmployeeID"])))
                //    {
                //        Response.Redirect("Login.aspx");
                //    }                    
                //}     

                //Nếu là nhân viên cũ
                if (Session["Role"].ToString().Equals("E2"))
                {
                    if (!IsAutoPass(Session["EmployeeID"]))
                    {
                        Response.Redirect("Login.aspx");
                    }
                }

                //Nếu là manager
                if (Session["Role"].ToString().Substring(0, 1).Equals("M"))
                {
                    if (!IsAutoPass(Session["EmployeeID"]))
                    {
                        Response.Redirect("Login.aspx");
                    }
                }

                //Nếu là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            //Set display status of language flag
            if (Session["lang"] == null)
            {
                this.vn.Visible = false;
                this.en.Visible = true;
            }
            else
            {
                string lang = "";
                lang = Convert.ToString(Session["lang"]);
                if (lang.ToLower() == "vi")
                {
                    this.vn.Visible = false;
                    this.en.Visible = true;
                }
                if (lang.ToLower() == "en")
                {
                    this.vn.Visible = true;
                    this.en.Visible = false;
                }
            }


        }

        private bool IsAutoPass(object EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtPassNew.Text = "";
            txtConfirmPassNew.Text = "";
            txtPassNew.Focus();
        }

        protected void vn_Click(object sender, ImageClickEventArgs e)
        {
            Session["lang"] = "vi";
            //Set cookie CultureInfo for Master Page
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
            Response.Redirect("ChangePass_1st.aspx");
        }

        protected void en_Click(object sender, ImageClickEventArgs e)
        {
            Session["lang"] = "en";
            //Set cookie CultureInfo for Master Page
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
            Response.Redirect("ChangePass_1st.aspx");
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Update tblEmployee Set Logon_Password = @Logon_Password, Logon_IsNew = @Logon_IsNew where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@Logon_Password", "@Logon_IsNew" };
            string pass = new SecurityProvider().RCVEncPwd(txtPassNew.Text.Trim());
            string empid = Session["EmployeeID"].ToString();
            provider.ValueCollection = new object[] { empid, pass, 0 };
            int i = provider.ExecuteNonQuery();
            provider.CloseConnection();

            if (i > 0)
            {
                //Update AutoPass = 0
                setAutoPass(empid, "0");

                Response.Redirect("Login.aspx");
            }
        }

        private void setAutoPass(object EmployeeID, object value)
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            provider.CommandText = "Update tblEmployee set AutoPass = @value where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@value" };
            provider.ValueCollection = new object[] { EmployeeID, value };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }
    }
}