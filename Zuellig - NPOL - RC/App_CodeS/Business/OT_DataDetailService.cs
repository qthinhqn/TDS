using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace NPOL.App_Code.Business
{
    public class OT_DataDetailService : System.Web.UI.Page
    {
        public OT_DataDetailService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataTable GetTableByid(int RegID)
        {
            OT_DataDetailDAO newsDAO = new OT_DataDetailDAO();
            return newsDAO.GetTableByid("spOT_GetDataDetail", "Reg", RegID);
        }
    }
}