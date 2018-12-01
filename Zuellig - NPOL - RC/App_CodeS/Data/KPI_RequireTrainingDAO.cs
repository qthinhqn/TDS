using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class KPI_RequireTrainingDAO : BaseDAO
    {
        private tbl_KPIRequireTraining CreateObjectFromReader(IDataReader reader)
        {
            tbl_KPIRequireTraining news = new tbl_KPIRequireTraining();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["EmployeeID"].ToString())))
                    news.EmployeeID = (string)reader["EmployeeID"];

                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

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
        public DataTable GetAllRequirement(string Procedure_Name, string Table_Name, int PeriodID)
        {
            return StoreToTable(Procedure_Name, Table_Name, PeriodID);
        }

        public DataTable GetAllRequirementByEmployee(string Procedure_Name, string Table_Name, int PeriodID, string EmployeeID)
        {
            object[] param = new object[] { EmployeeID, PeriodID};
            return StoreToTable(Procedure_Name, Table_Name, param);
        }

        public bool CreateNew(tbl_KPIRequireTraining item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_RequireTrainingCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmployeeID", item.EmployeeID));
                command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
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
                    SqlCommand command = new SqlCommand("spKPI_RequireTraining_DeleteByID", connection);
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

        public bool UpdateByID(tbl_KPIRequireTraining item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_RequireTraining_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Detail", item.Detail));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_KPIRequireTraining GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_KPIRequireTraining news = null;
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

        public tbl_KPIRequireTraining GetObjectByEmp(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));

                connection.Open();
                tbl_KPIRequireTraining news = null;
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