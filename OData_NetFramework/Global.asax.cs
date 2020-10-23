using OData_NetFramework.App_Start;
using System.Web.Http;

namespace OData_NetFramework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config => {
                WebApiConfig.Register(config);
                ODataConfig.Register(config);
            });
        }
    }
}
