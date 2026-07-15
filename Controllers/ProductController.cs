using Inventory.API.DTOs;
using Inventory.API.Modals;
using Inventory.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            this.productService = _productService;

        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync(ProductRequestDto productRequestDto)
        {
            if (productRequestDto == null)
            {
                return BadRequest();
            }
            var result = await productService.AddProductAsync(productRequestDto);

            if (result.IsError)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }


        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result =await productService.GetProductsAsync();
            
            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var result = await productService.GetProductByIdAsync(productId);
            return Ok(result);
        }
    }
}
