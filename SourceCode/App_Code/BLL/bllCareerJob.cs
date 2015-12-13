using System;
using System.Data;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{

    public class bllCareerJob 
    {

        dalCareerJob objCareer = new dalCareerJob(); // Object to access DAL.
        private static ICacheManager cacheCareer = CacheFactory.GetCacheManager("CacheCareer");



        public DataTable GetList(int StartRowIndex, int MaxRows, string Criteria, bool PrintMode)
        {
            string cachName = "GetList" + StartRowIndex.ToString() + "-" + MaxRows.ToString() + Criteria +
                              PrintMode.ToString();

            DataTable dt = (DataTable)cacheCareer.GetData(cachName);
            if (dt == null)
            {
                dt = objCareer.GetList(StartRowIndex, MaxRows, Criteria, PrintMode);
                cacheCareer.Add(cachName, dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            dt.DefaultView.RowFilter = "";
            return dt;

        }

        public DataTable GetActive(int StartRowIndex, int MaxRows, string Criteria, bool PrintMode)
        {
            string cachName = "GetActive" + StartRowIndex.ToString() + "-" + MaxRows.ToString() + Criteria +
                              PrintMode.ToString();


            DataTable dt = (DataTable)cacheCareer.GetData(cachName);
            if (dt == null)
            {
                dt = objCareer.GetActive(StartRowIndex, MaxRows, Criteria, PrintMode);
                cacheCareer.Add(cachName, dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            dt.DefaultView.RowFilter = "";
            return dt;

        }


        public DataTable GetByID(int id)
        {
            return objCareer.GetByID(id);
        }


        public int Insert(string JobTitle, int NoOfVacancies, string JobType, string JobLevel,
            string EducationalQualification, string Responsibility, string AdditionalRequirements,
            string Experience, bool SalaryNagotiable, bool SalaryMention, bool SalaryDisplayRange,
            int SalaryMinimum, int SalaryMaximum, string OtherBenifits,
            Nullable<DateTime> ApplicationDeadline, int AgeFrom, int AgeTo, string Gender,
            bool IsActive)
        {

            cacheCareer.Flush();
            return objCareer.Insert(JobTitle, NoOfVacancies, JobType, JobLevel,
                                    EducationalQualification, Responsibility, AdditionalRequirements,
                                    Experience, SalaryNagotiable, SalaryMention, SalaryDisplayRange,
                                    SalaryMinimum, SalaryMaximum, OtherBenifits,
                                    ApplicationDeadline, AgeFrom, AgeTo, Gender,
                                    IsActive);


        }


        public int Update(int ID, string JobTitle, int NoOfVacancies, string JobType, string JobLevel,
           string EducationalQualification, string Responsibility, string AdditionalRequirements,
           string Experience, bool SalaryNagotiable, bool SalaryMention, bool SalaryDisplayRange,
           int SalaryMinimum, int SalaryMaximum, string OtherBenifits,
           Nullable<DateTime> ApplicationDeadline, int AgeFrom, int AgeTo, string Gender,
           bool IsActive)
        {

            cacheCareer.Flush();
            return objCareer.Update(ID, JobTitle, NoOfVacancies, JobType, JobLevel,
                                    EducationalQualification, Responsibility, AdditionalRequirements,
                                    Experience, SalaryNagotiable, SalaryMention, SalaryDisplayRange,
                                    SalaryMinimum, SalaryMaximum, OtherBenifits,
                                    ApplicationDeadline, AgeFrom, AgeTo, Gender,
                                    IsActive);
        }


        public int Delete(int id)
        {

            cacheCareer.Flush();
            return objCareer.Delete(id);
        }


    } // class
} // namespace