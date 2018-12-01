using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class OT_DataDetailDAO : BaseDAO
    {
        public OT_DataDetailDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetTableByid(string Procedure_Name, string Table_Name, int regid)
        {

            return StoreToTable(Procedure_Name, Table_Name, regid);

        }
    }
}