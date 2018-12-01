using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class RefLeaveTypeDAO : BaseDAO
    {
        public DataTable GetLeaveType_ByID(string Procedure_Name, string Table_Name, string leaveid)
        {
            return StoreToTable(Procedure_Name, Table_Name, leaveid);
        }

    }
}