using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerritoryManager.Api.Models
{
    public static class ModelExtensions
    {
        public static TerritoryDto AsDto(this Territory territory){
            return new TerritoryDto(
                territory.tid,
                territory.publisher,
                territory.dateAssigned,
                territory.driveLink
            );
        }
        public static UserAddDto AsDto(this User user){
            return new UserAddDto(
                user.password,
                user.username
            );
        }
    }
}