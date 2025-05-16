using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressByIDQueryHandler _getAddressByIDQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIDQueryHandler getAddressByIDQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIDQueryHandler = getAddressByIDQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AddressList()
        { 
            var result = await _getAddressQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public  async Task<IActionResult> AddressListByID(int id)
        {
            var result = await _getAddressByIDQueryHandler.Handle(new GetOrderDetailByIDQuery(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
         await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres başarıyla silindi");
        }
    }
}
