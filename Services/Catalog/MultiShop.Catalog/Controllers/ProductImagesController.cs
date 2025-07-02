﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("ProductImagesByProductID/{id}")]
        public async Task<IActionResult> ProductImagesByProductID(string id)
        {
            var values = await _productImageService.GetByProductIDProductImageAsync(id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByID(string id)
        {
            var values = await _productImageService.GetByIDProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDTO);
            return Ok("Ürün görselleri başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
            return Ok("Ürün görselleri başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi");
        }
    }
}
