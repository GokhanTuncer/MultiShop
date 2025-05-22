using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoOperationGetById(int id)
        {
            var values = _cargoOperationService.TGetByID(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
               Barcode = createCargoOperationDTO.Barcode,
                Description = createCargoOperationDTO.Description,
                OperationDate = createCargoOperationDTO.OperationDate

            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo işlemi başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationID = updateCargoOperationDTO.CargoOperationID,
                Barcode = updateCargoOperationDTO.Barcode,
                Description = updateCargoOperationDTO.Description,
                OperationDate = updateCargoOperationDTO.OperationDate
            };
            return Ok("Kargo işlemi başarıyla güncellendi.");
        }
    }
}
