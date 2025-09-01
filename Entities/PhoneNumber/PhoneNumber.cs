using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class PhoneNumber : BaseEntity
{
    public required string Number { get; set; }
    public bool IsVerified { get; set; } = false;
    
    public required int CountryId { get; set; }
    public Country? Country { get; set; }
    
    public required int UserId { get; set; }
    public User? User { get; set; }
}