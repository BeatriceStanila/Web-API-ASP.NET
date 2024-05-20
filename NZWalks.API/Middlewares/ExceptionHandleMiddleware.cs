using System.Linq.Expressions;
using System.Net;

namespace NZWalks.API.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;

            // request delegate returns a task that represents the completion of request processing
            this.next = next;
        }

        // create an async method so that we can use the request delegate and pass the context 

        public async Task InvokeAsync(HttpContext httpContext)
        {
           try
            {
                // await on the next call and pass the content
                await next(httpContext);
            }
           catch (Exception ex)
            {
                // if anything happens during the calls we want to handle the exceptions at a single exception

                var errorId = Guid.NewGuid();
                // Log this exception
                logger.LogError(ex, $"{errorId} : {ex.Message}" );

                // return a custom error response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";


                var error = new
                {
                    Id = errorId,
                    errorMessage = "Something went wrong!",
                };
                
                await httpContext.Response.WriteAsJsonAsync(error);

                // inject this middleware in the middleware pipeline in Program.cs file
            }
        }
    }
}
