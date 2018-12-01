using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Employee_KPILevelDAO : BaseDAO
    {
        public DataTable GetAllEmployee_KPILevel(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public ArrayList GetAllManager_KPILevel(string EmpID)
        {
            ArrayList arrayList = new ArrayList();
            
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT Distinct ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4 FROM tblKPIManagerLevel WHERE EmployeeID = @EmpID;", connection);
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(new SqlParameter("@EmpID", EmpID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            if (!string.IsNullOrEmpty(reader["ManagerID_L1"].ToString()))
                                arrayList.Add(reader["ManagerID_L1"].ToString());
                            if (!string.IsNullOrEmpty(reader["ManagerID_L2"].ToString()))
                                arrayList.Add(reader["ManagerID_L2"].ToString());
                            if (!string.IsNullOrEmpty(reader["ManagerID_L3"].ToString()))
                                arrayList.Add(reader["ManagerID_L3"].ToString());
                            if (!string.IsNullOrEmpty(reader["ManagerID_L4"].ToString()))
                                arrayList.Add(reader["ManagerID_L4"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return arrayList;
        }
    }
}