using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PAOL.App_Code.Data
{
    public class AttachmentDAO : BaseDAO
    {
        private tbl_Attachment CreateObjectFromReader(IDataReader reader)
        {
            tbl_Attachment news = new tbl_Attachment();
            try
            {
                news.ID = (int)reader["ID"];

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
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tbl_Attachment item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spAttachmentCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@AttachmentName", item.AttachmentName));
                command.Parameters.Add(new SqlParameter("@AttachmentPath", item.AttachmentPath));
                command.Parameters.Add(new SqlParameter("@FileType", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FileSize", item.FileSize));
                if(item.NewsID == 0)
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
        public bool DeleteAllAttach(tbl_Attachment news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spAttachmentDelete", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@NewsID", news.NewsID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public bool DeleteAttachByID(int  ID)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spAttachmentDeleteByID", connection);
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

        public DataTable GetNewsById(string Procedure_Name, string Table_Name, int newsid)
        {

            return StoreToTable(Procedure_Name, Table_Name, newsid);

        }

        public tbl_Attachment GetAttachmentById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Attachment news = null;
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
    }
}