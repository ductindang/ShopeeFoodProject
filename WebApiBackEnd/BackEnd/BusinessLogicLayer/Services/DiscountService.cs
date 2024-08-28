using AutoMapper;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DiscountRequest>> GetAllDiscounts()
        {
            var discounts = await _discountRepository.GetAll();
            return _mapper.Map<IEnumerable<DiscountRequest>>(discounts);
        }

        public async Task<DiscountRequest> GetDiscountById(int id)
        {
            var product = await _discountRepository.GetById(id);
            return _mapper.Map<DiscountRequest>(product);
        }


    }
}
