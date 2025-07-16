using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.DTOs;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;
        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string ID)
        {
            var values = await _userMessageService.GetSendboxMessageAsync(ID);
            return Ok(values);
        }

        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string ID)
        {
            var values = await _userMessageService.GetInboxMessageAsync(ID);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            await _userMessageService.CreateMessageAsync(createMessageDTO);
            return Ok("Mesaj başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(int ID)
        {
            await _userMessageService.DeleteMessageAsync(ID);
            return Ok("Mesaj başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDTO);
            return Ok("Mesaj başarıyla güncellendi");
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCountByReceiverID")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverID(string ID)
        {
            int values = await _userMessageService.GetTotalMessageCountByReceiverId(ID);
            return Ok(values);
        }
    }
}
