using MgqsPollApp.Dtos;

namespace MgqsPollApp.Services.Interfaces
{
    public interface IUserService 
    {
        Task<BaseResponse<UserDto>> Login(CreateUserRequestModel model);
    }
}
