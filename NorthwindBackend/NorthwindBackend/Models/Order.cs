namespace Northwind_Backend.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTimeOffset? OrderDate { get; set; }
        public DateTimeOffset? RequiredDate { get; set; }
        public DateTimeOffset? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        // Navigációs tulajdonságok
        
        public IList<OrderDetail> OrderDetails { get; set; }
    }
}
