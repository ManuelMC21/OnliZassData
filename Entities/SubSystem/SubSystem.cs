using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities;

public sealed class SubSystem : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string? Description { get; set; }
    public required string[] PhotoObjectCodes { get; set; } = [];
    
    public required string? BaseUrl { get; set; }
    public required string? SessionExpiredWebhook { get; set; }
    public required string? UserBlockedWebhook { get; set; }
    public required string? ChangedRoleWebhook { get; set; }
    public required string? ChangedPermissionWebhook { get; set; }
    public required string? VerifiedUserWebhook { get; set; }
    
    
    
    public JsonDocument? Attributes { get; set; }
    
    public ICollection<Business> Business { get; set; } = new List<Business>();
    
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    
    public ICollection<SubSystemAttributeLog> AttributeLogs { get; set; } = new List<SubSystemAttributeLog>();
}