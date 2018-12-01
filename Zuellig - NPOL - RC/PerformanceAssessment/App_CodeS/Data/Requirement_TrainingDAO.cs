using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class Requirement_TrainingDAO : BaseDAO
    {
        private tbl_Requirement_Training CreateObjectFromReader(IDataReader reader)
        {
            tbl_Requirement_Training news = new tbl_Requirement_Training();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

                if (!(string.IsNullOrEmpty(reader["Employee_ID"].ToString())))
                    news.Employee_ID = (string)reader["Employee_ID"];

                if (!(string.IsNullOrEmpty(reader["Detail"].ToString())))
                    news.Detail = (string)reader["Detail"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public DataTable GetAllRefCompetency(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tbl_Requirement_Training item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_Requirement_TrainingCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                command.Parameters.Add(new SqlParameter("@Employee_ID", item.Employee_ID));
                command.Parameters.Add(new SqlParameter("@Detail", item.Detail));
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
                    SqlCommand command = new SqlCommand("spKPI_Requirement_Training_DeleteByID", connection);
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

        public bool UpdateByID(tbl_Requirement_Training item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Requirement_Training_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                    command.Parameters.Add(new SqlParameter("@Employee_ID", item.Employee_ID));
                    command.Parameters.Add(new SqlParameter("@Detail", item.Detail));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_Requirement_Training GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Requirement_Training news = null;
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

    }
}