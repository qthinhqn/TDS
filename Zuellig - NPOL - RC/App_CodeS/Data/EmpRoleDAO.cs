using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class EmpRoleDAO : BaseDAO
    {
        public EmpRoleDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tbl_EmpRole CreateNewsFromReader(IDataReader reader)
        {
            tbl_EmpRole news = new tbl_EmpRole();
            news.EmpID = (string)reader["EmployeeID"];

            if (string.IsNullOrEmpty(reader["A"].ToString()))
                news.LeaveManager = "";
            else
                news.LeaveManager = reader["A"].ToString();

            if (string.IsNullOrEmpty(reader["B"].ToString()))
                news.LeaveEmployee = "";
            else
                news.LeaveEmployee = reader["B"].ToString();

            if (string.IsNullOrEmpty(reader["C"].ToString()))
                news.ManagerKPI = "";
            else
                news.ManagerKPI = reader["C"].ToString();

            if (string.IsNullOrEmpty(reader["D"].ToString()))
                news.EmployeeKPI = "";
            else
                news.EmployeeKPI = reader["D"].ToString();

            if (string.IsNullOrEmpty(reader["GroupCode"].ToString()))
                news.GroupCode = "";
            else
                news.GroupCode = reader["GroupCode"].ToString();

            return news;
        }
        public void CreateNews(tbl_EmpRole news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("__", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));
                command.Parameters.Add(new SqlParameter("@LeaveManager", news.LeaveManager));
                command.Parameters.Add(new SqlParameter("@LeaveEmployee", news.LeaveEmployee));
                command.Parameters.Add(new SqlParameter("@ManagerKPI", news.ManagerKPI));
                command.Parameters.Add(new SqlParameter("@EmployeeKPI", news.EmployeeKPI));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool UpdateNews(tbl_EmpRole news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));
                    command.Parameters.Add(new SqlParameter("@LeaveManager", news.LeaveManager));
                    command.Parameters.Add(new SqlParameter("@LeaveEmployee", news.LeaveEmployee));
                    command.Parameters.Add(new SqlParameter("@ManagerKPI", news.ManagerKPI));
                    command.Parameters.Add(new SqlParameter("@EmployeeKPI", news.EmployeeKPI));

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
        public bool DeleteNews(tbl_EmpRole news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_EmpRole GetInfoByID(string Procedure_Name, string thamso, string EmpID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, EmpID));

                connection.Open();
                tbl_EmpRole news = null;
                try
                {
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                            news = CreateNewsFromReader(reader);
                    }
                }
                catch (Exception ex) { }
                return news;
            }
        }
        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string empid)
        {

            return StoreToTable(Procedure_Name, Table_Name, empid);

        }
        public List<tbl_EmpRole> GetListByID(string Procedure_name, string thamso, string EmpID)
        {
            List<tbl_EmpRole> newsList = new List<tbl_EmpRole>();
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