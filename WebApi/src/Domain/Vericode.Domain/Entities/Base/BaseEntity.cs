using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
