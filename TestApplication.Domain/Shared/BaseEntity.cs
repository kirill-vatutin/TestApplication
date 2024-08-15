using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Domain.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get;private set; }

        protected BaseEntity() { }
    }
}
