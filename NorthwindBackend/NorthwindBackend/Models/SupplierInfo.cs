

namespace Northwind_Backend.Models
{
    public class SupplierInfo
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public IList<ProductInfo> Products { get; set; }
    }
}
