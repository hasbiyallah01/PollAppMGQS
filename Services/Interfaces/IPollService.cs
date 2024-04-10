using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface IPollService
    {
        Task<BaseResponse<PollDto>> CreateCategoryAsync(CreatePollRequestModel model);
        Task<BaseResponse<ICollection<PollDto>>> GetCategoriesAsync();
        Task<BaseResponse<PollDto>> GetCategoryAsync(string id);
    }
}
