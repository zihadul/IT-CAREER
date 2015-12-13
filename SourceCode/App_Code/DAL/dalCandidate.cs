using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
    /// <summary>
    /// Summary description for dalCandidate
    /// </summary>
    public class dalCandidate
    {
        
        #region Method(s)


        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateDetail_SelectAll", altParams);
        }

        public DataTable GetByID(int CandidateID)
        {
            ArrayList altParams = new ArrayList();


            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return
                DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable(
                    "USP_CareerCandidateDetail_SelectByCandidateID", altParams);

        }

        public DataTable GetByUserName(string UserName)
        {
            ArrayList altParams = new ArrayList();


            altParams.Add(new SqlParameter("@UserName", UserName));
            return
                DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable(
                    "USP_CareerCandidateDetail_SelectByUserName", altParams);

        }

        public int Insert(string CandidateName, string FatherName, string MotherName, int RankID, int ArmsID, int FormationID, int UnitID, int PrefixID, int ArmyNo, DateTime BirthDate, string Gender, string MaritalStatus, 
            string Religion, string PresentAddress, string PermanentAddress, string Mobile, string Email,
             string CareerSummary, 
            string SpecialQualification, string SearchKeyword, 
            string UserName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateName", CandidateName));
            altParams.Add(new SqlParameter("@FatherName", FatherName));
            altParams.Add(new SqlParameter("@MotherName", MotherName));
            altParams.Add(new SqlParameter("@RankID", RankID));
            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            altParams.Add(new SqlParameter("@FormationID", FormationID));
            altParams.Add(new SqlParameter("@UnitID", UnitID));
            altParams.Add(new SqlParameter("@PrefixID", PrefixID));
            altParams.Add(new SqlParameter("@ArmyNo", ArmyNo));
            altParams.Add(new SqlParameter("@BirthDate", BirthDate));
            altParams.Add(new SqlParameter("@Gender", Gender));
            altParams.Add(new SqlParameter("@MaritalStatus", MaritalStatus));
            altParams.Add(new SqlParameter("@Religion", Religion));
            altParams.Add(new SqlParameter("@PresentAddress", PresentAddress));
            altParams.Add(new SqlParameter("@PermanentAddress", PermanentAddress));
            altParams.Add(new SqlParameter("@Mobile", Mobile));
            altParams.Add(new SqlParameter("@Email", Email));
            altParams.Add(new SqlParameter("@CareerSummary", CareerSummary));
            altParams.Add(new SqlParameter("@SpecialQualification", SpecialQualification));
            altParams.Add(new SqlParameter("@SearchKeyword", SearchKeyword));
            altParams.Add(new SqlParameter("@UserName", UserName));

            DataTable dt= DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateDetail_Insert",
                                                                                altParams);


            return int.Parse(dt.Rows[0][0].ToString());

        }


        public int Update(int CandidateID, string CandidateName, string FatherName, string MotherName, int RankID, int ArmsID, int FormationID, int UnitID, int PrefixID, int ArmyNo, DateTime BirthDate, string Gender, 
            string MaritalStatus, string Religion, string PresentAddress, string PermanentAddress, string Mobile,
            string Email,  string CareerSummary, string SpecialQualification, string SearchKeyword)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@CandidateName", CandidateName));
            altParams.Add(new SqlParameter("@FatherName", FatherName));
            altParams.Add(new SqlParameter("@MotherName", MotherName));
            altParams.Add(new SqlParameter("@RankID", RankID));
            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            altParams.Add(new SqlParameter("@FormationID", FormationID));
            altParams.Add(new SqlParameter("@UnitID", UnitID));
            altParams.Add(new SqlParameter("@PrefixID", PrefixID));
            altParams.Add(new SqlParameter("@ArmyNo", ArmyNo));
            altParams.Add(new SqlParameter("@BirthDate", BirthDate));
            altParams.Add(new SqlParameter("@Gender", Gender));
            altParams.Add(new SqlParameter("@MaritalStatus", MaritalStatus));
            altParams.Add(new SqlParameter("@Religion", Religion));
            altParams.Add(new SqlParameter("@PresentAddress", PresentAddress));
            altParams.Add(new SqlParameter("@PermanentAddress", PermanentAddress));
            altParams.Add(new SqlParameter("@Mobile", Mobile));
            altParams.Add(new SqlParameter("@Email", Email));
            
            altParams.Add(new SqlParameter("@CareerSummary", CareerSummary));
            altParams.Add(new SqlParameter("@SpecialQualification", SpecialQualification));
            altParams.Add(new SqlParameter("@SearchKeyword", SearchKeyword));
           

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateDetail_Update",
                                                                                altParams);

        }
        public int UpdateProfile(int CandidateID, string CandidateName,int RankID, int ArmsID, int FormationID, int UnitID,int PrefixID,string ArmyNo,string Mobile,
            string Email)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@CandidateName", CandidateName));
            altParams.Add(new SqlParameter("@RankID", RankID));
            altParams.Add(new SqlParameter("@ArmsID", ArmsID));
            altParams.Add(new SqlParameter("@FormationID", FormationID));
            altParams.Add(new SqlParameter("@UnitID", UnitID));
            altParams.Add(new SqlParameter("@PrefixID", PrefixID));
            altParams.Add(new SqlParameter("@ArmyNo", ArmyNo));
            altParams.Add(new SqlParameter("@Mobile", Mobile));
            altParams.Add(new SqlParameter("@Email", Email));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerProfile_Update",
                                                                                altParams);
        }
             

        public int Delete(int ID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@ID", ID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateDetail_DeleteRow",
                                                                                altParams);

        }

        public int InsertEducationTraining(int CandidateID, string EducationTrainingXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@EducationTrainingXml", EducationTrainingXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateEducationTraining_Insert",
                                                                                altParams);

        }
        //new add 10-10-2014

        public int InsertTraining(int CandidateID, string TrainingXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@TrainingXml", TrainingXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateTraining_Insert",
                                                                                altParams);

        }
        public int InsertSkill(int CandidateID, string SkillXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@SkillXml", SkillXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateSkill_Insert",
                                                                                altParams);

        }

        public int InsertPortfolio(int CandidateID, string PortfolioXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@PortfolioXml", PortfolioXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidatePortfolio_Insert",
                                                                                altParams);
        }
        public int InsertPortfolioTemp(int CandidateID, string PortfolioXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@PortfolioXml", PortfolioXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidatePortfolioTemp_Insert",
                                                                                altParams);
        }
        public int DeletePortfolioTemp()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidatePortfilioTemp_Delete", altParams);
        }
        //

        #endregion



        public DataTable GetTrainingSummery(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateTrainingSummary_SelectAll", altParams);
        }

       
        public DataTable GetProfessionalQualification(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateProfessionalQualification_SelectAll", altParams);
        }
        public DataTable GetByCandidateUserName(string CandidateUserName)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateUserName", CandidateUserName));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateJob_GetByCandidateUserName", altParams);
        }

        public DataTable GetAcademicQualification(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateAcademicQualification_SelectAll", altParams);
        }

        public DataTable GetPortfolio(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateGetPortfolio_SelectAll", altParams);
        }
        public DataTable GetPortfolioTemp(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateGetPortfolioTemp_SelectAll", altParams);
        }



        public DataTable GetEmploymentHistory(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateEmploymentHistory_SelectAll", altParams);
        }


        public int InsertEmploymentHistory(int CandidateID, string EmploymentHistoryXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@EmploymentHistoryXml", EmploymentHistoryXml));

            return
                DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure(
                    "USP_CareerCandidateEmploymentHistory_Insert", altParams);


        }


        public DataTable GetReference(int CandidateID)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerCandidateReference_SelectAll", altParams);
        }


        public int InsertReference(int CandidateID, string ReferenceXml)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CandidateID", CandidateID));
            altParams.Add(new SqlParameter("@ReferenceXml", ReferenceXml));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("USP_CareerCandidateReference_Insert",
                                                                                altParams);
        }

        public DataTable GetAllResume(string Criteria, int StartRowIndex, int MaximumRows, bool PrintMood)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@Criteria", Criteria));
            altParams.Add(new SqlParameter("@StartRowIndex", StartRowIndex));
            altParams.Add(new SqlParameter("@MaximumRows", MaximumRows));
            altParams.Add(new SqlParameter("@PrintMood", PrintMood));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerResume_SelectAll", altParams);

        }

        public DataTable ResumeWithInterest(string Criteria, int StartRowIndex, int MaximumRows, bool PrintMood)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@Criteria", Criteria));
            altParams.Add(new SqlParameter("@StartRowIndex", StartRowIndex));
            altParams.Add(new SqlParameter("@MaximumRows", MaximumRows));
            altParams.Add(new SqlParameter("@PrintMood", PrintMood));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_CareerResume_ResumeWithInterest", altParams);

        }


    }
}

