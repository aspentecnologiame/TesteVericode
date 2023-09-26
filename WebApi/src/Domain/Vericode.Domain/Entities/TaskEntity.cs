using System;
using System.Collections.Generic;
using System.Text;
using Vericode.Domain.Entities.Base;

namespace Vericode.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
