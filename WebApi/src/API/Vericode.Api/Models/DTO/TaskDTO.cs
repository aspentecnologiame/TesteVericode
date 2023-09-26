using Vericode.Domain.Enums;

namespace Vericode.Api.Models.DTO
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public TaskEnum Status { get; set; }
        public DateTime Date { get; set; }
    }
}
