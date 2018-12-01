using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Internal;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{

    public class GridViewFeaturesHelper
    {
        public static void SetupGlobalGridViewBehavior(ASPxGridView gridView)
        {
            if (gridView == null)
                return;
            gridView.EnablePagingGestures = AutoBoolean.False;
            gridView.SettingsPager.EnableAdaptivity = true;
            gridView.Styles.Header.Wrap = DefaultBoolean.True;
            if (InjectGridNoWrapGroupPanelCssStyle(gridView.Page))
                gridView.Styles.GroupPanel.CssClass = "GridNoWrapGroupPanel";
        }
        static bool InjectGridNoWrapGroupPanelCssStyle(Page page)
        {
            HtmlHead header = (page != null && page.Header != null) ? page.Header : RenderUtils.FindHead(page);
            if (header != null)
            {
                header.Controls.Add(new LiteralControl()
                {
                    Text = "\r\n<style>.GridNoWrapGroupPanel td.dx-wrap { white-space: nowrap !important; }</style>\r\n"
                });
                return true;
            }
            return false;
        }
    }

    public partial class uc_ManagerHR_Director : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewFeaturesHelper.SetupGlobalGridViewBehavior(gridManagerHR_Direct);

            if (!string.IsNullOrEmpty(Request.Params["KPI_ID"]))
            {
                Session["KPI_ID"] = Request.Params["KPI_ID"];
            }
            try
            {
                if (Session["Role"] != "PA_Admin")
                {
                    object refUrl = ViewState["RefUrl"];
                    if (refUrl != null)
                        Response.Redirect((string)refUrl);
                }
            }
            catch (Exception ex)
            {
            
            }
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

        }

        protected void gvTrainLine_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
        }

        protected void gridKPIList_SelectionChanged(object sender, EventArgs e)
        {
            ASPxGridView grid = sender as ASPxGridView;
            selectedKPI.Clear();
            selectedKPI = grid.GetSelectedFieldValues(new string[] { "ID" });
            Session["KPI_ID"] = selectedKPI[0];
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

        protected void btnView_Click(object sender, EventArgs e)
        {
            ASPxButton bt = sender as ASPxButton;
            GridViewDataItemTemplateContainer container = bt.NamingContainer as GridViewDataItemTemplateContainer;
            ASPxGridView grid = container.Grid;
            object _pid = grid.GetRowValues(container.VisibleIndex, new string[] { "ID" });
            object _empID = grid.GetRowValues(container.VisibleIndex, new string[] { "ManagerID" });
            hdfManagerID.Value = _pid.ToString();

            //Xử lý giá trị biến
            _pid = (_pid == null ? DBNull.Value : _pid);

            //Gán dữ liệu vào Popup control
            ASPxPopupControl1.ShowOnPageLoad = true;
            string ketnoi = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
            tblRecruitData obj = new tblRecruitData(ketnoi);
            //gridManagerHR_Direct.DataSource = obj.GetTablePayGroupReviewByid(_pid.ToString());
            Khuong kh = new Khuong(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            ASPxPopupControl1.HeaderText = "Nhóm quản lý theo nhân sự tuyển dụng: " + kh.getEmployeeName(_empID.ToString());
            Session["PayGroupReview_ID"] = _pid;
            gridManagerHR_Direct.DataBind();

        }

        protected void btnView_Init(object sender, EventArgs e)
        {
            try
            {
                ASPxButton button = sender as ASPxButton;
                GridViewDataItemTemplateContainer container = button.NamingContainer as GridViewDataItemTemplateContainer;
                string regType = DataBinder.Eval(container.DataItem, "Type").ToString();
                if (regType != null)
                {
                    if (regType == "A" || regType == "E" || regType == "G" || regType == "H" || regType == "I")
                        button.Visible = true;
                    else
                        button.Visible = false;
                }
                else
                {
                    button.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #region cascading combobox
        protected void grid_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName != "GroupCode") return;
            //if (e.KeyValue == DBNull.Value || e.KeyValue == null) return;
            object val = gridManagerHR_Direct.GetRowValuesByKeyValue(e.KeyValue, "PayGroup");
            if (val == DBNull.Value) return;
            string groupCode = (string)val;

            ASPxComboBox combo = e.Editor as ASPxComboBox;
            FillGroupCombo(combo, groupCode);

            combo.Callback += new CallbackEventHandlerBase(cmbDivision_OnCallback);
        }

        protected void FillGroupCombo(ASPxComboBox cmb, string groupCode)
        {
            if (string.IsNullOrEmpty(groupCode)) return;

            DataTable divisions = GetDivisions(groupCode);
            cmb.DataSource = divisions;
            cmb.DataBind();
        }
        private DataTable GetDivisions(string groupCode)
        {
            ManagerHR_DirectService service = new ManagerHR_DirectService();
            return service.GetTableByid(groupCode, hdfManagerID.Value);
        }

        void cmbDivision_OnCallback(object source, CallbackEventArgsBase e)
        {
            FillGroupCombo(source as ASPxComboBox, e.Parameter);
        }
        #endregion
    }
}