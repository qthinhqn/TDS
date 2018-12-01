using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class EmpCompetency_DetailDAO : BaseDAO
    {
        private tbl_EmpCompetency_Detail CreateObjectFromReader(IDataReader reader)
        {
            tbl_EmpCompetency_Detail news = new tbl_EmpCompetency_Detail();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["EmpCompetency_id"].ToString())))
                    news.EmpCompetency_id = (int)reader["EmpCompetency_id"];

                if (!(string.IsNullOrEmpty(reader["Competency_ID"].ToString())))
                    news.Competency_id = (int)reader["Competency_ID"];

                if (!(string.IsNullOrEmpty(reader["Score"].ToString())))
                    news.Score = (double)reader["Score"];

                if (!(string.IsNullOrEmpty(reader["Adj_Score"].ToString())))
                    news.Adj_Score = (double)reader["Adj_Score"];

                if (!(string.IsNullOrEmpty(reader["Important"].ToString())))
                    news.Important = (double)reader["Important"];

                if (!(string.IsNullOrEmpty(reader["Adj_Important"].ToString())))
                    news.Adj_Important = (double)reader["Adj_Important"];

                if (!(string.IsNullOrEmpty(reader["Point"].ToString())))
                    news.Point = (double)reader["Point"];

                if (!(string.IsNullOrEmpty(reader["Adj_Point"].ToString())))
                    news.Adj_Point = (double)reader["Adj_Point"];
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

        public bool CreateNew(tbl_EmpCompetency_Detail item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_EmpCompetency_DetailCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpCompetency_id", item.EmpCompetency_id));
                command.Parameters.Add(new SqlParameter("@Competency_ID", item.Competency_id));
                command.Parameters.Add(new SqlParameter("@Score", item.Score));
                command.Parameters.Add(new SqlParameter("@Adj_Score", item.Adj_Score));
                command.Parameters.Add(new SqlParameter("@Important", item.Important));
                command.Parameters.Add(new SqlParameter("@Adj_Important", item.Adj_Important));
                command.Parameters.Add(new SqlParameter("@Point", item.Point));
                command.Parameters.Add(new SqlParameter("@Adj_Point", item.Adj_Point));
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
                    SqlCommand command = new SqlCommand("spKPI_EmpCompetency_Detail_DeleteByID", connection);
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

        public bool UpdateByID(tbl_EmpCompetency_Detail item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_EmpCompetency_Detail_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID)); 
                    command.Parameters.Add(new SqlParameter("@EmpCompetency_id", item.EmpCompetency_id));
                    command.Parameters.Add(new SqlParameter("@Competency_ID", item.Competency_id));
                    command.Parameters.Add(new SqlParameter("@Score", item.Score));
                    command.Parameters.Add(new SqlParameter("@Adj_Score", item.Adj_Score));
                    command.Parameters.Add(new SqlParameter("@Important", item.Important));
                    command.Parameters.Add(new SqlParameter("@Adj_Important", item.Adj_Important));
                    command.Parameters.Add(new SqlParameter("@Point", item.Point));
                    command.Parameters.Add(new SqlParameter("@Adj_Point", item.Adj_Point));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_EmpCompetency_Detail GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_EmpCompetency_Detail news = null;
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

        public DataTable GetEmpCompetencyDetail(string Procedure_Name, string Table_Name, int period, int parentID, string EmployeeID)
        {
            object[] par = new object[] { period, parentID, EmployeeID };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }

        public DataTable GetDetailCompetency(string Procedure_Name, string Table_Name, int period, int parentID, int ShowType)
        {
            object[] par = new object[] { period, parentID, ShowType };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }

        public bool UpdateScore(string EmployeeID, int PeriodID, int competency_id, double score, double important)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_EmpCompetency_Detail_UpdateScore", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));
                    command.Parameters.Add(new SqlParameter("@Competency_id", competency_id));
                    command.Parameters.Add(new SqlParameter("@Score", score));
                    command.Parameters.Add(new SqlParameter("@Important", important));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
        public bool UpdateAdj_Score(string EmployeeID, int PeriodID, int competency_id, double score, double important)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_EmpCompetency_Detail_UpdateAdj_Score", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));
                    command.Parameters.Add(new SqlParameter("@Competency_id", competency_id));
                    command.Parameters.Add(new SqlParameter("@Score", score));
                    command.Parameters.Add(new SqlParameter("@Important", important));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public int CountSameImportant(string EmployeeID, int PeriodID, int competency_id, double important)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_CountSameImportant", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));
                    command.Parameters.Add(new SqlParameter("@Competency_id", competency_id));
                    command.Parameters.Add(new SqlParameter("@Important", important));

                    connection.Open();
                    object obj = command.ExecuteScalar();
                        result = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public int check4Time(string EmployeeID, int period, int competency_id, double point, double important)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Check4Time", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@PeriodID", period));
                    command.Parameters.Add(new SqlParameter("@Competency_id", competency_id));
                    command.Parameters.Add(new SqlParameter("@Score", point));
                    command.Parameters.Add(new SqlParameter("@Important", important));

                    connection.Open();
                    object obj = command.ExecuteScalar();
                    result = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}