using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    public class dalCareerJob
    {


        public DataTable GetList(int StartRowIndex, int MaxRows, string Criteria, bool PrintMode)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StartRowIndex", StartRowIndex));
            altParams.Add(new SqlParameter("@MaxRows", MaxRows));
            altParams.Add(new SqlParameter("@Criteria", Criteria));
            altParams.Add(new SqlParameter("@PrintMode", PrintMode));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerJobs_GetAll", altParams);
        }



        public DataTable GetActive(int StartRowIndex, int MaxRows, string Criteria, bool PrintMode)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@StartRowIndex", StartRowIndex));
            altParams.Add(new SqlParameter("@MaxRows", MaxRows));
            altParams.Add(new SqlParameter("@Criteria", Criteria));
            altParams.Add(new SqlParameter("@PrintMode", PrintMode));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerJobs_GetActive", altParams);
        }


        public DataTable GetByID(int ID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ID", ID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerJobs_GetByID", altParams);
        }


        public int Insert(string JobTitle, int NoOfVacancies, string JobType, string JobLevel,
            string EducationalQualification, string Responsibility, string AdditionalRequirements,
            string Experience, bool SalaryNagotiable, bool SalaryMention, bool SalaryDisplayRange,
            int SalaryMinimum, int SalaryMaximum, string OtherBenifits,
            Nullable<DateTime> ApplicationDeadline, int AgeFrom, int AgeTo, string Gender,
            bool IsActive)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@JobTitle", JobTitle));
            altParams.Add(new SqlParameter("@NoOfVacancies", NoOfVacancies));
            altParams.Add(new SqlParameter("@JobType", JobType));
            altParams.Add(new SqlParameter("@JobLevel", JobLevel));
            altParams.Add(new SqlParameter("@EducationalQualification", EducationalQualification));
            altParams.Add(new SqlParameter("@Responsibility", Responsibility));
            altParams.Add(new SqlParameter("@AdditionalRequirements", AdditionalRequirements));
            altParams.Add(new SqlParameter("@Experience", Experience));
            altParams.Add(new SqlParameter("@SalaryNagotiable", SalaryNagotiable));
            altParams.Add(new SqlParameter("@SalaryMention", SalaryMention));
            altParams.Add(new SqlParameter("@SalaryDisplayRange", SalaryDisplayRange));
            altParams.Add(new SqlParameter("@SalaryMinimum", SalaryMinimum));
            altParams.Add(new SqlParameter("@SalaryMaximum", SalaryMaximum));
            altParams.Add(new SqlParameter("@OtherBenifits", OtherBenifits));
            altParams.Add(new SqlParameter("@ApplicationDeadline", ApplicationDeadline));
            altParams.Add(new SqlParameter("@AgeFrom", AgeFrom));
            altParams.Add(new SqlParameter("@AgeTo", AgeTo));
            altParams.Add(new SqlParameter("@Gender", Gender));
            altParams.Add(new SqlParameter("@IsActive", IsActive));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerJobs_Insert", altParams);
        }


        public int Update(int ID, string JobTitle, int NoOfVacancies, string JobType, string JobLevel,
            string EducationalQualification, string Responsibility, string AdditionalRequirements,
            string Experience, bool SalaryNagotiable, bool SalaryMention, bool SalaryDisplayRange,
            int SalaryMinimum, int SalaryMaximum, string OtherBenifits,
            Nullable<DateTime> ApplicationDeadline, int AgeFrom, int AgeTo, string Gender,
            bool IsActive)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ID", ID));
            altParams.Add(new SqlParameter("@JobTitle", JobTitle));
            altParams.Add(new SqlParameter("@NoOfVacancies", NoOfVacancies));
            altParams.Add(new SqlParameter("@JobType", JobType));
            altParams.Add(new SqlParameter("@JobLevel", JobLevel));
            altParams.Add(new SqlParameter("@EducationalQualification", EducationalQualification));
            altParams.Add(new SqlParameter("@Responsibility", Responsibility));
            altParams.Add(new SqlParameter("@AdditionalRequirements", AdditionalRequirements));
            altParams.Add(new SqlParameter("@Experience", Experience));
            altParams.Add(new SqlParameter("@SalaryNagotiable", SalaryNagotiable));
            altParams.Add(new SqlParameter("@SalaryMention", SalaryMention));
            altParams.Add(new SqlParameter("@SalaryDisplayRange", SalaryDisplayRange));
            altParams.Add(new SqlParameter("@SalaryMinimum", SalaryMinimum));
            altParams.Add(new SqlParameter("@SalaryMaximum", SalaryMaximum));
            altParams.Add(new SqlParameter("@OtherBenifits", OtherBenifits));
            altParams.Add(new SqlParameter("@ApplicationDeadline", ApplicationDeadline));
            altParams.Add(new SqlParameter("@AgeFrom", AgeFrom));
            altParams.Add(new SqlParameter("@AgeTo", AgeTo));
            altParams.Add(new SqlParameter("@Gender", Gender));
            altParams.Add(new SqlParameter("@IsActive", IsActive));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerJobs_Update", altParams);
        }


        public int Delete(int ID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ID", ID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerJobs_Delete", altParams);
        }

    } 
} 