using onlizas.Entities.Users;
using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities;

public sealed class BusinessAttributeLog : BaseEntity
{
    public required int BusinessId { get; set; }
    public required Business Business { get; set; }
    
    public required int ChangerUserId { get; set; }
    public required User ChangerUser { get; set; }
    
    public JsonDocument? LastAttributes { get; set; }
}