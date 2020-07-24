using CentralDeErros.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Datas.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RepositoryUser(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Register(string name, string email, string password)
        {
            var user = new IdentityUser()
            {
                UserName = name,
                Email = email,
                EmailConfirmed = true
            };

            var content = await _userManager.CreateAsync(user, password);

            return content.Succeeded;
        }

        public async Task<IdentityUser> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }
    }
}
