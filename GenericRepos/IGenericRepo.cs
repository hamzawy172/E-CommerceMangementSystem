namespace E_CommerceMangementSystem.GenericRepos
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(int id);
    }

}
