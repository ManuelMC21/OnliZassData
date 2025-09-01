// Entities/Trace/UserLog.cs
using onlizas.Entities.Users;
using onlizas.Shared.Entities;

public class UserLog : BaseEntity
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;

    public bool IsBlocked { get; set; }
    public bool IsVerified { get; set; }
    public UserApiRole ApiRole { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }

    public int ChangedById { get; set; }

    // ✅ Relación con el usuario que hizo el cambio
    public User? ChangedByUser { get; set; }

    public UserLog() { }
}