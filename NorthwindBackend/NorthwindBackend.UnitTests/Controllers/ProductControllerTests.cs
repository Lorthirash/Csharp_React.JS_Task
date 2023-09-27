using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Northwind_Backend.Models;
using NorthwindBackend.Controllers;
using NorthwindBackend.Models;
using NorthwindBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NorthwindBackend.UnitTests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public async Task GetAvailableProducts_ReturnsOkResult()
        {
            var productServiceMock = new Mock<IProductService>();
            var mockProducts = new List<Product>
            {
                new Product
                {
                    ProductID = 1,
                    ProductName = "Termék 1",
                    SupplierID = 1,
                    CategoryID = 1,
                    QuantityPerUnit = "10 darab/doboz",
                    UnitPrice = 10.0m,
                    UnitsInStock = 100,
                    UnitsOnOrder = 20,
                    ReorderLevel = 10,
                    Discontinued = false
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Termék 2",
                    SupplierID = 2,
                    CategoryID = 2,
                    QuantityPerUnit = "20 darab/doboz",
                    UnitPrice = 20.0m,
                    UnitsInStock = 80,
                    UnitsOnOrder = 30,
                    ReorderLevel = 15,
                    Discontinued = false
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Termék 3",
                    SupplierID = 3,
                    CategoryID = 3,
                    QuantityPerUnit = "20 darab/doboz",
                    UnitPrice = 20.0m,
                    UnitsInStock = 0,
                    UnitsOnOrder = 40,
                    ReorderLevel = 15,
                    Discontinued = false
                }
            };
            productServiceMock.Setup(p => p.GetAvailableProductsAsync()).ReturnsAsync(mockProducts);
            var controller = new ProductController(productServiceMock.Object);

            var result = await controller.GetAvailableProducts();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var products = (result.Result as OkObjectResult).Value as List<Product>;
            Assert.IsNotNull(products);
            Assert.AreEqual(mockProducts.Count, products.Count);
        }

        [TestMethod]
        public async Task GetSupplierProductInfo_ReturnsOkResult()
        {
            var productServiceMock = new Mock<IProductService>();
            var mockSupplierInfo = new List<SupplierInfo>
            {
                new SupplierInfo
                {
                    SupplierID = 1,
                    CompanyName = "Beszállító 1",
                    Products = new List<ProductInfo>
                    {
                        new ProductInfo
                        {
                            ProductID = 1,
                            ProductName = "Termék 1",
                            TotalOrderedValue = 100.0m
                        },
                        new ProductInfo
                        {
                            ProductID = 2,
                            ProductName = "Termék 2",
                            TotalOrderedValue = 200.0m
                        }
                    }
                },
                new SupplierInfo
                {
                    SupplierID = 2,
                    CompanyName = "Beszállító 2",
                    Products = new List<ProductInfo>
                    {
                        new ProductInfo
                        {
                            ProductID = 3,
                            ProductName = "Termék 3",
                            TotalOrderedValue = 300.0m
                        }
                    }
                }
            };

            productServiceMock.Setup(p => p.GetSupplierProductInfoAsync()).ReturnsAsync(mockSupplierInfo);
            var controller = new ProductController(productServiceMock.Object);

            var result = await controller.GetSupplierProductInfo();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var supplierInfo = (result.Result as OkObjectResult).Value as List<SupplierInfo>;
            Assert.IsNotNull(supplierInfo);
            Assert.AreEqual(mockSupplierInfo.Count, supplierInfo.Count);
        }
    }
}
