using MultiShop.DTOLayer.MessageDTOs;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDTO>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDTO>> GetSendboxMessageAsync(string id);
    }
}
