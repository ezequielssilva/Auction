using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Core.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auction.Core.Tests.Services
{

    [TestClass]
    public class ProductServiceTest
    {
        private ProductService _ProductService;

        public ProductServiceTest()
        {
            _ProductService = new ProductService(
                new ValidationCollection(),
                new FakeProductRepository());
        }

        [TestMethod]
        public void IsValidProduct()
        {
            var product = new Product();
            product.Name = "Macbook Pro 2020";
            product.Value = 15000;

            Assert.IsTrue(_ProductService.IsValid(product));
        }

        [TestMethod]
        public void IsInvalidProduct()
        {
            var product = new Product();
            product.Name = "";
            product.Value = 0;

            Assert.IsFalse(_ProductService.IsValid(product));
        }

        [TestMethod]
        public void IsInvalidProductWhenValueLessThanOrEqualToZero()
        {
            var product = new Product();
            product.Name = "Macbook Pro 2020";
            product.Value = -1;

            Assert.IsFalse(_ProductService.IsValid(product));
        }
    }
}
