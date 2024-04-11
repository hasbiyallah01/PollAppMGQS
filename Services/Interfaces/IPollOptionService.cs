using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface PollOptionService
    {
        Task<BaseResponse<PollOptionDto>> CreateCategoryAsync(CreatePollOptionRequestModel model);
        Task<BaseResponse<ICollection<PollOptionDto>>> GetCategoriesAsync();
        Task<BaseResponse<PollOptionDto>> GetCategoryAsync(string id);
    }
}
