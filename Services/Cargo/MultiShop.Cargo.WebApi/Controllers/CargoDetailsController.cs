using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoDetailGetById(int id)
        {
            var values = _cargoDetailService.TGetByID(id);
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                SenderCustomer = createCargoDetailDTO.SenderCustomer,
                ReceiverCustomer = createCargoDetailDTO.ReceiverCustomer,
                Barcode = createCargoDetailDTO.Barcode,
                CargoCompanyID = createCargoDetailDTO.CargoCompanyID

            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo bilgisi başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo bilgisi başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                SenderCustomer = updateCargoDetailDTO.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDTO.ReceiverCustomer,
                Barcode = updateCargoDetailDTO.Barcode,
                CargoCompanyID = updateCargoDetailDTO.CargoCompanyID,
                CargoDetailID = updateCargoDetailDTO.CargoDetailID

            };
            return Ok("Kargo bilgisi başarıyla güncellendi.");
        }
    }
}
