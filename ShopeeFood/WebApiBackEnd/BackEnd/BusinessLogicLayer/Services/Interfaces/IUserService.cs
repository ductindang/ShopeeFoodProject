using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAllUsers();
        public Task<UserDto> GetByUserId(int id);
        public Task<UserDto> InsertUser(UserDto user);
        public Task<UserDto> UpdateUser(UserDto user);
        public Task<UserDto> DeleteByUserId(int id);
        public Task<int> Save();

        public Task<UserDto> GetUserByEmailPassword(string email, string password);
        public Task<UserDto> GetUserByEmail(string email);
    }
}
