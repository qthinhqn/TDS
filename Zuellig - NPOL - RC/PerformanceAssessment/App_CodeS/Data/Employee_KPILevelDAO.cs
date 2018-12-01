using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class Employee_KPILevelDAO : BaseDAO
    {
        public DataTable GetAllEmployee_KPILevel(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }
    }
}