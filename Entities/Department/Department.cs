using onlizas.Entities.Trace;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Department : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();

    // Relaci?n con logs
    public List<DepartmentLog> Logs { get; set; } = new List<DepartmentLog>();
}