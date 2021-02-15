using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Auction.Core.Services
{
    public class ProductService : IProductService
    {
        private ModelStateDictionary _ModelState;
        private IProductRepository _ProductRepository;

        public ProductService(
            ModelStateDictionary modelState,
            IProductRepository productRepository)
        {
            _ModelState = modelState;
            _ProductRepository = productRepository;
        }

        public IList<Product> GetProducts() => _ProductRepository.GetProducts();

        public bool IsValid(Product product)
        {
            if (product.Name.Trim().Length == 0)
                _ModelState.AddModelError("Name", "Preencha o campo Nome.");

            if (product.Value <= 0)
                _ModelState.AddModelError("Value", "Informe o valor do produto maior que zero.");

            return _ModelState.IsValid;
        }

        public bool CreateProduct(Product product)
        {
            if (!this.IsValid(product))
                return false;

            _ProductRepository.CreateProduct(product);

            return true;
        }
    }
}
