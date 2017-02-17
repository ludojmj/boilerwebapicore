using System.Collections.Generic;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Shared;

namespace BoilerWebApiCore.Repository
{
    /// <summary>
    /// Test our user message when id == 1
    /// Test normal operation when id != 1
    /// </summary>
    public class ProductRepo : IProductRepo
    {
        private readonly IList<Product> _dataSource = new AppDb().AppTable;

        public IList<Product> GetProductsFromRepo(int id)
        {
            if (id == 1)
            {   // Test our own error in app if input == 0
                throw new BusinessException("Human message for my app exception.");
            }
            IList<Product> result = _dataSource;
            return result;
        }

        public async Task<IList<Product>> GetProductsFromRepoAsync(int id)
        {
            IList<Product> result = await Task.FromResult(GetProductsFromRepo(id)).ConfigureAwait(false);
            return result;
        }
    }
}