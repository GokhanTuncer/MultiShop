using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(string id)
        {
            var values = await _productService.GetByIDProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.CreateProductAsync(createProductDTO);
            return Ok("Ürün başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
            return Ok("Ürün başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi");
        }
        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetProductsWithCategoryAsync();
            return Ok(values);

        }

        [HttpGet("ProductListWithCategoryByCategoryID")]
        public async Task<IActionResult> ProductListWithCategoryByCategoryID(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIDAsync(id);
            return Ok(values);

        }
    }
}
