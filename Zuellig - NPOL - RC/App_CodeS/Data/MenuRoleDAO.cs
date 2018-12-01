using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class MenuRoleDAO : BaseDAO
    {
        public MenuRoleDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tbl_MenuRole CreateNewsFromReader(IDataReader reader)
        {
            tbl_MenuRole news = new tbl_MenuRole();

            if (string.IsNullOrEmpty(reader["GroupCode"].ToString()))
                news.RoleCode = "";
            else
                news.RoleCode = (string)reader["GroupCode"];

            //if (string.IsNullOrEmpty(reader["EmployeeID"].ToString()))
            //    news.EmpID = "";
            //else
            //    news.EmpID = (string)reader["EmployeeID"];

            if (string.IsNullOrEmpty(reader["News"].ToString()) || reader["News"].ToString() == "0")
                news.News = false;
            else
                news.News = true;

            if (string.IsNullOrEmpty(reader["ChangePassWord"].ToString()) || reader["ChangePassWord"].ToString() == "0")
                news.ChangePassWord = false;
            else
                news.ChangePassWord = true;

            if (string.IsNullOrEmpty(reader["Registration"].ToString()) || reader["Registration"].ToString() == "0")
                news.Registration = false;
            else
                news.Registration = true;

            if (string.IsNullOrEmpty(reader["Approval"].ToString()) || reader["Approval"].ToString() == "0")
                news.Approval = false;
            else
                news.Approval = true;

            if (string.IsNullOrEmpty(reader["HRNew"].ToString()) || reader["HRNew"].ToString() == "0")
                news.HRNew = false;
            else
                news.HRNew = true;

            if (string.IsNullOrEmpty(reader["ManagerLevel"].ToString()) || reader["ManagerLevel"].ToString() == "0")
                news.ManagerLevel = false;
            else
                news.ManagerLevel = true;

            if (string.IsNullOrEmpty(reader["LeaveReport"].ToString()) || reader["LeaveReport"].ToString() == "0")
                news.LeaveReport = false;
            else
                news.LeaveReport = true;

            if (string.IsNullOrEmpty(reader["PassManagement"].ToString()) || reader["PassManagement"].ToString() == "0")
                news.PassManagement = false;
            else
                news.PassManagement = true;

            if (string.IsNullOrEmpty(reader["KPI4Employee"].ToString()) || reader["KPI4Employee"].ToString() == "0")
                news.KPI4Employee = false;
            else
                news.KPI4Employee = true;

            if (string.IsNullOrEmpty(reader["KPI4Manager"].ToString()) || reader["KPI4Manager"].ToString() == "0")
                news.KPI4Manager = false;
            else
                news.KPI4Manager = true;

            if (string.IsNullOrEmpty(reader["KPIInfo"].ToString()) || reader["KPIInfo"].ToString() == "0")
                news.KPIInfo = false;
            else
                news.KPIInfo = true;

            if (string.IsNullOrEmpty(reader["SkillWill"].ToString()) || reader["SkillWill"].ToString() == "0")
                news.Skill_Will = false;
            else
                news.Skill_Will = true;

            if (string.IsNullOrEmpty(reader["Salary"].ToString()) || reader["Salary"].ToString() == "0")
                news.Salary = false;
            else
                news.Salary = true;

            if (string.IsNullOrEmpty(reader["OTRegistration"].ToString()) || reader["OTRegistration"].ToString() == "0")
                news.OTRegistration = false;
            else
                news.OTRegistration = true;
            if (string.IsNullOrEmpty(reader["OTRegisted"].ToString()) || reader["OTRegisted"].ToString() == "0")
                news.OTRegisted = false;
            else
                news.OTRegisted = true;
            if (string.IsNullOrEmpty(reader["OTApproval"].ToString()) || reader["OTApproval"].ToString() == "0")
                news.OTApproval = false;
            else
                news.OTApproval = true;
            if (string.IsNullOrEmpty(reader["OTStatistic"].ToString()) || reader["OTStatistic"].ToString() == "0")
                news.OTStatistic = false;
            else
                news.OTStatistic = true;

            if (string.IsNullOrEmpty(reader["RecruitRegistration"].ToString()) || reader["RecruitRegistration"].ToString() == "0")
                news.RCRegistration_TD = false;
            else
                news.RCRegistration_TD = true;
            if (string.IsNullOrEmpty(reader["RecruitRegistration_TT"].ToString()) || reader["RecruitRegistration_TT"].ToString() == "0")
                news.RCRegistration_TT = false;
            else
                news.RCRegistration_TT = true;
            if (string.IsNullOrEmpty(reader["RecruitRegisted"].ToString()) || reader["RecruitRegisted"].ToString() == "0")
                news.RCRegisted = false;
            else
                news.RCRegisted = true;
            if (string.IsNullOrEmpty(reader["RecruitApproval"].ToString()) || reader["RecruitApproval"].ToString() == "0")
                news.RCApproval = false;
            else
                news.RCApproval = true;
            if (string.IsNullOrEmpty(reader["RecruitStatistic"].ToString()) || reader["RecruitStatistic"].ToString() == "0")
                news.RCStatistic = false;
            else
                news.RCStatistic = true;
            if (string.IsNullOrEmpty(reader["ViewRecruit"].ToString()) || reader["ViewRecruit"].ToString() == "0")
                news.ViewRecruit = false;
            else
                news.ViewRecruit = true;

            return news;
        }
        public void CreateNews(tbl_MenuRole news)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("__", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@GroupCode", news.RoleCode));
                command.Parameters.Add(new SqlParameter("@News", news.News));
                command.Parameters.Add(new SqlParameter("@ChangePassWord", news.ChangePassWord));

                command.Parameters.Add(new SqlParameter("@Registration", news.Registration));
                command.Parameters.Add(new SqlParameter("@Approval", news.Approval));
                command.Parameters.Add(new SqlParameter("@LeaveReport", news.LeaveReport));

                command.Parameters.Add(new SqlParameter("@KPI4Employee", news.KPI4Employee));
                command.Parameters.Add(new SqlParameter("@KPI4Manager", news.KPI4Manager));
                command.Parameters.Add(new SqlParameter("@KPIInfo", news.KPIInfo));

                command.Parameters.Add(new SqlParameter("@Salary", news.Salary));
                command.Parameters.Add(new SqlParameter("@Skill_Will", news.Skill_Will));

                command.Parameters.Add(new SqlParameter("@HRNew", news.HRNew));
                command.Parameters.Add(new SqlParameter("@ManagerLevel", news.ManagerLevel));
                command.Parameters.Add(new SqlParameter("@PassManagement", news.PassManagement));

                command.Parameters.Add(new SqlParameter("@OTRegistration", news.OTRegistration));
                command.Parameters.Add(new SqlParameter("@OTRegisted", news.OTRegisted));
                command.Parameters.Add(new SqlParameter("@OTApproval", news.OTApproval));
                command.Parameters.Add(new SqlParameter("@OTStatistic", news.OTStatistic));

                command.Parameters.Add(new SqlParameter("@RecruitRegistration", news.RCRegistration_TD));
                command.Parameters.Add(new SqlParameter("@RecruitRegisted", news.RCRegisted));
                command.Parameters.Add(new SqlParameter("@RecruitApproval", news.RCApproval));
                command.Parameters.Add(new SqlParameter("@RecruitStatistic", news.RCStatistic));

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public bool UpdateNews(tbl_MenuRole news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@GroupCode", news.RoleCode));
                    command.Parameters.Add(new SqlParameter("@News", news.News));
                    command.Parameters.Add(new SqlParameter("@ChangePassWord", news.ChangePassWord));

                    command.Parameters.Add(new SqlParameter("@Registration", news.Registration));
                    command.Parameters.Add(new SqlParameter("@Approval", news.Approval));
                    command.Parameters.Add(new SqlParameter("@LeaveReport", news.LeaveReport));

                    command.Parameters.Add(new SqlParameter("@KPI4Employee", news.KPI4Employee));
                    command.Parameters.Add(new SqlParameter("@KPI4Manager", news.KPI4Manager));
                    command.Parameters.Add(new SqlParameter("@KPIInfo", news.KPIInfo));

                    command.Parameters.Add(new SqlParameter("@Salary", news.Salary));
                    command.Parameters.Add(new SqlParameter("@Skill_Will", news.Skill_Will));

                    command.Parameters.Add(new SqlParameter("@HRNew", news.HRNew));
                    command.Parameters.Add(new SqlParameter("@ManagerLevel", news.ManagerLevel));
                    command.Parameters.Add(new SqlParameter("@PassManagement", news.PassManagement));

                    command.Parameters.Add(new SqlParameter("@OTRegistration", news.OTRegistration));
                    command.Parameters.Add(new SqlParameter("@OTRegisted", news.OTRegisted));
                    command.Parameters.Add(new SqlParameter("@OTApproval", news.OTApproval));
                    command.Parameters.Add(new SqlParameter("@OTStatistic", news.OTStatistic));

                    command.Parameters.Add(new SqlParameter("@RecruitRegistration", news.RCRegistration_TD));
                    command.Parameters.Add(new SqlParameter("@RecruitRegisted", news.RCRegisted));
                    command.Parameters.Add(new SqlParameter("@RecruitApproval", news.RCApproval));
                    command.Parameters.Add(new SqlParameter("@RecruitStatistic", news.RCStatistic));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
                catch (Exception ex)
                {
                    
                }
            }
            
            return result;
        }
        public bool DeleteNews(tbl_MenuRole news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("__", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@GroupCode", news.RoleCode));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tbl_MenuRole GetInfoByID(string Procedure_Name, string thamso, string GroupCode)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, GroupCode));

                connection.Open();
                tbl_MenuRole news = null;
                try
                {
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                            news = CreateNewsFromReader(reader);
                    }
                }
                catch (Exception ex) { }
                return news;
            }
        }
        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string GroupCode)
        {

            return StoreToTable(Procedure_Name, Table_Name, GroupCode);

        }
        public List<tbl_MenuRole> GetListByID(string Procedure_name, string thamso, string GroupCode)
        {
            List<tbl_MenuRole> newsList = new List<tbl_MenuRole>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, GroupCode));

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
    }
}