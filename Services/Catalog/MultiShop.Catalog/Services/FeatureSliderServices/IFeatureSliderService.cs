﻿using MultiShop.Catalog.DTOs.FeatureSliderDTOs;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDTO>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDTO createFeatureSliderDTO);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDTO updateFeatureSliderDTO);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByIDFeatureSliderDTO> GetByIDFeatureSliderAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
