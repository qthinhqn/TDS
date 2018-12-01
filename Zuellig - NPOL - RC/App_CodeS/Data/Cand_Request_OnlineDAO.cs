using NPOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Data
{
    public class Cand_Request_OnlineDAO : BaseDAO
    {
        public Cand_Request_OnlineDAO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private tblCand_Request_Online CreateNewsFromReader(IDataReader reader)
        {
            tblCand_Request_Online news = new tblCand_Request_Online();
            news.RequestID = (string)reader["RequestID"];

            if (string.IsNullOrEmpty(reader["DateID"].ToString()))
                news.DateID = DateTime.Now;
            else
                news.DateID = DateTime.Parse(reader["DateID"].ToString());

            if (!string.IsNullOrEmpty(reader["ReceivedDate"].ToString()))
                news.ReceivedDate = DateTime.Parse(reader["ReceivedDate"].ToString());

            if (!string.IsNullOrEmpty(reader["DeadLine"].ToString()))
                news.DeadLine = DateTime.Parse(reader["DeadLine"].ToString());

            if (!string.IsNullOrEmpty(reader["FinalDate"].ToString()))
                news.FinalDate = DateTime.Parse(reader["FinalDate"].ToString());

            if (string.IsNullOrEmpty(reader["RecruitByID"].ToString()))
                news.RecruitByID = "";
            else
                news.RecruitByID = reader["RecruitByID"].ToString();

            if (string.IsNullOrEmpty(reader["SectionID"].ToString()))
                news.SectionID = "";
            else
                news.SectionID = reader["SectionID"].ToString();

            if (string.IsNullOrEmpty(reader["LineID"].ToString()))
                news.LineID = "";
            else
                news.LineID = reader["LineID"].ToString();

            if (string.IsNullOrEmpty(reader["DepID"].ToString()))
                news.DepID = "";
            else
                news.DepID = reader["DepID"].ToString();

            if (string.IsNullOrEmpty(reader["LevelID"].ToString()))
                news.LevelID = "";
            else
                news.LevelID = reader["LevelID"].ToString();

            if (string.IsNullOrEmpty(reader["PosID"].ToString()))
                news.PosID = "";
            else
                news.PosID = reader["PosID"].ToString();

            if (string.IsNullOrEmpty(reader["RegionID"].ToString()))
                news.RegionID = "";
            else
                news.RegionID = reader["RegionID"].ToString();

            if (string.IsNullOrEmpty(reader["Numof"].ToString()))
                news.Numof = 0;
            else
                news.Numof = (int)reader["Numof"];

            if (string.IsNullOrEmpty(reader["TypeID"].ToString()))
                news.TypeID = "";
            else
                news.TypeID = reader["TypeID"].ToString();

            if (string.IsNullOrEmpty(reader["ReasonID"].ToString()))
                news.ReasonID = "";
            else
                news.ReasonID = reader["ReasonID"].ToString();

            if (string.IsNullOrEmpty(reader["EmpID_Replace"].ToString()))
                news.EmpID_Replace = "";
            else
                news.EmpID_Replace = reader["EmpID_Replace"].ToString();

            if (string.IsNullOrEmpty(reader["EmpReplace_Sal"].ToString()))
                news.EmpReplace_Sal = 0;
            else
                news.EmpReplace_Sal = (double)(reader["EmpReplace_Sal"]);

            if (string.IsNullOrEmpty(reader["EmpReplace_Allowance"].ToString()))
                news.EmpReplace_Allowance = 0;
            else
                news.EmpReplace_Allowance = (double)(reader["EmpReplace_Allowance"]);

            if (!string.IsNullOrEmpty(reader["IsInternalPost"].ToString()))
                news.IsInternalPost = (bool)(reader["IsInternalPost"]);

            if (string.IsNullOrEmpty(reader["LocationID"].ToString()))
                news.LocationID = "";
            else
                news.LocationID = reader["LocationID"].ToString();

            if (string.IsNullOrEmpty(reader["SexID"].ToString()))
                news.SexID = "";
            else
                news.SexID = reader["SexID"].ToString();

            if (!string.IsNullOrEmpty(reader["JobDes"].ToString()))
                news.JobDes = (bool)(reader["JobDes"]);

            if (string.IsNullOrEmpty(reader["JobDes_File"].ToString()))
                news.JobDes_File = "";
            else
                news.JobDes_File = reader["JobDes_File"].ToString();

            if (!string.IsNullOrEmpty(reader["IsBudgetHead"].ToString()))
                news.IsBudgetHead = (bool)(reader["IsBudgetHead"]);

            if (!string.IsNullOrEmpty(reader["StartDate"].ToString()))
                news.StartDate = DateTime.Parse(reader["StartDate"].ToString());

            if (reader["ProbationID"] == DBNull.Value)
                news.ProbationID = null;
            else
                news.ProbationID = reader["ProbationID"].ToString();

            if (string.IsNullOrEmpty(reader["Probation_Sal"].ToString()))
                news.Probation_Sal = 0;
            else
                news.Probation_Sal = (double)(reader["Probation_Sal"]);

            if (string.IsNullOrEmpty(reader["Probation_Travel"].ToString()))
                news.Probation_Travel = 0;
            else
                news.Probation_Travel = (double)(reader["Probation_Travel"]);

            if (string.IsNullOrEmpty(reader["Probation_Allowance"].ToString()))
                news.Probation_Allowance = 0;
            else
                news.Probation_Allowance = (double)(reader["Probation_Allowance"]);

            if (string.IsNullOrEmpty(reader["Permanent_Sal"].ToString()))
                news.Permanent_Sal = 0;
            else
                news.Permanent_Sal = (double)(reader["Permanent_Sal"]);

            if (string.IsNullOrEmpty(reader["Permanent_Travel"].ToString()))
                news.Permanent_Travel = 0;
            else
                news.Permanent_Travel = (double)(reader["Permanent_Travel"]);

            if (string.IsNullOrEmpty(reader["Permanent_Allowance"].ToString()))
                news.Permanent_Allowance = 0;
            else
                news.Permanent_Allowance = (double)(reader["Permanent_Allowance"]);

            if (string.IsNullOrEmpty(reader["Requester"].ToString()))
                news.Requester = "";
            else
                news.Requester = reader["Requester"].ToString();

            if (string.IsNullOrEmpty(reader["ReportTo"].ToString()))
                news.ReportTo = "";
            else
                news.ReportTo = reader["ReportTo"].ToString();

            if (string.IsNullOrEmpty(reader["ApprovedBy"].ToString()))
                news.ApprovedBy = "";
            else
                news.ApprovedBy = reader["ApprovedBy"].ToString();

            if (!string.IsNullOrEmpty(reader["ApprovedDate"].ToString()))
                news.StartDate = DateTime.Parse(reader["ApprovedDate"].ToString());

            if (string.IsNullOrEmpty(reader["HRDept_Note"].ToString()))
                news.HRDept_Note = "";
            else
                news.HRDept_Note = reader["HRDept_Note"].ToString();

            if (string.IsNullOrEmpty(reader["ContractID"].ToString()))
                news.ContractID = "";
            else
                news.ContractID = reader["ContractID"].ToString();

            if (string.IsNullOrEmpty(reader["EmpID_Other"].ToString()))
                news.EmpID_Other = "";
            else
                news.EmpID_Other = reader["EmpID_Other"].ToString();

            if (string.IsNullOrEmpty(reader["EmpID_Apply"].ToString()))
                news.EmpID_Apply = "";
            else
                news.EmpID_Apply = reader["EmpID_Apply"].ToString();

            if (string.IsNullOrEmpty(reader["Apply_Name"].ToString()))
                news.Apply_Name = "";
            else
                news.Apply_Name = reader["Apply_Name"].ToString();

            if (string.IsNullOrEmpty(reader["To_PosID"].ToString()))
                news.To_PosID = "";
            else
                news.To_PosID = reader["To_PosID"].ToString();

            if (string.IsNullOrEmpty(reader["To_LineID"].ToString()))
                news.To_LineID = "";
            else
                news.To_LineID = reader["To_LineID"].ToString();

            if (string.IsNullOrEmpty(reader["To_DepID"].ToString()))
                news.To_DepID = "";
            else
                news.To_DepID = reader["To_DepID"].ToString();

            if (string.IsNullOrEmpty(reader["To_LocationID"].ToString()))
                news.To_LocationID = "";
            else
                news.To_LocationID = reader["To_LocationID"].ToString();

            if (string.IsNullOrEmpty(reader["Other_old"].ToString()))
                news.Other_old = "";
            else
                news.Other_old = reader["Other_old"].ToString();

            if (string.IsNullOrEmpty(reader["Other_new"].ToString()))
                news.Other_new = "";
            else
                news.Other_new = reader["Other_new"].ToString();

            //if (string.IsNullOrEmpty(reader["FinalStatus"].ToString()))
            //    news.FinalStatus = "";
            //else
            //    news.FinalStatus = reader["FinalStatus"].ToString();

            //if (string.IsNullOrEmpty(reader["MailToUser"].ToString()))
            //    news.MailToUser = 0;
            //else
            //    news.MailToUser = (int)reader["MailToUser"];

            if (string.IsNullOrEmpty(reader["OtherDescription"].ToString()))
                news.OtherDescription = "";
            else
                news.OtherDescription = reader["OtherDescription"].ToString();

            if (string.IsNullOrEmpty(reader["Other_oldValue"].ToString()))
                news.Other_oldValue = "";
            else
                news.Other_oldValue = reader["Other_oldValue"].ToString();

            if (string.IsNullOrEmpty(reader["Other_newValue"].ToString()))
                news.Other_newValue = "";
            else
                news.Other_newValue = reader["Other_newValue"].ToString();

            if (string.IsNullOrEmpty(reader["ProAdj_Type"].ToString()))
                news.ProAdj_Type = "";
            else
                news.ProAdj_Type = reader["ProAdj_Type"].ToString();

            // 
            //if (!string.IsNullOrEmpty(reader["RegType"].ToString()))
            //    news.RegType = (Boolean)reader["RegType"];

            if (string.IsNullOrEmpty(reader["Other_old2Value"].ToString()))
                news.Other_old2Value = "";
            else
                news.Other_old2Value = reader["Other_old2Value"].ToString();

            if (string.IsNullOrEmpty(reader["Other_new2Value"].ToString()))
                news.Other_new2Value = "";
            else
                news.Other_new2Value = reader["Other_new2Value"].ToString();


            if (string.IsNullOrEmpty(reader["Remarks"].ToString()))
                news.Remarks = "";
            else
                news.Remarks = reader["Remarks"].ToString();

            return news;
        }
        public void CreateNews(tblCand_Request_Online news)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spInsert_tblCand_Request_Online", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));
                    command.Parameters.Add(new SqlParameter("@DateID", news.DateID));
                    command.Parameters.Add(new SqlParameter("@ReceivedDate", news.ReceivedDate));
                    command.Parameters.Add(new SqlParameter("@DeadLine", news.DeadLine));
                    command.Parameters.Add(new SqlParameter("@FinalDate", news.FinalDate));
                    command.Parameters.Add(new SqlParameter("@RecruitByID", news.RecruitByID));
                    command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                    command.Parameters.Add(new SqlParameter("@LineID", news.LineID));
                    command.Parameters.Add(new SqlParameter("@DepID", news.DepID));
                    command.Parameters.Add(new SqlParameter("@LevelID", news.LevelID));
                    command.Parameters.Add(new SqlParameter("@PosID", news.PosID));
                    command.Parameters.Add(new SqlParameter("@RegionID", news.RegionID));
                    command.Parameters.Add(new SqlParameter("@Numof", news.Numof));
                    command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                    command.Parameters.Add(new SqlParameter("@ReasonID", news.ReasonID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Replace", news.EmpID_Replace));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Sal", news.EmpReplace_Sal));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Allowance", news.EmpReplace_Allowance));
                    command.Parameters.Add(new SqlParameter("@IsInternalPost", news.IsInternalPost));
                    command.Parameters.Add(new SqlParameter("@LocationID", news.LocationID));
                    command.Parameters.Add(new SqlParameter("@SexID", news.SexID));
                    command.Parameters.Add(new SqlParameter("@JobDes", news.JobDes));
                    command.Parameters.Add(new SqlParameter("@JobDes_File", news.JobDes_File));
                    command.Parameters.Add(new SqlParameter("@IsBudgetHead", news.IsBudgetHead));
                    command.Parameters.Add(new SqlParameter("@StartDate", news.StartDate));
                    command.Parameters.Add(new SqlParameter("@ProbationID", news.ProbationID));
                    command.Parameters.Add(new SqlParameter("@Probation_Sal", news.Probation_Sal));
                    command.Parameters.Add(new SqlParameter("@Probation_Travel", news.Probation_Travel));
                    command.Parameters.Add(new SqlParameter("@Probation_Allowance", news.Probation_Allowance));
                    command.Parameters.Add(new SqlParameter("@Permanent_Sal", news.Permanent_Sal));
                    command.Parameters.Add(new SqlParameter("@Permanent_Travel", news.Permanent_Travel));
                    command.Parameters.Add(new SqlParameter("@Permanent_Allowance", news.Permanent_Allowance));
                    command.Parameters.Add(new SqlParameter("@Requester", news.Requester));
                    command.Parameters.Add(new SqlParameter("@ReportTo", news.ReportTo));
                    command.Parameters.Add(new SqlParameter("@ApprovedBy", news.ApprovedBy));
                    command.Parameters.Add(new SqlParameter("@ApprovedDate", news.ApprovedDate));
                    command.Parameters.Add(new SqlParameter("@HRDept_Note", news.HRDept_Note));
                    command.Parameters.Add(new SqlParameter("@ContractID", news.ContractID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Other", news.EmpID_Other));
                    command.Parameters.Add(new SqlParameter("@EmpID_Apply", news.EmpID_Apply));
                    command.Parameters.Add(new SqlParameter("@Apply_Name", news.Apply_Name));
                    command.Parameters.Add(new SqlParameter("@To_LineID", news.To_LineID));
                    command.Parameters.Add(new SqlParameter("@To_DepID", news.To_DepID));
                    command.Parameters.Add(new SqlParameter("@To_LocationID", news.To_LocationID));
                    command.Parameters.Add(new SqlParameter("@To_PosID", news.To_PosID));
                    command.Parameters.Add(new SqlParameter("@Other_old", news.Other_old));
                    command.Parameters.Add(new SqlParameter("@Other_new", news.Other_new));
                    command.Parameters.Add(new SqlParameter("@OtherDescription", news.OtherDescription));
                    command.Parameters.Add(new SqlParameter("@Other_oldValue", news.Other_oldValue));
                    command.Parameters.Add(new SqlParameter("@Other_newValue", news.Other_newValue));

                    command.Parameters.Add(new SqlParameter("@ProAdj_Type", news.ProAdj_Type));
                    command.Parameters.Add(new SqlParameter("@Other_old2Value", news.Other_old2Value));
                    command.Parameters.Add(new SqlParameter("@Other_new2Value", news.Other_new2Value));
                    command.Parameters.Add(new SqlParameter("@Remarks", news.Remarks));

                    foreach (SqlParameter par in command.Parameters)
                    {
                        if (par.Value == null)
                            par.Value = DBNull.Value;
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            { }
        }

        public void CreateNews_Tmp(tblCand_Request_Online news)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("spInsert_tblCand_Request_Online_Tmp", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));
                    command.Parameters.Add(new SqlParameter("@DateID", news.DateID));
                    command.Parameters.Add(new SqlParameter("@ReceivedDate", news.ReceivedDate));
                    command.Parameters.Add(new SqlParameter("@DeadLine", news.DeadLine));
                    command.Parameters.Add(new SqlParameter("@FinalDate", news.FinalDate));
                    command.Parameters.Add(new SqlParameter("@RecruitByID", news.RecruitByID));
                    command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                    command.Parameters.Add(new SqlParameter("@LineID", news.LineID));
                    command.Parameters.Add(new SqlParameter("@DepID", news.DepID));
                    command.Parameters.Add(new SqlParameter("@LevelID", news.LevelID));
                    command.Parameters.Add(new SqlParameter("@PosID", news.PosID));
                    command.Parameters.Add(new SqlParameter("@RegionID", news.RegionID));
                    command.Parameters.Add(new SqlParameter("@Numof", news.Numof));
                    command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                    command.Parameters.Add(new SqlParameter("@ReasonID", news.ReasonID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Replace", news.EmpID_Replace));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Sal", news.EmpReplace_Sal));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Allowance", news.EmpReplace_Allowance));
                    command.Parameters.Add(new SqlParameter("@IsInternalPost", news.IsInternalPost));
                    command.Parameters.Add(new SqlParameter("@LocationID", news.LocationID));
                    command.Parameters.Add(new SqlParameter("@SexID", news.SexID));
                    command.Parameters.Add(new SqlParameter("@JobDes", news.JobDes));
                    command.Parameters.Add(new SqlParameter("@JobDes_File", news.JobDes_File));
                    command.Parameters.Add(new SqlParameter("@IsBudgetHead", news.IsBudgetHead));
                    command.Parameters.Add(new SqlParameter("@StartDate", news.StartDate));
                    command.Parameters.Add(new SqlParameter("@ProbationID", news.ProbationID));
                    command.Parameters.Add(new SqlParameter("@Probation_Sal", news.Probation_Sal));
                    command.Parameters.Add(new SqlParameter("@Probation_Travel", news.Probation_Travel));
                    command.Parameters.Add(new SqlParameter("@Probation_Allowance", news.Probation_Allowance));
                    command.Parameters.Add(new SqlParameter("@Permanent_Sal", news.Permanent_Sal));
                    command.Parameters.Add(new SqlParameter("@Permanent_Travel", news.Permanent_Travel));
                    command.Parameters.Add(new SqlParameter("@Permanent_Allowance", news.Permanent_Allowance));
                    command.Parameters.Add(new SqlParameter("@Requester", news.Requester));
                    command.Parameters.Add(new SqlParameter("@ReportTo", news.ReportTo));
                    command.Parameters.Add(new SqlParameter("@ApprovedBy", news.ApprovedBy));
                    command.Parameters.Add(new SqlParameter("@ApprovedDate", news.ApprovedDate));
                    command.Parameters.Add(new SqlParameter("@HRDept_Note", news.HRDept_Note));
                    command.Parameters.Add(new SqlParameter("@ContractID", news.ContractID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Other", news.EmpID_Other));
                    command.Parameters.Add(new SqlParameter("@EmpID_Apply", news.EmpID_Apply));
                    command.Parameters.Add(new SqlParameter("@Apply_Name", news.Apply_Name));
                    command.Parameters.Add(new SqlParameter("@To_LineID", news.To_LineID));
                    command.Parameters.Add(new SqlParameter("@To_DepID", news.To_DepID));
                    command.Parameters.Add(new SqlParameter("@To_LocationID", news.To_LocationID));
                    command.Parameters.Add(new SqlParameter("@To_PosID", news.To_PosID));
                    command.Parameters.Add(new SqlParameter("@Other_old", news.Other_old));
                    command.Parameters.Add(new SqlParameter("@Other_new", news.Other_new));
                    command.Parameters.Add(new SqlParameter("@OtherDescription", news.OtherDescription));
                    command.Parameters.Add(new SqlParameter("@Other_oldValue", news.Other_oldValue));
                    command.Parameters.Add(new SqlParameter("@Other_newValue", news.Other_newValue));
                    command.Parameters.Add(new SqlParameter("@ProAdj_Type", news.ProAdj_Type));

                    command.Parameters.Add(new SqlParameter("@RegType", news.RegType));
                    command.Parameters.Add(new SqlParameter("@Other_old2Value", news.Other_old2Value));
                    command.Parameters.Add(new SqlParameter("@Other_new2Value", news.Other_new2Value));
                    command.Parameters.Add(new SqlParameter("@Remarks", news.Remarks));

                    foreach (SqlParameter par in command.Parameters)
                    {
                        if (par.Value == null)
                            par.Value = DBNull.Value;
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            { }
        }

        public bool UpdateNews(tblCand_Request_Online news)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("spUpdate_tblCand_Request_Online", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));
                    command.Parameters.Add(new SqlParameter("@DateID", news.DateID));
                    command.Parameters.Add(new SqlParameter("@ReceivedDate", news.ReceivedDate));
                    command.Parameters.Add(new SqlParameter("@DeadLine", news.DeadLine));
                    command.Parameters.Add(new SqlParameter("@FinalDate", news.FinalDate));
                    command.Parameters.Add(new SqlParameter("@RecruitByID", news.RecruitByID));
                    command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                    command.Parameters.Add(new SqlParameter("@LineID", news.LineID));
                    command.Parameters.Add(new SqlParameter("@DepID", news.DepID));
                    command.Parameters.Add(new SqlParameter("@LevelID", news.LevelID));
                    command.Parameters.Add(new SqlParameter("@PosID", news.PosID));
                    command.Parameters.Add(new SqlParameter("@RegionID", news.RegionID));
                    command.Parameters.Add(new SqlParameter("@Numof", news.Numof));
                    command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                    command.Parameters.Add(new SqlParameter("@ReasonID", news.ReasonID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Replace", news.EmpID_Replace));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Sal", news.EmpReplace_Sal));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Allowance", news.EmpReplace_Allowance));
                    command.Parameters.Add(new SqlParameter("@IsInternalPost", news.IsInternalPost));
                    command.Parameters.Add(new SqlParameter("@LocationID", news.LocationID));
                    command.Parameters.Add(new SqlParameter("@SexID", news.SexID));
                    command.Parameters.Add(new SqlParameter("@JobDes", news.JobDes));
                    command.Parameters.Add(new SqlParameter("@JobDes_File", news.JobDes_File));
                    command.Parameters.Add(new SqlParameter("@IsBudgetHead", news.IsBudgetHead));
                    command.Parameters.Add(new SqlParameter("@StartDate", news.StartDate));
                    command.Parameters.Add(new SqlParameter("@ProbationID", news.ProbationID));
                    command.Parameters.Add(new SqlParameter("@Probation_Sal", news.Probation_Sal));
                    command.Parameters.Add(new SqlParameter("@Probation_Travel", news.Probation_Travel));
                    command.Parameters.Add(new SqlParameter("@Probation_Allowance", news.Probation_Allowance));
                    command.Parameters.Add(new SqlParameter("@Permanent_Sal", news.Permanent_Sal));
                    command.Parameters.Add(new SqlParameter("@Permanent_Travel", news.Permanent_Travel));
                    command.Parameters.Add(new SqlParameter("@Permanent_Allowance", news.Permanent_Allowance));
                    command.Parameters.Add(new SqlParameter("@Requester", news.Requester));
                    command.Parameters.Add(new SqlParameter("@ReportTo", news.ReportTo));
                    command.Parameters.Add(new SqlParameter("@ApprovedBy", news.ApprovedBy));
                    command.Parameters.Add(new SqlParameter("@ApprovedDate", news.ApprovedDate));
                    command.Parameters.Add(new SqlParameter("@HRDept_Note", news.HRDept_Note));
                    command.Parameters.Add(new SqlParameter("@ContractID", news.ContractID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Other", news.EmpID_Other));
                    command.Parameters.Add(new SqlParameter("@EmpID_Apply", news.EmpID_Apply));
                    command.Parameters.Add(new SqlParameter("@Apply_Name", news.Apply_Name));
                    command.Parameters.Add(new SqlParameter("@To_LineID", news.To_LineID));
                    command.Parameters.Add(new SqlParameter("@To_DepID", news.To_DepID));
                    command.Parameters.Add(new SqlParameter("@To_LocationID", news.To_LocationID));
                    command.Parameters.Add(new SqlParameter("@To_PosID", news.To_PosID));
                    command.Parameters.Add(new SqlParameter("@Other_old", news.Other_old));
                    command.Parameters.Add(new SqlParameter("@Other_new", news.Other_new));
                    command.Parameters.Add(new SqlParameter("@OtherDescription", news.OtherDescription));
                    command.Parameters.Add(new SqlParameter("@Other_oldValue", news.Other_oldValue));
                    command.Parameters.Add(new SqlParameter("@Other_newValue", news.Other_newValue));
                    command.Parameters.Add(new SqlParameter("@ProAdj_Type", news.ProAdj_Type));

                    //command.Parameters.Add(new SqlParameter("@RegType", news.RegType));
                    command.Parameters.Add(new SqlParameter("@Other_old2Value", news.Other_old2Value));
                    command.Parameters.Add(new SqlParameter("@Other_new2Value", news.Other_new2Value));
                    command.Parameters.Add(new SqlParameter("@Remarks", news.Remarks));

                    foreach (SqlParameter par in command.Parameters)
                    {
                        if (par.Value == null)
                            par.Value = DBNull.Value;
                    }

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

        public bool UpdateNews_2(tblCand_Request_Online news, object empID, object levelNo, int UpdateType)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand("spUpdate_tblCand_Request_Online_2", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));
                    command.Parameters.Add(new SqlParameter("@DateID", news.DateID));
                    command.Parameters.Add(new SqlParameter("@ReceivedDate", news.ReceivedDate));
                    command.Parameters.Add(new SqlParameter("@DeadLine", news.DeadLine));
                    command.Parameters.Add(new SqlParameter("@FinalDate", news.FinalDate));
                    command.Parameters.Add(new SqlParameter("@RecruitByID", news.RecruitByID));
                    command.Parameters.Add(new SqlParameter("@SectionID", news.SectionID));
                    command.Parameters.Add(new SqlParameter("@LineID", news.LineID));
                    command.Parameters.Add(new SqlParameter("@DepID", news.DepID));
                    command.Parameters.Add(new SqlParameter("@LevelID", news.LevelID));
                    command.Parameters.Add(new SqlParameter("@PosID", news.PosID));
                    command.Parameters.Add(new SqlParameter("@RegionID", news.RegionID));
                    command.Parameters.Add(new SqlParameter("@Numof", news.Numof));
                    command.Parameters.Add(new SqlParameter("@TypeID", news.TypeID));
                    command.Parameters.Add(new SqlParameter("@ReasonID", news.ReasonID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Replace", news.EmpID_Replace));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Sal", news.EmpReplace_Sal));
                    command.Parameters.Add(new SqlParameter("@EmpReplace_Allowance", news.EmpReplace_Allowance));
                    command.Parameters.Add(new SqlParameter("@IsInternalPost", news.IsInternalPost));
                    command.Parameters.Add(new SqlParameter("@LocationID", news.LocationID));
                    command.Parameters.Add(new SqlParameter("@SexID", news.SexID));
                    command.Parameters.Add(new SqlParameter("@JobDes", news.JobDes));
                    command.Parameters.Add(new SqlParameter("@JobDes_File", news.JobDes_File));
                    command.Parameters.Add(new SqlParameter("@IsBudgetHead", news.IsBudgetHead));
                    command.Parameters.Add(new SqlParameter("@StartDate", news.StartDate));
                    command.Parameters.Add(new SqlParameter("@ProbationID", news.ProbationID));
                    command.Parameters.Add(new SqlParameter("@Probation_Sal", news.Probation_Sal));
                    command.Parameters.Add(new SqlParameter("@Probation_Travel", news.Probation_Travel));
                    command.Parameters.Add(new SqlParameter("@Probation_Allowance", news.Probation_Allowance));
                    command.Parameters.Add(new SqlParameter("@Permanent_Sal", news.Permanent_Sal));
                    command.Parameters.Add(new SqlParameter("@Permanent_Travel", news.Permanent_Travel));
                    command.Parameters.Add(new SqlParameter("@Permanent_Allowance", news.Permanent_Allowance));
                    command.Parameters.Add(new SqlParameter("@Requester", news.Requester));
                    command.Parameters.Add(new SqlParameter("@ReportTo", news.ReportTo));
                    command.Parameters.Add(new SqlParameter("@ApprovedBy", news.ApprovedBy));
                    command.Parameters.Add(new SqlParameter("@ApprovedDate", news.ApprovedDate));
                    command.Parameters.Add(new SqlParameter("@HRDept_Note", news.HRDept_Note));
                    command.Parameters.Add(new SqlParameter("@ContractID", news.ContractID));
                    command.Parameters.Add(new SqlParameter("@EmpID_Other", news.EmpID_Other));
                    command.Parameters.Add(new SqlParameter("@EmpID_Apply", news.EmpID_Apply));
                    command.Parameters.Add(new SqlParameter("@Apply_Name", news.Apply_Name));
                    command.Parameters.Add(new SqlParameter("@To_LineID", news.To_LineID));
                    command.Parameters.Add(new SqlParameter("@To_DepID", news.To_DepID));
                    command.Parameters.Add(new SqlParameter("@To_LocationID", news.To_LocationID));
                    command.Parameters.Add(new SqlParameter("@To_PosID", news.To_PosID));
                    command.Parameters.Add(new SqlParameter("@Other_old", news.Other_old));
                    command.Parameters.Add(new SqlParameter("@Other_new", news.Other_new));
                    command.Parameters.Add(new SqlParameter("@OtherDescription", news.OtherDescription));
                    command.Parameters.Add(new SqlParameter("@Other_oldValue", news.Other_oldValue));
                    command.Parameters.Add(new SqlParameter("@Other_newValue", news.Other_newValue));
                    command.Parameters.Add(new SqlParameter("@ProAdj_Type", news.ProAdj_Type));

                    //command.Parameters.Add(new SqlParameter("@RegType", news.RegType));
                    command.Parameters.Add(new SqlParameter("@Other_old2Value", news.Other_old2Value));
                    command.Parameters.Add(new SqlParameter("@Other_new2Value", news.Other_new2Value));
                    command.Parameters.Add(new SqlParameter("@Remarks", news.Remarks));

                    // New Param 
                    command.Parameters.Add(new SqlParameter("@UserID", empID));
                    command.Parameters.Add(new SqlParameter("@LevelNo", levelNo));
                    command.Parameters.Add(new SqlParameter("@UpdateType", UpdateType));

                    foreach (SqlParameter par in command.Parameters)
                    {
                        if (par.Value == null)
                            par.Value = DBNull.Value;
                    }

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

        public bool DeleteNews(tblCand_Request_Online news)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand command = new SqlCommand("DELETE FROM [dbo].[tblCand_Request_Online] WHERE [RequestID]=@RequestID ", connection);
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add(new SqlParameter("@RequestID", news.RequestID));

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                        result = true;
                }
            }
            catch (Exception ex) { }
            return result;
        }

        public tblCand_Request_Online GetInfoByID(string Procedure_Name, string thamso, string EmpID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(Procedure_Name, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(thamso, EmpID));

                connection.Open();
                tblCand_Request_Online news = null;
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
        public tblCand_Request_Online GetInfoByRequestID(string strSQL, string RequestID)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand(strSQL, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("@RequestID", RequestID));

                connection.Open();
                tblCand_Request_Online news = null;
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
        public DataTable GetEmpInfoByid(string Procedure_Name, string Table_Name, string empid)
        {

            return StoreToTable(Procedure_Name, Table_Name, empid);

        }
        public DataTable GetTableByid(string Procedure_Name, string Table_Name, string empid)
        {

            return StoreToTable(Procedure_Name, Table_Name, empid);

        }
        public List<tblCand_Request_Online> GetListByID(string Procedure_name, string thamso, string EmpID)
        {
            List<tblCand_Request_Online> newsList = new List<tblCand_Request_Online>();
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

        public List<string> GetEmployeeNameByID(string Procedure_name, string thamso, string EmpID, string search)
        {
            List<string> newsList = new List<string>();
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Procedure_name, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter(thamso, EmpID));
                    command.Parameters.Add(new SqlParameter("@Search", search));

                    connection.Open();
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            newsList.Add((string)reader["EmployeeName"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return newsList;
        }
        public bool IsRepresentative(string EmpID)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string sql = "select count(*) from tblRecruitManagerLevel where EmployeeID = @EmpID";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("EmpID", EmpID));

                connection.Open();
                try
                {
                    Object obj = command.ExecuteScalar();
                    if (int.Parse(obj.ToString()) > 0)
                        result = true;
                }
                catch (Exception ex) { }
            }
            return result;
        }

        public bool IsLineManager(string EmpID, string managerID)
        {
            bool result = false;
            using (SqlConnection connection = GetConnection())
            {
                string sql = "select count(*) from v_EmpLineManager where EmployeeID = @EmpID AND ISNULL(@ManagerID,'') <> '' AND @ManagerID in (ManagerID_L1, ManagerID_L2, ManagerID_L3, ManagerID_L4, ManagerID_L5, ManagerID_L6, ManagerID_L7, ManagerID_L8)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add(new SqlParameter("EmpID", EmpID));
                command.Parameters.Add(new SqlParameter("ManagerID", managerID));

                connection.Open();
                try
                {
                    Object obj = command.ExecuteScalar();
                    if (int.Parse(obj.ToString()) > 0)
                        result = true;
                }
                catch (Exception ex) { }
            }
            return result;
        }

    }
}