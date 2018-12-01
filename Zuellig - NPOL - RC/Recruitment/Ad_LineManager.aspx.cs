using System;
using System.Web.UI;
using System.Data;
using System.Collections;
using DevExpress.Web;
using System.Data.OleDb;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace NPOL
{
    public partial class Ad_LineManager : System.Web.UI.Page
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
                if (!Session["Role"].ToString().Equals("RC_Admin"))
                {
                    Response.Redirect("Login.aspx");
                }
            }


            if (!IsPostBack)
            {

            }
            else
            {
                gvDinhCapTMP.SettingsText.Title = "";
            }
        }

        private DataTable CollectDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ManagerID");
            dt.Columns.Add("EmployeeID");

            ArrayList arr;

            for (int i = 0; i < gvDinhCap.VisibleRowCount; i++)
            {
                arr = new ArrayList();
                object managerid = gvDinhCap.GetDataRow(i)["ManagerID"];
                object empid = gvDinhCap.GetDataRow(i)["EmployeeID"];
                arr.Add(managerid);
                arr.Add(empid);
                dt.Rows.Add(arr.ToArray());

            }
            return dt;
        }

        #region // tab_1 button events
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            DataTable dt = CollectDataSource();
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            try
            {
                //Xóa trắng dữ liệu trong tblEmpLineManager_tmp 
                cleardata();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    provider.CommandText = "Insert into tblEmpLineManager_tmp (EmployeeID, DateChange, ManagerID) values(UPPER(@EmployeeID), @DateChange, UPPER(@ManagerID))";
                    provider.ParameterCollection = new string[] { "@EmployeeID", "@DateChange", "@ManagerID" };
                    object managerid = dt.Rows[i]["ManagerID"];
                    object empid = dt.Rows[i]["EmployeeID"];
                    object datechange = DateTime.Now;
                    provider.ValueCollection = new object[] { empid, datechange, managerid };
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
        protected void btnXlsExport_Click(object sender, EventArgs e)
        {
            gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        }
        #endregion

        #region // tab_2 button & events

        protected void gvDinhCapTMP_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                object EmpID = e.GetFieldValue("EmployeeID");

                //object SectionID = e.GetFieldValue("SectionID");
                //object LineID = e.GetFieldValue("LineID");
                //object PosID = e.GetFieldValue("PosID");
                //object LocationID = e.GetFieldValue("LocationID");
                //object LevelID = e.GetFieldValue("LevelID");

                switch (e.Column.FieldName)
                {
                    case "ManagerID":
                        object ManagerID = e.GetFieldValue("ManagerID");
                        e.DisplayText = getEmployeeInfo(ManagerID.ToString(), "EmployeeName");
                        break;

                    case "EmployeeID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "EmployeeName");
                        break;

                    case "SectionID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "SectionName");
                        break;

                    case "LineID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "LineName");
                        break;

                    case "PosID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "PosName");
                        break;

                    case "LocationID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "LocationName");
                        break;

                    case "LevelID":
                        e.DisplayText = getEmployeeInfo(EmpID.ToString(), "LevelName");
                        break;

                    default:
                        break;
                }
            }
            catch { }
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
                    for (int i = 1; i < exceldata.Rows.Count; i++)
                    {
                        current = i + 2;
                        object managerid = exceldata.Rows[i][0];
                        object empid = exceldata.Rows[i][2];
                        if (managerid.Equals("") | empid.Equals(""))
                            break;
                        //object sectionid = exceldata.Rows[i][2];
                        //object lineid = exceldata.Rows[i][4];
                        //object posid = exceldata.Rows[i][6];
                        //object locationid = exceldata.Rows[i][8];
                        //object levelid = exceldata.Rows[i][10];

                        //Thêm dữ liệu vào bảng định cấp tạm tblEmpLineManager_TMP
                        provider.CommandText = "Insert into tblEmpLineManager_tmp (EmployeeID, DateChange, ManagerID) values(UPPER(@EmployeeID), getdate(), UPPER(@ManagerID))";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@ManagerID" };
                        provider.ValueCollection = new object[] { empid, managerid };
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

        #endregion
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
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "Delete from tblEmpLineManager_tmp";
                provider.ExecuteNonQuery();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        const string UploadDirectory = "~/Upload/";
        static string fullpath = "";
        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string resultFileName = Path.ChangeExtension("LineManager", resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            fullpath = resultFilePath;
            e.UploadedFile.SaveAs(resultFilePath, true);
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

        public string getEmployeeInfo(object EmployeeID, string strInfo)
        {
            string value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "sp_EmployeeInfo";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = provider.GetDataTable().Rows[0][strInfo].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {

            }
            return value;
        }

        private void UpdateManagerLevel()
        {
            try
            {
                //int returnValue = 0;
                Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "Select * from tblEmpLineManager_tmp";
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count == 0)
                {
                    gvDinhCapTMP.SettingsText.Title = "Không có dữ liệu để cập nhật";
                }
                else if (dt.Rows.Count > 0)
                {
                    provider.CommandText = "sp_EmpLineManager_Import";
                    provider.CommandType = CommandType.StoredProcedure;
                    provider.ExecuteNonQuery();
                }
                provider.CloseConnection();
                //return returnValue;
            }
            catch (Exception ex)
            {

            }
        }

    }
}