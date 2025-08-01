﻿using MultiShop.DTOLayer.IdentityDTOs.LoginDTOs;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDTO signUpDTO);
        Task<bool> GetRefreshToken();
    }
}
