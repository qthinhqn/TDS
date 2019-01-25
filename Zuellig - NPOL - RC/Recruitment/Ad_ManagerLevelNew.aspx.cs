using System;
using System.Web.UI;
using System.Data;
using System.Collections;
using DevExpress.Web;
using System.Data.OleDb;
using System.IO;
using DevExpress.Web.ASPxTreeList;
using System.Drawing;
using ClosedXML.Excel;

namespace NPOL
{
    public partial class RC_ManagerLevelNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null || !Session["Role"].ToString().Equals("RC_Admin"))
            {
                Response.Redirect("../Login.aspx");
            }

            if (!IsPostBack)
            {
                //Session["DepID"] = null;
                //Session["DepTypeID"] = null;
            }
            else
            {
                gvDinhCapTMP.SettingsText.Title = "";
                //Load data grid
                gvDinhCap.DataBind();
            }

            CustomizeFocusedNodeStyle(treeList, Color.FromArgb(255, 242, 200), Color.Black);
        }
        private void CustomizeFocusedNodeStyle(ASPxTreeList treeList, Color bkColor, Color foreColor)
        {
            treeList.Styles.FocusedNode.BackColor = bkColor;
            treeList.Styles.FocusedNode.ForeColor = foreColor;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["DepID"] != null)
                {
                    string str = Session["DepID"].ToString().Replace("-", "%2D");
                    Response.Redirect("FileDownloadHandler.ashx?id=" + str);
                }
                /*
                //Tổng hợp datasource cho lưới ẩn DinhCap
                DataTable dt = CollectDataSource();

                //Gán datasource cho lưới ẩn DinhCap
                DinhCap.DataSource = dt;
                DinhCap.DataBind();

                //Xuất dữ liệu ra excel
                //gvExporter.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
                */
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            DataTable dt = CollectDataSource();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                //Xóa trắng dữ liệu trong tblOTManagerLevel_tmp 
                cleardata();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    provider.CommandText = "Insert into tblPR_ManagerLevel_tmp (EmployeeID, DateChange, ManagerID_L1, ManagerID_L2) values(@EmployeeID, @DateChange, @ManagerID_L1, @ManagerID_L2)";
                    provider.ParameterCollection = new string[] { "@EmployeeID", "@DateChange", "@ManagerID_L1", "@ManagerID_L2" };
                    object empid = dt.Rows[i]["EmployeeID"];
                    object datechange = DateTime.Now;
                    object managerid_l1 = dt.Rows[i]["ID_L1"];
                    object managerid_l2 = dt.Rows[i]["ID_L2"];
                    provider.ValueCollection = new object[] { empid, datechange, managerid_l1, managerid_l2 };
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
            provider.CommandText = "spPR_InfoDinhCap";
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
            provider.CommandText = "Delete from tblPR_ManagerLevel_tmp";
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
                    arr.Add(dtDinhCap.Rows[0]["SectionID"]);
                    arr.Add(dtDinhCap.Rows[0]["SectionName"]);
                    arr.Add(dtDinhCap.Rows[0]["LineID"]);
                    arr.Add(dtDinhCap.Rows[0]["LineName"]);
                    arr.Add(dtDinhCap.Rows[0]["PosID"]);
                    arr.Add(dtDinhCap.Rows[0]["PosName"]);
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L1"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L1"]);
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L2"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L2"]);
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
                treeList.DataBind();
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
                        object m1 = exceldata.Rows[i][8];
                        object m2 = exceldata.Rows[i][10];

                        //Thêm dữ liệu vào bảng định cấp tạm tblOTManagerLevel_TMP
                        provider.CommandText = "Insert into tblPR_ManagerLevel_tmp (EmployeeID, DateChange, ManagerID_L1, ManagerID_L2) values(@EmployeeID, getdate(), @ManagerID_L1, @ManagerID_L2)";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@ManagerID_L1", "@ManagerID_L2" };
                        provider.ValueCollection = new object[] { empid, m1, m2 };
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
            provider.CommandText = "Select * from tblPR_ManagerLevel_tmp";
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count == 0)
            {
                gvDinhCapTMP.SettingsText.Title = "Không có dữ liệu để cập nhật";
            }
            else if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object employeeid = dt.Rows[i]["EmployeeID"].ToString().ToUpper();
                    object m1 = dt.Rows[i]["ManagerID_L1"].ToString().ToUpper();
                    object m2 = dt.Rows[i]["ManagerID_L2"].ToString().ToUpper();

                    if (!kh.IsExistsEmployee_PR(employeeid.ToString()))
                    {
                        //Thêm mới định cấp
                        provider.CommandText = "Insert into tblPR_ManagerLevel (EmployeeID, DateChange, ManagerID_L1, ManagerID_L2) values(@EmployeeID, getdate(), @ManagerID_L1, @ManagerID_L2)";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@ManagerID_L1", "@ManagerID_L2" };
                        provider.ValueCollection = new object[] { employeeid, m1, m2 };
                        provider.ExecuteNonQuery();
                    }
                    else
                    {
                        //Cập nhật định cấp cho tblPR_ManagerLevel
                        provider.CommandText = "Update tblPR_ManagerLevel Set ManagerID_L1 = @L1, ManagerID_L2 = @L2 where EmployeeID = @EmpID";
                        provider.ParameterCollection = new string[] { "@L1", "@L2", "@EmpID" };
                        provider.ValueCollection = new object[] { m1, m2, employeeid };
                        int z = provider.ExecuteNonQuery();
                    }

                }
            }
            provider.CloseConnection();
            gvDinhCap.DataBind();
        }

        protected void treeList_CustomDataCallback(object sender, TreeListCustomDataCallbackEventArgs e)
        {
            string key = e.Argument.ToString();
            TreeListNode node = treeList.FindNodeByKeyValue(key);
            //e.Result = GetEntryText(node);
            Session["DepID"] = key;
            Session["DepTypeID"] = GetEntryText(node);
            gvDinhCap.DataBind();
            UpdatePanel1.DataBind();
        }

        protected string GetEntryText(TreeListNode node)
        {
            if (node != null)
            {
                string text = node["DepTypeID"].ToString();
                return text.Trim();
            }
            return string.Empty;
        }

        protected void treeList_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
        {
            //if (Object.Equals(e.GetValue("IsNew"), true))
            //    e.Cell.Font.Bold = true;
        }

    }
}