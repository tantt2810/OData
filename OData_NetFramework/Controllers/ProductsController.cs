using Microsoft.AspNet.OData;
using System.Collections.Generic;
using System.Web.Http;

namespace OData_NetFramework.Controllers
{
    public class ProductsController : ODataController
    {
        /// <summary>
        /// Get Product Controller
        /// Ex: https://localhost:44350/odata/product/Products/GetProducts(Id=100,Name='Candy')
        /// </summary>
        [EnableQuery]
        [HttpGet]
        public IHttpActionResult GetProducts([FromODataUri] int Id, [FromODataUri] string Name)
        {
            Dictionary<string, string> response = new Dictionary<string, string>()
            {
                { "Id", Id.ToString() },
                { "Name", Name }
            };
            return Ok(response);
        }
    }
}