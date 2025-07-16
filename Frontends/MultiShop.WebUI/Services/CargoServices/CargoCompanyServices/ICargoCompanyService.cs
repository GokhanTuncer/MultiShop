using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDTO>> GetAllCargoCompanyAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO);
        Task DeleteCargoCompanyAsync(int id);
        Task<UpdateCargoCompanyDTO> GetByIdCargoCompanyAsync(int id);
    }
}
