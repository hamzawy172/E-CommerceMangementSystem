using E_CommerceMangementSystem.CustomRepos.AuthRepos;
using E_CommerceMangementSystem.CustomRepos.OrderRepos;
using E_CommerceMangementSystem.CustomRepos.ProductRepos;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepo<User> User {  get; }
        IOrderRepo Order {  get; }
        IGenericRepo<Category> Category {  get; }
        IProductRepo Product {  get; }
        IGenericRepo<OrderItem> OrderItem {  get; }
        IAuthRepo Auth { get; }
        Task Save();
    }
}
