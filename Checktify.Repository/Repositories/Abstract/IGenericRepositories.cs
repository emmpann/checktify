using Checktify.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Checktify.Repository.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T:class,IBaseEntity
    {
        Task AddEntityAsync(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        IQueryable<T> GetAllEntityList();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<T> GetEntityByIdAsync(Guid id);
    }
}
