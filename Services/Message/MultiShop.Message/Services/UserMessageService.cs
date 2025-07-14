using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.Dal.Context;
using MultiShop.Message.Dal.Entities;
using MultiShop.Message.DTOs;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }
        public async Task CreateMessageAsync(CreateMessageDTO createMessageDTO)
        {
            var value = _mapper.Map<UserMessage>(createMessageDTO);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }
        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }
        public async Task<List<ResultMessageDTO>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDTO>>(values);
        }
        public async Task<GetByIDMessageDTO> GetByIdMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIDMessageDTO>(values);
        }
        public async Task<List<ResultInboxMessageDTO>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDTO>>(values);
        }
        public async Task<List<ResultSendboxMessageDTO>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderID == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDTO>>(values);
        }

        public async Task<int> GetTotalMessageCount()
        {
            int values = await _messageContext.UserMessages.CountAsync();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverID == id).CountAsync();
            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            var values = _mapper.Map<UserMessage>(updateMessageDTO);
            _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }
    }
}
