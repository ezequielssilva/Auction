using Auction.Core.Models;
using Auction.Core.Services;
using Auction.Core.Validations;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifaceEmail([Bind("Email")] string email)
        {
            _ValidationWrapper.SetModelState(this.ModelState);

            if (!_PersonService.IsValidEmail(email))
                return View();

            var person = _PersonService.GetPersonByEmail(email);

            if (null == person)
                return RedirectToAction("Create", "Person", new { email = email });

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
