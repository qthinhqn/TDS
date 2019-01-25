using System.IO;
using System.Linq;
using System.Web;
using System;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using System.Data;

public class FileDownloadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request["id"];
        try
        {
            tbl_Attachment_RC obj = Attachment_RCService.GetAttachmentById(int.Parse(id));

            byte[] content = File.ReadAllBytes(context.Server.MapPath(obj.AttachmentPath.Replace("Recruitment/", "") + @"/" + obj.AttachmentName));

            string fileType = obj.AttachmentName.Substring(obj.AttachmentName.LastIndexOf('.'));
            ExportToResponse(context, content, obj.AttachmentName, fileType, false);
        }
        catch (Exception ex)
        {
            DataTable dt = GetDataInfo(id);

            ExportToResponse(context, dt);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public void ExportToResponse(HttpContext context, byte[] content, string fileName, string fileType, bool inline)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/" + fileType;
        context.Response.AddHeader("Content-Disposition", string.Format("{0}; filename={1}", inline ? "Inline" : "Attachment", fileName));
        context.Response.AddHeader("Content-Length", content.Length.ToString());
        //Response.ContentEncoding = System.Text.Encoding.Default;
        context.Response.BinaryWrite(content);
        context.Response.Flush();
        context.Response.Close();
        context.Response.End();
    }

    private DataTable GetDataInfo(object DepID)
    {
        DataTable dt = new DataTable();
        khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
        provider.CommandText = "spPR_view_DinhCap";
        provider.CommandType = CommandType.StoredProcedure;
        provider.ParameterCollection = new string[] { "@DepID" };
        provider.ValueCollection = new object[] { DepID };
        dt = provider.GetDataTable();
        provider.CloseConnection();
        return dt;
    }


    public void ExportToResponse(HttpContext context, DataTable table)
    {
        try
        {

            // This actually makes your HTML output to be downloaded as .xls file
            context.Response.Clear();
            context.Response.ClearContent();
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=ExcelFile.xls");
            context.Response.ContentEncoding = System.Text.Encoding.Unicode;
            context.Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            // Create a dynamic control, populate and render it
            System.Web.UI.WebControls.GridView excel = new System.Web.UI.WebControls.GridView();
            excel.DataSource = table;
            excel.DataBind();
            excel.RenderControl(new System.Web.UI.HtmlTextWriter(context.Response.Output));

            context.Response.Flush();
            context.Response.End();
            /*
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(table, "List");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            
            if (table.Rows.Count > 0)
            {
                string filename = "DownloadMobileNoExcel.xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                System.Web.UI.WebControls.DataGrid dgGrid = new System.Web.UI.WebControls.DataGrid();
                dgGrid.DataSource = table;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                context.Response.ContentType = "application/vnd.ms-excel";
                context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                //this.EnableViewState = false;
                context.Response.Write(tw.ToString());
                context.Response.End();
            }
            */
        }
        catch (Exception ex)
        {
        }
    }
}