using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Core.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime RegisteredIn { get; set; }
    }
}
