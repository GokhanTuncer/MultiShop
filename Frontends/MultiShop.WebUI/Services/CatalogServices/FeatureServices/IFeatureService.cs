using MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDTO>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDTO createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDTO> GetByIdFeatureAsync(string id);
    }
}
