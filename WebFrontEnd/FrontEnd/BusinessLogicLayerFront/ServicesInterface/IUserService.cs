using BusinessLogicLayerFront.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerFront.ServicesInterface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByEmailPassword(string email, string password);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> InsertUser(UserDto user);
        Task<UserDto> ForgotPassword(string email);
        Task ResetPassword(ResetPasswordDto resetPasswordDto);

        Task<bool> SendVerificationEmail(UserDto userDto);
        Task<bool> VerifyEmail(string token);
    }
}
