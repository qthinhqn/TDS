using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Entities;
using NPOL.App_Code.Business;
using DevExpress.Web;
using System.Collections;

namespace NPOL.UserControl
{
    public partial class ucKPIReview_Comment : System.Web.UI.UserControl
    {
        private Competency_KPIService service = new Competency_KPIService();
        private tbl_Competency_KPI obj = new tbl_Competency_KPI();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PeriodID"] = 1;
            //Session["EmployeeID"] = "HR021";
            if (!IsPostBack)
            {
                // Load data
                LoadData();

                #region #Kiem tra het han danh gia
                int period = int.Parse(Session["PeriodID"].ToString());
                string EmployeeID = Session["EmployeeIDReview"].ToString();
                ArrayList arrayList = Employee_KPILevelService.GetAllManager_KPILevel(EmployeeID);
                tbl_KPI_Period objKPI = (new KPI_PeriodService()).GetObjectById(period);
                MemoNote.ReadOnly = true;
                switch (arrayList.Count)
                {
                    case 1:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper()
                            && DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                        {
                            // cho edit
                        }
                        else
                        {
                            // khong cho edit
                            MemoNote.ReadOnly = true;
                        }
                        break;
                    case 2:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                MemoNote.ReadOnly = true;
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[1].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.EndTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                MemoNote.ReadOnly = true;
                            }
                        }
                        else
                        {
                            // khong cho edit
                            MemoNote.ReadOnly = true;
                        }
                        break;
                    case 3:
                        if (Session["EmployeeID"].ToString().ToUpper() == arrayList[0].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ReviewTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                MemoNote.ReadOnly = true;
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[1].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime_First && DateTime.Now < objKPI.ApprovalTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                MemoNote.ReadOnly = true;
                            }
                        }
                        else if (Session["EmployeeID"].ToString().ToUpper() == arrayList[2].ToString().ToUpper())
                        {
                            if (DateTime.Now >= objKPI.ReviewTime && DateTime.Now < objKPI.EndTime)
                            {
                                // cho edit
                            }
                            else
                            {
                                // khong cho edit
                                MemoNote.ReadOnly = true;
                            }
                        }
                        else
                        {
                            // khong cho edit
                            MemoNote.ReadOnly = true;
                        }
                        break;
                    default:
                        break;
                }
                #endregion
            }

        }
        private void LoadData()
        {
            try
            {
                obj = service.GetObjectByEmpId(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodIDReview"].ToString()));
                HiddenField1.Value = obj.ID.ToString();
                MemoNote.Text = obj.Notes;
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
                if (string.Compare(obj.Notes, MemoNote.Text) != 0)
                {
                    obj.Notes = MemoNote.Text;
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