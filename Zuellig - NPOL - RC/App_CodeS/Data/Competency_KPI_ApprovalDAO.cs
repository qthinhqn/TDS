using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Competency_KPI_ApprovalDAO : BaseDAO
    {
        private tblCompetency_KPI_Approval CreateObjectFromReader(IDataReader reader)
        {
            tblCompetency_KPI_Approval obj = new tblCompetency_KPI_Approval();
            try
            {
                obj.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["EmpCompetency_KPI_ID"].ToString())))
                    obj.EmpCompetency_KPI_ID = (int)reader["EmpCompetency_KPI_ID"];

                if (!(string.IsNullOrEmpty(reader["Approval_L1"].ToString())))
                    obj.Approval_L1 = (string)reader["Approval_L1"];

                if (!(string.IsNullOrEmpty(reader["DateApproval_L1"].ToString())))
                    obj.DateApproval_L1 = (DateTime)reader["DateApproval_L1"];
                else
                    obj.DateApproval_L1 = null;

                if (!(string.IsNullOrEmpty(reader["DateUpdate_L1"].ToString())))
                    obj.DateUpdate_L1 = (DateTime)reader["DateUpdate_L1"];
                else
                    obj.DateUpdate_L1 = null;

                if (!(string.IsNullOrEmpty(reader["Note_L1"].ToString())))
                    obj.Note_L1 = (string)reader["Note_L1"];

                if (!(string.IsNullOrEmpty(reader["Approval_L2"].ToString())))
                    obj.Approval_L2 = (string)reader["Approval_L2"];

                if (!(string.IsNullOrEmpty(reader["DateApproval_L2"].ToString())))
                    obj.DateApproval_L2 = (DateTime)reader["DateApproval_L2"];
                else
                    obj.DateApproval_L2 = null;

                if (!(string.IsNullOrEmpty(reader["DateUpdate_L2"].ToString())))
                    obj.DateUpdate_L2 = (DateTime)reader["DateUpdate_L2"];
                else
                    obj.DateUpdate_L2 = null;

                if (!(string.IsNullOrEmpty(reader["Note_L2"].ToString())))
                    obj.Note_L2 = (string)reader["Note_L2"];
            }
            catch (Exception ex)
            {
                obj = null;
                throw;
            }

            return obj;
        }
        public DataTable GetAllStore_Competency(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public bool CreateNew(tblCompetency_KPI_Approval item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_Competency_ApprovalCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpCompetency_KPI_ID", item.EmpCompetency_KPI_ID));
                command.Parameters.Add(new SqlParameter("@Approval_L1", item.Approval_L1));
                if (item.DateApproval_L1 != null)
                    command.Parameters.Add(new SqlParameter("@DateApproval_L1", item.DateApproval_L1));
                else
                    command.Parameters.Add(new SqlParameter("@DateApproval_L1", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Note_L1", item.Note_L1));
                command.Parameters.Add(new SqlParameter("@Approval_L2", item.Approval_L2));
                if (item.DateApproval_L2 != null)
                    command.Parameters.Add(new SqlParameter("@DateApproval_L2", item.DateApproval_L2));
                else
                    command.Parameters.Add(new SqlParameter("@DateApproval_L2", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@Note_L2", item.Note_L2));

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

        public bool CreateNew(string EmployeeID, int PeriodID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_CompetencyKPI_ApprovalCreate", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", PeriodID));

                    connection.Open();
                    object o = command.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    result = true;
                }
            }
            catch { }
            return result;
        }

        public bool DeleteByID(int ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_Approval_DeleteByID", connection);
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

        public bool UpdateByID(tblCompetency_KPI_Approval item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_Approval_UpdateByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@EmpCompetency_KPI_ID", item.EmpCompetency_KPI_ID));
                    command.Parameters.Add(new SqlParameter("@Approval_L1", item.Approval_L1));
                    if (item.DateUpdate_L1 != null)
                        command.Parameters.Add(new SqlParameter("@DateUpdate_L1", item.DateUpdate_L1));
                    else
                        command.Parameters.Add(new SqlParameter("@DateUpdate_L1", DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Note_L1", item.Note_L1));
                    command.Parameters.Add(new SqlParameter("@Approval_L2", item.Approval_L2));
                    if (item.DateUpdate_L2 != null)
                        command.Parameters.Add(new SqlParameter("@DateUpdate_L2", item.DateUpdate_L2));
                    else
                        command.Parameters.Add(new SqlParameter("@DateUpdate_L2", DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Note_L2", item.Note_L2));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tblCompetency_KPI_Approval GetObjectById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblCompetency_KPI_Approval news = null;
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

        public bool UpdateNote_L1(tblCompetency_KPI_Approval item)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_Competency_Approval_UpdateNote_L1", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", item.ID));
                    command.Parameters.Add(new SqlParameter("@Note_L1", item.Note_L1));

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