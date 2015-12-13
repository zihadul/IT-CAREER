using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using TVL.DataLogicLayer;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dalSlider
/// </summary>
public class dalSlider
{
	public dalSlider()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    public DataTable GetList()
    {
        ArrayList altParams = new ArrayList();
        return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Slider_GetAll", altParams);

    }

    public DataTable GetActive()
    {
        ArrayList altParams = new ArrayList();
        return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Slider_GetActive", altParams);

    }

    public DataTable GetByID(int ID)
    {
        ArrayList altParams = new ArrayList();

        altParams.Add(new SqlParameter("@ID", ID));
        return DatabaseManager.GetInstance().ExecuteStoredProcedureDataTable("usp_Slider_GetByID", altParams);

    }

    public int Insert(string ImageName, int Active, string Description)
    {
        ArrayList altParams = new ArrayList();

        altParams.Add(new SqlParameter("@ImageName", ImageName));
        altParams.Add(new SqlParameter("@Active", Active));
        altParams.Add(new SqlParameter("@Description", Description));
        return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Slider_Insert", altParams);

    }

    public int Update(int ID, string ImageName, int Active, string Description)
    {
        ArrayList altParams = new ArrayList();
        altParams.Add(new SqlParameter("@ID", ID));
        altParams.Add(new SqlParameter("@ImageName", ImageName));
        altParams.Add(new SqlParameter("@Active", Active));
        altParams.Add(new SqlParameter("@Description", Description));
        return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Slider_Update", altParams);

    }

    public int Delete(int ID)
    {
        ArrayList altParams = new ArrayList();

        altParams.Add(new SqlParameter("@ID", ID));
        return DatabaseManager.GetInstance().ExecuteNonQueryStoredProcedure("usp_Slider_Delete", altParams);

    }
}