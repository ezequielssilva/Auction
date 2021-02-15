using Auction.Core.Models;
using Auction.Core.Repositories;
using Auction.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AuctionContext _Context;

        public ProductRepository(AuctionContext context)
        {
            _Context = context;
        }

        public IList<Product> GetProducts()
        {
            return _Context.Products.ToList();
        }

        public bool CreateProduct(Product product)
        {
            _Context.Products.Add(product);
            _Context.SaveChanges();

            return true;
        }

        public Product GetProductById(int id)
        {
            return _Context.Products.SingleOrDefault(p => p.Id == id);
        }
    }
}
