using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class ChangeManagerDAO : BaseDAO
    {
        private tblChangeManager CreateObjectFromReader(IDataReader reader)
        {
            tblChangeManager news = new tblChangeManager();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["ManagerID_A"].ToString())))
                    news.Manager_A = (string)reader["ManagerID_A"];

                if (!(string.IsNullOrEmpty(reader["ManagerID_B"].ToString())))
                    news.Manager_B = (string)reader["ManagerID_B"];

                if (!(string.IsNullOrEmpty(reader["FromDate"].ToString())))
                    news.FromDate = (DateTime)reader["FromDate"];

                if (!(string.IsNullOrEmpty(reader["ToDate"].ToString())))
                    news.ToDate = (DateTime)reader["ToDate"];

                if (!(string.IsNullOrEmpty(reader["Status"].ToString())))
                    news.Status = (bool)reader["Status"];

                if (!(string.IsNullOrEmpty(reader["Notes"].ToString())))
                    news.Notes = (string)reader["Notes"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public DataTable GetAllManager(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tblChangeManager item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_ChangeManager_Create", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ManagerID_A", item.Manager_A));
                command.Parameters.Add(new SqlParameter("@ManagerID_B", item.Manager_B));
                if (item.FromDate == null)
                    command.Parameters.Add(new SqlParameter("@FromDate", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@FromDate", item.FromDate));
                if (item.ToDate == null)
                    command.Parameters.Add(new SqlParameter("@ToDate", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@ToDate", item.ToDate));
                if (item.Status == null)
                    command.Parameters.Add(new SqlParameter("@Status", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@Status", item.Status));
                command.Parameters.Add(new SqlParameter("@Notes", item.Notes));
                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                paramID.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                if (paramID.Value != DBNull.Value)
                {
                    item.ID = (int)paramID.Value;
                    result = true;
                }
                else
                    item.ID = 0;
            }
            return result;
        }

        public bool CreateNew_PA(tblChangeManager item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_ChangePAManager_Create", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ManagerID_A", item.Manager_A));
                command.Parameters.Add(new SqlParameter("@ManagerID_B", item.Manager_B));
                if (item.FromDate == null)
                    command.Parameters.Add(new SqlParameter("@FromDate", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@FromDate", item.FromDate));
                if (item.ToDate == null)
                    command.Parameters.Add(new SqlParameter("@ToDate", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@ToDate", item.ToDate));
                if (item.Status == null)
                    command.Parameters.Add(new SqlParameter("@Status", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@Status", item.Status));
                command.Parameters.Add(new SqlParameter("@Notes", item.Notes));
                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                paramID.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                if (paramID.Value != DBNull.Value)
                {
                    item.ID = (int)paramID.Value;
                    result = true;
                }
                else
                    item.ID = 0;
            }
            return result;
        }

        public bool DeleteByID(int ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_ChangeManager_DeleteByID", connection);
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

        public bool UpdateByID(tblChangeManager item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_ChangeManager_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@ManagerID_A", item.Manager_A));
                    command.Parameters.Add(new SqlParameter("@ManagerID_B", item.Manager_B));
                    if (item.FromDate == null)
                        command.Parameters.Add(new SqlParameter("@FromDate", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@FromDate", item.FromDate));
                    if (item.ToDate == null)
                        command.Parameters.Add(new SqlParameter("@ToDate", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@ToDate", item.ToDate));
                    if (item.Status == null)
                        command.Parameters.Add(new SqlParameter("@Status", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@Status", item.Status));
                    command.Parameters.Add(new SqlParameter("@Notes", item.Notes));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tblChangeManager GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblChangeManager news = null;
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


        public bool ChangeManager(string Procedure_Name, int ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RefID", ID));

                    connection.Open();
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}