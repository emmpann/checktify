using Checktify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Application.Interfaces
{
    public interface IAttendanceRepository
    {
        Task AddAsync(Attendance attendance);
        Task<IEnumerable<Attendance>> GetByUserAsync(Guid userId);
    }
}
