using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NPOL.UserControl
{
    public class tbl_News
    {
        private string ConString = "";

        public tbl_News(string constring)
        {
            ConString = constring;
        }
        public int insertNews(object empid, object issuedate, object summary, object content, object isattach, object isprivate, object title)
        {
            int value = 0;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "INSERT INTO [dbo].[tbl_News]" 
                    + " ([UserID],[CreateDate],[IssueDate],[Summary],[Content],[IsAttach]"
                    + " ,[IsPrivate],[TypeID],[StatusID],[Title])"
                    + " Values (@, getdate(), @IssueDate, @Summary, @Content, @IsAttach, @IsPrivate, 'I', 0, @Title);"
                    + " SELECT CAST(scope_identity() AS int);";
                provider.ParameterCollection = new string[] { "@EmployeeID", "@IssueDate", "@Summary", "@Content", "@IsAttach", "@IsPrivate", "@Title" };
                provider.ValueCollection = new object[] { empid, issuedate, summary, content, isattach, isprivate, title };
                value = int.Parse( provider.ExecuteScalar().ToString() );
            }
            catch (Exception ex)
            {
            }
            provider.CloseConnection();
            return value;
        }

        public DataTable GetCacbaiVietKhac(long newsID, int type)
        {
            DataTable dt = new DataTable();
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "spNewsOthers";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@NewsID", "@Action" };
                provider.ValueCollection = new object[] { newsID, type };
                
                dt = provider.GetDataTable();
            }
            catch (Exception ex)
            {
                dt = null;
            }
            finally
            {
            }
            return dt;
        }
        /*
        public static List<News> GetNewsByIDParent(int IDParent)
        {
            return GetListNewsByID("spGetNewsByIDParent", "@IDParent", IDParent);

        }

        public List<News> GetListNewsByID(string Procedure_name, string thamso, int ID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_name, connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter(thamso, ID));

                connection.Open();
                List<News> newsList = new List<News>();
                using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        newsList.Add(CreateNewsFromReader(reader));
                    }
                }
                return newsList;
            }
        }*/
    }
}
