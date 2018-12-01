using System;
using System.Data;
using System.Data.SqlClient;

public class Provider
{
    public SqlConnection con;
    protected SqlDataAdapter adapter;
    protected SqlCommand command;

    //protected static string _connectionString = "server=NGT-PC\\SQLEXPRESS; database=PERFETTI;Integrated Security=True;";
    protected static string _connectionString = "Data Source=112.78.2.114;Initial Catalog=leh4fc94_QLNhanVien;Persist Security Info=False;Max Pool Size=1000; Connection Timeout=10;User ID=leh4fc94_lehaiha;Password=Dragonha7#@";
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



    public Provider(string conString)
    {
        _connectionString = conString;
    }

    public DataTable GetAdmin()
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("select * from tblEmployee", con);
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];

    }

    public DataTable GetEmpID()
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("select * from tblEmpManagerLevel", con);
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];

    }

    public DataTable GetAdminUser()
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("select UserName,[Password],RoleID from tbluser", con);
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];

    }

    public DataTable GetEmpManagerLever(string manv)
    {
        DataSet ds = new DataSet();
        connection();
        command = new SqlCommand("select(select ManagerID_L1 from(select top(1) EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where ManagerID_L1 = '" + manv + "' or ManagerID_L2 = '" + manv + "' or ManagerID_L3 = '" + manv + "' order by DateChange desc) as hung where ManagerID_L1 = '" + manv + "') as ManagerID_L1,(select ManagerID_L2 from(select top(1) EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where ManagerID_L1 = '" + manv + "' or ManagerID_L2 = '" + manv + "' or ManagerID_L3 = '" + manv + "' order by DateChange desc) as hung where ManagerID_L2 = '" + manv + "') as ManagerID_L2,(select ManagerID_L3 from (select top(1) EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where ManagerID_L1 = '" + manv + "' or ManagerID_L2 = '" + manv + "' or ManagerID_L3 = '" + manv + "' order by DateChange desc) as hung where ManagerID_L3 = '" + manv + "') as ManagerID_L3", con);
        //command = new SqlCommand("select (select ManagerID_L1 from (select top (1) EmployeeID, ManagerID_L1,ManagerID_L2,ManagerID_L3 from tblEmpManagerLevel where EmployeeID = '" + manv + "' order by DateChange desc) as hung where ManagerID_L1='" + manv + "') as ManagerID_L1,(select ManagerID_L2 from(select top(1) EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where EmployeeID = '" + manv + "' order by DateChange desc) as hung where ManagerID_L2 = '" + manv + "') as ManagerID_L2,(select ManagerID_L3 from(select top(1) EmployeeID, ManagerID_L1, ManagerID_L2, ManagerID_L3 from tblEmpManagerLevel where EmployeeID = '" + manv + "' order by DateChange desc) as hung where ManagerID_L3 = '" + manv + "') as ManagerID_L3", con);
        adapter = new SqlDataAdapter(command);
        adapter.Fill(ds);
        con.Close();

        return ds.Tables[0];

    }

    public void Logon_IsNewflag(string EmployeeID, bool Logon_IsNew)
    {
        using (SqlConnection Conn = new SqlConnection(_connectionString))
        {
            SqlTransaction trans = null;
            try
            {

                Conn.Open();
                trans = Conn.BeginTransaction();
                string ComText = "update tblEmployee set Logon_IsNew='" + Logon_IsNew + "' where EmployeeID='" + EmployeeID + "'";

                execute(ComText, Conn, trans);

                trans.Commit();
                Conn.Close();


            }
            catch (Exception Ex)
            {
                if (trans != null)
                    trans.Rollback();
                //return -1;
            }
        }
    }


    public void ChangePassword(string EmployeeID, string Logon_Password)
    {
        using (SqlConnection Conn = new SqlConnection(_connectionString))
        {
            SqlTransaction trans = null;
            try
            {

                Conn.Open();
                trans = Conn.BeginTransaction();
                string ComText = "update tblEmployee set Logon_Password='" + Logon_Password + "' where EmployeeID='" + EmployeeID + "'";

                execute(ComText, Conn, trans);

                trans.Commit();
                Conn.Close();


            }
            catch (Exception Ex)
            {
                if (trans != null)
                    trans.Rollback();
                //return -1;
            }
        }
    }

    public void executeNonQuery(string sqlString)
    {
        connection();
        command = new SqlCommand(sqlString, con);
        command.ExecuteNonQuery();
        con.Close();


    }

    private void execute(string ComText, SqlConnection Conn, SqlTransaction trans)
    {
        SqlCommand Com = null;
        using (Com = new SqlCommand(ComText, Conn, trans))
        {
            /* DB work */
            Com.ExecuteNonQuery();

        }
    }
}
