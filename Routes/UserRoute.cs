using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using TerritoryManager.Api.Models;
using TerritoryManager.Api.Repositories;

namespace TerritoryManager.Api.Routes
{
    public static class UserRoute
    {
        public static RouteGroupBuilder MapUserRoutes(this IEndpointRouteBuilder routes){
            var group = routes.MapGroup("/users");

            group.MapPost("/", async (IUserRepository repo, UserAddDto userDto) => {
                User newUser = new(){
                    _id = ObjectId.GenerateNewId(),
                    username = userDto.username,
                    password = userDto.password,
                };
                await repo.CreateAsync(newUser);
                return Results.Ok(newUser);
            });

            return group;
        }
    }
}