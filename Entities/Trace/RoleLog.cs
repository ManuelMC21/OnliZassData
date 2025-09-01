using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class RoleLog : BaseEntity
{
    public Guid RoleGuid { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string RoleCode { get; set; } = string.Empty;
    public string? RoleDescription { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public RoleLog() { }
}