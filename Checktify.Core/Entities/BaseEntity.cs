using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string CreatedDate { get; set; } = null!;
        public virtual string? UpdatedDate { get; set; }
        public virtual byte[] RowVersion { get; set; } = null!;
    }
}
