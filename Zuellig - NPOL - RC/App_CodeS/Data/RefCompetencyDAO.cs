using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class RefCompetencyDAO : BaseDAO
    {
        private tbl_Ref_Competency CreateObjectFromReader(IDataReader reader)
        {
            tbl_Ref_Competency news = new tbl_Ref_Competency();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

                if (!(string.IsNullOrEmpty(reader["Competency_ID"].ToString())))
                    news.Competency_ID = (int)reader["Competency_ID"];

                if (!(string.IsNullOrEmpty(reader["Order"].ToString())))
                    news.Order = (int)reader["Order"];
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

        public bool CreateNew(tbl_Ref_Competency item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_RefCompetencyCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                command.Parameters.Add(new SqlParameter("@Competency_ID", item.Competency_ID));
                command.Parameters.Add(new SqlParameter("@Order", item.Order));
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
                    SqlCommand command = new SqlCommand("spKPI_RefCompetency_DeleteByID", connection);
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

        public bool UpdateByID(tbl_Ref_Competency item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Period_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                    command.Parameters.Add(new SqlParameter("@Competency_ID", item.Competency_ID));
                    command.Parameters.Add(new SqlParameter("@Order", item.Order));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_Ref_Competency GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Ref_Competency news = null;
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

        public DataTable GetCompetency_Level1(string Procedure_Name, string Table_Name, int period, int ShowType)
        {
            object[] par = new object[] { period, ShowType };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }
        public DataTable GetCompetency_Level1_ByEmpID(string Procedure_Name, string Table_Name, string EmpID, int period, int ShowType)
        {
            object[] par = new object[] { EmpID, period, ShowType };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }

        public DataTable GetChildCompetency(string Procedure_Name, string Table_Name, int period, int parentID, int ShowType)
        {
            object[] par = new object[] { period, parentID, ShowType };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }

        public bool InsertRef(string Procedure_Name, int competency_ID, int period_ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", period_ID));
                    command.Parameters.Add(new SqlParameter("@Competency_ID", competency_ID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}