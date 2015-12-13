using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

/// <summary>
/// Summary description for bllInterest
/// </summary>
public class bllInterest
{
    dalInterest objInterest = new dalInterest();
	public bllInterest()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int Insert(string Category,string InterestName)
    {
        return objInterest.Insert(Category, InterestName);
    }


    public int Update(int InterestID,string Category, string InterestName)
    {
        return objInterest.Update(InterestID,Category, InterestName);
    }

    public int Delete(int InterestID)
    {
        return objInterest.Delete(InterestID);
    }
    public DataTable GetAll()
    {
        return objInterest.GetAll();

    }

    public DataTable GetByID(int InterestID)
    {
        return objInterest.GetByID(InterestID);
    }
    public DataTable GetByCategory(string Category)
    {
        return objInterest.GetByCategory(Category);
    }

    public DataTable InterestByCandidateID(int CandidateID)
    {
        return objInterest.InterestByCandidateID(CandidateID);
    }
    public DataTable DeleteByCandidateID(int CandidateID)
    {
        return objInterest.DeleteByCandidateID(CandidateID);
    }

    public int InsertCandidateInterest(DataTable dt)
    {
        DataSet ds = new DataSet("Interest");
        ds.Tables.Add(dt);
        return objInterest.InsertCandidateInterest(ds.GetXml());
    }

    public int UpdateCandidateInterest(DataTable dt)
    {
        DataSet ds = new DataSet("Interest");
        ds.Tables.Add(dt);
        return objInterest.UpdateCandidateInterest(ds.GetXml());
    }
}