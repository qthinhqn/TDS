using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class Employee_InfoDAO : BaseDAO
    {
        private Employee_Info CreateObjectFromReader(IDataReader reader)
        {
            Employee_Info news = new Employee_Info();
            try
            {
                if (!(string.IsNullOrEmpty(reader["EmployeeId"].ToString())))
                    news.EmployeeId = (string)reader["EmployeeId"];

                if (!(string.IsNullOrEmpty(reader["EmployeeName"].ToString())))
                    news.EmployeeName = (string)reader["EmployeeName"];

                if (!(string.IsNullOrEmpty(reader["LeftDate"].ToString())))
                    news.LeftDate = (DateTime)reader["LeftDate"];
                else
                    news.LeftDate = null;

                if (!(string.IsNullOrEmpty(reader["Salary"].ToString())))
                    news.Salary = (double)reader["Salary"];
                else
                    news.Salary = 0;

                if (!(string.IsNullOrEmpty(reader["MaternityDate"].ToString())))
                    news.MaternityDate = (DateTime)reader["MaternityDate"];
                else
                    news.MaternityDate = null;
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }

        public bool CheckViewSalary_EmpReplace(string empID, string managerID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spRC_CheckViewSalary", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@EmpID", empID));
                    command.Parameters.Add(new SqlParameter("@ManagerID", managerID));
                    SqlParameter paramID = new SqlParameter("@KQ", SqlDbType.Bit);
                    paramID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(paramID);

                    connection.Open();
                    command.ExecuteNonQuery();
                    if (paramID.Value != DBNull.Value)
                        result = (bool)paramID.Value;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public Employee_Info GetAttachmentById(string empID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string strSQL = "SELECT EmployeeID, EmployeeName, LeftDate, 'Salary'=(Select top 1 dbo.udf_me_bin(BasicSalary) from tblEmpSalary Where EmployeeID = @EmpID Order by Datechange desc), 'MaternityDate'=(Select top 1 FromDate from tblempDayoff Where LeaveID = 'ML' And EmployeeID=@EmpID order by FromDate desc) From tblEmployee Where EmployeeID = @EmpID";
                SqlCommand command = new SqlCommand(strSQL, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@EmpID", empID));

                connection.Open();
                Employee_Info news = null;
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