using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class ManagerHR_DirectDAO : BaseDAO
    {
        public ManagerHR_DirectDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tblRef_Department CreateNewsFromReader(IDataReader reader)
        {
            tblRef_Department news = new tblRef_Department();
            news.DepID = (string)reader["DepID"];

            if (string.IsNullOrEmpty(reader["Group"].ToString()))
                news.Group = "";
            else
                news.Group = reader["Group"].ToString();

            if (string.IsNullOrEmpty(reader["DepName"].ToString()))
                news.DepName = "";
            else
                news.DepName = reader["DepName"].ToString();

            if (string.IsNullOrEmpty(reader["DepParent"].ToString()))
                news.DepParent = "";
            else
                news.DepParent = reader["DepParent"].ToString();

            if (string.IsNullOrEmpty(reader["DepID"].ToString()))
                news.DepID = "";
            else
                news.DepID = reader["DepID"].ToString();

            if (string.IsNullOrEmpty(reader["DepTypeID"].ToString()))
                news.DepTypeID = "";
            else
                news.DepTypeID = reader["DepTypeID"].ToString();
            
            return news;
        }

        public List<tblRef_Department> GetListByID(string Procedure_name, string thamso, string EmpID)
        {
            List<tblRef_Department> newsList = new List<tblRef_Department>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, EmpID));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add(CreateNewsFromReader(reader));
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
        }

        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string groupcode, string managerID)
        {
            object[] par = new object[] { groupcode, managerID };
            return StoreToTable(Procedure_Name, Table_Name, par);

        }
    }
}