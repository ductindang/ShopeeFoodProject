
using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;


namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> InsertUser(UserDto user)
        {
            var userInsert = _mapper.Map<User>(user);
            await _userRepository.Insert(userInsert);
            return user;
        }

        public async Task<UserDto> DeleteUserById(int id)
        {
            var user = await _userRepository.GetById(id);
            await _userRepository.Delete(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.Update(user);

            return userDto;
        }

        public async Task<int> Save()
        {
            return await _userRepository.Save();
        }

        public async Task<UserDto> GetUserByEmailPassword(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailPass(email, password);
            if(user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if(user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByPassToken(string passwordResetToken)
        {
            var user = await _userRepository.GetUserByPassToken(passwordResetToken);
            if(user == null)
            {
                return null;
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> VerifyEmail(string token)
        {
            var user = await _userRepository.GetUserByVerificationTokenAsync(token);

            if (user == null)
            {
                return false;
            }

            user.IsEmailVerified = true;
            user.VerificationEmailToken = null;
            user.VerificationEmailTokenExpiry = null;

            await _userRepository.Update(user);
            return true;
        }

    }
}
