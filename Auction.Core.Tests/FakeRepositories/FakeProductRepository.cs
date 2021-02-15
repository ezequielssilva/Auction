using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;

namespace Auction.Core.Tests.FakeRepositories
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> _Products;

        public FakeProductRepository()
        {
            _Products = new List<Product>();
        }

        public IList<Product> GetProducts() => _Products;

        public bool CreateProduct(Product product)
        {
            _Products.Add(product);
            return true;
        }
    }
}
