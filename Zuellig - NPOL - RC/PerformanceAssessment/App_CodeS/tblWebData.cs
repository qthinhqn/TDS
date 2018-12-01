using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace PAOL
{
    public class tblWebData
    {
        private string ConString = "";
        public tblWebData(string constring)
        {
            ConString = constring;
        }

        public object getCheckNum(object id)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select CheckNum from tblWebdata where id = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["CheckNum"];
            }
            provider.CloseConnection();
            return value;
        }

        public object getCurrentLevel(object id, object managerid)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblWebdata where id = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (string.Compare(managerid.ToString(), dt.Rows[0]["ManagerID_L" + (i + 1).ToString()].ToString(), true) == 0)
                    {
                        value = i + 1;
                        break;
                    }
                }
            }
            provider.CloseConnection();
            return value;
        }

        public ArrayList getLevelValues(object id)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblWebdata where id = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
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

        public bool isFirstLevel(object id, object currentLevel)
        {
            bool value = false;
            ArrayList arr = new ArrayList();
            arr = getLevelValues(id);
            object count = getCheckNum(id);
            if (!count.ToString().Equals(""))
            {
                if (Convert.ToInt32(count) > 1)
                {
                    if (string.Compare(arr[0].ToString(), currentLevel.ToString(), true) == 0)
                    {
                        value = true;
                    }
                }
            }
            return value;
        }

        public bool isFirstLastLevel(object id, object currentLevel)
        {
            bool value = false;
            ArrayList arr = new ArrayList();
            arr = getLevelValues(id);
            object count = getCheckNum(id);
            if (!count.ToString().Equals(""))
            {
                if (Convert.ToInt32(count) == 1)
                {
                    if (string.Compare(arr[0].ToString(), currentLevel.ToString(), true) == 0)
                    {
                        value = true;
                    }
                }
            }
            return value;
        }

        public bool isLastLevel(object id, object currentLevel)
        {
            bool value = false;
            try
            {
                ArrayList arr = new ArrayList();
                arr = getLevelValues(id);
                if (Convert.ToInt32(currentLevel) == arr.Count)
                {
                    value = true;
                }
                //object count = getCheckNum(id);
                //if (!count.ToString().Equals(""))
                //{
                //    if (Convert.ToInt32(count) > 1)
                //    {
                //        if (string.Compare(arr[Convert.ToInt32(count) - 1].ToString(), currentLevel.ToString(), true) == 0)
                //        {
                //            value = true;
                //        }
                //    }
                //}
            }
            catch (Exception ex) { }
            return value;
        }

        public object getNextLevel(object id, object currentLevel)
        {
            object value = null;
            ArrayList arr = new ArrayList();
            arr = getLevelValues(id);
            int count = Convert.ToInt32(getCheckNum(id));
            if (!currentLevel.ToString().Equals(""))
            {
                for (int i = 0; i < count; i++)
                {
                    object tmp = arr[i];
                    if (string.Compare(tmp.ToString(), currentLevel.ToString(), true) == 0)
                    {
                        value = arr[i + 1];
                        break;
                    }
                }
            }
            return value;
        }

        public object getPrevLevel(object id, object currentLevel)
        {
            object value = null;
            ArrayList arr = new ArrayList();
            arr = getLevelValues(id);
            int count = Convert.ToInt32(getCheckNum(id));
            if (!currentLevel.ToString().Equals(""))
            {
                for (int i = 0; i < count; i++)
                {
                    object tmp = arr[i];
                    if (string.Compare(tmp.ToString(), currentLevel.ToString(), true) == 0)
                    {
                        value = arr[i - 1];
                        break;
                    }
                }
            }
            return value;
        }

        public bool ApproveFirst(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            object nextLevel = getNextLevel(id, level);
            string sql = "Update tblwebdata set ApprovingDate_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 1, ";
            sql += "MailToL" + level.ToString() + " = 0, MailToL" + nextLevel.ToString() + " = 1, ApprovingReason_L" + level.ToString() + " = @note where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            setHRView(id, "b");
            provider.CloseConnection();
            return value;
        }

        public bool ApproveLast(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            string sql = "Update tblwebdata set ApprovingDate_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 1, ";
            sql += "ApprovingReason_L" + level.ToString() + " = @note, MailToL" + level.ToString() + " = 0, MailToUser = 1, FinalDate = getdate(), FinalStatus = 'a' where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }
            setHRView(id, "a");
            provider.CloseConnection();
            return value;
        }

        public bool CancelApproval(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            string sql = "Update tblwebdata set ApprovingDate_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 0, ";
            sql += "MailToL" + level.ToString() + " = 0, ";
            sql += "ApprovingReason_L" + level.ToString() + " = @note, FinalStatus = 'c', MailToUser = 1 where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            setHRView(id, "d");

            provider.CloseConnection();
            return value;
        }

        public bool AllowUpdate(object id, object currentLevel)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            if (isFirstLastLevel(id, currentLevel) || isLastLevel(id, currentLevel))
            {
                provider.CommandText = "Select HRCheckingStatus from tblwebdata where ID = @id";
                provider.ParameterCollection = new string[] {"@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    object hrStatus = dt.Rows[0]["HRCheckingStatus"];
                    if (hrStatus.ToString().Equals(""))
                    {
                        value = true;
                    }
                }
            }
            else
            {
                object nextLevel = getNextLevel(id, currentLevel);
                provider.CommandText = "Select ApprovingStatus_L" + nextLevel.ToString() + " from tblwebdata where ID = @id";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    object nextStatus = dt.Rows[0]["ApprovingStatus_L" + nextLevel.ToString()];
                    if (nextStatus.ToString().Equals(""))
                    {
                        value = true;
                    }
                }
            }
            provider.CloseConnection();
            return value;
        }

        public void setHRView(object id, object value)
        {
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Update tblWebdata set HRview = @value where ID = @id";
            provider.ParameterCollection = new string[] { "@value", "@id" };
            provider.ValueCollection = new object[] { value, id };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        public bool HRSync(object id, object empid, object leaveid, object pertimeid, object frmdate, object todate, object frmtime, object totime, object regdate, object days)
        {
            bool value = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                /*
                provider.CommandText = "Update tblWebdata set HRCheckingStatus = 1, HRview = 'c', HRCheckingDate = getdate() where ID = @id";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                provider.ExecuteNonQuery();

                //Transfer to HRM
                provider.CommandText = "Insert into tblEmpDayOff (KeyID, EmployeeID, FromDate, PerTimeID, ToDate, Days, LeaveID, FromTime, ToTime, RegistedDate) values( [dbo].[fn_GetMaxID_tblEmpDayOff] () + 1 , @EmployeeID, @FromDate, @PerTimeID, @ToDate, @Days, @LeaveID, @FromTime, @ToTime, @RegistedDate)";
                provider.ParameterCollection = new string[] { "@EmployeeID", "@FromDate", "@PerTimeID", "@ToDate", "@Days", "@LeaveID", "@FromTime", "@ToTime", "@RegistedDate" };
                provider.ValueCollection = new object[] { empid, frmdate, pertimeid, todate, days, leaveid, frmtime, totime, regdate };
                
                */
                provider.CommandText = "sp_HRSync";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@id", "@EmployeeID", "@FromDate", "@PerTimeID", "@ToDate", "@Days", "@LeaveID", "@FromTime", "@ToTime", "@RegistedDate" };
                provider.ValueCollection = new object[] { id, empid, frmdate, pertimeid, todate, days, leaveid, DBNull.Value, DBNull.Value, regdate };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                    value = true;
                provider.CloseConnection();
            }
            catch (Exception ex)
            { }
            return value;
        }

        public bool HRCancel(object id, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Update tblWebdata set HRCheckingStatus = 0, HRview = 'd', HRCheckingDate = getdate(), HRCheckingReason = @reason, FinalStatus = 'c', FinalDate = getdate() where ID = @id";
            provider.ParameterCollection = new string[] { "@reason", "@id" };
            provider.ValueCollection = new object[] { reason, id };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
                value = true;
            provider.CloseConnection();
            return value;
        }

        public object getFinalStatusByID(object ID)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select FinalStatus from tblWebdata where ID = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { ID };
            if (provider.GetDataTable().Rows.Count > 0)
            {
                value = provider.GetDataTable().Rows[0]["FinalStatus"];
            }
            provider.CloseConnection();
            return value;
        }
        /*
        public DataTable GetLeaveData(bool Type)
        {
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                if (!Type)
                    provider.CommandText =
                        "SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.LineName, dbo.tblEmployee.PosName, "
+ " dbo.tblRef_LeaveType.LeaveType, dbo.tblPerTime.PerTimeName, dbo.tblWebData.LeaveReason, dbo.tblWebData.StartDate, "
+ " dbo.tblWebData.ToDate, dbo.tblWebData.TotalDays, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.TotalHours, "
+ " dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.FinalDate, "
+ " dbo.tblWebData.FinalStatus, dbo.tblWebData.HRview, dbo.tblEmployee.SalaryTypeName, dbo.tblWebData.EmployeeID, "
+ " dbo.tblWebData.LeaveID, dbo.tblWebData.PerTimeID "
+ " FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblPerTime "
    + " ON dbo.tblWebData.PerTimeID = dbo.tblPerTime.PerTimeID "
    + " LEFT OUTER JOIN dbo.tblRef_LeaveType "
    + " ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID "
    + " LEFT OUTER JOIN dbo.tblEmployee "
    + " ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID "
+ " WHERE dbo.tblWebData.HRCheckingStatus is null And dbo.tblWebData.FinalStatus not like 'c' "
+ " ORDER BY dbo.tblWebData.HRview";
                else
                    provider.CommandText =
                        "SELECT dbo.tblWebData.ID, dbo.tblEmployee.EmployeeName, dbo.tblEmployee.LineName, dbo.tblEmployee.PosName, "
+ " dbo.tblRef_LeaveType.LeaveType, dbo.tblPerTime.PerTimeName, dbo.tblWebData.LeaveReason, dbo.tblWebData.StartDate, "
+ " dbo.tblWebData.ToDate, dbo.tblWebData.TotalDays, dbo.tblWebData.FromTime, dbo.tblWebData.ToTime, dbo.tblWebData.TotalHours, "
+ " dbo.tblWebData.HRCheckingDate, dbo.tblWebData.HRCheckingReason, dbo.tblWebData.HRCheckingStatus, dbo.tblWebData.FinalDate, "
+ " dbo.tblWebData.FinalStatus, dbo.tblWebData.HRview, dbo.tblEmployee.SalaryTypeName, dbo.tblWebData.EmployeeID, "
+ " dbo.tblWebData.LeaveID, dbo.tblWebData.PerTimeID "
+ " FROM dbo.tblWebData LEFT OUTER JOIN dbo.tblPerTime "
    + " ON dbo.tblWebData.PerTimeID = dbo.tblPerTime.PerTimeID "
    + " LEFT OUTER JOIN dbo.tblRef_LeaveType "
    + " ON dbo.tblWebData.LeaveID = dbo.tblRef_LeaveType.LeaveID "
    + " LEFT OUTER JOIN dbo.tblEmployee "
    + " ON dbo.tblWebData.EmployeeID = dbo.tblEmployee.EmployeeID "
+ " WHERE dbo.tblWebData.HRCheckingStatus is not null OR "
+ " ( dbo.tblWebData.HRCheckingStatus is null And dbo.tblWebData.FinalStatus like 'c' )"
+ " ORDER BY dbo.tblWebData.HRview";
                DataTable dt = provider.GetDataTable();
                provider.CloseConnection();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        */
        public DataTable GetLeaveData(bool Type)
        {
            DataTable dt = null;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@Type" };
                provider.ValueCollection = new object[] { Type };
                dt = provider.GetDataTable();


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

            return dt;
        }

    }
}