using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace NPOL
{
    public class tblRecruitData
    {
        private string ConString = "";
        public tblRecruitData(string constring)
        {
            ConString = constring;
        }

        public object getCheckNum(object id)
        {
            object value = 3;
            //khSqlServerProvider provider = new khSqlServerProvider(ConString);
            //provider.CommandText = "Select CheckNum from tblOTdata where id = @id";
            //provider.ParameterCollection = new string[] { "@id" };
            //provider.ValueCollection = new object[] { id };
            //DataTable dt = provider.GetDataTable();
            //if (dt.Rows.Count > 0)
            //{
            //    value = dt.Rows[0]["CheckNum"];
            //}
            //provider.CloseConnection();
            return value;
        }

        public object getCurrentLevel(object id, object managerid)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "sp_GetRecruitDataByID";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (string.Compare(managerid.ToString().ToUpper(), dt.Rows[0]["ManagerID_L" + (i + 1).ToString()].ToString().ToUpper(), true) == 0)
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
            provider.CommandText = "sp_GetRecruitDataByID";
            provider.CommandType = CommandType.StoredProcedure;
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
                        value = (int)arr[i] + 1;
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

        public bool ApproveFirst(object id, object manager, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            //object nextLevel = getNextLevel(id, level);
            string sql = "spRecruit_Approval";
            provider.CommandText = sql;
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id", "@ManagerID", "@Level", "@ApprovalStatus", "@Note", "@IsFinal" };
            provider.ValueCollection = new object[] { id, manager, level, true, reason, false };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            setHRView(id, "b");
            provider.CloseConnection();
            return value;
        }

        public bool ApproveLast(object id, object manager, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            string sql = "spRecruit_Approval";
            provider.CommandText = sql;
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id", "@ManagerID", "@Level", "@ApprovalStatus", "@Note", "@IsFinal" };
            provider.ValueCollection = new object[] { id, manager, level, true, reason, true };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }
            setHRView(id, "a");
            provider.CloseConnection();
            return value;
        }

        public bool CancelApproval(object id, object manager, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            string sql = "spRecruit_Approval";
            provider.CommandText = sql;
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id", "@ManagerID", "@Level", "@ApprovalStatus", "@Note", "@IsFinal" };
            provider.ValueCollection = new object[] { id, manager, level, false, reason, true };
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
            // 
            return true;
            /*
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            {
                object nextLevel = getNextLevel(id, currentLevel);
                provider.CommandText = "Select * from tblRecruitApproval_Detail Where RegID = @id And LevelNo = @Level";
                provider.ParameterCollection = new string[] { "@id", "@Level" };
                provider.ValueCollection = new object[] { id, nextLevel };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    object nextStatus = dt.Rows[0]["ApprovingStatus_L" + nextLevel.ToString()];
                    if (nextStatus.ToString().Equals("") || nextStatus.ToString().Equals("w"))
                    {
                        value = true;
                    }
                }
                else
                {
                    value = true;
                }
            }
            provider.CloseConnection();
            return value;
            */
        }

        public void setHRView(object id, object value)
        {
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "";
            provider.ParameterCollection = new string[] { "@value", "@id" };
            provider.ValueCollection = new object[] { value, id };
            //provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        public bool HRSync(object id)
        {
            bool value = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);

                provider.CommandText = "sp_HRSyncRecruit";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@RequestID" };
                provider.ValueCollection = new object[] { id };
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
            provider.CommandText = "sp_HRSyncRecruitDetail";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@RequestID", "@Reason", "@Status" };
            provider.ValueCollection = new object[] { id, reason, false };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
                value = true;
            provider.CloseConnection();
            return value;
        }

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

        public object getFinalStatusByID(object ID)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select FinalStatus from tblCand_Request_Online where RequestID = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { ID };
            if (provider.GetDataTable().Rows.Count > 0)
            {
                value = provider.GetDataTable().Rows[0]["FinalStatus"];
            }
            provider.CloseConnection();
            return value;
        }

        public ArrayList getManagerLevel(object id)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "sp_GetRecruitDataByID";
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    object tmp = dt.Rows[0]["ManagerID_L" + i.ToString()];
                    arr.Add(tmp.ToString());
                }
            }
            provider.CloseConnection();
            return arr;
        }

        public int GetLevel(object id, object currentLevel)
        {
            int value = -1;
            ArrayList arr = new ArrayList();
            arr = getManagerLevel(id);
            foreach (var item in arr)
            {
                if (string.Compare(item.ToString(), currentLevel.ToString(), true) == 0)
                {
                    value = arr.IndexOf(item);
                    break;
                }
            }
            return value;
        }

        public bool Approve_open(object id, object manager, object approval, object reason, object sendToDirector, object curLevel)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            //object nextLevel = getNextLevel(id, approval);
            string sql = "spRecruit_Approval_Open_New";
            provider.CommandText = sql;
            provider.CommandType = CommandType.StoredProcedure;
            provider.ParameterCollection = new string[] { "@id", "@ManagerID", "@ApprovalStatus", "@Note", "@SendToDirector", "@iLevel"};
            provider.ValueCollection = new object[] { id, manager, approval, reason, sendToDirector, curLevel };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            setHRView(id, "b");
            provider.CloseConnection();
            return value;
        }

        public bool isHRRecruitment(string EmployeeID)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            {
                provider.CommandText = "Select * from tbl_RCManager_Open Where ManagerID = @EmployeeID And Type='A' AND Status = 0";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = true;
                }
            }
            provider.CloseConnection();
            return value;
        }

        public DataTable GetTablePayGroupReviewByid(string id)
        {
            DataTable dt = null;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "SELECT [ID],[ManagerID],[ManagerName]=(SELECT [ManagerName] FROM tbl_RCManager_Open WHERE [ID]=A.[ManagerID]),[PayGroup],[Status] FROM [dbo].[tbl_PayGroupReview] A WHERE ManagerID=@ManagerID ORDER BY [PayGroup]";
                provider.ParameterCollection = new string[] { "@ManagerID" };
                provider.ValueCollection = new object[] { id };
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