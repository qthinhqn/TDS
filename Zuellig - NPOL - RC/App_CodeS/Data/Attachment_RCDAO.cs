using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Entities;
using System.Data.SqlClient;
using System.Data;

namespace NPOL.App_Code.Data
{
    public class Attachment_RCDAO : BaseDAO
    {
        private tbl_Attachment_RC CreateObjectFromReader(IDataReader reader)
        {
            tbl_Attachment_RC news = new tbl_Attachment_RC();
            try
            {
                news.ID = (int)reader["ID"];

                if ((string.IsNullOrEmpty(reader["RequestID"].ToString())))
                    news.RequestID = reader["RequestID"].ToString();

                if (!(string.IsNullOrEmpty(reader["AttachmentName"].ToString())))
                    news.AttachmentName = (string)reader["AttachmentName"];

                if (!(string.IsNullOrEmpty(reader["AttachmentPath"].ToString())))
                    news.AttachmentPath = (string)reader["AttachmentPath"];

                if (!(string.IsNullOrEmpty(reader["FileType"].ToString())))
                    news.FileType = (string)reader["FileType"];

                if (!(string.IsNullOrEmpty(reader["FileSize"].ToString())))
                    news.FileSize = (string)reader["FileSize"];

                if (!(string.IsNullOrEmpty(reader["AttachType"].ToString())))
                    news.AttachType = (string)reader["AttachType"];
            }
            catch (Exception ex)
            {
                news = null;
                throw;
            }

            return news;
        }
        public void CreateNew(tbl_Attachment_RC item)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spAttachment_RCCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@AttachmentName", item.AttachmentName));
                command.Parameters.Add(new SqlParameter("@AttachmentPath", item.AttachmentPath));
                command.Parameters.Add(new SqlParameter("@FileType", DBNull.Value));
                command.Parameters.Add(new SqlParameter("@FileSize", item.FileSize));
                command.Parameters.Add(new SqlParameter("@RequestID", item.RequestID));
                command.Parameters.Add(new SqlParameter("@AttachType", item.AttachType));
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
        public bool DeleteAllAttach(tbl_Attachment_RC news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spAttachment_RCDelete", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));
                    command.Parameters.Add(new SqlParameter("@AttachType", news.AttachType));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        //public bool DeleteAttachByID(int  ID)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (SqlConnection connection = GetConnection())
        //        {
        //            SqlCommand command = new SqlCommand("spAttachmentDeleteByID", connection);
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.Add(new SqlParameter("@ID", ID));

        //            connection.Open();
        //            if (command.ExecuteNonQuery() > 0)
        //                result = true;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return result;
        //}

        public DataTable GetNewsById(string Procedure_Name, string Table_Name, string requestid)
        {

            return StoreToTable(Procedure_Name, Table_Name, requestid);

        }

        public tbl_Attachment_RC GetAttachmentById(string Procedure_Name, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ID", ID));

                connection.Open();
                tbl_Attachment_RC news = null;
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