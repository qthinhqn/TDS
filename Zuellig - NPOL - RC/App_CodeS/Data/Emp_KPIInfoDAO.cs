using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class Emp_KPIInfoDAO : BaseDAO
    {
        private tblEmp_KPIInfo CreateObjectFromReader(IDataReader reader)
        {
            tblEmp_KPIInfo news = new tblEmp_KPIInfo();
            try
            {
                news.ID = (int)reader["ID"];
                if (!(string.IsNullOrEmpty(reader["LevelID"].ToString())))
                    news.LevelID = (string)reader["LevelID"];
                else
                    news.LevelID = "";

                /*
                if ((string.IsNullOrEmpty(reader["NewsID"].ToString())))
                    news.NewsID = (int)reader["NewsID"];

                if (!(string.IsNullOrEmpty(reader["AttachmentName"].ToString())))
                    news.AttachmentName = (string)reader["AttachmentName"];

                if (!(string.IsNullOrEmpty(reader["AttachmentPath"].ToString())))
                    news.AttachmentPath = (string)reader["AttachmentPath"];

                if (!(string.IsNullOrEmpty(reader["FileType"].ToString())))
                    news.FileType = (string)reader["FileType"];

                if (!(string.IsNullOrEmpty(reader["FileSize"].ToString())))
                    news.FileSize = (string)reader["FileSize"];
                 */
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }

        public DataTable GetDataTableById(string Procedure_Name, string Table_Name, int period_id)
        {

            return StoreToTable(Procedure_Name, Table_Name, period_id);

        }

        public tblEmp_KPIInfo GetObjectById(string employeeid, int period_id)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("Select * From tblEmp_KPIInfo Where EmployeeID = @EmpID And Period_ID=@Period_ID;", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@EmpID", employeeid));
                command.Parameters.Add(new SqlParameter("@Period_ID", period_id));

                connection.Open();
                tblEmp_KPIInfo news = null;
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

        public int GetTypeById(int period_id)
        {
            using (SqlConnection connection = GetConnection())
            {
                int result = 0;
                try
                {
                    SqlCommand command = new SqlCommand("SELECT Distinct TypeID From tblKPI_Period WHERE [ID]=@Period_ID;", connection);
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(new SqlParameter("@Period_ID", period_id));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            if (!string.IsNullOrEmpty(reader["TypeID"].ToString()))
                                result = int.Parse(reader["TypeID"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                return result;
            }
        }
        public int GetYear(object EmployeeID)
        {
            using (SqlConnection connection = GetConnection())
            {
                int result = 0;
                try
                {
                    SqlCommand command = new SqlCommand("SELECT 'YearID'=Max(isnull(YearID,0)) From tblKPIYear;", connection);
                    command.CommandType = CommandType.Text;
                    //command.Parameters.Add(new SqlParameter("@EmployeeID", EmployeeID));
                    connection.Open();

                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(reader["YearID"].ToString()))
                                result = 0;
                            else
                                result = int.Parse(reader["YearID"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                return result;
            }
        }
    }
}