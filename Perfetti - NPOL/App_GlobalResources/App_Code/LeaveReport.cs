using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

using conn = System.Web.Configuration;

namespace NPOL
{
    public class LeaveReport
    {
        public LeaveReport()
        {
            con = "";
            empid = "";
        }
        public LeaveReport(string employeeid, string connectionstring)
        {
            con = connectionstring;
            empid = employeeid;
        }
        string con = null;
        string empid = null;

        public string getEmployeeName()
        {
            string returnValue = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select EmployeeName from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { empid };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = dt.Rows[0]["EmployeeName"].ToString();
            }
            provider.CloseConnection();
            return returnValue;
        }

        public DateTime getEmployedDate()
        {
            DateTime returnValue = new DateTime();
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select EmployedDate from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { empid };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = (DateTime)dt.Rows[0]["EmployedDate"];
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getSeniority()
        {
            float returnValue = 0;

            return returnValue;
        }

        public string getLineName()
        {
            string returnValue = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select LineName from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { empid };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = dt.Rows[0]["LineName"].ToString();
            }
            provider.CloseConnection();
            return returnValue;
        }

        public string getPosName()
        {
            string returnValue = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select PosName from tblEmployee where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { empid };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = dt.Rows[0]["PosName"].ToString();
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getTotalAlInit(int Year)
        {
            float returnValue = 0;
            DateTime frDate = new DateTime(Year - 1, 12, 1);
            DateTime toDate = new DateTime(Year - 1, 12, 31);
            //Gọi stored procedure sp_View_EmpALRemain_Online
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "sp_View_EmpALRemain_Online";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID" };
            provider.ValueCollection = new object[] { frDate, toDate, empid };
            provider.ExecuteNonQuery();

            //Tính toán giá trị phép năm tồn đầu 
            provider.CommandText = "Select * from tbl_View_EmpALRemain_Online where EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@EmployeeID" };
            provider.ValueCollection = new object[] { empid };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                returnValue = (float)dt.Rows[0]["AlRemain"];
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getAL(DateTime frDate, DateTime toDate)
        {
            float returnValue = 0;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select * from tblEmpDayOff where FromDate >= @FromDate and ToDate <= @ToDate and LeaveID = 'AL' and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmployeeID" };
            provider.ValueCollection = new object[] { frDate, toDate, empid };
            DataTable dt = provider.GetDataTable();
            float tempValue = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempValue = (float)dt.Rows[i]["Days"];
                    returnValue = returnValue + tempValue;
                }
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getSL(DateTime frDate, DateTime toDate)
        {
            float returnValue = 0;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select * from tblEmpDayOff where FromDate >= @FromDate and ToDate <= @ToDate and LeaveID = 'SL' and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmployeeID" };
            provider.ValueCollection = new object[] { frDate, toDate, empid };
            DataTable dt = provider.GetDataTable();
            float tempValue = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempValue = (float)dt.Rows[i]["Days"];
                    returnValue = returnValue + tempValue;
                }
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getUP(DateTime frDate, DateTime toDate)
        {
            float returnValue = 0;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select * from tblEmpDayOff where FromDate >= @FromDate and ToDate <= @ToDate and LeaveID = 'UP' and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmployeeID" };
            provider.ValueCollection = new object[] { frDate, toDate, empid };
            DataTable dt = provider.GetDataTable();
            float tempValue = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempValue = (float)dt.Rows[i]["Days"];
                    returnValue = returnValue + tempValue;
                }
            }
            provider.CloseConnection();
            return returnValue;
        }

        public float getUN(DateTime frDate, DateTime toDate)
        {
            float returnValue = 0;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Select * from tblEmpDayOff where FromDate >= @FromDate and ToDate <= @ToDate and LeaveID = 'UN' and EmployeeID = @EmployeeID";
            provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmployeeID" };
            provider.ValueCollection = new object[] { frDate, toDate, empid };
            DataTable dt = provider.GetDataTable();
            float tempValue = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempValue = (float)dt.Rows[i]["Days"];
                    returnValue = returnValue + tempValue;
                }
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool clearData()
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            provider.CommandText = "Delete * from tblWeb_LeaveReport";
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                returnValue = true;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public static DataTable getAllLeaveByManager(string managerID)
        {
            try
            {
                BaseDAO dao = new BaseDAO();
                DataTable dt = dao.StoreToTable("sp_getAllLeaveByManager", "AllLeaveByManager", managerID);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ArrayList getEmpIDListByManager(string ManagerID)
        {
            ArrayList returnList = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(conn.WebConfigurationManager.ConnectionStrings["PERFETTIConnectionString"].ToString());
            DataTable dt;
            string sql = "";
            try
            {
                sql = "Select Distinct EmployeeID from tblEmpManagerLevel Where ManagerID_L1=@ManagerID or ManagerID_L2=@ManagerID or ManagerID_L3=@ManagerID;";
                provider.CommandText = sql;
                provider.ParameterCollection = new string[] { "@ManagerID" };
                provider.ValueCollection = new object[] { ManagerID };
                dt = provider.GetDataTable();

                if (dt != null)
                {
                    for (int i=0; i<dt.Rows.Count; i++)
                        returnList.Add(dt.Rows[i]["EmployeeID"]);
                }
            }
            catch
            {
                returnList = null;
            }
            provider.CloseConnection();
            return returnList;
        }
    }
}