using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Domain.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime Date { get; set; }
    }
}
