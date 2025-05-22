using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        { 
            var values= _cargoCompanyService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoCompanyGetById(int id)
        {
            var values = _cargoCompanyService.TGetByID(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        { 
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName = createCargoCompanyDTO.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi başarıyla eklendi."); 
        }
        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyID = updateCargoCompanyDTO.CargoCompanyID,
                CargoCompanyName = updateCargoCompanyDTO.CargoCompanyName
            };
            return Ok("Kargo şirketi başarıyla güncellendi.");
        }
    }

}
