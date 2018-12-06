using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;
using System.Threading;
using System.Globalization;
using conn = System.Web.Configuration;


namespace NPOL
{
    public partial class AF_Approval : System.Web.UI.Page
    {
        ThProvider s = new ThProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());            
        static string EmpID = "";
        static string role = "";
        static int level;
        public static List<string> app = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                //Tru?ng h?p là nhân viên m?i ho?c nhân viên cu
                if (Session["Role"].ToString().Substring(0, 1).Equals("E"))
                {
                    Response.Redirect("Login.aspx");
                }

                //Tru?ng h?p là HR
                if (Session["Role"].ToString().Equals("HR"))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ConnectionString).getEmployeeName(Session["EmployeeID"].ToString());
            }

            Session["ActiveTab"] = 1;

            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                EmpID = Session["EmployeeID"].ToString();
            }
            role = Session["Role"].ToString();
            if (role == "M1")
            {
                level = 1;
            }
            else if (role == "M2")
            {
                level = 2;
            }
            else if (role == "M3")
            {
                level = 3;
            }
            else if (role == "HR")
            {
                Response.Redirect("AF_HR.aspx");
            }
            else if (role == "E2")
            {
                Response.Redirect("F_Registration1.aspx");
            }
            else
            {
                Response.Redirect("ChangePass_1st.aspx");
            }

            loaddata();
        }
        private void loaddata()
        {
            string lang;
            if (Session["lang"] == null)
            {
                lang = "vi";
            }
            else
            {
                lang = Session["lang"].ToString();
            }
            DataTable thct = new DataTable();
            if (level == 1)
            {
                thct = s.getdata1(EmpID, lang);
                ASPxGridView1.DataSource = thct;
                ASPxGridView1.DataBind();
            }
            if (level == 2)
            {
                thct = s.getdata2(EmpID, lang);
                ASPxGridView1.DataSource = thct;
                ASPxGridView1.DataBind();
            }
            if (level == 3)
            {
                thct = s.getdata3(EmpID, lang);
                ASPxGridView1.DataSource = thct;
                ASPxGridView1.DataBind();
            }

        }
        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            DataTable thct = new DataTable();
            int id = int.Parse(e.Keys[ASPxGridView1.KeyFieldName].ToString());
            thct = s.checkHR(id);
            DataView th = thct.DefaultView;
            ASPxComboBox combox = (ASPxComboBox)ASPxGridView1.FindEditFormTemplateControl("ASPxComboBox1");
            try
            {
                bool giatri1 = Boolean.Parse(combox.Value.ToString());
                int check = int.Parse(th[0].Row["CheckNum"].ToString());
                string m1 = th[0].Row["ManagerID_L1"].ToString();
                string m2 = th[0].Row["ManagerID_L2"].ToString();
                ASPxTextBox text = (ASPxTextBox)ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1");
                string txt1 = text.Text;
                if (level == 1)
                {
                    if (check > 1)
                    {
                        if (giatri1 == true)
                        {
                            s.UpdategetData1(id, txt1, giatri1, "w", 1, "b");
                        }
                        else
                        {
                            s.UpdategetData1(id, txt1, giatri1, "c", 0, "d");
                        }
                    }
                    else
                    {
                        if (giatri1 == true)
                        {
                            s.UpdategetData1(id, txt1, giatri1, "w", 0, "a");
                        }
                        else
                        {
                            s.UpdategetData1(id, txt1, giatri1, "c", 0, "d");
                        }
                    }
                }
                else if (level == 2)
                {
                    if (m2.Length > 0)
                    {
                        if (check > 2)
                        {
                            if (giatri1 == true)
                            {
                                s.UpdategetData2(id, txt1, giatri1, "w", 1, "b");
                            }
                            else
                            {
                                s.UpdategetData2(id, txt1, giatri1, "c", 0, "d");
                            }
                        }
                        else
                        {
                            if (giatri1 == true)
                            {
                                s.UpdategetData2(id, txt1, giatri1, "w", 0, "a");
                            }
                            else
                            {
                                s.UpdategetData2(id, txt1, giatri1, "c", 0, "d");
                            }
                        }
                    }
                    else
                    {
                        if (check > 1)
                        {
                            if (giatri1 == true)
                            {
                                s.UpdategetData1(id, txt1, giatri1, "w", 1, "b");
                            }
                            else
                            {
                                s.UpdategetData1(id, txt1, giatri1, "c", 0, "d");
                            }
                        }
                        else
                        {
                            if (giatri1 == true)
                            {
                                s.UpdategetData1(id, txt1, giatri1, "w", 0, "a");
                            }
                            else
                            {
                                s.UpdategetData1(id, txt1, giatri1, "c", 0, "d");
                            }
                        }
                    }
                }
                else if (level == 3)
                {
                    if (giatri1 == true)
                    {
                        s.UpdategetData3(id, txt1, giatri1, "w", "a");
                    }
                    else
                    {
                        s.UpdategetData3(id, txt1, giatri1, "c", "d");
                    }
                }
            }
            catch (Exception ex)
            {
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        ASPxGridView1.SettingsText.Title = "Chua xét duyệt";
                    }
                    else
                    {
                        ASPxGridView1.SettingsText.Title = "Not yet Aprroval";
                    }
                }
                else
                {
                    ASPxGridView1.SettingsText.Title = "Chua xét duyệt";
                }
            }
            loaddata();
            ASPxGridView1.CancelEdit();
            e.Cancel = true;
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBound(object sender, EventArgs e)
        {
            
            if (level == 1)
            {
                this.ASPxGridView1.Columns[1].Visible = false;
                this.ASPxGridView1.Columns[11].Visible = false;
                this.ASPxGridView1.Columns[12].Visible = false;
                this.ASPxGridView1.Columns[13].Visible = false;
                this.ASPxGridView1.Columns[14].Visible = false;
                this.ASPxGridView1.Columns[15].Visible = false;
                this.ASPxGridView1.Columns[16].Visible = false;
                this.ASPxGridView1.Columns[17].Visible = false;
                this.ASPxGridView1.Columns[18].Visible = false;
                this.ASPxGridView1.Columns[19].Visible = false;
                this.ASPxGridView1.Columns[20].Visible = false;
                this.ASPxGridView1.Columns[21].Visible = false;
            }
            else if (level == 2)
            {
                this.ASPxGridView1.Columns[1].Visible = false;
                this.ASPxGridView1.Columns[13].Visible = false;
                this.ASPxGridView1.Columns[14].Visible = false;
                this.ASPxGridView1.Columns[15].Visible = false;
                this.ASPxGridView1.Columns[16].Visible = false;
                this.ASPxGridView1.Columns[17].Visible = false;
                this.ASPxGridView1.Columns[18].Visible = false;
                this.ASPxGridView1.Columns[19].Visible = false;
                this.ASPxGridView1.Columns[20].Visible = false;
                this.ASPxGridView1.Columns[21].Visible = false;
            }
            else if (level == 3)
            {
                this.ASPxGridView1.Columns[1].Visible = false;
                this.ASPxGridView1.Columns[10].Visible = false;
                this.ASPxGridView1.Columns[11].Visible = false;
                this.ASPxGridView1.Columns[15].Visible = false;
                this.ASPxGridView1.Columns[16].Visible = false;
                this.ASPxGridView1.Columns[17].Visible = false;
                this.ASPxGridView1.Columns[18].Visible = false;
                this.ASPxGridView1.Columns[19].Visible = false;
                this.ASPxGridView1.Columns[20].Visible = false;
                this.ASPxGridView1.Columns[21].Visible = false;
            }
        }
        protected void ASPxGridView1_DetailRowGetButtonVisibility(object sender, ASPxGridViewDetailRowButtonEventArgs e)
        {
            e.ButtonState = GridViewDetailRowButtonState.Visible;
        }

        public String ASL()
        {
            string th = "";
            if (level == 1)
            {
                if (act1 == "True" || act1 == "true")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "duyệt";
                        }
                        else
                        {
                            th = "Approved";
                        }
                    }
                    else
                    {
                        th = "duyệt";
                    }
                }
                else if (act1 == "False" || act1 == "false")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Không duyệt";
                        }
                        else
                        {
                            th = "Cancel";
                        }
                    }
                    else
                    {
                        th = "Không duyệt";
                    }
                }
                else
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Chờ duyệt";
                        }
                        else
                        {
                            th = "Waiting";
                        }
                    }
                    else
                    {
                        th = "Chờ duyệt";
                    }
                }
            }
            else if (level == 2)
            {
                if (act2 == "True" || act2 == "true")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "duyệt";
                        }
                        else
                        {
                            th = "Approved";
                        }
                    }
                    else
                    {
                        th = "duyệt";
                    }
                }
                else if (act2 == "False" || act2 == "false")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Không duyệt";
                        }
                        else
                        {
                            th = "Cancel";
                        }
                    }
                    else
                    {
                        th = "Không duyệt";
                    }
                }
                else
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Chờ duyệt";
                        }
                        else
                        {
                            th = "Waiting";
                        }
                    }
                    else
                    {
                        th = "Chờ duyệt";
                    }
                }
            }
            else if (level == 3)
            {
                if (act3 == "True" || act3 == "true")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "duyệt";
                        }
                        else
                        {
                            th = "Approved";
                        }
                    }
                    else
                    {
                        th = "duyệt";
                    }
                }
                else if (act3 == "False" || act3 == "false")
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Không duyệt";
                        }
                        else
                        {
                            th = "Cancel";
                        }
                    }
                    else
                    {
                        th = "Không duyệt";
                    }
                }
                else
                {
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            th = "Chờ duyệt";
                        }
                        else
                        {
                            th = "Waiting";
                        }
                    }
                    else
                    {
                        th = "Chờ duyệt";
                    }
                }
            }
            return th;
        }

        public String ARL()
        {
            string th = "";
            if (level == 1) { th = "ApprovingReason_L1"; }
            else if (level == 2) { th = "ApprovingReason_L2"; }
            else if (level == 3) { th = "ApprovingReason_L3"; }
            return th;
        }
        static int ie;
        static string act1;
        static string act2;
        static string act3;
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            if (level == 1)
            {
                ie = int.Parse(e.EditingKeyValue.ToString());
                DataTable thct = new DataTable();
                thct = s.checkHR(ie);
                DataView th = thct.DefaultView;
                act1 = th[0].Row["ApprovingStatus_L1"].ToString();
                string active1 = th[0].Row["ApprovingStatus_L2"].ToString();
                string active2 = th[0].Row["HRCheckingStatus"].ToString();
                if ((active1 == "False" || active1 == "True") || (active2 == "False" || active2 == "True"))
                {
                    e.Cancel = true;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                        }
                        else
                        {
                            ASPxGridView1.SettingsText.Title = "This record can not be edit because it was approvied by HR.";
                        }
                    }
                    else
                    {
                        ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                    }
                }
            }
            else if (level == 2)
            {
                DataTable thct = new DataTable();
                ie = int.Parse(e.EditingKeyValue.ToString());
                thct = s.checkHR(ie);
                DataView th = thct.DefaultView;
                string active1 = th[0].Row["ApprovingStatus_L3"].ToString();
                string active2 = th[0].Row["HRCheckingStatus"].ToString();
                act2 = th[0].Row["ApprovingStatus_L2"].ToString();
                if ((active1 == "False" || active1 == "True") || (active2 == "False" || active2 == "True"))
                {
                    e.Cancel = true;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                        }
                        else
                        {
                            ASPxGridView1.SettingsText.Title = "This record can not be edit because it was approvied by HR.";
                        }
                    }
                    else
                    {
                        ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                    }
                }
            }
            else if (level == 3)
            {
                DataTable thct = new DataTable();
                ie = int.Parse(e.EditingKeyValue.ToString());
                thct = s.checkHR(ie);
                DataView th = thct.DefaultView;
                string active2 = th[0].Row["HRCheckingStatus"].ToString();
                act3 = th[0].Row["ApprovingStatus_L3"].ToString();
                if (active2 == "False" || active2 == "True")
                {
                    e.Cancel = true;
                    if (Session["lang"] != null)
                    {
                        if (Session["lang"].ToString().Equals("vi"))
                        {
                            ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                        }
                        else
                        {
                            ASPxGridView1.SettingsText.Title = "This record can not be edit because it was approvied by HR.";
                        }
                    }
                    else
                    {
                        ASPxGridView1.SettingsText.Title = "Không thể chỉnh sửa do đã được duyệt từ cấp cao hơn hoặc từ HR.";
                    }
                }
            }
        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();

        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ApprovingStatus_L1")
            {
                string p = e.GetFieldValue("ManagerID_L1").ToString();
                string value1 = e.Value.ToString();
                if (value1.Length > 0)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không duyệt";
                        }
                    }
                }
                else
                {
                    if (p.Length > 0)
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ duyệt";
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
            }

            if (e.Column.FieldName == "ApprovingStatus_L2")
            {
                string p = e.GetFieldValue("ManagerID_L2").ToString();
                string p2 = e.GetFieldValue("ManagerID_L1").ToString();
                int cn = int.Parse(e.GetFieldValue("CheckNum").ToString());
                string value2 = e.Value.ToString();
                if (value2.Length > 0)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không duyệt";
                        }
                    }
                }
                else
                {
                    if (p2.Length > 0)
                    {
                        if (cn > 1)
                        {
                            if (e.GetFieldValue("ApprovingStatus_L1").Equals(false))
                            { e.DisplayText = ""; }
                            else
                            {
                                if (Session["lang"] != null)
                                {
                                    if (Session["lang"].ToString().Equals("vi"))
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                    else
                                    {
                                        e.DisplayText = "Waiting";
                                    }
                                }
                                else
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ duyệt";
                        }
                    }
                }
            }

            if (e.Column.FieldName == "ApprovingStatus_L3")
            {
                string p2 = e.GetFieldValue("ManagerID_L1").ToString();
                string p3 = e.GetFieldValue("ManagerID_L2").ToString();
                int cn = int.Parse(e.GetFieldValue("CheckNum").ToString());
                string value3 = e.Value.ToString();
                if (value3.Length > 0)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không duyệt";
                        }
                    }
                }
                else
                {
                    if (p2.Length > 0)
                    {
                        if (cn == 3)
                        {
                            if (e.GetFieldValue("ApprovingStatus_L2").Equals(false))
                            { e.DisplayText = ""; }
                            else
                            {
                                if (Session["lang"] != null)
                                {
                                    if (Session["lang"].ToString().Equals("vi"))
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                    else
                                    {
                                        e.DisplayText = "Waiting";
                                    }
                                }
                                else
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        if (p3.Length > 0)
                        {
                            if (cn > 1)
                            {
                                if (e.GetFieldValue("ApprovingStatus_L2").Equals(false))
                                { e.DisplayText = ""; }
                                else
                                {
                                    if (Session["lang"] != null)
                                    {
                                        if (Session["lang"].ToString().Equals("vi"))
                                        {
                                            e.DisplayText = "Chờ duyệt";
                                        }
                                        else
                                        {
                                            e.DisplayText = "Waiting";
                                        }
                                    }
                                    else
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                }
                            }
                            else
                            {
                                e.DisplayText = "";
                            }
                        }
                        else
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                                else
                                {
                                    e.DisplayText = "Waiting";
                                }
                            }
                            else
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                        }
                    }
                }
            }
            if (e.Column.FieldName == "HRCheckingStatus")
            {
                string valuehr = e.Value.ToString();
                if (valuehr.Length > 0)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Đồng bộ";
                            }
                            else
                            {
                                e.DisplayText = "Syncied";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Đồng bộ";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không Đồng bộ";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không Đồng bộ";
                        }
                    }
                }
                else
                {
                    if (e.GetFieldValue("HRview").ToString() == "a")
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ Đồng bộ";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ Đồng bộ";
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
            }
        }

        protected void ASPxGridView2_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

            if (e.Column.FieldName == "ApprovingStatus_L1")
            {
                int ii = int.Parse(e.GetFieldValue("id").ToString());
                DataTable tt = new DataTable();
                tt = s.checkHR(ii);
                DataView th = tt.DefaultView;
                string p = th[0].Row["ManagerID_L1"].ToString();
                string aspp = th[0].Row["ApprovingStatus_L1"].ToString();
                if (string.IsNullOrWhiteSpace(aspp) == false)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không Duyệt";
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(p) == false)
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ duyệt";
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
            }

            if (e.Column.FieldName == "ApprovingStatus_L2")
            {
                int ii = int.Parse(e.GetFieldValue("id").ToString());
                DataTable tt = new DataTable();
                tt = s.checkHR(ii);
                DataView th = tt.DefaultView;
                string p = th[0].Row["ManagerID_L2"].ToString();
                string p2 = th[0].Row["ManagerID_L1"].ToString();
                string value2 = th[0].Row["ApprovingStatus_L2"].ToString();
                int cn = int.Parse(th[0].Row["CheckNum"].ToString());
                if (string.IsNullOrWhiteSpace(value2) == false)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không Duyệt";
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(p2) == false)
                    {
                        if (cn > 1)
                        {
                            if (e.GetFieldValue("ApprovingStatus_L1").Equals(false))
                            { e.DisplayText = ""; }
                            else
                            {
                                if (Session["lang"] != null)
                                {
                                    if (Session["lang"].ToString().Equals("vi"))
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                    else
                                    {
                                        e.DisplayText = "Waiting";
                                    }
                                }
                                else
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ duyệt";
                        }
                    }
                }
            }

            if (e.Column.FieldName == "ApprovingStatus_L3")
            {
                int ii = int.Parse(e.GetFieldValue("id").ToString());
                DataTable tt = new DataTable();
                tt = s.checkHR(ii);
                DataView th = tt.DefaultView;
                string p2 = th[0].Row["ManagerID_L1"].ToString();
                string p3 = th[0].Row["ManagerID_L2"].ToString();
                string value3 = th[0].Row["ApprovingStatus_L3"].ToString();
                int cn = int.Parse(th[0].Row["CheckNum"].ToString());
                if (string.IsNullOrWhiteSpace(value3) == false)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Approved";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Duyệt";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không Duyệt";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không Duyệt";
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(p2) == false)
                    {
                        if (cn == 3)
                        {
                            if (e.GetFieldValue("ApprovingStatus_L2").Equals(false))
                            { e.DisplayText = ""; }
                            else
                            {
                                if (Session["lang"] != null)
                                {
                                    if (Session["lang"].ToString().Equals("vi"))
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                    else
                                    {
                                        e.DisplayText = "Waiting";
                                    }
                                }
                                else
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                            }
                        }
                        else
                        {
                            e.DisplayText = "";
                        }
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(p3) == false)
                        {
                            if (cn > 1)
                            {
                                if (e.GetFieldValue("ApprovingStatus_L2").Equals(false))
                                { e.DisplayText = ""; }
                                else
                                {
                                    if (Session["lang"] != null)
                                    {
                                        if (Session["lang"].ToString().Equals("vi"))
                                        {
                                            e.DisplayText = "Chờ duyệt";
                                        }
                                        else
                                        {
                                            e.DisplayText = "Waiting";
                                        }
                                    }
                                    else
                                    {
                                        e.DisplayText = "Chờ duyệt";
                                    }
                                }
                            }
                            else
                            {
                                e.DisplayText = "";
                            }
                        }
                        else
                        {
                            if (Session["lang"] != null)
                            {
                                if (Session["lang"].ToString().Equals("vi"))
                                {
                                    e.DisplayText = "Chờ duyệt";
                                }
                                else
                                {
                                    e.DisplayText = "Waiting";
                                }
                            }
                            else
                            {
                                e.DisplayText = "Chờ duyệt";
                            }
                        }
                    }
                }
            }

            if (e.Column.FieldName == "HRCheckingStatus")
            {
                int ii = int.Parse(e.GetFieldValue("id").ToString());
                DataTable tt = new DataTable();
                tt = s.checkHR(ii);
                DataView th = tt.DefaultView;
                string valuehr = th[0].Row["HRCheckingStatus"].ToString();
                string aspp1 = th[0].Row["HRview"].ToString();
                if (string.IsNullOrWhiteSpace(valuehr) == false)
                {
                    if (e.Value.Equals(true))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Đồng Bộ";
                            }
                            else
                            {
                                e.DisplayText = "Syncied";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Đồng Bộ";
                        }
                    }
                    else if (e.Value.Equals(false))
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Không Đồng Bộ";
                            }
                            else
                            {
                                e.DisplayText = "Cancel";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Không Đồng Bộ";
                        }
                    }
                }
                else
                {
                    if (aspp1 == "a")
                    {
                        if (Session["lang"] != null)
                        {
                            if (Session["lang"].ToString().Equals("vi"))
                            {
                                e.DisplayText = "Chờ Đồng Bộ";
                            }
                            else
                            {
                                e.DisplayText = "Waiting";
                            }
                        }
                        else
                        {
                            e.DisplayText = "Chờ Đồng Bộ";
                        }
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
            }
        }

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            string asp1 = e.GetValue("ApprovingStatus_L1").ToString();
            string asp2 = e.GetValue("ApprovingStatus_L2").ToString();
            string asp3 = e.GetValue("ApprovingStatus_L3").ToString();
            string m1 = e.GetValue("ManagerID_L1").ToString();
            string m2 = e.GetValue("ManagerID_L2").ToString();
            int cn = int.Parse(e.GetValue("CheckNum").ToString());
            DateTime dt1 = DateTime.Now.Date;
            DateTime dt2 = Convert.ToDateTime(e.GetValue("ToDate").ToString()).Date;
            if (dt1 > dt2)
            {
                if (!m1.Equals(""))
                {
                    if (cn == 1)
                    {
                        if (asp1 == "")
                        {
                            s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                        }
                    }
                    else if (cn == 2)
                    {
                        if (asp1 == "" || asp2 == "")
                        {
                            s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                        }
                    }
                    else if (cn == 3)
                    {
                        if (asp1 == "" || asp2 == "" || asp3 == "")
                        {
                            s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                        }
                    }
                }
                else
                {
                    if (!m1.Equals(""))
                    {
                        if (cn == 1)
                        {
                            if (asp2 == "")
                            {
                                s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                            }
                        }
                        else
                        {
                            if (asp2 == "" || asp3 == "")
                            {
                                s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                            }
                        }
                    }
                    else
                    {
                        if (asp3 == "")
                        {
                            s.UpdateHRC(e.VisibleIndex, "Quá hạn đăng ký nhưng chưa được Phê duyệt", "d");
                        }
                    }
                }
            }

            if (level == 1)
            {
                string warning = e.GetValue("Warning").ToString();
                if (String.Compare(warning, "True", true) == 0)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }

                if (e.GetValue("HRCheckingStatus").Equals(false) || e.GetValue("ApprovingStatus_L1").Equals(false) || e.GetValue("ApprovingStatus_L2").Equals(false) || e.GetValue("ApprovingStatus_L3").Equals(false))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
            else if (level == 2)
            {
                string warning = e.GetValue("Warning").ToString();
                if (String.Compare(warning, "True", true) == 0)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }

                if (e.GetValue("HRCheckingStatus").Equals(false) || e.GetValue("ApprovingStatus_L2").Equals(false) || e.GetValue("ApprovingStatus_L3").Equals(false))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
            else if (level == 3)
            {
                string warning = e.GetValue("Warning").ToString();
                if (String.Compare(warning, "True", true) == 0)
                {
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }

                if (e.GetValue("HRCheckingStatus").Equals(false) || e.GetValue("ApprovingStatus_L3").Equals(false))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
            }
            if (e.GetValue("HRCheckingStatus").Equals(true))
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
        }
    }
}