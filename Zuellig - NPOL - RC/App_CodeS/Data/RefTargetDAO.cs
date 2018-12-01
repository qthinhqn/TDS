using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;

namespace NPOL.App_Code.Data
{
    public class RefTargetDAO : BaseDAO
    {
        private tbl_KPI_RefTarget CreateObjectFromReader(IDataReader reader)
        {
            tbl_KPI_RefTarget news = new tbl_KPI_RefTarget();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Description"].ToString())))
                    news.Description = (string)reader["Description"];

                if (!(string.IsNullOrEmpty(reader["Description_eng"].ToString())))
                    news.Description_eng = (string)reader["Description_eng"];

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
        public DataTable GetAllTargetRef(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tbl_KPI_RefTarget item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_RefTargetCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Description", item.Description));
                command.Parameters.Add(new SqlParameter("@Description_eng", item.Description_eng));
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
                    SqlCommand command = new SqlCommand("spKPI_RefTarget_DeleteByID", connection);
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

        public bool UpdateByID(tbl_KPI_RefTarget item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_RefTarget_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@Description_eng", item.Description_eng));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_KPI_RefTarget GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_KPI_RefTarget news = null;
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