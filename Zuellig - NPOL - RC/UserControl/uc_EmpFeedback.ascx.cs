using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_EmpFeedback : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string empID = Session["EmployeeID"].ToString();
                GridView1.DataSource = NPOL.App_Code.Business.EmpFeedbackService.GetInfoByEmpID(empID);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_EmpFeedback obj = new tbl_EmpFeedback();
                obj.Content = message.Value.ToString();
                obj.EmpID = Session["EmployeeID"].ToString();
                obj.CreateDate = DateTime.Now;
                EmpFeedbackService.CreateNews(obj);
                message.Value = "";
                Page_Load(null, null);
            }
            catch(Exception ex)
            { }
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

    }
}