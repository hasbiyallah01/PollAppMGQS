using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface IMessageService
    {
        Task<BaseResponse<MessageDto>> CreateCategoryAsync(CreateMessageRequestModel model);
        Task<BaseResponse<ICollection<MessageDto>>> GetCategoriesAsync();
        Task<BaseResponse<MessageDto>> GetCategoryAsync(string id);
    }
}
