using System.Collections.Generic;
using BoilerWebApiCore.Models;

namespace BoilerWebApiCore.Repository
{
    public class AppDb
    {
        public IList<Product> AppTable => new List<Product>
        {
            new Product {Category = "Sporting Goods", Price = "$49.99", Stocked = true, Name = "Football"},
            new Product {Category = "Sporting Goods", Price = "$9.99", Stocked = true, Name = "Baseball"},
            new Product {Category = "Sporting Goods", Price = "$29.99", Stocked = false, Name = "Basketball"},
            new Product {Category = "Electronics", Price = "$99.99", Stocked = true, Name = "iPod Touch"},
            new Product {Category = "Electronics", Price = "$399.99", Stocked = false, Name = "iPhone 5"},
            new Product {Category = "Electronics", Price = "$199.99", Stocked = true, Name = "Nexus 7"}
        };
    }
}