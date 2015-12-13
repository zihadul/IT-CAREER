using Microsoft.Practices.EnterpriseLibrary.Caching;


public class RefreshCache : ICacheItemRefreshAction
{
    public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
    {
        CacheFactory.GetCacheManager("CacheCareer").Flush();
        CacheFactory.GetCacheManager("CachePhotograph").Flush();
        CacheFactory.GetCacheManager("CacheProduct").Flush();
        CacheFactory.GetCacheManager("CacheSEO").Flush();
        CacheFactory.GetCacheManager("CacheContent").Flush();
        CacheFactory.GetCacheManager("CacheMember").Flush();
        CacheFactory.GetCacheManager("CacheCandidate").Flush();
        
        
    }
}