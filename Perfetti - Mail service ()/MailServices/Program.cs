using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;


namespace MailServices
{
    class Program
    {

        static void Main(string[] args)
        {
            string ConString = "";
            //string MailServer = "";
            //string MailAddress = "";
            string UserName = "";
            string Pass = "";
            //int Port = 0;
            string Uri = "";

            //Call ham GetData() start
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("MailInfo.xml");
            //MailServer = (xmlDoc.DocumentElement.SelectSingleNode("//Server").InnerText).Trim();
            //MailAddress = (xmlDoc.DocumentElement.SelectSingleNode("//Address").InnerText).Trim();            
            //string strPort = (xmlDoc.DocumentElement.SelectSingleNode("//Port").InnerText).Trim();
            //Port = Convert.ToInt32(strPort);
            UserName = (xmlDoc.DocumentElement.SelectSingleNode("//UserName").InnerText).Trim();
            Pass = (xmlDoc.DocumentElement.SelectSingleNode("//Password").InnerText).Trim();
            ConString = (xmlDoc.DocumentElement.SelectSingleNode("//ConString").InnerText).Trim();
            ConString = DecryptConPassString(ConString);
            Uri = (xmlDoc.DocumentElement.SelectSingleNode("//Uri").InnerText).Trim();
            if (Pass.Equals(""))
            {
                Pass = "";
            }
            else
            {
                Pass = new SecurityProvider().RCVDecPwd(Pass);
            }
            //End GetData()

            //IUserAlert userAlert = new UserAlert(ConString, MailServer, MailAddress, MailAddress, Pass, Port);
            IUserAlert userAlert = new UserAlert(ConString, Uri, UserName, Pass);
            IManagerReminder reminder = new ManagerReminder(ConString, Uri, UserName, Pass);
            Fix_ApprovalMail fix = new Fix_ApprovalMail(ConString, Uri, UserName, Pass);
            Console.WriteLine("Start to send email...");
            //userAlert.SendMonthlyRemainLeave();

            //if (MailServer == "smtp.gmail.com")
            //{
            //    userAlert = new UserAlert(ConString, MailServer, MailAddress, MailAddress, Pass, Port);
            //    reminder = new ManagerReminder(ConString, MailServer, MailAddress, MailAddress, Pass, Port);
            //    fix = new Fix_ApprovalMail(ConString, MailServer, MailAddress, MailAddress, Pass, Port);
            //}

            //if (args.Length == 0)
            //{
            //    LogTrace.LogTraceProvider logTrace = new LogTrace.LogTraceProvider();
            //    logTrace.WriteErrorToLogFile(logTrace.LogFolderName);
            //    logTrace.WriteErrorToLogFile("Start log.");

            //    userAlert.SendEmailTest();
            //    logTrace.WriteErrorToLogFile("End log.");
            //    return;
            //}
            try
            {
                string type = args[0];
                switch (type)
                {
                    case "M1":
                        userAlert.SendEmailToManager_L1();
                        break;

                    case "M2":
                        userAlert.SendEmailToManager_L2();
                        break;

                    case "M3":
                        userAlert.SendEmailToManager_L3();
                        break;

                    case "E":
                        userAlert.SendEmailToEmployee();
                        break;

                    case "L":
                        userAlert.SendMonthlyRemainLeave();
                        break;

                    case "R1":
                        reminder.Reminder_L1();
                        break;

                    case "R2":
                        reminder.Reminder_L2();
                        break;

                    case "R3":
                        reminder.Reminder_L3();
                        break;

                    case "R4":
                        reminder.clearReminder();
                        break;

                    case "L0":
                        userAlert.LoadAL();
                        break;

                    case "F1":
                        fix.SenMailToManager("1");
                        break;

                    case "F2":
                        fix.SenMailToManager("2");
                        break;

                    case "F3":
                        fix.SenMailToManager("3");
                        break;

                    case "ID":
                        userAlert.SenMailIndependenceDay();
                        break;
                }
            }
            catch (Exception ex)
            {
                WriteErrorToFile(ex);
            }            
        }    


        private static void WriteErrorToFile(Exception ex)
        {            
            try
            {
                LogTrace.LogTraceProvider logTrace = new LogTrace.LogTraceProvider();
                logTrace.WriteErrorToLogFile(ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch
            {

            }

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
