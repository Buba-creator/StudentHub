using StudentHub.Data;
using StudentHub.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T:class 
    {
        private readonly ApplicationDbContext dbContext;
        public Repository(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public async Task Delete(T entity)
        {
            dbContext.Remove(entity);
           await dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int? id)
        {
          return await dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> Get(Func<T, bool> func)
        {
            return  dbContext.Set<T>().Where(func).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public async Task Post(T entity)
        {
            dbContext.Add(entity);
          await  dbContext.SaveChangesAsync();
        }

        public async Task Put(T entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
