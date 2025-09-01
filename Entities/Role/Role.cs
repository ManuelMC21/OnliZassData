using onlizas.Entities.Users;
using onlizas.Shared.Entities;
using onlizas.Entities.Permissions;

namespace onlizas.Entities;

public sealed class Role : BaseEntity
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string? Description { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public required int SubSystemId { get; set; }
    public SubSystem? SubSystem { get; set; }
    
    public ICollection<string> NotSyncPermissions = new List<string>();
    public ICollection<Guid> NotSyncUsers = new List<Guid>();
}