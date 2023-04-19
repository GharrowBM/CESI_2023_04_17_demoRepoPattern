using demoCESI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCESI.Data
{
    public class AddressesRepository : BaseRepository, IRepository<Address>
    {
        public AddressesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Address? DeleteById(int id)
        {
            Address? found = GetById(id);

            if (found != null)
            {
                _context.Addresses.Remove(found);

                if (_context.SaveChanges() > 0)
                {
                    return found;
                }
            }

            return null;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.Include(x => x.Persons).ToArray();
        }

        public Address? GetById(int id)
        {
            return _context.Addresses.Include(x => x.Persons).SingleOrDefault(x => x.Id == id);
        }

        public Address? Insert(Address entity)
        {
            _context.Addresses.Add(entity);

            if (_context.SaveChanges() > 0) {
                return entity;
            }

            return null;
        }

        public Address? Update(Address entity)
        {
            Address? found = GetById(entity.Id);

            if (found != null)
            {
                found.StreetNumber = entity.StreetNumber;
                found.StreetName = entity.StreetName;
                found.PostalCode = entity.PostalCode;
                found.Vicinity = entity.Vicinity;

                if (_context.SaveChanges() > 0)
                {
                    return found;
                }
            }

            return null;
        }
    }
}
