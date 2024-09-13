using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public UserAddressService(IUserAddressRepository userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAddressRequest>> GetAllUserAddresses()
        {
            var userAddresses = await _userAddressRepository.GetAll();
            return _mapper.Map<IEnumerable<UserAddressRequest>>(userAddresses);
        }

        public async Task<UserAddressRequest> GetUserAddressById(int id)
        {
            var userAddress = await _userAddressRepository.GetById(id);
            return _mapper.Map<UserAddressRequest>(userAddress);
        }

        public async Task<UserAddressRequest> InsertUserAddress(BaseUserAddress userAddressBase)
        {
            var userAddress = _mapper.Map<UserAddress>(userAddressBase);
            await _userAddressRepository.Insert(userAddress);
            return _mapper.Map<UserAddressRequest>(userAddress);
        }

        public Task<UserAddressRequest> UpdateUserAddress(UserAddressRequest userAddressDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserAddressRequest> DeleteUserAddress(UserAddressRequest userAddressDto)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<UserAddressRequest>> GetAllUserAddressesByUser(int userId)
        {
            var userAddresses = await _userAddressRepository.GetAllUserAddressesByUser(userId);
            return _mapper.Map<IEnumerable<UserAddressRequest>>(userAddresses);
        }

        public async Task<UserAddressDetailDto> GetUserAddressDetailById(int id)
        {
            var userAddressDetail = await _userAddressRepository.GetUserAddressDetailById(id);
            return _mapper.Map<UserAddressDetailDto>(userAddressDetail);
        }
    }
}
