using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using BoilerWebApiCore.Models;
using Microsoft.AspNetCore.Hosting;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Exception handling
    /// </summary>
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        private readonly IHostingEnvironment _env;

        public ErrorController(IHostingEnvironment env)
        {
            _env = env;
        }

        // Swagger needs an explicit HttpMethod
        // And UseExceptionHandler middleware requires HttpGet *AND* HttpPost according to source controllers
        // (and probably HttpPut, HttpDelete, ... But since there are not used in other controllers, we won't set them) 
        [HttpGet]
        [HttpPost]
        public IActionResult Get()
        {
            dynamic error = new GenericError
            {   // Default: We won't share any information publicly
                Message = "An error occured. Please try again later."
            };

            if (_env.IsDevelopment())
            {
                // Development: We share detailed exception information publicly
                error = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            }

            return new JsonResult(error) { StatusCode = 409 };
        }
    }
}
