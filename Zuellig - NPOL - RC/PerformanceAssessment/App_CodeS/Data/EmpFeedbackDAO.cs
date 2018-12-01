using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class EmpFeedbackDAO : BaseDAO
    {
        public EmpFeedbackDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tbl_EmpFeedback CreateNewsFromReader(IDataReader reader)
        {
            tbl_EmpFeedback news = new tbl_EmpFeedback();
            news.ID = (int)reader["ID"];
            news.EmpID = (string)reader["EmployeeID"];

            if (string.IsNullOrEmpty(reader["EmployeeName"].ToString()))
                news.EmployeeName = "";
            else
                news.EmployeeName = reader["EmployeeName"].ToString();

            if (string.IsNullOrEmpty(reader["Content"].ToString()))
                news.Content = "";
            else
                news.Content = reader["Content"].ToString();

            if (string.IsNullOrEmpty(reader["CreateDate"].ToString()))
                news.CreateDate = DateTime.Now;
            else
                news.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());

            if (string.IsNullOrEmpty(reader["EditDate"].ToString()))
                news.EditDate = null;
            else
                news.EditDate = DateTime.Parse(reader["EditDate"].ToString());

            return news;
        }
        public void CreateNew(tbl_EmpFeedback news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spKPI_CreateEmpFeedback", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));
                //command.Parameters.Add(new SqlParameter("@EmployeeName", news.EmployeeName));
                command.Parameters.Add(new SqlParameter("@Content", news.Content));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool UpdateByID(tbl_EmpFeedback news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("spKPI_UpdateEmpFeedback_ByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", news.ID));
                    command.Parameters.Add(new SqlParameter("@Content", news.Content));

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
        public bool DeleteByID(tbl_EmpFeedback news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spKPI_DeleteEmpFeedback_ByID", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", news.ID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public List<tbl_EmpFeedback> GetInfoByEmpID(string Procedure_Name, string thamso, string EmpID)
        {
            List<tbl_EmpFeedback> newsList = new List<tbl_EmpFeedback>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_Name, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter(thamso, EmpID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add(CreateNewsFromReader(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
        }
        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string empid)
        {

            return StoreToTable(Procedure_Name, Table_Name, empid);

        }
        public List<tbl_EmpFeedback> GetListByID(string Procedure_name, string thamso, string EmpID)
        {
            List<tbl_EmpFeedback> newsList = new List<tbl_EmpFeedback>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, EmpID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add(CreateNewsFromReader(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
        }
    }
}