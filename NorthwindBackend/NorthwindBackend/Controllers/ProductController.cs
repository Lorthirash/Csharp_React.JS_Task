using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind_Backend.Models;
using NorthwindBackend.Models;
using NorthwindBackend.Services.Interfaces;

namespace NorthwindBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("AvailableProducts")]
        public async Task<ActionResult<List<Product>>> GetAvailableProducts()
        {
            try
            {
                List<Product> product = await _productService.GetAvailableProductsAsync();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }
        [HttpGet("SupplierProductInfo")]
        public async Task<ActionResult<List<SupplierInfo>>> GetSupplierProductInfo()
        {
            try
            {
                List<SupplierInfo> supplierInfo =  await _productService.GetSupplierProductInfoAsync();
                return Ok(supplierInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }
    }
}
