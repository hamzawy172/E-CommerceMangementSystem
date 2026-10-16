using AutoMapper;
using E_CommerceMangementSystem.Dtos.OrderDto;
using E_CommerceMangementSystem.Models;
using E_CommerceMangementSystem.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMangementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork u;
        private readonly IMapper mapper;
        public OrdersController(IUnitOfWork u , IMapper mapper)
        {
            this.u = u;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = mapper.Map<Order>(dto);
            await u.Order.AddAsync(data);
            await u.Save();

            return Created();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(int id)
        {
            var data = await u.Order.GetOrderWithitems(id);
            var map = mapper.Map<OrderDto>(data);

            return Ok(map);
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchStatus(int id, PatchStatusDto dto)
        {
            var data = await u.Order.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            data.Status = dto.Status;
            u.Order.Update(data);
            await u.Save();

            return Ok(data);
        }
        [HttpGet("Total-revenue")]
        public async Task<IActionResult> Getrevenue()
        {
            var data = await u.Order.GetTotalRevenue();
            
            return Ok(data);
        }
    }
}
