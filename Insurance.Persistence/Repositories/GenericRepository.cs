using Insurance.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T
        : class
    {
        private readonly InsuranceDbContext _dbContext;

        public GenericRepository(InsuranceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<T> Detele(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
            
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
