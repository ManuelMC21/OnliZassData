using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class TwilioConfig: BaseEntity
{
    public required int CountryId {get; set;}
    public Country? Country { get; set; }
    
    public required string AccountSid { get; set; }
    public required string AuthToken { get; set; }
    public required string FromNumber { get; set; }
    
    public required bool IsEnabled { get; set; }
}