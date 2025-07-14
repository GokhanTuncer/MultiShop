using MultiShop.Message.DTOs;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDTO>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDTO>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDTO>> GetSendboxMessageAsync(string id);
        Task CreateMessageAsync(CreateMessageDTO createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDTO updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIDMessageDTO> GetByIdMessageAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
