using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class FilterByLocationDAO : BaseDAO
    {
        private tblPA_FilterByLocation CreateObjectFromReader(IDataReader reader)
        {
            tblPA_FilterByLocation news = new tblPA_FilterByLocation();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["FilterID"].ToString())))
                    news.FilterID = (string)reader["FilterID"];

                if (!(string.IsNullOrEmpty(reader["LocationID"].ToString())))
                    news.LocationID = (string)reader["LocationID"];

                if (!(string.IsNullOrEmpty(reader["LocationName"].ToString())))
                    news.LocationName = (string)reader["LocationName"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tblPA_FilterByLocation item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spFilterByLocationCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                command.Parameters.Add(new SqlParameter("@LocationID", item.LocationID));
                command.Parameters.Add(new SqlParameter("@LocationName", item.LocationName));
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
        public bool UpdateByID(tblPA_FilterByLocation item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spUpdateFilterByLocation", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    //command.Parameters.Add(new SqlParameter("@FilterID", item.FilterID));
                    //command.Parameters.Add(new SqlParameter("@LocationID", item.LocationID));
                    //command.Parameters.Add(new SqlParameter("@LocationName", item.LocationName));
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

        public bool DeleteFilterDep(tblPA_FilterByLocation news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spFilterByLocationDelete", connection);
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
                    SqlCommand command = new SqlCommand("spFilterByLocationDeleteByID", connection);
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

        public tblPA_FilterByLocation GetFilterDepById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblPA_FilterByLocation news = null;
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
                    SqlCommand command = new SqlCommand("spCleanFilterByLocation", connection);
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