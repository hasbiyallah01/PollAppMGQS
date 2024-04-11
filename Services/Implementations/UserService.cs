using MgqsPollApp.Dtos;
using MgqsPollApp.Repositories.Interfaces;
using MgqsPollApp.Services.Interfaces;

namespace MgqsPollApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<UserDto>> Login(CreateUserRequestModel model)
        {
            var user = await _userRepository.Get(a => a.Email == model.Email);
            if (user == null)
            {
                return new BaseResponse<UserDto>()
                {
                    Status = false,
                    Message = "invalid credentials",
                    Data = null
                };
            }
            if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return new BaseResponse<UserDto>()
                {
                    Message = $"login successful",
                    Status = true,
                    Data = new UserDto()
                    {
                         Email = model.Email,
                         Password = model.Password,
                         FirstName = model.FirstName,
                         Gender = model.Gender,
                         ImageUrl = model.ImageUrl,
                         PhoneNumber = model.PhoneNumber,
                         LastName = model.LastName,
                         DisplayName = model.FirstName + " " + model.LastName,
                    }

                };
            }
            return new BaseResponse<UserDto>()
            {
                Status = false,
                Message = "invalid credentials",
                Data = null
            };
        }
    }
}
