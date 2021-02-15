using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _Service;
        private IValidationWrapper _ValidationWrapper;

        public ProductController(
            IProductService service,
            IValidationWrapper wrapper)
        {
            _Service = service;
            _ValidationWrapper = wrapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name,Value")] Product product)
        {
            _ValidationWrapper.SetModelState(this.ModelState);

            if (_Service.CreateProduct(product))
                return RedirectToAction("ShowAll", "Negotiation");

            _ValidationWrapper.MapTo(_Service.GetErrors());
            return View();
        }
    }
}
