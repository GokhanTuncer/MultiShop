using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService AboutService)
        {
            _aboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutByID(string id)
        {
            var values = await _aboutService.GetByIDAboutAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            await _aboutService.CreateAboutAsync(createAboutDTO);
            return Ok("Kategori başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDTO);
            return Ok("Kategori başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Kategori başarıyla silindi");
        }

    }
}
