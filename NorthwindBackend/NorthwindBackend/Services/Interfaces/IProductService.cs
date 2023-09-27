using Northwind_Backend.Models;
using NorthwindBackend.Models;

namespace NorthwindBackend.Services.Interfaces
{
    public interface IProductService
    {
      
        Task<List<Product>> GetAvailableProductsAsync();
    
        Task<List<SupplierInfo>> GetSupplierProductInfoAsync();
    }
}
