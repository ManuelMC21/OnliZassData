using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Email : BaseEntity
{
    public required string Address { get; set; }
    public bool IsVerified { get; set; } = false;
    
    public required int UserId { get; set; }
    public User? User { get; set; }
}