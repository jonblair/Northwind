using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Models;

namespace Northwind.Dal
{
    public interface IOrderRepository
    {
        List<Order> Get();
    }


    public class OrdersRepository: IOrderRepository
    {
        private List<Order> myOrderList;
        private Order myOrder;
        private readonly IDatabaseContext _databaseContext;
        private DateTime dt;

        public OrdersRepository(IDatabaseContext databaseContext)
        {
            myOrderList = new List<Order>();
            _databaseContext = databaseContext;
        }

        public List<Order> Get()
        {
            using (var db = _databaseContext)
            {
                var cmd = db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Orders";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    myOrder = new Order();
                    myOrderList.Add(this.Map(myOrder, reader));
                }
            }

            return myOrderList;
        }

        private Order Map(Order _myOrder, SqlDataReader _reader)
        {
            _myOrder.OrderId = int.Parse(_reader["orderid"].ToString());
            _myOrder.CustomerId = _reader["customerid"].ToString();
            _myOrder.EmployeeId = int.Parse(_reader["employeeid"].ToString());
            _myOrder.OrderDate = DateTime.TryParse(_reader["orderdate"].ToString(), out dt) ? dt : (DateTime?)null;
            _myOrder.RequiredDate = DateTime.TryParse(_reader["requireddate"].ToString(), out dt) ? dt : (DateTime?)null;
            _myOrder.Freight = double.Parse(_reader["freight"].ToString());
            _myOrder.ShippedDate = DateTime.TryParse(_reader["shippeddate"].ToString(), out dt) ? dt : (DateTime?)null;
            _myOrder.ShipName = _reader["shipname"].ToString();
            _myOrder.ShipAddress = _reader["shipaddress"].ToString();
            _myOrder.ShipCity = _reader["shipcity"].ToString();
            _myOrder.ShipRegion = _reader["shipregion"].ToString();
            _myOrder.ShipPostalCode = _reader["shippostalcode"].ToString();
            _myOrder.ShipCountry = _reader["shipcountry"].ToString();

            return _myOrder;
        }
    }
}
