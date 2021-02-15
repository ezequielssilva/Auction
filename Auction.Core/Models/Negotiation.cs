using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Auction.Core.Models
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        [Display(Name = "Valor do Lance")]
        public decimal Value { get; set; }

        [NotMapped]
        public string ValueFormat
        {
            get => $"R$ {Value.ToString("N2")}";
        }

        public DateTime NegotiatedOn { get; set; }
    }
}
