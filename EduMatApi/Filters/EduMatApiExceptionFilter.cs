using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EduMatApi.Filters
{
    public class EduMatApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<EduMatApiExceptionFilter> _logger;

        public EduMatApiExceptionFilter(ILogger<EduMatApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            _logger.LogError($"[{DateTime.Now}] Uncought exception: {context.Exception.Message}");

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            response.ContentType = "application/json";
            response.WriteAsync("An internal server error occured. Sorry!");
        }
    }
}
