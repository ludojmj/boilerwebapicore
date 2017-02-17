using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace BoilerWebApiCore.Shared
{
    public class GlobalExceptionHandler : IExceptionFilter
    {
        private readonly ILogger<ExceptionContext> _log;
        private readonly IHostingEnvironment _environment;

        public GlobalExceptionHandler(ILogger<ExceptionContext> log, IHostingEnvironment environment)
        {
            _log = log;
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            var businessException = context.Exception as BusinessException;
            if (businessException == null)
            {   // No need to log managed BusinessException
                _log.LogCritical(context.Exception.ToString());
            }

            string msg = _environment.IsDevelopment() || businessException != null
                ? context.Exception.Message
                : "An error occured. Please try again later.";

            var error = new ErrorContent
            {
                Message = "An error occured.",
                MessageDetail = msg
            };
            var result = new JsonResult(error) { StatusCode = 409 };
            context.Result = result;
        }
    }
}