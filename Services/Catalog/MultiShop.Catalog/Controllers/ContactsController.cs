using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactsController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _ContactService.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactByID(string id)
        {
            var values = await _ContactService.GetByIDContactAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            await _ContactService.CreateContactAsync(createContactDTO);
            return Ok("Bağlantı başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _ContactService.UpdateContactAsync(updateContactDTO);
            return Ok("Bağlantı başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _ContactService.DeleteContactAsync(id);
            return Ok("Bağlantı başarıyla silindi");
        }
    }
}
