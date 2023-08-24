using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TerritoryManager.Api.Models;
using TerritoryManager.Api.Repositories;

namespace TerritoryManager.Api.Routes
{
    public static class TerritoryRoute
    {
        public static RouteGroupBuilder MapTerritoryRoutes(this IEndpointRouteBuilder routes){
            var group = routes.MapGroup("/territories");

            group.MapGet("/",async (ITerritoryRepository repo)=> 
                (await repo.GetAllAsync()).Select(territory=>territory.AsDto())
            );
            group.MapGet("/{tid}", async (ITerritoryRepository repo,string tid)=> await repo.GetAsync(tid));
            group.MapPut("/{tid}", async (ITerritoryRepository repo,string tid,TerritoryUpdateDto territory)=> await repo.UpdateAsync(tid,territory));

            return group;
        }
    }
}