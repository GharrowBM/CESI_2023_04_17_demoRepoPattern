using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoCESI.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T? DeleteById(int id);
        T? Update(T entity);
        T? Insert(T entity);
    }
}
