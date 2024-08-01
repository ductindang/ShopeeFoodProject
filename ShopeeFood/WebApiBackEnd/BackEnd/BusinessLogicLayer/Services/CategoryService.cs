using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Contrast;
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

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var cates = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(cates);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var cate = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(cate);
        }

        public async Task<CategoryDto> InsertCategory(CategoryDto categoryDto)
        {
            var cate = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Insert(cate);
            return categoryDto;
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categoryDto)
        {
            //if(categoryDto == null)
            //{
            //    return null;
            //}
            //var cate = _mapper.Map<Category>(categoryDto);
            //await _categoryRepository.Update(cate);
            //return categoryDto;
            if (categoryDto == null)
            {
                return null;
            }

            var existingEntity = await _categoryRepository.GetById(categoryDto.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            var cate = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(cate);
            return categoryDto;
        }


        public async Task<CategoryDto> DeleteCategoryById(int id)
        {
            var cate = await _categoryRepository.GetById(id);

            if(cate == null)
            {
                return null;
            }

            await _categoryRepository.Delete(cate);
            return _mapper.Map<CategoryDto>(cate);
        }

        

        

        

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        
    }
}
