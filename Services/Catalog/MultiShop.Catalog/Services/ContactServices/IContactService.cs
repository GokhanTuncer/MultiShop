using MultiShop.Catalog.DTOs.ContactDTOs;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task CreateContactAsync(CreateContactDTO createContactDTO);
        Task UpdateContactAsync(UpdateContactDTO updateContactDTO);
        Task DeleteContactAsync(string id);
        Task<GetByIDContactDTO> GetByIDContactAsync(string id);
    }
}
