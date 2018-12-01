using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PAOL.UserControl
{
    class tblUserSubmitNews
    {

        public tblUserSubmitNews()
        {
            newsid = 0;
            userID = "";
            submitDate = "";
            submitFile = "";
        }

        public tblUserSubmitNews(string ketnoi)
        {
            // TODO: Complete member initialization
            this.ConString = ketnoi;
        }
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        private long newsid;
        public long NewsID
        {
            get { return newsid; }
            set { newsid = value; }
        }
        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private string submitDate;
        public string SubmitDate
        {
            get { return submitDate; }
            set { submitDate = value; }
        }
        private string submitFile;
        public string SubmitFile
        {
            get { return submitFile; }
            set { submitFile = value; }
        }

        private string ConString;

        public int insertNewSubmit(object empid, object newsid, object submitfile)
        {
            int value = 0;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "INSERT INTO [dbo].[tblUserSubmitNews]"
                    + " ([UserID],[NewsID],[SubmitDate],[SubmitFile]"
                    + " ,[IsPrivate],[TypeID],[StatusID],[Title])"
                    + " Values (@UserID, @NewsID, getdate(), @SubmitFile);"
                    + " SELECT CAST(scope_identity() AS int);";
                provider.ParameterCollection = new string[] { "@UserID", "@NewsID", "@SubmitFile" };
                provider.ValueCollection = new object[] { empid, newsid, submitfile };
                value = int.Parse(provider.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
            }
            provider.CloseConnection();
            return value;
        }

        public System.Data.DataTable getSubmit()
        {
            DataTable dt = new DataTable();
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "SELECT * FROM [tblUserSubmitNews]"
                    + " WHERE [NewsID] = @NewsID and [UserID] = @UserID";
                provider.CommandType = CommandType.Text;
                provider.ParameterCollection = new string[] { "@NewsID", "@UserID" };
                provider.ValueCollection = new object[] { this.newsid, this.userID };

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
    }
}