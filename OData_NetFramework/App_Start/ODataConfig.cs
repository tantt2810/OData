using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using OData_NetFramework.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OData_NetFramework.App_Start
{
    public static class ODataConfig
    {
        public static void Register(HttpConfiguration config) 
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            var function = builder.Function("GetProd");
            function.Parameter<int>("Id");
            function.Parameter<string>("Name");
            function.Returns<Dictionary<string, string>>();
            var model = builder.GetEdmModel();

            var batchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);

            config.MapODataServiceRoute(
                routeName: "HMODataRoute",
                routePrefix: "odata/product",
                model: model,
                batchHandler: batchHandler);
        }
    }
}