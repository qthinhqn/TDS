using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for kh.SqlServerDataProvider
/// </summary>
public partial class khSqlServerProvider 
{
     
    
    #region GetDataSet
    public DataSet GetDataSet( )
    {
        sqlCommand = new SqlCommand();
        sqlCommand.CommandText = commandText;
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = commandType;
        if (ParameterCollection!=null)
            AddParameters(sqlCommand);
        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataSet dataSet = new DataSet();
        sqlDataAdapter.Fill(dataSet);
        sqlCommand.Dispose();
        sqlDataAdapter.Dispose();
        return dataSet;
    }     
    #endregion

    #region GetDataTable

    public DataTable GetDataTable()
    {
        sqlCommand = new SqlCommand();
        sqlCommand.CommandText = commandText;
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = commandType;
        if (ParameterCollection!=null)
            AddParameters(sqlCommand);
        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dataTable = new DataTable();
        sqlDataAdapter.Fill(dataTable);
        sqlCommand.Dispose();
        sqlDataAdapter.Dispose();
        return dataTable;
    }
    public DataTable GetDataTable(int startRecord, int maxRecord)
    {
        
        DataTable dataTable = new DataTable();         
        sqlCommand = new SqlCommand();
        sqlCommand.CommandText = commandText;
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = commandType;
        if (ParameterCollection != null)
            AddParameters(sqlCommand);
        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        sqlDataAdapter.Fill(startRecord, maxRecord, dataTable);             
        return dataTable;
    } 
    #endregion
		 
}
