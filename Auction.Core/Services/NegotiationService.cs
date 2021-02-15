using Auction.Core.Models;
using Auction.Core.Repositories;
using System;
using System.Collections.Generic;

namespace Auction.Core.Services
{
    public class NegotiationService : INegotiationService
    {
        private IValidationCollection _Validation;
        private INegotiationRepository _NegotiationRepository;
        private IProductRepository _ProductRepository;

        public NegotiationService(
            IValidationCollection validation,
            INegotiationRepository negotiationRepository,
            IProductRepository productRepository)
        {
            _Validation = validation;
            _NegotiationRepository = negotiationRepository;
            _ProductRepository = productRepository;
        }

        public IList<Negotiation> GetNegotiations()
            => _NegotiationRepository.GetNegotiations();

        public IList<Negotiation> GetNegotiationsByPersonName(string name)
            => _NegotiationRepository.GetNegotiationsByPersonName(name);

        public Negotiation LastNegotiationByProduct(int productId)
            => _NegotiationRepository.LastNegotiationByProduct(productId);

        public bool IsValid(Negotiation negotiation)
        {
            var lastNegotiation = this.LastNegotiationByProduct(negotiation.ProductId);
            if (null != lastNegotiation && negotiation.Value <= lastNegotiation.Value)
                _Validation.AddError("Value", $"Informa um lance com o valor maior que {lastNegotiation.ValueFormat}.");
            else if (negotiation.Value <= negotiation.Product.Value)
                _Validation.AddError("Value", $"Informe um valor maior que {negotiation.Product.ValueFormat}.");

            if (negotiation.ProductId == 0)
                _Validation.AddError("ProductId", "É necessário um produto para que haja uma negociação válida.");

            if (negotiation.PersonId == 0)
                _Validation.AddError("PersonId", "É necessário uma pessoa para que haja uma negociação válida.");

            return _Validation.IsValid;
        }

        public bool CreateNegotiation(Negotiation negotiation)
        {
            negotiation.Product = _ProductRepository.GetProductById(negotiation.ProductId);

            if (!this.IsValid(negotiation))
                return false;

            negotiation.NegotiatedOn = DateTime.Now;
            _NegotiationRepository.CreateNegotiation(negotiation);

            return true;
        }

        public IList<ValidationModel> GetErrors()
        {
            return _Validation.GetErrors();
        }
    }
}
