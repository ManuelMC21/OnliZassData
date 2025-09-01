using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class Session : BaseEntity
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public required bool IsClosed { get; set; }
    public required string Ip { get; set; }
    public required string? UserAgent { get; set; }
    public required string? Device { get; set; }
    public required string? Browser { get; set; }
    public required string? OperatingSystem { get; set; }
    public required DateTimeOffset LastRefreshDateTime { get; set; }
    public required DateTimeOffset TokenExpiresAtDateTime { get; set; }
    public required DateTimeOffset RefreshTokenExpiresAtDateTime { get; set; }
    
    public int? CountryId { get; set; }
    public Country? Country { get; set; }
    
    public required int UserId { get; set; }
    public User? User { get; set; }
    
    public SocialLogin? SocialLogin { get; set; }
}