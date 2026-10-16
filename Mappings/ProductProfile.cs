using AutoMapper;
using E_CommerceMangementSystem.Dtos.ProductDtos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdatwStockDto, Product>();


        }
    }
}
