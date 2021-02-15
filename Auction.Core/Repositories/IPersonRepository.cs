using Auction.Core.Models;
using System.Collections.Generic;

namespace Auction.Core.Repositories
{
    public interface IPersonRepository
    {
        IList<Person> GetPeople();
        bool CreatePerson(Person person);
    }
}
