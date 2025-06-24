using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userLoginDTO.Username,
                userLoginDTO.Password,
                isPersistent: false,
                lockoutOnFailure: false);

            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);


            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.Username = userLoginDTO.Username;
                model.ID = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Kullanıcı Adı veya Şifre hatalı");
            }
        }
    }

}
