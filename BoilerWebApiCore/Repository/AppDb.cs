using System.Collections.Generic;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Repository
{
    public class AppDb
    {
        public IList<Product> AppTable => new List<Product>
        {
            new Product { Id = "41", Lib = "Label1" },
            new Product { Id = "42", Lib = "Label2" },
            new Product { Id = "43", Lib = "Label3" }
        };
    }
}