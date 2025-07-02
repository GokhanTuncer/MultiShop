using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDTO createContactDto);
        Task UpdateContactAsync(UpdateContactDTO updateContactDto);
        Task DeleteContactAsync(string id);
        Task<GetByIDContactDTO> GetByIdContactAsync(string id);
    }
}
