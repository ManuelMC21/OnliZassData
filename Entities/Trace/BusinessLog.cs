using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class BusinessLog : BaseEntity
{
    public Guid BusinessGuid { get; set; } // Identificador único
    public string BusinessName { get; set; } = string.Empty; 
    public string BusinessCode { get; set; } = string.Empty; 

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    // Relación con Location
    public int? LocationId { get; set; }
    public string? LocationName { get; set; }

    // Datos del propietario
    public int OwnerId { get; set; }
    public string OwnerName { get; set; } = string.Empty;

    public BusinessLog() { }
}
