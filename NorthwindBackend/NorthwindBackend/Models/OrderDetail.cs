using NorthwindBackend.Models;

namespace Northwind_Backend.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        // Navigációs tulajdonságok
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
