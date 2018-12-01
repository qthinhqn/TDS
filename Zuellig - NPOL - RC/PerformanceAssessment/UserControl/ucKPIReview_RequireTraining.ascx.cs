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
    public partial class ucKPIReview_RequireTraining : System.Web.UI.UserControl
    {
        private KPI_RequireTrainingService service = new KPI_RequireTrainingService();
        private tbl_KPIRequireTraining obj = new tbl_KPIRequireTraining();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeID"] = "HR021";
            if (!IsPostBack)
            {
                // Load data
                LoadData();
                // kiem tra het han danh gia
                int kpiid = KPI_PeriodService.GetKPI_LastActive();
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(kpiid);

                if (DateTime.Now >= objKPI.StartTime && DateTime.Now < objKPI.ReviewTime)
                {
                    // cho edit
                }
                else
                {
                    // khong cho edit
                    MemoNote.ReadOnly = true;
                }
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByEmp(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodIDReview"].ToString()));
                HiddenField1.Value = obj.ID.ToString();
                MemoNote.Text = obj.Detail;
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
                if (string.Compare(obj.Detail, MemoNote.Text) != 0)
                {
                    obj.Detail = MemoNote.Text;
                    obj.ID = int.Parse(HiddenField1.Value);
                    service.UpdateByID(obj);
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