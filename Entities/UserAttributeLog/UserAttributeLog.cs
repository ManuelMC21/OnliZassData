using onlizas.Entities.Users;
using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities;

public sealed class UserAttributeLog: BaseEntity
{
    public required int ChangedUserId { get; set; }
    public User? ChangedUser { get; set; }
    
    public required int ChangerUserId { get; set; }
    public User? ChangerUser { get; set; }
    
    public JsonDocument? LastAttributes { get; set; }
}