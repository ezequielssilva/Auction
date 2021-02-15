using Auction.Core.Models;
using Auction.Core.Repositories;
using Auction.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private AuctionContext _Context;

        public PersonRepository(AuctionContext context)
        {
            _Context = context;
        }

        public bool CreatePerson(Person person)
        {
            _Context.People.Add(person);
            _Context.SaveChanges();

            return true;
        }

        public IList<Person> GetPeople()
        {
            return _Context.People.OrderBy(x => x.Name).ToList();
        }

        public Person GetPersonByEmail(string email)
        {
            return _Context.People.SingleOrDefault(x => x.Email.Equals(email));
        }
    }
}
