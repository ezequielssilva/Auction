using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Auction.Core.Services
{
    public class NegotiationService : INegotiationService
    {
        private ModelStateDictionary _ModelState;
        private INegotiationRepository _NegotiationRepository;

        public NegotiationService(
            ModelStateDictionary modelState,
            INegotiationRepository negotiationRepository)
        {
            _ModelState = modelState;
            _NegotiationRepository = negotiationRepository;
        }

        public IList<Negotiation> GetNegotiations()
            => _NegotiationRepository.GetNegotiations();

        public IList<Negotiation> GetNegotiationsByPersonName(string name)
            => _NegotiationRepository.GetNegotiationsByPersonName(name);

        public Negotiation LastNegotiationByProduct(int productId)
            => _NegotiationRepository.LastNegotiationByProduct(productId);

        public bool IsValid(Negotiation negotiation)
        {
            if (negotiation.Value <= negotiation.Product.Value)
                _ModelState.AddModelError("Value", "Informe um valor maior.");

            var lastNegotiation = this.LastNegotiationByProduct(negotiation.ProductId);

            if (null != lastNegotiation && negotiation.Value <= lastNegotiation.Value)
                _ModelState.AddModelError("Value", "Informa um lance com o valor maior que o anterior.");

            if (negotiation.ProductId == 0)
                _ModelState.AddModelError("ProductId", "É necessário um produto para que haja uma negociação válida.");

            if (negotiation.PersonId == 0)
                _ModelState.AddModelError("PersonId", "É necessário uma pessoa para que haja uma negociação válida.");

            return _ModelState.IsValid;
        }

        public bool CreateNegotiation(Negotiation negotiation)
        {
            if (!this.IsValid(negotiation))
                return false;

            _NegotiationRepository.CreateNegotiation(negotiation);

            return false;
        }
    }
}
