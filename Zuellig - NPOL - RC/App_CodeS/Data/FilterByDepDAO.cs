using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class FilterByDepDAO : BaseDAO
    {
        private tblPA_FilterByDep CreateObjectFromReader(IDataReader reader)
        {
            tblPA_FilterByDep news = new tblPA_FilterByDep();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["FilterID"].ToString())))
                    news.FilterID = (string)reader["FilterID"];

                if (!(string.IsNullOrEmpty(reader["DepID"].ToString())))
                    news.DepID = (string)reader["DepID"];

                if (!(string.IsNullOrEmpty(reader["DepName"].ToString())))
                    news.DepName = (string)reader["DepName"];

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
        public void CreateNew(tblPA_FilterByDep item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spFilterByDepCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                command.Parameters.Add(new SqlParameter("@DepID", item.DepID));
                command.Parameters.Add(new SqlParameter("@DepName", DBNull.Value));
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
        public bool UpdateByID(tblPA_FilterByDep item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spUpdateFilterByDep", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    //command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                    //command.Parameters.Add(new SqlParameter("@DepID", item.DepID));
                    //command.Parameters.Add(new SqlParameter("@DepName", item.DepName));
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

        public bool DeleteFilterDep(tblPA_FilterByDep news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spFilterByDepDelete", connection);
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

        public bool DeleteFilterDepByID(int  ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spFilterByDepDeleteByID", connection);
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

        public tblPA_FilterByDep GetFilterDepById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblPA_FilterByDep news = null;
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

        public DataTable GetFilterDep(string Procedure_Name, string Table_Name, string manager)
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
                    SqlCommand command = new SqlCommand("spCleanFilterByDep", connection);
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