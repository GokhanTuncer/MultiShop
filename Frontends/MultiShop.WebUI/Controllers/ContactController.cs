﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Mesaj Gönder";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
    
}


