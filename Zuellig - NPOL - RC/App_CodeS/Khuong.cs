using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using System.Security.Cryptography;
using NPOL.App_Code.Business;
using System.Text;

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

                provider.CommandText = "Select * from tblEmployee_Online where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { username };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["EmployeeID"].ToString();
                    Password = dt.Rows[0]["EPassword"].ToString();
                    //Password = dt.Rows[0]["PayslipPassword"].ToString();
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

        public bool IsLogin_PayslipPass(string username, string password)
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
                    //Password = dt.Rows[0]["EPassword"].ToString();
                    Password = dt.Rows[0]["PayslipPassword"].ToString();
                    //password = new SecurityProvider().RCVEncPwd(password);
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

        public bool IsLogin_v2(string username, string password)
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
                    //Password = dt.Rows[0]["Logon_Password"].ToString();
                    Password = dt.Rows[0]["PayslipPassword"].ToString();
                    //password = new SecurityProvider().RCVEncPwd(password);
                    //Encrypt password
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = Utility.GetMd5Hash(md5Hash, password);
                        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                        if (0 == comparer.Compare(Password, hash))
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

        public bool IsAdminLogin(string username, string password)
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

        public bool IsAdminLogin_v2(string username, string password)
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
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = Utility.GetMd5Hash(md5Hash, password);
                        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                        if (Password.Equals("p"))
                        {
                            if (String.Compare(username, password, true) == 0)
                            {
                                returnValue = true;
                            }
                        }
                        else
                        {
                            if (0 == comparer.Compare(Password, hash))
                            {
                                returnValue = true;
                            }
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

        public bool IsEmployeeKPI(string EmployeeID)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select top 1 * from tblKPIManagerLevel where EmployeeID = @EmployeeID order by DateChange desc;";
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

        public bool IsExistsEmployeeRecruit(string EmployeeID)
        {
            bool returnValue = true;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select top 1 * from tblRecruitManagerLevel where EmployeeID = @EmployeeID order by DateChange desc;";
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
                provider.CommandText = "Select * from tblEmployee where PayslipEmail = @Logon_Email";
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

        //public string getEmpEmail(string EmployeeID)
        //{
        //    string email = null;
        //    khSqlServerProvider provider = new khSqlServerProvider(con);
        //    DataTable dt;
        //    try
        //    {
        //        provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
        //        provider.ParameterCollection = new string[] { "@EmployeeID" };
        //        provider.ValueCollection = new object[] { EmployeeID };
        //        dt = provider.GetDataTable();
        //        if (dt.Rows.Count > 0)
        //        {
        //            email = dt.Rows[0]["Email"].ToString();
        //        }
        //    }
        //    catch { email = null; }
        //    provider.CloseConnection();
        //    return email;
        //}

        public string getEmpPayslipEmail(string EmployeeID)
        {
            string email = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID And (LeftDate is null Or LeftDate >= getdate())";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    email = dt.Rows[0]["PayslipEmail"].ToString();
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
            int maxSize = 8;
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public string getEmpID(string Email)
        {
            string empid = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where PayslipEmail = @Logon_Email";
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

        public bool UpdatePayslipPassword(string pass, string employeeid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                provider.CommandText = "Update tblEmployee Set PayslipPassword = @Logon_Password Where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@Logon_Password", "@EmployeeID" };
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
        public bool UpdateEPassword(string pass, string employeeid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                provider.CommandText = "Update tblEmployee_Online Set EPassword = @Logon_Password Where EmployeeID = @EmployeeID";
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

        public bool UpdatePasswordEmail(string pass, string employeeid)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                provider.CommandText = "Update tblEmployee Set PayslipPassword = @Password Where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@Password", "@EmployeeID" };
                //provider.ValueCollection = new object[] { new SecurityProvider().RCVEncPwd(pass), employeeid };
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

        public string getEncryptPassAdmin_v2(string pass)
        {
            string encryptpass = null;
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    encryptpass = Utility.GetMd5Hash(md5Hash, pass);
                }
            }
            catch { encryptpass = null; }
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
            string server = null;
            string MailAddress = "";
            string UserName = null;
            string PassWord = null;
            string Uri = null;
            try
            {
                //Read XML
                XmlDocument xmlDoc = new XmlDocument();
                String path = System.Web.HttpContext.Current.Server.MapPath("MailInfo.xml");
                xmlDoc.Load(path);
                server = (xmlDoc.DocumentElement.SelectSingleNode("//Server").InnerText).Trim();
                MailAddress = (xmlDoc.DocumentElement.SelectSingleNode("//Address").InnerText).Trim();
                string strPort = (xmlDoc.DocumentElement.SelectSingleNode("//Port").InnerText).Trim();

                UserName = (xmlDoc.DocumentElement.SelectSingleNode("//UserName").InnerText).Trim();
                PassWord = new SecurityProvider().RCVDecPwd((xmlDoc.DocumentElement.SelectSingleNode("//Password").InnerText).Trim());
                Uri = (xmlDoc.DocumentElement.SelectSingleNode("//Uri").InnerText).Trim();
                MailProvider mailProvider = new MailProvider();
                mailProvider.MailAddress = MailAddress;
                mailProvider.Port = (String.IsNullOrEmpty(strPort) ? 0 : int.Parse(strPort));

                if (server.ToLower() == "gmail")
                {
                    returnValue = mailProvider.SendMailFromGmail(MailTo, Subject, Content, UserName, PassWord);
                }
                else
                {
                    returnValue = mailProvider.SendMailFromExchange(MailTo, Subject, Content, UserName, PassWord, Uri);
                }
            }
            catch (Exception ex)
            {
                MyLogs.LogError(ex);
                returnValue = false;
            }
            return returnValue;
        }

        public string getEmployeeName(string EmployeeID)
        {
            string value = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            if (IsEmployeeOrigin(EmployeeID))
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


        public string getWorkingEmployeeName(string EmployeeID)
        {
            string value = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            if (IsEmployeeOrigin(EmployeeID))
            {
                provider.CommandText = "Select EmployeeName from tblEmployee where EmployeeID = @EmployeeID And (LeftDate is null OR Leftdate > getdate())";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt != null && dt.Rows.Count == 1)
                    value = dt.Rows[0]["EmployeeName"].ToString();
                else
                    value = "";
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



        public string GetCurrentPassword(string UserName)
        {
            string pass = null;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblEmployee where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { UserName };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    pass = dt.Rows[0]["PayslipPassword"].ToString();
                }
            }
            catch { pass = null; }
            provider.CloseConnection();
            return pass;
        }

        public string InsertAutoCode(string randompass, string username)
        {
            string returnValue = randompass;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            try
            {
                provider.CommandText = "sp_CreateAutoCode";
                provider.CommandType = CommandType.StoredProcedure;
                provider.ParameterCollection = new string[] { "@AutoCode", "@EmpID" };
                provider.ValueCollection = new object[] { new SecurityProvider().RCVEncPwd(randompass), username };
                provider.OutputParameterCollection = new string[] { "@OutputCode" };
                provider.OutputDbTypeCollection = new SqlDbType[] { SqlDbType.NVarChar };
                provider.OutputFieldsizeCollection = new int[] { 100 };

                ArrayList result = new ArrayList();
                result = provider.OutputExecuteNonQuery();

                if (result != null && result.Count > 0)
                {
                    //returnValue = result[0].ToString();
                    returnValue = new SecurityProvider().RCVDecPwd(result[0].ToString());
                }
            }
            catch(Exception ex)
            {
                returnValue = "";
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsUseAutoCode(string autoCode, string username)
        {
            autoCode = new SecurityProvider().RCVEncPwd(autoCode);
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            string UserName = null;
            string Password = null;

            try
            {

                provider.CommandText = "Select EmployeeID, AutoCode from tblEmployee_AutoCode where EmployeeID = @EmployeeID"
                                     + " And [IsUsed] is null And convert(nvarchar(10),getdate(),103)=convert(nvarchar(10),CreatedDate,103)";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { username };
                dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    UserName = dt.Rows[0]["EmployeeID"].ToString();
                    Password = dt.Rows[0]["AutoCode"].ToString();
                    if (String.Compare(username, UserName, true) == 0 & String.Compare(autoCode, Password, false) == 0)
                    {
                        returnValue = true;
                    }
                }

            }
            catch(Exception ex)
            {
                returnValue = false;
            }
            provider.CloseConnection();
            return returnValue;
        }

        public bool IsShowCheckedLevel3(string EmployeeID)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblUserHRManager where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID};
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

        internal bool isPARole(string EmployeeID)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblKPIManagerLevel where @EmployeeID in (EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3);";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
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

        internal bool isRCRole(string EmployeeID)
        {
            bool returnValue = false;
            khSqlServerProvider provider = new khSqlServerProvider(con);
            DataTable dt;
            try
            {
                provider.CommandText = "Select * from tblRecruitManagerLevel where @EmployeeID in (EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3);";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
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
    }
}