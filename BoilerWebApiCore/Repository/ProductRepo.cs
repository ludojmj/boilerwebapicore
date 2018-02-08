using System.Collections.Generic;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Shared;

namespace BoilerWebApiCore.Repository
{
    /// <summary>
    /// Test business error if businessError parameter == 1
    /// Normal operation if businessError parameter == 0
    /// </summary>
    public class ProductRepo : IProductRepo
    {
        private readonly IList<Product> _dataSource = new AppDb().AppTable;

        public IList<Product> GetProductsFromRepo(int businessError)
        {
            if (businessError == 1)
            {   // Business error in application since input == 1
                throw new BusinessException("Human message for my app exception.");
            }
            IList<Product> result = _dataSource;
            return result;
        }

        public async Task<IList<Product>> GetProductsFromRepoAsync(int businessError)
        {
            IList<Product> result = await Task.FromResult(GetProductsFromRepo(businessError)).ConfigureAwait(false);
            return result;
        }
    }
}