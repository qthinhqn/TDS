using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Export;
using DevExpress.XtraPrinting;
using DevExpress.Web;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;

namespace NPOL.UserControl
{
    public partial class uc_NewsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridLookup.GridView.Width = 500;
            LoadSubmitList();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ASPxGridView1_SelectionChanged(gv_Submit, e);

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
                gv_Submit.Selection.UnselectAll();
                gv_Submit.DataBind();
            }
            else
            {

            }
            //catch (Exception ex)
            //{
            //    string message = "alert('" + ex.Message + "')";
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            //}
        }
        
        static List<object> selectedRows = new List<object>();
        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;
            selectedRows.Clear();
            selectedRows = grid.GetSelectedFieldValues(new string[] { "Path", "SubmitFile" });
        }

        protected void ASPxGridView1_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            try
            {
                object isAttach = e.GetFieldValue("IsAttach");
                if (e.Column.Name == "Approval")
                {
                    if((bool)isAttach)
                    {
                        e.DisplayText = "Att";
                    }
                    else
                    {
                        e.DisplayText = "";
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {
            try
            {
                object id = e.KeyValue;
                ASPxGridView grid = sender as ASPxGridView;
                object status = grid.GetRowValuesByKeyValue(id, "Status");

                switch (status.ToString())
                {
                    case "W":
                        e.Cell.BackColor = System.Drawing.Color.White;
                        break;
                    case "A":
                        e.Cell.BackColor = System.Drawing.Color.LightGreen;
                        break;
                    case "L":
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        e.Cell.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "C":
                        e.Cell.BackColor = System.Drawing.Color.Gray;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                object id = e.Keys[0];
                tbl_SubmitNews obj = new tbl_SubmitNews();
                //obj.updateSubmitNews(id, "C", "");
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_CustomButtonCallback(object sender, ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            try
            {
                switch (e.ButtonID)
                {
                    // Download file attach
                    case "Download":
                        string path = gv_Submit.GetRowValues(e.VisibleIndex, "Path").ToString();
                        string filename = gv_Submit.GetRowValues(e.VisibleIndex, "SubmitFile").ToString();
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

        protected void GridLookup_ValueChanged(object sender, EventArgs e)
        {
            //reload list submit
            LoadSubmitList();
        }

        private void LoadSubmitList()
        {
            try
            {
                int newsid = int.Parse(GridLookup.Value.ToString());
                gv_Submit.DataSource = NPOL.App_Code.Business.SubmitNewsService.GetTableByNewsid(newsid);
                gv_Submit.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
}