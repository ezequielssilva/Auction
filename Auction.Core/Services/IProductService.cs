using Auction.Core.Models;
using System.Collections.Generic;


namespace Auction.Core.Services
{
    public interface IProductService
    { 
        bool IsValid(Product product);
        IList<Product> GetProducts();
        bool CreateProduct(Product product);
        IList<ValidationModel> GetErrors();
    }
}
