using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerritoryManager.Api.Models;

namespace TerritoryManager.Api.Repositories
{
    public interface ITerritoryRepository
    {
        Task<Territory> UpdateAsync(string tid,TerritoryUpdateDto territory);
        Task<IEnumerable<Territory>> GetAllAsync();
        Task<Territory?> GetAsync(string tid);
    }
}