using Auction.Core.Models;
using Auction.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Core.Tests.FakeRepositories
{
    public class FakePersonRepository : IPersonRepository
    {
        private IList<Person> _People;

        public FakePersonRepository()
        {
            _People = new List<Person>();
        }

        public IList<Person> GetPeople() => _People;

        public bool CreatePerson(Person person)
        {
            _People.Add(person);
            return true;
        }

        public Person GetPersonByEmail(string email)
        {
            return _People.SingleOrDefault(p => p.Email.Equals(email));
        }
    }
}
