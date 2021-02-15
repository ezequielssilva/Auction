using Auction.Core.Models;
using Auction.Core.Repositories;
using Auction.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Infra.Repositories
{
    public class NegotiationRepository : INegotiationRepository
    {
        private AuctionContext _Context;

        public NegotiationRepository(AuctionContext context)
        {
            _Context = context;
        }

        public IList<Negotiation> GetNegotiations()
        {
            return _Context.Negotiations
                .Include(n => n.Product)
                .Include(n => n.Person)
                .OrderByDescending(n => n.Value)
                .ToList();
        }

        public IList<Negotiation> GetNegotiationsByPersonName(string name)
        {
            return _Context.Negotiations
                .Include(n => n.Product)
                .Include(n => n.Person)
                .Where(n => n.Person.Name.Contains(name))
                .OrderByDescending(n => n.Value)
                .ToList();
        }

        public Negotiation LastNegotiationByProduct(int productId)
        {
            return _Context.Negotiations
                .Where(n => n.ProductId == productId)
                .OrderByDescending(n => n.Id)
                .FirstOrDefault();
        }

        public bool CreateNegotiation(Negotiation negotiation)
        {
            _Context.Negotiations.Add(negotiation);
            _Context.SaveChanges();

            return true;
        }
    }
}
