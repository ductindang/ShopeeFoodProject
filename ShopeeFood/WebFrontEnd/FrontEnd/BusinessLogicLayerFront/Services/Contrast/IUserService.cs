using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.Services.Contrast
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByEmailPassword(string email, string password);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> InsertUser(UserDto user);
        
    }
}
