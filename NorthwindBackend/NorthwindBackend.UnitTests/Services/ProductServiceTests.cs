using Microsoft.OData.Client;
using Moq;
using NorthwindBackend.Models;
using NorthwindBackend.Services;

namespace NorthwindBackend.UnitTests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public async Task GetAvailableProducts_ReturnsNonEmptyList()
        {
            // Arrange
            var httpClientMock = new Mock<HttpClient>();

            var productService = new ProductService(httpClientMock.Object);

            // Act
            var availableProducts = await productService.GetAvailableProductsAsync();

            // Assert
            Assert.IsNotNull(availableProducts);
            Assert.IsTrue(availableProducts.Count > 0);
            Assert.AreEqual(18, availableProducts.Count);
        }

        [TestMethod]
        public async Task GetSupplierProductInfo_ReturnsNonEmptyList()
        {
            // Arrange
            var httpClientMock = new Mock<HttpClient>();

            var productService = new ProductService(httpClientMock.Object);

            // Act
            var supplierProductInfo = await productService.GetSupplierProductInfoAsync();

            // Assert
            Assert.IsNotNull(supplierProductInfo);
            Assert.IsTrue(supplierProductInfo.Count > 0);
            Assert.AreEqual(29, supplierProductInfo.Count);
        }

    }
}

