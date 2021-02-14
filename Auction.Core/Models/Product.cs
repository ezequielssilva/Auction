using System;

namespace Auction.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinimumValue { get; set; }
        public DateTime RegisteredIn { get; set; }
    }
}
