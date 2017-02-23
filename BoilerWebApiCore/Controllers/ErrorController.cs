using Microsoft.AspNetCore.Mvc;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Shared;

namespace BoilerWebApiCore.Controllers
{
    [Route("api/[controller]/{isDevelopment}")]
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Get(bool isDevelopment)
        {
            var error = new ErrorContent
            {   // Default: We won't share any information publicly
                Message = "An error occured.",
                MessageDetail = "An error occured. Please try again later."
            };

            var feature = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();

            var businessException = feature == null ? null : feature.Error as BusinessException;

            if (businessException == null)
            {
                if (isDevelopment)
                {   // Bug in development: We share detailed exception information publicly
                    error.MessageDetail = feature.Error.Message;
                }
            }
            else
            {
                // Business exception: We send the specified message
                error.MessageDetail = feature.Error.Message;
            }
            return new JsonResult(error) { StatusCode = 409 };
        }
    }
}
