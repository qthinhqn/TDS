using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAOL.App_Code.Entities;
using PAOL.App_Code.Business;
using DevExpress.Web;

namespace PAOL.UserControl
{
    public partial class ucKPI_ManageNote : System.Web.UI.UserControl
    {
        private Competency_KPI_ApprovalService service = new Competency_KPI_ApprovalService();
        private tblCompetency_KPI_Approval obj = new tblCompetency_KPI_Approval();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeIDReview"] = "HR021";
            if (!IsPostBack)
            {
            // Load data
            LoadData();
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByRefId(int.Parse(Session["EmpCompetency_KPI_ID"].ToString()));
                HiddenField1.Value = obj.ID.ToString();
                MemoNote.Text = obj.Note_L1;
            }
            catch { }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // save data
            try
            {
                if (string.Compare(obj.Note_L1, MemoNote.Text) != 0)
                {
                    obj.Note_L1 = MemoNote.Text;
                    obj.ID = int.Parse(HiddenField1.Value);
                    service.UpdateNote_L1(obj);
                }
            }
            catch (Exception ex)
            {

            }

            // Load data
            LoadData();
        }

    }
}