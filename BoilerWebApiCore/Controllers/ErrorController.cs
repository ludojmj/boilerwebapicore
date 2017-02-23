using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Shared;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Exception handling
    /// </summary>
    [Route("api/[controller]/{isDevelopment}")]
    public class ErrorController : Controller
    {
        // Swagger needs an explicit HttpMethod
        // And UseExceptionHandler middleware requires HttpGet *AND* HttpPost according to source controllers
        // (and probably HttpPut, HttpDelete, ... But since there are not used in other controllers, we won't set them) 
        [HttpGet]
        [HttpPost]
        public IActionResult Get(bool isDevelopment)
        {
            var error = new GenericError
            {   // Default: We won't share any information publicly
                Message = "An error occured. Please try again later."
            };

            var feature = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var businessException = feature == null ? null : feature.Error as BusinessException;

            if (businessException != null)
            {
                error.Message = feature.Error.Message;
                feature = null;
                return new JsonResult(error) { StatusCode = 409 };
            }
            if (isDevelopment)
            {
                // Development: We share detailed exception information publicly
                return new JsonResult(feature.Error) { StatusCode = 409 };
            }

            // Default message
            return new JsonResult(error) { StatusCode = 409 };
        }
    }
}
