using demoCESI.Data;
using demoCESI.Models;
using demoCESI.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoCESI.WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IRepository<Address> _addressesRepo;

        public AddressesController(IRepository<Address> addressesRepo)
        {
            _addressesRepo = addressesRepo;
        }

        [HttpGet("addresses")]
        public IEnumerable<Address> GetAll() {
            return _addressesRepo.GetAll();
        }

        [HttpGet("address/{id}")]
        public Address? GetById(int id)
        {
            return _addressesRepo?.GetById(id);
        }

        [HttpPost("address")]
        public Address? Insert(AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return _addressesRepo.Insert(new Address()
                {
                    StreetNumber = viewModel.StreetNumber,
                    StreetName = viewModel.StreetName,
                    PostalCode = viewModel.PostalCode,
                    Vicinity = viewModel.Vicinity,
                });
            }

            return null;
        }

        [HttpDelete("address/{id}")]
        public Address? DeleteById(int id)
        {
            return _addressesRepo.DeleteById(id);
        }

        [HttpPatch("address/{id}")]
        public Address? Update(int id, AddressViewModel viewModel) {

            if (ModelState.IsValid && viewModel.Id != null)
            {
                Address? toEdit = _addressesRepo.GetById(id);

                if (toEdit != null)
                {
                    toEdit.StreetName = viewModel.StreetName;
                    toEdit.StreetNumber = viewModel.StreetNumber;
                    toEdit.PostalCode = viewModel.PostalCode;
                    toEdit.Vicinity = viewModel.Vicinity;

                    return _addressesRepo.Update(toEdit); 
                }
            }

            return null;
        }
    }
}
