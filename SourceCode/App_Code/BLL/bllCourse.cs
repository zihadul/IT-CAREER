using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllCourse
/// </summary>
/// 
namespace BLL
{
    public class bllCourse
    {
        dalCourse objCourse = new dalCourse();
        public bllCourse()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Insert(string CourseName)
        {
            return objCourse.Insert(CourseName);
        }


        public int Update(int CourseID, string CourseName)
        {
            return objCourse.Update(CourseID, CourseName);
        }

        public int Delete(int CourseID)
        {
            return objCourse.Delete(CourseID);
        }
        public DataTable GetAll()
        {
            return objCourse.GetAll();

        }

        public DataTable GetByID(int CourseID)
        {
            return objCourse.GetByID(CourseID);
        }
    }
}