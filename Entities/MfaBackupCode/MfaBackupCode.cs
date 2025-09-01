using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class MfaBackupCode : BaseEntity
{
    public required int UserId { get; set; }
    public User? User { get; set; }

    public required string CodeHash { get; set; }
    public bool TimesUsed { get; set; } = false;
    public DateTime ExpiresAt { get; set; }
}