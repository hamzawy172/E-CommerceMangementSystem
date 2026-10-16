using E_CommerceMangementSystem.CustomRepos.AuthRepos;
using E_CommerceMangementSystem.CustomRepos.OrderRepos;
using E_CommerceMangementSystem.CustomRepos.ProductRepos;
using E_CommerceMangementSystem.Data;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepo<User> User { get; }

        public IOrderRepo Order { get; }

        public IGenericRepo<Category> Category { get; }

        public IProductRepo Product { get; }

        public IGenericRepo<OrderItem> OrderItem { get; }
        public IAuthRepo Auth { get; }

        private readonly MyContext c;

        public UnitOfWork(MyContext c , IGenericRepo<User> User , IOrderRepo Order , IGenericRepo<Category> Category , IProductRepo Product , IGenericRepo<OrderItem> OrderItem , IAuthRepo Auth)
        {
            this.c = c;
            this.User = User;
            this.Order = Order;
            this.Category = Category;
            this.Product = Product;
            this.OrderItem = OrderItem;
            this.Auth = Auth;
        }

        public async Task Save()
        {
            await c.SaveChangesAsync();
        }
    }
}
