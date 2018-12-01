using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class NewsDAO : BaseDAO
    {
        public NewsDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tbl_News CreateNewsFromReader(IDataReader reader)
        {
            tbl_News news = new tbl_News();
            news.NewsID = (int)reader["NewsID"];

            if ((string.IsNullOrEmpty(reader["TypeID"].ToString())))
                news.TypeID = (int)reader["TypeID"];

            if (!(string.IsNullOrEmpty(reader["Title"].ToString())))
                news.Title = (string)reader["Title"];

            if (!(string.IsNullOrEmpty(reader["Summary"].ToString())))
                news.Summary = (string)reader["Summary"];

            if (!(string.IsNullOrEmpty(reader["Content"].ToString())))
                news.Content = (string)reader["Content"];

            if (!(string.IsNullOrEmpty(reader["Picture"].ToString())))
                news.Picture = (string)reader["Picture"];

            if (!(string.IsNullOrEmpty(reader["UserID"].ToString())))
                news.UserID = (string)reader["UserID"];

            if (!(string.IsNullOrEmpty(reader["CreationTime"].ToString())))
                news.CreationTime = (DateTime)reader["CreationTime"];

            if (!(string.IsNullOrEmpty(reader["IssueDate"].ToString())))
                news.IssueDate = (DateTime)reader["IssueDate"];

            if (!(string.IsNullOrEmpty(reader["IsAttach"].ToString())))
                news.IsAttach = (bool)reader["IsAttach"];

            if (!(string.IsNullOrEmpty(reader["AllowSubmit"].ToString())))
                news.AllowSubmit = (bool)reader["AllowSubmit"];

            if (!(string.IsNullOrEmpty(reader["DeadlineSubmit"].ToString())))
                news.DeadlineSubmit = (DateTime)reader["DeadlineSubmit"];

            if (!(string.IsNullOrEmpty(reader["IsShow"].ToString())))
                news.IsShow = (bool)reader["IsShow"];

            //if (!(string.IsNullOrEmpty(reader["StatusID"].ToString())))
            //    news.StatusID = reader["StatusID"].ToString().ToCharArray().ElementAt(0);

            if (!(string.IsNullOrEmpty(reader["ViewedCount"].ToString())))
                news.ViewedCount = (short)reader["ViewedCount"];

            return news;
        }
        public void CreateNews(tbl_News news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("spNewsCreate", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                command.Parameters.Add(new SqlParameter("@Title", news.Title));
                command.Parameters.Add(new SqlParameter("@Summary", news.Summary));
                command.Parameters.Add(new SqlParameter("@Content", news.Content));
                command.Parameters.Add(new SqlParameter("@Picture", news.Picture));
                command.Parameters.Add(new SqlParameter("@UserID", news.UserID));
                command.Parameters.Add(new SqlParameter("@CreationTime", news.CreationTime));
                command.Parameters.Add(new SqlParameter("@IssueDate", news.IssueDate));
                command.Parameters.Add(new SqlParameter("@IsAttach", news.IsAttach));
                command.Parameters.Add(new SqlParameter("@IsShow", news.IsShow));
                command.Parameters.Add(new SqlParameter("@StatusID", news.StatusID));
                command.Parameters.Add(new SqlParameter("@AllowSubmit", news.AllowSubmit));
                if (news.DeadlineSubmit == null)
                    command.Parameters.Add(new SqlParameter("@DeadlineSubmit", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@DeadlineSubmit", news.DeadlineSubmit));
                SqlParameter paramID = new SqlParameter("@ID", SqlDbType.Int, 4);
                paramID.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramID);
                connection.Open();
                command.ExecuteNonQuery();
                if (paramID.Value != DBNull.Value)
                    news.NewsID = (int)paramID.Value;
                else
                    news.NewsID = 0;
            }
        }
        public bool UpdateNews(tbl_News news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("spNewsUpdate", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@NewsID", news.NewsID));
                    command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                    command.Parameters.Add(new SqlParameter("@Title", news.Title));
                    command.Parameters.Add(new SqlParameter("@Summary", news.Summary));
                    command.Parameters.Add(new SqlParameter("@Content", news.Content));
                    command.Parameters.Add(new SqlParameter("@Picture", news.Picture));
                    //command.Parameters.Add(new SqlParameter("@UserID", news.UserID));
                    //command.Parameters.Add(new SqlParameter("@CreationTime", news.CreationTime));
                    //command.Parameters.Add(new SqlParameter("@IssueDate", news.IssueDate));
                    command.Parameters.Add(new SqlParameter("@IsAttach", news.IsAttach));
                    command.Parameters.Add(new SqlParameter("@IsShow", news.IsShow));
                    command.Parameters.Add(new SqlParameter("@AllowSubmit", news.AllowSubmit));
                    if(news.DeadlineSubmit == null)
                        command.Parameters.Add(new SqlParameter("@DeadlineSubmit", DBNull.Value));
                    else
                        command.Parameters.Add(new SqlParameter("@DeadlineSubmit", news.DeadlineSubmit));
                    //command.Parameters.Add(new SqlParameter("@StatusID", news.StatusID));
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
        public bool DeleteNews(tbl_News news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spNewsDelete", connection);
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

        public tbl_News GetNewsByID(string Procedure_Name, string thamso, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, ID));

                connection.Open();
                tbl_News news = null;
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
        public DataTable GetNewsById(string Procedure_Name, string Table_Name, int newsid)
        {

            return StoreToTable(Procedure_Name, Table_Name, newsid);

        }
        public List<tbl_News> GetListNewsByID(string Procedure_name, string thamso, int TypeID)
        {
            List<tbl_News> newsList = new List<tbl_News>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, TypeID));

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
        public DataTable GetNewsToTableByStore(string Procedure_Name, string Table_Name, int thamso1, int action)
        {

            return StoreToTable(Procedure_Name, Table_Name, thamso1, action);

        }
    }
}