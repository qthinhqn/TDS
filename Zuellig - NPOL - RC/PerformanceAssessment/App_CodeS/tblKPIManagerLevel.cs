using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAOL
{
    public class tblKPIManagerLevel
    {
        private string ConString = "";
        public tblKPIManagerLevel(string constring)
        {
            ConString = constring;

        }

        public object getManagerID(object EmployeeID, object level)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID_L" + level.ToString() + " from tblKPIManagerLevel where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["ManagerID_L" + level.ToString()];
            }
            provider.CloseConnection();
            return value;
        }

        public ArrayList getManagerList(object EmployeeID)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4 from tblKPIManagerLevel where EmployeeID = @EmpID";
            provider.ParameterCollection = new string[] { "@EmpID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    object tmp = dt.Rows[0]["ManagerID_L" + i.ToString()];
                    if (!tmp.ToString().Equals(""))
                    {
                        arr.Add(tmp);
                    }
                }
            }
            provider.CloseConnection();
            return arr;
        }

        public ArrayList getManagerLevelList(object EmployeeID)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4 from tblKPIManagerLevel where EmployeeID = @EmpID";
            provider.ParameterCollection = new string[] { "@EmpID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    object tmp = dt.Rows[0]["ManagerID_L" + i.ToString()];
                    if (!tmp.ToString().Equals(""))
                    {
                        arr.Add(i);
                    }
                }
            }
            provider.CloseConnection();
            return arr;
        }
    }
}
