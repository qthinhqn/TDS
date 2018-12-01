using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class ViewEmployeeKPI : System.Web.UI.Page
    {
        //private string employeeid;
        //private int periodid;
        //public string EmployeeID
        //{
        //    get
        //    {
        //        return employeeid;
        //    }
        //    set
        //    {
        //        employeeid = value;
        //    }
        //}
        //public int Period_ID
        //{
        //    get
        //    {
        //        return periodid;
        //    }
        //    set
        //    {
        //        periodid = value;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            string employeeid = Session["EmpID"].ToString();
            int periodid = int.Parse(Session["PerID"].ToString());
            if(!IsPostBack)
            {

            }
            uc_rptEmpKPI.EmployeeID = employeeid;
            uc_rptEmpKPI.Period_ID = periodid;
            uc_rptEmpKPI.ReloadControl();
        }
    }
}