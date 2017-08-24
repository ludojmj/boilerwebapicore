using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Shared
{
    public class GenericExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var businessException = context.Exception as BusinessException;
            if (businessException == null)
            {   // Not a managed BusinessException
                // ==> Delegating logging to AspNet: UseExceptionHandler/ErrorController
                return;
            }

            var businessError = new GenericError { Message = context.Exception.Message };
            context.Result = new JsonResult(businessError) { StatusCode = 409 };
        }
    }
}