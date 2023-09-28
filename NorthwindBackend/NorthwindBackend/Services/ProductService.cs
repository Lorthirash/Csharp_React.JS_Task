using Microsoft.OData.Client;
using Northwind_Backend.Models;
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
        public async Task<List<Product>> GetAvailableProductsAsync()
        {
            // Lekérdezzük az összes terméket az OData szolgáltatásból
            List<Product> query = _context.CreateQuery<Product>("Products")
                                           .ToList()
                                           .Where(p => p.UnitsInStock > 0)
                                           .ToList();

            // Visszaadjuk az elérhető termékek listáját
            return await Task.FromResult(query);
        }





        // Lekéri az összes beszállítót, valamint az általuk szállított termékeket és az ezekből rendelt összértéket
        public async Task<List<SupplierInfo>> GetSupplierProductInfoAsync()
        {
            // Lekérdezzük az összes beszállítót, terméket és rendelés részletet az OData szolgáltatásból
            List<Supplier> suppliers = _context.CreateQuery<Supplier>("Suppliers").ToList();
            List<Product> products = _context.CreateQuery<Product>("Products").ToList();
            List<OrderDetail> orderDetails = _context.CreateQuery<OrderDetail>("Order_Details")
                .Expand("Order")
                .ToList();

            // Létrehozzuk a SupplierInfo objektumokat a beszállítókhoz és a hozzájuk kapcsolódó termékeket
            List<SupplierInfo> supplierInfo = suppliers
                .Select(supplier => new SupplierInfo
            {
                SupplierID = supplier.SupplierID,
                CompanyName = supplier.CompanyName,
                Products = products
                    .Where(product => product.SupplierID == supplier.SupplierID)
                    .Select(product => new ProductInfo
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        // Számoljuk az összes rendelés összértékét az adott termékből
                        TotalOrderedValue = orderDetails
                            .Where(od => od.ProductID == product.ProductID)
                            .Sum(od => od.UnitPrice * od.Quantity)
                    })
                    .ToList()
            }).ToList();

            // Visszaadjuk a beszállítók és az általuk szállított termékek listáját
            return await Task.FromResult(supplierInfo);
        }




    }
}
