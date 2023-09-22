using Microsoft.OData.Client;
using NorthwindBackend.Models;
using NorthwindBackend.Services.Interfaces;

namespace NorthwindBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly DataServiceContext _context;

        public ProductService(HttpClient httpClient)
        {
            // Inicializáljuk az OData szolgáltatás kapcsolatot
            _context = new DataServiceContext(new Uri("https://services.odata.org/V4/Northwind/Northwind.svc/"));
        }

        // Lekéri az összes olyan terméket, amelyeknél a készlet mennyisége nagyobb, mint 0
        public IList<Product> GetAvailableProducts()
        {
            // Lekérdezzük az összes terméket az OData szolgáltatásból
            var query = _context.CreateQuery<Product>("Products").ToList()
                                .Where(p => p.UnitsInStock > 0);

            // Visszaadjuk az elérhető termékek listáját
            return query.ToList();
        }
    }
}
