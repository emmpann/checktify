using Checktify.Repository.Context;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.Repositories.Concrete;
using Checktify.Repository.UnitOfWorks.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.UnitOfWorks.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        IGenericRepositories<T> IUnitOfWork.GetGenericRepository<T>()
        {
            return new GenericRepositories<T>(_context);
        }
    }
}
