using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class SubmitNewsDAO : BaseDAO
    {
        private tbl_SubmitNews CreateObjectFromReader(IDataReader reader)
        {
            tbl_SubmitNews news = new tbl_SubmitNews();
            try
            {
                news.ID = (int)reader["SubmitID"];

                if ((string.IsNullOrEmpty(reader["NewsID"].ToString())))
                    news.NewsID = (int)reader["NewsID"];

                if (!(string.IsNullOrEmpty(reader["Path"].ToString())))
                    news.Path = (string)reader["Path"];

                if (!(string.IsNullOrEmpty(reader["SubmitDate"].ToString())))
                    news.SubmitDate = (DateTime)reader["SubmitDate"];

                if (!(string.IsNullOrEmpty(reader["SubmitFile"].ToString())))
                    news.SubmitFile = (string)reader["SubmitFile"];

                if (!(string.IsNullOrEmpty(reader["SubmitUser"].ToString())))
                    news.SubmitUser = (string)reader["SubmitUser"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tbl_SubmitNews item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spSubmitFileCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@SubmitUser", item.SubmitUser));
                command.Parameters.Add(new SqlParameter("@SubmitFile", item.SubmitFile));
                //command.Parameters.Add(new SqlParameter("@SubmitDate", item.SubmitDate));
                command.Parameters.Add(new SqlParameter("@Path", item.Path));
                if (item.NewsID == 0)
                    command.Parameters.Add(new SqlParameter("@NewsID", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@NewsID", item.NewsID));
                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                paramID.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                if (paramID.Value != DBNull.Value)
                    item.ID = (int)paramID.Value;
                else
                    item.ID = 0;
            }
        }

        public tbl_SubmitNews GetSubmitFile(string Procedure_Name, int ID, string user)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@NewsID", ID));
                command.Parameters.Add(new SqlParameter("@SubmitUser", user));

                connection.Open();
                tbl_SubmitNews news = null;
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

        public DataTable GetTableByNewsId(string Procedure_Name, string Table_Name, int newsid)
        {

            return StoreToTable(Procedure_Name, Table_Name, newsid);

        }
    }
}