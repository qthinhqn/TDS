using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace MailServices
{
    class Fix_ApprovalMail
    {
        private string ConString = "";
        private string UserName = "";
        private string Password = "";
        private string Uri = "";

        private string MailServer = "";
        private string MailAddress = "";
        private int Port = 0;

        public Fix_ApprovalMail(string con, string mailserver, string mailaddress, string username, string pass, int port)
        {
            //ConString = "Data Source=NGT-PC\\SQLEXPRESS;Initial Catalog=PERFETTI;Integrated Security=True";
            ConString = con;
            MailServer = mailserver;
            MailAddress = mailaddress;
            UserName = username;
            Password = pass;
            Port = port;
        }

        public Fix_ApprovalMail(string con, string uri, string username, string pass)
        {
            ConString = con;
            Uri = uri;
            UserName = username;
            Password = pass;
        }

        string[] ManagerIDList = new string[] { "0103120" };

        #region My Functions
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
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L1 = @ManagerID and MailToL1 = 1 and FinalStatus = 'w'";
                    break;
                case "2":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L2 = @ManagerID and MailToL2 = 1 and FinalStatus = 'w'";
                    break;
                case "3":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L3 = @ManagerID and MailToL3 = 1 and FinalStatus = 'w'";
                    break;
            }

            sqlProvider.ParameterCollection = new string[] { "@ManagerID" };
            sqlProvider.ValueCollection = new object[] { ManagerID };
            dt = sqlProvider.GetDataTable();
            subject = "Có " + dt.Rows.Count + " lượt đăng ký chờ phê duyệt (" + dt.Rows.Count + " submission has been applied for your approval)";
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
                content += "<em>You are advised to click the link below to sign up for the online Leave Request system.</em><br/><br/>";
                content += "<a href='https://hrmweb.vn.pvmgrp.com/eleave'>Click here</a>";

                //Ket thuc noi dung html

                //Them subject va content vao ArrayList
                arrayList.Add(subject);
                arrayList.Add(content);
                arrayList.Add(dt.Rows.Count);
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

        void MarkEmailSent(string ManagerID, string Level)
        {
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            if (Level == "1")
            {
                sqlProvider.CommandText = "Update tblWebData Set MailToL1=2 Where ManagerID_L1 = @ManagerID_L1 and MailToL1=1";
                sqlProvider.ParameterCollection = new string[] { "@ManagerID_L1" };
                sqlProvider.ValueCollection = new object[] { ManagerID };
                sqlProvider.ExecuteNonQuery();
            }

            if (Level == "2")
            {
                sqlProvider.CommandText = "Update tblWebData Set MailToL2=2 Where ManagerID_L2 = @ManagerID_L2 and MailToL2=1";
                sqlProvider.ParameterCollection = new string[] { "@ManagerID_L2" };
                sqlProvider.ValueCollection = new object[] { ManagerID };
                sqlProvider.ExecuteNonQuery();
            }

            if (Level == "3")
            {
                sqlProvider.CommandText = "Update tblWebData Set MailToL3=2 Where ManagerID_L3 = @ManagerID_L3 and MailToL3=1";
                sqlProvider.ParameterCollection = new string[] { "@ManagerID_L3" };
                sqlProvider.ValueCollection = new object[] { ManagerID };
                sqlProvider.ExecuteNonQuery();
            }
            sqlProvider.CloseConnection();
        }
        #endregion

        public bool SenMailToManager(string ManagerLevel)
        {
            bool sent = false;
            try
            {
                switch (ManagerLevel)
                {
                    case "1":
                        #region Gửi mail cho quản lý cấp 1
                        if (ManagerIDList.Count() > 0)
                        {
                            foreach (string m1 in ManagerIDList)
                            {
                                string subject = CreateContentForManager(m1, "1")[0].ToString();
                                string content = CreateContentForManager(m1, "1")[1].ToString();
                                object count = CreateContentForManager(m1, "1")[2];
                                string email = GetEmployeeInfo(m1)[1].ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(email))
                                {
                                    if (Convert.ToInt32(count) > 0)
                                    {
                                        if (SendMailToUserFromGmail(email, subject, content))
                                        {
                                            MarkEmailSent(m1, "1");
                                            sent = true;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        break;

                    case "2":
                        #region Gửi mail cho quản lý cấp 2
                        if (ManagerIDList.Count() > 0)
                        {
                            foreach (string m1 in ManagerIDList)
                            {
                                string subject = CreateContentForManager(m1, "2")[0].ToString();
                                string content = CreateContentForManager(m1, "2")[1].ToString();
                                object count = CreateContentForManager(m1, "2")[2];
                                string email = GetEmployeeInfo(m1)[1].ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(email))
                                {
                                    if (Convert.ToInt32(count) > 0)
                                    {
                                        if (SendMailToUserFromGmail(email, subject, content))
                                        {
                                            MarkEmailSent(m1, "2");
                                            sent = true;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        break;

                    case "3":
                        #region Gửi mail cho quản lý cấp 3
                        if (ManagerIDList.Count() > 0)
                        {
                            foreach (string m1 in ManagerIDList)
                            {
                                string subject = CreateContentForManager(m1, "3")[0].ToString();
                                string content = CreateContentForManager(m1, "3")[1].ToString();
                                object count = CreateContentForManager(m1, "3")[2];
                                string email = GetEmployeeInfo(m1)[1].ToString().Trim();
                                if (!string.IsNullOrWhiteSpace(email))
                                {
                                    if (Convert.ToInt32(count) > 0)
                                    {
                                        if (SendMailToUserFromGmail(email, subject, content))
                                        {
                                            MarkEmailSent(m1, "3");
                                            sent = true;
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        break;
                }
            }
            catch
            {
                sent = false;
            }

            return sent;
        }
    }
}
