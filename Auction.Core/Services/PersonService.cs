using Auction.Core.Models;
using Auction.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Auction.Core.Services
{
    public class PersonService : IPersonService
    {
        private ModelStateDictionary _ModelState;
        private IPersonRepository _PersonRepository;

        public PersonService(
            ModelStateDictionary modelState,
            IPersonRepository personRepository)
        {
            _ModelState = modelState;
            _PersonRepository = personRepository;
        }

        public IList<Person> GetPeople()
            => _PersonRepository.GetPeople();

        public int GetAge(Person person)
        {
            return new DateTime(DateTime.Now.Subtract(person.DateOfBirth).Ticks).Year - 1;
        }

        public bool IsValid(Person person)
        {
            if (person.Name.Trim().Length == 0)
                _ModelState.AddModelError("Name", "Preencha o campo Nome.");

            if (this.GetAge(person) < 18)
                _ModelState.AddModelError("DateOfBirth", "Você precisa ter 18 ou mais para particpar do leilão.");

            return _ModelState.IsValid;
        }

        public bool CreatePerson(Person person)
        {
            if (!this.IsValid(person))
                return false;

            _PersonRepository.CreatePerson(person);

            return true;
        }
    }
}
