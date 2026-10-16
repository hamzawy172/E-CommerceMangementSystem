using System.Threading.Tasks;
using AutoMapper;
using E_CommerceMangementSystem.Dtos.CategoryDtos;
using E_CommerceMangementSystem.Models;
using E_CommerceMangementSystem.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMangementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var data = await u.Category.GetAll();
            var map = mapper.Map<List<CategoryDto>>(data);

            return Ok(map);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var data = mapper.Map<Category>(dto);
            await u.Category.AddAsync(data);
            await u.Save();

            return Created();
        }
    }
}
