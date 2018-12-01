using System;
using System.Data;
using System.Collections;

namespace NPOL
{
    public class prServices
    {
        private string ConString = "";
        public prServices(string constring)
        {
            ConString = constring;
        }

        public String getDep_Display(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select DepID = '[' + DepID + '] ' + DepName from tblRef_Department where Depid = @id";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["DepID"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getPos_Display(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select [PosID]='[' + PosID + '] ' + PosName from tblRef_Position where Posid = @id";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["PosID"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getLocation_Display(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select [LocationID]='[' + LocationID + '] ' + LocationName from tblRef_Location where Locationid = @id";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["LocationID"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getRemark_Requester(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select Remarks from tblRC_ChangeRequest where RequestID = @id AND (LevelID=1 OR (LevelID = 2 AND ManagerID not in (SELECT [ManagerID] FROM [dbo].[tbl_RCManager_Open] WHERE [Type] = 'F'))) ORDER BY ID DESC;";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["Remarks"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getRemark_CB(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select Remarks from tblRC_ChangeRequest where RequestID = @id AND LevelID=2 AND ManagerID in (SELECT [ManagerID] FROM [dbo].[tbl_RCManager_Open] WHERE [Type] = 'F')";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["Remarks"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getRemark_HR(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select Remarks from tblRC_ChangeRequest where RequestID = @id AND LevelID=3";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["Remarks"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public String getRemark_CEO(object id)
        {
            String value = "";
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select Remarks from tblRC_ChangeRequest where RequestID = @id AND LevelID=4";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["Remarks"].ToString();
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public bool CheckExists_GroupDep(object groupname)
        {
            bool value = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select * from tblGroupDepSelected Where GroupName like @GroupName";
                provider.ParameterCollection = new string[] { "@GroupName" };
                provider.ValueCollection = new object[] { groupname };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    value = true;
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public int Save_GroupDep(object groupname)
        {
            int value = 0;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "INSERT INTO tblGroupDepSelected VALUES(@GroupName)";
                provider.ParameterCollection = new string[] { "@GroupName" };
                provider.ValueCollection = new object[] { groupname };
                provider.ExecuteNonQuery();

                provider.CommandText = "Select top 1 GroupID from tblGroupDepSelected Where GroupName like @GroupName";
                value = (int)provider.ExecuteScalar();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public bool Save_SelectedDep(object depid, object managerid, object groupid, object status )
        {
            bool value = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "spRC_SelectedDep_Save";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@DepID", "@ManagerID", "@GroupID", "@Status" };
                provider.ValueCollection = new object[] { depid, managerid, groupid, status };
                int result = (int)provider.ExecuteNonQuery();
                if (result > 0)
                {
                    value = true;
                }
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return value;
        }

        public DataTable getDescription_Requester(object id)
        {
            DataTable dt = null;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select * from tblRC_ChangeRequest where RequestID = @id AND (LevelID=1 OR (LevelID = 2 AND ManagerID not in (SELECT [ManagerID] FROM [dbo].[tbl_RCManager_Open] WHERE [Type] = 'F'))) ORDER BY ID DESC;";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                dt = provider.GetDataTable();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

        public DataTable getDescription_HR(object id)
        {
            DataTable dt = null;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select * from tblRC_ChangeRequest where RequestID = @id AND (LevelID=3 OR LevelID=4 OR (LevelID = 2 AND ManagerID in (SELECT [ManagerID] FROM [dbo].[tbl_RCManager_Open] WHERE [Type] = 'F'))) ORDER BY ID DESC;";
                provider.ParameterCollection = new string[] { "@id" };
                provider.ValueCollection = new object[] { id };
                dt = provider.GetDataTable();
                provider.CloseConnection();
            }
            catch (Exception ex)
            {
            }
            return dt;
        }

    }
}