using HexagonalSample.Application.Exceptions;

namespace HexagonalProject.ApiHost.Middleware
{
    public class ExceptionMiddleware
    {
        // bu kod parçası, ASP.NET Core uygulamasında özel bir ara katman (middleware) sınıfını tanımlar.
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case NotFoundException:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case BadRequestException:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var response = new
            {
                message = ex.Message,
                StatusCode = context.Response.StatusCode
            };
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
