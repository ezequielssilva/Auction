using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Core.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "E-mail do Comprador")]
        public string Email { get; set; }

        [Display(Name = "Nome do Comprador")]
        public string Name { get; set; }

        [Display(Name = "Data de Nascimento do Comprador")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisteredIn { get; set; }
    }
}
