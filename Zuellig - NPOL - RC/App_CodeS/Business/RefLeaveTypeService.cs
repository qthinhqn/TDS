using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class RefLeaveTypeService
    {
        public DataTable GetLeaveType_ByID(string leaveid)
        {
            RefLeaveTypeDAO newsDAO = new RefLeaveTypeDAO();
            return newsDAO.GetLeaveType_ByID("spNPOL_GetLeaveType_ByID", "LeaveType_ByID", leaveid);
        }

    }
}