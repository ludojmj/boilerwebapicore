using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Shared
{
    public class GenericExceptionHandler : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;

        public GenericExceptionHandler(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var businessException = context.Exception as BusinessException;
            if (businessException == null)
            {   // Not a managed BusinessException
                // ==> Delegating logging to AspNet: UseExceptionHandler/ErrorController
                throw context.Exception;
            }

            var businessError = new GenericError { Message = context.Exception.Message };
            context.Result = new JsonResult(businessError) { StatusCode = 409 };
        }
    }
}