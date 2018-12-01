﻿using System;
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
    public partial class ucKPI_ManageComment : System.Web.UI.UserControl
    {
        private Competency_KPIService service_note = new Competency_KPIService();
        private tbl_Competency_KPI obj_note = new tbl_Competency_KPI();

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
                    ASPxMemo1.ReadOnly = true;
                }
            }

        }
        private void LoadData()
        {
            try
            {
                obj_note = service_note.GetObjectByEmpId(Session["EmployeeIDReview"].ToString(), int.Parse(Session["PeriodIDReview"].ToString()));
                HiddenField2.Value = obj_note.ID.ToString();
                ASPxMemo1.Text = obj_note.Notes;
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
                if (string.Compare(obj_note.Notes, ASPxMemo1.Text) != 0)
                {
                    obj_note.Notes = ASPxMemo1.Text;
                    obj_note.ID = int.Parse(HiddenField2.Value);
                    service_note.UpdateNotes(obj_note);
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