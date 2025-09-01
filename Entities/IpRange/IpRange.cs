using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class IpRange : BaseEntity
{
    public required uint IpStart { get; set; }
    public required uint IpEnd { get; set; }
    
    public int CountryId { get; set; } 
    public Country Country { get; set; } = default!;
}