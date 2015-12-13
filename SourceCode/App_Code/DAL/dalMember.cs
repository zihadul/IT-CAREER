using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using TVL.DataLogicLayer;

namespace DAL
{
   
    public class dalMember
    {

        public int MemberInsert(string CandidateName,int PrefixID,int ArmyNo, int RankID, int ArmsID, int FormationID, int UnitID,string Mobile, string Email,string UserName)
        {
            try
            {
                ArrayList altParams = new ArrayList();
                altParams.Add(new SqlParameter("@CandidateName", CandidateName));
                altParams.Add(new SqlParameter("@PrefixID", PrefixID));
                altParams.Add(new SqlParameter("@ArmyNo", ArmyNo));
                altParams.Add(new SqlParameter("@RankID", RankID));
                altParams.Add(new SqlParameter("@ArmsID", ArmsID));
                altParams.Add(new SqlParameter("@FormationID", FormationID));
                altParams.Add(new SqlParameter("@UnitID", UnitID));
                altParams.Add(new SqlParameter("@Mobile", Mobile));
                altParams.Add(new SqlParameter("@Email", Email));
                altParams.Add(new SqlParameter("@UserName", UserName));
                return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_member_Insert", altParams);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public DataTable GetAll(string roleName)
        {
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@roleName", roleName));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Member_GetAll", altParams);
        }
       
        public DataTable GetList()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_members_get", altParams);
                     
        }
        public DataTable GetAllUser()
        {
            ArrayList altParams = new ArrayList();

            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("USP_User_GetAll", altParams);

        }

        public DataTable GetByUserName(string UserName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UserName", UserName));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_members_GetByUserName", altParams);
        }
        public DataTable GetByID(int MemberID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@MemberID", MemberID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_members_getbyid", altParams);

        }

        public DataTable GetByEmail(string Email)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@Email", Email));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_members_getbyemail", altParams);

        }


        public int Insert(string UserName, string FirstName, string LastName, string Email, string Mobile)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UserName", UserName));
            altParams.Add(new SqlParameter("@FirstName", FirstName));
            altParams.Add(new SqlParameter("@LastName", LastName));
            altParams.Add(new SqlParameter("@Email", Email));
            altParams.Add(new SqlParameter("@Mobile", Mobile));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_members_insert", altParams);

        }
        public int MemberUpdate(string UserName, string FirstName, string LastName, string Email, string Mobile)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@UserName", UserName));
            altParams.Add(new SqlParameter("@FirstName", FirstName));
            altParams.Add(new SqlParameter("@LastName", LastName));
            altParams.Add(new SqlParameter("@Email", Email));
            altParams.Add(new SqlParameter("@Mobile", Mobile));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_members_Update", altParams);

        }

        // carrer update
        public int CarrerUpdate(int id, string title, string description, bool opened)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@id", id));
            altParams.Add(new SqlParameter("@title", title));
            altParams.Add(new SqlParameter("@description", description));
            altParams.Add(new SqlParameter("@opened", opened));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_career_update", altParams);
        }


        public int Delete(int MemberID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@MemberID", MemberID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_members_delete", altParams);

        }


    } //class
} //namespace