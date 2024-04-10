using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface IChatRoomService
    {
        Task<BaseResponse<ChatRoomDto>> CreateCategoryAsync(CreateChatRoomRequestModel model);
        Task<BaseResponse<ICollection<ChatRoomDto>>> GetCategoriesAsync();
        Task<BaseResponse<ChatRoomDto>> GetCategoryAsync(string id);
    }
}
