using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NPOL
{
    public class tblEmpManagerNews
    {
        private string ConString = "";
        public tblEmpManagerNews(string constring)
        {
            ConString = constring;
        }

        public object getManagerID(object EmployeeID)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID from tblEmpManagerNews where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["ManagerID"];
            }
            provider.CloseConnection();
            return value;
        }

        public bool IsMakerNews(string EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "Select EmployeeID from tblEmpManagerNews where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = true;
                }
            }
            catch (Exception ex)
            {
            }

            provider.CloseConnection();
            return value;
        }

        public bool IsCheckerNews(string EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "Select ManagerID from tblEmpManagerNews where ManagerID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = true;
                }
            }
            catch (Exception ex)
            {
            }

            provider.CloseConnection();
            return value;
        }
    }
}
