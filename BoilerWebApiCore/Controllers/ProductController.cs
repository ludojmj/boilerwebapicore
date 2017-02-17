using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Repository;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Test our user message when id == 1
    /// Test normal operation when id != 1
    /// </summary>
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        // GET api/product/1
        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            IList<Product> result = _repo.GetProductsFromRepo(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("async")]
        public async Task<IActionResult> GetAsync([FromQuery] int id)
        {
            IList<Product> result = await _repo.GetProductsFromRepoAsync(id).ConfigureAwait(false);
            return Ok(result); ;
        }
    }
}
