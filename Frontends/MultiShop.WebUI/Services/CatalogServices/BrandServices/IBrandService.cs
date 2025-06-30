using MultiShop.DTOLayer.CatalogDTOs.BrandDTOs;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDTO>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDTO createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDTO updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDTO> GetByIdBrandAsync(string id);
    }
}
