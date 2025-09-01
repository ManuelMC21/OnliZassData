using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.MfaMethods;

public sealed class MfaMethod : BaseEntity
{
    public required int UserId { get; set; }
    public User? User { get; set; }

    public required MfaMethodType MethodType { get; set; }
    public int? PhoneNumberId { get; set; } // SMS
    public string? Email { get; set; } // Email
    public string? SecretKey { get; set; } // TOTP
    public bool IsPreferred { get; set; }
}