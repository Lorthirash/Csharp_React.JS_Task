using NorthwindBackend.Models;

namespace NorthwindBackend.Services.Interfaces
{
    public interface IProductService
    {
        IList<Product> GetAvailableProducts();
    }
}
