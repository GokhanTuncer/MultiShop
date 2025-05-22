using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoCustomerGetById(int id)
        {
            var values = _cargoCustomerService.TGetByID(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDTO.Name,
                Surname = createCargoCustomerDTO.Surname,
                Email = createCargoCustomerDTO.Email,
                Number = createCargoCustomerDTO.Number,
                Address = createCargoCustomerDTO.Address,
                District = createCargoCustomerDTO.District,
                City = createCargoCustomerDTO.City

            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerID = updateCargoCustomerDTO.CargoCustomerID,
                Name = updateCargoCustomerDTO.Name,
                Surname = updateCargoCustomerDTO.Surname,
                Email = updateCargoCustomerDTO.Email,
                Number = updateCargoCustomerDTO.Number,
                Address = updateCargoCustomerDTO.Address,
                District = updateCargoCustomerDTO.District,
                City = updateCargoCustomerDTO.City

            };
            return Ok("Kargo müşterisi başarıyla güncellendi.");
        }
    }
}
