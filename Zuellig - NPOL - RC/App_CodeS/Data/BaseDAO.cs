using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class BaseDAO : DataAccessException
    {
        public BaseDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        private SqlConnection conn;
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
        }
        public DataTable StoreToTable(string TenStore, string TenBang, params object[] Giatri)
        {
            DataSet ds = new DataSet();
            try
            {
                conn = GetConnection();
                conn.Open();
                SqlCommand cm = new SqlCommand(TenStore, conn);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    if (i <= Giatri.Length && Giatri[i - 1] != null)
                        cm.Parameters[i].Value = Giatri[i - 1];
                    else
                        cm.Parameters[i].Value = DBNull.Value;// "HR0045";
                }
                SqlDataAdapter da = new SqlDataAdapter(cm);

                da.Fill(ds, TenBang);

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ex.Message);
            }
            finally
            {
                conn.Close();// Đóng kết nối
            }
            return ds.Tables[TenBang];

        }
    }
}