using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class Store_KPIDAO : BaseDAO
    {
        private tbl_Store_KPI CreateObjectFromReader(IDataReader reader)
        {
            tbl_Store_KPI obj = new tbl_Store_KPI();
            try
            {
                obj.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Type"].ToString())))
                    obj.Type = (bool)reader["Type"];
                else
                    obj.Type = null;

                if (!(string.IsNullOrEmpty(reader["Description"].ToString())))
                    obj.Description = (string)reader["Description"];

                if (!(string.IsNullOrEmpty(reader["Description_eng"].ToString())))
                    obj.Description_eng = (string)reader["Description_eng"];

                if (!(string.IsNullOrEmpty(reader["Target"].ToString())))
                    obj.Target = (string)reader["Target"];

                if (!(string.IsNullOrEmpty(reader["DoneBy"].ToString())))
                    obj.DoneBy = (string)reader["DoneBy"];

                if (!(string.IsNullOrEmpty(reader["Active"].ToString())))
                    obj.Active = (bool)reader["Active"];

                if (!(string.IsNullOrEmpty(reader["CreateTime"].ToString())))
                    obj.CreateTime = (DateTime)reader["CreateTime"];
                else
                    obj.CreateTime = null;

                if (!(string.IsNullOrEmpty(reader["LastUpdate"].ToString())))
                    obj.LastUpdate = (DateTime)reader["LastUpdate"];
                else
                    obj.LastUpdate = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw;
            }

            return obj;
        }
        public DataTable GetAllStore_KPI(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tbl_Store_KPI item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_StoreKPICreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                if (item.Type != null)
                    command.Parameters.Add(new SqlParameter("@Type", item.Type));
                else
                    command.Parameters.Add(new SqlParameter("@Type", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Description", item.Description));
                command.Parameters.Add(new SqlParameter("@Description_eng", item.Description_eng));
                command.Parameters.Add(new SqlParameter("@Target", item.Target));
                command.Parameters.Add(new SqlParameter("@DoneBy", item.DoneBy));
                
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
                    SqlCommand command = new SqlCommand("spKPI_StoreKPI_DeleteByID", connection);
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

        public bool UpdateByID(tbl_Store_KPI item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_StoreKPI_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Type", item.Type));
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@Description_eng", item.Description_eng));
                    command.Parameters.Add(new SqlParameter("@Doneby", item.DoneBy));
                    command.Parameters.Add(new SqlParameter("@Target", item.Target));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_Store_KPI GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Store_KPI news = null;
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