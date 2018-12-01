using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for DataTableProvider
/// </summary>
public partial class khSqlServerProvider
{

    private SqlConnection sqlConnection;
    private SqlCommand sqlCommand;
    //private SqlDataReader sqlDataReader;
    private SqlDataAdapter sqlDataAdapter;
    private ArrayList arrayList = new ArrayList();

    private string connectionString = "";
    public string ConnectionString
    {
        set { connectionString = value; }
        get { return connectionString; }
    }

    private string commandText = "";
    public string CommandText
    {
        set { commandText = value; }
        get{return commandText;}
    }
    private CommandType commandType = CommandType.Text;
    public CommandType CommandType
    {
        set { commandType = value; }
        get { return commandType; }
    }
    
    private string[] parameterCollection;
    public string[] ParameterCollection
    {
        set { parameterCollection = value; }
        get { return parameterCollection; }
    }
    
    private object[] valueCollection;
    public object[] ValueCollection
    {
        set { valueCollection = value; }
        get { return valueCollection; }
    }

    private string[] outputParameterCollection;
    public string[] OutputParameterCollection
    {
        set { outputParameterCollection = value; }
        get { return outputParameterCollection; }
    }

    private SqlDbType[] outputDbTypeCollection;
    public SqlDbType[] OutputDbTypeCollection
    {
        set { outputDbTypeCollection = value; }
        get { return outputDbTypeCollection; }
    }

    private int[] outputFieldSizeCollection;
    public int[] OutputFieldsizeCollection
    {
        set { outputFieldSizeCollection = value; }
        get { return outputFieldSizeCollection; }
    }
    
    private string errorMessage = "";
    public string ErrorMessage
    {
        set { errorMessage = value; }
        get { return errorMessage; }
    }
    private int errorCode = 0;
    public int ErrorCode
    {
        set { errorCode = value; }
        get { return errorCode; }
    }

    private int time_out = 0;
    public int Time_Out
    {
        set { time_out = value; }
        get { return time_out; }
    }
    public khSqlServerProvider()
    {
        connectionString = "server=(local);" +
            "database=RecruitVietnamDb;" +
            "Integrated Security=SSPI;";
    }
    public khSqlServerProvider(string conString)
    {
        if(conString =="" )
            conString= "server=(local);" +
             "database=RecruitVietnamDb;" +
                "Integrated Security=SSPI;";
        connectionString = conString;
        OpenConnection();
    }
    private void OpenConnection()
    {
        if (sqlConnection == null || sqlConnection.State == ConnectionState.Closed)
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;
            sqlConnection.Open();
        }
    }
     
    public void CloseConnection()
    {
        
        if (sqlConnection.State == ConnectionState.Open)
        {
             sqlConnection.Close();
        }
        sqlConnection.Dispose();
    }
    public void AddParameters(SqlCommand sqlCommand)
    {
        for (int i = 0; i < parameterCollection.Length; i++)
        {
            sqlCommand.Parameters.AddWithValue(
            parameterCollection[i], valueCollection[i]);
        }
    }   
    
}
