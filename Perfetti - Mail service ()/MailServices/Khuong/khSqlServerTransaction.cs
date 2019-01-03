using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for SqlServerTransaction
/// </summary>
public partial class khSqlServerProvider
{
    #region	 ExecuteNonQuery
    public int ExecuteNonQuery()
    {
        sqlCommand = new SqlCommand();
        sqlCommand.CommandText = commandText;
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = commandType;
        if(ParameterCollection.Length>0)
            AddParameters(sqlCommand);
        int rows = sqlCommand.ExecuteNonQuery();      
        sqlCommand.Dispose();
        return rows;
    }

    public ArrayList OutputExecuteNonQuery()
    {        
        using (SqlCommand cmd = new SqlCommand(CommandText, sqlConnection))
        {
            cmd.CommandType = CommandType;
            for (int i = 0; i < ParameterCollection.Length; i++)
            {
                cmd.Parameters.AddWithValue(ParameterCollection[i], ValueCollection[i]);
            }
            for (int j = 0; j < OutputParameterCollection.Length; j++)
            {
                cmd.Parameters.Add(OutputParameterCollection[j], OutputDbTypeCollection[j], OutputFieldsizeCollection[j]);
                cmd.Parameters[OutputParameterCollection[j]].Direction = ParameterDirection.Output;
            }                
            cmd.ExecuteNonQuery();
            //Add vao ArrayList
            for (int k = 0; k < OutputParameterCollection.Length; k++)
            {
                arrayList.Add(cmd.Parameters[OutputParameterCollection[k]].Value);
            }
            CloseConnection();           
        }
        return arrayList;
    }
     
    #endregion

    #region ExecuteScalar

    public object ExecuteScalar( )
    {
        sqlCommand = new SqlCommand();
        sqlCommand.CommandText = commandText;
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandType = commandType;

        if (ParameterCollection!=null)
            AddParameters(sqlCommand);

        object obj = sqlCommand.ExecuteScalar();
        sqlCommand.Dispose();
        return obj;
    }

     
    #endregion
}
