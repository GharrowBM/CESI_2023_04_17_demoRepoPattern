using demoCESI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCESI.Data
{
    public class PersonsRepository : BaseRepository, IRepository<Person>
    {
        public PersonsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Person? DeleteById(int id)
        {
            Person? foundPerson = GetById(id);

            if (foundPerson != null)
            {
                _context.Persons.Remove(foundPerson);

                if (_context.SaveChanges() > 0)
                {
                    return foundPerson;
                }
            }

            return null;
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Persons.Include(x => x.Address).ToArray();
        }

        public Person? GetById(int id)
        {
            return _context.Persons.Include(x => x.Address).SingleOrDefault(x => x.Id == id);
        }

        public Person? Insert(Person entity)
        {
            _context.Persons.Add(entity);

            if (_context.SaveChanges() > 0) {
                return entity;
            }

            return null;
        }

        public Person? Update(Person entity)
        {
            Person? foundPerson = GetById(entity.Id);

            if (foundPerson != null)
            {
                foundPerson.FirstName = entity.FirstName;
                foundPerson.LastName = entity.LastName;
                foundPerson.Email = entity.Email;
                foundPerson.Phone = entity.Phone;
                foundPerson.AddressId = entity.AddressId;

                if (_context.SaveChanges() > 0)
                {
                    return foundPerson;
                }
            }

            return null;
        }
    }
}
