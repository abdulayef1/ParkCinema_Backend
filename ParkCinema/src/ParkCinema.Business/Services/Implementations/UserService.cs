using ParkCinema.Business.DTOs.AppUser;
using ParkCinema.Business.Services.Interfaces;

namespace ParkCinema.Business.Services.Implementations;

public class UserService : IUserService
{
    public Task<bool> AddUser(UserCreateDTO userCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO> GetUserById(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
