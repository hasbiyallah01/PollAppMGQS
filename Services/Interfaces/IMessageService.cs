using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface MessageService
    {
        Task<BaseResponse<MessageDto>> CreateCategoryAsync(CreateMessageRequestModel model);
        Task<BaseResponse<ICollection<MessageDto>>> GetCategoriesAsync();
        Task<BaseResponse<MessageDto>> GetCategoryAsync(string id);
    }
}
