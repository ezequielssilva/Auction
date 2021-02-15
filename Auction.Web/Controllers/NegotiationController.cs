using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auction.Web.Controllers
{
    public class NegotiationController : Controller
    {
        private IProductService _ProductService;
        private INegotiationService _NegotiationService;
        private IValidationWrapper _ValidationWrapper;

        public NegotiationController(
            IProductService productService,
            INegotiationService negotiationService,
            IValidationWrapper wrapper)
        {
            _ProductService = productService;
            _NegotiationService = negotiationService;
            _ValidationWrapper = wrapper;
        }

        [Route("Negotiation/Create/{personId}")]
        public IActionResult Index(int personId)
        {
            this.ViewBag.Products = _ProductService.GetProducts();

            return View();
        }

        [HttpGet]
        public IActionResult Create(int personId, int productId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ProductId,PersonId,Value")] Negotiation negotiation)
        {
            _ValidationWrapper.SetModelState(this.ModelState);

            if (_NegotiationService.CreateNegotiation(negotiation))
                return RedirectToAction("ShowAll", "Negotiation");

            _ValidationWrapper.MapTo(_NegotiationService.GetErrors());
            return View();
        }

        [HttpGet]
        public IActionResult ShowAll(string personName = null)
        {
            if (String.IsNullOrEmpty(personName))
                @ViewBag.Negotiations = _NegotiationService.GetNegotiations();
            else
                @ViewBag.Negotiations = _NegotiationService.GetNegotiationsByPersonName(personName);
            

            return View();
        }
    }
}
