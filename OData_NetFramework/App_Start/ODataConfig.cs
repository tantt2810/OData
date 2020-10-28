using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using OData_NetFramework.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OData_NetFramework.App_Start
{
    public static class ODataConfig
    {
        public const string ODataRoutePrefix = "odata";

        public static void Register(HttpConfiguration config) 
        {
            var batchHandler = new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer);

            config.MapODataServiceRoute("OrderODataRoute", ODataRoutePrefix + "/order", GetOrderEdmModal(), batchHandler);
            config.MapODataServiceRoute("ProductODataRoute", ODataRoutePrefix + "/product", GetProductEdmModal(), batchHandler);
        }

        private static IEdmModel GetOrderEdmModal() 
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Order>("Orders");
            return builder.GetEdmModel();
        }

        private static IEdmModel GetProductEdmModal()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            var boundFunction = builder.EntitySet<Product>("Products").EntityType.Collection.Function("GetProducts");
                boundFunction.Parameter<int>("Id");
                boundFunction.Parameter<string>("Name");
            boundFunction.Returns<Dictionary<string, string>>();
            return builder.GetEdmModel();
        }

    }
}