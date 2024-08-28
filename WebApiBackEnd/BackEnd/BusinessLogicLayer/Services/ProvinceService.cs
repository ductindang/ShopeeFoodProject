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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public ProvinceService(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProvinceRequest>> GetAllProvinces()
        {
            var provinces = await _provinceRepository.GetAll();
            return _mapper.Map<IEnumerable<ProvinceRequest>>(provinces);
        }

        public async Task<ProvinceRequest> GetProvinceById(string id)
        {
            var province = await _provinceRepository.GetProvinceById(id);
            return _mapper.Map<ProvinceRequest>(province);
        }
    }
}
