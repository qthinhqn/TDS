using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;
using System.Collections;

namespace NPOL
{
    public partial class AF_PassManagement : System.Web.UI.Page
    {
        string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            //Show report pass
            if (StaticCls.flagPass == 1)
            {
                Report.RandomPass report = new Report.RandomPass();
                //Gán datasource cho report
                if (StaticCls.dtPass != null)
                {
                    report.DataSource = StaticCls.dtPass;
                    report.DataMember = StaticCls.dtPass.TableName;
                }
                ASPxDocumentViewer1.Report = report;
            }
        }

        private void setAutoPass(object EmployeeID, object value)
        {
            khSqlServerProvider provider = new khSqlServerProvider(ketnoi);
            provider.CommandText = "Update tblEmployee set AutoPass = @value where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID", "@value" };
            provider.ValueCollection = new object[] { EmployeeID, value };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        private void resetPassAll()
        {
            khSqlServerProvider provider = new khSqlServerProvider(ketnoi);
            Khuong kh = new Khuong(ketnoi);
            SecurityProvider sec = new SecurityProvider();
            provider.CommandText = "Select EmployeeID from tblEmployee";
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    resetPassbySelection(dt.Rows[i]["EmployeeID"]);
                }
            }
            provider.CloseConnection();
        }

        private void resetPassbySelection(object EmployeeID)
        {
            khSqlServerProvider provider = new khSqlServerProvider(ketnoi);
            Khuong kh = new Khuong(ketnoi);
            SecurityProvider sec = new SecurityProvider();
            provider.CommandText = "Update tblEmployee set PayslipPassword = @Password, AutoPass = 0 where EmployeeID = @EmpID";
            provider.ParameterCollection = new string[] { "@Password", "@EmpID" };
            object newpass = sec.RCVEncPwd(kh.GetRandomPassword());
            newpass = sec.RCVDecPwd(newpass.ToString());
            provider.ValueCollection = new object[] { newpass, EmployeeID };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        static List<object> selectedRows = new List<object>();
        protected void gvPass_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            selectedRows.Clear();
            selectedRows = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            gvPass_SelectionChanged(gvPass, e);

            //Kiểm tra select checkbox
            if (selectedRows.Count <= 0)
            {
                string message = "alert('Vui lòng chọn nhân viên để thay đổi mật khẩu')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    object value = selectedRows[i];
                    resetPassbySelection(value);
                }
                gvPass.Selection.UnselectAll();
                gvPass.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void btnResetAll_Click(object sender, EventArgs e)
        {
            try
            {
                resetPassAll();
                gvPass.DataBind();
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void gvPass_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            SecurityProvider sec = new SecurityProvider();
            if (e.Column.Name == "pass")
            {
                object autopass = e.GetFieldValue("AutoPass");
                object pass = e.GetFieldValue("PayslipPassword");
                if (!autopass.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(autopass) == true)
                    {
                        if (!pass.ToString().Equals(""))
                        {
                            e.DisplayText = sec.RCVDecPwd(pass.ToString());
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        e.DisplayText = "Không hiển thị";
                    }
                }
                else
                {
                    e.DisplayText = "Không hiển thị";
                }
            }
        }

        protected void gvPass_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            object autopass = e.GetValue("AutoPass");
            object pass = e.GetValue("PayslipPassword");
            if (e.DataColumn.Name == "pass")
            {
                if (!autopass.ToString().Equals(""))
                {
                    if (Convert.ToBoolean(autopass) == true)
                    {
                        if (!pass.ToString().Equals(""))
                        {

                        }
                        else
                        {
                            e.Cell.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        e.Cell.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        static DataTable datasource = new DataTable();
        protected void btnView_Click(object sender, EventArgs e)
        {
            if (datasource.Columns.Count == 0)
            {
                datasource.Columns.Add("EmployeeID");
                datasource.Columns.Add("EmployeeName");
                datasource.Columns.Add("SectionName");
                datasource.Columns.Add("LineName");
                datasource.Columns.Add("PosName");
                datasource.Columns.Add("PayslipPassword");
            }
            else
            {
                datasource.Clear();
            }

            //Tổng hợp datasource
            ArrayList arr;
            for (int i = 0; i < gvPass.VisibleRowCount; i++)
            {
                arr = new ArrayList();
                arr.Add(gvPass.GetDataRow(i)["EmployeeID"]);
                arr.Add(gvPass.GetDataRow(i)["EmployeeName"]);
                arr.Add(gvPass.GetDataRow(i)["SectionName"]);
                arr.Add(gvPass.GetDataRow(i)["LineName"]);
                arr.Add(gvPass.GetDataRow(i)["PosName"]);
                object encryptedpass = gvPass.GetDataRow(i)["PayslipPassword"];
                if (!encryptedpass.ToString().Equals(""))
                {
                    object empid = gvPass.GetDataRow(i)["EmployeeID"];
                    //if (getAutoPass(empid).ToString().Equals("True"))
                    try {
                        object decryptedpass = new SecurityProvider().RCVDecPwd(encryptedpass.ToString());
                        arr.Add(decryptedpass);
                    }
                    catch { arr.Add(""); }
                    //else if (getAutoPass(empid).ToString().Equals("False"))
                    //{
                    //    arr.Add("Không hiển thị");
                    //}
                    //else
                    //{
                    //    arr.Add("");
                    //}
                }
                else
                {
                    arr.Add("");
                }
                datasource.Rows.Add(arr.ToArray());
            }
            StaticCls.dtPass = datasource;
            StaticCls.flagPass = 1;

        }

        private object getAutoPass(object EmployeeID)
        {
            object autopass = null;
            khSqlServerProvider provider = new khSqlServerProvider(ketnoi);
            provider.CommandText = "Select AutoPass from tblEmployee where EmployeeID = @EmpID";
            provider.ParameterCollection = new string[] { "@EmpID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                autopass = dt.Rows[0]["AutoPass"];
            }
            provider.CloseConnection();
            return autopass;
        }
    }
}