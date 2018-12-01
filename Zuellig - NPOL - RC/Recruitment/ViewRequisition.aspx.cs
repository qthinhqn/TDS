using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL
{
    public partial class ViewRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string requestID = Session["RequestID"].ToString();
            if(!IsPostBack)
            {

            }
            uc_rptEmpRequisition.RequestID = requestID;
            uc_rptEmpRequisition.ReloadControl();
        }
    }
}