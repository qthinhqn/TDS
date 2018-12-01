using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data.SqlTypes;

class ThProvider
{
    public SqlConnection con;
    protected SqlDataAdapter adapter;
    protected SqlCommand command;
    //local   
    protected static string _connectionString = "server=THACH\\THACH; database=PERFETTI;Integrated Security=True;";
    //protected static string _connectionString = "Data Source=112.78.2.114;Initial Catalog=leh4fc94_QLNhanVien;Persist Security Info=False;Max Pool Size=1000; Connection Timeout=10;User ID=leh4fc94_lehaiha;Password=Dragonha7#@";
    public int count = 0;

    public ThProvider(string conString)
    {
        _connectionString = conString;
    }


    public void connection()
    {
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

    public DataTable getdata1(string manhanvien, string lang)
    {
        DataSet ds = new DataSet();
        connection();
        if (lang == "vi")
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where ManagerID_L1 = '" + manhanvien + "') as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        else
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where ManagerID_L1 = '" + manhanvien + "') as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public DataTable getdata2(string manhanvien, string lang)
    {
        DataSet ds = new DataSet();
        connection();
        if (lang == "vi")
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where (ManagerID_L2 = '" + manhanvien + "' and ApprovingStatus_L1 = 'True' and CheckNum > 1) or (ManagerID_L2 = '" + manhanvien + "' and ManagerID_L1='')) as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        else
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where (ManagerID_L2 = '" + manhanvien + "' and ApprovingStatus_L1 = 'True' and CheckNum > 1) or (ManagerID_L2 = '" + manhanvien + "' and ManagerID_L1='')) as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public DataTable getdata3(string manhanvien, string lang)
    {
        DataSet ds = new DataSet();
        connection();
        if (lang == "vi")
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where (ManagerID_L3 = '" + manhanvien + "' and CheckNum > 2 and ApprovingStatus_L2 = 'True') or (ManagerID_L3 = '" + manhanvien + "' and CheckNum > 1 and ManagerID_L1='') or (ManagerID_L3 = '" + manhanvien + "' and ManagerID_L2='')) as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        else
        {
            command = new SqlCommand("select * from (select * from (select * from (select ID,th.EmployeeID,tblEmployee.EmployeeName,RegDate,th.LeaveID,LeaveType,StartDate,ToDate,FromTime,ToTime,PerTimeID,LeaveReason,ApprovingDate_L1,ApprovingReason_L1,ApprovingStatus_L1,ApprovingDate_L2,ApprovingReason_L2,ApprovingStatus_L2,ApprovingDate_L3,ApprovingReason_L3,ApprovingStatus_L3,CheckNum,ManagerID_L1,ManagerID_L2,ManagerID_L3,TotalDays,TotalHours,FinalDate,FinalStatus,MailToL1,MailToL2,MailToL3,MailToUser,HRCheckingStatus,HRview, Warning, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t from (select * from (select * from tblWebData where (ManagerID_L3 = '" + manhanvien + "' and CheckNum > 2 and ApprovingStatus_L2 = 'True') or (ManagerID_L3 = '" + manhanvien + "' and CheckNum > 1 and ManagerID_L1='') or (ManagerID_L3 = '" + manhanvien + "' and ManagerID_L2='')) as tblWebData,(select LeaveID as LID,LeaveType from tblRef_LeaveType where tblRef_LeaveType.IsOnline = 'True') as leave where tblWebData.LeaveID=leave.LID) as th inner join tblEmployee on th.EmployeeID=tblEmployee.EmployeeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3", con);
        }
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public DataTable getdataHR(string hracc, string lang)
    {

        DataSet ds = new DataSet();
        connection();
        if (lang == "" || lang == "vi")
        {
            if (hracc == "HR_Sale" || hracc == "HR_SALE")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Chờ Đồng Bộ' else '' end) else (case when HRCheckingStatus=1 then N'Đồng Bộ' else N'Không Đồng Bộ' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='Sale') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_ASM")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Chờ Đồng Bộ' else '' end) else (case when HRCheckingStatus=1 then N'Đồng Bộ' else N'Không Đồng Bộ' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='ASM' or SalaryTypeID = 'FS') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_Sweep" || hracc == "HR_SWEEP")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Chờ Đồng Bộ' else '' end) else (case when HRCheckingStatus=1 then N'Đồng Bộ' else N'Không Đồng Bộ' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='Sweep' and PayrollType = 'AtSite') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_Nosweep" || hracc == "HR_NOSWEEP")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Chờ Đồng Bộ' else '' end) else (case when HRCheckingStatus=1 then N'Đồng Bộ' else N'Không Đồng Bộ' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID= 'Nosweep' and PayrollType = 'AtSite') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Chờ Duyệt' end) else (case when ApprovingStatus_L1=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Chờ Duyệt' else (case when CheckNum > 1 then N'Chờ Duyệt' else '' end) end) else (case when CheckNum = 3 then N'Chờ Duyệt' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Duyệt' else N'Không Duyệt' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Chờ Đồng Bộ' else '' end) else (case when HRCheckingStatus=1 then N'Đồng Bộ' else N'Không Đồng Bộ' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
        }
        else
        {
            if (hracc == "HR_Sale" || hracc == "HR_SALE")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Waiting' else '' end) else (case when HRCheckingStatus=1 then N'Syncied' else N'Cancel' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='Sale') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_ASM")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Waiting' else '' end) else (case when HRCheckingStatus=1 then N'Syncied' else N'Cancel' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='ASM' or SalaryTypeID = 'FS') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_Sweep" || hracc == "HR_SWEEP")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Waiting' else '' end) else (case when HRCheckingStatus=1 then N'Syncied' else N'Cancel' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID='Sweep' and PayrollType = 'AtSite') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else if (hracc == "HR_Nosweep" || hracc == "HR_NOSWEEP")
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Waiting' else '' end) else (case when HRCheckingStatus=1 then N'Syncied' else N'Cancel' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True' and SalaryTypeID= 'Nosweep' and PayrollType = 'AtSite') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
            else
            {
                command = new SqlCommand("select * from (select * from (select * from (select * from(select * from (select id,tblWebData.EmployeeID,tblEmployee.EmployeeName,RegDate,tblWebData.LeaveID,LeaveType,StartDate,ToDate,LeaveReason,TotalDays,CheckNum,ApprovingStatus_L1,ApprovingStatus_L2,ApprovingStatus_L3,ApprovingDate_L1,ApprovingDate_L2,ApprovingDate_L3,ApprovingReason_L1,ApprovingReason_L2,ApprovingReason_L3,ManagerID_L1,ManagerID_L2,ManagerID_L3,HRCheckingDate,HRCheckingReason,HRCheckingStatus,FinalDate,FinalStatus,PerTimeID as PTID,HRview, FromTime, ToTime, TotalHours, case when ApprovingStatus_L1 IS NULL then (case when ManagerID_L1 = '' then '' else N'Waiting' end) else (case when ApprovingStatus_L1=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L1t,case when ApprovingStatus_L2 IS NULL then (case when ManagerID_L2 = '' then '' else (case when ManagerID_L1 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) end) else (case when ApprovingStatus_L2=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L2t,case when ApprovingStatus_L3 IS NULL then (case when ManagerID_L1 = '' then (case when ManagerID_L2 = '' then N'Waiting' else (case when CheckNum > 1 then N'Waiting' else '' end) end) else (case when CheckNum = 3 then N'Waiting' else '' end) end) else (case when ApprovingStatus_L3=1 then N'Approved' else N'Cancel' end) end ApprovingStatus_L3t,case when HRCheckingStatus IS NULL then (case when HRview = 'a' then N'Waiting' else '' end) else (case when HRCheckingStatus=1 then N'Syncied' else N'Cancel' end) end HRCheckingStatust from tblWebData,(select EmployeeID,EmployeeName from tblEmployee group by EmployeeID,EmployeeName) as tblEmployee,(select LeaveID,LeaveType,IsOnline from tblRef_LeaveType group by LeaveID,LeaveType,IsOnline) as tblRef_LeaveType where tblWebData.EmployeeID=tblEmployee.EmployeeID and tblWebData.LeaveID=tblRef_LeaveType.LeaveID and tblRef_LeaveType.IsOnline = 'True') as th left join (select emp,SalaryTypeID,PayrollType from(select max(yearid) as yid,max(monthid) as mid,EmployeeID as emp from tblPAYROLL_ONLINE group by EmployeeID) as pr left join tblPAYROLL_ONLINE on pr.emp = tblPAYROLL_ONLINE.EmployeeID and pr.yid=tblPAYROLL_ONLINE.YearID and pr.mid=tblPAYROLL_ONLINE.MonthID) as payroll on payroll.emp = th.EmployeeID) as main left outer join (select PerTimeID,PerTimeName from tblPerTime) as tblPerTime on main.PTID = tblPerTime.PerTimeID) as main1 left outer join (select EmployeeID as EID1,EmployeeName as ManagerName_L1 from tblemployee) as MN1 on MN1.EID1=main1.ManagerID_L1) as main2 left outer join (select EmployeeID as EID2,EmployeeName as ManagerName_L2 from tblemployee) as MN2 on MN2.EID2=main2.ManagerID_L2) as main3 left outer join (select EmployeeID as EID3,EmployeeName as ManagerName_L3 from tblemployee) as MN3 on MN3.EID3=main3.ManagerID_L3 order by HRview asc", con);
            }
        }
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public DataTable checkHR(int id)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("select * from tblWebData where ID = '" + id + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];
    }

    public void UpdategetData1(int id, string ApprovingReason_L1, bool ApprovingStatus_L1, string FinalStatus, int mail, string HRview)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("update tblWebData set ApprovingDate_L1=GETDATE(),ApprovingReason_L1= N'" + ApprovingReason_L1 + "',ApprovingStatus_L1='" + ApprovingStatus_L1 + "',FinalStatus='" + FinalStatus + "',MailToL1='0',MailToL2='" + mail + "',FinalDate=GETDATE(),HRview='" + HRview + "' where ID = '" + id + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();
    }

    public void UpdategetData2(int id, string ApprovingReason_L2, bool ApprovingStatus_L2, string FinalStatus, int mail, string HRview)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("update tblWebData set ApprovingDate_L2=GETDATE(),ApprovingReason_L2= N'" + ApprovingReason_L2 + "',ApprovingStatus_L2='" + ApprovingStatus_L2 + "',FinalStatus='" + FinalStatus + "',MailToL2='0',MailToL3='" + mail + "',FinalDate=GETDATE(),HRview='" + HRview + "' where ID = '" + id + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();
    }

    public void UpdategetData3(int id, string ApprovingReason_L3, bool ApprovingStatus_L3, string FinalStatus, string HRview)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("update tblWebData set ApprovingDate_L3=GETDATE(),ApprovingReason_L3= N'" + ApprovingReason_L3 + "',ApprovingStatus_L3='" + ApprovingStatus_L3 + "',FinalStatus='" + FinalStatus + "',MailToL3='0',FinalDate=GETDATE(),HRview='" + HRview + "' where ID = '" + id + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();
    }

    public void UpdateHRA(int i, string lydo, string hr)
    {
        //DataSet ds = new DataSet();
        //connection();
        //command = new SqlCommand("update tblWebData set HRCheckingStatus = '1',HRCheckingDate=GETDATE(),HRCheckingReason = '" + lydo + "',FinalStatus='a',FinalDate=getdate() where ID='" + i + "'", con);
        ////Fetch data and fill your datatable
        //adapter = new SqlDataAdapter(command);
        //adapter.Fill(ds);
        //con.Close();
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("update tblWebData set HRCheckingStatus = '1',HRCheckingDate=GETDATE(),HRCheckingReason = N'" + lydo + "',FinalStatus='a',FinalDate=getdate(),MailToUser = '1',HRview = '" + hr + "' where ID='" + i + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

    }

    public void UpdateHRC(int i, string lydo, string hr)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("update tblWebData set HRCheckingStatus = '0',HRCheckingDate=GETDATE(),HRCheckingReason = '" + lydo + "',FinalStatus='c',FinalDate=getdate(),HRview = '" + hr + "' where ID='" + i + "'", con);
        //Fetch data and fill your datatable
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
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
    public void insert(string Emp, string From, string Per, string To, string Day, string LeaveID, string Reg)
    {
        using (SqlConnection Conn = new SqlConnection(_connectionString))
        {
            SqlTransaction trans = null;
            try
            {

                Conn.Open();
                trans = Conn.BeginTransaction();
                string ComText = "insert into tblEmpDayOff(EmployeeID,FromDate,PerTimeID,ToDate,StartDate,tblEmpDayOff.Days,tblEmpDayOff.LeaveID,FromTime,ToTime,Notes,CompForDate,ApprovedDate,RegistedDate,Start_MY,End_My,Child_FromDate) values ('" + Emp + "','" + From + "','" + Per + "','" + To + "',NULL," + Day + ",'" + LeaveID + "',NULL,NULL,NULL,NULL,GETDATE(),'" + Reg + "',NULL,NULL,NULL)";
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
}
