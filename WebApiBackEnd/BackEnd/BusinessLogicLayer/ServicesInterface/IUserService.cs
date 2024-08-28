using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ServicesInterface
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAllUsers();
        public Task<UserDto> GetUserById(int id);
        public Task<UserDto> InsertUser(UserDto user);
        public Task<UserDto> UpdateUser(UserDto user);
        public Task<UserDto> DeleteUserById(int id);
        public Task<int> Save();

        public Task<UserDto> GetUserByEmailPassword(string email, string password);
        public Task<UserDto> GetUserByEmail(string email);
        public Task<UserDto> GetUserByPassToken(string passwordResetToken);
        public Task<bool> VerifyEmail(string token);
    }
}
