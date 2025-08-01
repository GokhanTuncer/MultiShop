﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureByID(string id)
        {
            var values = await _featureService.GetByIDFeatureAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            await _featureService.CreateFeatureAsync(createFeatureDTO);
            return Ok("Öne Çıkan Alan başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDTO);
            return Ok("Öne Çıkan Alan başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Öne Çıkan Alan başarıyla silindi");
        }

    }
}
