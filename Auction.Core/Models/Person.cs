using System;

namespace Auction.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisteredIn { get; set; }
    }
}
