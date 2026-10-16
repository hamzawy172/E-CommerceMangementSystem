using E_CommerceMangementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMangementSystem.GenericRepos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly MyContext c;
        public GenericRepo(MyContext c)
        {
            this.c = c;
        }

        public async Task AddAsync(T item)
        {
            await c.Set<T>().AddAsync(item);
        }

        public void Delete(int id)
        {
            var data = c.Set<T>().Find(id);
        }

        public async Task<List<T>> GetAll()
        {
            var data = await c.Set<T>().ToListAsync();
            return data;
        }

        public async Task<T> GetById(int id)
        {
            var data = await c.Set<T>().FindAsync(id);
            return data;
        }

        public void Update(T item)
        {
            c.Set<T>().Update(item);
        }
    }
}
