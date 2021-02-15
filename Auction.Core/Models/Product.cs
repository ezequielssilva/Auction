using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Core.Models
{
    public class Product
    {
        public int Id { get; private set; }
        
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Display(Name = "Valor do Produto")]
        public decimal? Value { get; set; }

        [NotMapped]
        public string ValueFormat
        {
            get => $"R$ {Value?.ToString("N2")}";
        }

        public DateTime RegisteredIn { get; set; }
    }
}
