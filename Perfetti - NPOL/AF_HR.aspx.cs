using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.Web;
using conn = System.Web.Configuration;
using System.Globalization;
using System.Threading;
using cnn = System.Web.Configuration.WebConfigurationManager;
using System.Data.SqlTypes;
//using System.Threading;
//using System.Globalization;


namespace NPOL
{
    public partial class AF_HR : System.Web.UI.Page
    {
        static string EmpID = "";
        static string role = "";
        ThProvider s = new ThProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
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
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = Session["EmployeeID"].ToString();
            }
            

            if (Session["EmployeeID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { EmpID = Session["EmployeeID"].ToString(); }
            role = Session["Role"].ToString();
            if (role == "HR")
            {
              
            }
            else if (role == "M1")
            {
                Response.Redirect("AF_Approval.aspx");
            }
            else if (role == "M2")
            {
                Response.Redirect("AF_Approval.aspx");
            }
            else if (role == "M3")
            {
                Response.Redirect("AF_Approval.aspx");
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
            DataTable thct = new DataTable();
            string lang;
            if (Session["lang"] == null)
            {
                lang = "vi";
            }
                else
            {
                lang = Session["lang"].ToString();
            }
            thct = s.getdataHR(Session["EmployeeID"].ToString(),lang);
            ASPxGridView1.DataSource = thct;
            ASPxGridView1.DataBind();
        }
        public String HRS()
        { return "HRCheckingStatus"; }
        public String HRR()
        { return "HRCheckingReason"; }
        public String HRD()
        { return "HRCheckingDate"; }
        public String HRSL()
        {
            string th = "";
            if (acthr == "True" || acthr == "true")
            {
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        th = "Đồng bộ";
                    }
                    else
                    {
                        th = "Syncied";
                    }
                }
                else
                {
                    th = "Đồng bộ";
                }
            }
            else if (acthr == "False" || acthr == "false")
            {
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        th = "Không Đồng bộ";
                    }
                    else
                    {
                        th = "Cancel";
                    }
                }
                else
                {
                    th = "Không Đồng bộ";
                }
            }
            else
            {
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        th = "Chờ Đồng bộ";
                    }
                    else
                    {
                        th = "Waiting";
                    }
                }
                else
                {
                    th = "Chờ Đồng bộ";
                }
            }
            return th; }
        protected void ASPxGridView1_DataBound(object sender, EventArgs e)
        {
            this.ASPxGridView1.Columns[1].Visible = false;
        }

        protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["id"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        bool InsertRecord(string empid, DateTime regdate, DateTime startdate, DateTime todate, string leaveid, string pertimeid, DateTime approveddate, float TotalDays, System.Data.SqlTypes.SqlDateTime fromtime, System.Data.SqlTypes.SqlDateTime totime)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(cnn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            try
            {                
                string sql = "insert into tblEmpDayOff (EmployeeID, FromDate, ToDate, RegistedDate, ApprovedDate, PerTimeID, LeaveID, Days, FromTime, ToTime) ";
                sql += "Values(@EmployeeID, @FromDate, @ToDate, @RegistedDate, @ApprovedDate, @PerTimeID, @LeaveID, @Days, @FromTime, @ToTime);";
                provider.CommandText = sql ;
                provider.ParameterCollection = new string[] { "@EmployeeID", "@FromDate", "@ToDate", "@RegistedDate", "@ApprovedDate", "@PerTimeID", "@LeaveID", "@Days", "@FromTime", "@ToTime" };
                provider.ValueCollection = new object[] {empid, startdate, todate, regdate, approveddate, pertimeid, leaveid, TotalDays, fromtime, totime };
                provider.ExecuteNonQuery();                
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }


        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "id" });
            DataTable thct = new DataTable();
            
            khSqlServerProvider provider = new khSqlServerProvider(cnn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            string EmpID = null;
            string PerTimeID = null;
            string LeaveID = null;
            float TotalDays = 0;
            DateTime RegDate;
            DateTime StarDate;
            DateTime ToDate;
            DateTime ApprovedDate;            
            DataTable dt;
            System.Data.SqlTypes.SqlDateTime fromtime;
            System.Data.SqlTypes.SqlDateTime totime;

            foreach (var item in fieldValues)
            {
                int i = int.Parse(item.ToString());
                thct = s.checkHR(i);
                DataView th = thct.DefaultView;
                
                string active = th[0].Row["HRCheckingStatus"].ToString();
                string hrv = th[0].Row["HRview"].ToString();
                if (th[0].Row["HRCheckingStatus"].ToString() == "" && hrv == "a")
                {
                    s.UpdateHRA(i, "","c");
                    
                    provider.CommandText = "Select * from tblWebData Where ID = @ID";
                    provider.ParameterCollection = new string[] {"@ID" };
                    provider.ValueCollection = new object[] { item };
                    dt = provider.GetDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        EmpID = dt.Rows[0]["EmployeeID"].ToString();
                        PerTimeID = dt.Rows[0]["PerTimeID"].ToString();
                        LeaveID = dt.Rows[0]["LeaveID"].ToString(); 
                        RegDate = (DateTime)dt.Rows[0]["RegDate"];
                        StarDate = (DateTime)dt.Rows[0]["StartDate"];
                        ToDate = (DateTime)dt.Rows[0]["ToDate"];
                        ApprovedDate = (DateTime)dt.Rows[0]["HRCheckingDate"];
                        double tempTotalDays = (double) dt.Rows[0]["TotalDays"];
                        TotalDays = (float)tempTotalDays;
                        try
                        {
                            fromtime = (DateTime)dt.Rows[0]["FromTime"];
                            totime = (DateTime)dt.Rows[0]["ToTime"];
                        }
                        catch (Exception ex)
                        {
                            fromtime = SqlDateTime.Null;
                            totime = SqlDateTime.Null;
                        }
                        InsertRecord(EmpID, RegDate, StarDate, ToDate, LeaveID, PerTimeID, ApprovedDate, TotalDays, fromtime, totime);
                    }
                }
                else { }
            }
            provider.CloseConnection();
            
            loaddata();
            ASPxGridView1.DataBind();
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            List<object> fieldValues = ASPxGridView1.GetSelectedFieldValues(new string[] { "id" });
            DataTable thct = new DataTable();

            foreach (var item in fieldValues)
            {
                int i = int.Parse(item.ToString());
                thct = s.checkHR(i);
                DataView th = thct.DefaultView;
                string Emp = th[0].Row["EmployeeID"].ToString();
                string active = th[0].Row["HRCheckingStatus"].ToString();
                string hrv = th[0].Row["HRview"].ToString();
                if (th[0].Row["HRCheckingStatus"].ToString() == "" && hrv == "a")
                {
                    s.UpdateHRC(i, "","d");
                }
                else { }
            }
            loaddata();
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            int id = int.Parse(e.Keys[ASPxGridView1.KeyFieldName].ToString());
            ASPxComboBox combox = (ASPxComboBox)ASPxGridView1.FindEditFormTemplateControl("ASPxComboBox1");
            khSqlServerProvider provider = new khSqlServerProvider(cnn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
            string EmpID = null;
            string PerTimeID = null;
            string LeaveID = null;
            float TotalDays = 0;
            DateTime RegDate;
            DateTime StarDate;
            DateTime ToDate;
            DateTime ApprovedDate;
            DataTable dt;
            System.Data.SqlTypes.SqlDateTime fromtime;
            System.Data.SqlTypes.SqlDateTime totime;
            try
            {
                bool giatri1 = Boolean.Parse(combox.Value.ToString());
                ASPxTextBox text = (ASPxTextBox)ASPxGridView1.FindEditFormTemplateControl("ASPxTextBox1");
                string txt1 = text.Text;
                DataTable thct = new DataTable();
                thct = s.checkHR(id);
                DataView th = thct.DefaultView;
                
                string active = th[0].Row["HRCheckingStatus"].ToString();
                string hrv = th[0].Row["HRview"].ToString();
                if (giatri1 == true)
                {
                    s.UpdateHRA(id, txt1,"c");
                    //s.insert(Emp, SD, PT, TD,total, LID, RD);
                    provider.CommandText = "Select * from tblWebData Where ID = @ID";
                    provider.ParameterCollection = new string[] {"@ID" };
                    provider.ValueCollection = new object[] { id };
                    dt = provider.GetDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        EmpID = dt.Rows[0]["EmployeeID"].ToString();
                        PerTimeID = dt.Rows[0]["PerTimeID"].ToString();
                        LeaveID = dt.Rows[0]["LeaveID"].ToString();

                        RegDate = (DateTime)dt.Rows[0]["RegDate"];

                        StarDate = (DateTime)dt.Rows[0]["StartDate"];

                        ToDate = (DateTime)dt.Rows[0]["ToDate"];

                        ApprovedDate = (DateTime)dt.Rows[0]["HRCheckingDate"];

                        double tempTotalDays = (double)dt.Rows[0]["TotalDays"];
                        TotalDays = (float)tempTotalDays;
                        try
                        {
                            fromtime = (DateTime)dt.Rows[0]["FromTime"];
                            totime = (DateTime)dt.Rows[0]["ToTime"];
                        }
                        catch (Exception ex)
                        {
                            fromtime = SqlDateTime.Null;
                            totime = SqlDateTime.Null;
                        }
                        InsertRecord(EmpID, RegDate, StarDate, ToDate, LeaveID, PerTimeID, ApprovedDate, TotalDays, fromtime, totime);
                    }
                }
                else { s.UpdateHRC(id, txt1, "d"); }
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
        static string acthr;
        protected void ASPxGridView1_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            DataTable thct = new DataTable();
            int i = int.Parse(e.EditingKeyValue.ToString());
            thct = s.checkHR(i);
            DataView th = thct.DefaultView;
            acthr = th[0].Row["HRCheckingStatus"].ToString();
            string active = th[0].Row["HRCheckingStatus"].ToString();
            string hrv = th[0].Row["HRview"].ToString();
            if (active == "True" || active == "False" || hrv == "b" || hrv == "" || hrv == "d")
            {
                e.Cancel = true;
                if (Session["lang"] != null)
                {
                    if (Session["lang"].ToString().Equals("vi"))
                    {
                        if (hrv == "b" || hrv == "")
                        { ASPxGridView1.SettingsText.Title = "Không thể đồng bộ do lượt dang ký dang trong quá trình phê duyệt."; }
                        else if (hrv == "d")
                        { ASPxGridView1.SettingsText.Title = "Không thể đồng bộ do lượt dang ký không được duyệt."; }
                        else
                        { ASPxGridView1.SettingsText.Title = "Không th? d?ng b? do dã được duyệt."; }
                        
                    }
                    else
                    {
                        if (hrv == "b" || hrv == "")
                        { ASPxGridView1.SettingsText.Title = "This record can not be edit because it be in approving progess."; }
                        else if (hrv == "d")
                        { ASPxGridView1.SettingsText.Title = "This record can not be edit because it was cancel."; }
                        else
                        { ASPxGridView1.SettingsText.Title = "This record can not be edit because it was approvied."; }
                    }
                }
                else
                {
                    if (hrv == "b" || hrv == "")
                    { ASPxGridView1.SettingsText.Title = "Không thể đồng bộ do lượt đăng ký đang trong quá trình phê duyệt."; }
                    else if (hrv == "d")
                    { ASPxGridView1.SettingsText.Title = "Không thể đồng bộ do lượt đăng ký không được duyệt."; }
                    else
                    { ASPxGridView1.SettingsText.Title = "Không thể đồng bộ do đã được duyệt."; }
                }
            }
        }

        protected void ASPxGridView1_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            bool isOddCol = e.Column.VisibleIndex == 0;
            if (isOddCol)
            {
                string active = ASPxGridView1.GetRowValues(e.VisibleIndex, "HRCheckingStatus").ToString();
                string hrv = ASPxGridView1.GetRowValues(e.VisibleIndex, "HRview").ToString();
                if (active == "True" || active == "False" || hrv == "b" || hrv == "" || hrv == "d")
                    if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox)
                        e.Enabled = false;
            }
        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
                if (e.Column.FieldName == "ApprovingStatus_L1")
                {
                    string p = e.GetFieldValue("ManagerID_L1").ToString();
                    string value1 = e.Value.ToString();
                    if (string.IsNullOrWhiteSpace(value1) == false)
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
                    string p = e.GetFieldValue("ManagerID_L2").ToString();
                    string p2 = e.GetFieldValue("ManagerID_L1").ToString();
                    int cn = int.Parse(e.GetFieldValue("CheckNum").ToString());
                    string value2 = e.Value.ToString();
                    if (string.IsNullOrWhiteSpace(value2) == false)
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
                    string p2 = e.GetFieldValue("ManagerID_L1").ToString();
                    string p3 = e.GetFieldValue("ManagerID_L2").ToString();
                    int cn = int.Parse(e.GetFieldValue("CheckNum").ToString());
                    string value3 = e.Value.ToString();
                    if (string.IsNullOrWhiteSpace(value3) == false)
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
                                if(cn > 1)
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
                    if (string.IsNullOrWhiteSpace(valuehr) == false)
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

            string th = e.GetValue("HRCheckingStatus").ToString();
            if ((e.GetValue("HRview").ToString().Equals("") || e.GetValue("HRview").ToString().Equals("b")) && e.GetValue("HRCheckingStatus").ToString().Equals(""))
            {
                e.Row.BackColor = System.Drawing.Color.Green;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            else if (e.GetValue("HRCheckingStatus").Equals(false) || e.GetValue("HRview").ToString().Equals("d"))
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            else if (e.GetValue("HRCheckingStatus").Equals(true))
            {
                e.Row.BackColor = System.Drawing.Color.Yellow;
            }
            
        }

        /*protected void ASPxGridView1_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            DataTable thct = new DataTable();
            thct = s.getdataHR();
            DataView th = thct.DefaultView;
            for (int i = 0; i < th.Count; i++)
            {
                if (e.VisibleIndex == 0) return;
                {
                    string active = ASPxGridView1.GetRowValues(e.VisibleIndex, "HRCheckingStatus").ToString();
                    if (e.ButtonType == ColumnCommandButtonType.SelectCheckbox && active == "")
                    { e.Enabled = true; }
                    else { e.Enabled = false; }
                }
                
            }
        }
        */
        
    }
}