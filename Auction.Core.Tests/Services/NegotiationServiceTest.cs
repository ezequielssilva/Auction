using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Core.Tests.FakeRepositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace Auction.Core.Tests.Services
{
    [TestClass]
    public class NegotiationServiceTest
    {
        private NegotiationService _NegotiationService;

        public NegotiationServiceTest()
        {
            _NegotiationService = new NegotiationService(
                new ModelStateDictionary(),
                new FakeNegotiationRepository());
        }

        [TestMethod]
        public void IsValidNegotiation()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Document = "44000383787";
            person.DateOfBirth = new DateTime(1995, 10, 12);

            var product = new Product();
            product.Name = "Macbook Pro 2020";
            product.Value = 15000;

            var negotiation = new Negotiation();
            negotiation.PersonId = 1;
            negotiation.Person = person;
            negotiation.ProductId = 1;
            negotiation.Product = product;
            negotiation.Value = 16000;

            Assert.IsTrue(_NegotiationService.IsValid(negotiation));
        }

        [TestMethod]
        public void IsInvalidNegotiationWhenTradingValueLessThanProductValue()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Document = "44000383787";
            person.DateOfBirth = new DateTime(1995, 10, 12);

            var product = new Product();
            product.Name = "Macbook Pro 2020";
            product.Value = 15000;

            var negotiation = new Negotiation();
            negotiation.PersonId = 1;
            negotiation.Person = person;
            negotiation.ProductId = 1;
            negotiation.Product = product;
            negotiation.Value = 14000;

            Assert.IsFalse(_NegotiationService.IsValid(negotiation));
        }

        [TestMethod]
        public void IsInvalidNegotiationWhenValueIsLessThanTheValueOfTheLastTrade()
        {
            var person = new Person();
            person.Name = "Marcos Ferreira";
            person.Document = "44000383787";
            person.DateOfBirth = new DateTime(1995, 10, 12);

            var product = new Product();
            product.Name = "Macbook Pro 2020";
            product.Value = 15000;

            var negotiation1 = new Negotiation();
            negotiation1.PersonId = 1;
            negotiation1.Person = person;
            negotiation1.ProductId = 1;
            negotiation1.Product = product;
            negotiation1.Value = 16000;

            _NegotiationService.CreateNegotiation(negotiation1);

            var negotiation2 = new Negotiation();
            negotiation2.PersonId = 1;
            negotiation2.Person = person;
            negotiation2.ProductId = 1;
            negotiation2.Product = product;
            negotiation2.Value = 15500;

            Assert.IsFalse(_NegotiationService.IsValid(negotiation2));
        }
    }
}
