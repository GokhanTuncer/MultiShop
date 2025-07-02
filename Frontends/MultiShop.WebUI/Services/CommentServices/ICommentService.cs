using MultiShop.DTOLayer.CommentDTOs;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDTO>> GetAllCommentAsync();
        Task<List<ResultCommentDTO>> CommentListByProductId(string id);
        Task CreateCommentAsync(CreateCommentDTO createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDTO updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<UpdateCommentDTO> GetByIdCommentAsync(string id);
        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPAssiveCommentCount();
    }
}
