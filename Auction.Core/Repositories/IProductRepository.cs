using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Repositories
{
    public interface IProductRepository
    {
        IList<Product> GetProducts();
        Product GetProductById(int id);
        bool CreateProduct(Product product);
    }
}
