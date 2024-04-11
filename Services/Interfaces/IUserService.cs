using MgqsPollApp.Dtos;
using PollAppMGQS.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface IUserService 
    {
        Task<BaseResponse<UserDto>> Login(CreateUserRequestModel model);
    }
}
