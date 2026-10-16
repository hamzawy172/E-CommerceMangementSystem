using E_CommerceMangementSystem.Dtos.AuthDtos;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.CustomRepos.AuthRepos
{
    public interface IAuthRepo : IGenericRepo<User>
    {
        Task<string> Login(LoginDto login);
        Task<bool> register(User user);
    }
}
