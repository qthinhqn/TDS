using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class FilterByManagerDAO : BaseDAO
    {
        private tblPA_FilterByManager CreateObjectFromReader(IDataReader reader)
        {
            tblPA_FilterByManager news = new tblPA_FilterByManager();
            try
            {
                news.ID = (int)reader["ID"];
                
                if (!(string.IsNullOrEmpty(reader["FilterID"].ToString())))
                    news.FilterID = (string)reader["FilterID"];

                if (!(string.IsNullOrEmpty(reader["ManagerID"].ToString())))
                    news.ManagerID = (string)reader["ManagerID"];

                if (!(string.IsNullOrEmpty(reader["ManagerName"].ToString())))
                    news.ManagerName = (string)reader["ManagerName"];

                if (!(string.IsNullOrEmpty(reader["ParentID"].ToString())))
                    news.ParentID = (string)reader["ParentID"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tblPA_FilterByManager item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spFilterByManagerCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                command.Parameters.Add(new SqlParameter("@ManagerID", item.ManagerID));
                command.Parameters.Add(new SqlParameter("@ManagerName", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@ParentID", item.ParentID));
                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                paramID.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                if (paramID.Value != DBNull.Value)
                    item.ID = (int)paramID.Value;
                else
                    item.ID = 0;
            }
        }
        public bool UpdateByID(tblPA_FilterByManager item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spUpdateFilterByManager", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    //command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                    //command.Parameters.Add(new SqlParameter("@ManagerID", item.ManagerID));
                    //command.Parameters.Add(new SqlParameter("@ManagerName", item.ManagerName));
                    //command.Parameters.Add(new SqlParameter("@ParentID", item.ParentID));
                    //command.Parameters.Add(new SqlParameter("@Status", item.Status));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteFilter(tblPA_FilterByManager news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spFilterByManagerDelete", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", news.ID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteFilterByID(int  ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spDeleteByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", ID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public DataTable GetNewsById(string Procedure_Name, string Table_Name, int newsid)
        {

            return StoreToTable(Procedure_Name, Table_Name, newsid);

        }

        public tblPA_FilterByManager GetFilterMangerById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblPA_FilterByManager news = null;
                try
                {
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                            news = CreateObjectFromReader(reader);
                    }
                }
                catch (Exception ex) { }
                return news;
            }
        }

        public DataTable GetFilterManger(string Procedure_Name, string Table_Name, string manager)
        {
            return StoreToTable(Procedure_Name, Table_Name, manager);
        }
        public void InitGroup(string Procedure_Name, int period, string manager)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", period));
                    command.Parameters.Add(new SqlParameter("@ManagerID", manager));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { }
        }

        public void CleanCheck(int period, string manager)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spCleanFilterByManager", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", period));
                    command.Parameters.Add(new SqlParameter("@ManagerID", manager));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { }
        }
    }
}