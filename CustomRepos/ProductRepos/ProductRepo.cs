using E_CommerceMangementSystem.Data;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMangementSystem.CustomRepos.ProductRepos
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly MyContext c;
        public ProductRepo(MyContext c):base(c)
        {
            this.c = c;
        }

        public async Task<List<Product>> Paged(int pnumber, int psize, string SortBy)
        {
            var data = c.products.AsQueryable();

            if (SortBy == "Name" || SortBy == "name")
            {
                data = data.OrderBy(a=>a.Name);
            }
            if (SortBy == "Price" || SortBy == "price")
            {
                data = data.OrderByDescending(a => a.Price);
            }
            data = data.Skip((pnumber - 1) * psize)
                .Take(psize);
                

            return await data.ToListAsync();
        }

        public async Task<List<Product>> SearchByName(string name)
        {
            var data = await c.products.Where(a => a.Name.Contains(name)).ToListAsync();
            return data;
        }

        public async Task<Product> SeconedMostExpinsive()
        {
            var data = await c.products.OrderByDescending(a => a.Price).Skip(1).FirstOrDefaultAsync();
            return data;

        }
    }
}
