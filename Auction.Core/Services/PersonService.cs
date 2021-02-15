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
            return new DateTime(DateTime.Now.Subtract((DateTime)person?.DateOfBirth).Ticks).Year - 1;
        }

        public bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                _Validation.AddError("Email", "Informe o E-mail.");
                return false;
            }

            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (regex.IsMatch(email))
                return true;

            _Validation.AddError("Email", "Informe um E-mail válido.");
            return false;
        }

        public bool IsValid(Person person)
        {
            if (String.IsNullOrEmpty(person.Name))
                _Validation.AddError("Name", "Informe o seu Nome.");

            if (null == person.DateOfBirth)
                _Validation.AddError("DateOfBirth", "Informe sua Data de Nascimento.");
            else if (person.DateOfBirth < new DateTime(1900, 1, 1) || person.DateOfBirth > DateTime.Now.Date)
                _Validation.AddError("DateOfBirth", "Data de Nascimento Inválida.");
            else if (this.GetAge(person) < 18)
                _Validation.AddError("DateOfBirth", "Você precisa ter 18 anos ou mais para particpar do leilão.");

            this.IsValidEmail(person.Email);

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
