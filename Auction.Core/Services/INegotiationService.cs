using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Services
{
    public interface INegotiationService
    {
        bool IsValid(Negotiation negotiation);
        bool CreateNegotiation(Negotiation negotiation);
        IList<Negotiation> GetNegotiations();
        IList<Negotiation> GetNegotiationsByPersonName(string name);
        Negotiation LastNegotiationByProduct(int productId);
        IList<ValidationModel> GetErrors();
    }
}
