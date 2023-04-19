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
                    AddressId = viewModel.AddressId,
                });
            }

            return null;
        }

        [HttpGet("clients")]
        public IEnumerable<Person> GetAll()
        {
            return _personsRepo.GetAll();
        }

        [HttpGet("client/{id}")]
        public Person? GetById(int id)
        {
            return _personsRepo.GetById(id);
        }

        [HttpDelete("client/{id}")]
        public Person? DeleteById(int id) {
            return _personsRepo.DeleteById(id);
        }

        [HttpPatch("client/{id}")]
        public Person? Update(int id, PersonViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.Id != null)
            {
                Person? toEdit = _personsRepo.GetById(id);

                if (toEdit != null)
                {
                    toEdit.FirstName = viewModel.FirstName;
                    toEdit.LastName = viewModel.LastName;
                    toEdit.Email = viewModel.Email;
                    toEdit.Phone = viewModel.Phone;
                    toEdit.AddressId = viewModel.AddressId;
                    
                    return _personsRepo.Update(toEdit);
                }

            }

            return null;
        }
    }
}
