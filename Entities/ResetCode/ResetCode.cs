using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class ResetCode: BaseEntity
{
    public required string Code { get; init; }
    public string? Email { get; set; }
    
    public int? PhoneNumberId { get; set; }
    public PhoneNumber? PhoneNumber { get; set; }
    
    public required int UserId { get; set; }
    public User? User { get; set; }
}