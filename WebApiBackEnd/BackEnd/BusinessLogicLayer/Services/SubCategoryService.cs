using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;

namespace BusinessLogicLayer.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubCategoryRequest>> GetAllSubCategories()
        {
            var subCates = await _subCategoryRepository.GetAll();
            return _mapper.Map<IEnumerable<SubCategoryRequest>>(subCates);
        }

        public async Task<SubCategoryRequest> GetSubCategoryById(int id)
        {
            var subCate = await _subCategoryRepository.GetById(id);
            if(subCate == null)
            {
                return null;
            }
            return _mapper.Map<SubCategoryRequest>(subCate);
        }

        public async Task<SubCategoryRequest> InsertSubCategory(BaseSubCategory subCategoryDto)
        {
            var subCate = _mapper.Map<SubCategory>(subCategoryDto);
            await _subCategoryRepository.Insert(subCate);

            return _mapper.Map<SubCategoryRequest>(subCate);
        }

        public async Task<SubCategoryRequest> UpdateSubCategory(SubCategoryRequest subCategoryDto)
        {
            var subCate = _mapper.Map<SubCategory>(subCategoryDto);
            await _subCategoryRepository.Update(subCate);
            return subCategoryDto;
        }

        public async Task<SubCategoryRequest> DeleteSubCategory(SubCategoryRequest subCategoryDto)
        {
            var subCate = _mapper.Map<SubCategory>(subCategoryDto);
            await _subCategoryRepository.Delete(subCate);
            return subCategoryDto;
        }

        public async Task<IEnumerable<SubCategoryRequest>> GetSubCategoriesByCategoryId(int categoryId)
        {
            var subCates = await _subCategoryRepository.GetSubCategoriesByCategoryId(categoryId);
            return _mapper.Map<IEnumerable<SubCategoryRequest>>(subCates);
        }
    }
}
