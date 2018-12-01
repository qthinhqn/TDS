using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPOL.UserControl
{
    public class tbl_SubmitNews
    {
        private string ConString = "";

        public tbl_SubmitNews(string constring)
        {
            ConString = constring;
        }
        public bool insertSubmitNews(object newsID, object empid)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "INSERT INTO [dbo].[tbl_SubmitNews] ([NewsID],[SubmitUser],[Status]) "
                        + "VALUES (@NewsID,'W',(Select ManagerID From tblEmpManagerNews Where EmployeeID=@EmployeeID));";
                provider.ParameterCollection = new string[] { "@NewsID", "@EmployeeID" };
                provider.ValueCollection = new object[] { newsID, empid };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                    value = true;
            }
            catch (Exception ex)
            {
            }
            provider.CloseConnection();
            return value;
        }

        public bool updateSubmitNews(object newsID, object status, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "UPDATE [dbo].[tbl_SubmitNews] SET "
                        + "Status=@Status, SubmitDate=getdate(), Reason=@Reason "
                        + "Where NewsID=@NewsID;";
                provider.ParameterCollection = new string[] { "@NewsID", "@Status", "@Reason" };
                provider.ValueCollection = new object[] { newsID, status, reason };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                    value = true;
            }
            catch (Exception ex)
            {
            }
            provider.CloseConnection();
            return value;
        }

        public bool updateSubmitNews_HR(object newsID, object status, object reason)
        {
            bool value = false;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            try
            {
                provider.CommandText = "UPDATE [dbo].[tbl_SubmitNews] SET "
                        + "Status=@Status, SubmitDate=getdate(), Reason=@Reason, HRSubmit=1 "
                        + "Where NewsID=@NewsID;";
                provider.ParameterCollection = new string[] { "@NewsID", "@Status", "@Reason" };
                provider.ValueCollection = new object[] { newsID, status, reason };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                    value = true;
            }
            catch (Exception ex)
            {
            }
            provider.CloseConnection();
            return value;
        }
    }
}
