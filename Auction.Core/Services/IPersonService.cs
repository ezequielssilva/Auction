using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Services
{
    public interface IPersonService
    {
        bool IsValid(Person person);
        bool IsValidEmail(string email);
        IList<Person> GetPeople();
        bool CreatePerson(Person person);
        int GetAge(Person person);
        Person GetPersonByEmail(string email);
        IList<ValidationModel> GetErrors();
    }
}
