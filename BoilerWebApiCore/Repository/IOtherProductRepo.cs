using System.Collections.Generic;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Repository
{
    public interface IOtherProductRepo
    {
        IList<Product> GetOtherProductsFromRepo(Product input);
        Task<IList<Product>> GetOtherProductsFromRepoAsync(Product input);
    }
}
