using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Recruit_EmpGroupDAO : BaseDAO
    {
        public Recruit_EmpGroupDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tblRecruit_EmpGroup CreateNewsFromReader(IDataReader reader)
        {
            tblRecruit_EmpGroup news = new tblRecruit_EmpGroup();
            news.EmpID = (string)reader["EmployeeID"];

            if (string.IsNullOrEmpty(reader["RepresentativeID"].ToString()))
                news.RepresentativeID = "";
            else
                news.RepresentativeID = reader["RepresentativeID"].ToString();

            if (string.IsNullOrEmpty(reader["DateChange"].ToString()))
                news.DateChange = DateTime.Now;
            else
                news.DateChange = DateTime.Parse(reader["DateChange"].ToString());

            if (string.IsNullOrEmpty(reader["SectionID"].ToString()))
                news.SectionID = "";
            else
                news.SectionID = reader["SectionID"].ToString();

            if (string.IsNullOrEmpty(reader["LineID"].ToString()))
                news.LineID = "";
            else
                news.LineID = reader["LineID"].ToString();

            if (string.IsNullOrEmpty(reader["PosID"].ToString()))
                news.PosID = "";
            else
                news.PosID = reader["PosID"].ToString();

            return news;
        }
        public void CreateNews(tblRecruit_EmpGroup news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("__", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));
                command.Parameters.Add(new SqlParameter("@RepresentativeID", news.RepresentativeID));
                command.Parameters.Add(new SqlParameter("@DateChange", news.DateChange));
                command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                command.Parameters.Add(new SqlParameter("@LineID", news.LineID));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool UpdateNews(tblRecruit_EmpGroup news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmpID", news.EmpID));
                    command.Parameters.Add(new SqlParameter("@RepresentativeID", news.RepresentativeID));
                    command.Parameters.Add(new SqlParameter("@DateChange", news.DateChange));
                    command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                    command.Parameters.Add(new SqlParameter("@LineID", news.LineID));

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
        public bool DeleteNews(tblRecruit_EmpGroup news)
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

        public tblRecruit_EmpGroup GetInfoByID(string Procedure_Name, string thamso, string EmpID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, EmpID));

                connection.Open();
                tblRecruit_EmpGroup news = null;
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
        public List<tblRecruit_EmpGroup> GetListByID(string Procedure_name, string thamso, string EmpID)
        {
            List<tblRecruit_EmpGroup> newsList = new List<tblRecruit_EmpGroup>();
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

        public List<string> GetEmployeeNameByID(string Procedure_name, string thamso, string EmpID, string search)
        {
            List<string> newsList = new List<string>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, EmpID));
                    command.Parameters.Add(new SqlParameter("@Search", search));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add((string)reader["EmployeeName"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
        }
        public bool IsRepresentative(string EmpID)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string sql = "select count(*) from tblRecruitManagerLevel where EmployeeID = @EmpID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("EmpID", EmpID));

                connection.Open();
                try
                {
                    Object obj = command.ExecuteScalar();
                    if (int.Parse(obj.ToString()) > 0)
                        result = true;
                }
                catch (Exception ex) { }
            }
            return result;
        }
    }
}