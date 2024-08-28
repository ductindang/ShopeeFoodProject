using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public DistrictService(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DistrictRequest>> GetAllDistricts()
        {
            var districts = await _districtRepository.GetAll();
            return _mapper.Map<IEnumerable<DistrictRequest>>(districts);
        }

        public async Task<DistrictRequest> GetDistrictById(string id)
        {
            var district = await _districtRepository.GetDistrictById(id);
            return _mapper.Map<DistrictRequest>(district);
        }

        public async Task<IEnumerable<DistrictRequest>> GetDistrictsByProvince(string provinceId)
        {
            var districts = await _districtRepository.GetDistrictsByProvince(provinceId);
            return _mapper.Map<IEnumerable<DistrictRequest>>(districts);
        }
    }
}
