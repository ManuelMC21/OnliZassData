using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class Country : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required int PhoneNumberCode { get; set; }
    
    public required ICollection<IpRange> IpRanges { get; set; } = new List<IpRange>();
    
    public ICollection<State> States { get; set; } = new List<State>();
    
    public required int RegionId {get; set;}
    public Region? Region { get; set; }
    public int? ApprovalProcessId { get; set; }
    public ApprovalProcess? ApprovalProcess { get; set; }
    public TwilioConfig? TwilioConfig { get; set; }
}