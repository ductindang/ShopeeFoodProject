using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class WardService : IWardService
    {
        private readonly IWardRepository _wardRepository;
        private readonly IMapper _mapper;

        public WardService(IWardRepository wardRepository, IMapper mapper)
        {
            _wardRepository = wardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WardRequest>> GetAllWards()
        {
            var wards = await _wardRepository.GetAll();
            return _mapper.Map<IEnumerable<WardRequest>>(wards);
        }

        public async Task<WardRequest> GetWardById(string id)
        {
            var ward = await _wardRepository.GetWardById(id);
            return _mapper.Map<WardRequest>(ward);
        }

        public async Task<IEnumerable<WardRequest>> GetWardsByDistrict(string districtId)
        {
            var wards = await _wardRepository.GetWardsByDistrict(districtId);
            return _mapper.Map<IEnumerable<WardRequest>>(wards);
        }
    }
}
