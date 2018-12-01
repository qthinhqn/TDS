using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Recruit_ApprovalDAO : BaseDAO
    {
        public Recruit_ApprovalDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tblOT_Approval CreateNewsFromReader(IDataReader reader)
        {
            tblOT_Approval news = new tblOT_Approval();
            news.ID = (Int32)reader["ID"];

            if (string.IsNullOrEmpty(reader["RegID"].ToString()))
                news.RegID = null;
            else
                news.RegID = (Int32)reader["RegID"];

            if (string.IsNullOrEmpty(reader["LevelNo"].ToString()))
                news.LevelNo = null;
            else
                news.LevelNo = (Int16)reader["LevelNo"];

            if (string.IsNullOrEmpty(reader["ApprovingDate"].ToString()))
                news.ApprovingDate = null;
            else
                news.ApprovingDate = DateTime.Parse(reader["ApprovingDate"].ToString());

            if (string.IsNullOrEmpty(reader["ManagerID"].ToString()))
                news.ManagerID = "";
            else
                news.ManagerID = reader["ManagerID"].ToString();

            if (string.IsNullOrEmpty(reader["ApprovingReason"].ToString()))
                news.ApprovingReason = "";
            else
                news.ApprovingReason = reader["ApprovingReason"].ToString();

            if (string.IsNullOrEmpty(reader["ApprovingStatus"].ToString()))
                news.ApprovingStatus = null;
            else
                news.ApprovingStatus = (bool)reader["ApprovingStatus"];

            if (string.IsNullOrEmpty(reader["MailToManager"].ToString()))
                news.MailToManager = null;
            else
                news.MailToManager = (Int16)reader["MailToManager"];

            return news;
        }
        public void CreateNews(tblOT_Approval news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("__", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@RegID", news.RegID));
                command.Parameters.Add(new SqlParameter("@LevelNo", news.LevelNo));
                command.Parameters.Add(new SqlParameter("@ApprovingDate", news.ApprovingDate));
                command.Parameters.Add(new SqlParameter("@ManagerID", news.ManagerID));
                command.Parameters.Add(new SqlParameter("@ApprovingReason", news.ApprovingReason));
                command.Parameters.Add(new SqlParameter("@ApprovingStatus", news.ApprovingStatus));
                command.Parameters.Add(new SqlParameter("@MailToManager", news.MailToManager));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool UpdateNews(tblOT_Approval news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@ID", news.ID));
                    command.Parameters.Add(new SqlParameter("@ApprovingDate", news.ApprovingDate));
                    command.Parameters.Add(new SqlParameter("@ApprovingReason", news.ApprovingReason));
                    command.Parameters.Add(new SqlParameter("@ApprovingStatus", news.ApprovingStatus));

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
        public bool DeleteNews(tblOT_Approval news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("__", connection);
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

        public tblOT_Approval GetInfoByID(string Procedure_Name, string thamso, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, ID));

                connection.Open();
                tblOT_Approval news = null;
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
        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string regID)
        {

            return StoreToTable(Procedure_Name, Table_Name, regID);

        }
        public List<tblOT_Approval> GetListByID(string Procedure_name, string thamso, int ID)
        {
            List<tblOT_Approval> newsList = new List<tblOT_Approval>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, ID));

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

        internal DataTable GetTable_rptEmpRequisition(string Procedure_Name, string Table_Name, string requestID)
        {
            return StoreToTable(Procedure_Name, Table_Name, requestID);
        }

        internal string getReportType(string requestID)
        {
            string validate = "0";
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    string sqlSelect = "Select * From tblCand_Request_Online Where RequestID=@RequestID";
                    SqlCommand command = new SqlCommand(sqlSelect, connection);
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(new SqlParameter("@RequestID", requestID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(reader["EmpID_Apply"].ToString()))
                                validate = "1";
                            else
                                validate = "2";
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return validate;
        }
    }
}