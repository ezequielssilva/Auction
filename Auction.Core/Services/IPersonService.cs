using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Services
{
    public interface IPersonService
    {
        bool IsValid(Person person);
        IList<Person> GetPeople();
        bool CreatePerson(Person person);
        int GetAge(Person person);
    }
}
