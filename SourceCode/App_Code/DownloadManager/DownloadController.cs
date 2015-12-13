using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public class DownloadController
{
    public DownloadController()
    {
    }

    public static void Download(string strPath, string strFileName, System.Web.UI.Page pg)
    {
        try
        {
            FileStream fs;
            byte[] bytBytes;

            fs = File.Open(strPath + strFileName, FileMode.Open);
            bytBytes = new byte[fs.Length];
            fs.Read(bytBytes, 0, (int)fs.Length);
            fs.Close();

            pg.Response.AddHeader("Content-disposition", "attachment; filename=" + strFileName);
            pg.Response.ContentType = "application/octet-stream";
            pg.Response.BinaryWrite(bytBytes);
            pg.Response.End();
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}