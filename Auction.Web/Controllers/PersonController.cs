using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Web.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _PersonService;
        private IValidationWrapper _ValidationWrapper;

        public PersonController(
            IPersonService personService,
            IValidationWrapper wrapper)
        {
            _PersonService = personService;
            _ValidationWrapper = wrapper;
        }

        [HttpGet]
        public IActionResult VerifaceEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifaceEmail([Bind("Email")] Person personParam)
        {
            _ValidationWrapper.SetModelState(this.ModelState);

            if (!_PersonService.IsValidEmail(personParam.Email))
            {
                _ValidationWrapper.MapTo(_PersonService.GetErrors());
                return View();
            }

            var person = _PersonService.GetPersonByEmail(personParam.Email);

            if (null == person)
                return RedirectToAction("Create", "Person", new { email = personParam.Email });

            return RedirectToAction("Index", "Negotiation", new { personId = person.Id });
        }

        [HttpGet]
        [Route("Person/Create/{email}")]
        public IActionResult Create(string email)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Email,Name,DateOfBirth")] Person person)
        {
            _ValidationWrapper.SetModelState(this.ModelState);

            if (_PersonService.CreatePerson(person))
                return RedirectToAction("Index", "Negotiation", new { personId = person.Id });

            _ValidationWrapper.MapTo(_PersonService.GetErrors());
            return View();
        }
    }
}
