using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_PercentageRating : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            try
            {
                foreach (var args in e.InsertValues)
                    InsertNewItem(args.NewValues);
                foreach (var args in e.UpdateValues)
                    UpdateItem(args.Keys, args.NewValues);
                foreach (var args in e.DeleteValues)
                    DeleteItem(args.Keys, args.Values);

                e.Handled = true;

                //Thoát chế độ edit
                ASPxGridView1.CancelEdit();

                //Cập nhật lại lưới
                ASPxGridView1.DataBind();
            }
            catch (Exception ex)
            { }
        }

        protected void InsertNewItem(OrderedDictionary newValues)
        {
            try
            {
                Ref_GuidelineService thucthi = new Ref_GuidelineService();
                tblRef_Guideline item = new tblRef_Guideline();

                item.Description = newValues["Description"].ToString();
                item.MinRange = Convert.ToDouble(newValues["MinRange"]);
                item.MaxRange = Convert.ToDouble(newValues["MaxRange"]);
                item.Expectation = newValues["Expectation"].ToString();

                thucthi.CreateNew(item);
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void UpdateItem(OrderedDictionary keys, OrderedDictionary newValues)
        {
            try
            {
                Ref_GuidelineService thucthi = new Ref_GuidelineService();
                tblRef_Guideline item = new tblRef_Guideline();

                item.ID = Convert.ToInt32(keys[0]);
                item.Description = newValues["Description"].ToString();
                item.MinRange = Convert.ToDouble(newValues["MinRange"]);
                item.MaxRange = Convert.ToDouble(newValues["MaxRange"]);
                item.Expectation = newValues["Expectation"].ToString();

                thucthi.UpdateByID(item);
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }

        protected void DeleteItem(OrderedDictionary keys, OrderedDictionary values)
        {
            try
            {
                Ref_GuidelineService thucthi = new Ref_GuidelineService();
                
                int _ID = Convert.ToInt32(keys[0]);
                thucthi.DeleteByID(_ID);
            }
            catch (Exception ex)
            {
                string message = "alert('" + ex.Message + "')";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", message, true);
            }
        }
    }
}