using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using DevExpress.Web;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;

namespace NPOL
{
    public partial class AF_ManagerLevelNew : System.Web.UI.Page
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
            else
            {
                gvDinhCapTMP.SettingsText.Title = "";
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //Tổng hợp datasource cho lưới ẩn DinhCap
            DataTable dt = CollectDataSource();

            //Gán datasource cho lưới ẩn DinhCap
            DinhCap.DataSource = dt;
            DinhCap.DataBind();

            //Xuất dữ liệu ra excel
            gvExporter.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            DataTable dt = CollectDataSource();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                //Xóa trắng dữ liệu trong tblEmpManagerLevel_tmp 
                cleardata();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    provider.CommandText = "Insert into tblEmpManagerLevel_tmp (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, @DateChange, @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
                    provider.ParameterCollection = new string[] { "@EmployeeID", "@DateChange", "@SectionID", "@LineID", "@PosID", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
                    object empid = dt.Rows[i]["EmployeeID"];
                    object datechange = DateTime.Now;
                    object sectionid = dt.Rows[i]["SectionID"];
                    object lineid = dt.Rows[i]["LineID"];
                    object posid = dt.Rows[i]["PosID"];
                    object managerid_l1 = dt.Rows[i]["ID_L1"];
                    object managerid_l2 = dt.Rows[i]["ID_L2"];
                    object managerid_l3 = dt.Rows[i]["ID_L3"];
                    provider.ValueCollection = new object[] { empid, datechange, sectionid, lineid, posid, managerid_l1, managerid_l2, managerid_l3 };
                    provider.ExecuteNonQuery();
                }
                ASPxPageControl1.ActiveTabIndex = 1;
                gvDinhCapTMP.DataBind();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + ex.Message + "')", true);
            }
        }

        private DataTable EmployeeInfo(object EmpID)
        {
            DataTable dt = new DataTable();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //provider.CommandText = "Select * from view_DinhCap where EmployeeID = @EmployeeID";
            provider.CommandText = "spAL_ManagerLevelInfo";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmpID };
            dt = provider.GetDataTable();
            provider.CloseConnection();
            return dt;
        }

        private void cleardata()
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Delete from tblEmpManagerLevel_tmp";
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        private DataTable CollectDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeID");
            dt.Columns.Add("EmployeeName");
            dt.Columns.Add("SectionID");
            dt.Columns.Add("SectionName");
            dt.Columns.Add("LineID");
            dt.Columns.Add("LineName");
            dt.Columns.Add("PosID");
            dt.Columns.Add("PosName");
            dt.Columns.Add("ID_L1");
            dt.Columns.Add("Name_L1");
            dt.Columns.Add("ID_L2");
            dt.Columns.Add("Name_L2");
            dt.Columns.Add("ID_L3");
            dt.Columns.Add("Name_L3");

            ArrayList arr;

            for (int i = 0; i < gvDinhCap.VisibleRowCount; i++)
            {
                arr = new ArrayList();
                object empid = gvDinhCap.GetDataRow(i)["EmployeeID"];
                DataTable dtDinhCap = EmployeeInfo(empid);
                if (dtDinhCap.Rows.Count > 0)
                {
                    arr.Add(empid);
                    arr.Add(dtDinhCap.Rows[0]["EmployeeName"]);
                    arr.Add(dtDinhCap.Rows[0]["LineID"]);
                    arr.Add(dtDinhCap.Rows[0]["LineName"]);
                    arr.Add(dtDinhCap.Rows[0]["DepID"]);
                    arr.Add(dtDinhCap.Rows[0]["DepName"]);
                    arr.Add(dtDinhCap.Rows[0]["PosID"]);
                    arr.Add(dtDinhCap.Rows[0]["PosName"]);
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L1"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L1"]);
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L2"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L2"]);
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L3"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L3"]);
                    dt.Rows.Add(arr.ToArray());
                }

            }
            return dt;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            gvDinhCapTMP.SettingsText.Title = "";
            try
            {
                UpdateManagerLevel();
                gvDinhCap.DataBind();
                gvDinhCapTMP.DataBind();
                ASPxPageControl1.ActiveTabIndex = 0;
            }
            catch (Exception ex)
            {
                gvDinhCapTMP.SettingsText.Title = ex.Message;
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //Clear data
            cleardata();

            //Clear Title Text
            gvDinhCapTMP.SettingsText.Title = "";

            int current = 0;
            try
            {
                //Đọc dữ liệu excel vào DataTable
                DataTable exceldata = getExelData(fullpath);
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                if (exceldata.Rows.Count > 0)
                {
                    for (int i = 0; i < exceldata.Rows.Count; i++)
                    {
                        current = i + 2;
                        object empid = exceldata.Rows[i][0];
                        if (empid.Equals(""))
                            break;
                        object sectionid = exceldata.Rows[i][2];
                        object lineid = exceldata.Rows[i][4];
                        object posid = exceldata.Rows[i][6];
                        object m1 = exceldata.Rows[i][8];
                        object m2 = exceldata.Rows[i][10];
                        object m3 = exceldata.Rows[i][12];

                        //Thêm dữ liệu vào bảng định cấp tạm tblEmpManagerLevel_TMP
                        provider.CommandText = "Insert into tblEmpManagerLevel_tmp (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@SectionID", "@LineID", "@PosID", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
                        provider.ValueCollection = new object[] { empid, sectionid, lineid, posid, m1, m2, m3 };
                        provider.ExecuteNonQuery();
                    }
                }

                provider.CloseConnection();
                gvDinhCapTMP.DataBind();

            }
            catch (Exception ex)
            {
                gvDinhCapTMP.SettingsText.Title = "Import bị lỗi tại dòng thứ " + current.ToString() + " vì nguyên nhân: [" + ex.Message + "]";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            cleardata();
            gvDinhCapTMP.DataBind();
        }

        const string UploadDirectory = "~/Upload/";
        static string fullpath = "";
        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string resultFileName = Path.ChangeExtension("DinhCap", resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            fullpath = resultFilePath;
            e.UploadedFile.SaveAs(resultFilePath, true);
        }

        protected void gvDinhCapTMP_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            object EmpID = e.GetFieldValue("EmployeeID");
            object M1 = e.GetFieldValue("ManagerID_L1");
            object M2 = e.GetFieldValue("ManagerID_L2");
            object M3 = e.GetFieldValue("ManagerID_L3");

            if (e.GetFieldValue("EmployeeID") != null)
            {
                if (!EmpID.ToString().Equals(""))
                {
                    if (e.Column.FieldName.Equals("EmployeeID"))
                    {
                        e.DisplayText = getEmployeeName(EmpID.ToString());
                    }

                    if (e.Column.FieldName.Equals("ManagerID_L1"))
                    {
                        e.DisplayText = getEmployeeName(M1.ToString());
                    }

                    if (e.Column.FieldName.Equals("ManagerID_L2"))
                    {
                        e.DisplayText = getEmployeeName(M2.ToString());
                    }

                    if (e.Column.FieldName.Equals("ManagerID_L3"))
                    {
                        e.DisplayText = getEmployeeName(M3.ToString());
                    }
                }
            }
        }

        private DataTable getExelData(string path)
        {
            DataTable dt = new DataTable();
            OleDbConnection con;
            OleDbCommand com;
            OleDbDataAdapter da;
            string constring = "";

            try
            {
                constring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                constring = string.Format(constring, path);

                //Tạo đối tượng OleDbConnection và mở kết nối
                con = new OleDbConnection(constring);
                con.Open();

                //Tạo và truyền tham số cho đối tượng OleDbCommand
                string query = "Select * from [{0}]";
                query = string.Format(query, "Sheet$");
                com = new OleDbCommand(query, con);
                com.CommandTimeout = 0;

                //Tạo đối tượng OleDbDataAdapter
                da = new OleDbDataAdapter(com);

                //Tạo đối tượng Dataset để chứa dữ liệu từ Adapter
                DataSet ds = new DataSet();

                //Đổ dữ liệu vào dataset
                da.Fill(ds);

                //Đổ dữ liệu vào DataTable
                dt = ds.Tables[0];

                //Đóng kết nối
                con.Close();
            }
            catch (Exception ex)
            {
                gvDinhCapTMP.SettingsText.Title = ex.Message;
            }
            return dt;
        }

        public string getEmployeeName(object EmployeeID)
        {
            string value = null;
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select EmployeeName from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = provider.GetDataTable().Rows[0]["EmployeeName"].ToString();
            }
            provider.CloseConnection();
            return value;
        }

        private void UpdateManagerLevel()
        {
            //int returnValue = 0;
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Select * from tblEmpManagerLevel_tmp";
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count == 0)
            {
                gvDinhCapTMP.SettingsText.Title = "Không có dữ liệu để cập nhật";
            }
            else if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object employeeid = dt.Rows[i]["EmployeeID"];
                    object sectionid = dt.Rows[i]["SectionID"];
                    object lineid = dt.Rows[i]["LineID"];
                    object posid = dt.Rows[i]["PosID"];
                    object m1 = dt.Rows[i]["ManagerID_L1"];
                    object m2 = dt.Rows[i]["ManagerID_L2"];
                    object m3 = dt.Rows[i]["ManagerID_L3"];

                    if (!kh.IsEmployee(employeeid.ToString()))
                    {
                        //Thêm mới định cấp
                        provider.CommandText = "Insert into tblEmpManagerLevel (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@SectionID", "@LineID", "@PosID", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
                        provider.ValueCollection = new object[] { employeeid, sectionid, lineid, posid, m1, m2, m3 };
                        provider.ExecuteNonQuery();
                        gvDinhCap.DataBind();
                    }
                    else
                    {
                        //Cập nhật định cấp cho tblEmpManagerLevel
                        provider.CommandText = "Update tblEmpManagerLevel Set ManagerID_L1 = @L1, ManagerID_L2 = @L2, ManagerID_L3 = @L3 where EmployeeID = @EmpID";
                        provider.ParameterCollection = new string[] { "@L1", "@L2", "@L3", "@EmpID" };
                        provider.ValueCollection = new object[] { m1, m2, m3, employeeid };
                        int z = provider.ExecuteNonQuery();
                        //gvDinhCap.DataBind();
                        if (z > 0)
                        {
                            //Cập nhật định cấp cho tblWebData
                            tblWebData web = new tblWebData(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                            tblEmpManagerLevel emp = new tblEmpManagerLevel(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);

                            ArrayList arrLevel = new ArrayList();
                            arrLevel = emp.getManagerLevelList(employeeid);
                            if (arrLevel.Count > 0)
                            {
                                int startmail = Convert.ToInt32(arrLevel[0]);
                                provider.CommandText = "Select ID, LeaveID, TotalDays from tblWebData where FinalStatus = 'w' and EmployeeID = @EmpID";
                                provider.ParameterCollection = new string[] { "@EmpID" };
                                provider.ValueCollection = new object[] { employeeid };
                                DataTable dt1 = provider.GetDataTable();
                                string sql = "";
                                if (dt1.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt1.Rows.Count; j++)
                                    {
                                        int CheckNum = CalCheckNum(employeeid, dt1.Rows[j]["LeaveID"], dt1.Rows[j]["TotalDays"], arrLevel.Count);
                                        switch (startmail)
                                        {
                                            case 1:
                                                if (CheckNum <= 1)
                                                {
                                                    sql = "";
                                                    sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                    sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                    sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                    sql += "ManagerID_L1 = @L1, ManagerID_L2 = NULL, ManagerID_L3 = NULL, ";
                                                    sql += "MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL where ID = @ID";
                                                    provider.CommandText = sql;
                                                    provider.ParameterCollection = new string[] { "@CheckNum", "@L1", "@ID" };
                                                    provider.ValueCollection = new object[] { CheckNum, m1, dt1.Rows[j]["ID"] };
                                                    provider.ExecuteNonQuery();
                                                }
                                                else if (CheckNum <= 2)
                                                {
                                                    sql = "";
                                                    sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                    sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                    sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                    sql += "ManagerID_L1 = @L1, ManagerID_L2 = @L2, ManagerID_L3 = NULL, ";
                                                    sql += "MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL where ID = @ID";
                                                    provider.CommandText = sql;
                                                    provider.ParameterCollection = new string[] { "@CheckNum", "@L1", "@L2", "@ID" };
                                                    provider.ValueCollection = new object[] { CheckNum, m1, m2, dt1.Rows[j]["ID"] };
                                                    provider.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    sql = "";
                                                    sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                    sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                    sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                    sql += "ManagerID_L1 = @L1, ManagerID_L2 = @L2, ManagerID_L3 = @L3, ";
                                                    sql += "MailToL1 = 1, MailToL2 = NULL, MailToL3 = NULL where ID = @ID";
                                                    provider.CommandText = sql;
                                                    provider.ParameterCollection = new string[] { "@CheckNum", "@L1", "@L2", "@L3", "@ID" };
                                                    provider.ValueCollection = new object[] { CheckNum, m1, m2, m3, dt1.Rows[j]["ID"] };
                                                    provider.ExecuteNonQuery();
                                                }

                                                break;

                                            case 2:
                                                if (CheckNum <= 1)
                                                {
                                                    sql = "";
                                                    sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                    sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                    sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                    sql += "ManagerID_L1 = NULL, ManagerID_L2 = @L2, ManagerID_L3 = NULL, ";
                                                    sql += "MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL where ID = @ID";
                                                    provider.CommandText = sql;
                                                    provider.ParameterCollection = new string[] { "@CheckNum", "@L2", "@ID" };
                                                    provider.ValueCollection = new object[] { CheckNum, m2, dt1.Rows[j]["ID"] };
                                                    provider.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    sql = "";
                                                    sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                    sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                    sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                    sql += "ManagerID_L1 = NULL, ManagerID_L2 = @L2, ManagerID_L3 = @L3, ";
                                                    sql += "MailToL1 = NULL, MailToL2 = 1, MailToL3 = NULL where ID = @ID";
                                                    provider.CommandText = sql;
                                                    provider.ParameterCollection = new string[] { "@CheckNum", "@L2", "@L3", "@ID" };
                                                    provider.ValueCollection = new object[] { CheckNum, m2, m3, dt1.Rows[j]["ID"] };
                                                    provider.ExecuteNonQuery();
                                                }

                                                break;

                                            case 3:
                                                sql = "";
                                                sql += "Update tblWebData Set CheckNum = @CheckNum, ApprovingStatus_L1 = NULL, ApprovingDate_L1 = NULL, ApprovingReason_L1 = NULL, ";
                                                sql += "ApprovingStatus_L2 = NULL, ApprovingDate_L2 = NULL, ApprovingReason_L2 = NULL, ";
                                                sql += "ApprovingStatus_L3 = NULL, ApprovingDate_L3 = NULL, ApprovingReason_L3 = NULL, ";
                                                sql += "ManagerID_L1 = NULL, ManagerID_L2 = NULL, ManagerID_L3 = @L3, ";
                                                sql += "MailToL1 = NULL, MailToL2 = NULL, MailToL3 = 1 where ID = @ID";
                                                provider.CommandText = sql;
                                                provider.ParameterCollection = new string[] { "@CheckNum", "@L3", "@ID" };
                                                provider.ValueCollection = new object[] { CheckNum, m3, dt1.Rows[j]["ID"] };
                                                provider.ExecuteNonQuery();
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            provider.CloseConnection();
            //return returnValue;
        }

        private int CalCheckNum(object EmployeeID, object LeaveType, object DaysOff, object curCheckNum)
        {
            int MaxCheckNum = Convert.ToInt32(curCheckNum);
            int CheckNum = 0;
            switch (LeaveType.ToString().ToLower())
            {
                #region Phép không hưởng lương
                //Trường hợp nghỉ không lương UP
                case "up":
                    //Nếu số ngày nghỉ dưới 4 ngày thì duyệt qua 1 cấp
                    if (Convert.ToDouble(DaysOff) < 4)
                    {
                        //Nếu số cấp duyệt hiện hữu lớn hơn 1 cấp thì CheckNum = 1
                        if (MaxCheckNum >= 1)
                        {
                            CheckNum = 1;
                        }
                    }
                    //Ngược lại nếu nghỉ từ 4 -> 12 ngày
                    else if (Convert.ToDouble(DaysOff) < 13)
                    {
                        //Nếu số cấp duyệt hiện hữu trên 2 cấp thì CheckNum = 2
                        if (MaxCheckNum >= 2)
                        {
                            CheckNum = 2;
                        }
                        //Ngược lại nếu số cấp duyệt hiện hữu dưới 2 cấp thì CheckNum sẽ bằng số cấp duyệt hiện hữu
                        else
                        {
                            CheckNum = MaxCheckNum;
                        }
                    }
                    //Ngược lại nếu nghỉ trên 12 ngày
                    else
                    {
                        //Nếu số cấp duyệt hiện hữu trên 3 cấp thì CheckNum = 3
                        if (MaxCheckNum >= 3)
                        {
                            CheckNum = 3;
                        }
                        //Ngược lại thì CheckNum = số cấp duyệt hiện hữu
                        else
                        {
                            CheckNum = MaxCheckNum;
                        }
                    }
                    break;
                #endregion

                #region Phép năm
                case "al":
                    //Nếu số cấp duyệt hiện hữu trên 2 cấp thì CheckNum = 2
                    if (MaxCheckNum >= 2)
                    {
                        CheckNum = 1;
                    }
                    //Ngược lại thì CheckNum = số cấp duyệt hiện hữu
                    else
                    {
                        CheckNum = MaxCheckNum;
                    }


                    break;
                #endregion

                //Các trường hợp khác
                default:
                    if (MaxCheckNum >= 2)
                    {
                        CheckNum = 1;
                    }
                    else
                    {
                        CheckNum = MaxCheckNum;
                    }
                    break;
            }
            return CheckNum;
        }


    }
}