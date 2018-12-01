using System.IO;
using System.Linq;
using System.Web;
using System;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;

public class FileDownloadHandler : IHttpHandler {
    public void ProcessRequest(HttpContext context) {
        string id = context.Request["id"];
        tbl_Attachment_RC obj = Attachment_RCService.GetAttachmentById(int.Parse(id));

        byte[] content = File.ReadAllBytes(context.Server.MapPath(obj.AttachmentPath.Replace("Recruitment/", "") + @"/" + obj.AttachmentName));

        string fileType = obj.AttachmentName.Substring(obj.AttachmentName.LastIndexOf('.'));
        ExportToResponse(context, content, obj.AttachmentName, fileType, false);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }
    
    public void ExportToResponse(HttpContext context, byte[] content, string fileName, string fileType, bool inline) {
        context.Response.Clear();
        context.Response.ContentType = "application/" + fileType;
        context.Response.AddHeader("Content-Disposition", string.Format("{0}; filename={1}", inline ? "Inline" : "Attachment",  fileName));
        context.Response.AddHeader("Content-Length", content.Length.ToString());
        //Response.ContentEncoding = System.Text.Encoding.Default;
        context.Response.BinaryWrite(content);
        context.Response.Flush();
        context.Response.Close();
        context.Response.End();
    }
}