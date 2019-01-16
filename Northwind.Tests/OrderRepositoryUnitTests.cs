using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Models;
using Northwind.Dal;
using System.Configuration;
using Moq;
using System.Collections.Generic;

namespace Northwind.Tests
{
    [TestClass]
    public class OrderRepositoryUnitTests
    {
        public readonly IOrderRepository MockOrdersRepository;
        private List<Order> _testOrders;

        public OrderRepositoryUnitTests()
        {
            _testOrders = this.generateTestData();
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(mr => mr.Get()).Returns(_testOrders);
            this.MockOrdersRepository = mockOrderRepository.Object;
        }

        [TestMethod]
        public void OrderRepository_Get()
        {
            List<Order> myOrders = this.MockOrdersRepository.Get();

            Assert.IsNotNull(myOrders);
            Assert.AreNotEqual(0, myOrders.Count);
            foreach (Order myOrder in myOrders)
            {
                Assert.IsInstanceOfType(myOrder, typeof(Order));
            }
            Assert.IsInstanceOfType(this.MockOrdersRepository, typeof(IOrderRepository));
        }

        private List<Order> generateTestData(int recordCount = 10)
        {
            List<Order> _myOrders = new List<Order>();
            int index = 1;

            while (index <= recordCount)
            {
                Order _myOrder = new Order
                {
                    OrderId = index,
                    CustomerId = index.ToString(),
                    EmployeeId = index,
                    OrderDate = DateTime.Now.AddDays(-index),
                    RequiredDate = DateTime.Now.AddDays(index),
                    Freight = index * 5,
                    ShippedDate = DateTime.Now.AddHours(-index),
                    ShipName = "Test Name " + index.ToString(),
                    ShipAddress = index.ToString() + " Test Address",
                    ShipCity = "Test City",
                    ShipRegion = "Test Region",
                    ShipPostalCode = "11223",
                    ShipCountry = "USA"
                };

                _myOrders.Add(_myOrder);

                index++;
            }

            return _myOrders;
        }
    }
}
