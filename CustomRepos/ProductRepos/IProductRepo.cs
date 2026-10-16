using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.CustomRepos.ProductRepos
{
    public interface IProductRepo : IGenericRepo<Product>
    {
        Task<List<Product>> Paged(int pnumber, int psize, string SortBy);
        Task<Product> SeconedMostExpinsive();
        Task<List<Product>> SearchByName(string name);
    }
}
