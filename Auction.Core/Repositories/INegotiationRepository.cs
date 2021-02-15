using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Repositories
{
    public interface INegotiationRepository
    {
        bool CreateNegotiation(Negotiation negotiation);
        IList<Negotiation> GetNegotiations();
        IList<Negotiation> GetNegotiationsByPersonName(string name);
        Negotiation LastNegotiationByProduct(int productId);
    }
}
