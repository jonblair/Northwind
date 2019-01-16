using System;
using Northwind.Models;
using Northwind.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data.SqlClient;

namespace Northwind.Tests
{
    [TestClass]
    public class DatabaseContextIntegrationTests
    {
        private IDatabaseContext _databaseContext;

        [TestMethod]
        public void DatabaseContextInformation_IntegrationTest()
        {
            _databaseContext = new DatabaseContext(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);

            using (var db = _databaseContext)
            {
                Assert.IsNotNull(db.Connection);
                Assert.AreEqual("Northwind", db.Connection.Database);
                Assert.AreEqual(@"localhost\SQLEXPRESS", db.Connection.DataSource);
                Assert.AreEqual(db.Connection.State.ToString(), "Open");
            }
        }
    }
}
