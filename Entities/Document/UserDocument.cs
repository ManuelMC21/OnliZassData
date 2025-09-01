using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class UserDocument : BaseEntity
{
    public required string Name { get; set; }
    public required string? Description { get; set; }
    public required string ObjectCode { get; set; }

    public required int UserId { get; set; }
    public User? User { get; set; }
}