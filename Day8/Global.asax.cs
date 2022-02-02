using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Uni.WebWebApi.App_Start;

namespace Uni.WebWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // AreaRegistration.RegisterAllAreas();

            Bootstrapper.Run();


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
