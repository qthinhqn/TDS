using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace NPOL
{
    public partial class AF_ManagerLevel : System.Web.UI.Page
    {
        static bool Allow_ManagerL1_Updated = false;
        static bool Allow_ManagerL2_Updated = false;
        static bool Allow_ManagerL3_Updated = false;

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
                //lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                //lbUserName.Text = Session["EmployeeID"].ToString();
            }

            //this.ASPxPageControl1.TabPages[2].Visible = false;
        }

        protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            ((ASPxGridView)sender).DataBind();
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            List<object> Keys = ASPxGridView1.GetSelectedFieldValues(new string[] { "EmployeeID", "SectionID", "LineID" });
            // List<object> SectionIDs = ASPxGridView1.gets
            object id = null;
            object sectionid = null;
            object lineid = null;

            foreach (object[] item in Keys)
            {
                id = item[0];
                sectionid = item[1];
                lineid = item[2];
                InsertRecord(id, DateTime.Today, sectionid, lineid);
            }
            ASPxGridView2.DataBind();
            ASPxGridView1.DataBind();
        }

        private bool InsertRecord(object EmpID, DateTime DateChange, object SectionID, object LineID)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Insert into tblEmpManagerLevel (EmployeeID, DateChange, SectionID, LineID) values(@EmployeeID, @DateChange, @SectionID, @LineID);";
                provider.ParameterCollection = new string[] { "@EmployeeID", "@DateChange", "@SectionID", "@LineID" };
                provider.ValueCollection = new object[] { EmpID, DateChange, SectionID, LineID };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                {
                    returnValue = true;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        protected void ASPxGridView2_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ManagerID_L1")
            {
                if (e.GetFieldValue("ManagerID_L1") != null)
                    e.DisplayText = getEmployeeName(e.GetFieldValue("ManagerID_L1").ToString());
            }
            if (e.Column.FieldName == "ManagerID_L2")
            {
                if (e.GetFieldValue("ManagerID_L2") != null)
                    e.DisplayText = getEmployeeName(e.GetFieldValue("ManagerID_L2").ToString());
            }
            if (e.Column.FieldName == "ManagerID_L3")
            {
                if (e.GetFieldValue("ManagerID_L3") != null)
                    e.DisplayText = getEmployeeName(e.GetFieldValue("ManagerID_L3").ToString());
            }
        }

        protected void ASPxGridView2_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            if (e.Exception == null)
            {
                ASPxGridView2.JSProperties["cpIsDeleted"] = true;
            }
        }

        protected void ASPxGridView2_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string L1 = "", L2 = "", L3 = "";
            string EmployeeID = e.Keys[0].ToString();
            try
            {

                GridViewDataColumn columnL1 = (GridViewDataColumn)((ASPxGridView)sender).Columns["ManagerID_L1"];
                ASPxComboBox cbL1 = (ASPxComboBox)ASPxGridView2.FindEditRowCellTemplateControl(columnL1, "ASPxComboBox1");
                L1 = cbL1.Value.ToString();

                GridViewDataColumn columnL2 = (GridViewDataColumn)((ASPxGridView)sender).Columns["ManagerID_L2"];
                ASPxComboBox cbL2 = (ASPxComboBox)ASPxGridView2.FindEditRowCellTemplateControl(columnL2, "ASPxComboBox1");
                L2 = cbL2.Value.ToString();

                GridViewDataColumn columnL3 = (GridViewDataColumn)((ASPxGridView)sender).Columns["ManagerID_L3"];
                ASPxComboBox cbL3 = (ASPxComboBox)ASPxGridView2.FindEditRowCellTemplateControl(columnL3, "ASPxComboBox1");
                L3 = cbL3.Value.ToString();

                //Validate before update

                if ((checkEmployeeID(L1) == false && !String.IsNullOrWhiteSpace(L1)) || (checkEmployeeID(L2) == false && !String.IsNullOrWhiteSpace(L2)) || (checkEmployeeID(L3) == false && !String.IsNullOrWhiteSpace(L3)))
                {
                    e.Cancel = true;

                    if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                    {
                        this.ASPxGridView2.SettingsText.Title = "Bạn đã nhập vào cấp phê duyệt không tồn tại";
                    }
                    else
                    {
                        this.ASPxGridView2.SettingsText.Title = "Approval manager you entered can not be found";
                    }
                }
                else
                {
                    //Xét trường hợp 3 mã quản lý hợp lệ
                    if (checkEmployeeID(L1) && checkEmployeeID(L2) && checkEmployeeID(L3))
                    {
                        if (String.Compare(L1, L2, true) == 0 || String.Compare(L1, L3, true) == 0 || String.Compare(L2, L3, true) == 0)
                        {
                            e.Cancel = true;

                            if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                            {
                                this.ASPxGridView2.SettingsText.Title = "Cấp phê duyệt bị trùng";
                            }
                            else
                            {
                                this.ASPxGridView2.SettingsText.Title = "Approval manager you entered was dupplicated";
                            }
                        }
                    }
                    else
                    {
                        //Xét trường hợp 3 mã quản lý là khoảng trắng
                        if (String.IsNullOrWhiteSpace(L1) && String.IsNullOrWhiteSpace(L2) && String.IsNullOrWhiteSpace(L3))
                        {
                            e.Cancel = true;

                            if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                            {
                                this.ASPxGridView2.SettingsText.Title = "3 cấp phê duyệt không được bỏ trống";
                            }
                            else
                            {
                                this.ASPxGridView2.SettingsText.Title = "You must enter asleast one Manager Level";
                            }
                        }
                        //else
                        //{
                        //    //Xét trường hợp L2 bị khuyết
                        //    if (String.IsNullOrWhiteSpace(L2) == true && checkEmployeeID(L1) && checkEmployeeID(L3))
                        //    {
                        //        e.Cancel = true;

                        //        if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                        //        {
                        //            this.ASPxGridView2.SettingsText.Title = "Vi phạm trình tự phê duyệt";
                        //        }
                        //        else
                        //        {
                        //            this.ASPxGridView2.SettingsText.Title = "The order of Manager Level list was violated";
                        //        }
                        //    }
                        //}
                    }
                }

            }
            catch
            {
                e.Cancel = true;

                if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                {
                    this.ASPxGridView2.SettingsText.Title = "Giá trị nhập bị rỗng";
                }
                else
                {
                    this.ASPxGridView2.SettingsText.Title = "The value you entered is empty";
                }
            }


            //Cập nhật lại cấp phê duyệt mới cho các lượt đang xử lý 
            if (Allow_ManagerL1_Updated)
            {
                if (checkEmployeeID(L1) == false)
                {
                    e.Cancel = true;

                    if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                    {
                        this.ASPxGridView2.SettingsText.Title = "Cấp duyệt 1 đang hiệu lực phê duyệt nên không thể cập nhật giá trị không hợp lệ hoặc rỗng";
                    }
                    else
                    {
                        this.ASPxGridView2.SettingsText.Title = "The manager level 1 is on approval processing so can not be updated with empty or invalid value";
                    }
                }
                else
                {
                    if (updateManagerLevelID(EmployeeID, L1, 1))
                    {

                    }
                    else
                    {
                        e.Cancel = true;

                        if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                        {
                            this.ASPxGridView2.SettingsText.Title = "Có lỗi cập nhật cấp phê duyệt 1";
                        }
                        else
                        {
                            this.ASPxGridView2.SettingsText.Title = "There is something with updating to Manager level 1";
                        }
                    }
                }
            }

            if (Allow_ManagerL2_Updated)
            {
                if (checkEmployeeID(L2) == false)
                {
                    e.Cancel = true;
                    if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                    {
                        this.ASPxGridView2.SettingsText.Title = "Cấp duyệt 2 đang hiệu lực phê duyệt nên không thể cập nhật giá trị không hợp lệ hoặc rỗng";
                    }
                    else
                    {
                        this.ASPxGridView2.SettingsText.Title = "The manager level 2 is on approval processing so can not be updated with empty or invalid value";
                    }
                }
                else
                {
                    if (updateManagerLevelID(EmployeeID, L2, 2))
                    {

                    }
                    else
                    {
                        e.Cancel = true;
                        if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                        {
                            this.ASPxGridView2.SettingsText.Title = "Có lỗi cập nhật cấp phê duyệt 2";
                        }
                        else
                        {
                            this.ASPxGridView2.SettingsText.Title = "There is something with updating to Manager level 2";
                        }
                    }
                }
            }

            if (Allow_ManagerL3_Updated)
            {
                if (checkEmployeeID(L3) == false)
                {
                    e.Cancel = true;
                    if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                    {
                        this.ASPxGridView2.SettingsText.Title = "Cấp duyệt 3 đang hiệu lực phê duyệt nên không thể cập nhật giá trị không hợp lệ hoặc rỗng";
                    }
                    else
                    {
                        this.ASPxGridView2.SettingsText.Title = "The manager level 3 is on approval processing so can not be updated with empty or invalid value";
                    }
                }
                else
                {
                    if (updateManagerLevelID(EmployeeID, L3, 3))
                    {

                    }
                    else
                    {
                        e.Cancel = true;
                        if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                        {
                            this.ASPxGridView2.SettingsText.Title = "Có lỗi cập nhật cấp phê duyệt 3";
                        }
                        else
                        {
                            this.ASPxGridView2.SettingsText.Title = "There is something with updating to Manager level 3";
                        }
                    }
                }
            }

        }


        private bool updateManagerLevelID(string employeeid, string managerid, int level)
        {
            bool returnValue = false;
            string sql = "";
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                switch (level)
                {
                    case 1:
                        sql += "Update tblWebdata set MailToL1 = 1, ManagerID_L1 = @ManagerID_L1 where EmployeeID = @EmployeeID and FinalStatus = 'w' and (MailToL1 = 1 or MailToL1 = 2)";
                        provider.CommandText = sql;
                        provider.ParameterCollection = new string[] { "@ManagerID_L1", "@EmployeeID" };
                        break;
                    case 2:
                        sql += "Update tblWebdata set MailToL2 = 1, ManagerID_L2 = @ManagerID_L2 where EmployeeID = @EmployeeID and FinalStatus = 'w' and (MailToL2 = 1 or MailToL2 = 2)";
                        provider.CommandText = sql;
                        provider.ParameterCollection = new string[] { "@ManagerID_L2", "@EmployeeID" };
                        break;
                    case 3:
                        sql += "Update tblWebdata set MailToL3 = 1, ManagerID_L3 = @ManagerID_L3 where EmployeeID = @EmployeeID and FinalStatus = 'w' and (MailToL3 = 1 or MailToL3 = 2)";
                        provider.CommandText = sql;
                        provider.ParameterCollection = new string[] { "@ManagerID_L3", "@EmployeeID" };
                        break;
                }
                provider.ValueCollection = new object[] { managerid, employeeid };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                {
                    returnValue = true;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }


        private bool IsEmployeeOnProcessing(string employeeid, int level)
        {
            bool returnValue = false;
            string sql = "";
            System.Data.DataTable dt;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                switch (level)
                {
                    case 1:
                        sql += "select * from tblWebdata where FinalStatus = 'w' and (MailToL1 = 1 or MailToL1 = 2) and EmployeeID = @EmployeeID";
                        break;
                    case 2:
                        sql += "select * from tblWebdata where FinalStatus = 'w' and (MailToL2 = 1 or MailToL2 = 2) and EmployeeID = @EmployeeID";
                        break;
                    case 3:
                        sql += "select * from tblWebdata where FinalStatus = 'w' and (MailToL3 = 1 or MailToL3 = 2) and EmployeeID = @EmployeeID";
                        break;
                }
                provider.CommandText = sql;
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { employeeid };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    returnValue = true;
                }

            }
            catch { returnValue = false; }
            provider.CloseConnection();
            return returnValue;
        }

        private bool checkEmployeeID(string input)
        {
            bool returnValue = true;
            System.Data.DataTable dt;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { input };
                dt = provider.GetDataTable();
                if (dt.Rows.Count == 0)
                {
                    returnValue = false;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        private string getEmployeeName(string EmployeeID)
        {
            string returnValue = null;
            System.Data.DataTable dt;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                provider.CommandText = "Select EmployeeName from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                returnValue = dt.Rows[0]["EmployeeName"].ToString();
            }
            catch
            {
                returnValue = null;
            }
            provider.CloseConnection();
            return returnValue;
        }

        protected void ASPxGridView2_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            Allow_ManagerL1_Updated = false;
            Allow_ManagerL2_Updated = false;
            Allow_ManagerL3_Updated = false;
            string EmployeeID = e.EditingKeyValue.ToString();
            string L1 = getCollectionsManagerID(EmployeeID)[0].ToString();
            string L2 = getCollectionsManagerID(EmployeeID)[1].ToString();
            string L3 = getCollectionsManagerID(EmployeeID)[2].ToString();
            this.ASPxGridView2.SettingsText.Title = "";

            //Xét trường hợp cấp phê duyệt 1
            if (String.IsNullOrWhiteSpace(L1) == false && IsEmployeeOnProcessing(EmployeeID, 1) == true)
            {
                Allow_ManagerL1_Updated = true;
            }


            //Xét trường hợp cấp phê duyệt 2
            if (String.IsNullOrWhiteSpace(L2) == false && IsEmployeeOnProcessing(EmployeeID, 2) == true)
            {
                Allow_ManagerL2_Updated = true;
            }

            //Xét trường hợp cấp phê duyệt 3
            if (String.IsNullOrWhiteSpace(L3) == false && IsEmployeeOnProcessing(EmployeeID, 3) == true)
            {
                Allow_ManagerL3_Updated = true;
            }
        }

        private System.Collections.ArrayList getCollectionsManagerID(string employeeid)
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            System.Data.DataTable dt;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { employeeid };
            dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                arr.Add(dt.Rows[0][0]);
                arr.Add(dt.Rows[0][1]);
                arr.Add(dt.Rows[0][2]);
            }
            provider.CloseConnection();
            return arr;
        }

        protected void ASPxGridView2_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            this.ASPxGridView2.SettingsText.Title = "";
            string EmployeeID = e.Keys[0].ToString();
            if (IsEmployeeOnProcessing(EmployeeID, 1) == true)
            {
                e.Cancel = true;

                if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                {
                    this.ASPxGridView2.SettingsText.Title = "Không thể xóa vì lượt đăng ký của nhân viên đang được cấp duyệt 1 xử lý";
                }
                else
                {
                    this.ASPxGridView2.SettingsText.Title = "Because this employee is on processing, you can not delete this record.";
                }

            }
            if (IsEmployeeOnProcessing(EmployeeID, 2) == true)
            {
                e.Cancel = true;

                if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                {
                    this.ASPxGridView2.SettingsText.Title = "Không thể xóa vì lượt đăng ký của nhân viên đang được cấp duyệt 2 xử lý";
                }
                else
                {
                    this.ASPxGridView2.SettingsText.Title = "Because this employee is on processing, you can not delete this record.";
                }
            }
            if (IsEmployeeOnProcessing(EmployeeID, 3) == true)
            {
                e.Cancel = true;

                if (Session["lang"] == null || Session["lang"].ToString() == "vi")
                {
                    this.ASPxGridView2.SettingsText.Title = "Không thể xóa vì lượt đăng ký của nhân viên đang được cấp duyệt 3 xử lý";
                }
                else
                {
                    this.ASPxGridView2.SettingsText.Title = "Because this employee is on processing, you can not delete this record.";
                }
            }
        }

        //protected void ASPxFileManager1_FileUploading(object source, FileManagerFileUploadEventArgs e)
        //{

        //}

        //protected void btnImport_Click(object sender, EventArgs e)
        //{
        //    string sqlcon = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
        //    string path = Server.MapPath("~/Upload/ManagerLevel.xlsx");
        //    string xlscon = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
        //    try
        //    {                

        //        //Xóa dữ liệu tblEmpManagerLevel trước khi insert
        //        khSqlServerProvider provider = new khSqlServerProvider(sqlcon);
        //        provider.CommandText = "Delete from tblEmpManagerLevel";
        //        provider.ExecuteNonQuery();
        //        provider.CloseConnection();

        //        //Đọc dữ liệu từ excel
        //        OleDbConnection connection = new OleDbConnection();
        //        connection.ConnectionString = xlscon;
        //        OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
        //        connection.Open();
        //        OleDbDataReader dr = command.ExecuteReader();


        //        //Insert dữ liệu vào database
        //        SqlBulkCopy bulkInsert = new SqlBulkCopy(sqlcon);
        //        bulkInsert.DestinationTableName = "tblEmpManagerLevel";
        //        bulkInsert.WriteToServer(dr);
        //        lbThongBao.Text = "Đã xong";

        //        dr.Dispose();
        //        command.Dispose();
        //        bulkInsert.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        lbThongBao.Text = ex.Message;
        //    }

        //}

        //protected void UploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        //{
        //    if (UploadControl1.UploadedFiles != null)
        //    {
        //        string path = string.Concat(Server.MapPath("~/Upload/" + UploadControl1.UploadedFiles[0].FileName));
        //        UploadControl1.UploadedFiles[0].SaveAs(path,true);
        //    }
        //}



    }
}