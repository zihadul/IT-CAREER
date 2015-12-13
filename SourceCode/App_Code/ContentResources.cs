using System;
using System.Data;
using TVL.DataLogicLayer;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;


public static class ContentResources
{

    private static ICacheManager cache = CacheFactory.GetCacheManager("CacheContent");
    
    public static void CreateConnection()
    {    
    }

    public static DataTable GetPageControls(string page)
    {
        DataTable dt = new DataTable();
        try
        {
            string sql = "SELECT resourcedescription, resourcevalue FROM Localization Where pagename='" + page + "'";
            //ds = dataAccess.ExecuteDataSet(sql);
            dt = DatabaseManager.GetInstance().GetDataTable(sql);
            
        }
        catch
        {
        }
        return (dt);
    }

    public static DataSet GetPages(string page)
    {
        DataSet ds = new DataSet();
        try
        {
            string sql = "SELECT Distinct pagename, virtualpath FROM Localization";
            ds = DatabaseManager.GetInstance().GetDataset(sql);//dataAccess.ExecuteDataSet(sql);
        }
        catch
        {
        }
        return (ds);
    }
   

    public static DataSet GetLanguages(string page)
    {
        DataSet ds = new DataSet();
        string sql = "SELECT Distinct culturename FROM Localization";
        try
        {
            //ds = dataAccess.ExecuteDataSet(sql);
            ds = DatabaseManager.GetInstance().GetDataset(sql);
        }
        catch
        {
        }
        return (ds);
    }

    public static DataSet GetResourceByCulture(string page, string culture)
    {

        DataSet ds = new DataSet();
        ds = (DataSet)cache.GetData("GetResourceByCulture" + page + culture);
        if (ds == null)
        {
            string sql = "SELECT resourcename, resourcevalue FROM Localization Where (virtualpath='" + page + "' ) and culturename='" + culture + "' and resourcename like '%.Text'";
            try
            {
                ds = DatabaseManager.GetInstance().GetDataset(sql);
                cache.Add("GetResourceByCulture" + page + culture, ds, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            catch
            {
            }
        }
        return (ds);

    }

    public static DataSet GetLeftNavResourceByCulture(string culture)
    {
        DataSet ds = new DataSet();
        string sql = "SELECT distinct resourcename, resourcevalue FROM Localization Where (virtualpath='LeftNav.ascx') and culturename='" + culture + "' and resourcename like '%.Text'";
        try
        {
            //ds = dataAccess.ExecuteDataSet(sql);
            ds = DatabaseManager.GetInstance().GetDataset(sql);
        }
        catch
        {
        }
        return (ds);
    }

    public static string GetResourceByCultureKey(string page, string key)
    {
        string s = "";


        s = (string)cache.GetData("GetResourceByCultureKey" + page + key);
        if (s == "" || s == null)
        {
            string sql = "SELECT resourcevalue FROM Localization Where virtualpath='" + page + "' and resourcedescription='" + key + "'";
            try
            {
                s = DatabaseManager.GetInstance().ExecuteScalar(sql) as string;
                cache.Add("GetResourceByCultureKey" + page + key, s, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            catch
            {
            }
        }

        return (s);
    }

    public static string GetResourceByPageName(string page, string key)
    {
        string s = "";


        s = (string)cache.GetData("GetResourceByCultureKey" + page + key);
        if (s == "" || s == null)
        {
            string sql = "SELECT resourcevalue FROM Localization Where virtualpath='" + page + "' and resourcedescription='" + key + "'";
            try
            {
                s = DatabaseManager.GetInstance().ExecuteScalar(sql) as string;
                cache.Add("GetResourceByCultureKey" + page + key, s, CacheItemPriority.Normal, new RefreshCache(), new SlidingTime(TimeSpan.FromSeconds(60)));
            }
            catch
            {
            }
        }

        return (s);
    }

    public static bool UpdateResource(string page, string key, string keyValue)
    {
        bool bol = false;
        int value;
        keyValue = keyValue.Replace("'", "''");
        string sql = "UPDATE Localization SET resourcevalue = '" + keyValue + "' Where pagename='" + page + "' and resourcedescription='" + key + "'";
        try
        {
            value = int.Parse(DatabaseManager.GetInstance().ExecuteSQLQueryAction(sql,null).ToString());//dataAccess.ExecuteQuery(sql);
            if (value > 0) bol = true;
        }
        catch
        {
        }
        cache.Flush();
        return (bol);
    }
}
