using Microsoft.AspNetCore.Mvc;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Exception handling
    /// </summary>
    [Route("api/[controller]")]
    public class ErrorController : Controller
    {
        // Swagger needs an explicit HttpMethod
        // And UseExceptionHandler middleware requires HttpGet *AND* HttpPost according to source controllers
        // (and probably HttpPut, HttpDelete, ... But since there are not used in other controllers, we won't set them) 
        [HttpGet]
        [HttpPost]
        public IActionResult Get()
        {
            // We won't share any information publicly
            var error = new GenericError { Message = "An error occured. Please try again later." };
            return new JsonResult(error) { StatusCode = 409 };
        }
    }
}
