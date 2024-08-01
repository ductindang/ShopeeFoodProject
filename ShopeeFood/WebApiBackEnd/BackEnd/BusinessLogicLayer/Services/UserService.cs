
using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Contrast;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, ApplicationDbContext context, IMapper mapper)
        {
            _userRepository = userRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetByUserId(int id)
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

        public async Task<UserDto> DeleteByUserId(int id)
        {
            var user = await _userRepository.GetById(id);
            await _userRepository.Delete(user);

            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> UpdateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
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
    }
}
