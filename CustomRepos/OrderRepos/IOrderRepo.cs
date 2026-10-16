using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.CustomRepos.OrderRepos
{
    public interface IOrderRepo : IGenericRepo<Order>
    {
        Task<Order> GetOrderWithitems(int id);
        Task<decimal> GetTotalRevenue();
    }
}
