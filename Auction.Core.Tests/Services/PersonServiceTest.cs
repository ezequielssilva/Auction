﻿using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Core.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Auction.Core.Tests.Services
{
    [TestClass]
    public class PersonServiceTest
    {
        private IPersonService _PersonService;

        public PersonServiceTest()
        {
            _PersonService = new PersonService(
                new ValidationCollection(),
                new FakePersonRepository());
        }

        [TestMethod]
        public void IsValidPerson()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Email = "marcosferreira@email.com";
            person.DateOfBirth = new DateTime(1995, 10, 12);

            Assert.IsTrue(_PersonService.IsValid(person));
        }

        [TestMethod]
        public void IsinvalidPerson()
        {
            var person = new Person();
            person.Name = "";
            person.Email = "marcosferreira@email.com";
            person.DateOfBirth = new DateTime(0001, 1, 1);

            Assert.IsFalse(_PersonService.IsValid(person));
        }

        [TestMethod]
        public void IsInvalidPersonWhenAgeUnder18()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Email = "marcosferreira@email.com";
            person.DateOfBirth = DateTime.Now.AddYears(-17);

            Assert.IsFalse(_PersonService.IsValid(person));
        }

        [TestMethod]
        public void IsInvalidPersonWhenEmailIsInvalid()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Email = "marcosferreira.email.com";
            person.DateOfBirth = DateTime.Now.AddYears(-17);

            Assert.IsFalse(_PersonService.IsValid(person));
        }
    }
}
