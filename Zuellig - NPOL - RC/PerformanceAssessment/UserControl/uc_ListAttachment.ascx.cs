using PAOL.App_Code.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DevExpress.Web;
using PAOL.App_Code.Business;

namespace PAOL.UserControl
{
    public partial class uc_ListAttachment : System.Web.UI.UserControl
    {
        int newsid = 0;
        static List<object> selectedRows = new List<object>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                gv_Attachment.DataSource = PAOL.App_Code.Business.AttachmentService.GetTable();
                gv_Attachment.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ASPxGridView1_SelectionChanged(gv_Attachment, e);

            //Kiểm tra select checkbox
            if (selectedRows.Count <= 0)
            {
                string message = "alert('Vui lòng chọn file cần tải!')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
                return;
            }

            if (selectedRows.Count == 1)
            {
                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    //object newsID = arr[0];
                    //object empid = arr[1];
                    //object issueDate = arr[2];

                    Utility.Download_A_File(arr[0].ToString(), arr[1].ToString());

                }
            }
            else
            {
                Utility.Download_Multy_Files(selectedRows);
            }

            gv_Attachment.Selection.UnselectAll();
            gv_Attachment.DataBind();
            //catch (Exception ex)
            //{
            //    string message = "alert('" + ex.Message + "')";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            //}
        }

        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            selectedRows.Clear();
            selectedRows = grid.GetSelectedFieldValues(new string[] { "AttachmentPath", "AttachmentName" });
        }

        protected void gv_Attachment_CustomButtonCallback(object sender, DevExpress.Web.ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                switch (e.ButtonID)
                {
                    // Download file attach
                    case "Download":
                        string path = gv_Attachment.GetRowValues(e.VisibleIndex, "AttachmentPath").ToString();
                        string filename = gv_Attachment.GetRowValues(e.VisibleIndex, "AttachmentName").ToString();
                        Utility.Download_A_File(path, filename);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}