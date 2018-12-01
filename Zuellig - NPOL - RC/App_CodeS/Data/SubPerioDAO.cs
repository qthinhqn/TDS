using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class SubPeriodDAO : BaseDAO
    {
        private tblSubPeriod CreateObjectFromReader(IDataReader reader)
        {
            tblSubPeriod news = new tblSubPeriod();
            try
            {
                news.ID = (int)reader["ID"];

                if (!(string.IsNullOrEmpty(reader["Period_ID"].ToString())))
                    news.Period_ID = (int)reader["Period_ID"];

                if (!(string.IsNullOrEmpty(reader["ManagerID"].ToString())))
                    news.ManagerID = (string)reader["ManagerID"];

                if (!(string.IsNullOrEmpty(reader["FromDate"].ToString())))
                    news.FromDate = (DateTime)reader["FromDate"];

                if (!(string.IsNullOrEmpty(reader["ToDate"].ToString())))
                    news.ToDate = (DateTime)reader["ToDate"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tblSubPeriod item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spSubPeriod_Create", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@ManagerID", item.ManagerID));
                command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                command.Parameters.Add(new SqlParameter("@FromDate", item.FromDate));
                command.Parameters.Add(new SqlParameter("@ToDate", item.ToDate));
                //SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                //paramID.Direction = ParameterDirection.Output;
                //command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                //if (paramID.Value != DBNull.Value)
                //    item.ID = (int)paramID.Value;
                //else
                //    item.ID = 0;
            }
        }

        public bool UpdateNews(tblSubPeriod item)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("spSubPeriod_Update", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ManagerID", item.ManagerID));
                    command.Parameters.Add(new SqlParameter("@Period_ID", item.Period_ID));
                    if (item.FromDate != null)
                        command.Parameters.Add(new SqlParameter("@FromDate", item.FromDate));
                    else
                        command.Parameters.Add(new SqlParameter("@FromDate", DBNull.Value));
                    if (item.ToDate != null)
                        command.Parameters.Add(new SqlParameter("@ToDate", item.ToDate));
                    else
                        command.Parameters.Add(new SqlParameter("@ToDate", DBNull.Value));
                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
                catch (Exception ex)
                {

                }
            }

            return result;
        }

        public bool DeleteByID(int  ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("DELETE [dbo].[tblSubPeriod]  WHERE ID = @ID", connection);
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(new SqlParameter("@ID", ID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public DataTable GetNewsById(string Procedure_Name, string Table_Name, int newsid)
        {

            return StoreToTable(Procedure_Name, Table_Name, newsid);

        }

        public tblSubPeriod GetAttachmentById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tblSubPeriod news = null;
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

        public DataTable GetAttachment(string Procedure_Name, string Table_Name)
        {
            return StoreToTable(Procedure_Name, Table_Name, null);
        }

        public DataTable GetListByID(int period, string EmployeeID)
        {
            return StoreToTable("spKPI_CheckEditSubPeriod", "tblEmpHasSubPeriod", new object[] {period, EmployeeID});
            /*
            List<tblSubPeriod> newsList = new List<tblSubPeriod>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Period_ID", period));
                    command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add(CreateObjectFromReader(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
            */
        }
    }
}