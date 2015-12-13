using System.Web;
using System.Web.UI.WebControls;


public class NavigationController
{
    public static SiteMapDataSource  GetSiteMapDataSource(string strRole)
    {
        System.Collections.Specialized.NameValueCollection myCollection = new System.Collections.Specialized.NameValueCollection(1);
        myCollection.Add("siteMapFile", "~/Web.sitemap");

        XmlSiteMapProvider xmlSiteMap = new XmlSiteMapProvider();
        xmlSiteMap.Initialize("provider", myCollection);
        xmlSiteMap.BuildSiteMap();

        SiteMapDataSource siteMap = new SiteMapDataSource();
        siteMap.StartingNodeUrl = "~/" + strRole + "Dummy.aspx";
        siteMap.ShowStartingNode = false;                

        return siteMap;
    }

    public static SiteMapDataSource GetSiteMapDataSource()
    {
        System.Collections.Specialized.NameValueCollection myCollection = new System.Collections.Specialized.NameValueCollection(1);
        myCollection.Add("siteMapFile", "~/Web.sitemap");

        XmlSiteMapProvider xmlSiteMap = new XmlSiteMapProvider();
        xmlSiteMap.Initialize("provider", myCollection);
        xmlSiteMap.BuildSiteMap();

        SiteMapDataSource siteMap = new SiteMapDataSource();
        siteMap.StartingNodeUrl = "~/" + "Default.aspx";
        siteMap.ShowStartingNode = false;

        return siteMap;
    }

} // Class