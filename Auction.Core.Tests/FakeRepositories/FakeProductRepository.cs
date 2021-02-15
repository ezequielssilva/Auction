using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Core.Tests.FakeRepositories
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> _Products;

        public FakeProductRepository()
        {
            _Products = new List<Product>();
            _Products.Add(new Product() { Name = "CASA MANSÃO", Value = 50000});
        }

        public IList<Product> GetProducts() => _Products;

        public bool CreateProduct(Product product)
        {
            _Products.Add(product);
            return true;
        }

        public Product GetProductById(int id)
        {
            var count = _Products.Count;

            if (count < id)
                return null;

            return _Products[id - 1];
        }
    }
}
