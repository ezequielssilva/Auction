using Auction.Core.Models;
using Auction.Core.Repositories;
using System;
using System.Collections.Generic;

namespace Auction.Core.Services
{
    public class ProductService : IProductService
    {
        private IValidationCollection _Validation;
        private IProductRepository _ProductRepository;

        public ProductService(
            IValidationCollection validation,
            IProductRepository productRepository)
        {
            _Validation = validation;
            _ProductRepository = productRepository;
        }

        public IList<Product> GetProducts() => _ProductRepository.GetProducts();

        public bool IsValid(Product product)
        {
            if (String.IsNullOrEmpty(product.Name))
                _Validation.AddError("Name", "Preencha o campo Nome.");

            if (null == product.Value || product.Value <= 0)
                _Validation.AddError("Value", "Informe o valor do produto maior que zero.");

            return _Validation.IsValid;
        }

        public bool CreateProduct(Product product)
        {
            if (!this.IsValid(product))
                return false;

            product.Name = product.Name.ToUpper();
            product.RegisteredIn = DateTime.Now;
            _ProductRepository.CreateProduct(product);

            return true;
        }

        public IList<ValidationModel> GetErrors()
        {
            return _Validation.GetErrors();
        }
    }
}
