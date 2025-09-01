using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class CategoryLog : BaseEntity
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }

    // Relación con Category
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    //Relacion con Departamento
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

    // Relacion con User
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public CategoryLog() { }
}