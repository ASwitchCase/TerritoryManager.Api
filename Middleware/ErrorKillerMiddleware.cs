using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TerritoryManager.Api.Middleware;

public class ErrorKillerMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ErrorKillerMiddleware> logger;

    public ErrorKillerMiddleware(ILogger<ErrorKillerMiddleware> logger,RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }

    public async Task Invoke(HttpContext context){
        try{
            await next(context);
        }
        catch(Exception ex){
            logger.LogError(ex.ToString());
            await Results.Problem(
                title:"Something Went wrong",
                statusCode: StatusCodes.Status500InternalServerError,
                extensions: new Dictionary<string, object?>
                {
                    {"traceId", Activity.Current?.Id}
                }
            ).ExecuteAsync(context);
        }
    }
}