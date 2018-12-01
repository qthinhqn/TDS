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
    public partial class K_ManagerKPILevel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null || !Session["Role"].ToString().Equals("PA_Admin"))
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
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
                //Xóa trắng dữ liệu trong tblKPIManagerLevel_tmp 
                cleardata();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    provider.CommandText = "Insert into tblKPIManagerLevel_tmp (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, @DateChange, @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
                    provider.ParameterCollection = new string[] { "@EmployeeID", "@DateChange", "@SectionID", "@LineID", "@PosID", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
                    object empid = dt.Rows[i]["EmployeeID"].ToString().ToUpper();
                    object datechange = DateTime.Now;
                    object sectionid = dt.Rows[i]["SectionID"];
                    object lineid = dt.Rows[i]["LineID"];
                    object posid = dt.Rows[i]["PosID"];
                    object managerid_l1 = dt.Rows[i]["ID_L1"].ToString().ToUpper();
                    object managerid_l2 = dt.Rows[i]["ID_L2"].ToString().ToUpper();
                    object managerid_l3 = dt.Rows[i]["ID_L3"].ToString().ToUpper();
                    //object managerid_l4 = dt.Rows[i]["ID_L4"].ToString().ToUpper();
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
            provider.CommandText = "Select * from view_DinhCapPA where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmpID };
            dt = provider.GetDataTable();
            provider.CloseConnection();
            return dt;
        }

        private void cleardata()
        {
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            provider.CommandText = "Delete from tblKPIManagerLevel_tmp";
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
            //dt.Columns.Add("ID_L4");
            //dt.Columns.Add("Name_L4");

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
                    arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L3"]);
                    arr.Add(dtDinhCap.Rows[0]["ManagerName_L3"]);
                    //arr.Add(gvDinhCap.GetDataRow(i)["ManagerID_L4"]);
                    //arr.Add(dtDinhCap.Rows[0]["ManagerName_L4"]);
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
                        object empid = exceldata.Rows[i][0].ToString().ToUpper();
                        object sectionid = exceldata.Rows[i][2];
                        object lineid = exceldata.Rows[i][4];
                        object posid = exceldata.Rows[i][6];
                        object m1 = exceldata.Rows[i][8].ToString().ToUpper();
                        object m2 = exceldata.Rows[i][10].ToString().ToUpper();
                        object m3 = exceldata.Rows[i][12].ToString().ToUpper();
                        //object m4 = exceldata.Rows[i][14].ToString().ToUpper();

                        //Thêm dữ liệu vào bảng định cấp tạm tblKPIManagerLevel_TMP
                        provider.CommandText = "Insert into tblKPIManagerLevel_tmp (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
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
            if (!Directory.Exists(MapPath(UploadDirectory)))
            {
                Directory.CreateDirectory(MapPath(UploadDirectory));
            }
            fullpath = resultFilePath;
            e.UploadedFile.SaveAs(resultFilePath, true);
        }

        protected void gvDinhCapTMP_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            object EmpID = e.GetFieldValue("EmployeeID");
            object M1 = e.GetFieldValue("ManagerID_L1");
            object M2 = e.GetFieldValue("ManagerID_L2");
            object M3 = e.GetFieldValue("ManagerID_L3");
            //object M4 = e.GetFieldValue("ManagerID_L4");

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

                    //if (e.Column.FieldName.Equals("ManagerID_L4"))
                    //{
                    //    e.DisplayText = getEmployeeName(M4.ToString());
                    //}
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
            provider.CommandText = "Select * from tblKPIManagerLevel_tmp";
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
                    object sectionid = dt.Rows[i]["SectionID"];
                    object lineid = dt.Rows[i]["LineID"];
                    object posid = dt.Rows[i]["PosID"];
                    object m1 = dt.Rows[i]["ManagerID_L1"].ToString().ToUpper();
                    object m2 = dt.Rows[i]["ManagerID_L2"].ToString().ToUpper();
                    object m3 = dt.Rows[i]["ManagerID_L3"].ToString().ToUpper();
                    //object m4 = dt.Rows[i]["ManagerID_L4"].ToString().ToUpper();

                    if (!kh.IsEmployeeKPI(employeeid.ToString()))
                    {
                        //Thêm mới định cấp
                        provider.CommandText = "Insert into tblKPIManagerLevel (EmployeeID, DateChange, SectionID, LineID, PosID, ManagerID_L1, ManagerID_L2, ManagerID_L3) values(@EmployeeID, getdate(), @SectionID, @LineID, @PosID, @ManagerID_L1, @ManagerID_L2, @ManagerID_L3)";
                        provider.ParameterCollection = new string[] { "@EmployeeID", "@SectionID", "@LineID", "@PosID", "@ManagerID_L1", "@ManagerID_L2", "@ManagerID_L3" };
                        provider.ValueCollection = new object[] { employeeid, sectionid, lineid, posid, m1, m2, m3 };
                        provider.ExecuteNonQuery();
                        
                    }
                    else
                    {
                        //Cập nhật định cấp cho tblKPIManagerLevel
                        provider.CommandText = "Update tblKPIManagerLevel Set ManagerID_L1 = @L1, ManagerID_L2 = @L2, ManagerID_L3 = @L3 where EmployeeID = @EmpID";
                        provider.ParameterCollection = new string[] { "@L1", "@L2", "@L3", "@EmpID" };
                        provider.ValueCollection = new object[] { m1, m2, m3, employeeid };
                        int z = provider.ExecuteNonQuery();
                    }
                }

                gvDinhCap.DataBind();
            }
            provider.CloseConnection();
            //return returnValue;
        }

    }
}