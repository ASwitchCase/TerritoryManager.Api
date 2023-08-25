using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerritoryManager.Api.Models;

namespace TerritoryManager.Api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> CreateAsync(User newUser); 
        Task<bool> DoesContainAsync(User target); 
    }
}