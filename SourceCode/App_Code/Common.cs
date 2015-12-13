using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Security;
using System.Drawing;


/// <summary>
/// Holds common functions for the site
/// </summary>
public class Common
{
	
    public static string GetUserKey(string UserName)
    {
        try
        {
            if (UserName != "")
                return Membership.GetUser(UserName).ProviderUserKey.ToString();
            else
                return "";
        }
        catch (Exception)
        {
            return "";
        }
    }

    public static System.Drawing.Image GetThumsImage(string path, int width, int height)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(path);

        if (image.Width > width && image.Height > height)
            image = image.GetThumbnailImage(width, height, null, new IntPtr());
        else if (image.Width > width && image.Height < height)
            image = image.GetThumbnailImage(width, image.Height, null, new IntPtr());
        else if (image.Width < width && image.Height > height)
            image = image.GetThumbnailImage(image.Width, height, null, new IntPtr());
        else
            image = image.GetThumbnailImage(image.Width, image.Height, null, new IntPtr());

        return image;
    }

    public static void DeleteFile(string path)
    {
        try
        {
            System.IO.File.Delete(path);
        }
        catch (Exception)
        {
        }
    }

    public static List<string> GetColors()
    {
        //create a generic list of strings
        List<string> colors = new List<string>();
        //get the color names from the Known color enum
        string[] colorNames = Enum.GetNames(typeof(KnownColor));

        //iterate thru each string in the colorNames array
        foreach (string colorName in colorNames)
        {
            //cast the colorName into a KnownColor
            KnownColor knownColor = (KnownColor)Enum.Parse(typeof(KnownColor), colorName);
            //check if the knownColor variable is a System color
            if (knownColor > KnownColor.Transparent)
            {
                //add it to our list
                colors.Add(colorName);
            }
        }

        //return the color list
        return colors;
    }

    public static bool IsDate(string sdate)
    {
        DateTime dt;
        bool isDate = true;
        try
        {
            dt = DateTime.Parse(sdate);
        }
        catch
        {
            isDate = false;
        }
        return isDate;
    }

    public static string HtmlStrip(string input)
    {
        input = Regex.Replace(input, "<style>(.|\n)*?</style>", string.Empty);
        input = Regex.Replace(input, @"<xml>(.|\n)*?</xml>", string.Empty); // remove all <xml></xml> tags and anything inbetween.  
        return Regex.Replace(input, @"<(.|\n)*?>", string.Empty); // remove any tags but not there content
    }

    public static string LocalizeDigit(string strString)
    {
        if (Thread.CurrentThread.CurrentCulture.Name == "bn-BD")
        {
            string[] nativeDigits = Thread.CurrentThread.CurrentCulture.NumberFormat.NativeDigits;
            return strString.Replace('0', nativeDigits[0].ToCharArray()[0])
                    .Replace('1', nativeDigits[1].ToCharArray()[0])
                    .Replace('2', nativeDigits[2].ToCharArray()[0])
                    .Replace('3', nativeDigits[3].ToCharArray()[0])
                    .Replace('4', nativeDigits[4].ToCharArray()[0])
                    .Replace('5', nativeDigits[5].ToCharArray()[0])
                    .Replace('6', nativeDigits[6].ToCharArray()[0])
                    .Replace('7', nativeDigits[7].ToCharArray()[0])
                    .Replace('8', nativeDigits[8].ToCharArray()[0])
                    .Replace('9', nativeDigits[9].ToCharArray()[0]);

        }
        else
        {
            return strString;
        }
    }

}
