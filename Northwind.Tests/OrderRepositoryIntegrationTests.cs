using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Models;
using Northwind.Dal;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

namespace Northwind.Tests
{
    [TestClass]
    public class OrderRepositoryIntegrationTests
    {
        private IOrderRepository orderRepo;
        private IDatabaseContext _northwindDatabaseContext = new DatabaseContext(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);

        [TestMethod]
        public void OrderRepository_Get()
        {
            List<Order> myOrders = new List<Order>();
            orderRepo = new OrdersRepository(_northwindDatabaseContext);
            myOrders = orderRepo.Get();

            Assert.IsNotNull(myOrders);
            Assert.AreNotEqual(0, myOrders.Count);
            foreach (Order myOrder in myOrders)
            {
                Assert.IsInstanceOfType(myOrder, typeof(Order));
            }
            Assert.IsInstanceOfType(orderRepo, typeof(IOrderRepository));
        }
    }
}
