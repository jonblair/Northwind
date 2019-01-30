using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Models
{
    /// <summary>
    /// Order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order Id for Order
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Customer Id for Order
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Employee Id for Order
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Date Order placed
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Date Order is required
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// Order Fright
        /// </summary>
        public double Freight { get; set; }

        /// <summary>
        /// Date Order shipped
        /// </summary>
        public DateTime? ShippedDate { get; set; }

        /// <summary>
        /// Name of Order Shipper
        /// </summary>
        public string ShipName { get; set; }

        /// <summary>
        /// Ship to Address
        /// </summary>
        public string ShipAddress { get; set; }

        /// <summary>
        /// Ship to City
        /// </summary>
        public string ShipCity { get; set; }

        /// <summary>
        /// Ship to Region
        /// </summary>
        public string ShipRegion { get; set; }

        /// <summary>
        /// Ship to Postal Code
        /// </summary>
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// Ship to Country
        /// </summary>
        public string ShipCountry { get; set; }
    }
}