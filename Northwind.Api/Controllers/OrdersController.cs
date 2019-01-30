using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Northwind.Models;
using Northwind.Dal;
using System.Configuration;
using Northwind.Api.Services;

namespace Northwind.Api.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrderRepository orderRepo;
        private readonly IDatabaseContext _northwindDatabaseContext;

        public OrdersController()
        {
            _northwindDatabaseContext = new DatabaseContext(ConfigurationService.GetConnectionString("NorthwindConnection"));
        }

        // GET: api/Orders
        public IEnumerable<Order> Get()
        {
            orderRepo = new OrdersRepository(_northwindDatabaseContext);

            return orderRepo.Get();
        }
    }
}
