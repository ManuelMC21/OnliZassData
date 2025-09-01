using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class SocialLogin : BaseEntity
{
    public required int SessionId { get; set; }
    public Session? Session { get; set; }
    
    public string? Email { get; set; }
    public int? PhoneNumberId { get; set; }   
    public PhoneNumber? PhoneNumber { get; set; }
    
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public DateTimeOffset? ExpiresAt { get; set; }
}