using System;

namespace Auction.Core.Models
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double Value { get; set; }
        public DateTime NegotiatedOn { get; set; }
    }
}
