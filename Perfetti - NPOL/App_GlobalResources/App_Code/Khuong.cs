using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;

namespace NPOL
{
    public class Khuong
    {
        public Khuong()
        {
            
        }

        public Khuong(string ConnectionString)
        {
            con = ConnectionString;
        }
        private string con = null;

        public string getDecryptConString()
        {
            string EncryptedConString = "";

            //Load from xml file
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("MailInfo.xml"));
            EncryptedConString = (xmlDoc.DocumentElement.SelectSingleNode("//ConString").InnerText).Trim();
            string returnConString = DecryptConPassString(EncryptedConString);

            return returnConString;
        }

        public ArrayList getManagerIDList(string TableName, ArrayList ManagerColumnNames, string EmployeeID)
        {
            ArrayList returnList = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            string sql = "";
            try
            {
                sql = "Select top 1 * from " + TableName + " where EmployeeID = @EmployeeID order by DateChange desc;";
                provider.CommandText = sql;
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < ManagerColumnNames.Count; i++)
                    {
                        returnList.Add(dt.Rows[0][ManagerColumnNames[i].ToString()]);
                    }
                }
            }
            catch
            {
                returnList = null;
            }
            provider.CloseConnection();
            return returnList;
        }
        public bool IsLogin(string username, string password)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            string UserName = null;
            string Password = null;

            try
            {

                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID And (LeftDate is null Or LeftDate >= getdate())";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { username };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["EmployeeID"].ToString();
                    Password = dt.Rows[0]["Logon_Password"].ToString();
                    password = new SecurityProvider().RCVEncPwd(password);
                    if (String.Compare(username, UserName, true) == 0 & String.Compare(password, Password, false) == 0)
                    {
                        returnValue = true;
                    }
                }

            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }
        public bool IsLeft(string username)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;

            try
            {

                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID And LeftDate is not null And LeftDate < getdate()";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { username };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    returnValue = true;
                }

            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool 
            IsAdminLogin(string username, string password)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            Khuong kh = new Khuong(con);
            DataTable dt;
            string UserName = null;
            string Password = null;
            ArrayList result = new ArrayList();
            try
            {
                provider.CommandText = "Select * from tblUser where UserName = @UserName and RoleID = 'Special'";
                provider.ParameterCollection = new string[] { "@UserName" };
                provider.ValueCollection = new object[] { username };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["UserName"].ToString();
                    Password = dt.Rows[0]["Password"].ToString();
                    //Encrypt password
                    provider.CommandText = "sp_EnCode";
                    provider.CommandType = CommandType.StoredProcedure;
                    provider.ParameterCollection = new string[] { "@Password" };
                    provider.ValueCollection = new object[] { password };
                    provider.OutputParameterCollection = new string[] { "@Encrypt_Pass" };
                    provider.OutputDbTypeCollection = new SqlDbType[] { SqlDbType.NVarChar };
                    provider.OutputFieldsizeCollection = new int[] { 100 };
                    result = provider.OutputExecuteNonQuery();
                    password = result[0].ToString();

                    if (Password.Equals("p"))
                    {
                        if (String.Compare(username, password, true) == 0)
                        {
                            returnValue = true;
                        }
                    }
                    else
                    {
                        if (String.Compare(username, UserName, true) == 0 && String.Compare(password, Password, true) == 0)
                        {
                            returnValue = true;
                        }
                    }

                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public string IsApprovalManager(string TableName, ArrayList ManagerColumnNames, string EmployeeID)
        {
            string returnValue = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            string sql = "";
            try
            {

                for (int i = 0; i < ManagerColumnNames.Count; i++)
                {
                    sql = "Select top 1 * from " + TableName + " where " + ManagerColumnNames[i].ToString() + " = @EmployeeID order by DateChange desc;";
                    provider.CommandText = sql;
                    provider.ParameterCollection = new string[] { "@EmployeeID" };
                    provider.ValueCollection = new object[] { EmployeeID };
                    dt = provider.GetDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        returnValue = ManagerColumnNames[i].ToString();
                        break;
                    }
                }

            }
            catch
            {
                returnValue = null;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsEmployee(string EmployeeID)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select top 1 * from tblEmpManagerLevel where EmployeeID = @EmployeeID order by DateChange desc;";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                if (dt.Rows.Count <= 0)
                {
                    returnValue = false;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsEmployeeOrigin(string EmployeeID)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                if (dt.Rows.Count <= 0)
                {
                    returnValue = false;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsNewEmployee(string EmployeeID)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {                    
                    returnValue = Convert.ToBoolean(dt.Rows[0]["Logon_IsNew"].ToString());
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsAdmin(string EmployeeID)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblUser where UserName = @UserName and RoleID = @RoleID";
                provider.ParameterCollection = new string[] { "@UserName", "RoleID" };
                provider.ValueCollection = new object[] { EmployeeID, "special" };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    returnValue = true;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsEmail(string inputEmail)
        {
            if (inputEmail == null | inputEmail.Length > 35) return false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            return (re.IsMatch(inputEmail));
        }

        public string getEmployeeID(string inputEmail)
        {
            string empid = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where Logon_Email = @Logon_Email";
                provider.ParameterCollection = new string[] { "@Logon_Email" };
                provider.ValueCollection = new object[] { inputEmail };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    empid = dt.Rows[0]["EmployeeID"].ToString();
                }
            }
            catch
            {
                empid = null;
            }
            provider.CloseConnection();
            return empid;
        }

        public string getEmpEmail(string EmployeeID)
        {
            string email = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    email = dt.Rows[0]["Email"].ToString();
                }
            }
            catch { email = null; }
            provider.CloseConnection();
            return email;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private string RandomString(int size, bool lowerCase)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string GetRandomPassword()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        public string getEmpID(string Email)
        {
            string empid = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where Logon_Email = @Logon_Email";
                provider.ParameterCollection = new string[] { "@Logon_Email" };
                provider.ValueCollection = new object[] { Email };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    empid = dt.Rows[0]["EmployeeID"].ToString();
                }
            }
            catch { empid = null; }
            provider.CloseConnection();
            return empid;
        }

        public bool UpdatePassword(string pass, string employeeid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                provider.CommandText = "Update tblEmployee Set Logon_Password = @Logon_Password Where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@Logon_Password", "@EmployeeID" };
                provider.ValueCollection = new object[] { new SecurityProvider().RCVEncPwd(pass), employeeid };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                {
                    returnValue = true;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public string getEncryptPassAdmin(string pass)
        {
            string encryptpass = null;
            ArrayList result = new ArrayList();
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                //Encrypt password
                provider.CommandText = "sp_EnCode";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@Password" };
                provider.ValueCollection = new object[] { pass };
                provider.OutputParameterCollection = new string[] { "@Encrypt_Pass" };
                provider.OutputDbTypeCollection = new SqlDbType[] { SqlDbType.NVarChar };
                provider.OutputFieldsizeCollection = new int[] { 100 };
                result = provider.OutputExecuteNonQuery();
                encryptpass = result[0].ToString();
            }
            catch { encryptpass = null; }
            provider.CloseConnection();
            return encryptpass;
        }

        public bool UpdatePasswordAdmin(string pass, string employeeid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                //Update encrypt pass into tblUser
                provider.CommandText = "Update tblUser Set [Password] = @Password Where UserName = @UserName";
                provider.CommandType = CommandType.Text;
                provider.ParameterCollection = new string[] { "@Password", "@UserName" };
                provider.ValueCollection = new object[] { pass, employeeid };
                int i = provider.ExecuteNonQuery();
                if (i > 0)
                {
                    returnValue = true;
                }
            }
            catch
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool SendMail(string MailTo, string Subject, string Content)
        {
            bool returnValue = false;
            string UserName = null;
            string PassWord = null;
            string Uri = null;
            try
            {
                //Read XML
                XmlDocument xmlDoc = new XmlDocument();
                String path = System.Web.HttpContext.Current.Server.MapPath("MailInfo.xml");
                xmlDoc.Load(path);
                UserName = (xmlDoc.DocumentElement.SelectSingleNode("//UserName").InnerText).Trim();
                PassWord = new SecurityProvider().RCVDecPwd((xmlDoc.DocumentElement.SelectSingleNode("//Password").InnerText).Trim());
                Uri = (xmlDoc.DocumentElement.SelectSingleNode("//Uri").InnerText).Trim();
                MailProvider mailProvider = new MailProvider();
                returnValue = mailProvider.SendMailFromExchange(MailTo, Subject, Content, UserName, PassWord, Uri);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        public string getEmployeeName(string EmployeeID)
        {
            string value = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            if (IsEmployee(EmployeeID))
            {
                provider.CommandText = "Select EmployeeName from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                value = provider.GetDataTable().Rows[0]["EmployeeName"].ToString();
            }
            else
            {
                value = EmployeeID;
            }
            provider.CloseConnection();
            return value;
        }

        private static string EncryptConPassString(string ConnectionString)
        {
            string returnValue = "";
            string conpass = ConnectionString.Substring(ConnectionString.IndexOf("Password") + 9);
            if (conpass.Equals(""))
            {
                returnValue = ConnectionString;
            }
            else
            {
                returnValue = ConnectionString.Substring(0, ConnectionString.IndexOf("Password") + 9) + new SecurityProvider().RCVEncPwd(conpass);
            }
            return returnValue;
        }

        private static string DecryptConPassString(string ConnectionString)
        {
            string returnValue = "";
            string conpass = ConnectionString.Substring(ConnectionString.IndexOf("Password") + 9);
            if (conpass.Equals(""))
            {
                returnValue = ConnectionString;
            }
            else
            {
                returnValue = ConnectionString.Substring(0, ConnectionString.IndexOf("Password") + 9) + new SecurityProvider().RCVDecPwd(conpass);
            }
            return returnValue;
        }

        
    }
}