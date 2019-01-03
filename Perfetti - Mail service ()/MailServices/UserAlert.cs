using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


interface IUserAlert
{
    bool SendEmailToManager_L1();
    bool SendEmailToManager_L2();
    bool SendEmailToManager_L3();
    bool SendEmailToEmployee();
    bool SendEmailTest();
    bool SendMonthlyRemainLeave();
    bool SenMailIndependenceDay();
    void LoadAL();
}


namespace MailServices
{
    public class UserAlert : IUserAlert
    {
        private string ConString = "";
        private string MailServer = "";
        private string MailAddress = "";
        private string UserName = "";
        private string Password = "";
        private int Port = 0;
        private string Uri = "";
        public UserAlert(string con, string mailserver, string mailaddress, string username, string pass, int port)
        {
            //ConString = "Data Source=NGT-PC\\SQLEXPRESS;Initial Catalog=PERFETTI;Integrated Security=True";
            ConString = con;
            MailServer = mailserver;
            MailAddress = mailaddress;
            UserName = username;
            Password = pass;
            Port = port;
        }

        public UserAlert(string con, string uri, string username, string pass)
        {
            ConString = con;
            Uri = uri;
            UserName = username;
            Password = pass;
        }

        public bool SendEmailToManager_L1()
        {
            bool sent = false;
            string ManagerID_L1 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListManagerID_L1();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        ManagerID_L1 = arr[i].ToString();
                        Subject = CreateContentForManager(ManagerID_L1, "1")[0].ToString();
                        Content = CreateContentForManager(ManagerID_L1, "1")[1].ToString();
                        EmailTo = GetEmployeeInfo(ManagerID_L1)[1].ToString();
                        if (EmailTo != null)
                        {
                            //Đánh dấu đã gửi thành công vào database
                            if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                            {
                                MarkEmailSent(ManagerID_L1, "1");
                                sent = true;

                                //Ghi lại lịch sử gửi thành công
                                WriteLog(EmailTo, ManagerID_L1, getEmployeeName(ManagerID_L1), true, Content, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, ManagerID_L1, getEmployeeName(ManagerID_L1), false, DBNull.Value, ex.Message);
            }
            return sent;
        }

        public bool SendEmailToManager_L2()
        {
            bool sent = false;
            string ManagerID_L2 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListManagerID_L2();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        ManagerID_L2 = arr[i].ToString();
                        Subject = CreateContentForManager(ManagerID_L2, "2")[0].ToString();
                        Content = CreateContentForManager(ManagerID_L2, "2")[1].ToString();
                        EmailTo = GetEmployeeInfo(ManagerID_L2)[1].ToString();
                        if (EmailTo != null)
                        {
                            //Đánh dấu đã gửi thành công vào database
                            if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                            {
                                MarkEmailSent(ManagerID_L2, "2");
                                sent = true;
                                WriteLog(EmailTo, ManagerID_L2, getEmployeeName(ManagerID_L2), true, Content, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, ManagerID_L2, getEmployeeName(ManagerID_L2), false, DBNull.Value, ex.Message);
            }
            return sent;
        }

        public bool SendEmailToManager_L3()
        {
            bool sent = false;
            string ManagerID_L3 = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListManagerID_L3();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        ManagerID_L3 = arr[i].ToString();
                        Subject = CreateContentForManager(ManagerID_L3, "3")[0].ToString();
                        Content = CreateContentForManager(ManagerID_L3, "3")[1].ToString();
                        EmailTo = GetEmployeeInfo(ManagerID_L3)[1].ToString();
                        if (EmailTo != null)
                        {
                            //Đánh dấu đã gửi thành công vào database                        
                            if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                            {
                                MarkEmailSent(ManagerID_L3, "3");
                                sent = true;
                                WriteLog(EmailTo, ManagerID_L3, getEmployeeName(ManagerID_L3), true, Content, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, ManagerID_L3, getEmployeeName(ManagerID_L3), false, DBNull.Value, ex.Message);
            }
            return sent;
        }

        public bool SendEmailToEmployee()
        {
            bool sent = false;
            string EmployeeID = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListEmployee();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        EmployeeID = arr[i].ToString();
                        Subject = CreateContentForEmployee(EmployeeID)[0].ToString();
                        Content = CreateContentForEmployee(EmployeeID)[1].ToString();
                        EmailTo = GetEmployeeInfo(EmployeeID)[1].ToString();
                        if (EmailTo != null)
                        {
                            if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                            {
                                MarkEmailSentForUser(EmployeeID);
                                sent = true;
                                WriteLog(EmailTo, EmployeeID, getEmployeeName(EmployeeID), true, Content, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, EmployeeID, getEmployeeName(EmployeeID), false, DBNull.Value, ex.Message);
            }
            return sent;
        }

        public bool SendEmailTest()
        {
            bool sent = false;
            string EmployeeID = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListEmployee();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        EmployeeID = arr[i].ToString();
                        Subject = CreateContentForEmployee(EmployeeID)[0].ToString();
                        Content = CreateContentForEmployee(EmployeeID)[1].ToString();
                        EmailTo = GetEmployeeInfo(EmployeeID)[1].ToString();
                        
                    }
                }
                EmailTo = "thinhnq@tdt-tanduc.com";
                Subject = "Test send mail";
                Content = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                {
                    if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                    {
                        sent = true;
                        WriteLog(EmailTo, "EmpIDtest", getEmployeeName(EmployeeID), true, Content, DBNull.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, EmployeeID == null ? "NULL" : EmployeeID, getEmployeeName(EmployeeID), false, DBNull.Value, ex.Message);
            }
            return sent;
        }

        public void LoadAL()
        {
            khSqlServerProvider Provider = new khSqlServerProvider(ConString);
            Provider.CommandText = "PER_sp_Rpt_LeaveReport";
            Provider.CommandType = CommandType.StoredProcedure;
            DateTime fromDate = new DateTime(DateTime.Today.Year, 1, 1);
            //DateTime toDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateTime toDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            Provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID", "@UserID" };
            Provider.ValueCollection = new object[] { fromDate, toDate, "", "LeaveMail" };
            int i = Provider.ExecuteNonQuery();
            if (i > 0)
            {
                Provider.CloseConnection();
            }
        }

        public void LoadAL(string EmpID)
        {
            khSqlServerProvider Provider = new khSqlServerProvider(ConString);
            Provider.CommandText = "PER_sp_Rpt_LeaveReport";
            Provider.CommandType = CommandType.StoredProcedure;
            DateTime fromDate = new DateTime(DateTime.Today.Year, 1, 1);
            //DateTime toDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            DateTime toDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            Provider.ParameterCollection = new string[] { "@FromDate", "@ToDate", "@EmpID", "@UserID" };
            Provider.ValueCollection = new object[] { fromDate, toDate, EmpID, "LeaveMail" };
            int i = Provider.ExecuteNonQuery();
            if (i > 0)
            {
                Provider.CloseConnection();
            }
        }

        public bool SendMonthlyRemainLeave()
        {
            bool sent = true;
            string EmployeeID = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            string sqlString = "";
            string sqlString2 = "";

            // Duyet tung nguoi trong danh sach goi mail
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlString2 = "SELECT distinct e.EmployeeID "
                        + "FROM ("
                        + " select distinct 'mng'=ManagerID_L1 from tblEmpManagerLevel "
                        + " union all "
                        + " select distinct 'mng'=ManagerID_L2 from tblEmpManagerLevel "
                        + " Union all "
                        + " select distinct 'mng'=ManagerID_L3 from tblEmpManagerLevel "
                        + " ) as tmp "
                        + " join tblEmployee e on e.employeeID=tmp.mng "
                        + " Where e.LeftDate is null or DateDiff(d, e.LeftDate, getdate()) <= 0 AND mng is not null";

            sqlString = "SELECT r.EmployeeID, e.EmployeeName, r.ALRemain, e.Email, e.DepName, e.PosName "
                        + "FROM tblEmployee e INNER JOIN tbl_View_EmpALRemain_Online r ON e.EmployeeID = r.EmployeeID where r.ComputerName = 'LeaveMail'";
            
            //sqlProvider.CommandText = sqlString2;
            //DataTable dt2 = sqlProvider.GetDataTable();
            //if (dt2.Rows.Count > 0)
            //{
            //    for (int j = 0; j < dt2.Rows.Count; j++)
            //    {
            //        string EmpID = dt2.Rows[j]["EmployeeID"].ToString();
            //        //Goi sp thuc hien load data phep ton truoc
            //        LoadAL(EmpID);

            //        //Bat dau xu ly gui mail
            //        //khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
                    sqlProvider.CommandText = sqlString2;
                    DataTable dt = sqlProvider.GetDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeID = dt.Rows[i]["EmployeeID"].ToString();
                            EmailTo = GetEmployeeInfo(EmployeeID)[1].ToString();
                            Subject = CreateContentForRemainLeave(EmployeeID)[0].ToString();
                            //Content = CreateContentForRemainLeave(EmployeeID)[1].ToString();
                            Content = CreateContentForRemainLeave_2(EmployeeID)[1].ToString();
                            if (EmailTo != null)
                            {
                                
                                if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                                {

                                }
                                else
                                {
                                    sent = false;
                                }
                            }
                        }
                //    }
                //}
            }
            return sent;
        }

        public bool SenMailIndependenceDay()
        {
            bool sent = false;
            string EmployeeID = null;
            string Subject = null;
            string EmailTo = null;
            string Content = null;
            try
            {
                ArrayList arr = GetListForenceEmployee();
                if (arr.Count > 0)
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        EmployeeID = arr[i].ToString();
                        Subject = "Congratulations on your Independence Day";
                        Content = CreateContentForIndependenceDay(EmployeeID)[1].ToString();
                        EmailTo = GetEmployeeInfo(EmployeeID)[1].ToString();
                        if (EmailTo != null)
                        {
                            if (SendMailToUserFromGmail(EmailTo, Subject, Content))
                            {
                                sent = true;
                                WriteLog(EmailTo, EmployeeID, getEmployeeName(EmployeeID), true, Content, DBNull.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi lại lịch sử gửi thất bại
                WriteLog(EmailTo, EmployeeID, getEmployeeName(EmployeeID), false, DBNull.Value, ex.Message);
            }
            return sent;
        }


        public bool SendMailToUser(string emailTo, string subject, string contentToSend)
        {
            bool sent = false;
            //Noi dung code



            return sent;
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
                //sent = mailProvider.SendMailFromGmail(emailTo, subject, contentToSend, "khuongsm@gmail.com", "Tk150314110806");
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

        ArrayList CreateContentForRemainLeave(string EmployeeID)
        {
            ArrayList arrayList = new ArrayList();
            string sqlString = "";
            string subject = "";
            string content = "";
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlString += "SELECT r.EmployeeID, e.EmployeeName, r.ALRemain, e.Email, e.DepName, e.PosName ";
            sqlString += "FROM tblEmployee e INNER JOIN tbl_View_EmpALRemain_Online r ON e.EmployeeID = r.EmployeeID ";
            sqlString += "WHERE r.EmployeeID = @EmployeeID AND r.ComputerName = 'LeaveMail'";
            sqlProvider.CommandText = sqlString;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            subject = "Phép tồn tính đến ngày " + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
            if (dt.Rows.Count > 0)
            {
                content += "<table border=0 width=100%>";
                content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                content += "<td>Stt/No</td>";
                content += "<td>Mã NV/EmployeeID</td>";
                content += "<td>Họ Tên/FullName</td>";
                content += "<td>Chức vụ/Position</td>";
                content += "<td>Phòng ban/Department</td>";
                content += "<td>Phép tồn/Remain leave</td>";
                content += "</tr>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    content += "<tr>";
                    content += "<td style='text-align:center'>" + (i + 1) + "</td>";
                    content += "<td>" + dt.Rows[i]["EmployeeID"].ToString() + "</td>";
                    content += "<td>" + dt.Rows[i]["EmployeeName"].ToString() + "</td>";
                    content += "<td>" + dt.Rows[i]["PosName"].ToString() + "</td>";
                    content += "<td>" + dt.Rows[i]["DepName"].ToString() + "</td>";
                    content += "<td>" + dt.Rows[i]["ALRemain"].ToString() + "</td>";
                    content += "</tr>";
                }
                content += "</table>";
            }
            arrayList.Add(subject);
            arrayList.Add(content);
            sqlProvider.CloseConnection();
            return arrayList;
        }

        ArrayList CreateContentForRemainLeave_2(string EmployeeID)
        {
            ArrayList arrayList = new ArrayList();
            string sqlString = "";
            string subject = "";
            string content = "";
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlString += "SELECT r.EmployeeID, e.EmployeeName, r.ALRemain, e.Email, e.DepName, e.PosName ";
            sqlString += "FROM tblEmployee e INNER JOIN tbl_View_EmpALRemain_Online r ON e.EmployeeID = r.EmployeeID ";
            sqlString += "WHERE r.EmployeeID = @EmployeeID AND r.ComputerName = 'LeaveMail'";
            sqlProvider.CommandText = sqlString;
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            subject = "Phép tồn tính đến ngày " + DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month) + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year;
            
            // Content
            content += "<p class=MsoNormal style='margin-bottom:12.0pt'>";
            content += "<span style='font-size:12.0pt;font-family:\"Times New Roman\",serif'>Dear </span><b>Anh</b>(Mr)/<b>Chị</b>(Ms),<br><br>Vui lòng đăng nhập vào hệ thống Eleave để xem thông tin phép năm sử dụng trong tháng và thống kê tính đến thời điểm hiện tại của Phòng ban / đội nhóm của bạn.<br>";
            content += "<br><i>Please login to Eleave system to find the total used of Annual leave and balance remaining of your Department / Function.</i><br>";
            content += "<br>Anh chị vui lòng sắp cho nhân viên nghỉ phép hợp lý đảm bảo không ảnh hưởng đến kế hoạch sản xuất và hoạt động của Công ty.<br>";
            content += "<span style='font-family:\"Calibri\",sans-serif'>";
            content += "<br><i>You are requested to arrange the job of  your team members to take annual leave days of the respective year and cause no negative affects to Company business.</i><br>";
            content += "</span>";
            content += "</p>";

            //if (dt.Rows.Count > 0)
            //{
            //    content += "<table border=0 width=100%>";
            //    content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
            //    content += "<td>Stt/No</td>";
            //    content += "<td>Mã NV/EmployeeID</td>";
            //    content += "<td>Họ Tên/FullName</td>";
            //    content += "<td>Chức vụ/Position</td>";
            //    content += "<td>Phòng ban/Department</td>";
            //    content += "<td>Phép tồn/Remain leave</td>";
            //    content += "</tr>";
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        content += "<tr>";
            //        content += "<td style='text-align:center'>" + (i + 1) + "</td>";
            //        content += "<td>" + dt.Rows[i]["EmployeeID"].ToString() + "</td>";
            //        content += "<td>" + dt.Rows[i]["EmployeeName"].ToString() + "</td>";
            //        content += "<td>" + dt.Rows[i]["PosName"].ToString() + "</td>";
            //        content += "<td>" + dt.Rows[i]["DepName"].ToString() + "</td>";
            //        content += "<td>" + dt.Rows[i]["ALRemain"].ToString() + "</td>";
            //        content += "</tr>";
            //    }
            //    content += "</table>";
            //}

            content += "<p class=MsoNormal>";
            content += "<u>Lưu ý:</u> Số ngày phép của năm nào thì sử dụng trong năm đó, không được mang phép sang năm sau. Đối với những vị trí được mang tối đa 5 ngày phép năm sang năm sau vui lòng bỏ qua mail này.";
            content += "</p>";
            content += "<p class=MsoNormal>";
            content += "<i>";
            content += "Note: Annual leave should be taken in the respective year, without reserving for the following year. For locations that are allowed to bring up to 5 days of leave year to year, please ignore this mail.";
            content += "</i>";
            content += "</p>";
            content += "<p class=MsoNormal style='margin-bottom:12.0pt'>";
            content += "Bạn có thể đăng nhập vào đường link dưới đây để đăng nhập vào Hệ thống phép online.<br><em><span style='font-family:\"Calibri\",sans-serif'>You are advised to click the link below to sign up for the system.</span></em>";
            content += "</p>";
            content += "<p class=MsoNormal>";
            content += "<a href=\"https://hrmweb.vn.pvmgrp.com/eleave\">Click here</a>";
            content += "</p>";
            content += "<p class=MsoNormal>&nbsp;</p>";
            arrayList.Add(subject);
            arrayList.Add(content);
            sqlProvider.CloseConnection();
            return arrayList;
        }

        ArrayList CreateContentForIndependenceDay(string EmployeeID)
        {
            ArrayList arrayList = new ArrayList();
            string content = "";
            string subject = "";

            subject = "Congratulations on your Independence Day";
            
            {
                //Bat dau noi dung html
                content += "Dear Sir/Madam,<br/><br/>";
                
                content += "Congratulations on your Independence Day.<br/>";
                content += "Kindly take note that tomorrow is your holiday and wishing you enjoy that.<br/><br/>";
                
                content += "You are not required to register your holiday in the Eleave system.<br/><br/>";

                content += "Thanks & best regards.<br/>";
                //Ket thuc noi dung html
            }
            arrayList.Add(subject);
            arrayList.Add(content);

            return arrayList;
        }

        ArrayList CreateContentForEmployee(string EmployeeID)
        {
            ArrayList arrayList = new ArrayList();
            string content = "";
            string subject = "";
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlProvider.CommandText = "Select * from tblWebData Where EmployeeID = @EmployeeID and MailToUser=1";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            DataTable dt = sqlProvider.GetDataTable();
            subject = "Tình trạng lượt đăng ký của bạn (Your submission status)";
            if (dt.Rows.Count > 0)
            {
                //Bat dau noi dung html
                content += "Dear <b>Anh</b>(Mr)/<b>Chị</b>(Ms),<br/><br/>";
                content += "Vui lòng đăng nhập vào đường link dưới đây để xem tình trạng lượt đăng ký của bạn.<br/>";
                content += "<em>Please login into the link below to see your submission.</em><br/><br/>";
                content += "<a href='https://hrmweb.vn.pvmgrp.com/eleave'>Click here</a><br/><br/>";


                content += "<table border=0 width=100%>";
                content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                content += "<td>Stt</td>";
                content += "<td>Mã NV</td>";
                content += "<td>Họ Tên</td>";
                content += "<td>Nội dung đăng ký</td>";
                content += "<td>Bắt đầu</td>";
                content += "<td>Kết thúc</td>";
                content += "<td>Tổng ngày</td>";
                content += "<td>Tổng giờ</td>";
                content += "<td>Ngày phê duyệt</td>";
                content += "<td>Phê duyệt</td>";
                content += "</tr>";

                content += "<tr style='font-weight:bold; background-color:yellow; text-align:center'>";
                content += "<td>No</td>";
                content += "<td>Employee ID</td>";
                content += "<td>Full Name</td>";
                content += "<td>Registration content</td>";
                content += "<td>Start Date</td>";
                content += "<td>End Date</td>";
                content += "<td>Days off</td>";
                content += "<td>Hours off</td>";
                content += "<td>Approval Date</td>";
                content += "<td>Aprroval Status</td>";
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
                    content += "<td>" + ((DateTime)dt.Rows[i]["StartDate"]).ToShortDateString() + "</td>";
                    content += "<td>" + ((DateTime)dt.Rows[i]["ToDate"]).ToShortDateString() + "</td>";
                    content += "<td>" + dt.Rows[i]["TotalDays"].ToString() + "</td>";
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
                    content += "<td>" + dt.Rows[i]["FinalDate"].ToString() + "</td>";
                    if (dt.Rows[i]["FinalStatus"].ToString().Equals("w") || dt.Rows[i]["FinalStatus"].ToString().Equals("W"))
                    {
                        content += "<td>Chờ duyệt / Waiting</td>";
                    }

                    if (dt.Rows[i]["FinalStatus"].ToString().Equals("a") || dt.Rows[i]["FinalStatus"].ToString().Equals("A"))
                    {
                        content += "<td>Duyệt / Approved</td>";
                    }

                    if (dt.Rows[i]["FinalStatus"].ToString().Equals("c") || dt.Rows[i]["FinalStatus"].ToString().Equals("C"))
                    {
                        content += "<td>Không duyệt / Rejected</td>";
                    }
                    content += "</tr>";
                }
                content += "</table>";


                //Ket thuc noi dung html
            }
            arrayList.Add(subject);
            arrayList.Add(content);
            sqlProvider.CloseConnection();
            return arrayList;
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
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L1 = @ManagerID and MailToL1=1";
                    break;
                case "2":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L2 = @ManagerID and MailToL2=1";
                    break;
                case "3":
                    sqlProvider.CommandText = "Select * From tblWebData Where ManagerID_L3 = @ManagerID and MailToL3=1";
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
            }

            sqlProvider.CloseConnection();
            return arrayList;
        }

        //Lay ra danh sach ma quan ly cap 1 dang cho gui mail
        public ArrayList GetListManagerID_L1()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList();
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L1 from tblWebData Where MailToL1=1";
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

        //Lay ra danh sach ma quan ly cap 2 dang cho gui mail
        public ArrayList GetListManagerID_L2()
        {
            //Noi dung code 
            ArrayList arrayList = new ArrayList(); ;
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L2 from tblWebData Where MailToL2=1";
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

        //Lay ra danh sach ma quan ly cap 3 dang cho gui mail
        public ArrayList GetListManagerID_L3()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList(); ;
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct ManagerID_L3 from tblWebData Where MailToL3=1";
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

        //Lay ra danh sach ma nhan vien dang cho gui mail
        public ArrayList GetListEmployee()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList();
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "Select distinct EmployeeID from tblWebData Where MailToUser=1";
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrayList.Add(dt.Rows[i]["EmployeeID"]);
                }
            }
            sqlProvider.CloseConnection();
            return arrayList;
        }

        //Lay ra danh sach ma nhan vien nguoi nuoc ngoai can gui mail
        public ArrayList GetListForenceEmployee()
        {
            //Noi dung code
            ArrayList arrayList = new ArrayList();
            string con = ConString;
            khSqlServerProvider sqlProvider = new khSqlServerProvider(con);
            sqlProvider.CommandText = "PER_sp_IndependenceDay";
            sqlProvider.CommandType = CommandType.StoredProcedure;
            sqlProvider.ParameterCollection = new string[] { "@Dating", "@EmpID" };
            DateTime Dating = DateTime.Now.AddDays(1);
            sqlProvider.ValueCollection = new object[] { Dating, "" };
            DataTable dt = sqlProvider.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrayList.Add(dt.Rows[i]["EmployeeID"]);
                }
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

        void MarkEmailSentForUser(string EmployeeID)
        {
            khSqlServerProvider sqlProvider = new khSqlServerProvider(ConString);
            sqlProvider.CommandText = "Update tblWebData Set MailToUser=2 Where EmployeeID = @EmployeeID and MailToUser=1";
            sqlProvider.ParameterCollection = new string[] { "@EmployeeID" };
            sqlProvider.ValueCollection = new object[] { EmployeeID };
            sqlProvider.ExecuteNonQuery();
        }

        private void WriteLog(object MailTo, object ManagerID, object ManagerName, bool Sent, object Content, object Error)
        {
            khSqlServerProvider provider = new khSqlServerProvider(ConString);
            provider.CommandText = "Insert into tblWeb_MailLog values(@mailfrom, @mailto, getdate(), @managerid, @managername, @sent, @content, @error)";
            provider.ParameterCollection = new string[] { "@mailfrom", "@mailto", "@managerid", "@managername", "@sent", "@content", "@error" };
            provider.ValueCollection = new object[] { "E-Leave", MailTo, ManagerID, ManagerName, Sent, Content, Error };
            provider.ExecuteNonQuery();
            provider.CloseConnection();
        }

        private string getEmployeeName(object EmployeeID)
        {
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(ConString);
                provider.CommandText = "Select EmployeeName from tblEmployee Where EmployeeID = @employeeid";
                provider.ParameterCollection = new string[] { "@employeeid" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                string value = "";
                if (dt.Rows.Count > 0)
                {
                    value = dt.Rows[0]["EmployeeName"].ToString();
                }
                provider.CloseConnection();
                return value;
            }
            catch(Exception ex)
            {
                return "";
            }
        }
    }
}
