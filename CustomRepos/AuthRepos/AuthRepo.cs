using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_CommerceMangementSystem.Data;
using E_CommerceMangementSystem.Dtos.AuthDtos;
using E_CommerceMangementSystem.GenericRepos;
using E_CommerceMangementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace E_CommerceMangementSystem.CustomRepos.AuthRepos
{
    public class AuthRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly MyContext c;
        private readonly IConfiguration configuration;

        public AuthRepo(MyContext c , IConfiguration configuration) : base(c)
        {
            this.c = c;
            this.configuration = configuration;
        }

        public async Task<string> Login(LoginDto login)
        {
            var data = await c.users.Where(a => a.Email == login.Email).FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception();
            }
            if (data.Password == login.Password)
            {
                return GenerateToken(data);
            }
            return null;
            //var data = await c.users.Where(a => a.Email == login.Email).FirstOrDefaultAsync();
            //if (data == null)
            //{
            //    throw new Exception();
            //}
            //if (data.Password == login.Password)
            //{
            //    return GenerateToken(data);
            //}
            //return null;

        }
        private string GenerateToken(User user)
        {
            var claimss = new List<Claim>()
            {
                new Claim("Name" , user.FullName),
                new Claim("Email" , user.Email)
            };
            var keyy = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
            var signingcreadintials = new SigningCredentials(keyy , SecurityAlgorithms.HmacSha256);
            var data = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audince"],
                expires: DateTime.Now.AddHours(6),
                claims: claimss,
                signingCredentials: signingcreadintials);

            var token = new JwtSecurityTokenHandler().WriteToken(data);
            return token;
            
            //var cliamss = new List<Claim>
            //{
            //    new Claim ("Name" , user.FullName),
            //    new Claim ("Email" , user.Email)
            //};
            //var keyy = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
            //var signingcredantials = new SigningCredentials(keyy , SecurityAlgorithms.HmacSha256);
            //var data = new JwtSecurityToken(
            //    issuer: configuration["Jwt:Issuer"],
            //    audience: configuration["Jwt:Audince"],
            //    expires: DateTime.Now.AddHours(6),
            //    claims: cliamss,
            //    signingCredentials: signingcredantials
            //    );
            //var Token = new JwtSecurityTokenHandler().WriteToken(data);
            //return Token;
        }

        public async Task<bool> register(User u)
        {
            var data = await c.users.AnyAsync(a => a.Email == u.Email);
            if (data)
            {
                return false;
            }
            await c.users.AddAsync(u);
            await c.SaveChangesAsync();
            return true;
            //var data = await c.users.AnyAsync(a => a.Email == u.Email);
            //if (data)
            //{
            //    return false;
            //}

            //await c.users.AddAsync(u);
            //await c.SaveChangesAsync();

            //return true;
        }
    }
}
