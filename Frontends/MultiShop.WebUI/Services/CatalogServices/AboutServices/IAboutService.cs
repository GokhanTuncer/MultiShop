using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {

        Task<List<ResultAboutDTO>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAboutDTO createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDTO updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<UpdateAboutDTO> GetByIdAboutAsync(string id);
    }
}
