using Northwind_Backend.Models;
using NorthwindBackend.Models;

namespace NorthwindBackend.Services.Interfaces
{
    public interface IProductService
    {
        IList<Product> GetAvailableProducts();
        IList<SupplierInfo> GetSupplierProductInfo();
    }
}
