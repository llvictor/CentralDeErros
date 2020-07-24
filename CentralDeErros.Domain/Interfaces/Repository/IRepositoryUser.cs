using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Domain.Interfaces.Repository
{
    public interface IRepositoryUser
    {
        Task<bool> Register(string name, string email, string password);
        Task<IdentityUser> Login(string email, string password);
    }
}
