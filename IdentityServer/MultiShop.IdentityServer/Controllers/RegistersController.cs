﻿using IdentityServer4.Hosting.LocalApiAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDTO userRegisterDTO)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDTO.Username,
                Email = userRegisterDTO.Email,
                Name = userRegisterDTO.Name,
                Surname = userRegisterDTO.Surname
            };
            var result = await _userManager.CreateAsync(values, userRegisterDTO.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                // Handle errors
                return Ok("Bir hata oluştu");
            }
        }

    }
}
