using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Core.Tests.FakeRepositories
{
    public class FakeNegotiationRepository : INegotiationRepository
    {
        private IList<Negotiation> _Negotiations;

        public FakeNegotiationRepository()
        {
            _Negotiations = new List<Negotiation>();
        }

        public bool CreateNegotiation(Negotiation negotiation)
        {
            _Negotiations.Add(negotiation);
            return true;
        }

        public IList<Negotiation> GetNegotiations()
        {
            return _Negotiations;
        }

        public IList<Negotiation> GetNegotiationsByPersonName(string name)
        {
            return _Negotiations
                .Where(n => n.Person.Name.Contains(name))
                .ToList();
        }

        public Negotiation LastNegotiationByProduct(int productId)
        {
            return _Negotiations.SingleOrDefault(n => n.ProductId == productId);
        }
    }
}
