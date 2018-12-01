using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class KPI_PeriodDAO : BaseDAO
    {
        private tbl_KPI_Period CreateObjectFromReader(IDataReader reader)
        {
            tbl_KPI_Period news = new tbl_KPI_Period();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Name"].ToString())))
                    news.Name = (string)reader["Name"];

                if (!(string.IsNullOrEmpty(reader["StartTime"].ToString())))
                    news.StartTime = (DateTime)reader["StartTime"];

                if (!(string.IsNullOrEmpty(reader["EndTime"].ToString())))
                    news.EndTime = (DateTime)reader["EndTime"];

                if (!(string.IsNullOrEmpty(reader["ReviewTime"].ToString())))
                    news.ReviewTime = (DateTime)reader["ReviewTime"];

                if (!(string.IsNullOrEmpty(reader["ApprovalTime"].ToString())))
                    news.ApprovalTime = (DateTime)reader["ApprovalTime"];

                if (!(string.IsNullOrEmpty(reader["Active"].ToString())))
                    news.Active = (bool)reader["Active"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public DataTable GetAllKPI_Period(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tbl_KPI_Period item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_PeriodCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Name", item.Name));
                command.Parameters.Add(new SqlParameter("@StartTime", item.StartTime));
                command.Parameters.Add(new SqlParameter("@EndTime", item.EndTime));
                command.Parameters.Add(new SqlParameter("@ReviewTime", item.ReviewTime));
                command.Parameters.Add(new SqlParameter("@ApprovalTime", item.ApprovalTime));
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
                    SqlCommand command = new SqlCommand("spKPI_Period_DeleteByID", connection);
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

        public bool UpdateByID(tbl_KPI_Period item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Period_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Name", item.Name));
                    command.Parameters.Add(new SqlParameter("@StartTime", item.StartTime));
                    command.Parameters.Add(new SqlParameter("@EndTime", item.EndTime));
                    command.Parameters.Add(new SqlParameter("@ReviewTime", item.ReviewTime));
                    command.Parameters.Add(new SqlParameter("@ApprovalTime", item.ApprovalTime));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_KPI_Period GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_KPI_Period news = null;
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

        public int GetKPI_InProcess(string Procedure_Name)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramID = new SqlParameter("@Period_ID", SqlDbType.Int, 4);
                    paramID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    if (paramID.Value != DBNull.Value)
                    {
                        result = (int)paramID.Value;
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool AllowDelete(string Procedure_Name, int ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", ID));
                    SqlParameter paramID = new SqlParameter("@Result", SqlDbType.Bit);
                    paramID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    if (paramID.Value != DBNull.Value)
                    {
                        result = (bool)paramID.Value;
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool AllowEdit(string Procedure_Name, int ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", ID));
                    SqlParameter paramID = new SqlParameter("@Result", SqlDbType.Int, 4);
                    paramID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    if (paramID.Value != DBNull.Value)
                    {
                        result = (bool)paramID.Value;
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}