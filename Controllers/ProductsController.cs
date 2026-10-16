using AutoMapper;
using E_CommerceMangementSystem.Dtos.ProductDtos;
using E_CommerceMangementSystem.Models;
using E_CommerceMangementSystem.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMangementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;

        public ProductsController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPaged(int pnumber, int psize, string sortby)
        {
            var data = await u.Product.Paged(pnumber, psize, sortby);
            var map = mapper.Map<List<ProductDto>>(data);

            return Ok(map);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await u.Product.GetById(id);
            if (data == null)
            {
                return NotFound("Product not Found");
            }
            var map = mapper.Map<ProductDto>(data);
            return Ok(map);
        }
        [HttpGet("most-seconed-expinsive")]
        public async Task<IActionResult> SeconedMostExpinsive()
        {
            var data = await u.Product.SeconedMostExpinsive();
            var map = mapper.Map<ProductDto>(data);
            return Ok(map);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var cat = await u.Category.GetById(dto.CategoryId);
            if (cat == null)
            {
                return BadRequest("Category not found");
            }
            var map = mapper.Map<Product>(dto);
            await u.Product.AddAsync(map);
            await u.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id ,UpdateProductDto dto)
        {
            var pro = await u.Product.GetById(id);
            if (pro == null)
            {
                return NotFound("Product not found");
            }
            var cat = await u.Category.GetById(dto.CategoryId);
            if (cat == null)
            {
                return BadRequest("Category not found");
            }
            mapper.Map(dto, pro);
            u.Product.Update(pro);
            await u.Save();

            return Ok(dto);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStok(int id , UpdatwStockDto dto)
        {
            var data = await u.Product.GetById(id);
            if (data == null)
            {
                return NotFound("Produc not found");
            }
            data.Quantity = dto.Quantity;
            u.Product.Update(data);
            await u.Save();

            var map = mapper.Map<ProductDto>(data);
            return Ok(map);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name)
        {
            var data = await u.Product.SearchByName(name);
            var map = mapper.Map<List<ProductDto>>(data);
            return Ok(map);
        }
    }
}
