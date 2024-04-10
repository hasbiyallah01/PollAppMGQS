using MgqsPollApp.Dtos;
using MgqsPollApp.Services.Interfaces;

namespace MgqsPollApp.Services.Implementations
{
    public class ChatRoomService : IChatRoomService
    {
        public Task<BaseResponse<ChatRoomDto>> CreateCategoryAsync(CreateChatRoomRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ICollection<ChatRoomDto>>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ChatRoomDto>> GetCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
