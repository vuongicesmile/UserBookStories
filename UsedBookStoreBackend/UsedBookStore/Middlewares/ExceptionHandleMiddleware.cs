using System.Net;

namespace UsedBookStore.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        // in here , i will first create a constructor
        // and i will inject the eye logger 
        // 1st : create the private 
        private readonly ILogger<ExceptionHandleMiddleware> logger;
        private readonly RequestDelegate next;

        // the second thing i want to inject is the request delegate
        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        // create async method of type task , call this invoke async
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                // log this exception
                logger.LogError(ex, $"{errorId} : {ex.Message}");
                // return a custom error response
                // now, we will make use of the http contxt
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json"; ;

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! we are looking into resolving this"
                };
                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }




    }
}
