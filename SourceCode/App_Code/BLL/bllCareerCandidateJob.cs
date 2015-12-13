using System.Data;
using DAL;

namespace BLL
{

    public class bllCareerCandidateJob 
    {

        dalCareerCandidateJob objCandidateJo = new dalCareerCandidateJob(); // Object to access DAL.

        public DataTable GetCareerCandidateJob(int StartRowIndex, int MaxRows, string Criteria, int JobID,
           string Qualification, string Training, bool ShortListed, bool Rejected, bool PrintMode)
        {
            return objCandidateJo.GetCareerCandidateJob(StartRowIndex, MaxRows, Criteria, JobID,
                Qualification, Training, ShortListed, Rejected , PrintMode);

        }

        public DataTable GetCareerCandidateJob(int JobID, int CandidateID)
        {
            return objCandidateJo.GetCareerCandidateJob(JobID, CandidateID);
        }

        public int InsertCandidateJob(int JobID, int CandidateID)
        {
            return objCandidateJo.InsertCandidateJob(JobID, CandidateID);
        }

        public DataTable GetJobCandidateShortLis(int JobID, int CandidateID)
        {
            return objCandidateJo.GetJobCandidateShortLis(JobID, CandidateID);
        }

        public int InsertJobCandidateShortLis(int JobID, int CandidateID, bool ShortListed, bool Rejected, string Comments)
        {
            return objCandidateJo.InsertJobCandidateShortLis(JobID, CandidateID, ShortListed, Rejected, Comments);
        }


    } // class
} // namespace