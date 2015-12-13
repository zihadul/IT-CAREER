using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    public class dalCareerCandidateJob
    {


        public DataTable GetCareerCandidateJob(int StartRowIndex, int MaxRows, string Criteria, int JobID,
            string Qualification, string Training, bool ShortListed, bool Rejected, bool PrintMode)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StartRowIndex", StartRowIndex));
            altParams.Add(new SqlParameter("@MaxRows", MaxRows));
            altParams.Add(new SqlParameter("@Criteria", Criteria));
            altParams.Add(new SqlParameter("@JobID", JobID));
            altParams.Add(new SqlParameter("@Qualification", Qualification));
            altParams.Add(new SqlParameter("@Training", Training));
            altParams.Add(new SqlParameter("@ShortListed", ShortListed));
            altParams.Add(new SqlParameter("@Rejected", Rejected));
            altParams.Add(new SqlParameter("@PrintMode", PrintMode));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateJob_GetAll", altParams);
        }


        public DataTable GetCareerCandidateJob(int JobID, int CandidateID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@JobID", JobID));
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));

            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateJob_GetByCandidateIDAndJobID", altParams);
        }



        public int InsertCandidateJob(int JobID, int CandidateID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@JobID", JobID));
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
           
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateJob_Insert", altParams);
        }



        public DataTable GetJobCandidateShortLis(int JobID, int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@JobID", JobID));
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CarrerJobCandidateShortList_GetByCandidateJob", altParams);
        }

        public int InsertJobCandidateShortLis(int JobID, int CandidateID, bool ShortListed, bool Rejected, string Comments)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@JobID", JobID));
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@ShortListed", ShortListed));
            altParams.Add(new SqlParameter("@Rejected", Rejected));
            altParams.Add(new SqlParameter("@Comments", Comments));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CarrerJobCandidateShortList_Insert", altParams);
        }


    } 
} 