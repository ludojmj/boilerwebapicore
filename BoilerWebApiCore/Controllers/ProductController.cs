using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Repository;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Test business error if businessError parameter == 1
    /// Normal operation if businessError parameter == 0
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int businessError)
        {
            IList<Product> result = _repo.GetProductsFromRepo(businessError);
            return Ok(result);
        }

        [HttpGet]
        [Route("async")]
        public async Task<IActionResult> GetAsync([FromQuery] int businessError)
        {
            IList<Product> result = await _repo.GetProductsFromRepoAsync(businessError).ConfigureAwait(false);
            return Ok(result); ;
        }
    }
}
