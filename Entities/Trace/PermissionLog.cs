using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class PermissionLog : BaseEntity
{
    public Guid PermissionGuid { get; set; } = Guid.NewGuid();
    public string PermissionName { get; set; } = string.Empty;
    public string PermissionCode { get; set; } = string.Empty;
    public string? PermissionEntity { get; set; }
    public string? PermissionType { get; set; }
    public string? PermissionDescription { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public PermissionLog() { }
}