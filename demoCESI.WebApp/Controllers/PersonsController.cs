using demoCESI.Data;
using demoCESI.Models;
using demoCESI.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoCESI.WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IRepository<Person> _personsRepo;

        public PersonsController(IRepository<Person> personsRepo)
        {
            _personsRepo = personsRepo;
        }

        [HttpPost("client")]
        public Person? Insert(PersonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return _personsRepo.Insert(new Person()
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                });
            }

            return null;
        }

        [HttpGet("clients")]
        public IEnumerable<Person> GetAll()
        {
            return _personsRepo.GetAll();
        }
    }
}
