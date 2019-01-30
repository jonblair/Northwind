using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Models;
using Northwind.Dal;
using Northwind.Api.Services;
using System.Web.Http.Description;

namespace Northwind.Api.Controllers
{
    /// <summary>
    /// Api endpoint for Orders (api/Orders)
    /// </summary>
    public class OrdersController : ApiController
    {
        private IOrderRepository orderRepo;
        private readonly IDatabaseContext _northwindDatabaseContext;

        private OrdersController()
        {
            _northwindDatabaseContext = new DatabaseContext(ConfigurationService.GetConnectionString("NorthwindConnection"));
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <remarks>
        /// Get a list of all orders
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        // GET: api/Orders
        [ResponseType(typeof(IEnumerable<Order>))]
        public HttpResponseMessage Get()
        {
            orderRepo = new OrdersRepository(_northwindDatabaseContext);

            return Request.CreateResponse(HttpStatusCode.OK, orderRepo.Get());
        }
    }
}
