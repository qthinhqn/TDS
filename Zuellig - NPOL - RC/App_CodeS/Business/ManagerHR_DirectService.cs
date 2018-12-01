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
    public class ManagerHR_DirectService : System.Web.UI.Page
    {
        public ManagerHR_DirectService()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static List<tblRef_Department> GetListByID(string groupCode)
        {
            ManagerHR_DirectDAO newsDAO = new ManagerHR_DirectDAO();
            return newsDAO.GetListByID("spRC_GetDivision", "@RepresentativeID", groupCode);

        }

        public DataTable GetTableByid(string groupCode, string managerID)
        {
            ManagerHR_DirectDAO newsDAO = new ManagerHR_DirectDAO();
            return newsDAO.GetTableByid("spRC_GetDivision", "DepartmentInGroup", groupCode, managerID);
        }
    }
}