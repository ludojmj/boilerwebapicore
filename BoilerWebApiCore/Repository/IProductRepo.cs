using System.Collections.Generic;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Repository
{
    public interface IProductRepo
    {
        IList<Product> GetProductsFromRepo(int businessError);
        Task<IList<Product>> GetProductsFromRepoAsync(int businessError);
    }
}
