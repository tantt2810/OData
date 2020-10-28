
using OData_NetFramework.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.OData;

namespace OData_NetFramework.Controllers
{
    public class OrdersController : ODataController
    {
        /// <summary>
        /// Get List Order Controller
        /// Ex: https://localhost:44350/odata/order/orders
        /// </summary>
        [EnableQuery]
        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            Order order = new Order()
            {
                Id = 1,
                DateTime = DateTime.Now,
                TotalAmount = 10000,
                Products = new List<Product>() { }
            };
            return Ok(order);
        }
    }
}