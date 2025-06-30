using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<UpdateSpecialOfferDTO> GetByIdSpecialOfferAsync(string id);
    }
}
