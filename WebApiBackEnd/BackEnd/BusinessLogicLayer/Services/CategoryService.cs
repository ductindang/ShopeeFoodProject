using AutoMapper;
using BusinessLogicLayer.BaseRequests;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Requests;
using BusinessLogicLayer.ServicesInterface;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, ApplicationDbContext context, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryRequest>> GetAllCategories()
        {
            var cates = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryRequest>>(cates);
        }

        public async Task<CategoryRequest> GetCategoryById(int id)
        {
            var cate = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryRequest>(cate);
        }

        public async Task<CategoryRequest> InsertCategory(BaseCategory baseCategory)
        {
            var cate = _mapper.Map<Category>(baseCategory);
            cate.CreatedAt = DateTime.UtcNow.AddHours(7);
            cate.UpdatedAt = DateTime.UtcNow.AddHours(7);
            await _categoryRepository.Insert(cate);
            return _mapper.Map<CategoryRequest>(cate);
        }

        public async Task<CategoryRequest> UpdateCategory(CategoryRequest baseCategory)
        {
            //if(categoryDto == null)
            //{
            //    return null;
            //}
            //var cate = _mapper.Map<Category>(categoryDto);
            //await _categoryRepository.Update(cate);
            //return categoryDto;
            if (baseCategory == null)
            {
                return null;
            }

            var existingEntity = await _categoryRepository.GetById(baseCategory.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            var cate = _mapper.Map<Category>(baseCategory);
            cate.UpdatedAt = DateTime.UtcNow.AddHours(7);
            await _categoryRepository.Update(cate);
            return baseCategory;
        }


        public async Task<CategoryRequest> DeleteCategoryById(int id)
        {
            var cate = await _categoryRepository.GetById(id);

            if(cate == null)
            {
                return null;
            }

            await _categoryRepository.Delete(cate);
            return _mapper.Map<CategoryRequest>(cate);
        }

        

        

        

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        
    }
}
