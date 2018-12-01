using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PAOL
{
    public class Ha
    {
        public SqlConnection con;
        protected SqlDataAdapter adapter;
        protected SqlCommand command;
        //local   
        //protected static string _connectionString = "server=NGT-PC\\SQLEXPRESS; database=PERFETTI;Integrated Security=True;";
        protected static string _connectionString = "Data Source=112.78.2.114;Initial Catalog=leh4fc94_QLNhanVien;Persist Security Info=False;Max Pool Size=1000; Connection Timeout=10;User ID=leh4fc94_lehaiha;Password=Dragonha7#@";
               
        public Ha(string constring)
        {
            _connectionString = constring;
        }

        public void connection()
        {
            //NGT-PC\\SQLEXPRESS
            if (con == null)
            {
                con = new SqlConnection(_connectionString);
                con.Open();


            }
            else
            {
                con.Close();

            }
        }
        public DataTable getLeaveRegistration(string EmployeeID)
        {
            DataSet ds = new DataSet();
            connection();
            string thang = DateTime.Now.Month + "";
            string nam = DateTime.Now.Year + "";


            command = new SqlCommand("Select tblWebData.ID,tblEmployee.EmployeeName,tblWebData.EmployeeID,tblWebData.RegDate,tblWebData.ID,tblWebData.StartDate,tblWebData.ToDate,tblWebData.FromTime,tblWebData.ToTime,tblWebData.PerTimeID,tblWebData.LeaveReason,tblWebData.ApprovingDate_L1,tblWebData.ApprovingReason_L1,tblWebData.ApprovingStatus_L1,tblWebData.ApprovingDate_L2,tblWebData.ApprovingReason_L2,tblWebData.ApprovingStatus_L2,tblWebData.ApprovingDate_L3,tblWebData.ApprovingReason_L3,tblWebData.ApprovingStatus_L3,tblWebData.HRCheckingDate,tblWebData.HRCheckingReason,tblWebData.HRCheckingStatus,tblWebData.CheckNum,tblWebData.MailToL1,tblWebData.ManagerID_L1,tblWebData.MailToL2,tblWebData.ManagerID_L2,tblWebData.MailToL3,tblWebData.ManagerID_L3,tblWebData.MailToUser,tblWebData.TotalDays,tblWebData.TotalHours,tblWebData.FinalDate,case 'a' when tblWebData.FinalStatus then N'Duyệt' else case 'c' when tblWebData.FinalStatus then N'Không Duyệt' else N'Chờ Duyệt' end end as FinalStatus,tblRef_LeaveType.LeaveType,tblPerTime.PerTimeName,(select tblEMployee.EmployeeName from tblEmpManagerLevel,tblEmployee,tblWebData where tblEmpManagerLevel.ManagerID_L1=tblEmployee.EmployeeID and tblWebData.ManagerID_L1=tblEmpManagerLevel.ManagerID_L1 group by  tblEMployee.EmployeeName) as ManagerName_L1,(select tblEMployee.EmployeeName from tblEmpManagerLevel,tblEmployee,tblWebData where tblEmpManagerLevel.ManagerID_L2=tblEmployee.EmployeeID and tblWebData.ManagerID_L2=tblEmpManagerLevel.ManagerID_L2 group by tblEMployee.EmployeeName) as ManagerName_L2,(select  tblEMployee.EmployeeName from tblEmpManagerLevel,tblEmployee,tblWebData where tblEmpManagerLevel.ManagerID_L3=tblEmployee.EmployeeID and tblWebData.ManagerID_L3=tblEmpManagerLevel.ManagerID_L3 group by tblEMployee.EmployeeName) as ManagerName_L3 from tblWebData,tblPerTime,tblRef_LeaveType,tblEmpManagerLevel,tblEmployee where tblWebData.PerTimeID=tblPerTime.PerTimeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID  and tblEmpManagerLevel.EmployeeID = tblWebData.EmployeeID and tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.EmployeeID='"+EmployeeID+"'", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public DataTable getReport1()
        {
            DataSet ds = new DataSet();
            connection();
            string thang = DateTime.Now.Month + "";
            string nam = DateTime.Now.Year + "";


            command = new SqlCommand("select * from tblPayroll_TmpPrint", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public DataTable checkPayRollOnline(int month,int year,string EmployeeID)
        {
            DataSet ds = new DataSet();
            connection();
            string thang = DateTime.Now.Month + "";
            string nam = DateTime.Now.Year + "";


            command = new SqlCommand("select SalaryTypeID from tblPayroll_online where MonthID=" + month + "and YearID=" + year + "and EmployeeID='" + EmployeeID + "'", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public DataTable getCheckCancel(int ID)
        {
            DataSet ds = new DataSet();
            connection();
            string thang = DateTime.Now.Month + "";
            string nam = DateTime.Now.Year + "";


            command = new SqlCommand("select FinalStatus from tblWebData where ID=" + ID + " and (FinalStatus='a' or FinalStatus='A')", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }

        public DataTable GetAllNameLevel(string EmployeeID)
        {
            DataSet ds = new DataSet();
            connection();


            command = new SqlCommand("select tblEmpManagerLevel.ManagerID_L1,tblEmpManagerLevel.ManagerID_L2,tblEmpManagerLevel.ManagerID_L3,tblEmployee.EmployeeName,Max(DateChange) as DateChange from tblEmpManagerLevel  inner join tblEmployee on (tblEmpManagerLevel.ManagerID_L1=tblEmployee.EmployeeID or tblEmpManagerLevel.ManagerID_L2=tblEmployee.EmployeeID or tblEmpManagerLevel.ManagerID_L3=tblEmployee.EmployeeID)  where tblEmpManagerLevel.EmployeeID='" + EmployeeID + "' group by tblEmpManagerLevel.ManagerID_L1,tblEmpManagerLevel.ManagerID_L2,tblEmpManagerLevel.ManagerID_L3,tblEmployee.EmployeeName", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public void executeNonQuery(string sqlString)
        {
            connection();
            command = new SqlCommand(sqlString, con);
            command.ExecuteNonQuery();
            con.Close();


        }
        public void execute(string ComText, SqlConnection Conn, SqlTransaction trans)
        {
            SqlCommand Com = null;
            using (Com = new SqlCommand(ComText, Conn, trans))
            {
                /* DB work */
                Com.ExecuteNonQuery();

            }

        }
        public void InsertRegistration1(string EmployeeID, string RegDate, string LeaveID, string StartDate, string ToDate, char PerTimeID, string LeaveReason, int CheckNum, string ManagerID_L1, double TotalDays)
        {
            using (SqlConnection Conn = new SqlConnection(_connectionString))
            {
                SqlTransaction trans = null;
                try
                {

                    Conn.Open();
                    trans = Conn.BeginTransaction();
                    string ComText = "INSERT INTO  tblWebData(EmployeeID, RegDate, LeaveID, StartDate, ToDate,FromTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,CheckNum,MailToL1,ManagerID_L1,MailToL2,ManagerID_L2,MailToL3,ManagerID_L3,MailToUser,TotalDays,TotalHours,FinalDate,FinalStatus) VALUES ('" + EmployeeID + "','" + RegDate + "','" + LeaveID + "','" + StartDate + "','" + ToDate + "',NULL,'" + PerTimeID + "','" + LeaveReason + "',NULL,NULL,NULL,'','','',NULL,'','',NULL,'',NULL," + CheckNum + ",1,'" + ManagerID_L1 + "','','','','',1," + TotalDays + ",'',NULL,'w')";
                    //string ComText = "INSERT INTO solaodong(masolaodong,manhanvien,soso,ngaycap,noicap) VALUES ('" + masolaodong + "'," + manhanvien + ",'" + Soso + "','" + ngaycap + "','" + noicap + "');";
                    execute(ComText, Conn, trans);

                    trans.Commit();
                    Conn.Close();


                }
                catch (Exception Ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    Conn.Close();


                    //return -1;
                }
            }
        }
        public void InsertRegistration2(string EmployeeID, string RegDate, string LeaveID, string StartDate, string ToDate, char PerTimeID, string LeaveReason, int CheckNum, string ManagerID_L1, string ManagerID_L2, double TotalDays)
        {
            using (SqlConnection Conn = new SqlConnection(_connectionString))
            {
                SqlTransaction trans = null;
                try
                {

                    Conn.Open();
                    trans = Conn.BeginTransaction();
                    string ComText = "INSERT INTO  tblWebData(EmployeeID, RegDate, LeaveID, StartDate, ToDate,FromTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,CheckNum,MailToL1,ManagerID_L1,MailToL2,ManagerID_L2,MailToL3,ManagerID_L3,MailToUser,TotalDays,TotalHours,FinalDate,FinalStatus) VALUES ('" + EmployeeID + "','" + RegDate + "','" + LeaveID + "','" + StartDate + "','" + ToDate + "',NULL,'" + PerTimeID + "','" + LeaveReason + "',NULL,NULL,NULL,'','','',NULL,'','',NULL,'',NULL," + CheckNum + ",1,'" + ManagerID_L1 + "','1','" + ManagerID_L2 + "','','',1," + TotalDays + ",'',NULL,'w')";
                    //string ComText = "INSERT INTO solaodong(masolaodong,manhanvien,soso,ngaycap,noicap) VALUES ('" + masolaodong + "'," + manhanvien + ",'" + Soso + "','" + ngaycap + "','" + noicap + "');";
                    execute(ComText, Conn, trans);

                    trans.Commit();
                    Conn.Close();


                }
                catch (Exception Ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    Conn.Close();


                    //return -1;
                }
            }
        }
        public void InsertRegistration3(string EmployeeID, string RegDate, string LeaveID, string StartDate, string ToDate, char PerTimeID, string LeaveReason, int CheckNum, string ManagerID_L1, string ManagerID_L2, string ManagerID_L3, double TotalDays)
        {
            using (SqlConnection Conn = new SqlConnection(_connectionString))
            {
                SqlTransaction trans = null;
                try
                {

                    Conn.Open();
                    trans = Conn.BeginTransaction();
                    string ComText = "INSERT INTO  tblWebData(EmployeeID, RegDate, LeaveID, StartDate, ToDate,FromTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,CheckNum,MailToL1,ManagerID_L1,MailToL2,ManagerID_L2,MailToL3,ManagerID_L3,MailToUser,TotalDays,TotalHours,FinalDate,FinalStatus) VALUES ('" + EmployeeID + "','" + RegDate + "','" + LeaveID + "','" + StartDate + "','" + ToDate + "',NULL,'" + PerTimeID + "','" + LeaveReason + "',NULL,NULL,NULL,'','','',NULL,'','',NULL,'',NULL," + CheckNum + ",1,'" + ManagerID_L1 + "','1','" + ManagerID_L2 + "','1','" + ManagerID_L3 + "',1," + TotalDays + ",'',NULL,'w')";
                    //string ComText = "INSERT INTO solaodong(masolaodong,manhanvien,soso,ngaycap,noicap) VALUES ('" + masolaodong + "'," + manhanvien + ",'" + Soso + "','" + ngaycap + "','" + noicap + "');";
                    execute(ComText, Conn, trans);

                    trans.Commit();
                    Conn.Close();


                }
                catch (Exception Ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    Conn.Close();


                    //return -1;
                }
            }
        }

        public DataTable GetHoliDayinMonth(string Tungay, string Denngay)
        {
            DataSet ds = new DataSet();
            connection();


            command = new SqlCommand("select count(temp.allday) as Dating from (select convert(datetime,Concat(th.nam,'/',th.thang,'/',th.ngay)) as allday from (select Datepart(day,Dating) as ngay, Datepart(month,Dating) as thang, datepart(year,getdate()) as nam from tblHoliday) as th) as temp  where temp.allday between '" + Tungay + "' and '" + Denngay + "'", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }

        public DataTable getSumAbsentLeave(string EmployeeID)
        {
            DataSet ds = new DataSet();
            connection();


            command = new SqlCommand("select sum(TotalDays) as SumTotalDays from tblWebData inner join tblEmpManagerLevel on tblWebData.EmployeeID = tblEmpManagerLevel.EmployeeID inner join tblPerTime on tblWebData.PerTimeID=tblPerTime.PerTimeID inner join tblRef_LeaveType on tblWebData.LeaveID=tblRef_LeaveType.LeaveID inner join tblEmployee on tblEmployee.EmployeeID=tblWebData.EmployeeID and (tblWebData.FinalStatus ='w' or tblWebData.FinalStatus ='W')  and tblWebData.EmployeeID='" + EmployeeID + "'", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public DataTable checkMarry(string EmployeeID)
        {
            DataSet ds = new DataSet();
            connection();


            command = new SqlCommand("select * from tblWebData where LeaveID='MR' and EmployeeID='" + EmployeeID + "'", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
        public void DeleteRegistration(int Position)
        {
            DataSet ds = new DataSet();
            connection();


            command = new SqlCommand("delete  from tblWebData where ID=" + Position + "", con);


            //Fetch data and fill your datatable
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            con.Close();

        }


    }

}