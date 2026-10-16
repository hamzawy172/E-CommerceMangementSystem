using E_CommerceMangementSystem.Data;
using E_CommerceMangementSystem.Dtos.OrderDto;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMangementSystem.CustomRepos.OrderRepos
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        private readonly MyContext c;
        public OrderRepo(MyContext c) : base(c)
        {
           this.c = c; 
        }

        public async Task<Order> GetOrderWithitems(int id)
        {
            var data = await c.orders.Where(a => a.Id == id).Include(a => a.OrderItems).FirstOrDefaultAsync();
            return data;
        }

        public async Task<decimal> GetTotalRevenue()
        {
            var data = c.orders.Sum(a => a.TotalAmount);
            return data;
        }
    }
}
