using System;
using System.Data;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{

    public class bllCandidate
    {

        dalCandidate objCandidate = new dalCandidate(); // Object to access DAL.
        private static ICacheManager cacheCandidate = CacheFactory.GetCacheManager("CacheCandidate");

        #region Method(s)


        public DataTable GetList()
        {
            DataTable dt = (DataTable)cacheCandidate.GetData("cacheCandidateGetList");
            if (dt == null)
            {
                dt = objCandidate.GetList();
                cacheCandidate.Add("cacheCandidateGetList", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            dt.DefaultView.RowFilter = "";
            return dt;
        }

        public DataTable GetByID(int ID)
        {
            return objCandidate.GetByID(ID);
        }

        public DataTable GetByUserName(string UserName)
        {
            DataTable dt = (DataTable)cacheCandidate.GetData("GetByUserName" + UserName);
            if (dt == null)
            {
                dt = objCandidate.GetByUserName(UserName);
                cacheCandidate.Add("GetByUserName" + UserName, dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            dt.DefaultView.RowFilter = "";
            return dt;
        }


        public int Insert(string CandidateName, string FatherName, string MotherName, int RankID, int ArmsID, int FormationID, int UnitID,int PrefixID,int ArmyNo, DateTime BirthDate, string Gender, string MaritalStatus,
            string Religion, string PresentAddress, string PermanentAddress, string Mobile,
            string Email, 
            string CareerSummary, string SpecialQualification, string SearchKeyword,  string UserName)
        {

            cacheCandidate.Flush();
            return objCandidate.Insert(CandidateName, FatherName, MotherName, RankID, ArmsID, FormationID, UnitID, PrefixID, ArmyNo, BirthDate, Gender, MaritalStatus,
                                       Religion, PresentAddress, PermanentAddress, Mobile, Email, CareerSummary, SpecialQualification,
                                       SearchKeyword,UserName);


        }


        public int Update(int CandidateID, string CandidateName, string FatherName, string MotherName, int RankID, int ArmsID, int FormationID, int UnitID,int PrefixID,int ArmyNo, DateTime BirthDate, string Gender, string MaritalStatus, 
            string Religion, string PresentAddress, string PermanentAddress, string Mobile, string Email,
           string CareerSummary, 
            string SpecialQualification, string SearchKeyword)
        {

            cacheCandidate.Flush();
            return objCandidate.Update(CandidateID, CandidateName, FatherName, MotherName, RankID, ArmsID, FormationID, UnitID, PrefixID, ArmyNo, BirthDate, Gender, MaritalStatus, Religion,
                                       PresentAddress, PermanentAddress, Mobile, Email, CareerSummary, SpecialQualification,
                                       SearchKeyword);
        }

        public int UpdateProfile(int CandidateID, string CandidateName, int RankID, int ArmsID, int FormationID, int UnitID,int PrefixID, string ArmyNo, string Mobile,
            string Email)
        {
            return objCandidate.UpdateProfile(CandidateID, CandidateName, RankID, ArmsID, FormationID, UnitID,PrefixID, ArmyNo, Mobile, Email);
        }


        public int Delete(int id)
        {
            cacheCandidate.Flush();
            return objCandidate.Delete(id);
        }

        #endregion



        public int InsertEducationTraining(int CandidateID, DataTable AcademicQualification)
        {

            string EducationTrainingXml = "";

            DataSet ds = new DataSet("EducationTraining");

            ds.Tables.Add(AcademicQualification);
            EducationTrainingXml = ds.GetXml();
            EducationTrainingXml = EducationTrainingXml.Replace("T00:00:00+06:00", "");


            return objCandidate.InsertEducationTraining(CandidateID, EducationTrainingXml);

        }
        //new add deba
        public int InsertTraining(int CandidateID, DataTable dtTraining)
        {

            string TrainingXml = "";

            DataSet ds = new DataSet("Training");

            ds.Tables.Add(dtTraining);
            TrainingXml = ds.GetXml();
            TrainingXml = TrainingXml.Replace("T00:00:00+06:00", "");


            return objCandidate.InsertTraining(CandidateID, TrainingXml);

        }

        public int InsertSkill(int CandidateID, DataTable dtSkill)
        {

            string SkillXml = "";

            DataSet ds = new DataSet("Skill");

            ds.Tables.Add(dtSkill);
            SkillXml = ds.GetXml();
            SkillXml = SkillXml.Replace("T00:00:00+06:00", "");


            return objCandidate.InsertSkill(CandidateID, SkillXml);

        }

        public int InsertPortfolio(int CandidateID, DataTable dtPortfolio)
        {
            string PortfolioXml = "";
            DataSet ds = new DataSet("Portfolio");
            ds.Tables.Add(dtPortfolio);
            PortfolioXml = ds.GetXml();
            PortfolioXml = PortfolioXml.Replace("T00:00:00+06:00", "");
            return objCandidate.InsertPortfolio(CandidateID, PortfolioXml);
        }
        public int InsertPortfolioTemp(int CandidateID, DataTable dtPortfolioTemp)
        {
            string PortfolioXml = "";
            DataSet ds = new DataSet("PortfolioTemp");
            ds.Tables.Add(dtPortfolioTemp);
            PortfolioXml = ds.GetXml();
            PortfolioXml = PortfolioXml.Replace("T00:00:00+06:00", "");
            return objCandidate.InsertPortfolioTemp(CandidateID, PortfolioXml);
        }
        public int DeletePortfolioTemp()
        {
            return objCandidate.DeletePortfolioTemp();
        }
             

        //new add
        public DataTable GetTrainingSummery(int CandidateID)
        {
            return objCandidate.GetTrainingSummery(CandidateID);
        }

        public DataTable GetAcademicQualification(int CandidateID)
        {
            return objCandidate.GetAcademicQualification(CandidateID);
        }

        public DataTable GetPortfolio(int CandidateID)
        {
            return objCandidate.GetPortfolio(CandidateID);
        }
        public DataTable GetPortfolioTemp(int CandidateID)
        {
            return objCandidate.GetPortfolioTemp(CandidateID);
        }

       
        public DataTable GetProfessionalQualification(int CandidateID)
        {
            return objCandidate.GetProfessionalQualification(CandidateID);
        }

        public DataTable GetByCandidateUserName(string CandidateUserName)
        {
            return objCandidate.GetByCandidateUserName(CandidateUserName);
        }

         public DataTable GetEmploymentHistory(int CandidateID)
        {
            return objCandidate.GetEmploymentHistory(CandidateID);
        }

         public int InsertEmploymentHistory(int CandidateID, DataTable dtEmploymentHistory)
         {
             string EmploymentHistoryXml = "";

             DataSet ds = new DataSet("Employment");
             ds.Tables.Add(dtEmploymentHistory);

             EmploymentHistoryXml = ds.GetXml();
             EmploymentHistoryXml = EmploymentHistoryXml.Replace("T00:00:00+06:00", "");

             return objCandidate.InsertEmploymentHistory(CandidateID, EmploymentHistoryXml);
         }


         public DataTable GetReference(int CandidateID)
         {
             return objCandidate.GetReference(CandidateID);
         }

         public int InsertReference(int CandidateID, DataTable dtReferenceXml)
         {

             DataSet ds = new DataSet("Reference");
             ds.Tables.Add(dtReferenceXml);

             string ReferenceXml = "";
             ReferenceXml = ds.GetXml();
             ReferenceXml = ReferenceXml.Replace("T00:00:00+06:00", "");

             return objCandidate.InsertReference(CandidateID, ReferenceXml);

         }

         public DataTable GetAllResume(string Criteria, int StartRowIndex, int MaximumRows, bool PrintMood)
         {
             return objCandidate.GetAllResume(Criteria, StartRowIndex, MaximumRows, PrintMood);

         }

         public DataTable ResumeWithInterest(string Criteria, int StartRowIndex, int MaximumRows, bool PrintMood)
         {
             return objCandidate.ResumeWithInterest(Criteria, StartRowIndex, MaximumRows, PrintMood);

         }


    } // class


} // namespace