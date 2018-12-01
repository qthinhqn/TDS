using NPOL.App_Code.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Competency_KPIDAO : BaseDAO
    {
        private tbl_Competency_KPI CreateObjectFromReader(IDataReader reader)
        {
            tbl_Competency_KPI news = new tbl_Competency_KPI();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["EmployeeID"].ToString())))
                    news.EmployeeID = (string)reader["EmployeeID"];

                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

                if (!(string.IsNullOrEmpty(reader["Total_CompPoint"].ToString())))
                    news.Total_CompPoint = (double)reader["Total_CompPoint"];

                if (!(string.IsNullOrEmpty(reader["Total_CompImportant"].ToString())))
                    news.Total_CompImportant = (double)reader["Total_CompImportant"];

                if (!(string.IsNullOrEmpty(reader["Total_KPIPoint"].ToString())))
                    news.Total_KPIPoint = (double)reader["Total_KPIPoint"];

                if (!(string.IsNullOrEmpty(reader["Total_KPIImportant"].ToString())))
                    news.Total_KPIImportant = (double)reader["Total_KPIImportant"];

                if (!(string.IsNullOrEmpty(reader["Job_Factor"].ToString())))
                    news.JobFactor = (double)reader["Job_Factor"];

                if (!(string.IsNullOrEmpty(reader["KPI_Factor"].ToString())))
                    news.KPIFactor = (double)reader["KPI_Factor"];

                if (!(string.IsNullOrEmpty(reader["Rating_Total"].ToString())))
                    news.Rating_Total = (double)reader["Rating_Total"];

                if (!(string.IsNullOrEmpty(reader["Notes"].ToString())))
                    news.Notes = (string)reader["Notes"];

                if (!(string.IsNullOrEmpty(reader["Step"].ToString())))
                    news.Step = reader["Step"].ToString();
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

        public bool CreateNew(tbl_Competency_KPI item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_Competency_Create", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmployeeID", item.EmployeeID));
                command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                command.Parameters.Add(new SqlParameter("@Total_CompPoint", item.Total_CompPoint));
                command.Parameters.Add(new SqlParameter("@Total_CompImportant", item.Total_CompImportant));
                command.Parameters.Add(new SqlParameter("@Total_KPIPoint", item.Total_KPIPoint));
                command.Parameters.Add(new SqlParameter("@Total_KPIImportant", item.Total_KPIImportant));
                command.Parameters.Add(new SqlParameter("@JobFactor", item.JobFactor));
                command.Parameters.Add(new SqlParameter("@KPIFactor", item.KPIFactor));
                command.Parameters.Add(new SqlParameter("@Rating_Total", item.Rating_Total));
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
                    SqlCommand command = new SqlCommand("spKPI_Competency_DeleteByID", connection);
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

        public bool UpdateByID(tbl_Competency_KPI item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@EmployeeID", item.EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                    command.Parameters.Add(new SqlParameter("@Total_CompPoint", item.Total_CompPoint));
                    command.Parameters.Add(new SqlParameter("@Total_CompImportant", item.Total_CompImportant));
                    command.Parameters.Add(new SqlParameter("@Total_KPIPoint", item.Total_KPIPoint));
                    command.Parameters.Add(new SqlParameter("@Total_KPIImportant", item.Total_KPIImportant));
                    command.Parameters.Add(new SqlParameter("@JobFactor", item.JobFactor));
                    command.Parameters.Add(new SqlParameter("@KPIFactor", item.KPIFactor));
                    command.Parameters.Add(new SqlParameter("@Rating_Total", item.Rating_Total));
                    command.Parameters.Add(new SqlParameter("@Notes", item.Notes));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }
        public bool UpdateNotes(tbl_Competency_KPI item)
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

        public tbl_Competency_KPI GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Competency_KPI news = null;
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


        public int GetCurrentStep(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_GetCurrentStep", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));

                    connection.Open();
                    object obj = command.ExecuteScalar();
                    result = int.Parse(obj.ToString());
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_Competency_KPI GetObjectByEmpId(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                command.Parameters.Add(new SqlParameter("@PeriodID", PeriodID));

                connection.Open();
                tbl_Competency_KPI news = null;
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

        public bool UpdateScore(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", PeriodID));

                    connection.Open();
                    if (command.ExecuteNonQuery() >= 0)
                        result = true;
                    connection.Close();
                    command.Dispose();
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool UpdateKPIPoint(string Procedure_Name, string EmployeeID, int PeriodID, double KPIPoint)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", PeriodID));
                    command.Parameters.Add(new SqlParameter("@KPIPoint", KPIPoint));

                    connection.Open();
                    if (command.ExecuteNonQuery() >= 0)
                        result = true;
                    connection.Close();
                    command.Dispose();
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool UpdateFactor(string Procedure_Name, string EmployeeID, int PeriodID, double jobFactor, double kpiFactor)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", PeriodID));
                    command.Parameters.Add(new SqlParameter("@Job_Factor", jobFactor));
                    command.Parameters.Add(new SqlParameter("@KPI_Factor", kpiFactor));

                    connection.Open();
                    if (command.ExecuteNonQuery() >= 0)
                        result = true;
                    connection.Close();
                    command.Dispose();
                }
            }
            catch (Exception ex) { }
            return result;
        }
        public bool UpdateFactorByID(string Procedure_Name, int ID, double jobFactor, double kpiFactor)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", ID));
                    command.Parameters.Add(new SqlParameter("@Job_Factor", jobFactor));
                    command.Parameters.Add(new SqlParameter("@KPI_Factor", kpiFactor));

                    connection.Open();
                    if (command.ExecuteNonQuery() >= 0)
                        result = true;
                    connection.Close();
                    command.Dispose();
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool IsCompletedAssess(string Procedure_Name, string EmployeeID, int PeriodID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", PeriodID));
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

        public DataTable GetTable_rptEmpKPI(string Procedure_Name, string Table_Name, string EmployeeID, int PeriodID)
        {
            object[] par = new object[] { EmployeeID, PeriodID };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }
        public DataTable GetTable_rptRatingPercent(string Procedure_Name, string Table_Name, string EmployeeID, int PeriodID, string Location, bool level3)
        {
            object[] par = new object[] { EmployeeID, PeriodID, Location, level3 };
            DataTable dt = StoreToTable(Procedure_Name, Table_Name, par);
            return dt;
        }

        public DataTable GetTable_rptEmpHistory(string Procedure_Name, string Table_Name, string EmployeeID, int Period_ID)
        {
            object[] par = new object[] { EmployeeID, Period_ID };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }

        public DataTable GetTable_rptGeneralKPI(string Procedure_Name, string Table_Name, int PeriodID)
        {
            object[] par = new object[] { PeriodID };
            return StoreToTable(Procedure_Name, Table_Name, par);
        }


        public object getCurrentLevel(object id, object managerid)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(GetConnectionString());
            provider.CommandText = "Select Approval_L1, Approval_L2, Approval_L3, Approval_L4 from tblCompetency_KPI_Approval where id = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (string.Compare(managerid.ToString(), dt.Rows[0]["Approval_L" + (i + 1).ToString()].ToString(), true) == 0)
                    {
                        value = i + 1;
                        break;
                    }
                }
            }
            provider.CloseConnection();
            return value;
        }


        public bool isLastLevel(object id, object currentLevel)
        {
            bool value = false;

            try
            {
                ArrayList arr = new ArrayList();
                arr = getLevelValues(id);
                if (Convert.ToInt32(currentLevel) == arr.Count)
                {
                    value = true;
                }
            }
            catch (Exception ex) { }
            return value;
        }

        public ArrayList getLevelValues(object id)
        {
            ArrayList arr = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(GetConnectionString());
            provider.CommandText = "Select Approval_L1, Approval_L2, Approval_L3, Approval_L4 from tblCompetency_KPI_Approval where id = @id";
            provider.ParameterCollection = new string[] { "@id" };
            provider.ValueCollection = new object[] { id };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    object tmp = dt.Rows[0]["Approval_L" + i.ToString()];
                    if (!tmp.ToString().Equals(""))
                    {
                        arr.Add(i);
                    }
                }
            }
            provider.CloseConnection();
            return arr;
        }
        public bool isFirstLastLevel(object id, object currentLevel)
        {
            bool value = false;
            ArrayList arr = new ArrayList();
            arr = getLevelValues(id);
            if (arr.Count == 1 && Convert.ToInt32(currentLevel) == 1)
            {
                value = true;
            }
            return value;
        }

        public bool ApproveFirst(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(GetConnectionString());
            string sql = "Update tblCompetency_KPI_Approval set DateApproval_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 1, FinalStatus = 'w', ";
            sql += "Note_L" + level.ToString() + " = @note where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            provider.CloseConnection();
            return value;
        }

        public bool ApproveLast(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(GetConnectionString());
            string sql = "Update tblCompetency_KPI_Approval set DateApproval_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 1, ";
            sql += "Note_L" + level.ToString() + " = @note, FinalStatus = 'a' where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            provider.CloseConnection();
            return value;
        }

        public bool CancelApproval(object id, object level, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(GetConnectionString());
            string sql = "Update tblCompetency_KPI_Approval set DateApproval_L" + level.ToString() + " = getdate(), ApprovingStatus_L" + level.ToString() + " = 0, ";
            sql += "Note_L" + level.ToString() + " = @note, FinalStatus = 'c' where id = @id";
            provider.CommandText = sql;
            provider.ParameterCollection = new string[] { "@id", "@note" };
            provider.ValueCollection = new object[] { id, reason };
            int i = provider.ExecuteNonQuery();
            if (i > 0)
            {
                value = true;
            }

            provider.CloseConnection();
            return value;
        }

    }
}