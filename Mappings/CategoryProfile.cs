using AutoMapper;
using E_CommerceMangementSystem.Dtos.CategoryDtos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}
