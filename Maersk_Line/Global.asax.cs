using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using StackExchange.Redis;

namespace Maersk_Line
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private static ConnectionMultiplexer redisCache;

        public static ConnectionMultiplexer RedisCache { get { if (redisCache == null || !redisCache.IsConnected)
                {
                    redisCache = ConnectionMultiplexer.Connect(ConfigurationManager.ConnectionStrings["RedisConnection"].ConnectionString);
                }
                return redisCache;
            }
        }
       
    }
}
