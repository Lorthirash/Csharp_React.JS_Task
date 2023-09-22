﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAvailableProducts()
        {
            try
            {
                var productList = _productService.GetAvailableProducts();
                return Ok(productList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }
        [HttpGet("SupplierProductInfo")]
        public IActionResult GetSupplierProductInfo()
        {
            try
            {
                var supplierOrderTotals = _productService.GetSupplierProductInfo();
                return Ok(supplierOrderTotals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Hiba történt: {ex.Message}");
            }
        }
    }
}
