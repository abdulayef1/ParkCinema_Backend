using ParkCinema.Business.DTOs.AppUser;

namespace ParkCinema.Business.Services.Interfaces;

public interface IUserService
{
    Task<bool> AddUser(UserCreateDTO userCreateDTO); 
    Task<UserDTO> GetUserById(int Id); 
    Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO);
}
