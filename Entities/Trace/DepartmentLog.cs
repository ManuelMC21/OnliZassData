using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class DepartmentLog : BaseEntity
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }

    // Relación con Departamento
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    // Relación con Usuario
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public DepartmentLog() { }
}
