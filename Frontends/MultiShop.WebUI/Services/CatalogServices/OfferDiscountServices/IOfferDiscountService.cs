using MultiShop.DTOLayer.CatalogDTOs.OfferDiscountDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDTO>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDTO createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDTO updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDTO> GetByIdOfferDiscountAsync(string id);
    }
}
