using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Repository;

namespace BoilerWebApiCore.Controllers
{
    /// <summary>
    /// Test bugg in app if input.Id == "1"
    /// Normal operation if input.Id != "1"
    /// </summary>
    [Route("api/[controller]")]
    public class OtherProductController : Controller
    {
        private readonly IOtherProductRepo _repo;

        public OtherProductController(IOtherProductRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product input)
        {
            IList<Product> result = _repo.GetOtherProductsFromRepo(input);
            return Ok(result);
        }

        [HttpPost]
        [Route("async")]
        public async Task<IActionResult> PostAsync([FromBody] Product input)
        {
            IList<Product> result = await _repo.GetOtherProductsFromRepoAsync(input).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
