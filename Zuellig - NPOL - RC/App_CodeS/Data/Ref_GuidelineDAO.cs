using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Ref_GuidelineDAO : BaseDAO
    {
        private tblRef_Guideline CreateObjectFromReader(IDataReader reader)
        {
            tblRef_Guideline news = new tblRef_Guideline();
            try
            {
                news.ID = (int)reader["ID"];
                
                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

                if (!(string.IsNullOrEmpty(reader["MinRange"].ToString())))
                    news.MinRange = (double)reader["MinRange"];

                if (!(string.IsNullOrEmpty(reader["MaxRange"].ToString())))
                    news.MaxRange = (double)reader["MaxRange"];

                if (!(string.IsNullOrEmpty(reader["Description"].ToString())))
                    news.Description = (string)reader["Description"];

                if (!(string.IsNullOrEmpty(reader["Expectation"].ToString())))
                    news.Expectation = (string)reader["Expectation"];

                if (!(string.IsNullOrEmpty(reader["Real_Percent"].ToString())))
                    news.Real_Percent = (double)reader["Real_Percent"];

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
        public DataTable GetAllRefCompetency(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tblRef_Guideline item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_CreateRef_Guideline", connection);
                command.CommandType = CommandType.StoredProcedure;

                //command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                command.Parameters.Add(new SqlParameter("@MinRange", item.MinRange));
                command.Parameters.Add(new SqlParameter("@MaxRange", item.MaxRange));
                command.Parameters.Add(new SqlParameter("@Description", item.Description));
                command.Parameters.Add(new SqlParameter("@Expectation", item.Expectation));
                //command.Parameters.Add(new SqlParameter("@Real_Percent", item.Real_Percent));
                //command.Parameters.Add(new SqlParameter("@Notes", item.Notes));
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
                    SqlCommand command = new SqlCommand("sp_DeleteRef_GuidelineByID", connection);
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

        public bool UpdateByID(tblRef_Guideline item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("sp_UpdateRef_GuidelineByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    //command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                    command.Parameters.Add(new SqlParameter("@MinRange", item.MinRange));
                    command.Parameters.Add(new SqlParameter("@MaxRange", item.MaxRange));
                    command.Parameters.Add(new SqlParameter("@Description", item.Description));
                    command.Parameters.Add(new SqlParameter("@Expectation", item.Expectation));
                    //command.Parameters.Add(new SqlParameter("@Real_Percent", item.Real_Percent));
                    //command.Parameters.Add(new SqlParameter("@Notes", item.Notes));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
        public bool UpdateNotes(tblRef_Guideline item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_UpdateNotes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Notes", item.Notes));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tblRef_Guideline GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblRef_Guideline news = null;
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

        public DataTable GetTable_rptEmpKPI(string Procedure_Name, string Table_Name, string EmployeeID, int PeriodID)
        {
            object[] par = new object[] { EmployeeID, PeriodID };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }
    }
}