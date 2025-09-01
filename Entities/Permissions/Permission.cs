using onlizas.Shared.Entities;

namespace onlizas.Entities.Permissions;

public sealed class Permission : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string? Entity { get; set; }
    public required PermissionType? PermissionType { get; set; }
    public required string? Description { get; set; }

    public int? RoleId { get; set; }
    public Role? Role { get; set; }

    public Guid? NotSyncRole{ get; set; }
    
    public bool RoleSyncronized { get; set; } = true;
}