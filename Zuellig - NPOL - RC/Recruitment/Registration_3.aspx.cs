using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using conn = System.Web.Configuration;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;

namespace NPOL
{
    public partial class Registration_Promotion3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Page
            if (Session["EmployeeID"] == null || Session["Role"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else
            {
            }

            //Nạp dữ liệu chế độ nghỉ khi mở trang
            if (!IsPostBack)
            {

            }

            // hide phan thong tin dieu chinh
            txtBasicSal_new.Visible = chk1_3.Checked;
            txtTransAllow_new.Visible = chk1_5.Checked;
            txtOtherAllow_new.Visible = chk1_5.Checked;
            ddl_Dep.Visible = chk1_2.Checked;
            ddl_Line.Visible = chk1_2.Checked;
            ddl_Location.Visible = chk1_4.Checked;
            ddl_Pos.Visible = chk1_6.Checked;
            txtOther_new.Visible = chk1_7.Checked;
            TextBox5.Visible = chk1_7.Checked;

            Session["LineID"] = ddl_Line.Text.Split(']')[0].Trim('[');
            ddl_Dep.DataBind();
        }

        #region Validate
        protected void vThongBao_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            try
            {
            }
            catch (Exception ex)
            {
                //Phải set true để lưới không bị bắt validate
                args.IsValid = true;
            }
        }
        #endregion

        #region Button click
        protected void btnSaveTemp_Click(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {

        }

        protected void btnNhapLai_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region // AutoPostBack events
        protected void ddl_Line_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_Dep.Text = "";
        }
        #endregion
    }
}