using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Repositories
{
    public interface IPersonRepository
    {
        Person GetPersonByEmail(string email);
        IList<Person> GetPeople();
        bool CreatePerson(Person person);
    }
}
