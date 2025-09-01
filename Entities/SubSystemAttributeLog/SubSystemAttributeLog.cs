using onlizas.Entities.Users;
using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities;

public sealed class SubSystemAttributeLog : BaseEntity
{
    public required int SubSystemId { get; set; }
    public SubSystem? SubSystem { get; set; }
    
    public required int ChangerUserId { get; set; }
    public User? ChangerUser { get; set; }
    
    public JsonDocument? LastAttributes { get; set; }
}