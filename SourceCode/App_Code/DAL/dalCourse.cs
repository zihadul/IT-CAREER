using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TVL.DataLogicLayer;
/// <summary>
/// Summary description for dalCourse
/// </summary>
/// 
namespace DAL
{
    public class dalCourse
    {
        public dalCourse()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public int Insert(string CourseName)
        {
            SqlParameter param;
            ArrayList altParams = new ArrayList();
            altParams.Add(new SqlParameter("@CourseName", CourseName));

            param = new SqlParameter("@CourseID", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            altParams.Add(param);

            DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Course_Insert", altParams);
            return Convert.ToInt32(param.Value);

        }

        public int Update(int CourseID, string CourseName)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CourseID", CourseID));
            altParams.Add(new SqlParameter("@CourseName", CourseName));

            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Course_Update", altParams);
        }


        public int Delete(int CourseID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CourseID", CourseID));
            return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Course_delete", altParams);

        }
        public DataTable GetAll()
        {
            ArrayList altParams = new ArrayList();
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Course_getAll", altParams);

        }


        public DataTable GetByID(int CourseID)
        {
            ArrayList altParams = new ArrayList();

            altParams.Add(new SqlParameter("@CourseID", CourseID));
            return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Course_GetByID", altParams);

        }
    }
}