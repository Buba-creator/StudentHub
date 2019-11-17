using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Repository.Abstraction
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        Task<T> Get(int? id);

        IEnumerable<T> Get(Func<T, bool> func);

        Task Put(T entity);

        Task Delete(T entity);

        Task Post(T entity);
    }
}
