using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_ManagerSetKPI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["KPI_ID"]))
            {
                Session["KPI_ID"] = Request.Params["KPI_ID"];
                LoadEmpList(Request.Params["KPI_ID"]);
            }
            try
            {
                if (Session["Role"] == "PA_Admin")
                {

                }
            }
            catch (Exception ex)
            {
            
            }
            if (!IsPostBack)
            {
                
            }
        }

        private void LoadEmpList(string p)
        {
            gvEmployee.DataBind();
            gvTrainLine.DataBind();
        }

        static List<object> selectedKPI = new List<object>();
        static List<object> selectedEmployeeID = new List<object>();
        protected void gvEmployee_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedEmployeeID.Clear();
            selectedEmployeeID = grid.GetSelectedFieldValues(new string[] { "EmployeeID" });
        }

        protected void gvTrainLine_RowDeleted(object sender, DevExpress.Web.Data.ASPxDataDeletedEventArgs e)
        {
            gvEmployee.DataBind();
        }

        protected void gvTrainLine_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            //if (gridKPIList.GetSelectedFieldValues("ID").Count <= 0)
            //{
            //    string message = "alert('Vui lòng chọn chỉ tiêu cần phân bổ nhân viên')";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            //    return;
            //}
            if (gvEmployee.GetSelectedFieldValues("EmployeeID").Count <= 0)
            {
                string message = "alert('Vui lòng chọn nhân viên cần phân bổ')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
                //Xử lý sao chép
                foreach (object item in selectedEmployeeID)
                {
                    //object[] arr = item as object[];
                    //object empid = arr[0];
                    provider.CommandText = "spKPI_InsertDonebyList";
                    provider.CommandType = System.Data.CommandType.StoredProcedure;
                    provider.ParameterCollection = new string[] { "@KPI_ID", "EmployeeID" };
                    if (item.ToString().Equals(""))
                    {
                        return;
                    }
                    else
                    {
                        provider.ValueCollection = new object[] { Session["KPI_ID"], item };
                    }
                    provider.ExecuteNonQuery();
                }
                provider.CloseConnection();
                gvEmployee.Selection.UnselectAll();
                gvTrainLine.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + ex.Message + "')", true);
            }
        }

        protected void gridKPIList_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedKPI.Clear();
            selectedKPI = grid.GetSelectedFieldValues(new string[] { "ID" });
            Session["KPI_ID"] = selectedKPI[0];
            LoadEmpList(Session["KPI_ID"].ToString());
        }
        protected void gridKPIList_BeforePerformDataSelect(object sender, EventArgs e)
        {
            Session["KPI_ID"] = (sender as DevExpress.Web.ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gridKPIList_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // Show popup add Doneby list
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object kpiid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            kpiid = (kpiid == null ? DBNull.Value : kpiid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            //gvEmployee.DataSource = OT_DataDetailService.GetTableByid((int)kpid);
            Session["KPI_ID"] = kpiid;
            gvEmployee.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            // Show popup view Doneby list
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object kpiid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });

            //Xử lý giá trị biến
            kpiid = (kpiid == null ? DBNull.Value : kpiid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            //gvEmployee.DataSource = OT_DataDetailService.GetTableByid((int)kpid);
            Session["KPI_ID"] = kpiid;
            gvTrainLine.DataBind();
            gvEmployee.DataBind();
        }

        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }


        const string UploadDirectory = "~/Upload/";
        static string fullpath = "";
        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {

            string resultExtension = Path.GetExtension(e.UploadedFile.FileName);
            string resultFileName = Path.ChangeExtension("KPI_Import", resultExtension);
            string resultFileUrl = UploadDirectory + resultFileName;
            string resultFilePath = MapPath(resultFileUrl);
            if (!Directory.Exists(MapPath(UploadDirectory)))
            {
                Directory.CreateDirectory(MapPath(UploadDirectory));
            }
            fullpath = resultFilePath;
            e.UploadedFile.SaveAs(resultFilePath, true);
            
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //Clear Title Text
            gridKPIList.SettingsText.Title = "";

            if (fullpath == "")
            {
                string mess = GetGlobalResourceObject("AF_ManagerLevel", "mess_1").ToString();
                gridKPIList.SettingsText.Title = mess;
                return;
            }

            int current = 0;
            try
            {
                //Đọc dữ liệu excel vào DataTable
                DataTable exceldata = getExelData(fullpath);
                khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);

                if (exceldata.Rows.Count > 0)
                {
                    if (exceldata.Columns.Count != 10)
                    {
                        provider.CloseConnection();
                        string mess = GetGlobalResourceObject("AF_ManagerLevel", "mess_2").ToString();
                        gridKPIList.SettingsText.Title = mess;
                        return;
                    }
                    else
                    {
                        // delete data temp (same user input)
                        provider.CommandText = "DELETE tblStore_KPI_temp WHERE ManagerID=@ManagerID;";
                        provider.ParameterCollection = new string[] { "@ManagerID" };
                        provider.ValueCollection = new object[] { Session["EmployeeID"] };
                        provider.ExecuteNonQuery();

                        // insert data to table temp
                        for (int i = 1; i < exceldata.Rows.Count; i++)
                        {
                            current = i + 2;
                            object Description = exceldata.Rows[i][1].ToString().Trim();
                            object Performance = exceldata.Rows[i][2].ToString().Trim();
                            object Notes = exceldata.Rows[i][3].ToString().Trim();
                            object Achieve_100 = exceldata.Rows[i][4].ToString().Trim();
                            object Achieve_125 = exceldata.Rows[i][5].ToString().Trim();
                            object Achieve_150 = exceldata.Rows[i][6].ToString().Trim();
                            object EmployeeID = exceldata.Rows[i][7].ToString().Trim();
                            object Weighing = exceldata.Rows[i][9].ToString().Trim();
                            object ManagerID = Session["EmployeeID"];

                            //Thêm dữ liệu vào bảng định cấp tạm tblKPIManagerLevel_TMP
                            provider.CommandText = "INSERT INTO [tblStore_KPI_temp] ([Description],[Performance],[Achieve_100],[Achieve_125],[Achieve_150],[Notes],[EmployeeID],[Weighing],[ImportTime],[ManagerID]) "
                                                 + " VALUES (@Description,@Performance,@Achieve_100,@Achieve_125,@Achieve_150,@Notes,@EmployeeID,@Weighing,Getdate(),@ManagerID)";
                            provider.ParameterCollection = new string[] { "@Description", "@Performance", "@Achieve_100", "@Achieve_125", "@Achieve_150", "@Notes", "@EmployeeID", "@Weighing", "@ManagerID" };
                            if (Weighing.ToString() == "")
                                provider.ValueCollection = new object[] { Description, Performance, Achieve_100, Achieve_125, Achieve_150, Notes, EmployeeID, DBNull.Value, ManagerID };
                            else
                                provider.ValueCollection = new object[] { Description, Performance, Achieve_100, Achieve_125, Achieve_150, Notes, EmployeeID, double.Parse(Weighing.ToString()), ManagerID };
                            provider.ExecuteNonQuery();
                        }

                        // import data
                        provider.CommandText = "sp_ImportKPI";
                        provider.CommandType = CommandType.StoredProcedure;
                        provider.ParameterCollection = new string[] { "@ManagerID" };
                        provider.ValueCollection = new object[] { Session["EmployeeID"] };
                        provider.ExecuteNonQuery();
                    }
                }

                provider.CloseConnection();
                gridKPIList.DataBind();

            }
            catch (Exception ex)
            {
                gridKPIList.SettingsText.Title = "Import bị lỗi tại dòng thứ " + current.ToString() + " vì nguyên nhân: [" + ex.Message + "]";
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
                gridKPIList.SettingsText.Title = ex.Message;
            }
            return dt;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //gridExport.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });

                //ExportToExcel();

                string strURL = "App_Data/Template_KPI.xls";
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"Template_KPI.xls\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();

            }
            catch (Exception ex)
            {}
        }
        protected void ExportToExcel()
        {
            //Get the data from database into datatable
            khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligPAConnection"].ConnectionString);
            provider.CommandText = "spKPI_GetKPI_EmpID";
            provider.CommandType = System.Data.CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@ManagerID", "@Period_ID" };
            provider.ValueCollection = new object[] { Session["EmployeeID"], 1 };
            DataTable dt = provider.GetDataTable();

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                GridView1.Rows[i].Attributes.Add("class", "textmode");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            if (ASPxPageControl1.ActiveTabIndex == 1)
            {
                btnExport.Visible = btnImport.Visible = true;
            }
            else
            {
                btnExport.Visible = btnImport.Visible = false;
            }
        }

    }
}