using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Trace;

public class CurrencyLog : BaseEntity
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }

    // Relación con Currency
    public int CurrencyId { get; set; }
    public string CurrencyName { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = string.Empty;

    // Relacion con User
    public int UserId { get; set; }
    public User User { get; set; } = default!;

    public CurrencyLog() { }
}