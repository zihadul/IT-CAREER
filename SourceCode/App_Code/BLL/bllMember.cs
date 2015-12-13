using System;
using System.Data;
using DAL;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace BLL
{

    public class bllMember 
    {

        dalMember objMember= new dalMember(); // Object to access DAL.
        private static ICacheManager cacheMember= CacheFactory.GetCacheManager("CacheMember");

        public int MemberInsert(string CandidateName,int PrefixID, int ArmyNo, int RankID, int ArmsID, int FormationID, int UnitID, string Mobile, string Email, string UserName)
        {
            return objMember.MemberInsert(CandidateName,PrefixID, ArmyNo, RankID, ArmsID, FormationID, UnitID, Mobile, Email, UserName);
        }

        public DataTable GetList()
        {
            DataTable dt = (DataTable)cacheMember.GetData("GetMemberList");
            if (dt == null)
            {
                dt = objMember.GetList();
                cacheMember.Add("GetMemberList", dt, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            dt.DefaultView.RowFilter = "";
            return dt;

        }
        public DataTable GetAll(string roleName)
        {
            DataTable dt = objMember.GetAll(roleName);
            return dt;
        }

        public DataTable GetAllUser()
        {
            return objMember.GetAllUser();
        }

        public DataTable GetByID(int MemberID)
        {
            return objMember.GetByID(MemberID);
        }

        public DataTable GetByUserName(string UserName)
        {
            return objMember.GetByUserName(UserName);
        }
        public DataTable GetByEmail(string Email)
        {
            return objMember.GetByEmail(Email);
        }


        public int Insert(string UserName, string FirstName, string LastName, string Email, string Mobile)
        {
            cacheMember.Flush();
            return objMember.Insert(UserName.Trim(), FirstName.Trim(), LastName.Trim(), Email.Trim(), Mobile.Trim());
        }

        public int MemberUpdate(string UserName, string FirstName, string LastName, string Email, string Mobile)
        {
            cacheMember.Flush();
            return objMember.MemberUpdate(UserName.Trim(), FirstName.Trim(), LastName.Trim(), Email.Trim(), Mobile.Trim());
        }


        public int Update(int id, string title, string description, bool opened)
        {
            cacheMember.Flush();
            return objMember.CarrerUpdate(id, title, description, opened);
        }


        public int Delete(int MemberID)
        {
            cacheMember.Flush();
            return objMember.Delete(MemberID);
        }

    } // class
} // namespace