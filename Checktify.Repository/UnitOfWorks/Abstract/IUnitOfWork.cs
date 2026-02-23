using Checktify.Core.Entities;
using Checktify.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.UnitOfWorks.Abstract
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        IGenericRepositories<T> GetGenericRepository<T>() where T : class, IBaseEntity, new();
        ValueTask DisposeAsync();
    }
}
