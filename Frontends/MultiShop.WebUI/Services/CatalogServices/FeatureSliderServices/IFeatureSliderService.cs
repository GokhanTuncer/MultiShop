using MultiShop.DTOLayer.CatalogDTOs.FeatureSliderDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDTO> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChageStatusToTrue(string id);
        Task FeatureSliderChageStatusToFalse(string id);
    }
}
