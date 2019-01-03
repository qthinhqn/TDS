using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

interface IManagerReminder
{
    bool Reminder_L1();
    bool Reminder_L2();
    bool Reminder_L3();
    void clearReminder();
}


namespace MailServices
{
    class ManagerReminder : IManagerReminder
    {
        private string ConString = "";
        private string MailServer = "";
        private string MailAddress = "";
        private string UserName = "";
        private string Password = "";
        private int Port = 0;
        private string Uri = "";
        public ManagerReminder(string con, string mailserver, string mailaddress, string username, string pass, int port)
        {
            //ConString = "Data Source=NGT-PC\\SQLEXPRESS;Initial Catalog=PERFETTI;Integrated Security=True";
            ConString = con;
            MailServer = mailserver;
            MailAddress = mailaddress;
            UserName = username;
            Password = pass;
            Port = port;
        }

        public ManagerReminder(string con, string uri, string username, string pass)
        {
            //ConString = "Data Source=NGT-PC\\SQLEXPRESS;Initial Catalog=PERFETTI;Integrated Security=True";
            ConString = con;
            Uri = uri;
            UserName = username;
            Password = pass;
        }

        public bool Reminder_L1()
        {
            bool sent = true;
            string ManagerID_L1 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;

            //Xóa remind không hợp lệ
            //clearReminder();

            ArrayList arr = GetListManagerID_L1();
            if (arr.Count > 0)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    ManagerID_L1 = arr[i].ToString();
                    Subject = CreateContentForManager(ManagerID_L1, "1")[0].ToString();
                    Content = CreateContentForManager(ManagerID_L1, "1")[1].ToString();
                    EmailTo = GetEmployeeInfo(ManagerID_L1)[1].ToString();
                    if (EmailTo != null && Content != "")
                    {
                        //Đánh dấu đã gửi thành công vào database
                        if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                        {

                        }
                        //else
                        //{
                        //    sent = false;
                        //}
                    }
                    else
                    {
                        sent = false;
                    }
                }
            }

            return sent;
        }

        public bool Reminder_L2()
        {
            bool sent = true;
            string ManagerID_L2 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;

            //Xóa remind không hợp lệ
            //clearReminder();

            ArrayList arr = GetListManagerID_L2();
            if (arr.Count > 0)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    ManagerID_L2 = arr[i].ToString();
                    Subject = CreateContentForManager(ManagerID_L2, "2")[0].ToString();
                    Content = CreateContentForManager(ManagerID_L2, "2")[1].ToString();
                    EmailTo = GetEmployeeInfo(ManagerID_L2)[1].ToString();
                    if (EmailTo != null && Content != "")
                    {
                        //Đánh dấu đã gửi thành công vào database
                        if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                        {

                        }
                        //else
                        //{
                        //    sent = false;
                        //}
                    }
                    else
                    {
                        sent = false;
                    }
                }
            }


            return sent;
        }

        public bool Reminder_L3()
        {
            bool sent = true;
            string ManagerID_L3 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;

            //Xóa remind không hợp lệ
            //clearReminder();

            ArrayList arr = GetListManagerID_L3();
            if (arr.Count > 0)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    ManagerID_L3 = arr[i].ToString();
                    Subject = CreateContentForManager(ManagerID_L3, "3")[0].ToString();
                    Content = CreateContentForManager(ManagerID_L3, "3")[1].ToString();
                    EmailTo = GetEmployeeInfo(ManagerID_L3)[1].ToString();
                    if (EmailTo != null && Content != "")
                    {
                        //Đánh dấu đã gửi thành công vào database                        
                        if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                        {

                        }
                        //else
                        //{
                        //    sent = false;
                        //}
                    }
                    else
                    {
                        sent = false;
                    }
                }
            }
            return sent;
        }

        public ArrayList GetListManagerID_L1()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList();
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L1 from tblWebData Where MailToL1=2";
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrayList.Add(dt.Rows[i]["ManagerID_L1"]);

                }
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        public ArrayList GetListManagerID_L2()
        {
            //Noi dung code 
            ArrayList arrayList = new ArrayList(); ;
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L2 from tblWebData Where MailToL2=2";
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrayList.Add(dt.Rows[i]["ManagerID_L2"]);
                }
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        public ArrayList GetListManagerID_L3()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList(); ;
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L3 from tblWebData Where MailToL3=2";
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrayList.Add(dt.Rows[i]["ManagerID_L3"]);
                }
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        public bool SendMailToUserFromGmail(string emailTo, string subject, string contentToSend)
        {
            bool sent = false;
            MailProvider mailProvider = new MailProvider();
            //mailProvider.MailServerName = MailServer;
            //mailProvider.MailAddress = MailAddress;
            //mailProvider.Port = Port;

            if (mailProvider.IsEmail(emailTo))
            {
                if (string.IsNullOrEmpty(Uri))
                {
                    sent = mailProvider.SendMailFromGmail(emailTo, subject, contentToSend, UserName, Password);
                }
                else
                {
                    sent = mailProvider.SendMailFromExchange(emailTo, subject, contentToSend, UserName, Password, Uri);
                }
            }
            return sent;
        }

        private object getLeaveTypeName(object LeaveID)
        {
            object value = null;
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select LeaveType from tblRef_LeaveType where LeaveID = @LeaveID";
            provider.ParameterCollection = new string[] { "@LeaveID" };
            provider.ValueCollection = new object[] { LeaveID };
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                value = dt.Rows[0]["LeaveType"];
            }
            provider.CloseConnection();
            return value;
        }

        ArrayList CreateContentForManager(string ManagerID, string Level)
        {
            ArrayList arrayList = new ArrayList();
            string subject = "";
            string content = "";
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            DataTable dt;

            switch (Level)
            {
                case "1":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L1 = @ManagerID and MailToL1=2 and FinalStatus='w'";
                    break;
                case "2":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L2 = @ManagerID and MailToL2=2 and FinalStatus='w'";
                    break;
                case "3":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L3 = @ManagerID and MailToL3=2 and FinalStatus='w'";
                    break;
            }
            sqlProvider.ParameterCollection = new string[] { "@ManagerID" };
            sqlProvider.ValueCollection = new object[] { ManagerID };
            dt = sqlProvider.GetDataTable();
            subject = "Có " + dt.Rows.Count + " lượt đăng ký chờ phê duyệt (" + dt.Rows.Count + " submission has been applied for your approval) (reminder)";
            if (dt.Rows.Count > 0)
            {
                //Bat dau noi dung html
                content += "Dear <b>Anh</b>(Mr)/<b>Chị</b>(Ms),<br/><br/>";
                content += "Vui lòng thực hiện phê duyệt của những nhân viên có tên dưới đây.<br/>";
                content += "<em>Please give your approval on the employee’s request as below.</em><br/><br/>";

                content += "<table border=0 width=100%>";
                content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                content += "<td>Stt</td>";
                content += "<td>Mã NV</td>";
                content += "<td>Họ Tên</td>";
                content += "<td>Nội dung đăng ký</td>";
                content += "<td>Bắt đầu</td>";
                content += "<td>Kết thúc</td>";
                content += "<td>Tổng ngày</td>";
                content += "<td>Tổng giờ</td>";
                content += "</tr>";
                content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                content += "<td>No</td>";
                content += "<td>Employee ID</td>";
                content += "<td>Full Name</td>";
                content += "<td>Registration content</td>";
                content += "<td>Start Date</td>";
                content += "<td>Finish Date</td>";
                content += "<td>Days off</td>";
                content += "<td>Hours off</td>";
                content += "</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    content += "<tr>";
                    content += "<td style='text-align:center'>" + (i + 1) + "</td>";
                    content += "<td>" + dt.Rows[i]["EmployeeID"].ToString() + "</td>";
                    content += "<td>" + GetEmployeeInfo(dt.Rows[i]["EmployeeID"].ToString())[0].ToString() + "</td>";

                    if (getLeaveTypeName(dt.Rows[i]["LeaveID"]) != null)
                    {
                        content += "<td>" + getLeaveTypeName(dt.Rows[i]["LeaveID"]).ToString() + "</td>";
                    }
                    else
                    {
                        content += "<td>" + "" + "</td>";
                    }

                    object startdate = dt.Rows[i]["StartDate"];
                    object todate = dt.Rows[i]["ToDate"];
                    if (!startdate.ToString().Equals(""))
                    {
                        content += "<td style='text-align:center'>" + ((DateTime)dt.Rows[i]["StartDate"]).ToShortDateString() + "</td>";
                    }
                    else
                    {
                        content += "<td style='text-align:center'>" + "" + "</td>";
                    }

                    if (!todate.ToString().Equals(""))
                    {
                        content += "<td style='text-align:center'>" + ((DateTime)dt.Rows[i]["ToDate"]).ToShortDateString() + "</td>";
                    }
                    else
                    {
                        content += "<td style='text-align:center'>" + "" + "</td>";

                    }
                    content += "<td style='text-align:center'>" + dt.Rows[i]["TotalDays"].ToString() + "</td>";
                    object hours = dt.Rows[i]["TotalHours"];
                    if (!hours.ToString().Equals(""))
                    {
                        double dblhours = Math.Round(Convert.ToDouble(hours), 2);
                        content += "<td style='text-align:center'>" + dblhours.ToString() + "</td>";
                    }
                    else
                    {
                        content += "<td style='text-align:center'>" + hours.ToString() + "</td>";
                    }
                    content += "</tr>";
                }
                content += "</table>";

                content += "<br/><br/>";
                content += "Bạn có thể đăng nhập vào đường link dưới đây để đăng nhập vào Hệ thống phép online.<br/>";
                content += "<em>You are advised to click the link below to sign up for  the online Leave Request system.</em><br/><br/>";
                content += "<a href='https://hrmweb.vn.pvmgrp.com/eleave'>Click here</a>";

                //Ket thuc noi dung html

                //Them subject va content vao ArrayList
                arrayList.Add(subject);
                arrayList.Add(content);
            }
            else
            {
                arrayList.Add(subject);
                arrayList.Add(content);
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        public ArrayList GetEmployeeInfo(string EmployeeID)
        {
            ArrayList arrayList = new ArrayList();
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlProvider.CommandText = "Select EmployeeName, Email From tblEmployee Where EmployeeID = @EmployeeID";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                arrayList.Add(dt.Rows[0]["EmployeeName"]);
                arrayList.Add(dt.Rows[0]["Email"]);
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        public void clearReminder()
        {
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Select * from view_Reminder";
            DataTable dt = provider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    object id = dt.Rows[i]["ID"];

                    for (int k = 1; k < 4; k++)
                    {
                        object MailToL = dt.Rows[i]["MailToL" + k.ToString()];
                        object ApprovingStatus_L = dt.Rows[i]["ApprovingStatus_L" + k.ToString()];

                        if (!string.IsNullOrWhiteSpace(MailToL.ToString()) && !string.IsNullOrWhiteSpace(ApprovingStatus_L.ToString()))
                        {
                            if ((MailToL.ToString().Equals("2") || MailToL.ToString().Equals("1")) && (Convert.ToBoolean(ApprovingStatus_L) == true || Convert.ToBoolean(ApprovingStatus_L) == false))
                            {
                                provider.CommandText = "Update tblWebData set MailToL" + k.ToString() + " = '0' where ID = @id";
                                provider.ParameterCollection = new string[] { "@id" };
                                provider.ValueCollection = new object[] { id };
                                provider.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            provider.CloseConnection();
        }

    }
}
