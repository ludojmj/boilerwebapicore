using System.Collections.Generic;
using System.Threading.Tasks;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Repository
{
    /// <summary>
    /// Bug in application if input.Name == "1"
    /// Normal operation if input.Name != "1"
    /// </summary>
    public class OtherProductRepo : IOtherProductRepo
    {
        private readonly IList<Product> _dataSource = new AppDb().AppTable;
        
        public IList<Product> GetOtherProductsFromRepo(Product input)
        {
            if (input.Name == "1")
            {   // Bug in application since input.Name == "1"
                int a = 0;
                int b = 10;
                var c = b / a;
            }

            IList<Product> result = _dataSource;
            return result;
        }

        public async Task<IList<Product>> GetOtherProductsFromRepoAsync(Product input)
        {
            IList<Product> result = await Task.FromResult(GetOtherProductsFromRepo(input)).ConfigureAwait(false);
            return result;
        }
    }
}
