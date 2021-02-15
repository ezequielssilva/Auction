using Auction.Core.Models;
using Auction.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Auction.Core.Services
{
    public class PersonService : IPersonService
    {
        private IValidationCollection _Validation;
        private IPersonRepository _PersonRepository;

        public PersonService(
            IValidationCollection validation,
            IPersonRepository personRepository)
        {
            _Validation = validation;
            _PersonRepository = personRepository;
        }

        public IList<Person> GetPeople()
            => _PersonRepository.GetPeople();

        public Person GetPersonByEmail(string email)
            => _PersonRepository.GetPersonByEmail(email);

        public int GetAge(Person person)
        {
            return new DateTime(DateTime.Now.Subtract(person.DateOfBirth).Ticks).Year - 1;
        }

        public bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(email);
        }

        public bool IsValid(Person person)
        {
            if (person.Name.Trim().Length == 0)
                _Validation.AddError("Name", "Preencha o campo Nome.");

            if (this.GetAge(person) < 18)
                _Validation.AddError("DateOfBirth", "Você precisa ter 18 ou mais para particpar do leilão.");

            if (String.IsNullOrEmpty(person.Email))
                _Validation.AddError("Email", "Informe o E-mail.");

            if (!this.IsValidEmail(person.Email))
                _Validation.AddError("Email", "Informe um E-mail válido.");

            return _Validation.IsValid;
        }

        public bool CreatePerson(Person person)
        {
            if (!this.IsValid(person))
                return false;

            person.Name = person.Name.ToUpper();
            person.RegisteredIn = DateTime.Now;
            _PersonRepository.CreatePerson(person);

            return true;
        }

        public IList<ValidationModel> GetErrors()
        {
            return _Validation.GetErrors();
        }
    }
}
