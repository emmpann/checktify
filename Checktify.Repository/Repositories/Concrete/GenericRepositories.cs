using Checktify.Core.Entities;
using Checktify.Repository.Context;
using Checktify.Repository.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Text;

namespace Checktify.Repository.Repositories.Concrete
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class, IBaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepositories(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddEntityAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void UpdateEntity(T entity)
        {
            _dbSet.Update(entity);
        }

        public void DeleteEntity(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAllEntityList()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsNoTracking().AsQueryable();
        }

        public async Task<T> GetEntityByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
