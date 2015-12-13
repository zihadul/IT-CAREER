using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for bllSlider
/// </summary>
public class bllSlider
{
	public bllSlider()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    dalSlider objSlider = new dalSlider();
    public DataTable GetList()
    {
        return objSlider.GetList();
    }

    public DataTable GetActive()
    {
        return objSlider.GetActive();
    }
    public DataTable GetByID(int NewsID)
    {
        return objSlider.GetByID(NewsID);
    }

    public int Insert(string ImageName, int Active, string Description)
    {
        return objSlider.Insert(ImageName, Active, Description);
    }


    public int Update(int ID, string ImageName, int Active, string Description)
    {
        return objSlider.Update(ID, ImageName, Active, Description);
    }

    public int Delete(int CourseID)
    {
        return objSlider.Delete(CourseID);
    }
}